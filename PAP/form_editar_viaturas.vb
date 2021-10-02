Imports MySql.Data.MySqlClient
Public Class form_editar_viaturas

    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"


    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        ligacao.ConnectionString = StrLigacao
        Query = "update veiculos set  Matricula= @Matricula,Marca=@Marca, Ano= @Ano, Descricao= @Descricao, Estado= @Estado, Tipo= @Tipo, Data_Registo= @Data_Registo ,Modelo= @Modelo Where id_veiculos= " & Label8.Text
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

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")

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
    End Sub

    Private Sub form_editar_viaturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        TextBox2.Text = StrConv(TextBox2.Text, vbProperCase)
        TextBox2.SelectionStart = TextBox2.Text.Length + 1
    End Sub
End Class