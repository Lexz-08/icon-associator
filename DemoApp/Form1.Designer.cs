namespace DemoApp
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
			this.lbl_FileExtension = new System.Windows.Forms.Label();
			this.txt_FileExtension = new System.Windows.Forms.TextBox();
			this.btn_AssociateFile = new System.Windows.Forms.Button();
			this.btn_UnassociateFile = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbl_FileExtension
			// 
			this.lbl_FileExtension.AutoSize = true;
			this.lbl_FileExtension.Location = new System.Drawing.Point(12, 9);
			this.lbl_FileExtension.Name = "lbl_FileExtension";
			this.lbl_FileExtension.Size = new System.Drawing.Size(82, 15);
			this.lbl_FileExtension.TabIndex = 0;
			this.lbl_FileExtension.Text = "File Extension:";
			// 
			// txt_FileExtension
			// 
			this.txt_FileExtension.Location = new System.Drawing.Point(100, 5);
			this.txt_FileExtension.Name = "txt_FileExtension";
			this.txt_FileExtension.Size = new System.Drawing.Size(248, 23);
			this.txt_FileExtension.TabIndex = 1;
			// 
			// btn_AssociateFile
			// 
			this.btn_AssociateFile.Location = new System.Drawing.Point(258, 34);
			this.btn_AssociateFile.Name = "btn_AssociateFile";
			this.btn_AssociateFile.Size = new System.Drawing.Size(90, 23);
			this.btn_AssociateFile.TabIndex = 2;
			this.btn_AssociateFile.Text = "Associate File";
			this.btn_AssociateFile.UseVisualStyleBackColor = true;
			this.btn_AssociateFile.Click += new System.EventHandler(this.AssociateFile_Click);
			// 
			// btn_UnassociateFile
			// 
			this.btn_UnassociateFile.Enabled = false;
			this.btn_UnassociateFile.Location = new System.Drawing.Point(149, 34);
			this.btn_UnassociateFile.Name = "btn_UnassociateFile";
			this.btn_UnassociateFile.Size = new System.Drawing.Size(103, 23);
			this.btn_UnassociateFile.TabIndex = 3;
			this.btn_UnassociateFile.Text = "Unassociate File";
			this.btn_UnassociateFile.UseVisualStyleBackColor = true;
			this.btn_UnassociateFile.Click += new System.EventHandler(this.UnassociateFile_Click);
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(360, 68);
			this.Controls.Add(this.btn_UnassociateFile);
			this.Controls.Add(this.btn_AssociateFile);
			this.Controls.Add(this.txt_FileExtension);
			this.Controls.Add(this.lbl_FileExtension);
			this.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "reg";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_FileExtension;
		private System.Windows.Forms.TextBox txt_FileExtension;
		private System.Windows.Forms.Button btn_AssociateFile;
		private System.Windows.Forms.Button btn_UnassociateFile;
	}
}

