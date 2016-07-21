Imports Microsoft.Win32
Public Class frmMain
    Sub DoWinRestore()
        Try
            Dim sSource As String = FormatDirectory(lblPath.Text) & File1.SelectedItem.ToString
            Dim sTo As String = DBLastLoc
            Dim i As Long = 0
            Dim ObjFS As New BurnSoft.GlobalClasses.BSFileSystem
            ObjFS.DeleteFile(sTo)
            My.Computer.FileSystem.CopyFile(sSource, sTo, FileIO.UIOption.OnlyErrorDialogs)
            MsgBox("Restore was Successful!", MsgBoxStyle.Information, "Datbase Restore")
            Dim Obj As New BurnSoft.GlobalClasses.BSRegistry
            Obj.DefaultRegPath = RegKey
            If chkRunApp.Checked Then i = Shell(Obj.GetApplicationPath & "\" & MainAppNameEXE, vbMaximizedFocus)
            Global.System.Windows.Forms.Application.Exit()
        Catch ex As Exception
            Dim ObjFS As New BurnSoft.GlobalClasses.BSFileSystem
            Dim strform As String = "frmMain"
            Dim strProcedure As String = "DoWinRestore"
            Dim sMessage As String = strform & "." & strProcedure & "::" & Err.Number & "::" & ex.Message.ToString()
            ObjFS.LogFile(MyLogFile, sMessage)
            MsgBox("An Error has occured while attempting to restore your database." & Chr(10) & sMessage)
            Me.Cursor = Cursors.Arrow
            cmdImport.Enabled = True
        End Try
    End Sub
    Sub UpdateFileList()
        Try
            Dim Obj As New BurnSoft.GlobalClasses.BSRegistry
            Dim LastFile As String
            Obj.DefaultRegPath = RegKey
            If Len(lblPath.Text) > 0 Then
                File1.Path = FormatDirectory(lblPath.Text)

                LastFile = Obj.GetLastBackupFile
                Dim i As Long = 0
                Dim CurFile As String = ""
                For i = 0 To File1.Items.Count - 1
                    CurFile = File1.Items(i)
                    If CurFile = LastFile Then
                        File1.SetSelected(i, True)
                        Exit For
                    End If
                Next
            Else
                MsgBox("Please Select a Path!", MsgBoxStyle.Information, "Database Restore")
                Call SelectAFolder()
            End If
        Catch ex As Exception
            Dim ObjFS As New BurnSoft.GlobalClasses.BSFileSystem
            Dim strform As String = "UpdateFileList"
            Dim strProcedure As String = "Load"
            Dim sMessage As String = strform & "." & strProcedure & "::" & Err.Number & "::" & ex.Message.ToString()
            Select Case Err.Number
                Case 68
                    Call SelectAFolder()
                Case Else
                    ObjFS.LogFile(MyLogFile, sMessage)
            End Select
        End Try
    End Sub
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetINIT()
        Try
            Dim Obj As New BurnSoft.GlobalClasses.BSRegistry
            Obj.DefaultRegPath = RegKey
            chkRunApp.Text = "Run " & MainAppName & " after restore."
            chkRunApp.Checked = True
            lblPath.Text = FormatDirectory(Obj.GetLastWorkingDir)
            Call UpdateFileList()
        Catch ex As Exception
            Dim ObjFS As New BurnSoft.GlobalClasses.BSFileSystem
            Dim strform As String = "frmMain"
            Dim strProcedure As String = "Load"
            Dim sMessage As String = strform & "." & strProcedure & "::" & Err.Number & "::" & ex.Message.ToString()
            ObjFS.LogFile(MyLogFile, sMessage)
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Global.System.Windows.Forms.Application.Exit()
    End Sub
    Sub SelectAFolder()
        FolderBrowserDialog1.ShowDialog()
        If Len(FolderBrowserDialog1.SelectedPath) > 0 Then
            lblPath.Text = FormatDirectory(FolderBrowserDialog1.SelectedPath)
            cmdImport.Enabled = True
            Call UpdateFileList()
        End If
    End Sub
    Private Sub btnPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPath.Click
        Call SelectAFolder()
    End Sub

    Private Sub cmdImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImport.Click
        cmdImport.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Call DoWinRestore()
        Me.Cursor = Cursors.Arrow
        cmdImport.Enabled = True
    End Sub
End Class