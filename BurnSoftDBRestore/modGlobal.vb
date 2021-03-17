Imports System.Configuration
Imports DBRestore.BurnSoft.GlobalClasses
''' <summary>
''' Class modGlobal.
''' </summary>
Module ModGlobal
    ''' <summary>
    ''' The application name
    ''' </summary>
    Public AppName As String
    ''' <summary>
    ''' The main application name
    ''' </summary>
    Public MainAppName As String
    ''' <summary>
    ''' The main application name executable
    ''' </summary>
    Public MainAppNameExe As String
    ''' <summary>
    ''' The database name
    ''' </summary>
    Public DbName As String
    ''' <summary>
    ''' The reg key
    ''' </summary>
    Public RegKey As String
    ''' <summary>
    ''' The check process
    ''' </summary>
    Public CheckProcess As Boolean
    ''' <summary>
    ''' My log file
    ''' </summary>
    Public MyLogFile As String
    ''' <summary>
    ''' The application abv
    ''' </summary>
    Public AppAbv As String
    ''' <summary>
    ''' The database last loc
    ''' </summary>
    Public DbLastLoc As String
    ''' <summary>
    ''' The do automatic backup
    ''' </summary>
    Public DoAutoBackup As Boolean
    ''' <summary>
    ''' Initialze the global vars with the settings form teh config file and if the switch for autp back up has been passed
    ''' </summary>
    Public Sub SetInit()
        AppName = ConfigurationManager.AppSettings("AppName")
        MainAppName = ConfigurationManager.AppSettings("MainAppName")
        MainAppNameExe = ConfigurationManager.AppSettings("MainAppNameEXE")
        DbName = ConfigurationManager.AppSettings("DBName")
        RegKey = ConfigurationManager.AppSettings("RegKey")
        CheckProcess = CBool(ConfigurationManager.AppSettings("CheckProcess"))
        MyLogFile = ConfigurationManager.AppSettings("LogFilename")
        AppAbv = ConfigurationManager.AppSettings("AppABV")
        DoAutoBackup = GetCommand("auto", "Bool")
        Dim obj As New BsRegistry
        obj.DefaultRegPath = RegKey
        DbLastLoc = obj.GetDbPath
    End Sub
    ''' <summary>
    ''' sort through the command switch to find the setting that you are looking for to see if it was
    ''' passed or not.
    ''' </summary>
    ''' <param name="strLookFor"></param>
    ''' <param name="strType"></param>
    ''' <param name="didExist"></param>
    ''' <returns></returns>
    Public Function GetCommand(ByVal strLookFor As String, ByVal strType As String, Optional ByRef didExist As Boolean = False) As String
        Dim sAns As String 
        didExist = False
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
        Dim i As Integer
        Dim intCount As Integer = cmdLine.Length
        Dim strValue As String
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
                    didExist = True
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
        sAns = AppAbv & "_" & Format(Now(), "yyyymmd") & "_" & Format(Now(), "hmmss") & ".bak"
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
            Dim lastChar As String = Mid(sValue, iCount)
            If lastChar <> "\" Then
                sAns = sValue & "\"
            Else
                sAns = sValue
            End If
        End If
        Return sAns
    End Function
End Module
