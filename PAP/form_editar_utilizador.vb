Imports MySql.Data.MySqlClient

Public Class form_editar_utilizador

    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PictureBox1.Image.Dispose()
    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        System.IO.File.Delete(form_diretorio.Label1.Text & ":\PAP\camara\" & TextBox6.Text & ".jpg")
        form_camara_utilizadores.Show()
        form_camara_utilizadores.MdiParent = Form1
        form_camara_utilizadores.Label1.Text = "Editar"

    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        ligacao.ConnectionString = StrLigacao
        Query = "update login set  Utilizador= @Utilizador,senha=@senha, nome= @nome, Email= @Email, Idade= @Idade, NIF= @NIF Where ID_Utilizador= " & Label8.Text

        Try

            ligacao.Open()
            Comando = New MySqlCommand(Query, ligacao)
            Comando.Parameters.AddWithValue("@ID_Utilizador", Label8.Text)
            Comando.Parameters.AddWithValue("@Utilizador", TextBox5.Text)
            Comando.Parameters.AddWithValue("@senha", TextBox3.Text)
            Comando.Parameters.AddWithValue("@nome", TextBox2.Text)
            Comando.Parameters.AddWithValue("@Email", TextBox4.Text)
            Comando.Parameters.AddWithValue("@Idade", TextBox1.Text)
            Comando.Parameters.AddWithValue("@NIF", TextBox6.Text)
            Comando.ExecuteNonQuery()

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")

        Finally
            ligacao.Close()


        End Try


        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Utilizador,Utilizador, Senha, Nome, Email,Idade,NIF FROM login", StrLigacao)

        ligacao.ConnectionString = StrLigacao
        Try
            ligacao.Open()
            adapter.Fill(table)
            form.datagridview1.DataSource = table

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
    End Sub
End Class