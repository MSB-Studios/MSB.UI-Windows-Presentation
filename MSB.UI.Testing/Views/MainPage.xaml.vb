Imports MSB.UI.Controls

Namespace Views
    Class MainPage
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub OnShowDialogButtonClick(sender As Object, e As RoutedEventArgs)
            Dim xBtn = TryCast(sender, Button)

            If xBtn Is Nothing Then
                Return
            End If

            Select Case xBtn.Tag
                Case "MD"
                    With New MessageDialog()
                        .Title = "Message Dialog"
                        .Message = "This is a message dialog."
                        .Show()
                    End With
                Case "CD"
                    With New ContentDialog()
                        .Title = "Content Dialog"
                        .Content = New TextBox() With {
                            .Background = Brushes.Pink,
                            .Text = "This is a content dialog."
                        }
                        .Show()
                    End With
            End Select
        End Sub
    End Class
End Namespace