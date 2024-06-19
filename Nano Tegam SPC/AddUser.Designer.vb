<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddUser))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Reenter_txt = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Addpass_txt = New System.Windows.Forms.TextBox()
        Me.Adduser_txt = New System.Windows.Forms.TextBox()
        Me.Adduser_btn = New System.Windows.Forms.Button()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(75, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 16)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Re-enter password"
        '
        'Reenter_txt
        '
        Me.Reenter_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reenter_txt.Location = New System.Drawing.Point(73, 134)
        Me.Reenter_txt.Name = "Reenter_txt"
        Me.Reenter_txt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.Reenter_txt.Size = New System.Drawing.Size(290, 31)
        Me.Reenter_txt.TabIndex = 25
        Me.Reenter_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(40, 87)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 24
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(40, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'Addpass_txt
        '
        Me.Addpass_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Addpass_txt.Location = New System.Drawing.Point(73, 87)
        Me.Addpass_txt.Name = "Addpass_txt"
        Me.Addpass_txt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.Addpass_txt.Size = New System.Drawing.Size(290, 31)
        Me.Addpass_txt.TabIndex = 22
        Me.Addpass_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Adduser_txt
        '
        Me.Adduser_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Adduser_txt.Location = New System.Drawing.Point(73, 31)
        Me.Adduser_txt.Name = "Adduser_txt"
        Me.Adduser_txt.Size = New System.Drawing.Size(290, 31)
        Me.Adduser_txt.TabIndex = 21
        Me.Adduser_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Adduser_btn
        '
        Me.Adduser_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Adduser_btn.FlatAppearance.BorderSize = 0
        Me.Adduser_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Adduser_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Adduser_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Adduser_btn.Location = New System.Drawing.Point(243, 180)
        Me.Adduser_btn.Name = "Adduser_btn"
        Me.Adduser_btn.Size = New System.Drawing.Size(120, 34)
        Me.Adduser_btn.TabIndex = 20
        Me.Adduser_btn.Text = "Add User"
        Me.Adduser_btn.UseVisualStyleBackColor = True
        '
        'AddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SeaGreen
        Me.ClientSize = New System.Drawing.Size(402, 244)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Reenter_txt)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Addpass_txt)
        Me.Controls.Add(Me.Adduser_txt)
        Me.Controls.Add(Me.Adduser_btn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AddUser"
        Me.Text = "AddUser"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents Reenter_txt As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Addpass_txt As TextBox
    Friend WithEvents Adduser_txt As TextBox
    Friend WithEvents Adduser_btn As Button
End Class
