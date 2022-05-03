
namespace ToDo_app_new
{
    partial class Form1
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
            this.notes_data = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.notes_data)).BeginInit();
            this.SuspendLayout();
            // 
            // notes_data
            // 
            this.notes_data.BackgroundColor = System.Drawing.SystemColors.Control;
            this.notes_data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.notes_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.notes_data.GridColor = System.Drawing.SystemColors.Control;
            this.notes_data.Location = new System.Drawing.Point(23, 24);
            this.notes_data.Name = "notes_data";
            this.notes_data.RowHeadersVisible = false;
            this.notes_data.Size = new System.Drawing.Size(734, 231);
            this.notes_data.TabIndex = 0;
            this.notes_data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(758, 61);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add task";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.notes_data);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.notes_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView notes_data;
        private System.Windows.Forms.Button button1;
    }
}

