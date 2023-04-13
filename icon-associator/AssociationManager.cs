using Microsoft.Win32;

namespace icon_associator
{
    public static class AssociationManager
    {
        /// <summary>
        /// Adds the provided file association info to your device registry
        /// </summary>
        /// <param name="AssociationInfo">The file assocation info to add</param>
        public static void AddAssociationInfo(FileAssociationInfo AssociationInfo)
        {
            RegistryKey rootKey = Registry.ClassesRoot;
            RegistryKey assocKey = rootKey.CreateSubKey($"{AssociationInfo.FileExtension}\\shell");

            if (AssociationInfo.AssociateOpen)
                assocKey.CreateSubKey("open\\command").SetValue("", AssociationInfo.OpenCommand);
            if (AssociationInfo.AssociateEdit)
                assocKey.CreateSubKey("edit\\command").SetValue("", AssociationInfo.EditCommand);

            assocKey.Close();
            rootKey.Close();

            Win32.UpdateAssociations();
        }

        /// <summary>
        /// Removes the specified file assocation info from your device registry
        /// </summary>
        /// <param name="AssociationInfo">Used to identify the file association info of which to be removed from your device registry</param>
        public static void RemoveAssociationInfo(FileAssociationInfo AssociationInfo)
        {
            RegistryKey rootKey = Registry.ClassesRoot;
            RegistryKey assocKey = rootKey.OpenSubKey(AssociationInfo.FileExtension);

            if (assocKey != null || assocKey.OpenSubKey("shell") != null)
                rootKey.DeleteSubKeyTree(AssociationInfo.FileExtension, true);

            rootKey.Close();

            Win32.UpdateAssociations();
        }

        /// <summary>
        /// Checks the device's registry to see if the specified program's file assocation info was added
        /// </summary>
        /// <param name="AssociationInfo">The program's file assoication info the check for</param>
        /// <returns><see langword="true"/> if the info is found, <see langword="false"/> if otherwise</returns>
        public static bool CheckForAssociationInfo(FileAssociationInfo AssociationInfo)
        {
            RegistryKey rootKey = Registry.ClassesRoot;
            RegistryKey assocKey = rootKey.OpenSubKey(AssociationInfo.FileExtension);
            bool result = false;

            if (rootKey == null || assocKey == null) result = false;

            if (assocKey != null &&
                assocKey.OpenSubKey("shell") != null &&
                ((assocKey.OpenSubKey("open") != null && AssociationInfo.AssociateOpen) ||
                (assocKey.OpenSubKey("edit") != null && AssociationInfo.AssociateEdit)))
                result = true;

            assocKey?.Close();
            rootKey.Close();

            return result;
        }
    }
}
