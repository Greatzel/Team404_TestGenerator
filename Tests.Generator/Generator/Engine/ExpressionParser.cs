//// ********************************************************************************
//// Created by:    Jim Wood 
//// Date created:  05/24/2017
//// Reason:
////     ULTI-249839: Write a tool to generate test cases from an XML specification.
//// ********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;

namespace Generator.Engine
{
    /// <summary>
    /// Enumerates the types of expression notations.
    /// </summary>
    public enum NotationEnum
    {
        Infix,
        Prefix,
        Postfix
    };

    /// <summary>
    /// Class that encapsulates an expression (or sub-expression) used in the
    /// expected result of a test specification.
    /// </summary>
    public class ExpressionParser
    {
        public const string BracketLeft = "[";
        public const string BracketRight = "]";
        public const string ParenthesisLeft = "(";
        public const string ParenthesisRight = ")";
        public const string Comma = ",";
        public const string OperatorOr = "OR";
        public const string OperatorAnd = "AND";
        public const string OperatorNot = "NOT";
        public const string OperatorEqualAsName = "EQ";
        public const string OperatorEqualAsSymbol = "=";
        public const string OperatorNotEqualAsName = "NEQ";
        public const string OperatorNotEqualAsSymbol = "!=";
        public const string OperatorLessAsName = "LT";
        public const string OperatorLessAsSymbol = "<";
        public const string OperatorLessEqualAsName = "LEQ";
        public const string OperatorLessEqualAsSymbol = "<=";
        public const string OperatorGreaterAsName = "GT";
        public const string OperatorGreaterAsSymbol = ">";
        public const string OperatorGreaterEqualAsName = "GEQ";
        public const string OperatorGreaterEqualAsSymbol = ">=";

        /// <summary>
        /// Lists all of the relational operator tokens.
        /// </summary>
        public static IList<string> BooleanOperators = new List<string>
        {
            OperatorOr,
            OperatorAnd,
            OperatorNot
        };

        /// <summary>
        /// Lists all of the relational operator tokens.
        /// </summary>
        public static IList<string> RelationalOperators = new List<string>
        {
            OperatorEqualAsSymbol,
            OperatorNotEqualAsSymbol,
            OperatorLessAsSymbol,
            OperatorLessEqualAsSymbol,
            OperatorGreaterAsSymbol,
            OperatorGreaterEqualAsSymbol,
            OperatorEqualAsName,
            OperatorNotEqualAsName,
            OperatorLessAsName,
            OperatorLessEqualAsName,
            OperatorGreaterAsName,
            OperatorGreaterEqualAsName
        };

        /// <summary>
        /// Lists all of punctuation substrings of length 1.
        /// </summary>
        public static IList<string> Punctuation = new List<string>
        {
            BracketLeft,
            BracketRight,
            ParenthesisLeft,
            ParenthesisRight,
            Comma
        };

        /// <summary>
        /// Parses the string (represented in infix, prefix, or postfix notation)
        /// and returns the resulting expression. The default notation is INFIX.
        /// </summary>
        public static Expression Parse(string expressionAsString, NotationEnum notation = NotationEnum.Infix)
        {
            IList<string> expressionTokens = OrderedTokens(expressionAsString);
            if (!expressionTokens.Any())
            {
                return null;
            }

            int index = 0;
            return ParseOr(expressionTokens, ref index);
        }

        /// <summary>
        /// Parses and returns an OR expression.
        /// </summary>
        private static Expression ParseOr(IList<string> expressionTokens, ref int index)
        {
            IList<Expression> operands = new List<Expression>();
            Expression operand = ParseAnd(expressionTokens, ref index);
            if (operand != null)
            {
                operands.Add(operand);
            }

            while (Token(expressionTokens, index, true) == OperatorOr)
            {
                index++;
                operand = ParseAnd(expressionTokens, ref index);
                if (operand != null)
                {
                    operands.Add(operand);
                }
            }

            return ExpressionBinary.Build(operands, OperatorOr);
        }

        /// <summary>
        /// Parses and returns an AND expression.
        /// </summary>
        private static Expression ParseAnd(IList<string> expressionTokens, ref int index)
        {
            IList<Expression> operands = new List<Expression>();
            Expression operand = ParseNot(expressionTokens, ref index);
            if (operand != null)
            {
                operands.Add(operand);
            }

            while (Token(expressionTokens, index, true) == OperatorAnd)
            {
                index++;
                operand = ParseNot(expressionTokens, ref index);
                if (operand != null)
                {
                    operands.Add(operand);
                }
            }

            return ExpressionBinary.Build(operands, OperatorAnd);
        }

        /// <summary>
        /// Parses and returns a NOT expression.
        /// </summary>
        private static Expression ParseNot(IList<string> expressionTokens, ref int index)
        {
            string unaryOperator = string.Empty;
            if (Token(expressionTokens, index, true) == OperatorNot)
            {
                index++;
                unaryOperator = OperatorNot;
            }

            return ExpressionUnary.Build(ParseRelational(expressionTokens, ref index), unaryOperator);
        }

        /// <summary>
        /// Parses and returns a relational expression.
        /// </summary>
        private static Expression ParseRelational(IList<string> expressionTokens, ref int index)
        {
            IList<Expression> operands = new List<Expression>();
            Expression operand = ParseOperand(expressionTokens, ref index);
            if (operand != null)
            {
                operands.Add(operand);
            }

            string relationalOperator = Token(expressionTokens, index, true);
            if (RelationalOperators.Contains(relationalOperator))
            {
                index++;
                operand = ParseOperand(expressionTokens, ref index);
                if (operand != null)
                {
                    operands.Add(operand);
                }
            }

            return ExpressionRelational.Build(operands, relationalOperator);
        }

        /// <summary>
        /// Parses and returns the operand (or parenthesized expression) as an expression.
        /// </summary>
        private static Expression ParseOperand(IList<string> expressionTokens, ref int index)
        {
            string token = Token(expressionTokens, index, false);
            if (token == ParenthesisLeft)
            {
                index++;
                Expression expression = ParseOr(expressionTokens, ref index);
                if ((expression == null) || (Token(expressionTokens, index, false) != ParenthesisRight))
                {
                    return null;
                }

                index++;
                return expression;
            }

            if (token == BracketLeft)
            {
                index++;
                IList<string> alternatives = new List<string>();
                string alternative = Token(expressionTokens, index, false);
                while (alternative != BracketRight)
                {
                    alternatives.Add(alternative);
                    index++;

                    alternative = Token(expressionTokens, index, false);
                    if (alternative == Comma)
                    {
                        index++;
                        alternative = Token(expressionTokens, index, false);
                    }
                }

                index++;
                return ExpressionOperand.Build(alternatives);
            }

            index++;
            return ExpressionOperand.Build(token);
        }

        /// <summary>
        /// Reads and returns the ordered list of tokens in the string.
        /// </summary>
        private static List<string> OrderedTokens(string expressionAsString)
        {
            List<string> orderedTokens = new List<string>();
            if (string.IsNullOrEmpty(expressionAsString))
            {
                return orderedTokens;
            }

            string[] tokensWithoutWhiteSpace = expressionAsString.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string token in tokensWithoutWhiteSpace)
            {
                List<string> tokensAndParentheses = OrderedTokensAndPunctuation(token);
                if (tokensAndParentheses.Any())
                {
                    orderedTokens.AddRange(tokensAndParentheses);
                }
            }

            return orderedTokens;
        }

        /// <summary>
        /// Reads and returns the ordered list of tokens, including parentheses, in the string.
        /// </summary>
        private static List<string> OrderedTokensAndPunctuation(string token)
        {
            List<string> orderedTokens = new List<string>();

            int index = 0;
            while (index < token.Length)
            {
                int start = index;
                int end = index;
                if (Punctuation.Contains(token.Substring(index, 1)))
                {
                    end = index + 1;
                }
                else
                {
                    while ((end < token.Length) && !Punctuation.Contains(token.Substring(end, 1)))
                    {
                        end++;
                    }
                }

                if (end > start)
                {
                    orderedTokens.Add(token.Substring(start, end - start));
                }

                index = end;
            }

            return orderedTokens;
        }

        /// <summary>
        /// Returns the specific token in the list if it exists (otherwise NULL).
        /// </summary>
        private static string Token(IList<string> expressionTokens, int index, bool toUpper)
        {
            if ((expressionTokens == null) || !expressionTokens.Any() || (index >= expressionTokens.Count))
            {
                return null;
            }

            return toUpper ? expressionTokens[index].ToUpper() : expressionTokens[index];
        }
    }
}
