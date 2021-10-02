Imports System.Text

Imports MySql.Data.MySqlClient
Public Class form_editar_ocorrencias


    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"


    Private Sub form_editar_ocorrencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Size = New Size(783, 434)
        TabControl1.Size = New Size(783, 434)

        Dim street As String = TextBox3.Text
        Dim city As String = TextBox4.Text
        Dim zip As String = TextBox6.Text

        Try
            Dim queryaddress As New StringBuilder
            queryaddress.Append("http://maps.google.com/maps?=")

            If TextBox3.Text <> String.Empty Then
                queryaddress.Append(city + "," & "+")
            End If
            If TextBox4.Text <> String.Empty Then
                queryaddress.Append(city + "," & "+")
            End If
            If TextBox6.Text <> String.Empty Then
                queryaddress.Append(zip + "," & "+")
            End If

            WebBrowser1.Navigate(queryaddress.ToString)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Size = New Size(816, 304)
        TabControl1.Size = New Size(783, 237)
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        ligacao.ConnectionString = StrLigacao
        Query = "update ocorrencias set  Designacao= @Designacao,Data_Ocorrencia=@Data_Ocorrencia, Nome= @Nome, Telefone= @Telefone, Meios_Homens= @Meios_Homens, Meios_Viaturas= @Meios_Viaturas, Meios_Corpo_Bombeiros= @Meios_Corpo_Bombeiros ,Rua= @Rua,Cidade=@Cidade, Codigo_Postal= @Codigo_Postal, Feridos_bomb_ligeiro= @Feridos_bomb_ligeiro, Feridos_bomb_grave= @Feridos_bomb_grave, Feridos_bomb_Mortes= @Feridos_bomb_Mortes, Feridos_civil_ligeiro= @Feridos_civil_ligeiro, Feridos_civil_grave= @Feridos_civil_grave, Feridos_civil_mortes= @Feridos_civil_mortes Where id_ocorrencia= " & Label8.Text

        Try

            ligacao.Open()
            Comando = New MySqlCommand(Query, ligacao)

            Comando.Parameters.AddWithValue("@Designacao", TextBox1.Text)
            Comando.Parameters.AddWithValue("@Data_Ocorrencia", DateTimePicker1.Text)
            Comando.Parameters.AddWithValue("@Nome", TextBox2.Text)
            Comando.Parameters.AddWithValue("@Telefone", TextBox5.Text)
            Comando.Parameters.AddWithValue("@Meios_Homens", TextBox9.Text)
            Comando.Parameters.AddWithValue("@Meios_Viaturas", TextBox8.Text)
            Comando.Parameters.AddWithValue("@Meios_Corpo_Bombeiros", TextBox7.Text)
            Comando.Parameters.AddWithValue("@Rua", TextBox3.Text)
            Comando.Parameters.AddWithValue("@Cidade", TextBox4.Text)
            Comando.Parameters.AddWithValue("@Codigo_Postal", TextBox6.Text)
            Comando.Parameters.AddWithValue("@Feridos_bomb_ligeiro", TextBox12.Text)
            Comando.Parameters.AddWithValue("@Feridos_bomb_grave", TextBox11.Text)
            Comando.Parameters.AddWithValue("@Feridos_bomb_Mortes", TextBox10.Text)
            Comando.Parameters.AddWithValue("@Feridos_civil_ligeiro", TextBox15.Text)
            Comando.Parameters.AddWithValue("@Feridos_civil_grave", TextBox14.Text)
            Comando.Parameters.AddWithValue("@Feridos_civil_mortes", TextBox13.Text)
            Comando.ExecuteNonQuery()

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")

        Finally
            ligacao.Close()


        End Try


        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Ocorrencia,Data_Ocorrencia, Rua, Telefone, Designacao  FROM Ocorrencias", StrLigacao)

        ligacao.ConnectionString = StrLigacao
        Try
            ligacao.Open()
            adapter.Fill(table)
            form_ocorrencias.datagridview1.DataSource = table

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub
End Class