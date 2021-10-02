Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_contagem.Show()
        form_contagem.MdiParent = Me

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub FichaDeBombeiroToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        form_bombeiros.Show()
        form_bombeiros.MdiParent = Me
    End Sub

    Private Sub DistritosPortugalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DistritosPortugalToolStripMenuItem.Click
        form_mapa_portugal.Show()
        form_mapa_portugal.MdiParent = Me
    End Sub

    Private Sub MapaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MapaToolStripMenuItem.Click
        form_googlemaps.Show()
        form_googlemaps.MdiParent = Me
    End Sub

    Private Sub AdicionarBombeirosToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        form_criar_bombeiros.Show()
        form_criar_bombeiros.MdiParent = Me
    End Sub

    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click
        Me.Hide()
        form_login.Show()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        End
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        End
    End Sub

    Private Sub AaaaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AaaaToolStripMenuItem.Click
        form_bombeiros.Show()
        form_bombeiros.MdiParent = Me
    End Sub

    Private Sub DiretórioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiretórioToolStripMenuItem.Click
        form_diretorio.Show()
        form_diretorio.MdiParent = Me
    End Sub

    Private Sub ViaturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViaturasToolStripMenuItem.Click
        form_viaturas.Show()
        form_viaturas.MdiParent = Me
    End Sub

    Private Sub EquipamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EquipamentoToolStripMenuItem.Click
        form_socios.Show()
        form_socios.MdiParent = Me
    End Sub

    Private Sub SistemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SistemaToolStripMenuItem.Click

    End Sub

    Private Sub OcorrênciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OcorrênciasToolStripMenuItem.Click
        form_ocorrencias.Show()
        form_ocorrencias.MdiParent = Me
    End Sub

    Private Sub ContagensToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContagensToolStripMenuItem.Click
        form_contagem.Show()
        form_contagem.MdiParent = Me
    End Sub

    Private Sub ContasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContasToolStripMenuItem.Click
        form.Show()
        form.MdiParent = Me
    End Sub

    Private Sub AlarmersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlarmersToolStripMenuItem.Click

    End Sub

    Private Sub ExteriorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExteriorToolStripMenuItem.Click
        My.Computer.Audio.Play(form_diretorio.Label1.Text & ":\PAP\sons\sirene_exterior.wav")
    End Sub

    Private Sub InternoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InternoToolStripMenuItem.Click
        My.Computer.Audio.Play(form_diretorio.Label1.Text & ":\PAP\sons\sirene_interior.wav")
    End Sub

    Private Sub StockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockToolStripMenuItem.Click
        form_stock.Show()
        form_stock.MdiParent = Me
    End Sub
End Class
