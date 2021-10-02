Imports MySql.Data.MySqlClient
Public Class form_criar_Stock

    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"
    Private Sub form_criar_Stock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Label11.Text = OpenFileDialog1.FileName
            PictureBox1.ImageLocation = Label11.Text
        End If
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        ligacao.ConnectionString = StrLigacao
        Query = "Insert Into Stock ( Nome_Produto) values  ( @Nome_Produto)"

        Try
            ligacao.Open()
            Comando = New MySqlCommand(Query, ligacao)
            Comando.Parameters.AddWithValue("@Nome_Produto", TextBox2.Text)


            Comando.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ligacao.Close()
        End Try

        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Produto,Nome_Produto, Numero_Produto FROM Stock", StrLigacao)
        ligacao.ConnectionString = StrLigacao
        Try
            ligacao.Open()
            adapter.Fill(table)
            form_stock.datagridview1.DataSource = table

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
        PictureBox1.Image.Save(form_diretorio.Label1.Text & ":\PAP\camara\" & TextBox2.Text & ".jpg")
        TextBox2.ResetText()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        TextBox2.ResetText()
    End Sub
End Class