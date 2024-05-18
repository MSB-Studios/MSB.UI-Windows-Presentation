Imports MSB.UI.Testing.Views
Imports MSB.UI

Class Application
    Protected Overrides Sub OnStartup(e As StartupEventArgs)
        MyBase.OnStartup(e)

        If Me.MainWindow Is Nothing Then
            Dim xFrame As New Frame()
            Dim xWindow As New AeroWindow()

            With xFrame
                .Navigate(New MainPage())
            End With

            With xWindow
                .WindowStartupLocation = WindowStartupLocation.CenterScreen
                .ExtendViewIntoTitleBar = True
                .MinHeight = 450
                .MinWidth = 550
                .Height = 0
                .Width = 0
                .Content = xFrame
            End With

            Me.MainWindow = xWindow
        End If

        Me.MainWindow.Show()
    End Sub

    Protected Overrides Sub OnExit(e As ExitEventArgs)
        MyBase.OnExit(e)
    End Sub

End Class
