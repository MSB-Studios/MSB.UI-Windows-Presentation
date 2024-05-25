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

## Controls

- `msb:AeroWindow` ...
- `msb:MessageDialog` ...
- `msb:ContentDialog` ...
- `msb:AppBarButton` ...
- `msb:FontIcon` ...
- `msb:PathIcon` ...
- `msb:SymbolIcon` ...
- `msb:ImageIcon` ...
- `msb:NavigationView` ...
- `msb:NavigationViewList` ...
- `msb:NavigationViewItem` ...
- `msb:SplitView` ...
- `msb:TeachingTip` ...
- `msb:ToastAlert` ...

## Release Notes

### [Version 2.4.0] - 2024-05-25

#### Added

- `TeachingTip` is a UI control used to provide contextual information or guidance to users. It appears as a floating box, typically with a header, content, and optional actions, and is positioned relative to a specific target element.
- `ToastAlert` is a brief, dismissible notification that appears on the screen to inform users about events or statuses. It usually appears and disappears automatically after a short period.

#### Changed

- `MessageDialog` and `ContentDialog` are totally separate controls with unique purposes.
- Now the base color of the dark theme is no longer an absolute black.

#### Removed

- The `Flyout` control is deprecated and will be removed in future versions.

#### Fixed

- `ComboBox` content `Template` has been fixed.
- `NavigationView.FooterItems` placement has been fixed.

#### Notes

- Almost all the brushes resources have been renamed, many others were removed and some others added, for more details click [here](https://github.com/MSB-Studios/MSB.UI-Windows-Presentation/blob/main/MSB.UI-WPF/Assets/Themes/Light.Pink.xaml) to know the resources included in this version.
- The `MessageDialog` type has also received changes, its `Caption` property is now `Title` and `Content` changed to `Message`.

## Contributions
MSB.UI-WPF is an open source project. If you would like to contribute to the project, you can submit your changes through the MSB.UI-WPF [GitHub repository](https://github.com/MSB-Studios/MSB.UI-Windows-Presentation).

## Thank you
Thank you for using MSB.UI-WPF!