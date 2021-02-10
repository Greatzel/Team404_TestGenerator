using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TestCaseGeneratorViewer
{
    partial class ViewManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewManager));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveEditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discardEditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeSpecificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeSpecificationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabSummary = new System.Windows.Forms.TabPage();
            this.button11 = new System.Windows.Forms.Button();
            this.richTextBox9 = new System.Windows.Forms.RichTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.listBox7 = new System.Windows.Forms.ListBox();
            this.listBox6 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabParameters = new System.Windows.Forms.TabPage();
            this.richTextBox10 = new System.Windows.Forms.RichTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.richTextBox11 = new System.Windows.Forms.RichTextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.richTextBox7 = new System.Windows.Forms.RichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox8 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabExpectedResults = new System.Windows.Forms.TabPage();
            this.button12 = new System.Windows.Forms.Button();
            this.richTextBox8 = new System.Windows.Forms.RichTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.listBox9 = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.listBox10 = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.tabCoverageGroups = new System.Windows.Forms.TabPage();
            this.button13 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.listBox11 = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.listBox12 = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.tabTestCases = new System.Windows.Forms.TabPage();
            this.richTextBox6 = new System.Windows.Forms.RichTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.listBox13 = new System.Windows.Forms.ListBox();
            this.tabTestScript = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabTestStatistics = new System.Windows.Forms.TabPage();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabParameters.SuspendLayout();
            this.tabExpectedResults.SuspendLayout();
            this.tabCoverageGroups.SuspendLayout();
            this.tabTestCases.SuspendLayout();
            this.tabTestScript.SuspendLayout();
            this.tabTestStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AccessibleDescription = "Parameters";
            this.tableLayoutPanel1.AccessibleName = "Parameters";
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1191F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1191F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1191F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1191F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1191F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1191F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1836, 1191);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 521);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(8, 8);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // listBox3
            // 
            this.listBox3.AccessibleDescription = "Parameters";
            this.listBox3.AccessibleName = "Parameters";
            this.listBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 16;
            this.listBox3.Location = new System.Drawing.Point(3, 521);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(275, 84);
            this.listBox3.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1836, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AccessibleDescription = "File";
            this.toolStripMenuItem1.AccessibleName = "File";
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveEditsToolStripMenuItem,
            this.discardEditsToolStripMenuItem,
            this.generateScriptToolStripMenuItem,
            this.writeSpecificationToolStripMenuItem,
            this.writeScriptToolStripMenuItem,
            this.writeStatisticsToolStripMenuItem,
            this.closeSpecificationToolStripMenuItem1,
            this.exitToolStripMenuItem2});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(52, 26);
            this.toolStripMenuItem1.Tag = "File";
            this.toolStripMenuItem1.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.newToolStripMenuItem.Tag = "New specification";
            this.newToolStripMenuItem.Text = "New specification";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.openToolStripMenuItem.Tag = "Open specification";
            this.openToolStripMenuItem.Text = "Open specification";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveEditsToolStripMenuItem
            // 
            this.saveEditsToolStripMenuItem.Enabled = false;
            this.saveEditsToolStripMenuItem.Name = "saveEditsToolStripMenuItem";
            this.saveEditsToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.saveEditsToolStripMenuItem.Text = "Cache edits";
            this.saveEditsToolStripMenuItem.Click += new System.EventHandler(this.saveEditsToolStripMenuItem_Click);
            // 
            // discardEditsToolStripMenuItem
            // 
            this.discardEditsToolStripMenuItem.Enabled = false;
            this.discardEditsToolStripMenuItem.Name = "discardEditsToolStripMenuItem";
            this.discardEditsToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.discardEditsToolStripMenuItem.Tag = "Discard edits";
            this.discardEditsToolStripMenuItem.Text = "Revert edits";
            this.discardEditsToolStripMenuItem.Click += new System.EventHandler(this.discardEditsToolStripMenuItem_Click);
            // 
            // generateScriptToolStripMenuItem
            // 
            this.generateScriptToolStripMenuItem.Enabled = false;
            this.generateScriptToolStripMenuItem.Name = "generateScriptToolStripMenuItem";
            this.generateScriptToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.generateScriptToolStripMenuItem.Tag = "Generate test script";
            this.generateScriptToolStripMenuItem.Text = "Generate test script";
            this.generateScriptToolStripMenuItem.Click += new System.EventHandler(this.generateScriptToolStripMenuItem_Click);
            // 
            // writeSpecificationToolStripMenuItem
            // 
            this.writeSpecificationToolStripMenuItem.Enabled = false;
            this.writeSpecificationToolStripMenuItem.Name = "writeSpecificationToolStripMenuItem";
            this.writeSpecificationToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.writeSpecificationToolStripMenuItem.Text = "Write specification";
            this.writeSpecificationToolStripMenuItem.Click += new System.EventHandler(this.writeSpecificationToolStripMenuItem_Click);
            // 
            // writeScriptToolStripMenuItem
            // 
            this.writeScriptToolStripMenuItem.Enabled = false;
            this.writeScriptToolStripMenuItem.Name = "writeScriptToolStripMenuItem";
            this.writeScriptToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.writeScriptToolStripMenuItem.Text = "Write script";
            this.writeScriptToolStripMenuItem.Click += new System.EventHandler(this.writeScriptToolStripMenuItem_Click);
            // 
            // writeStatisticsToolStripMenuItem
            // 
            this.writeStatisticsToolStripMenuItem.Enabled = false;
            this.writeStatisticsToolStripMenuItem.Name = "writeStatisticsToolStripMenuItem";
            this.writeStatisticsToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.writeStatisticsToolStripMenuItem.Text = "Write statistics";
            this.writeStatisticsToolStripMenuItem.Click += new System.EventHandler(this.writeStatisticsToolStripMenuItem_Click);
            // 
            // closeSpecificationToolStripMenuItem1
            // 
            this.closeSpecificationToolStripMenuItem1.Enabled = false;
            this.closeSpecificationToolStripMenuItem1.Name = "closeSpecificationToolStripMenuItem1";
            this.closeSpecificationToolStripMenuItem1.Size = new System.Drawing.Size(257, 26);
            this.closeSpecificationToolStripMenuItem1.Text = "Close specification";
            this.closeSpecificationToolStripMenuItem1.Click += new System.EventHandler(this.closeSpecificationToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem2
            // 
            this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(257, 26);
            this.exitToolStripMenuItem2.Text = "Exit";
            this.exitToolStripMenuItem2.Click += new System.EventHandler(this.exitToolStripMenuItem2_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabSummary);
            this.tabMain.Controls.Add(this.tabParameters);
            this.tabMain.Controls.Add(this.tabExpectedResults);
            this.tabMain.Controls.Add(this.tabCoverageGroups);
            this.tabMain.Controls.Add(this.tabTestCases);
            this.tabMain.Controls.Add(this.tabTestScript);
            this.tabMain.Controls.Add(this.tabTestStatistics);
            this.tabMain.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(0, 30);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1836, 1140);
            this.tabMain.TabIndex = 0;
            // 
            // tabSummary
            // 
            this.tabSummary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabSummary.Controls.Add(this.button11);
            this.tabSummary.Controls.Add(this.richTextBox9);
            this.tabSummary.Controls.Add(this.label21);
            this.tabSummary.Controls.Add(this.textBox5);
            this.tabSummary.Controls.Add(this.textBox6);
            this.tabSummary.Controls.Add(this.label22);
            this.tabSummary.Controls.Add(this.label23);
            this.tabSummary.Controls.Add(this.richTextBox2);
            this.tabSummary.Controls.Add(this.listBox7);
            this.tabSummary.Controls.Add(this.listBox6);
            this.tabSummary.Controls.Add(this.label6);
            this.tabSummary.Controls.Add(this.label5);
            this.tabSummary.Controls.Add(this.label4);
            this.tabSummary.Controls.Add(this.listBox5);
            this.tabSummary.Controls.Add(this.pictureBox2);
            this.tabSummary.Location = new System.Drawing.Point(4, 31);
            this.tabSummary.Name = "tabSummary";
            this.tabSummary.Size = new System.Drawing.Size(1828, 1105);
            this.tabSummary.TabIndex = 0;
            this.tabSummary.Text = "Summary";
            // 
            // button11
            // 
            this.button11.Enabled = false;
            this.button11.Location = new System.Drawing.Point(355, 1016);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(143, 40);
            this.button11.TabIndex = 25;
            this.button11.Text = "Refresh";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // richTextBox9
            // 
            this.richTextBox9.Location = new System.Drawing.Point(600, 152);
            this.richTextBox9.Name = "richTextBox9";
            this.richTextBox9.Size = new System.Drawing.Size(377, 114);
            this.richTextBox9.TabIndex = 24;
            this.richTextBox9.Text = "";
            this.richTextBox9.TextChanged += new System.EventHandler(this.richTextBox9_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(509, 152);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 26);
            this.label21.TabIndex = 23;
            this.label21.Text = "Given";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(600, 100);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(377, 28);
            this.textBox5.TabIndex = 22;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(600, 32);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(377, 28);
            this.textBox6.TabIndex = 21;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(449, 100);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(136, 26);
            this.label22.TabIndex = 20;
            this.label22.Text = "Description";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(364, 32);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(221, 26);
            this.label23.TabIndex = 19;
            this.label23.Text = "Specification name";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(355, 317);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(1381, 678);
            this.richTextBox2.TabIndex = 9;
            this.richTextBox2.Text = "";
            // 
            // listBox7
            // 
            this.listBox7.FormattingEnabled = true;
            this.listBox7.ItemHeight = 22;
            this.listBox7.Location = new System.Drawing.Point(37, 815);
            this.listBox7.Name = "listBox7";
            this.listBox7.Size = new System.Drawing.Size(231, 180);
            this.listBox7.TabIndex = 8;
            // 
            // listBox6
            // 
            this.listBox6.FormattingEnabled = true;
            this.listBox6.ItemHeight = 22;
            this.listBox6.Location = new System.Drawing.Point(37, 566);
            this.listBox6.Name = "listBox6";
            this.listBox6.Size = new System.Drawing.Size(231, 180);
            this.listBox6.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 768);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 26);
            this.label6.TabIndex = 6;
            this.label6.Text = "Coverage groups";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 519);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "Expected results";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "Parameters";
            // 
            // listBox5
            // 
            this.listBox5.FormattingEnabled = true;
            this.listBox5.ItemHeight = 22;
            this.listBox5.Location = new System.Drawing.Point(37, 317);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(231, 180);
            this.listBox5.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(37, 32);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(231, 221);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tabParameters
            // 
            this.tabParameters.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabParameters.Controls.Add(this.richTextBox10);
            this.tabParameters.Controls.Add(this.label24);
            this.tabParameters.Controls.Add(this.richTextBox11);
            this.tabParameters.Controls.Add(this.textBox7);
            this.tabParameters.Controls.Add(this.textBox8);
            this.tabParameters.Controls.Add(this.label25);
            this.tabParameters.Controls.Add(this.label26);
            this.tabParameters.Controls.Add(this.label27);
            this.tabParameters.Controls.Add(this.richTextBox7);
            this.tabParameters.Controls.Add(this.label19);
            this.tabParameters.Controls.Add(this.button4);
            this.tabParameters.Controls.Add(this.button2);
            this.tabParameters.Controls.Add(this.richTextBox4);
            this.tabParameters.Controls.Add(this.textBox2);
            this.tabParameters.Controls.Add(this.textBox1);
            this.tabParameters.Controls.Add(this.label8);
            this.tabParameters.Controls.Add(this.label7);
            this.tabParameters.Controls.Add(this.label3);
            this.tabParameters.Controls.Add(this.label2);
            this.tabParameters.Controls.Add(this.label1);
            this.tabParameters.Controls.Add(this.listBox8);
            this.tabParameters.Controls.Add(this.button3);
            this.tabParameters.Controls.Add(this.button1);
            this.tabParameters.Controls.Add(this.listBox1);
            this.tabParameters.Location = new System.Drawing.Point(4, 31);
            this.tabParameters.Name = "tabParameters";
            this.tabParameters.Size = new System.Drawing.Size(1828, 1105);
            this.tabParameters.TabIndex = 1;
            this.tabParameters.Text = "Parameters";
            // 
            // richTextBox10
            // 
            this.richTextBox10.Location = new System.Drawing.Point(478, 631);
            this.richTextBox10.Name = "richTextBox10";
            this.richTextBox10.Size = new System.Drawing.Size(377, 114);
            this.richTextBox10.TabIndex = 26;
            this.richTextBox10.Text = "";
            this.richTextBox10.TextChanged += new System.EventHandler(this.richTextBox10_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(387, 631);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(76, 26);
            this.label24.TabIndex = 25;
            this.label24.Text = "Given";
            // 
            // richTextBox11
            // 
            this.richTextBox11.Location = new System.Drawing.Point(478, 819);
            this.richTextBox11.Name = "richTextBox11";
            this.richTextBox11.Size = new System.Drawing.Size(377, 162);
            this.richTextBox11.TabIndex = 24;
            this.richTextBox11.Text = "";
            this.richTextBox11.TextChanged += new System.EventHandler(this.richTextBox11_TextChanged);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(478, 785);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(377, 28);
            this.textBox7.TabIndex = 23;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(478, 751);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(377, 28);
            this.textBox8.TabIndex = 22;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(336, 819);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(127, 26);
            this.label25.TabIndex = 21;
            this.label25.Text = "Constraint";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(314, 785);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(149, 26);
            this.label26.TabIndex = 20;
            this.label26.Text = "Actual value";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(307, 751);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(156, 26);
            this.label27.TabIndex = 19;
            this.label27.Text = "Logical name";
            // 
            // richTextBox7
            // 
            this.richTextBox7.Location = new System.Drawing.Point(478, 156);
            this.richTextBox7.Name = "richTextBox7";
            this.richTextBox7.Size = new System.Drawing.Size(377, 114);
            this.richTextBox7.TabIndex = 18;
            this.richTextBox7.Text = "";
            this.richTextBox7.TextChanged += new System.EventHandler(this.richTextBox7_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(387, 156);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(76, 26);
            this.label19.TabIndex = 17;
            this.label19.Text = "Given";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(853, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(248, 40);
            this.button4.TabIndex = 16;
            this.button4.Text = "Delete equivalence class";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(578, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(248, 40);
            this.button2.TabIndex = 15;
            this.button2.Text = "Delete parameter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox4
            // 
            this.richTextBox4.Location = new System.Drawing.Point(478, 344);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(377, 162);
            this.richTextBox4.TabIndex = 14;
            this.richTextBox4.Text = "";
            this.richTextBox4.TextChanged += new System.EventHandler(this.richTextBox4_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(478, 310);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(377, 28);
            this.textBox2.TabIndex = 13;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(478, 276);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(377, 28);
            this.textBox1.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(336, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 26);
            this.label8.TabIndex = 11;
            this.label8.Text = "Constraint";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(314, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 26);
            this.label7.TabIndex = 10;
            this.label7.Text = "Actual value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(307, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Logical name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 584);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Equivalence classes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "Parameters";
            // 
            // listBox8
            // 
            this.listBox8.FormattingEnabled = true;
            this.listBox8.ItemHeight = 22;
            this.listBox8.Location = new System.Drawing.Point(36, 631);
            this.listBox8.Name = "listBox8";
            this.listBox8.Size = new System.Drawing.Size(231, 400);
            this.listBox8.TabIndex = 6;
            this.listBox8.SelectedIndexChanged += new System.EventHandler(this.listBox8_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(305, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(248, 40);
            this.button3.TabIndex = 5;
            this.button3.Text = "New equivalence class";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(248, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "New parameter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 22;
            this.listBox1.Location = new System.Drawing.Point(36, 156);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(231, 400);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_2);
            // 
            // tabExpectedResults
            // 
            this.tabExpectedResults.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabExpectedResults.Controls.Add(this.button12);
            this.tabExpectedResults.Controls.Add(this.richTextBox8);
            this.tabExpectedResults.Controls.Add(this.label20);
            this.tabExpectedResults.Controls.Add(this.listBox9);
            this.tabExpectedResults.Controls.Add(this.label16);
            this.tabExpectedResults.Controls.Add(this.label17);
            this.tabExpectedResults.Controls.Add(this.listBox10);
            this.tabExpectedResults.Controls.Add(this.label12);
            this.tabExpectedResults.Controls.Add(this.richTextBox5);
            this.tabExpectedResults.Controls.Add(this.textBox3);
            this.tabExpectedResults.Controls.Add(this.textBox4);
            this.tabExpectedResults.Controls.Add(this.label9);
            this.tabExpectedResults.Controls.Add(this.label10);
            this.tabExpectedResults.Controls.Add(this.label11);
            this.tabExpectedResults.Controls.Add(this.button6);
            this.tabExpectedResults.Controls.Add(this.button5);
            this.tabExpectedResults.Controls.Add(this.listBox2);
            this.tabExpectedResults.Location = new System.Drawing.Point(4, 31);
            this.tabExpectedResults.Name = "tabExpectedResults";
            this.tabExpectedResults.Size = new System.Drawing.Size(1828, 1105);
            this.tabExpectedResults.TabIndex = 2;
            this.tabExpectedResults.Text = "Expected results";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(999, 51);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(231, 40);
            this.button12.TabIndex = 31;
            this.button12.Text = "Refresh cheat sheet";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // richTextBox8
            // 
            this.richTextBox8.Location = new System.Drawing.Point(462, 170);
            this.richTextBox8.Name = "richTextBox8";
            this.richTextBox8.Size = new System.Drawing.Size(377, 114);
            this.richTextBox8.TabIndex = 30;
            this.richTextBox8.Text = "";
            this.richTextBox8.TextChanged += new System.EventHandler(this.richTextBox8_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(371, 170);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 26);
            this.label20.TabIndex = 29;
            this.label20.Text = "Given";
            // 
            // listBox9
            // 
            this.listBox9.FormattingEnabled = true;
            this.listBox9.ItemHeight = 22;
            this.listBox9.Location = new System.Drawing.Point(999, 468);
            this.listBox9.Name = "listBox9";
            this.listBox9.Size = new System.Drawing.Size(231, 224);
            this.listBox9.TabIndex = 28;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(994, 417);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(229, 26);
            this.label16.TabIndex = 27;
            this.label16.Text = "Equivalence classes";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(994, 112);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(137, 26);
            this.label17.TabIndex = 26;
            this.label17.Text = "Parameters";
            // 
            // listBox10
            // 
            this.listBox10.FormattingEnabled = true;
            this.listBox10.ItemHeight = 22;
            this.listBox10.Location = new System.Drawing.Point(999, 168);
            this.listBox10.Name = "listBox10";
            this.listBox10.Size = new System.Drawing.Size(231, 224);
            this.listBox10.TabIndex = 24;
            this.listBox10.SelectedIndexChanged += new System.EventHandler(this.listBox10_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(35, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(194, 26);
            this.label12.TabIndex = 23;
            this.label12.Text = "Expected results";
            // 
            // richTextBox5
            // 
            this.richTextBox5.Location = new System.Drawing.Point(462, 362);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.Size = new System.Drawing.Size(377, 313);
            this.richTextBox5.TabIndex = 22;
            this.richTextBox5.Text = "";
            this.richTextBox5.TextChanged += new System.EventHandler(this.richTextBox5_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(462, 328);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(377, 28);
            this.textBox3.TabIndex = 21;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(462, 294);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(377, 28);
            this.textBox4.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(330, 362);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 26);
            this.label9.TabIndex = 19;
            this.label9.Text = "Condition";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(314, 330);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 26);
            this.label10.TabIndex = 18;
            this.label10.Text = "Actual text";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(291, 294);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(156, 26);
            this.label11.TabIndex = 17;
            this.label11.Text = "Logical name";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(313, 51);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(248, 40);
            this.button6.TabIndex = 16;
            this.button6.Text = "Delete expected result";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(40, 51);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(248, 40);
            this.button5.TabIndex = 4;
            this.button5.Text = "New expected result";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 22;
            this.listBox2.Location = new System.Drawing.Point(40, 175);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(231, 466);
            this.listBox2.TabIndex = 3;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // tabCoverageGroups
            // 
            this.tabCoverageGroups.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabCoverageGroups.Controls.Add(this.button13);
            this.tabCoverageGroups.Controls.Add(this.button10);
            this.tabCoverageGroups.Controls.Add(this.button9);
            this.tabCoverageGroups.Controls.Add(this.label14);
            this.tabCoverageGroups.Controls.Add(this.listBox11);
            this.tabCoverageGroups.Controls.Add(this.label15);
            this.tabCoverageGroups.Controls.Add(this.listBox12);
            this.tabCoverageGroups.Controls.Add(this.label13);
            this.tabCoverageGroups.Controls.Add(this.button7);
            this.tabCoverageGroups.Controls.Add(this.button8);
            this.tabCoverageGroups.Controls.Add(this.listBox4);
            this.tabCoverageGroups.Location = new System.Drawing.Point(4, 31);
            this.tabCoverageGroups.Name = "tabCoverageGroups";
            this.tabCoverageGroups.Size = new System.Drawing.Size(1828, 1105);
            this.tabCoverageGroups.TabIndex = 3;
            this.tabCoverageGroups.Text = "Coverage groups";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(704, 96);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(231, 40);
            this.button13.TabIndex = 35;
            this.button13.Text = "Refresh cheat sheet";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(316, 100);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(286, 40);
            this.button10.TabIndex = 34;
            this.button10.Text = "Delete parameter from group";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(316, 54);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(286, 40);
            this.button9.TabIndex = 33;
            this.button9.Text = "New parameter in group";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(311, 168);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(237, 26);
            this.label14.TabIndex = 32;
            this.label14.Text = "Parameters in group";
            // 
            // listBox11
            // 
            this.listBox11.FormattingEnabled = true;
            this.listBox11.ItemHeight = 22;
            this.listBox11.Location = new System.Drawing.Point(316, 226);
            this.listBox11.Name = "listBox11";
            this.listBox11.Size = new System.Drawing.Size(231, 224);
            this.listBox11.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(699, 168);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(174, 26);
            this.label15.TabIndex = 30;
            this.label15.Text = "All parameters";
            // 
            // listBox12
            // 
            this.listBox12.FormattingEnabled = true;
            this.listBox12.ItemHeight = 22;
            this.listBox12.Location = new System.Drawing.Point(704, 226);
            this.listBox12.Name = "listBox12";
            this.listBox12.Size = new System.Drawing.Size(231, 400);
            this.listBox12.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(45, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(197, 26);
            this.label13.TabIndex = 19;
            this.label13.Text = "Coverage groups";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(50, 100);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(165, 40);
            this.button7.TabIndex = 18;
            this.button7.Text = "Delete group";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(50, 54);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(165, 40);
            this.button8.TabIndex = 17;
            this.button8.Text = "New group";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.ItemHeight = 22;
            this.listBox4.Location = new System.Drawing.Point(50, 226);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(231, 510);
            this.listBox4.TabIndex = 3;
            this.listBox4.SelectedIndexChanged += new System.EventHandler(this.listBox4_SelectedIndexChanged);
            // 
            // tabTestCases
            // 
            this.tabTestCases.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabTestCases.Controls.Add(this.richTextBox6);
            this.tabTestCases.Controls.Add(this.label18);
            this.tabTestCases.Controls.Add(this.listBox13);
            this.tabTestCases.Location = new System.Drawing.Point(4, 31);
            this.tabTestCases.Name = "tabTestCases";
            this.tabTestCases.Size = new System.Drawing.Size(1828, 1105);
            this.tabTestCases.TabIndex = 4;
            this.tabTestCases.Text = "Test cases";
            // 
            // richTextBox6
            // 
            this.richTextBox6.Location = new System.Drawing.Point(326, 98);
            this.richTextBox6.Name = "richTextBox6";
            this.richTextBox6.ReadOnly = true;
            this.richTextBox6.Size = new System.Drawing.Size(525, 510);
            this.richTextBox6.TabIndex = 22;
            this.richTextBox6.Text = "";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(48, 50);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(125, 26);
            this.label18.TabIndex = 21;
            this.label18.Text = "Test cases";
            // 
            // listBox13
            // 
            this.listBox13.FormattingEnabled = true;
            this.listBox13.ItemHeight = 22;
            this.listBox13.Location = new System.Drawing.Point(53, 98);
            this.listBox13.Name = "listBox13";
            this.listBox13.Size = new System.Drawing.Size(231, 510);
            this.listBox13.TabIndex = 20;
            this.listBox13.SelectedIndexChanged += new System.EventHandler(this.listBox13_SelectedIndexChanged);
            // 
            // tabTestScript
            // 
            this.tabTestScript.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabTestScript.Controls.Add(this.richTextBox1);
            this.tabTestScript.Location = new System.Drawing.Point(4, 31);
            this.tabTestScript.Name = "tabTestScript";
            this.tabTestScript.Size = new System.Drawing.Size(1828, 1105);
            this.tabTestScript.TabIndex = 4;
            this.tabTestScript.Text = "Test script";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(29, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1127, 997);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabTestStatistics
            // 
            this.tabTestStatistics.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabTestStatistics.Controls.Add(this.richTextBox3);
            this.tabTestStatistics.Location = new System.Drawing.Point(4, 31);
            this.tabTestStatistics.Name = "tabTestStatistics";
            this.tabTestStatistics.Size = new System.Drawing.Size(1828, 1105);
            this.tabTestStatistics.TabIndex = 5;
            this.tabTestStatistics.Text = "Test statistics";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(28, 32);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(1127, 997);
            this.richTextBox3.TabIndex = 1;
            this.richTextBox3.Text = "";
            // 
            // ViewManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1836, 1221);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ViewManager";
            this.Text = "TCG: Test Case Generator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabSummary.ResumeLayout(false);
            this.tabSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabParameters.ResumeLayout(false);
            this.tabParameters.PerformLayout();
            this.tabExpectedResults.ResumeLayout(false);
            this.tabExpectedResults.PerformLayout();
            this.tabCoverageGroups.ResumeLayout(false);
            this.tabCoverageGroups.PerformLayout();
            this.tabTestCases.ResumeLayout(false);
            this.tabTestCases.PerformLayout();
            this.tabTestScript.ResumeLayout(false);
            this.tabTestStatistics.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private ListBox listBox3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem generateScriptToolStripMenuItem;
        private ToolStripMenuItem discardEditsToolStripMenuItem;
        private ToolStripMenuItem saveEditsToolStripMenuItem;
        private ToolStripMenuItem writeSpecificationToolStripMenuItem;
        private ToolStripMenuItem closeSpecificationToolStripMenuItem1;

        private TabControl tabMain;
        private TabPage tabSummary;
        private TabPage tabParameters;
        private TabPage tabExpectedResults;
        private TabPage tabCoverageGroups;
        private TabPage tabTestCases;
        private TabPage tabTestScript;
        private TabPage tabTestStatistics;
        private PictureBox pictureBox2;
        private ListBox listBox7;
        private ListBox listBox6;
        private Label label6;
        private Label label5;
        private Label label4;
        private ListBox listBox5;
        private RichTextBox richTextBox2;
        private ListBox listBox1;
        private ListBox listBox2;
        private ListBox listBox4;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox3;
        private ToolStripMenuItem exitToolStripMenuItem2;
        private Button button3;
        private Button button1;
        private Label label2;
        private Label label1;
        private ListBox listBox8;
        private RichTextBox richTextBox4;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label8;
        private Label label7;
        private Label label3;
        private Button button4;
        private Button button2;
        private Label label16;
        private Label label17;
        private ListBox listBox10;
        private Label label12;
        private RichTextBox richTextBox5;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label9;
        private Label label10;
        private Label label11;
        private Button button6;
        private Button button5;
        private ListBox listBox9;
        private Button button10;
        private Button button9;
        private Label label14;
        private ListBox listBox11;
        private Label label15;
        private ListBox listBox12;
        private Label label13;
        private Button button7;
        private Button button8;
        private RichTextBox richTextBox6;
        private Label label18;
        private ListBox listBox13;
        private ToolStripMenuItem writeScriptToolStripMenuItem;
        private ToolStripMenuItem writeStatisticsToolStripMenuItem;
        private RichTextBox richTextBox7;
        private Label label19;
        private RichTextBox richTextBox9;
        private Label label21;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label22;
        private Label label23;
        private Button button11;
        private RichTextBox richTextBox10;
        private Label label24;
        private RichTextBox richTextBox11;
        private TextBox textBox7;
        private TextBox textBox8;
        private Label label25;
        private Label label26;
        private Label label27;
        private RichTextBox richTextBox8;
        private Label label20;
        private Button button12;
        private Button button13;
    }
}

