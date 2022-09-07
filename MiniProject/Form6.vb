Imports System.Data.SqlClient

Public Class Form6

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim i As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MessageBox.Show("Please enter the product name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("Please enter the product id", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(TextBox3.Text) Then
            MessageBox.Show("Please enter the quantity of the product", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(TextBox4.Text) Then
            MessageBox.Show("Please enter the price of the product", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Try
                cmd = con.CreateCommand()
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "insert into Table1 values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')"
                cmd.ExecuteNonQuery()
                Disp_data()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
            Catch ex As Exception

            End Try

        End If

    End Sub

    Public Sub Disp_data()
        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from Table1"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt


    End Sub


    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GABRIEL\source\repos\MiniProject\Inventory1.mdf;Integrated Security=True"
        If con.State = ConnectionState.Open Then
            con.Close()

        End If
        con.Open()
        Disp_data()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim iExit As DialogResult
        iExit = MessageBox.Show("Do you wish to exit?", "Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If iExit = DialogResult.Yes Then
            Application.Exit()
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        If con.State = ConnectionState.Open Then
            con.Close()

        End If
        con.Open()

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick




        If con.State = ConnectionState.Open Then
            con.Close()

        End If

        con.Open()


        i = Convert.ToInt32(DataGridView1.SelectedCells.Item(0).Value.ToString())




        Try
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from Table1 where id=" & i & ""
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Dim dr As SqlClient.SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read
                TextBox1.Text = dr.GetString(1).ToString()
                TextBox2.Text = dr.GetString(2).ToString()
                TextBox3.Text = dr.GetString(3).ToString()
                TextBox4.Text = dr.GetString(4).ToString()
            End While
        Catch ex As Exception
            MessageBox.Show("Error", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If con.State = ConnectionState.Open Then
            con.Close()

        End If

        con.Open()


        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update Table1 set Product_Name='" + TextBox1.Text + "', Product_ID='" + TextBox2.Text + "', Quantity='" + TextBox3.Text + "', Price='" + TextBox4.Text + "' where id=" & i & ""
        cmd.ExecuteNonQuery()



        Disp_data()



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        If con.State = ConnectionState.Open Then
            con.Close()

        End If

        con.Open()
        Try
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "delete from Table1 where Product_Name='" + TextBox1.Text + "'"
            cmd.ExecuteNonQuery()
            Disp_data()
        Catch ex As Exception
            MessageBox.Show("Error", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Form10.Show()
    End Sub
End Class