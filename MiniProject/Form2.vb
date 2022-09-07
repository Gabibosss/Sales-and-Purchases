Imports System.Data
Imports System.Data.SqlClient
Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim iExit As DialogResult
        iExit = MessageBox.Show("Do you wish to go back to previous form?", "Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If iExit = DialogResult.Yes Then
            Form1.Show()
        ElseIf iExit = DialogResult.No Then
            Me.Show()

        End If

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If String.IsNullOrEmpty(TextBox1.Text) Then
            MessageBox.Show("Please enter your first name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("Please enter your surname", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(ComboBox1.SelectedItem) Then
            MessageBox.Show("Please select your gender", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(TextBox3.Text) Then
            MessageBox.Show("Please enter your email", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(TextBox4.Text) Then
            MessageBox.Show("Please enter your phone number", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(TextBox5.Text) Then
            MessageBox.Show("Please enter the shop name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(ComboBox2.SelectedItem) Then
            MessageBox.Show("Please select the type of shop", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(TextBox7.Text) Then
            MessageBox.Show("Please enter location of shop", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(TextBox10.Text) Then
            MessageBox.Show("Please enter your business phone number", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(TextBox8.Text) Then
            MessageBox.Show("Please enter your username", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(TextBox9.Text) Then
            MessageBox.Show("Please enter your password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else



            Dim con As New SqlConnection("Data Source=DESKTOP-4NI1PEQ\SQLEXPRESS;Initial Catalog=MiniProject;Integrated Security=True")
            Dim cmd As New SqlCommand("INSERT INTO [dbo].[Seller_Info]
           ([F_Name]
           ,[S_Name]
           ,[Gender]
           ,[Email]
           ,[Phone]
           ,[Shop_Name]
           ,[Shop_Type]
           ,[Location]
           ,[B_Phone]
           ,[Username]
           ,[Password])
     VALUES
           ('" + TextBox1.Text + "', '" + TextBox2.Text + "','" + ComboBox1.SelectedItem.ToString() + "', '" + TextBox3.Text + "',  '" + TextBox4.Text + "', '" + TextBox5.Text + "', '" + ComboBox2.SelectedItem.ToString + "', '" + TextBox7.Text + "', '" + TextBox10.Text + "', '" + TextBox8.Text + "', '" + TextBox9.Text + "')", con)
            con.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Registration successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)


            If ComboBox2.SelectedItem = "Supermarket" Then
                Me.Hide()
                Form6.Show()


            ElseIf ComboBox2.SelectedItem = "Cosmetic" Then
                Me.Hide()
                Form7.Show()

            ElseIf ComboBox2.SelectedItem = "Accessories" Then
                Me.Hide()
                Form8.Show()
            End If
            con.Close()
        End If

    End Sub

    Private Sub Number_Only(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress, TextBox10.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("Please enter your phone number", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
