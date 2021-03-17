Imports System.Configuration
Imports DBRestore.BurnSoft.GlobalClasses

Module modGlobal
    Public AppName As String
    Public MainAppName As String
    Public MainAppNameEXE As String
    Public DBName As String
    Public RegKey As String
    Public CheckProcess As Boolean
    Public MyLogFile As String
    Public AppPath As String
    Public AppABV As String
    Public DBLastLoc As String
    Public DoAutoBackup As Boolean
    ''' <summary>
    ''' Initialze the global vars with the settings form teh config file and if the switch for autp back up has been passed
    ''' </summary>
    Public Sub SetINIT()
        AppName = ConfigurationManager.AppSettings("AppName")
        MainAppName = ConfigurationManager.AppSettings("MainAppName")
        MainAppNameEXE = ConfigurationManager.AppSettings("MainAppNameEXE")
        DBName = ConfigurationManager.AppSettings("DBName")
        RegKey = ConfigurationManager.AppSettings("RegKey")
        CheckProcess = CBool(ConfigurationManager.AppSettings("CheckProcess"))
        MyLogFile = ConfigurationManager.AppSettings("LogFilename")
        AppABV = ConfigurationManager.AppSettings("AppABV")
        DoAutoBackup = GetCommand("auto", "Bool")
        Dim Obj As New BsRegistry
        Obj.DefaultRegPath = RegKey
        DBLastLoc = Obj.GetDbPath
    End Sub
    ''' <summary>
    ''' sort through the command switch to find the setting that you are looking for to see if it was
    ''' passed or not.
    ''' </summary>
    ''' <param name="strLookFor"></param>
    ''' <param name="strType"></param>
    ''' <param name="DidExist"></param>
    ''' <returns></returns>
    Public Function GetCommand(ByVal strLookFor As String, ByVal strType As String, Optional ByRef DidExist As Boolean = False) As String
        Dim sAns As String = ""
        DidExist = False
        Select Case LCase(strType)
            Case "string"
                sAns = ""
            Case "bool"
                sAns = "false"
            Case "int"
                sAns = 0
            Case Else
                sAns = ""
        End Select
        Dim cmdLine() As String = Environment.GetCommandLineArgs
        Dim i As Integer = 0
        Dim intCount As Integer = cmdLine.Length
        Dim strValue As String = ""
        If intCount > 1 Then
            For i = 1 To intCount - 1
                strValue = cmdLine(i)
                strValue = Replace(strValue, "/", "")
                strValue = Replace(strValue, "--", "")
                Dim strSplit() As String = Split(strValue, "=")
                Dim intLBound As Integer = LBound(strSplit)
                Dim intUBound As Integer = UBound(strSplit)
                If LCase(strSplit(intLBound)) = LCase(strLookFor) Then
                    If intUBound <> 0 Then
                        sAns = strSplit(intUBound)
                    Else
                        sAns = "true"
                    End If
                    DidExist = True
                    Exit For
                End If
            Next
        End If
        Return LCase(sAns)
    End Function
    ''' <summary>
    ''' Generate a new name for the backup file
    ''' </summary>
    ''' <returns></returns>
    Public Function NewFileName() As String
        Dim sAns As String
        sAns = AppABV & "_" & Format(Now(), "yyyymmd") & "_" & Format(Now(), "hmmss") & ".bak"
        Return sAns
    End Function
    ''' <summary>
    ''' format the directory that was passed to see if it needs to add a back slash or not
    ''' </summary>
    ''' <param name="sValue"></param>
    ''' <returns></returns>
    Public Function FormatDirectory(ByVal sValue As String) As String
        Dim sAns As String = sValue
        If Len(sValue) <> 0 Then
            Dim iCount As Integer = Len(sValue)
            Dim LastChar As String = Mid(sValue, iCount)
            If LastChar <> "\" Then
                sAns = sValue & "\"
            Else
                sAns = sValue
            End If
        End If
        Return sAns
    End Function
End Module
