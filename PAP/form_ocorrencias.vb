Imports MySql.Data.MySqlClient

Public Class form_ocorrencias

    Dim dr As MySqlDataReader
    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"


    Private Sub form_ocorrencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Ocorrencia,Data_Ocorrencia, Rua, Telefone, Designacao  FROM Ocorrencias", StrLigacao)

        ligacao.ConnectionString = StrLigacao
        Try
            ligacao.Open()
            adapter.Fill(table)
            datagridview1.DataSource = table

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try

        filterdata("")
    End Sub

    Public Sub filterdata(valuetosearch As String)
        Dim searchquery As String = "SELECT ID_Ocorrencia,Data_Ocorrencia, Rua, Telefone, Designacao from Ocorrencias where CONCAT(ID_Ocorrencia,Data_Ocorrencia, Rua, Telefone, Designacao) like '%" & TextBox1.Text & "%'"
        Dim comand As New MySqlCommand(searchquery, ligacao)
        Dim adapter As New MySqlDataAdapter(comand)
        Dim table As New DataTable()
        adapter.Fill(table)
        datagridview1.DataSource = table
    End Sub

    Private Sub FicheiroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FicheiroToolStripMenuItem.Click
        form_criar_ocorrencias.Show()
        form_criar_ocorrencias.MdiParent = Form1
    End Sub

    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        Label2.Visible = True
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        Label2.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text = StrConv(TextBox1.Text, vbProperCase)
        filterdata(TextBox1.Text)
        TextBox1.SelectionStart = TextBox1.Text.Length + 1
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox1.Text = StrConv(TextBox1.Text, vbProperCase)
            filterdata(TextBox1.Text)
            TextBox1.SelectionStart = TextBox1.Text.Length + 1
        End If
    End Sub

    Private Sub EditarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem1.Click
        Try
            ligacao.Open()
            Query = "select ID_ocorrencia,Designacao, Data_Ocorrencia, Nome, Telefone, Meios_Homens, Meios_Viaturas ,Meios_Corpo_Bombeiros,Rua, Cidade, Codigo_Postal, Feridos_bomb_ligeiro, Feridos_bomb_grave, Feridos_bomb_Mortes,Feridos_civil_ligeiro,Feridos_civil_grave,Feridos_civil_mortes From ocorrencias Where id_ocorrencia = " & Label3.Text
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            form_editar_ocorrencias.Label8.Text = dr("ID_ocorrencia")
            form_editar_ocorrencias.TextBox1.Text = dr("Designacao")
            form_editar_ocorrencias.DateTimePicker1.Text = dr("Data_Ocorrencia")
            form_editar_ocorrencias.TextBox2.Text = dr("Nome")
            form_editar_ocorrencias.TextBox5.Text = dr("Telefone")
            form_editar_ocorrencias.TextBox9.Text = dr("Meios_Homens")
            form_editar_ocorrencias.TextBox8.Text = dr("Meios_Viaturas")
            form_editar_ocorrencias.TextBox7.Text = dr("Meios_Corpo_Bombeiros")
            form_editar_ocorrencias.TextBox3.Text = dr("Rua")
            form_editar_ocorrencias.TextBox4.Text = dr("Cidade")
            form_editar_ocorrencias.TextBox6.Text = dr("Codigo_Postal")
            form_editar_ocorrencias.TextBox12.Text = dr("Feridos_bomb_ligeiro")
            form_editar_ocorrencias.TextBox11.Text = dr("Feridos_bomb_grave")
            form_editar_ocorrencias.TextBox10.Text = dr("Feridos_bomb_Mortes")
            form_editar_ocorrencias.TextBox15.Text = dr("Feridos_civil_ligeiro")
            form_editar_ocorrencias.TextBox14.Text = dr("Feridos_civil_grave")
            form_editar_ocorrencias.TextBox13.Text = dr("Feridos_civil_mortes")

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try


        form_editar_ocorrencias.Show()
        form_editar_ocorrencias.MdiParent = Form1
    End Sub

    Private Sub datagridview1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = datagridview1.Rows(index)
        Try
            ligacao.Open()
            Query = "select ID_ocorrencia,Designacao, Data_Ocorrencia, Nome, Telefone, Meios_Homens, Meios_Viaturas ,Meios_Corpo_Bombeiros,Rua, Cidade, Codigo_Postal, Feridos_bomb_ligeiro, Feridos_bomb_grave, Feridos_bomb_Mortes,Feridos_civil_ligeiro,Feridos_civil_grave,Feridos_civil_mortes From ocorrencias Where id_ocorrencia = " & selectedrow.Cells(0).Value.ToString()
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            form_editar_ocorrencias.Label8.Text = dr("ID_ocorrencia")
            form_editar_ocorrencias.TextBox1.Text = dr("Designacao")
            form_editar_ocorrencias.DateTimePicker1.Text = dr("Data_Ocorrencia")
            form_editar_ocorrencias.TextBox2.Text = dr("Nome")
            form_editar_ocorrencias.TextBox5.Text = dr("Telefone")
            form_editar_ocorrencias.TextBox9.Text = dr("Meios_Homens")
            form_editar_ocorrencias.TextBox8.Text = dr("Meios_Viaturas")
            form_editar_ocorrencias.TextBox7.Text = dr("Meios_Corpo_Bombeiros")
            form_editar_ocorrencias.TextBox3.Text = dr("Rua")
            form_editar_ocorrencias.TextBox4.Text = dr("Cidade")
            form_editar_ocorrencias.TextBox6.Text = dr("Codigo_Postal")
            form_editar_ocorrencias.TextBox12.Text = dr("Feridos_bomb_ligeiro")
            form_editar_ocorrencias.TextBox11.Text = dr("Feridos_bomb_grave")
            form_editar_ocorrencias.TextBox10.Text = dr("Feridos_bomb_Mortes")
            form_editar_ocorrencias.TextBox15.Text = dr("Feridos_civil_ligeiro")
            form_editar_ocorrencias.TextBox14.Text = dr("Feridos_civil_grave")
            form_editar_ocorrencias.TextBox13.Text = dr("Feridos_civil_mortes")

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
        form_editar_ocorrencias.Show()
        form_editar_ocorrencias.MdiParent = Form1
    End Sub

    Private Sub datagridview1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = datagridview1.Rows(index)
        Try
            ligacao.Open()
            Query = "select ID_ocorrencia From ocorrencias Where id_ocorrencia = " & selectedrow.Cells(0).Value.ToString()
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            Label3.Text = dr("ID_ocorrencia")

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
    End Sub
End Class