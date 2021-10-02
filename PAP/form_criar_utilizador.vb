Imports MySql.Data.MySqlClient
Public Class form_criar_utilizador

    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"

    Private Sub form_criar_utilizador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        form_camara_utilizadores.Show()
        form_camara_utilizadores.MdiParent = Form1
        form_camara_utilizadores.Label1.Text = "Criar"
    End Sub

    Private Sub PictureBox3_MouseHover(sender As Object, e As EventArgs) Handles PictureBox3.MouseHover
        Label16.Visible = True
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave
        Label16.Visible = False
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        ligacao.ConnectionString = StrLigacao
        Query = "Insert Into login (Utilizador, senha,nome, Email, Idade, NIF) values  ( @Utilizador, @senha ,@nome ,@Email, @Idade, @NIF)"


        Try
            ligacao.Open()
            Comando = New MySqlCommand(Query, ligacao)
            Comando.Parameters.AddWithValue("@Utilizador", TextBox5.Text)
            Comando.Parameters.AddWithValue("@senha", TextBox3.Text)
            Comando.Parameters.AddWithValue("@nome", TextBox2.Text)
            Comando.Parameters.AddWithValue("@Email", TextBox4.Text)
            Comando.Parameters.AddWithValue("@Idade", TextBox1.Text)
            Comando.Parameters.AddWithValue("@NIF", TextBox6.Text)
            Comando.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ligacao.Close()
        End Try

        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Utilizador,Utilizador, Senha, Nome, Email,Idade,NIF FROM login", StrLigacao)

        ligacao.ConnectionString = StrLigacao
        Try
            ligacao.Open()
            adapter.Fill(table)
            Form.datagridview1.DataSource = table

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
        PictureBox1.Image.Save(form_diretorio.Label1.Text & ":\PAP\camara\" & TextBox6.Text & ".jpg")
        TextBox5.ResetText()
        TextBox3.ResetText()
        TextBox2.ResetText()
        TextBox4.ResetText()
        TextBox1.ResetText()
        TextBox6.ResetText()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        TextBox5.ResetText()
        TextBox3.ResetText()
        TextBox2.ResetText()
        TextBox4.ResetText()
        TextBox1.ResetText()
        TextBox6.ResetText()
    End Sub
End Class