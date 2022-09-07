Imports System.Reflection.Emit

Public Class Form11

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        Timer1.Start()


        ProgressBar1.Value += 1
        If ProgressBar1.Value > 20 Then
            Label1.Text = "Closing all components"
        End If


        If ProgressBar1.Value > 50 Then
            Label1.Text = "Enjoy your day"
        End If


        If ProgressBar1.Value > 75 Then
            Label1.Text = "Goodbye"
        End If

        If ProgressBar1.Value > 90 Then
            Label1.Text = "Adios"

        End If
        Application.Exit()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Stop()
        Me.Hide()
        Form10.Show()

    End Sub
End Class