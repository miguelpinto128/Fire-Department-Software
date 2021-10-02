Imports MySql.Data.MySqlClient


Public Class form_editar_socios

    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"



    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        ligacao.ConnectionString = StrLigacao
        Query = "update socios set  Nome= @Nome, NIF=@NIF, Morada=@Morada, Data_Aderencia=@Data_Aderencia, Data_Nascimento=@Data_Nascimento, Sexo=@Sexo, Telemovel=@Telemovel ,Email=@Email Where ID_Socio= " & Label8.Text
        ''  Try

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

        '' Catch ex As MySql.Data.MySqlClient.MySqlException
        '' MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        '' Finally
        ligacao.Close()
        '' End Try



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

    End Sub
End Class