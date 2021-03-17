<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnPath = New System.Windows.Forms.Button()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkRunApp = New System.Windows.Forms.CheckBox()
        Me.cmdImport = New System.Windows.Forms.Button()
        Me.File1 = New Microsoft.VisualBasic.Compatibility.VB6.FileListBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(266, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select the Drive/Directory were the Backup file(s) is at."
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(297, 206)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(79, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "E&xit"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnPath
        '
        Me.btnPath.Location = New System.Drawing.Point(297, 33)
        Me.btnPath.Name = "btnPath"
        Me.btnPath.Size = New System.Drawing.Size(75, 23)
        Me.btnPath.TabIndex = 6
        Me.btnPath.Text = "Select Path"
        Me.btnPath.UseVisualStyleBackColor = True
        '
        'lblPath
        '
        Me.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPath.Location = New System.Drawing.Point(12, 37)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(279, 17)
        Me.lblPath.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Select one of the following Files:"
        '
        'chkRunApp
        '
        Me.chkRunApp.AutoSize = True
        Me.chkRunApp.Location = New System.Drawing.Point(179, 64)
        Me.chkRunApp.Name = "chkRunApp"
        Me.chkRunApp.Size = New System.Drawing.Size(15, 14)
        Me.chkRunApp.TabIndex = 10
        Me.chkRunApp.UseVisualStyleBackColor = True
        '
        'cmdImport
        '
        Me.cmdImport.Location = New System.Drawing.Point(16, 206)
        Me.cmdImport.Name = "cmdImport"
        Me.cmdImport.Size = New System.Drawing.Size(75, 23)
        Me.cmdImport.TabIndex = 11
        Me.cmdImport.Text = "&Import"
        Me.cmdImport.UseVisualStyleBackColor = True
        '
        'File1
        '
        Me.File1.FormattingEnabled = True
        Me.File1.Location = New System.Drawing.Point(16, 92)
        Me.File1.Name = "File1"
        Me.File1.Pattern = "*.bak"
        Me.File1.Size = New System.Drawing.Size(360, 108)
        Me.File1.TabIndex = 12
        '
        'frmMain
        '
        Me.AcceptButton = Me.cmdImport
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(388, 244)
        Me.Controls.Add(Me.File1)
        Me.Controls.Add(Me.cmdImport)
        Me.Controls.Add(Me.chkRunApp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnPath)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BurnSoft DB Restore"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnPath As System.Windows.Forms.Button
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkRunApp As System.Windows.Forms.CheckBox
    Friend WithEvents cmdImport As System.Windows.Forms.Button
    Friend WithEvents File1 As Microsoft.VisualBasic.Compatibility.VB6.FileListBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class
