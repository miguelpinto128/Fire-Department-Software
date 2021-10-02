Imports MySql.Data.MySqlClient
Public Class form_editar_bombeiro

    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"

    Private Sub form_editar_bombeiro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        System.IO.File.Delete(form_diretorio.Label1.Text & ":\PAP\camara\" & TextBox5.Text & ".jpg")
        form_camara.Show()
        form_camara.MdiParent = Form1
        form_camara.Label1.Text = "Editar"

    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        ligacao.ConnectionString = StrLigacao
        Query = "update bombeiros set  Nome= @Nome,Sexo=@sexo, nif= @nif, categoria= @categoria, ID_equipa= @ID_equipa, atividade= @atividade, Data_Admissao= @Data_Admissao ,Calcas= @Calcas,Camisola=@Camisola, Casaco= @Casaco, cinto= @cinto, Chapeu= @Chapeu, Botas= @Botas Where id_bombeiro= " & Label8.Text
        Try

            ligacao.Open()
            Comando = New MySqlCommand(Query, ligacao)

            Comando.Parameters.AddWithValue("@nome", TextBox2.Text)
            Comando.Parameters.AddWithValue("@nif", TextBox5.Text)
            Comando.Parameters.AddWithValue("@sexo", ComboBox4.Text)
            Comando.Parameters.AddWithValue("@categoria", ComboBox1.Text)
            Comando.Parameters.AddWithValue("@ID_equipa", ComboBox2.Text)
            Comando.Parameters.AddWithValue("@atividade", ComboBox3.Text)
            Comando.Parameters.AddWithValue("@Data_admissao", DateTimePicker1.Text)
            Comando.Parameters.AddWithValue("@Calcas", ComboBox5.Text)
            Comando.Parameters.AddWithValue("@Camisola", ComboBox6.Text)
            Comando.Parameters.AddWithValue("@Casaco", ComboBox7.Text)
            Comando.Parameters.AddWithValue("@cinto", ComboBox8.Text)
            Comando.Parameters.AddWithValue("@Chapeu", ComboBox9.Text)
            Comando.Parameters.AddWithValue("@Botas", ComboBox10.Text)
            Comando.ExecuteNonQuery()

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")

        Finally
            ligacao.Close()


        End Try


        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Bombeiro,Nome,NIF,Categoria,Atividade,Sexo FROM bombeiros", StrLigacao)
        ligacao.ConnectionString = StrLigacao
        Try
            ligacao.Open()
            adapter.Fill(table)
            form_bombeiros.datagridview1.DataSource = table

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()

        End Try
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        TextBox2.Text = StrConv(TextBox2.Text, vbProperCase)
        TextBox2.SelectionStart = TextBox2.Text.Length + 1
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PictureBox1.Image.Dispose()
    End Sub

End Class