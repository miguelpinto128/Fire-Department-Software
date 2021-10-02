Imports MySql.Data.MySqlClient
Public Class form_adicionar_stock

    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"


    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        ligacao.ConnectionString = StrLigacao
        Query = "update stock set  ID_Produto= @ID_Produto,Nome_Produto=@Nome_Produto, Numero_Produto= @Numero_Produto Where ID_Produto= " & Label8.Text
        Try

            ligacao.Open()
            Comando = New MySqlCommand(Query, ligacao)

            Comando.Parameters.AddWithValue("@ID_Produto", Label8.Text)
            Comando.Parameters.AddWithValue("@Nome_Produto", TextBox2.Text)
            Comando.Parameters.AddWithValue("@Numero_Produto", NumericUpDown1.Value)


            Comando.ExecuteNonQuery()

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")

        Finally
            ligacao.Close()
        End Try


        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Produto, Nome_Produto, Numero_Produto FROM stock", StrLigacao)
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
    End Sub
End Class