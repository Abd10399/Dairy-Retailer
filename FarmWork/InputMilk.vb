Imports MySql.Data.MySqlClient

Public Class InputMilk
    Dim mysqlconn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub InputMilk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=Abdullah1234554321;database=farm2"
        Dim Reader As MySqlDataReader

        Try
            mysqlconn.Open()
            Dim query As String
            query = "select * from farm2.customerinfo"
            COMMAND = New MySqlCommand(query, mysqlconn)
            Reader = COMMAND.ExecuteReader
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
            COMMAND = New MySqlCommand(query, mysqlconn)
            Reader = COMMAND.ExecuteReader
            While Reader.Read
                TextBox2.Text = Reader.GetInt32("customerID")
                TextBox3.Text = Reader.GetString("CustomerName")


            End While
            mysqlconn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=Abdullah1234554321;database=farm2"
        Dim Reader As MySqlDataReader

        Try
            mysqlconn.Open()
            Dim query As String
            query = "update farm2.customerinfo set milkquantity = milkquantity + '" & Convert.ToDecimal(TextBox1.Text) & "', Day" & TextBox4.Text & " = " & Convert.ToDecimal(TextBox1.Text) & " where customerID= '" & Convert.ToInt32(TextBox2.Text) & "'"

            COMMAND = New MySqlCommand(query, mysqlconn)

            Reader = COMMAND.ExecuteReader


            MessageBox.Show("Updated!")

            mysqlconn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()

        End Try
    End Sub
End Class