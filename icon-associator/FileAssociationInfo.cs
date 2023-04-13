using System;

namespace icon_associator
{
	/// <summary>
	/// Stores information for adding or removing file association info from the Registry.
	/// </summary>
	public struct FileAssociationInfo
	{
		private string str_ProgramPath;

		/// <summary>
		/// The file type to associate with the program associated with this struct
		/// </summary>
		public string FileExtension;

		/// <summary>
		/// Determines whether a 'shell\open\command' key will be created for this file association
		/// </summary>
		public bool AssociateOpen;

		/// <summary>
		/// Determines whether a 'shell\edit\command' key will be created for this file association
		/// </summary>
		public bool AssociateEdit;

		/// <summary>
		/// The program command associated with the 'shell\open\command' key
		/// </summary>
		public string OpenCommand;

		/// <summary>
		/// The program command associated with the 'shell\edit\command' key
		/// </summary>
		public string EditCommand;

		
		public static string DefaultCLI(string ProgramPath)
		{
			return $"\"{ProgramPath}\" \"%1\"";
		}

		internal FileAssociationInfo(string ProgramPath, string FileExtension, bool AssociateOpen, bool AssociateEdit, string OpenCommand, string EditCommand)
		{
			str_ProgramPath = ProgramPath;
			this.FileExtension = FileExtension;
			this.AssociateOpen = AssociateOpen;
			this.AssociateEdit = AssociateEdit;
			this.OpenCommand = OpenCommand;
			this.EditCommand = EditCommand;
		}

		public static FileAssociationInfo CreateAssociationInfo(string ProgramPath, string FileExtension, string OpenCommand, string EditCommand)
		{
			return new FileAssociationInfo(ProgramPath, FileExtension, true, true, OpenCommand, EditCommand);
		}

		public static FileAssociationInfo CreateOpenInfo(string ProgramPath, string FileExtension, string OpenCommand)
		{
			return new FileAssociationInfo(ProgramPath, FileExtension, true, false, OpenCommand, "");
		}

		public static FileAssociationInfo CreateEditInfo(string ProgramPath, string FileExtension, string EditCommand)
		{
			return new FileAssociationInfo(ProgramPath, FileExtension, false, true, "", EditCommand);
		}
	}
}
