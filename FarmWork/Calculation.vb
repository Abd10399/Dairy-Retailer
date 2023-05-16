Imports MySql.Data.MySqlClient

Public Class Calculation
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Private Sub Calculation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=Abdullah1234554321;database=farm2"
        Dim Reader As MySqlDataReader

        Try
            mysqlconn.Open()
            Dim query As String
            query = "select * from farm2.customerinfo"
            command = New MySqlCommand(query, mysqlconn)
            Reader = command.ExecuteReader
            While Reader.Read
                Dim name = Reader.GetString("CustomerName")

                ListBox1.Items.Add(name)

            End While
            mysqlconn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()

        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=Abdullah1234554321;database=farm2"
        Dim Reader As MySqlDataReader

        Try
            mysqlconn.Open()
            Dim query As String
            query = "select * from farm2.customerinfo where customername='" & ListBox1.Text & "'"
            command = New MySqlCommand(query, mysqlconn)
            Reader = command.ExecuteReader
            While Reader.Read
                TextBox2.Text = Reader.GetInt32("customerID")
                TextBox1.Text = Reader.GetString("CustomerName")
                TextBox3.Text = Reader.GetDecimal("TotalBill")


            End While
            mysqlconn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=Abdullah1234554321;database=farm2"
        Dim Reader As MySqlDataReader

        Try
            mysqlconn.Open()
            Dim query As String
            query = "update farm2.customerinfo set TotalBill = RatePerKg * MilkQuantity where customerID='" & Convert.ToInt32(TextBox2.Text) & "'"
            command = New MySqlCommand(query, mysqlconn)

            Reader = command.ExecuteReader
            refresh()



            mysqlconn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()

        End Try
    End Sub
    Private Sub refresh()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=Abdullah1234554321;database=farm2"
        Dim Reader As MySqlDataReader

        Try
            mysqlconn.Open()
            Dim query As String
            query = "select * from farm2.customerinfo where customername='" & ListBox1.Text & "'"
            command = New MySqlCommand(query, mysqlconn)
            Reader = command.ExecuteReader
            While Reader.Read
                TextBox2.Text = Reader.GetInt32("customerID")
                TextBox1.Text = Reader.GetString("CustomerName")
                TextBox3.Text = Reader.GetDecimal("TotalBill")


            End While
            mysqlconn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()

        End Try
    End Sub
End Class