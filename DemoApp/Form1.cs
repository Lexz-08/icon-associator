using icon_associator;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace DemoApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			if (Registry.ClassesRoot.OpenSubKey("icon_assoc_demoapp") == null)
			{
				Registry.ClassesRoot.CreateSubKey("icon_assoc_demoapp").SetValue("file_assoc", "none");

				btn_AssociateFile.Enabled = true;
				btn_UnassociateFile.Enabled = false;
			}
			else if (Registry.ClassesRoot.OpenSubKey("icon_assoc_demoapp").GetValue("file_assoc").ToString() != "none")
			{
				string str_FileExtension = Registry.ClassesRoot.OpenSubKey("icon_assoc_demoapp").GetValue("file_assoc").ToString();
				txt_FileExtension.Text = str_FileExtension;
				txt_FileExtension.ReadOnly = true;

				btn_AssociateFile.Enabled = false;
				btn_UnassociateFile.Enabled = true;
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);

			if (btn_AssociateFile.Enabled == true)
				Registry.ClassesRoot.DeleteSubKeyTree("icon_assoc_demoapp", true);
		}

		private void AssociateFile_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txt_FileExtension.Text))
			{
				string str_Extension = txt_FileExtension.Text.StartsWith(".") ? txt_FileExtension.Text : $".{txt_FileExtension.Text}";

				Registry.ClassesRoot.OpenSubKey("icon_assoc_demoapp", true).SetValue("file_assoc", str_Extension);
				FileAssociationInfo fasc_AssociationInfo = FileAssociationInfo.CreateOpenInfo(
					Application.ExecutablePath, str_Extension,
					FileAssociationInfo.DefaultCLI(Application.ExecutablePath));
				AssociationManager.AddAssociationInfo(fasc_AssociationInfo);

				btn_AssociateFile.Enabled = false;
				btn_UnassociateFile.Enabled = true;
			}
			else MessageBox.Show("Please specify a file extension not already associated within this device before performing an association.", "Unassociated File Type Required",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void UnassociateFile_Click(object sender, EventArgs e)
		{
			string str_Extension = txt_FileExtension.Text.StartsWith(".") ? txt_FileExtension.Text : $".{txt_FileExtension.Text}";

			Registry.ClassesRoot.OpenSubKey("icon_assoc_demoapp", true).SetValue("file_assoc", "none");
			FileAssociationInfo fasc_AssociationInfo = FileAssociationInfo.CreateOpenInfo(
				Application.ExecutablePath, str_Extension,
				FileAssociationInfo.DefaultCLI(Application.ExecutablePath));
			AssociationManager.RemoveAssociationInfo(fasc_AssociationInfo);

			btn_AssociateFile.Enabled = true;
			btn_UnassociateFile.Enabled = false;
			txt_FileExtension.ReadOnly = false;
		}
	}
}
