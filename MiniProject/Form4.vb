﻿Imports System.Data
Imports System.Data.SqlClient

Public Class Form4
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection("Data Source=DESKTOP-4NI1PEQ\SQLEXPRESS;Initial Catalog=MiniProject;Integrated Security=True")
        Dim cmd As New SqlCommand("select * from Seller_Info where Username = '" + TextBox1.Text + "' and Password = '" + TextBox2.Text + "'", con)
        Dim sda As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        sda.Fill(dt)
        If (dt.Rows.Count > 0) Then
            MessageBox.Show("Login Succesful", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Login Failed. Invalid Username or Password", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox1.Focus()
        End If

        If ComboBox1.SelectedItem = "Supermarket" Then
            Me.Hide()
            Form6.Show()

        ElseIf ComboBox1.SelectedItem = "Cosmetic" Then
            Me.Hide()
            Form7.Show()

        ElseIf ComboBox1.SelectedItem = "Accessories" Then
            Me.Hide()
            Form8.Show()

        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Dim iExit As DialogResult
        iExit = MessageBox.Show("Do you wish to go back to previous form?", "Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If iExit = DialogResult.Yes Then
            Form1.Show()
        ElseIf iExit = DialogResult.No Then
            Me.Show()

        End If
    End Sub
End Class