Imports MySql.Data.MySqlClient

Public Class form_bombeiros

    Dim dr As MySqlDataReader
    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"

    Private Sub form_bombeiros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Bombeiro, Nome, NIF, Categoria, Atividade,Sexo FROM bombeiros", StrLigacao)
        'ID_Bombeiro, Nome, NIF, Categoria, Disponibilidade
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
        Dim searchquery As String = "SELECT ID_Bombeiro, Nome,NIF, Categoria,Atividade,Sexo from bombeiros where CONCAT(ID_Bombeiro, Nome,NIF, Categoria,Atividade,Sexo) like '%" & TextBox1.Text & "%'"
        Dim comand As New MySqlCommand(searchquery, ligacao)
        Dim adapter As New MySqlDataAdapter(comand)
        Dim table As New DataTable()
        adapter.Fill(table)
        datagridview1.DataSource = table
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        form_editar_bombeiro.Show()
        form_editar_bombeiro.MdiParent = Form1
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

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        form_criar_bombeiros.Show()
        form_criar_bombeiros.MdiParent = Form1
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub datagridview1_CelldoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = datagridview1.Rows(index)
        Try
            ligacao.Open()
            Query = "select ID_Bombeiro,Nome,Sexo, ID_Equipa,Categoria,NIF,Data_admissao,atividade,Calcas, Camisola, Casaco, cinto, Chapeu, Botas From bombeiros Where id_bombeiro = " & selectedrow.Cells(0).Value.ToString()
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            form_editar_bombeiro.Label8.Text = dr("ID_BOmbeiro")
            form_editar_bombeiro.TextBox2.Text = dr("Nome")
            form_editar_bombeiro.ComboBox4.Text = dr("Sexo")
            form_editar_bombeiro.ComboBox2.Text = dr("ID_Equipa")
            form_editar_bombeiro.ComboBox1.Text = dr("Categoria")
            form_editar_bombeiro.TextBox5.Text = dr("NIF")
            form_editar_bombeiro.DateTimePicker1.Text = dr("Data_admissao")
            form_editar_bombeiro.ComboBox3.Text = dr("atividade")
            form_editar_bombeiro.ComboBox5.Text = dr("Calcas")
            form_editar_bombeiro.ComboBox6.Text = dr("Camisola")
            form_editar_bombeiro.ComboBox7.Text = dr("Casaco")
            form_editar_bombeiro.ComboBox8.Text = dr("cinto")
            form_editar_bombeiro.ComboBox9.Text = dr("Chapeu")
            form_editar_bombeiro.ComboBox10.Text = dr("Botas")

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
        form_editar_bombeiro.PictureBox1.Image = System.Drawing.Bitmap.FromFile(form_diretorio.Label1.Text & ":\PAP\camara\" & form_editar_bombeiro.TextBox5.Text & ".jpg")
        form_editar_bombeiro.Show()
        form_editar_bombeiro.MdiParent = Form1
    End Sub

    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        Label2.Visible = True

    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        Label2.Visible = False
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click

        ligacao.ConnectionString = StrLigacao

        Try
            ligacao.Open()
            Query = "delete From bombeiros Where ID_bombeiro = " & Label3.Text
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader

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
            datagridview1.DataSource = table

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
            System.IO.File.Delete(form_diretorio.Label1.Text & ":\PAP\camara\" & Label4.Text & ".jpg")
        End Try
    End Sub

    Private Sub datagridview1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = datagridview1.Rows(index)
        Try
            ligacao.Open()
            Query = "select ID_BOmbeiro, NIF From bombeiros Where id_bombeiro = " & selectedrow.Cells(0).Value.ToString()
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            Label3.Text = dr("ID_BOmbeiro")
            Label4.Text = dr("NIF")

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try

    End Sub

    Private Sub FicheiroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FicheiroToolStripMenuItem.Click
        form_criar_bombeiros.Show()
        form_criar_bombeiros.MdiParent = Form1

    End Sub

    Private Sub EditarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem1.Click
        Try
            ligacao.Open()
            Query = "select ID_Bombeiro,Nome,Sexo, ID_Equipa,Categoria,NIF,Data_admissao,atividade,Calcas, Camisola, Casaco, cinto, Chapeu, Botas From bombeiros Where id_bombeiro = " & Label3.Text
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            form_editar_bombeiro.Label8.Text = dr("ID_BOmbeiro")
            form_editar_bombeiro.TextBox2.Text = dr("Nome")
            form_editar_bombeiro.ComboBox4.Text = dr("Sexo")
            form_editar_bombeiro.ComboBox2.Text = dr("ID_Equipa")
            form_editar_bombeiro.ComboBox1.Text = dr("Categoria")
            form_editar_bombeiro.TextBox5.Text = dr("NIF")
            form_editar_bombeiro.DateTimePicker1.Text = dr("Data_admissao")
            form_editar_bombeiro.ComboBox3.Text = dr("atividade")
            form_editar_bombeiro.ComboBox5.Text = dr("Calcas")
            form_editar_bombeiro.ComboBox6.Text = dr("Camisola")
            form_editar_bombeiro.ComboBox7.Text = dr("Casaco")
            form_editar_bombeiro.ComboBox8.Text = dr("cinto")
            form_editar_bombeiro.ComboBox9.Text = dr("Chapeu")
            form_editar_bombeiro.ComboBox10.Text = dr("Botas")

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
        form_editar_bombeiro.PictureBox1.Image = System.Drawing.Bitmap.FromFile(form_diretorio.Label1.Text & ":\PAP\camara\" & form_editar_bombeiro.TextBox5.Text & ".jpg")
        form_editar_bombeiro.Show()
        form_editar_bombeiro.MdiParent = Form1
    End Sub

    Private Sub datagridview1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellContentClick

    End Sub
End Class