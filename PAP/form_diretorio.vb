Public Class form_diretorio
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Text = TextBox1.Text
        Me.Hide()

        TextBox1.Text = StrConv(TextBox1.Text, vbProperCase)
        TextBox1.SelectionStart = TextBox1.Text.Length + 1

    End Sub
End Class