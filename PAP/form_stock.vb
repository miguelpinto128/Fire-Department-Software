Imports MySql.Data.MySqlClient
Public Class form_stock

    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"
    Dim dr As MySqlDataReader

    Private Sub form_stock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Produto, Nome_Produto, Numero_Produto FROM Stock", StrLigacao)
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
        Dim searchquery As String = "SELECT ID_Produto, Nome_Produto, Numero_Produto FROM Stock where CONCAT(ID_Produto, Nome_Produto, Numero_Produto) like '%" & TextBox1.Text & "%'"
        Dim comand As New MySqlCommand(searchquery, ligacao)
        Dim adapter As New MySqlDataAdapter(comand)
        Dim table As New DataTable()
        adapter.Fill(table)
        datagridview1.DataSource = table
    End Sub

    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs)
        Label2.Visible = True
    End Sub

    Private Sub PictureBox1_Mouseleave(sender As Object, e As EventArgs)
        Label2.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text = StrConv(TextBox1.Text, vbProperCase)
        filterdata(TextBox1.Text)
        TextBox1.SelectionStart = TextBox1.Text.Length + 1
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            filterdata(TextBox1.Text)
        End If

    End Sub

    Private Sub FicheiroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FicheiroToolStripMenuItem.Click
        form_criar_Stock.Show()
        form_criar_Stock.MdiParent = Form1
    End Sub

    Private Sub datagridview1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = datagridview1.Rows(index)
        Try
            ligacao.Open()
            Query = "select ID_Produto From Stock Where ID_Produto = " & selectedrow.Cells(0).Value.ToString()
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            Label3.Text = dr("ID_Produto")


        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
    End Sub

    Private Sub datagridview1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = datagridview1.Rows(index)
        Try
            ligacao.Open()
            Query = "select ID_Produto, Nome_Produto, Numero_Produto From Stock Where ID_Produto = " & selectedrow.Cells(0).Value.ToString()
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            form_adicionar_stock.Label8.Text = dr("ID_Produto")
            form_adicionar_stock.TextBox2.Text = dr("Nome_Produto")
            form_adicionar_stock.NumericUpDown1.Text = dr("Numero_Produto")

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
        form_adicionar_stock.PictureBox1.Image = System.Drawing.Bitmap.FromFile(form_diretorio.Label1.Text & ":\PAP\camara\" & form_adicionar_stock.TextBox2.Text & ".jpg")
        form_adicionar_stock.Show()
        form_adicionar_stock.MdiParent = Form1
    End Sub

    Private Sub EditarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem1.Click

        Try
            ligacao.Open()
            Query = "select ID_Produto, Nome_Produto, Numero_Produto From Stock Where ID_Produto = " & Label3.Text
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            form_adicionar_stock.Label8.Text = dr("ID_Produto")
            form_adicionar_stock.TextBox2.Text = dr("Nome_Produto")
            form_adicionar_stock.NumericUpDown1.Text = dr("Numero_Produto")


        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
        form_adicionar_stock.PictureBox1.Image = System.Drawing.Bitmap.FromFile(form_diretorio.Label1.Text & ":\PAP\camara\" & form_adicionar_stock.TextBox2.Text & ".jpg")
        form_adicionar_stock.Show()
        form_adicionar_stock.MdiParent = Form1
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        ligacao.ConnectionString = StrLigacao

        Try
            ligacao.Open()
            Query = "delete From Stock Where ID_Produto = " & Label3.Text
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try


        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Produto, Nome_Produto, Numero_Produto FROM Stock", StrLigacao)
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
    End Sub
End Class