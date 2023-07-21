# MSB.UI-WPF
MSB.UI-WPF is a UI library for Windows Presentation Foundation (WPF) applications. It provides a variety of controls and widgets that can be used to create complex and engaging user interfaces.

## Features
MSB.UI-WPF includes a variety of features, including:

A variety of controls and widgets, such as text boxes, lists, dialog boxes, and more
Support for styles and themes
Support for accessibility
## Installation
MSB.UI-WPF can be installed from NuGet. To install it, open the Visual Studio Package Manager and search for "MSB.UI-WPF". Click the "Install" button to install the library.

## Usage
MSB.UI-WPF can be used in the same way as any other WPF UI library. To use the library, add it as a reference to your project. Then, you can begin using the controls and widgets from the library in your user interface.

In your `App.xaml`...

```xaml
<Application x:Class="MyProject.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Application.Resources>
        <ResourceDictionary >
            <ResourceDictionary.MergedDictionaries>
                <!--MSB.UI-WPF assets-->
                <ResourceDictionary Source="/MSB.UI-WPF;component/Assets/Fonts/Fonts.xaml"/>
                <ResourceDictionary Source="/MSB.UI-WPF;component/Assets/Styles/Styles.xaml"/>
                <ResourceDictionary Source="/MSB.UI-WPF;component/Assets/Themes/Light.Green.xaml"/>
                
                <!--your assets-->
                ...
            </ResourceDictionary.MergedDictionaries>

            <!--other assets-->
            ...
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

In your `MainPage.xaml`...

```xaml
<Page x:Class="MyProject.Views.MainPage"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
      xmlns:msb="http://ui.msb-studios.com/winfx/xaml" <!--add this-->
      mc:Ignorable="d"
      
      d:DesignHeight="550" d:DesignWidth="600">

    <Grid Background="{DynamicResource PageBackground}">
        <msb:NavigationView IsActingAsTitleBar="True">
            <!--add your content here-->
        </msb:NavigationView>
    </Grid>
</Page>
```

## Release Notes

### [Version 2.0.0] - 2023-07-20

#### Added

- Added the `MenuItemsVisibility` and `FooterItemsVisibility` property in the `NavigationViewTemplateSettings` type. These new properties allow the `NavigationViewList` in `NavigationView` to be hidden or shown depending on whether they have items or not.
- Introduced `ApplicationTheme` and `ApplicationAccentColor` enums to make it easier for users to manage the theme and accent color of the application, as long as 'MSB.UI' resources are used.

#### Changed

- The `ModernWindow` control has been renamed to `AeroWindow`.
- `Flyout` is now included inside `AeroWindow`, however its default value is `null`. Create a new instance and use it according to your needs.
- Added the `CustomContentPlacement` property in the `NavigationView` type.

#### Removed

- The values `Top` and `Left` in the `LabelPosition` enum of the `AppBarButton` type were removed and its template was updated.

#### Fixed

- Fixed a bug that caused the brush in the `PathIcon` type to not update when the visual parent changed its `Foreground` property.

#### Notes

- Almost all the brushes resources have been renamed, many others were removed and some others added, for more details click [here](https://github.com/MSB-Studios/MSB.UI-Windows-Presentation/blob/main/MSB.UI-WPF/Assets/Themes/Light.Pink.xaml) to know the resources included in this version.
- The `MessageDialog` type has also received changes, its `Caption` property is now `Title` and `Content` changed to `Message`.

## Contributions
MSB.UI-WPF is an open source project. If you would like to contribute to the project, you can submit your changes through the MSB.UI-WPF [GitHub repository](https://github.com/MSB-Studios/MSB.UI-Windows-Presentation).

## Thank you
Thank you for using MSB.UI-WPF!