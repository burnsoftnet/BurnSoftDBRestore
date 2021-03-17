Imports DBRestore.BurnSoft.GlobalClasses
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Win32
Public Class frmMain
    ''' <summary>
    ''' Copy the file form the source drive to the application data drive
    ''' </summary>
    Sub DoWinRestore()
        Try
            Dim sSource As String = FormatDirectory(lblPath.Text) & File1.SelectedItem.ToString
            Dim sTo As String = DBLastLoc
            Dim i As Long = 0
            Dim ObjFS As New BsFileSystem
            ObjFS.DeleteFile(sTo)
            My.Computer.FileSystem.CopyFile(sSource, sTo, UIOption.OnlyErrorDialogs)
            MsgBox("Restore was Successful!", MsgBoxStyle.Information, "Datbase Restore")
            Dim Obj As New BsRegistry
            Obj.DefaultRegPath = RegKey
            If chkRunApp.Checked Then i = Shell(Obj.GetApplicationPath & "\" & MainAppNameEXE, vbMaximizedFocus)
            Application.Exit()
        Catch ex As Exception
            Dim ObjFS As New BsFileSystem
            Dim strform As String = "frmMain"
            Dim strProcedure As String = "DoWinRestore"
            Dim sMessage As String = strform & "." & strProcedure & "::" & Err.Number & "::" & ex.Message.ToString()
            ObjFS.LogFile(MyLogFile, sMessage)
            MsgBox("An Error has occured while attempting to restore your database." & Chr(10) & sMessage)
            Me.Cursor = Cursors.Arrow
            cmdImport.Enabled = True
        End Try
    End Sub
    ''' <summary>
    ''' Update the list by refreshing the the directory list
    ''' </summary>
    Sub UpdateFileList()
        Try
            Dim Obj As New BsRegistry
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
            Dim ObjFS As New BsFileSystem
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
    ''' <summary>
    ''' when the form first loads, get settings and do init
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Call SetINIT()
        Try
            Dim Obj As New BsRegistry
            Obj.DefaultRegPath = RegKey
            chkRunApp.Text = "Run " & MainAppName & " after restore."
            chkRunApp.Checked = True
            lblPath.Text = FormatDirectory(Obj.GetLastWorkingDir)
            Call UpdateFileList()
        Catch ex As Exception
            Dim ObjFS As New BsFileSystem
            Dim strform As String = "frmMain"
            Dim strProcedure As String = "Load"
            Dim sMessage As String = strform & "." & strProcedure & "::" & Err.Number & "::" & ex.Message.ToString()
            ObjFS.LogFile(MyLogFile, sMessage)
        End Try
    End Sub
    ''' <summary>
    ''' when the cancel button is clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub
    ''' <summary>
    ''' action to perform when the select path is clicked, or when there is not path to read on startup
    ''' to ask the user which path to read from
    ''' </summary>
    Sub SelectAFolder()
        FolderBrowserDialog1.ShowDialog()
        If Len(FolderBrowserDialog1.SelectedPath) > 0 Then
            lblPath.Text = FormatDirectory(FolderBrowserDialog1.SelectedPath)
            cmdImport.Enabled = True
            Call UpdateFileList()
        End If
    End Sub
    ''' <summary>
    ''' when the select path button is clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnPath_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPath.Click
        Call SelectAFolder()
    End Sub
    ''' <summary>
    ''' when the import/ restore button is clicked, start backup
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdImport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdImport.Click
        cmdImport.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Call DoWinRestore()
        Me.Cursor = Cursors.Arrow
        cmdImport.Enabled = True
    End Sub
End Class