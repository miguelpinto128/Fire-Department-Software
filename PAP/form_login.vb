Imports MySql.Data.MySqlClient

Public Class form_login
    Private Sub form_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = DateTime.Now.ToString("hh:mm:ss")
        Label2.Text = DateTime.Now.Date
    End Sub

    Private Sub txtutilizador_TextChanged(sender As Object, e As EventArgs) Handles txtutilizador.Click
        '''TEXTO NAS TEXBOX DO LOGIN
        If txtutilizador.Text = "UTILIZADOR" Then
            txtutilizador.Text = ""
        End If

        If txtsenha.Text = "" Then
            txtsenha.Text = "PASSWORD"
        End If
        If txtsenha.Text = "PASSWORD" Then
            txtsenha.PasswordChar = ""
        End If


    End Sub

    Private Sub txtsenha_TextChanged(sender As Object, e As EventArgs) Handles txtsenha.Click
        '''TEXTO NAS TEXBOX DO LOGIN
        If txtsenha.Text = "PASSWORD" Then
            txtsenha.Text = ""
            txtsenha.PasswordChar = "*"
        End If

        If txtutilizador.Text = "" Then
            txtutilizador.Text = "UTILIZADOR"
        End If

        If txtsenha.Text = "PASSWORD" Then
            txtsenha.PasswordChar = ""
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        '''TEXTO NAS TEXBOX DO LOGIN
        If CheckBox1.Checked = True Then
            txtsenha.PasswordChar = ""
        Else
            txtsenha.PasswordChar = "*"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ''' LOGIN, BUSCA NA BASE DE DADOS
        Dim MySqlConnection As MySqlConnection
        MySqlConnection = New MySqlConnection()
        MySqlConnection.ConnectionString = "server=localhost;port=3306;userid=pap;password=pap;database=pap"
        Try
            MySqlConnection.Open()
            Dim myadapter As New MySqlDataAdapter
            Dim sqlquary = "SELECT * FROM login WHERE utilizador = '" & txtutilizador.Text & "' and senha = '" & txtsenha.Text & "';"
            Dim command As New MySqlCommand
            command.Connection = MySqlConnection
            command.CommandText = sqlquary
            myadapter.SelectCommand = command
            Dim mydata As MySqlDataReader
            mydata = command.ExecuteReader()
            If mydata.HasRows = 0 Then
                If txtutilizador.Text = "UTILIZADOR" And txtsenha.Text = "PASSWORD" Then
                End If
                txtutilizador.Text = "UTILIZADOR"
                txtsenha.Text = "PASSWORD"
                txtsenha.PasswordChar = ""
                MsgBox("Utilziador ou Password inválidos!")
            Else
                Form1.Show()
                Me.Hide()
            End If
        Catch myerror As MySqlException
            MessageBox.Show("ERRO " & myerror.Message)
        End Try
    End Sub

    Private Sub form_login_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        End
    End Sub

    Private Sub form_login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        End
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        form_recoprar_password.Show()
    End Sub
End Class