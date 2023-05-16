Imports MySql.Data.MySqlClient

Public Class Form1
    Dim mysqlconn As MySqlConnection


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InputMilk.Show()
        Me.Hide()


    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Calculation.Show()
        Me.Hide()

    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Display_Data.Show()
        Me.Hide()

    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Change_Data.Show()
        Me.Hide()


    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=Abdullah1234554321;database=farm2"


        Try
            mysqlconn.Open()
            MessageBox.Show("Connection Successful")
            mysqlconn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()

        End Try
    End Sub


End Class
