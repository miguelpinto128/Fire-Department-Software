Imports MySql.Data.MySqlClient

Public Class form_socios

    Dim dr As MySqlDataReader
    Dim Comando As MySqlCommand
    Dim ligacao As MySqlConnection = New MySqlConnection()
    Dim Query As String
    Dim StrLigacao As String = "server=localhost;port=3306;userid=pap;password=pap;database=pap"


    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        Label2.Visible = True
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        Label2.Visible = False
    End Sub

    Private Sub form_socios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Socio, Nome, NIF, Telemovel,Email FROM socios", StrLigacao)
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
        Dim searchquery As String = "SELECT ID_Socio, Nome, NIF, Telemovel,Email from socios where CONCAT(ID_Socio, Nome, NIF, Telemovel,Email) like '%" & TextBox1.Text & "%'"
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
        form_criar_socios.Show()
        form_criar_socios.MdiParent = Form1
    End Sub

    Private Sub datagridview1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = datagridview1.Rows(index)
        Try
            ligacao.Open()
            Query = "select ID_socio, NIF From socios Where id_socio = " & selectedrow.Cells(0).Value.ToString()
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            Label3.Text = dr("ID_socio")
            Label4.Text = dr("NIF")

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
    End Sub

    Private Sub EditarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem1.Click
        Try
            ligacao.Open()
            Query = "select  ID_Socio,Nome, NIF, Morada, Data_Aderencia, Data_Nascimento, Sexo ,Telemovel,Email From socios Where id_socio = " & Label3.Text
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            form_editar_socios.Label8.Text = dr("ID_socio")
            form_editar_socios.TextBox2.Text = dr("Nome")
            form_editar_socios.TextBox5.Text = dr("NIF")
            form_editar_socios.TextBox1.Text = dr("Morada")
            form_editar_socios.DateTimePicker1.Text = dr("Data_Aderencia")
            form_editar_socios.DateTimePicker2.Text = dr("Data_Nascimento")
            form_editar_socios.ComboBox4.Text = dr("Sexo")
            form_editar_socios.TextBox3.Text = dr("Telemovel")
            form_editar_socios.TextBox4.Text = dr("Email")


        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
        form_editar_socios.PictureBox1.Image = System.Drawing.Bitmap.FromFile(form_diretorio.Label1.Text & ":\PAP\camara\" & form_editar_socios.TextBox5.Text & ".jpg")
        form_editar_socios.Show()
        form_editar_socios.MdiParent = Form1
    End Sub

    Private Sub datagridview1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = datagridview1.Rows(index)
        Try
            ligacao.Open()
            Query = "select  ID_Socio,Nome, NIF, Morada, Data_Aderencia, Data_Nascimento, Sexo ,Telemovel,Email From socios Where id_socio = " & selectedrow.Cells(0).Value.ToString()
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader
            dr.Read()

            If dr.IsDBNull(0) Then
                Exit Sub
            End If
            form_editar_socios.Label8.Text = dr("ID_Socio")
            form_editar_socios.TextBox2.Text = dr("Nome")
            form_editar_socios.TextBox5.Text = dr("NIF")
            form_editar_socios.TextBox1.Text = dr("Morada")
            form_editar_socios.DateTimePicker1.Text = dr("Data_Aderencia")
            form_editar_socios.DateTimePicker2.Text = dr("Data_Nascimento")
            form_editar_socios.ComboBox4.Text = dr("Sexo")
            form_editar_socios.TextBox3.Text = dr("Telemovel")
            form_editar_socios.TextBox4.Text = dr("Email")


        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try
        form_editar_socios.PictureBox1.Image = System.Drawing.Bitmap.FromFile(form_diretorio.Label1.Text & ":\PAP\camara\" & form_editar_socios.TextBox5.Text & ".jpg")
        form_editar_socios.Show()
        form_editar_socios.MdiParent = Form1

    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        ligacao.ConnectionString = StrLigacao

        Try
            ligacao.Open()
            Query = "delete From socios Where ID_Socio = " & Label3.Text
            Comando = New MySqlCommand(Query, ligacao)
            dr = Comando.ExecuteReader

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Ocorreu um erro. Por Favor Tente novamente")
        Finally
            ligacao.Close()
        End Try

        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter("SELECT ID_Socio, Nome, NIF, Telemovel,Email FROM socios", StrLigacao)
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