using System;
using System.Windows.Forms;
using Generator.Engine; 

namespace TestCaseGeneratorViewer
{
    public partial class ViewManager : Form
    {
        /// <summary>
        /// The controller's reference to the data model.par
        /// </summary>Re
        private readonly ModelInterface model;

        /// <summary>
        /// Constructs and initializes an instance of the class ViewManager.
        /// </summary>
        public ViewManager()
        {
            InitializeComponent();
            model = new ModelInterface();
        }

        #region MENU COMMANDS

        /// <summary>
        /// Implements the NEW command in the file menu.
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (model.WorkingSpecificationExists() && !YesOnConfirm(
                    "Are you sure that you would like to discard the current specification?",
                    "Confirm DISCARD before NEW"))
            {
                return;
            }

            string newSpecificationName = OpenDialogForText(
                "Specification name", "Please provide a name for the new specification");

            model.SetNewSpecificationAndName(newSpecificationName);
            RefreshEntireSpecification(model.GetWorkingSpecification());
            EnableSpecificationCommandsAndButtons();
        }

        /// <summary>
        /// Implements the OPEN command in the file menu.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (model.WorkingSpecificationExists() && !YesOnConfirm(
                    "Are you sure that you would like to discard the current specification?",
                    "Confirm DISCARD before OPEN"))
            {
                return;
            }

            string specificationFile = FilenameFromDialog(new OpenFileDialog());
            if (string.IsNullOrEmpty(specificationFile))
            {
                return;
            }

            model.SetNewSpecificationFromFile(specificationFile);
            RefreshEntireSpecification(model.GetWorkingSpecification());
            EnableSpecificationCommandsAndButtons();
        }

        /// <summary>
        /// Implements the SAVE EDITS command in the file menu.
        /// </summary>
        private void saveEditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (YesOnConfirm("Are you sure that you would like to save your edits", "Confirm SAVE"))
            {
                model.SaveSpecification();
            }
        }

        /// <summary>
        /// Implements the DISCARD EDITS command in the file menu.
        /// </summary>
        private void discardEditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (YesOnConfirm("Are you sure that you would like to discard your edits", "Confirm DISCARD"))
            {
                model.DiscardSpecification();
                RefreshEntireSpecification(model.GetWorkingSpecification());
            }
        }

        /// <summary>
        /// Implements the GENERATE SCRIPT command in the file menu.
        /// </summary>
        private void generateScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string error;
            if (!model.ValidateSpecification(out error))
            {

                MessageBox.Show($"Test specification is invalid: {error}", "Cannot generate a test script:");
                return;
            }

            EnableScriptCommandsAndButtons();

            string testSuiteStatus;
            bool populatedAndWritten = model.GenerateTestSuite(out testSuiteStatus);
            MessageBox.Show(populatedAndWritten
                ? $"SUCCESS: {testSuiteStatus}"
                : $"FAILURE: {testSuiteStatus}");

            RefreshTestCases(populatedAndWritten);
            RefreshTestScript(populatedAndWritten);
            RefreshTestStatistics(populatedAndWritten);
        }

        /// <summary>
        /// Implements the WRITE SPECIFICATION command in the file menu.
        /// </summary>
        private void writeSpecificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string specificationFilename = FilenameFromDialog(new SaveFileDialog());
            if (string.IsNullOrEmpty(specificationFilename))
            {
                return;
            }

            if (!specificationFilename.EndsWith(".json"))
            {
                specificationFilename += ".json";
            }

            bool fileWritten = model.WriteSpecification(specificationFilename);
            MessageBox.Show(fileWritten
                ? $"Wrote test specification to {specificationFilename}"
                : $"Failed to write test specification to {specificationFilename}");
        }

        /// <summary>
        /// Implements the WRITE SCRIPT command in the file menu.
        /// </summary>
        private void writeScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string scriptFilename = FilenameFromDialog(new SaveFileDialog());
            if (string.IsNullOrEmpty(scriptFilename))
            {
                return;
            }

            if (!scriptFilename.EndsWith(".txt"))
            {
                scriptFilename += ".txt";
            }

            bool fileWritten = model.WriteScript(scriptFilename);
            MessageBox.Show(fileWritten
                ? $"Wrote test script to {scriptFilename}"
                : $"Failed to write test script to {scriptFilename}");
        }

        /// <summary>
        /// Implements the WRITE STATISTICS command in the file menu.
        /// </summary>
        private void writeStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string statisticsFilename = FilenameFromDialog(new SaveFileDialog());
            if (string.IsNullOrEmpty(statisticsFilename))
            {
                return;
            }

            if (!statisticsFilename.EndsWith(".txt"))
            {
                statisticsFilename += ".txt";
            }

            bool fileWritten = model.WriteStatistics(statisticsFilename);
            MessageBox.Show(fileWritten
                ? $"Wrote test statistics to {statisticsFilename}"
                : $"Failed to write test statistics to {statisticsFilename}");
        }

        /// <summary>
        /// Implements the CLOSE SPECIFICATION command in the file menu.
        /// </summary>
        private void closeSpecificationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!YesOnConfirm(
                "Are you sure that you would like to close the current specification?",
                "Confirm CLOSE"))
            {
                return;
            }

            RefreshEntireSpecification(null);
            model.Reset();
            RefreshSpecificationJson(true);
            RefreshTestCases(false);
            RefreshTestScript(false);
            RefreshTestStatistics(false);
            DisableScriptCommandsAndButtons();
            DisableSpecificationCommandsAndButtons();
        }

        /// <summary>
        /// Implements the EXIT command in the file menu.
        /// </summary>
        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool cancel;
            ExitOnConfirm(out cancel);
        }

        /// <summary>
        /// Implements a handler for exiting via the upper-right X button.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            bool cancel;
            ExitOnConfirm(out cancel);
            e.Cancel = cancel;
        }

        #endregion // MENU COMMANDS
        #region EVENT HANDLERS

        /// <summary>
        /// Handler for the form's table layout (no action).
        /// </summary>
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        /// <summary>
        /// Handler for edits to the specification's GIVEN text box.
        /// </summary>
        private void richTextBox9_TextChanged(object sender, EventArgs e)
        {
            model.SetSpecificationText(EntityEnum.Given, richTextBox9.Text);
            RefreshSpecificationJson();
        }

        /// <summary>
        /// Handler for edits to the specification's NAME text box.
        /// </summary>
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            model.SetSpecificationText(EntityEnum.Name, textBox6.Text);
            RefreshSpecificationJson();
        }

        /// <summary>
        /// Handler for edits to the specification's DESCRIPTION text box.
        /// </summary>
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            model.SetSpecificationText(EntityEnum.Description, textBox5.Text);
            RefreshSpecificationJson();
        }

        private void richTextBox8_TextChanged(object sender, EventArgs e)
        {
            string expectedResultName = listBox2.GetItemText(listBox2.SelectedItem);
            model.SetExpectedResultText(EntityEnum.Given, expectedResultName, richTextBox8.Text);
            RefreshSpecificationJson();
        }

        /// <summary>
        /// Handler for edits to the parameter's GIVEN text box.
        /// </summary>
        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {
            string inputParameterName = listBox1.GetItemText(listBox1.SelectedItem);
            model.SetInputParameterText(EntityEnum.Given, inputParameterName, richTextBox7.Text);
            RefreshSpecificationJson();
        }

        /// <summary>
        /// Handler for edits to the parameter's TEXT text box.
        /// </summary>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string inputParameterName = listBox1.GetItemText(listBox1.SelectedItem);
            model.SetInputParameterText(EntityEnum.Value, inputParameterName, textBox2.Text);
            RefreshSpecificationJson();
        }

        /// <summary>
        /// Handler for edits to the parameter's CONSTRAINT text box.
        /// </summary>
        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {
            string inputParameterName = listBox1.GetItemText(listBox1.SelectedItem);
            model.SetInputParameterText(EntityEnum.Condition, inputParameterName, richTextBox4.Text);
            RefreshSpecificationJson();
        }

        /// <summary>
        /// Handler for edits to the equivalence class's GIVEN text box.
        /// </summary>

        private void richTextBox10_TextChanged(object sender, EventArgs e)
        {
            string inputParameterName = listBox1.GetItemText(listBox1.SelectedItem);
            string equivalenceClassName = listBox8.GetItemText(listBox8.SelectedItem);
            model.SetEquivalenceClassText(EntityEnum.Given, inputParameterName, equivalenceClassName, richTextBox10.Text);
        }

        /// <summary>
        /// Handler for edits to the equivalence class's VALUE text box.
        /// </summary>
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string inputParameterName = listBox1.GetItemText(listBox1.SelectedItem);
            string equivalenceClassName = listBox8.GetItemText(listBox8.SelectedItem);
            model.SetEquivalenceClassText(EntityEnum.Value, inputParameterName, equivalenceClassName, textBox7.Text);
        }

        /// <summary>
        /// Handler for edits to the equivalence class's CONSTRAINT text box.
        /// </summary>
        private void richTextBox11_TextChanged(object sender, EventArgs e)
        {
            string inputParameterName = listBox1.GetItemText(listBox1.SelectedItem);
            string equivalenceClassName = listBox8.GetItemText(listBox8.SelectedItem);
            model.SetEquivalenceClassText(EntityEnum.Condition, inputParameterName, equivalenceClassName, richTextBox11.Text);
            RefreshSpecificationJson();
        }

        /// <summary>
        /// Handler for edits to the expected result's VALUE text box.
        /// </summary>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string expectedResultName = listBox2.GetItemText(listBox2.SelectedItem);
            model.SetExpectedResultText(EntityEnum.Value, expectedResultName, textBox3.Text);
            RefreshSpecificationJson();
        }

        /// <summary>
        /// Handler for edits to the expected result's CONSTRAINT text box.
        /// </summary>
        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {
            string expectedResultName = listBox2.GetItemText(listBox2.SelectedItem);
            model.SetExpectedResultText(EntityEnum.Condition, expectedResultName, richTextBox5.Text);
            RefreshSpecificationJson();
        }

        /// <summary>
        /// Handler for the specification's REFRESH button.
        /// </summary>
        private void button11_Click(object sender, EventArgs e)
        {
            RefreshSpecificationJson();
        }

        /// <summary>
        /// Handler for deleting an input parameter.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            string inputParameterName = listBox1.GetItemText(listBox1.SelectedItem);
            if (!YesOnConfirm(
                $"Are you sure you want to delete input parameter {inputParameterName}",
                $"Delete input parameter"))
            {
                return;
            }

            string consumers;
            bool deletedSingleton = false;
            bool isConsumed = model.InputParameterIsConsumed(inputParameterName, out consumers);
            if (isConsumed)
            {
                if (consumers != $"Input parameter {inputParameterName} is used by coverage groups = Singleton-{inputParameterName}")
                {
                    MessageBox.Show($"CANNOT DELETE: {consumers}");
                    return;
                }

                deletedSingleton = model.DeleteCoverageGroup($"Singleton-{inputParameterName}");
            }

            bool deleted = model.DeleteInputParameter(inputParameterName);
            MessageBox.Show(deleted
                ? $"Deleted input parameter {inputParameterName} from the specification"
                : $"Failed to delete input parameter {inputParameterName} from the specification");

            if (deleted)
            {
                RefreshParameterListBoxes();
                if (deletedSingleton)
                {
                    RefreshCoverageGroupListBoxes();
                }
            }
        }

        /// <summary>
        /// Handler for deleting a parameter's equivalence class.
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            string inputParameterName = listBox1.GetItemText(listBox1.SelectedItem);
            string equivalenceClassName = listBox8.GetItemText(listBox8.SelectedItem);
            string qualifiedEquivalenceClassName = $"{inputParameterName}.{equivalenceClassName}";
            if (!YesOnConfirm(
                $"Are you sure you want to delete equivalence class {qualifiedEquivalenceClassName}",
                $"Delete equivalence class"))
            {
                return;
            }

            string consumers;
            bool isConsumed = model.EquivalenceClassIsConsumed(inputParameterName, equivalenceClassName, out consumers);
            if (isConsumed)
            {
                MessageBox.Show($"CANNOT DELETE: {consumers}");
                return;
            }

            bool deleted = model.DeleteEquivalenceClass(inputParameterName, equivalenceClassName);
            MessageBox.Show(deleted
                ? $"Deleted equivalence class {qualifiedEquivalenceClassName} from the specification"
                : $"Failed to delete equivalence class {qualifiedEquivalenceClassName} from the specification");

            if (deleted)
            {
                RefreshEquivalenceClassListBoxes();
            }
        }

        /// <summary>
        /// Handler for deleting a coverage group.
        /// </summary>
        private void button7_Click(object sender, EventArgs e)
        {
            string coverageGroupName = listBox4.GetItemText(listBox4.SelectedItem);
            if (!YesOnConfirm(
                $"Are you sure you want to delete coverage group {coverageGroupName}",
                $"Delete coverage group"))
            {
                return;
            }

            bool deleted = model.DeleteCoverageGroup(coverageGroupName);
            MessageBox.Show(deleted
                ? $"Deleted coverage group {coverageGroupName} from the specification"
                : $"Failed to delete coverage group {coverageGroupName} from the specification");

            if (deleted)
            {
                RefreshCoverageGroupListBoxes();
            }
        }

        /// <summary>
        /// Handler for deleting an input parameter in a coverage group.
        /// </summary>
        private void button10_Click(object sender, EventArgs e)
        {
            string coverageGroupName = listBox4.GetItemText(listBox4.SelectedItem);
            string inputParameterName = listBox11.GetItemText(listBox11.SelectedItem);
            if (!YesOnConfirm(
                $"Are you sure you want to delete input parameter {inputParameterName} in coverage group {coverageGroupName}",
                $"Delete coverage group input parameter"))
            {
                return;
            }

            bool deleted = model.DeleteCoverageGroupInputParameter(coverageGroupName, inputParameterName);
            MessageBox.Show(deleted
                ? $"Deleted input parameter {inputParameterName} in coverage group {coverageGroupName} from the specification"
                : $"Failed to delete input parameter {inputParameterName} in coverage group {coverageGroupName} from the specification");

            if (deleted)
            {
                RefreshCoverageGroupListBoxes();
            }
        }

        /// <summary>
        /// Handler for deleting an expected result.
        /// </summary>
        private void button6_Click(object sender, EventArgs e)
        {
            string expectedResultName = listBox2.GetItemText(listBox2.SelectedItem);
            if (!YesOnConfirm(
                $"Are you sure you want to delete expected result {expectedResultName}",
                $"Delete expected result"))
            {
                return;
            }

            bool deleted = model.DeleteExpectedResult(expectedResultName);
            MessageBox.Show(deleted
                ? $"Deleted expected result {expectedResultName} from the specification"
                : $"Failed to delete expected result {expectedResultName} from the specification");

            if (deleted)
            {
                RefreshExpectedResultListBoxes();
            }
        }

        /// <summary>
        /// Handler for the button that creates a new input parameter.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            string newInputParameterName = OpenDialogForText(
                "Parameter name", "Please provide a name for the new input parameter");

            model.NewInputParameter(newInputParameterName);
            RefreshParameterListBoxes();
            RefreshParameterData(newInputParameterName);
            RefreshSpecificationJson();
        }

        /// <summary>
        /// Handler for the button that adds a new equivalence class to an existing input parameter.
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            string inputParameterName = listBox1.GetItemText(listBox1.SelectedItem);
            string newEquivalenceClassName = OpenDialogForText(
                "Class name", "Please provide a name for the new equivalence class");

            model.NewEquivalenceClass(inputParameterName, newEquivalenceClassName);
            RefreshEquivalenceClassListBoxes();
            RefreshEquivalenceClassData(inputParameterName, newEquivalenceClassName);
            RefreshSpecificationJson();
        }

        /// <summary>
        /// Handler for the button that creates a new expected result.
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            string newExpectedResultName = OpenDialogForText(
                "Result name", "Please provide a name for the new expected result");

            model.NewExpectedResult(newExpectedResultName);
            RefreshExpectedResultListBoxes();
            RefreshExpectedResultData(newExpectedResultName);
            RefreshSpecificationJson();
        }

        /// <summary>
        /// Handler for the button that creates a new coverage group.
        /// </summary>
        private void button8_Click(object sender, EventArgs e)
        {
            string newCoverageGroupName = OpenDialogForText(
                "Group name", "Please provide a name for the new coverage group");

            model.NewCoverageGroup(newCoverageGroupName);
            RefreshCoverageGroupListBoxes();
            RefreshSpecificationJson();
        }

        /// <summary>
        /// Handler for the button that adds a new parameter to an existing coverage group.
        /// </summary>
        private void button9_Click(object sender, EventArgs e)
        {
            string coverageGroupName = listBox4.GetItemText(listBox4.SelectedItem);
            string newInputParameterName = listBox12.GetItemText(listBox12.SelectedItem);

            model.NewCoverageGroupInputParameter(coverageGroupName, newInputParameterName);
            RefreshCoverageGroupInputParameterListBoxes(coverageGroupName);
            RefreshSpecificationJson();
        }

        /// <summary>
        /// Handler for the button that refreshes the "cheat sheet" on the COVERAGE page.
        /// </summary>
        private void button13_Click(object sender, EventArgs e)
        {
            string[] parameterNames = model.InputParameterNames();
            if (parameterNames.Length == 0)
            {
                listBox12.Items.Clear();
                return;
            }

            listBox12.DataSource = parameterNames;
        }

        /// <summary>
        /// Handler for the button that refreshes the "cheat sheet" on the EXPECTED RESULTS page.
        /// </summary>
        private void button12_Click(object sender, EventArgs e)
        {
            string[] parameterNames = model.InputParameterNames();
            if (parameterNames.Length == 0)
            {
                listBox10.Items.Clear();
                listBox9.Items.Clear();
                return;
            }

            listBox10.DataSource = parameterNames;
            listBox10.SetSelected(0, true);

            string parameterName = listBox1.GetItemText(listBox1.SelectedItem);
            string[] equivalenceClassNames = model.EquivalenceClassNames(parameterName);
            if (equivalenceClassNames.Length == 0)
            {
                listBox9.Items.Clear();
                return;
            }

            listBox9.DataSource = equivalenceClassNames;
        }

        /// <summary>
        /// Handler for the parameters page's PARAMETER list box.
        /// </summary>
        private void listBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            string parameterName = listBox1.GetItemText(listBox1.SelectedItem);
            RefreshParameterData(parameterName);

            string[] equivalenceClassNames = model.EquivalenceClassNames(parameterName);
            listBox8.DataSource = equivalenceClassNames;

            string equivalenceClassName = listBox8.GetItemText(listBox8.SelectedItem);
            RefreshEquivalenceClassData(parameterName, equivalenceClassName);
        }

        /// <summary>
        /// Handler for the expected results page's PARAMETER list box.
        /// </summary>
        private void listBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            string parameterName = listBox10.GetItemText(listBox10.SelectedItem);
            string[] equivalenceClassNames = model.EquivalenceClassNames(parameterName);
            if (equivalenceClassNames.Length == 0)
            {
                listBox9.Items.Clear();
                return;
            }

            listBox9.DataSource = equivalenceClassNames;
        }

        /// <summary>
        /// Handler for the coverage groups page's PARAMETER list box.
        /// </summary>
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string coverageGroupName = listBox4.GetItemText(listBox4.SelectedItem);
            string[] parameterNames = model.CoverageGroupParameterNames(coverageGroupName);
            listBox11.DataSource = parameterNames;
        }

        private void listBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            string testCaseName = listBox13.GetItemText(listBox13.SelectedItem);
            richTextBox6.Text = model.GetTestCaseAsString(testCaseName);
        }

        /// <summary>
        /// Handler for the parameters page's EQUIVALENCE CLASS list box.
        /// </summary>
        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string parameterName = listBox1.GetItemText(listBox1.SelectedItem);
            string equivalenceClassName = listBox8.GetItemText(listBox8.SelectedItem);
            RefreshEquivalenceClassData(parameterName, equivalenceClassName);
        }

        /// <summary>
        /// Handler for the expected result page's data attributes.
        /// </summary>
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string expectedResultName = listBox2.GetItemText(listBox2.SelectedItem);
            RefreshExpectedResultData(expectedResultName);
        }

        #endregion // EVENT HANDLERS
        #region ENABLE, DISABLE COMMANDS, BUTTONS

        /// <summary>
        /// Enables commands and buttons when a new specification is created
        /// or opened from a file.
        /// </summary>
        private void EnableSpecificationCommandsAndButtons()
        {
            this.saveEditsToolStripMenuItem.Enabled = true;
            this.discardEditsToolStripMenuItem.Enabled = true;
            this.generateScriptToolStripMenuItem.Enabled = true;
            this.writeSpecificationToolStripMenuItem.Enabled = true;
            this.closeSpecificationToolStripMenuItem1.Enabled = true;
            this.button11.Enabled = true;
        }

        /// <summary>
        /// Disables commands and buttons when the working specification is closed.
        /// </summary>
        private void DisableSpecificationCommandsAndButtons()
        {
            this.saveEditsToolStripMenuItem.Enabled = false;
            this.discardEditsToolStripMenuItem.Enabled = false;
            this.generateScriptToolStripMenuItem.Enabled = false;
            this.writeSpecificationToolStripMenuItem.Enabled = false;
            this.closeSpecificationToolStripMenuItem1.Enabled = false;
            this.button11.Enabled = false;
        }

        /// <summary>
        /// Enables commands and buttons when a test script is generated.
        /// </summary>
        private void EnableScriptCommandsAndButtons()
        {
            this.writeScriptToolStripMenuItem.Enabled = true;
            this.writeStatisticsToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Disables commands and buttons when the test script is discarded, i.e. when
        /// the working specification is closed.
        /// </summary>
        private void DisableScriptCommandsAndButtons()
        {
            this.writeScriptToolStripMenuItem.Enabled = false;
            this.writeStatisticsToolStripMenuItem.Enabled = false;
        }

        #endregion // ENABLE, DISABLE COMMANDS, BUTTONS
        #region REFRESH HELPERS

        /// <summary>
        /// Refreshes the pages for the entire specification.
        /// </summary>
        private void RefreshEntireSpecification(TestSpecification specification)
        {
            RefreshSpecificationData(specification);
            RefreshSpecificationJson(clear: specification == null);

            bool clearListBoxes = specification == null;
            RefreshParameterListBoxes(clearListBoxes);
            RefreshExpectedResultListBoxes(clearListBoxes);
            RefreshCoverageGroupListBoxes(clearListBoxes);
        }

        /// <summary>
        /// Refreshes the data fields for the specification.
        /// </summary>
        /// <param name="specification"></param>
        private void RefreshSpecificationData(TestSpecification specification)
        {
            richTextBox9.Text = model.GetSpecificationText(EntityEnum.Given, specification);
            textBox6.Text = model.GetSpecificationText(EntityEnum.Name, specification);
            textBox5.Text = model.GetSpecificationText(EntityEnum.Description, specification);
        }

        /// <summary>
        /// Refreshes the data fields for the specific input parameter.
        /// </summary>
        private void RefreshParameterData(string parameterName)
        {
            InputParameter inputParameter = model.GetInputParameter(parameterName);
            richTextBox7.Text = model.GetInputParameterText(EntityEnum.Given, inputParameter);
            textBox1.Text = model.GetInputParameterText(EntityEnum.Name, inputParameter);
            textBox2.Text = model.GetInputParameterText(EntityEnum.Value, inputParameter);
            richTextBox4.Text = model.GetInputParameterText(EntityEnum.Condition, inputParameter);
        }

        /// <summary>
        /// Refreshes the data fields for the parameter's specific equivalence class.
        /// </summary>
        private void RefreshEquivalenceClassData(string parameterName, string equivalenceClassName)
        {
            EquivalenceClass equivalenceClass = model.GetEquivalenceClass(parameterName, equivalenceClassName);
            richTextBox10.Text = model.GetEquivalenceClassText(EntityEnum.Given, equivalenceClass);
            textBox8.Text = model.GetEquivalenceClassText(EntityEnum.Name, equivalenceClass);
            textBox7.Text = model.GetEquivalenceClassText(EntityEnum.Value, equivalenceClass);
            richTextBox11.Text = model.GetEquivalenceClassText(EntityEnum.Condition, equivalenceClass);
        }

        /// <summary>
        /// Refreshes the data fields for the specific expected result.
        /// </summary>
        private void RefreshExpectedResultData(string expectedResultName)
        {
            ExpectedResult expectedResult = model.GetExpectedResult(expectedResultName);
            richTextBox8.Text = model.GetExpectedResultText(EntityEnum.Given, expectedResult);
            textBox4.Text = model.GetExpectedResultText(EntityEnum.Name, expectedResult);
            textBox3.Text = model.GetExpectedResultText(EntityEnum.Value, expectedResult);
            richTextBox5.Text = model.GetExpectedResultText(EntityEnum.Condition, expectedResult);
        }

        /// <summary>
        /// Refreshes the text box containing the working specification's JSON.
        /// </summary>
        private void RefreshSpecificationJson(bool clear = false)
        {
            richTextBox2.Text = clear ? string.Empty : model.GetWorkingSpecificationAsJson();
        }

        /// <summary>
        /// Refreshes all of the list boxes containing input parameter names.
        /// </summary>
        private void RefreshParameterListBoxes(bool clear = false)
        {
            string[] parameterNames = clear ? null : model.InputParameterNames();

            listBox1.DataSource = parameterNames;
            listBox5.DataSource = parameterNames;
        }

        /// <summary>
        /// Refreshes all of the list boxes containing equivalence class names.
        /// </summary>
        private void RefreshEquivalenceClassListBoxes(bool clear = false)
        {
            string inputParameterName = listBox1.GetItemText(listBox1.SelectedItem);
            string[] equivalenceClassNames = clear ? null : model.EquivalenceClassNames(inputParameterName);
            listBox8.DataSource = equivalenceClassNames;
        }

        /// <summary>
        /// Refreshes all of the list boxes containing expected result names.
        /// </summary>
        private void RefreshExpectedResultListBoxes(bool clear = false)
        {
            string[] expectedResultNames = clear ? null : model.ExpectedResultNames();

            listBox2.DataSource = expectedResultNames;
            listBox6.DataSource = expectedResultNames;
        }

        /// <summary>
        /// Refreshes all of the list boxes containing coverage group names.
        /// </summary>
        private void RefreshCoverageGroupListBoxes(bool clear = false)
        {
            string[] coverageGroupNames = clear ? null : model.CoverageGroupNames();

            listBox4.DataSource = coverageGroupNames;
            listBox7.DataSource = coverageGroupNames;
        }

        /// <summary>
        /// Refreshes all of the list boxes containing the parameters of a coverage group.
        /// </summary>
        private void RefreshCoverageGroupInputParameterListBoxes(string coverageGroupName)
        {
            listBox11.DataSource = model.CoverageGroupParameterNames(coverageGroupName);
        }
        
        // <summary>
        /// Refreshes the page of generated test cases.
        /// </summary>
        private void RefreshTestCases(bool populatedAndWritten)
        {
            if (!populatedAndWritten)
            {
                richTextBox6.Text = string.Empty;
                listBox13.DataSource = null;
                return;
            }

            string[] testCaseNames = model.GeneratedTestCaseNames(true);
            listBox13.DataSource = testCaseNames;
        }

        // <summary>
        /// Refreshes the page containing the generated test script.
        /// </summary>
        private void RefreshTestScript(bool populatedAndWritten)
        {
            richTextBox1.Text = model.GetTestScriptAsString(populatedAndWritten);
        }

        // <summary>
        /// Refreshes the page containing the generated test statistics.
        /// </summary>
        private void RefreshTestStatistics(bool populatedAndWritten)
        {
            richTextBox3.Text = model.GetTestStatisticstAsString(populatedAndWritten);
        }

        #endregion // REFRESH HELPERS
        #region HELPER UTILITIES

        /// <summary>
        /// Returns true if the user responds YES from a confirmation message box.
        /// </summary>
        private bool YesOnConfirm(string message, string caption)
        {
            var result = MessageBox.Show(message, caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        /// <summary>
        /// Returns the fully-qualified file name from a file dialog (open or save).
        /// </summary>
        private string FilenameFromDialog(FileDialog dialog)
        {
            return (dialog.ShowDialog() == DialogResult.OK)
                ? dialog.FileName
                : null;
        }

        /// <summary>
        /// Opens a confirmation dialog and, if the user responds YES, exits the application;
        /// otherwise does not exit the application. Sets CANCEL to true if the user responds,
        /// NO, otherwise false.
        /// </summary>
        private void ExitOnConfirm(out bool cancel)
        {
            cancel = false;
            bool specificationExists = model.WorkingSpecificationExists();
            string message = specificationExists
                ? "Are you sure that you would like to discard the current specification and close TCG?"
                : "Are you sure that you would like to close TCG?";
            string caption = specificationExists
                ? "Confirm DISCARD and EXIT"
                : "Confirm EXIT";

            if (!YesOnConfirm(message, caption))
            {
                cancel = true;
                return;
            }

            Environment.Exit(0);
        }

        /// <summary>
        /// Opens a dialog, prompts for a value in the text box, and returns that value.
        /// </summary>
        private string OpenDialogForText(string dialogText, string dialogCaption)
        {
            Form prompt = new Form
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = dialogCaption,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { Left = 50, Top = 20, Text = dialogText };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : string.Empty;
        }

        #endregion // HELPER UTILITIES
    }
}
