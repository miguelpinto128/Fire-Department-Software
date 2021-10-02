Imports MySql.Data.MySqlClient

Public Class form_criar_viaturas

    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"


    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        ligacao.ConnectionString = StrLigacao
        Query = "Insert Into veiculos ( Matricula, Marca, Ano, Descricao, Estado, Tipo ,Data_Registo,Modelo) values  ( @Matricula, @Marca ,@Ano ,@Descricao, @Estado, @Tipo, @Data_Registo,@Modelo)"


        Try
            ligacao.Open()
            Comando = New MySqlCommand(Query, ligacao)
            Comando.Parameters.AddWithValue("@Matricula", TextBox2.Text)
            Comando.Parameters.AddWithValue("@Marca", ComboBox4.Text)
            Comando.Parameters.AddWithValue("@Ano", ComboBox1.Text)
            Comando.Parameters.AddWithValue("@Descricao", TextBox5.Text)
            Comando.Parameters.AddWithValue("@Estado", ComboBox2.Text)
            Comando.Parameters.AddWithValue("@Tipo", ComboBox3.Text)
            Comando.Parameters.AddWithValue("@Data_Registo", DateTimePicker1.Text)
            Comando.Parameters.AddWithValue("@Modelo", TextBox1.Text)
            Comando.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ligacao.Close()
        End Try

        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Veiculos, Matricula, Marca, Ano, Estado, Modelo FROM veiculos", StrLigacao)
        ligacao.ConnectionString = StrLigacao
        Try
            ligacao.Open()
            adapter.Fill(table)
            form_viaturas.datagridview1.DataSource = table

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
        PictureBox1.Image.Save(form_diretorio.Label1.Text & ":\PAP\camara\" & TextBox2.Text & ".jpg")
        TextBox2.ResetText()
        ComboBox4.ResetText()
        ComboBox1.ResetText()
        TextBox5.ResetText()
        ComboBox2.ResetText()
        ComboBox3.ResetText()
        DateTimePicker1.ResetText()
        TextBox1.ResetText()
    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Label11.Text = OpenFileDialog1.FileName
            PictureBox1.ImageLocation = Label11.Text
        End If
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        TextBox2.ResetText()
        ComboBox4.ResetText()
        ComboBox1.ResetText()
        TextBox5.ResetText()
        ComboBox2.ResetText()
        ComboBox3.ResetText()
        DateTimePicker1.ResetText()
        TextBox1.ResetText()
    End Sub

    Private Sub PictureBox3_MouseHover(sender As Object, e As EventArgs) Handles PictureBox3.MouseHover
        Label16.Visible = True
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave
        Label16.Visible = False
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        TextBox2.Text = StrConv(TextBox2.Text, vbProperCase)
        TextBox2.SelectionStart = TextBox2.Text.Length + 1
    End Sub


End Class