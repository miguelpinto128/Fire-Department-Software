Imports MySql.Data.MySqlClient

Public Class form

    Dim dr As MySqlDataReader
    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"


    Private Sub form_utilizadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Utilizador,Utilizador, Senha, Nome, Email,Idade,NIF FROM login", StrLigacao)

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
        Dim searchquery As String = "SELECT ID_Utilizador,Utilizador, Senha, Nome, Email,Idade,NIF from login where CONCAT(Utilizador, Senha, Nome, Email,Idade,NIF) like '%" & TextBox1.Text & "%'"
        Dim comand As New MySqlCommand(searchquery, ligacao)
        Dim adapter As New MySqlDataAdapter(comand)
        Dim table As New DataTable()
        adapter.Fill(table)
        datagridview1.DataSource = table
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        filterdata(TextBox1.Text)

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            filterdata(TextBox1.Text)
        End If

    End Sub

    Private Sub FicheiroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FicheiroToolStripMenuItem.Click
        form_criar_utilizador.Show()
        form_criar_utilizador.MdiParent = Form1
    End Sub

    Private Sub datagridview1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = datagridview1.Rows(index)
        Try
            ligacao.Open()
            Query = "select ID_Utilizador,Utilizador, senha, nome, Email, Idade, NIF From login Where ID_Utilizador = " & selectedrow.Cells(0).Value.ToString()
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            form_editar_utilizador.Label8.Text = dr("ID_Utilizador")
            form_editar_utilizador.TextBox5.Text = dr("Utilizador")
            form_editar_utilizador.TextBox3.Text = dr("senha")
            form_editar_utilizador.TextBox2.Text = dr("nome")
            form_editar_utilizador.TextBox4.Text = dr("Email")
            form_editar_utilizador.TextBox1.Text = dr("Idade")
            form_editar_utilizador.TextBox6.Text = dr("NIF")


        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
        form_editar_utilizador.PictureBox1.Image = System.Drawing.Bitmap.FromFile(form_diretorio.Label1.Text & ":\PAP\camara\" & form_editar_utilizador.TextBox6.Text & ".jpg")
        form_editar_utilizador.Show()
        form_editar_utilizador.MdiParent = Form1
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        ligacao.ConnectionString = StrLigacao

        Try
            ligacao.Open()
            Query = "delete From login Where ID_Utilizador = " & Label3.Text
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try


        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Utilizador,Utilizador, Senha, Nome, Email,Idade,NIF FROM login", StrLigacao)

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
            Query = "select ID_Utilizador From login Where id_Utilizador = " & selectedrow.Cells(0).Value.ToString()
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            Label3.Text = dr("ID_utilizador")


        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
    End Sub
End Class