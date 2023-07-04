using System.Runtime.InteropServices;
using System.Windows.Markup;
using System.Windows;

[assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]

[assembly: XmlnsPrefix("http://ui.msb-studios.com/winfx/xaml", "msb")]

[assembly: XmlnsDefinition("http://ui.msb-studios.com/winfx/xaml", "MSB.UI")]
[assembly: XmlnsDefinition("http://ui.msb-studios.com/winfx/xaml", "MSB.Converters")]
[assembly: XmlnsDefinition("http://ui.msb-studios.com/winfx/xaml", "MSB.UI.Controls")]
[assembly: XmlnsDefinition("http://ui.msb-studios.com/winfx/xaml", "MSB.Media.Animations")]

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

[assembly: Guid("b632d9b2-eecd-4a6a-9c1b-ef94b5df2123")]
