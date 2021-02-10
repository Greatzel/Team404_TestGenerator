The TestCaseGenerator is an application that presently runs as an NUnit test suite.
Tests are run from the module \Tests\GeneratorTests.cs.

Each individual test case has two parameters:
	* inputFilename: the name of a file (not including path) containing XML that defines a "test specification."
	* outputFilename: the name of a file (not including path) where the text for generated test cases is written.

The path where input files are stored is defined in the file \Helpers\FileHelper.cs in the constant PathTestGenerator.
Its value is presently \\denver2\backup\UDT\Testing\Specifications. Output files are also written to this same folder.

DEFINING A TEST SPECIFICATION

The XML input file is bounded by the <TestSpecification> tag, which has two parameters

A <TestSpecification> may have the following XML data and tags associated with it:
	* Attribute - Name: the logical name of the test suite (used internally).
	* Attribute - Text: the test suite's name as it appears in the output file.
	* 0-1 <FieldsAsAttributes>: true if tag attributes are processed as XML attributes (otherwise processed as elements).
	* 0 or more <CoverageGroup>: defines a combination of input parameters that must be covered exhaustively.
	* 0 or more <InputParameter>: defines an input parameter for the tests with equivalence classes.
	* 0 or more <ExpectedResult> defines an expected result for the tests.

A <CoverageGroup> may have the following XML data and tags associated with it:
	* Attribute - Name: the logical name of the coverage group.
	* 1 or more <Parameter>: names an input parameter that is included in the coverage group.

An <InputParameter> may have the following XML data and tags associated with it:
	* Attribute - Name: the logical name of the input parameter.
	* Attribute - Text: the parameter's name as it appears in the output file.
	* 1 or more <EquivalenceClass>: an equivalence class that partitions the value space for the parameter.

An <EquivalenceClass> may have the following XML data and tags associated with it:
	* Attribute - Name: the logical name of the equivalence class.
	* Attribute - Text: the class's value as it appears in the output file.
	* 0 or 1 <Expression>: an expression that may be unary <ExpressionUnary>, binary <ExpressionBinary>, or relational <ExpressionRelational>.

An <ExpressionUnary> may have the following XML data and tags associated with it:
	* Atribute - Operator: the name of the unary operator (e.g. NOT).
	* 1 <Expression>: the argument of the unary operator.

An <ExpressionBinary> may have the following XML data and tags associated with it:
	* Atribute - Operator: the name of the binary operator (e.g. AND, OR).
	* 1 or more <Expression>: the ordered arguments of the binary operator.

An <ExpressionRelational> may have the following XML data and tags associated with it:
	* Atribute - Operator: the name of the relational operator (e.g. EQ, NEQ, LT, LE, GT, GE).
	* Attribute - Parameter: the name of an input parameter.
	* Attribute - EquivalenceClass: the name of an equivalence class or hard-coded value.

An <ExpectedResult> may have the following XML data and tags associated with it:
	* Attribute - Name: the logical name of the expected result.
	* Attribute - Text: the name of the expected result as it appears in the output file.
	* 1 <Expression> the argument of the expected result that must evaluate to TRUE for the result to belong to a test case.

READING THE GENERATED TEST SUITE

The format of an output file is constructed from a general pattern that uses the TEXT attributes
of the elements specified in the XML input file.

The file first specifies the test suite's logical and printed names, followed by the details for
each (ordered) "consistent" test cases.

Following this, any "contradictory" test cases are enumerated. These are generated tests that are discarded
because any of the <Expression> tags associated with the tests' selected equivalence classes evaluate to FALSE.

Finally, test coverage data for the <CoverageGroup> tags is enumerated.

A consistent test case is displayed in WHEN <ParametersAndValues> THEN <Results> format.

<ParametersAndValues> is an AND-separated phrase that specifies, for each input parameter, the name of the
parameter and the value of the equivalence class selected for this test case.

<Results> is an AND-separated phrase that specifies the text of expected results whose <Expression> tags
evaluate to TRUE for this test case.
