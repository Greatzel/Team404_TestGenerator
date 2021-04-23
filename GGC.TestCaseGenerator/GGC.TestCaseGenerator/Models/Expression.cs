using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGC.TestCaseGenerator.Models
{
    /// <summary>
    /// Class that encapsulates an expression (or sub-expression) used in the
    /// expected result of a test specification.
    /// </summary>
    public class Expression
    {
        /// <summary>
        /// Returns true if the parameter assignments match the constraints in the expression.
        /// </summary>
        public virtual bool Match(IDictionary<string, ParameterAssignment> parameterAssignments)
        {
            return true;
        }

        /// <summary>
        /// Returns the list of parameter and equivalence class references in the expression.
        /// </summary>
        public virtual void SaveReferences(IList<string> references)
        {
        }

        /// <summary>
        /// Class that encapsulates a binary expression used in the
        /// expected result of a test specification.
        /// </summary>
        public class ExpressionBinary : Expression
        {
            /// <summary>
            /// Binary operator of the expression (AND, OR).
            /// </summary>
            public string BinaryOperator { get; set; }

            /// <summary>
            /// Operands (at least 2) of the binary expression.
            /// </summary>
            public IList<Expression> Operands { get; set; }

            /// <summary>
            /// Constructs and initializes an instance object of the class ExpressionBinary.
            /// </summary>
            public ExpressionBinary()
            {
                BinaryOperator = null;
                Operands = null;
            }

            /// <summary>
            /// Sets the data members of the class and returns true if successful.
            /// </summary>
            public bool Set(string binaryOperator, IList<Expression> operands)
            {
                BinaryOperator = binaryOperator;
                Operands = operands;
                return true;
            }

            /// <summary>
            /// Returns true if the parameter assignments match the constraints in the binary expression.
            /// </summary>
            public override bool Match(IDictionary<string, ParameterAssignment> parameterAssignments)
            {
                if (BinaryOperator == ExpressionParser.OperatorOr)
                {
                    foreach (Expression operand in Operands)
                    {
                        if (operand.Match(parameterAssignments))
                        {
                            return true;
                        }
                    }

                    return false;
                }

                if (BinaryOperator == ExpressionParser.OperatorAnd)
                {
                    foreach (Expression operand in Operands)
                    {
                        if (!operand.Match(parameterAssignments))
                        {
                            return false;
                        }
                    }

                    return true;
                }

                return false;
            }

            /// <summary>
            /// Returns the list of parameter and equivalence class references in the expression.
            /// </summary>
            public override void SaveReferences(IList<string> references)
            {
                foreach (Expression operand in Operands)
                {

                    operand.SaveReferences(references);
                }
            }

            /// <summary>
            /// Returns a binary expression from the list of N >= 0 operands and the operator (with appropriate error handling).
            /// </summary>
            public static Expression Build(IList<Expression> operands, string binaryOperator)
            {
                if (operands.Count == 0)
                {
                    return null;
                }

                if (operands.Count == 1)
                {
                    return operands[0];
                }

                return new ExpressionBinary
                {
                    Operands = operands,
                    BinaryOperator = binaryOperator
                };
            }
        }

        /// <summary>
        /// Class that encapsulates a unary expression used in the
        /// expected result of a test specification.
        /// </summary>
        public class ExpressionUnary : Expression
        {
            /// <summary>
            /// Unary operator of the expression (NOT).
            /// </summary>
            public string UnaryOperator { get; set; }

            /// <summary>
            /// Operand of the binary expression.
            /// </summary>
            public Expression Operand { get; set; }

            /// <summary>
            /// Constructs and initializes an instance object of the class ExpressionUnary.
            /// </summary>
            public ExpressionUnary()
            {
                UnaryOperator = null;
                Operand = null;
            }

            /// <summary>
            /// Sets the data members of the class and returns true if successful.
            /// </summary>
            public bool Set(string unaryOperator, Expression operand)
            {
                UnaryOperator = unaryOperator;
                Operand = operand;
                return true;
            }

            /// <summary>
            /// Returns true if the parameter assignments match the constraints in the unary expression.
            /// </summary>
            public override bool Match(IDictionary<string, ParameterAssignment> parameterAssignments)
            {
                if (UnaryOperator == ExpressionParser.OperatorNot)
                {
                    return !Operand.Match(parameterAssignments);
                }

                return false;
            }

            /// <summary>
            /// Returns the list of parameter and equivalence class references in the expression.
            /// </summary>
            public override void SaveReferences(IList<string> references)
            {
                Operand.SaveReferences(references);
            }

            /// <summary>
            /// Returns a unary expression from an operand and the operator (with appropriate error handling).
            /// </summary>
            public static Expression Build(Expression operand, string unaryOperator)
            {
                if (operand == null)
                {
                    return null;
                }

                if (string.IsNullOrEmpty(unaryOperator))
                {
                    return operand;
                }

                return new ExpressionUnary
                {
                    Operand = operand,
                    UnaryOperator = unaryOperator
                };
            }
        }

        /// <summary>
        /// Class that encapsulates a relational expression used in the
        /// expected result of a test specification.
        /// </summary>
        public class ExpressionRelational : Expression
        {
            /// <summary>
            /// Relational operator of the expression (EQ, NEQ, LT, LEQ, GT, GEQ).
            /// </summary>
            public string RelationalOperator { get; set; }

            /// <summary>
            /// Left operand of the relational expression: a parameter name.
            /// </summary>
            public string ParameterName { get; set; }

            /// <summary>
            /// Right operand of the relational expression: an equivalence class name.
            /// </summary>
            public IList<string> EquivalenceClassNames { get; set; }

            /// <summary>
            /// Constructs and initializes an instance object of the class ExpressionRelational.
            /// </summary>
            public ExpressionRelational()
            {
                RelationalOperator = null;
                ParameterName = null;
                EquivalenceClassNames = null;
            }

            /// <summary>
            /// Sets the data members of the class and returns true if successful.
            /// </summary>
            public bool Set(string relationalOperator, string parameterName, string equivalenceClassName)
            {
                RelationalOperator = relationalOperator;
                ParameterName = parameterName;
                EquivalenceClassNames = new List<string> { equivalenceClassName };
                return true;
            }

            /// <summary>
            /// Returns true if the parameter assignments match the constraints in the relational expression.
            /// </summary>
            public override bool Match(IDictionary<string, ParameterAssignment> parameterAssignments)
            {
                ParameterAssignment assignment = parameterAssignments[ParameterName];
                switch (RelationalOperator)
                {
                    case ExpressionParser.OperatorEqualAsName:
                    case ExpressionParser.OperatorEqualAsSymbol:
                        return EquivalenceClassNames.Contains(assignment.SelectedEquivalenceClassName());
                    case ExpressionParser.OperatorNotEqualAsName:
                    case ExpressionParser.OperatorNotEqualAsSymbol:
                        return !EquivalenceClassNames.Contains(assignment.SelectedEquivalenceClassName());
                    default:
                        if (EquivalenceClassNames.Count != 1)
                        {
                            return false;
                        }

                        double expectedAsNumeric = ConvertToNumeric(EquivalenceClassNames[0]);
                        double assignedAsNumeric = ConvertToNumeric(assignment.SelectedEquivalenceClassName());
                        switch (RelationalOperator)
                        {
                            case ExpressionParser.OperatorLessAsName:
                            case ExpressionParser.OperatorLessAsSymbol:
                                return assignedAsNumeric < expectedAsNumeric;
                            case ExpressionParser.OperatorLessEqualAsName:
                            case ExpressionParser.OperatorLessEqualAsSymbol:
                                return assignedAsNumeric <= expectedAsNumeric;
                            case ExpressionParser.OperatorGreaterAsName:
                            case ExpressionParser.OperatorGreaterAsSymbol:
                                return assignedAsNumeric > expectedAsNumeric;
                            case ExpressionParser.OperatorGreaterEqualAsName:
                            case ExpressionParser.OperatorGreaterEqualAsSymbol:
                                return assignedAsNumeric >= expectedAsNumeric;
                            default:
                                return false;
                        }
                }
            }

            /// <summary>
            /// Returns the list of parameter and equivalence class references in the expression.
            /// </summary>
            public override void SaveReferences(IList<string> references)
            {
                if (!references.Contains(ParameterName))
                {
                    references.Add(ParameterName);
                }

                foreach (string equivalenceClassName in EquivalenceClassNames)
                {
                    if (!references.Contains(equivalenceClassName))
                    {
                        references.Add($"{ParameterName}.{equivalenceClassName}");
                    }
                }
            }

            /// <summary>
            /// Returns a relational expression from 2 operands and the operator (with appropriate error handling).
            /// </summary>
            public static Expression Build(IList<Expression> operands, string relationalOperator)
            {
                if (operands.Count == 1)
                {
                    return operands[0];
                }

                if (operands.Count != 2)
                {
                    return null;
                }

                ExpressionOperand parameterAsExpression = operands[0] as ExpressionOperand;
                ExpressionOperand equivalenceClassAsExpression = operands[1] as ExpressionOperand;
                if ((parameterAsExpression == null) ||
                    (equivalenceClassAsExpression == null))
                {
                    return null;
                }

                return new ExpressionRelational
                {
                    ParameterName = parameterAsExpression.Operands[0],
                    EquivalenceClassNames = equivalenceClassAsExpression.Operands,
                    RelationalOperator = relationalOperator
                };
            }

            /// <summary>
            /// Converts and returns the value as a double; returns 0.0 if the value is NOT numeric.
            /// </summary>
            private double ConvertToNumeric(string valueAsString)
            {
                double valueAsDouble = 0.0;
                double.TryParse(valueAsString, out valueAsDouble);
                return valueAsDouble;
            }
        }

        /// <summary>
        /// Class that encapsulates a single operand of an expression in the test specification.
        /// </summary>
        public class ExpressionOperand : Expression
        {
            /// <summary>
            /// Sole operand of this atomic expression.
            /// </summary>
            public IList<string> Operands { get; set; }

            /// <summary>
            /// Returns an operand expression (with appropriate error handling).
            /// </summary>
            public static Expression Build(string token)
            {
                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }

                return new ExpressionOperand
                {
                    Operands = new List<string> { token }
                };
            }

            /// <summary>
            /// Returns an operand expression (with appropriate error handling).
            /// </summary>
            public static Expression Build(IList<string> tokens)
            {
                if (tokens == null)
                {
                    return null;
                }

                return new ExpressionOperand
                {
                    Operands = tokens
                };
            }
        }
    }
}