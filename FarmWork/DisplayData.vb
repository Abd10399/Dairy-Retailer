Imports MySql.Data.MySqlClient

Public Class Display_Data
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()

    End Sub
    Private Sub load_data()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=Abdullah1234554321;database=farm2"
        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource

        Try
            mysqlconn.Open()
            Dim query As String
            query = "Select * from farm2.customerinfo"
            command = New MySqlCommand(query, mysqlconn)
            sda.SelectCommand = command
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset

            DataGridView1.DataSource = bsource
            sda.Update(dbdataset)



            mysqlconn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        load_data()

    End Sub

    Private Sub Display_Data_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_data()

    End Sub


End Class