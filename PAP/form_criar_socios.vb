Imports MySql.Data.MySqlClient

Public Class form_criar_socios

    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"


    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        ligacao.ConnectionString = StrLigacao
        Query = "Insert Into socios ( Nome, NIF, Morada, Data_Aderencia, Data_Nascimento, Sexo ,Telemovel,Email) values  ( @Nome, @NIF ,@Morada ,@Data_Aderencia, @Data_Nascimento, @Sexo, @Telemovel,@Email)"


        Try
            ligacao.Open()
            Comando = New MySqlCommand(Query, ligacao)
            Comando.Parameters.AddWithValue("@Nome", TextBox2.Text)
            Comando.Parameters.AddWithValue("@NIF", TextBox5.Text)
            Comando.Parameters.AddWithValue("@Morada", TextBox1.Text)
            Comando.Parameters.AddWithValue("@Data_Aderencia", DateTimePicker1.Text)
            Comando.Parameters.AddWithValue("@Data_Nascimento", DateTimePicker2.Text)
            Comando.Parameters.AddWithValue("@Sexo", ComboBox4.Text)
            Comando.Parameters.AddWithValue("@Telemovel", TextBox3.Text)
            Comando.Parameters.AddWithValue("@Email", TextBox4.Text)
            Comando.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ligacao.Close()
        End Try


        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Socio, Nome, NIF, Telemovel,Email FROM socios", StrLigacao)
        ligacao.ConnectionString = StrLigacao
        Try
            ligacao.Open()
            adapter.Fill(table)
            form_socios.datagridview1.DataSource = table

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
        PictureBox1.Image.Save(form_diretorio.Label1.Text & ":\PAP\camara\" & TextBox5.Text & ".jpg")
        TextBox2.ResetText()
        TextBox5.ResetText()
        TextBox1.ResetText()
        DateTimePicker1.ResetText()
        DateTimePicker2.ResetText()
        ComboBox4.ResetText()
        TextBox3.ResetText()
        TextBox4.ResetText()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        TextBox2.ResetText()
        TextBox5.ResetText()
        TextBox1.ResetText()
        DateTimePicker1.ResetText()
        DateTimePicker2.ResetText()
        ComboBox4.ResetText()
        TextBox3.ResetText()
        TextBox4.ResetText()
    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Label11.Text = OpenFileDialog1.FileName
            PictureBox1.ImageLocation = Label11.Text
        End If
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub form_criar_socios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class