Imports MySql.Data.MySqlClient
Public Class form_contagem
    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"
    Dim count1 As Integer
    Dim count2 As Integer
    Dim count3 As Integer
    Dim count4 As Integer

    Private Sub form_contagem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MySqlConnection As MySqlConnection
        MySqlConnection = New MySqlConnection()
        MySqlConnection.ConnectionString = "server=localhost;port=3306;userid=pap;password=pap;database=pap"
        Try
            MySqlConnection.Open()
            Dim qry1 = "SELECT COUNT(*) as TRows FROM bombeiros"
            Dim cmd1 As New MySql.Data.MySqlClient.MySqlCommand(qry1, MySqlConnection)
            count1 = cmd1.ExecuteScalar
            Label5.Text = count1.ToString

            Dim qry2 = "SELECT COUNT(*) as TRows FROM veiculos"
            Dim cmd2 As New MySql.Data.MySqlClient.MySqlCommand(qry2, MySqlConnection)
            count2 = cmd2.ExecuteScalar
            Label6.Text = count2.ToString

            Dim qry3 = "SELECT COUNT(*) as TRows FROM socios"
            Dim cmd3 As New MySql.Data.MySqlClient.MySqlCommand(qry3, MySqlConnection)
            count3 = cmd3.ExecuteScalar
            Label7.Text = count3.ToString

            Dim qry4 = "SELECT COUNT(*) as TRows FROM ocorrencias"
            Dim cmd4 As New MySql.Data.MySqlClient.MySqlCommand(qry4, MySqlConnection)
            count4 = cmd4.ExecuteScalar
            Label8.Text = count4.ToString

        Catch myerror As MySqlException
            MessageBox.Show("ERRO " & myerror.Message)
        Finally
            MySqlConnection.Close()
        End Try
    End Sub
End Class