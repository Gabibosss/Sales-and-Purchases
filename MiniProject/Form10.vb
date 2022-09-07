Imports System.Data.SqlClient

Public Class Form10
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GABRIEL\source\repos\MiniProject\Inventory1.mdf;Integrated Security=True")
        con.Open()
        Dim cmd As New SqlCommand("select Product_Name, Product_ID, Quantity, Price from ViewIN", con)
        Dim sda As New SqlDataAdapter
        sda.SelectCommand = cmd
        Dim dt As New DataTable
        dt.Clear()
        sda.Fill(dt)
        DataGridView1.DataSource = dt
        con.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TryCast(DataGridView1.DataSource, DataTable).DefaultView.RowFilter =
            String.Format("Product_Name like '%" & TextBox1.Text & "%'")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim iExit As DialogResult
        iExit = MessageBox.Show("Do you wish to exit this application?", "Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If iExit = DialogResult.Yes Then
            Me.Hide()
            Form11.Show()

        End If
    End Sub
End Class