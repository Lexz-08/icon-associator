# icon-associator
## Description
Makes creating and removing file associations easier.<br>
Also calls `SHChangeNotify()` to automatically update your file associations, and can even help sometimes if you have associated another program with a different file type, and the association for that isn't updating.

## How To Use
This code is made assuming you have already referenced `icon-associator.dll` in your project, and is using `System.Windows.Forms.dll` for the example.<br>
Also, the two examples for adding and removing file associations should not be added in the same code block, they should be separate, as the removal would negate the addition, making usage of this library useless.
```csharp
str_ExampleExtension = ".example";

FileAssociation association = FileAssociation.CreateOpenInfo(
    Application.ExecutablePath, str_ExampleExtension,
    // returns "<EXECUTABLE_PATH>" "%1" with <EXECUTABLE_PATH> being the file path to your .exe
    FileAssociation.DefaultCLI(Application.ExecutablePath)
    );

// add the association to your device registry if not already there
if (!AssociationManager.CheckForAssociationInfo(association))
    AssociationManager.AddAssociationInfo(association);

// remove the association from your device registry if there
if (AssociationManager.CheckForAssociationInfo(association))
    AssociationManager.RemoveAssociationInfo(association);
```

## Download
[icon-associator.dll](https://github.com/Lexz-08/icon-associator/releases/latest/download/icon-associator.dll)
