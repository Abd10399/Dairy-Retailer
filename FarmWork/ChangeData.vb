Imports MySql.Data.MySqlClient

Public Class Change_Data
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand

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
            query = "update farm2.customerinfo set TotalBill = 0"

            command = New MySqlCommand(query, mysqlconn)

            Reader = command.ExecuteReader

            MessageBox.Show("Cleared all customers Bill")



            mysqlconn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=Abdullah1234554321;database=farm2"
        Dim Reader As MySqlDataReader

        Try
            mysqlconn.Open()
            Dim query As String
            query = "update farm2.customerinfo set MilkQuantity = 0"
            command = New MySqlCommand(query, mysqlconn)


            Reader = command.ExecuteReader

            MessageBox.Show("Cleared all customers milk quantity")




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
                TextBox2.Text = Reader.GetString("customerName")
                TextBox1.Text = Reader.GetInt32("CustomerID")
                TextBox3.Text = Reader.GetDecimal("RatePerKg")
                TextBox4.Text = Reader.GetChar("MilkQuality")



            End While
            mysqlconn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()

        End Try
    End Sub
    Private Sub form_load()
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
    Private Sub Change_Data_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=Abdullah1234554321;database=farm2"
        Dim Reader As MySqlDataReader

        Try
            mysqlconn.Open()
            Dim query As String
            query = "update farm2.customerinfo set RatePerKg = '" & Convert.ToDecimal(TextBox3.Text) & "', MilkQuality='" & Convert.ToChar(TextBox4.Text) & "' where CustomerID = '" & Convert.ToInt32(TextBox1.Text) & "'"

            command = New MySqlCommand(query, mysqlconn)

            Reader = command.ExecuteReader
            MessageBox.Show("Data modified")

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
                TextBox2.Text = Reader.GetString("customerName")
                TextBox1.Text = Reader.GetInt32("CustomerID")
                TextBox3.Text = Reader.GetDecimal("RatePerKg")
                TextBox4.Text = Reader.GetChar("MilkQuality")



            End While
            mysqlconn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=Abdullah1234554321;database=farm2"
        Dim Reader As MySqlDataReader

        Try
            mysqlconn.Open()
            Dim query As String
            query = "insert into farm2.customerinfo (customerID,CustomerName,MilkQuality,RatePerKg,MilkQuantity,TotalBill) values ('" & Convert.ToInt32(TextBox1.Text) & "', '" & TextBox2.Text & "', '" & Convert.ToChar(TextBox4.Text) & "','" & Convert.ToDecimal(TextBox3.Text) & "','" & 0 & "', '" & 0 & "')"
            command = New MySqlCommand(query, mysqlconn)
            Reader = command.ExecuteReader
            MessageBox.Show("Data Saved!")
            form_load()






            mysqlconn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=Abdullah1234554321;database=farm2"
        Dim Reader As MySqlDataReader

        Try
            mysqlconn.Open()
            Dim query As String
            query = "delete from farm2.customerinfo where customerID='" & Convert.ToInt32(TextBox1.Text) & "'"
            command = New MySqlCommand(query, mysqlconn)
            Reader = command.ExecuteReader
            MessageBox.Show("Data Deleted!")
            form_load()
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()

        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=Abdullah1234554321;database=farm2"
        Dim Reader As MySqlDataReader

        Try
            mysqlconn.Open()
            Dim query As String
            query = "update farm2.customerinfo set Day1 = 0, Day2 = 0, Day3 = 0, Day4 = 0, Day5 = 0, Day6 = 0, Day7 = 0, Day8 = 0, Day9 = 0, Day10 = 0, Day11 = 0, Day12 = 0, Day13 = 0, Day14 = 0, Day15 = 0, Day16 = 0, Day17 = 0, Day18 = 0, Day19 = 0, Day20 = 0, Day21 = 0, Day22 = 0, Day23 = 0, Day24 = 0, Day25 = 0, Day26 = 0, Day27 = 0, Day28 = 0, Day29 = 0, Day30 = 0, Day31 = 0"

            command = New MySqlCommand(query, mysqlconn)

            Reader = command.ExecuteReader

            MessageBox.Show("Cleared all customers Bill")



            mysqlconn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()

        End Try
    End Sub
End Class