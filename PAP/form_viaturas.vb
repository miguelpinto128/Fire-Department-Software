Imports MySql.Data.MySqlClient

Public Class form_viaturas

    Dim dr As MySqlDataReader
    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"

    Private Sub form_viaturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Veiculos, Matricula, Marca, Ano, Estado, Modelo FROM veiculos", StrLigacao)
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
        Dim searchquery As String = "SELECT ID_Veiculos, Matricula, Marca, Ano, Estado, Modelo FROM veiculos where CONCAT(ID_Veiculos, Matricula,Marca, Ano,Estado,Modelo) like '%" & TextBox1.Text & "%'"
        Dim comand As New MySqlCommand(searchquery, ligacao)
        Dim adapter As New MySqlDataAdapter(comand)
        Dim table As New DataTable()
        adapter.Fill(table)
        datagridview1.DataSource = table
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

    Private Sub FicheiroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FicheiroToolStripMenuItem.Click
        form_criar_viaturas.Show()
        form_criar_viaturas.MdiParent = Form1
    End Sub

    Private Sub EditarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem1.Click

        Try
            ligacao.Open()
            Query = "select ID_Veiculos,Matricula, Marca, Ano, Descricao, Estado, Tipo ,Data_Registo,Modelo From veiculos Where ID_Veiculos = " & Label3.Text
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            form_editar_viaturas.Label8.Text = dr("ID_Veiculos")
            form_editar_viaturas.TextBox2.Text = dr("Matricula")
            form_editar_viaturas.ComboBox4.Text = dr("Marca")
            form_editar_viaturas.ComboBox1.Text = dr("Ano")
            form_editar_viaturas.TextBox5.Text = dr("Descricao")
            form_editar_viaturas.ComboBox2.Text = dr("Estado")
            form_editar_viaturas.ComboBox3.Text = dr("Tipo")
            form_editar_viaturas.DateTimePicker1.Text = dr("Data_Registo")
            form_editar_viaturas.TextBox1.Text = dr("Modelo")


        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
        form_editar_viaturas.PictureBox1.Image = System.Drawing.Bitmap.FromFile(form_diretorio.Label1.Text & ":\PAP\camara\" & form_editar_viaturas.TextBox2.Text & ".jpg")
        form_editar_viaturas.Show()
        form_editar_viaturas.MdiParent = Form1
    End Sub

    Private Sub datagridview1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = datagridview1.Rows(index)
        Try
            ligacao.Open()
            Query = "select ID_Veiculos,Matricula, Marca, Ano, Descricao, Estado, Tipo ,Data_Registo,Modelo From veiculos Where ID_Veiculos = " & selectedrow.Cells(0).Value.ToString()
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            form_editar_viaturas.Label8.Text = dr("ID_Veiculos")
            form_editar_viaturas.TextBox2.Text = dr("Matricula")
            form_editar_viaturas.ComboBox4.Text = dr("Marca")
            form_editar_viaturas.ComboBox1.Text = dr("Ano")
            form_editar_viaturas.TextBox5.Text = dr("Descricao")
            form_editar_viaturas.ComboBox2.Text = dr("Estado")
            form_editar_viaturas.ComboBox3.Text = dr("Tipo")
            form_editar_viaturas.DateTimePicker1.Text = dr("Data_Registo")
            form_editar_viaturas.TextBox1.Text = dr("Modelo")


        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
        form_editar_viaturas.PictureBox1.Image = System.Drawing.Bitmap.FromFile(form_diretorio.Label1.Text & ":\PAP\camara\" & form_editar_viaturas.TextBox2.Text & ".jpg")
        form_editar_viaturas.Show()
        form_editar_viaturas.MdiParent = Form1
    End Sub

    Private Sub datagridview1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = datagridview1.Rows(index)
        Try
            ligacao.Open()
            Query = "select ID_veiculos From veiculos Where ID_Veiculos = " & selectedrow.Cells(0).Value.ToString()
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            Label3.Text = dr("ID_Veiculos")


        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        ligacao.ConnectionString = StrLigacao

        Try
            ligacao.Open()
            Query = "delete From veiculos Where ID_Veiculos = " & Label3.Text
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader

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
            datagridview1.DataSource = table

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
    End Sub

    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        Label2.Visible = True
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        Label2.Visible = False
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub datagridview1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellContentClick

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class