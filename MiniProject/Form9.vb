Public Class Form9
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        Label3.Text = ProgressBar1.Value & "%"

        ProgressBar1.Value += 1

        If ProgressBar1.Value > 10 Then
            Label2.Text = "Loading various components..."
        End If

        If ProgressBar1.Value > 25 Then
            Label2.Text = "Please be patient..."
        End If

        If ProgressBar1.Value > 35 Then
            Label2.Text = "Help customers find products easily"
        End If

        If ProgressBar1.Value > 60 Then
            Label2.Text = "Know exactly where to get products"
        End If

        If ProgressBar1.Value > 80 Then
            Label2.Text = "Life should be this easy"
        End If

        If ProgressBar1.Value > 95 Then
            Label2.Text = "Almost there..."
        End If

        If ProgressBar1.Value = 99 Then
            Label2.Text = "Launching Application"
            Me.Hide()
            Form1.Show()
            Timer1.Dispose()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Stop()
        Me.Close()

    End Sub
End Class