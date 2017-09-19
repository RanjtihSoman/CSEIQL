namespace IFC_LinQ
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.TreeviewHierarchy = new System.Windows.Forms.TreeView();
            this.ButtonFileOpen = new System.Windows.Forms.Button();
            this.label_openafile = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Query = new System.Windows.Forms.TextBox();
            this.Button_SubmitQuery = new System.Windows.Forms.Button();
            this.textBox_output = new System.Windows.Forms.TextBox();
            this.Label_Output = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeviewHierarchy
            // 
            this.TreeviewHierarchy.Dock = System.Windows.Forms.DockStyle.Left;
            this.TreeviewHierarchy.Location = new System.Drawing.Point(0, 0);
            this.TreeviewHierarchy.Name = "TreeviewHierarchy";
            this.TreeviewHierarchy.Size = new System.Drawing.Size(270, 686);
            this.TreeviewHierarchy.TabIndex = 0;
            // 
            // ButtonFileOpen
            // 
            this.ButtonFileOpen.Location = new System.Drawing.Point(16, 12);
            this.ButtonFileOpen.Name = "ButtonFileOpen";
            this.ButtonFileOpen.Size = new System.Drawing.Size(75, 32);
            this.ButtonFileOpen.TabIndex = 1;
            this.ButtonFileOpen.Text = "Open File";
            this.ButtonFileOpen.UseVisualStyleBackColor = true;
            this.ButtonFileOpen.Click += new System.EventHandler(this.ButtonFileOpen_Click);
            // 
            // label_openafile
            // 
            this.label_openafile.AutoSize = true;
            this.label_openafile.Location = new System.Drawing.Point(97, 22);
            this.label_openafile.Name = "label_openafile";
            this.label_openafile.Size = new System.Drawing.Size(114, 13);
            this.label_openafile.TabIndex = 2;
            this.label_openafile.Text = "Open a file to continue";
            this.label_openafile.Click += new System.EventHandler(this.label_openafile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Input Query";
            // 
            // textBox_Query
            // 
            this.textBox_Query.Location = new System.Drawing.Point(35, 65);
            this.textBox_Query.Multiline = true;
            this.textBox_Query.Name = "textBox_Query";
            this.textBox_Query.Size = new System.Drawing.Size(632, 117);
            this.textBox_Query.TabIndex = 4;
            this.textBox_Query.TextChanged += new System.EventHandler(this.textBox_Query_TextChanged);
            // 
            // Button_SubmitQuery
            // 
            this.Button_SubmitQuery.Location = new System.Drawing.Point(673, 65);
            this.Button_SubmitQuery.Name = "Button_SubmitQuery";
            this.Button_SubmitQuery.Size = new System.Drawing.Size(112, 117);
            this.Button_SubmitQuery.TabIndex = 5;
            this.Button_SubmitQuery.Text = "Submit Query";
            this.Button_SubmitQuery.UseVisualStyleBackColor = true;
            this.Button_SubmitQuery.Click += new System.EventHandler(this.Button_SubmitQuery_Click);
            // 
            // textBox_output
            // 
            this.textBox_output.Location = new System.Drawing.Point(7, 213);
            this.textBox_output.Multiline = true;
            this.textBox_output.Name = "textBox_output";
            this.textBox_output.Size = new System.Drawing.Size(831, 463);
            this.textBox_output.TabIndex = 6;
            // 
            // Label_Output
            // 
            this.Label_Output.AutoSize = true;
            this.Label_Output.Location = new System.Drawing.Point(13, 197);
            this.Label_Output.Name = "Label_Output";
            this.Label_Output.Size = new System.Drawing.Size(39, 13);
            this.Label_Output.TabIndex = 7;
            this.Label_Output.Text = "Output";
            this.Label_Output.Click += new System.EventHandler(this.Label_Output_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Label_Output);
            this.panel1.Controls.Add(this.textBox_Query);
            this.panel1.Controls.Add(this.textBox_output);
            this.panel1.Controls.Add(this.ButtonFileOpen);
            this.panel1.Controls.Add(this.Button_SubmitQuery);
            this.panel1.Controls.Add(this.label_openafile);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(276, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 686);
            this.panel1.TabIndex = 8;
            // 
            // MainPage
            // 
            this.ClientSize = new System.Drawing.Size(1126, 686);
            this.Controls.Add(this.TreeviewHierarchy);
            this.Controls.Add(this.panel1);
            this.Name = "MainPage";
            this.Text = "Query Window";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView Hierarchy;
        private System.Windows.Forms.Button ButtonOpenFile;
        private System.Windows.Forms.Label Label_Filename;
        private System.Windows.Forms.TextBox TextboxQuery;
        private System.Windows.Forms.Label label_typequery;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView TreeviewHierarchy;
        private System.Windows.Forms.Button ButtonFileOpen;
        private System.Windows.Forms.Label label_openafile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Query;
        private System.Windows.Forms.Button Button_SubmitQuery;
        private System.Windows.Forms.TextBox textBox_output;
        private System.Windows.Forms.Label Label_Output;
        private System.Windows.Forms.Panel panel1;
    }
}

