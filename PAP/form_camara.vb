Imports AForge
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class form_camara
    Dim camera As VideoCaptureDevice
    Dim bmp As Bitmap

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox1.Image = PictureBox2.Image

    End Sub

    Private Sub form_camara_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim cameras As VideoCaptureDeviceForm = New VideoCaptureDeviceForm
        If cameras.ShowDialog() = Windows.Forms.DialogResult.OK Then
            camera = cameras.VideoDevice
            AddHandler camera.NewFrame, New NewFrameEventHandler(AddressOf captured)
            camera.Start()
        End If

    End Sub

    Private Sub captured(sender As Object, eventargs As NewFrameEventArgs)
        bmp = DirectCast(eventargs.Frame.Clone(), Bitmap)
        PictureBox2.image = DirectCast(eventargs.frame.clone(), bitmap)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        camera.Stop()
        Me.Close()
        If Label1.Text = "Editar" Then
            form_editar_bombeiro.PictureBox1.Image = PictureBox1.Image
            PictureBox1.Image.Save(form_diretorio.Label1.Text & ":\PAP\camara\" & form_editar_bombeiro.TextBox5.Text & ".jpg")
        ElseIf Label1.Text = "Criar" Then
            form_criar_bombeiros.PictureBox1.Image = PictureBox1.Image
        End If
        form_criar_bombeiros.GuardarToolStripMenuItem.Enabled = True

    End Sub
End Class