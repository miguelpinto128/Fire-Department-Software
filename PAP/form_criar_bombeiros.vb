Imports MySql.Data.MySqlClient

Public Class form_criar_bombeiros

    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"


    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        TextBox2.Text = StrConv(TextBox2.Text, vbProperCase)
        TextBox2.SelectionStart = TextBox2.Text.Length + 1

    End Sub

    Private Sub form_criar_bombeiros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GuardarToolStripMenuItem.Enabled = False
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        ligacao.ConnectionString = StrLigacao
        Query = "Insert Into bombeiros ( Nome, NIF, sexo, categoria, ID_equipa, atividade ,Data_admissao,Calcas, Camisola, Casaco, cinto, Chapeu, Botas) values  ( @Nome, @NIF ,@sexo ,@categoria, @ID_equipa, @atividade, @Data_admissao,@Calcas, @Camisola ,@Casaco ,@cinto, @Chapeu, @Botas)"


        Try
            ligacao.Open()
            Comando = New MySqlCommand(Query, ligacao)
            Comando.Parameters.AddWithValue("@Nome", TextBox2.Text)
            Comando.Parameters.AddWithValue("@NIF", TextBox5.Text)
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

        Catch ex As Exception
            MessageBox.Show(ex.Message)
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
        PictureBox1.Image.Save(form_diretorio.Label1.Text & ":\PAP\camara\" & TextBox5.Text & ".jpg")
        TextBox2.ResetText()
        TextBox5.ResetText()
        ComboBox4.ResetText()
        ComboBox1.ResetText()
        ComboBox2.ResetText()
        ComboBox3.ResetText()
        DateTimePicker1.ResetText()
        ComboBox5.ResetText()
        ComboBox6.ResetText()
        ComboBox7.ResetText()
        ComboBox8.ResetText()
        ComboBox9.ResetText()
        ComboBox10.ResetText()

    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        TextBox2.ResetText()
        TextBox5.ResetText()
        ComboBox4.ResetText()
        ComboBox1.ResetText()
        ComboBox2.ResetText()
        ComboBox3.ResetText()
        DateTimePicker1.ResetText()
    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        form_camara.Show()
        form_camara.MdiParent = Form1
        form_camara.Label1.Text = "Criar"
    End Sub

    Private Sub PictureBox3_MouseHover(sender As Object, e As EventArgs) Handles PictureBox3.MouseHover
        Label16.Visible = True
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave
        Label16.Visible = False
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        TextBox2.Text = StrConv(TextBox2.Text, vbProperCase)
        TextBox2.SelectionStart = TextBox2.Text.Length + 1
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class