﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class form_stock
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Label1 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_stock))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FicheiroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.datagridview1 = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.datagridview1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(9, 34)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(71, 16)
        Label1.TabIndex = 52
        Label1.Text = "Pesquisa:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FicheiroToolStripMenuItem, Me.EditarToolStripMenuItem1, Me.EliminarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(848, 24)
        Me.MenuStrip1.TabIndex = 50
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FicheiroToolStripMenuItem
        '
        Me.FicheiroToolStripMenuItem.Name = "FicheiroToolStripMenuItem"
        Me.FicheiroToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.FicheiroToolStripMenuItem.Text = "Novo"
        '
        'EditarToolStripMenuItem1
        '
        Me.EditarToolStripMenuItem1.Name = "EditarToolStripMenuItem1"
        Me.EditarToolStripMenuItem1.Size = New System.Drawing.Size(58, 20)
        Me.EditarToolStripMenuItem1.Text = "Editar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'datagridview1
        '
        Me.datagridview1.AllowUserToAddRows = False
        Me.datagridview1.AllowUserToDeleteRows = False
        Me.datagridview1.AllowUserToResizeColumns = False
        Me.datagridview1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray
        Me.datagridview1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridview1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.datagridview1.BackgroundColor = System.Drawing.Color.White
        Me.datagridview1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datagridview1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.datagridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.datagridview1.DefaultCellStyle = DataGridViewCellStyle3
        Me.datagridview1.GridColor = System.Drawing.Color.DarkGray
        Me.datagridview1.Location = New System.Drawing.Point(12, 63)
        Me.datagridview1.Name = "datagridview1"
        Me.datagridview1.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datagridview1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.datagridview1.RowHeadersVisible = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkGray
        Me.datagridview1.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.datagridview1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridview1.Size = New System.Drawing.Size(827, 276)
        Me.datagridview1.TabIndex = 55
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(79, 368)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 16)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Label4"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 368)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 16)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(580, 362)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(267, 16)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Clique duas vezes para editar bombeiro"
        Me.Label2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(812, 381)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 56
        Me.PictureBox1.TabStop = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(428, 34)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 54
        Me.Button4.Text = "OK"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(86, 34)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(336, 21)
        Me.TextBox1.TabIndex = 53
        '
        'form_stock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(848, 414)
        Me.Controls.Add(Me.datagridview1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "form_stock"
        Me.Text = "Stock"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.datagridview1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FicheiroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents datagridview1 As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button4 As Button
    Friend WithEvents TextBox1 As TextBox
End Class