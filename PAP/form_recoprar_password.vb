Imports MySql.Data.MySqlClient
Imports System.Net.Mail

Public Class form_recoprar_password


    Dim dr As MySqlDataReader
    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label2.Visible = True
        TextBox2.Visible = True

        Dim MySqlConnection As MySqlConnection
        MySqlConnection = New MySqlConnection()
        MySqlConnection.ConnectionString = "server=localhost;port=3306;userid=pap;password=pap;database=pap"
        Try
            MySqlConnection.Open()
        Catch myerror As MySqlException
            MessageBox.Show("Não e possivel ligar a base de dados: " & myerror.Message)
        End Try
        Dim myadapter As New MySqlDataAdapter
        Dim sqlquary = "SELECT * FROM login WHERE Email = '" & TextBox1.Text & "';"
        Dim command As New MySqlCommand
        command.Connection = MySqlConnection
        command.CommandText = sqlquary
        myadapter.SelectCommand = command
        Dim mydata As MySqlDataReader
        mydata = command.ExecuteReader()

        If mydata.HasRows = 0 Then
            MsgBox("Email não existe")

        Else

            Label3.Text = GenerateRandomString(6, False)
            Try
                Dim Smtp_Server As New SmtpClient
                Dim e_mail As New MailMessage()
                Smtp_Server.UseDefaultCredentials = False
                Smtp_Server.Credentials = New Net.NetworkCredential("sportstore.clientes@gmail.com", "Sergiosa7")
                Smtp_Server.Port = 587
                Smtp_Server.EnableSsl = True
                Smtp_Server.Host = "smtp.gmail.com"

                e_mail = New MailMessage()
                e_mail.From = New MailAddress("sportstore.clientes@gmail.com")
                e_mail.To.Add(TextBox1.Text)
                e_mail.Subject = "Recuperação Password SportStore"
                e_mail.IsBodyHtml = False
                e_mail.Body = "O código de recuperação é " & Label3.Text & ". Use este código para que consiga recuperar a sua password."
                Smtp_Server.Send(e_mail)
                MsgBox("Mail Sent")

            Catch error_t As Exception
                MsgBox(error_t.ToString)
            End Try
        End If



    End Sub

    Private Sub form_recoprar_password_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Function GenerateRandomString(ByRef len As Integer, ByRef upper As Boolean) As String
        Dim rand As New Random()
        Dim allowableChars() As Char = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789".ToCharArray()
        Dim final As String = String.Empty
        For i As Integer = 0 To len - 1
            final += allowableChars(rand.Next(allowableChars.Length - 1))
        Next

        Return IIf(upper, final.ToUpper(), final)
    End Function

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = Label3.Text Then
            Label4.Visible = True
            TextBox3.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ligacao.ConnectionString = StrLigacao
        Query = "update login set senha= @senha Where Email = '" & TextBox1.Text & "'"
        Try
            ligacao.Open()
            Comando = New MySqlCommand(Query, ligacao)

            Comando.Parameters.AddWithValue("@senha", TextBox3.Text)

            Comando.ExecuteNonQuery()

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro.")
        Finally
            ligacao.Close()

        End Try

    End Sub
End Class