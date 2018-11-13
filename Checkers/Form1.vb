Public Class Form1
    Shared args As String
    Private Sub mnuClose_Click(sender As Object, e As EventArgs) Handles mnuClose.Click
        End
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub mnuStart_Click(sender As Object, e As EventArgs) Handles mnuStart.Click
        RunJar("Driver.jar")
    End Sub

    Shared Sub RunJar(command As String, Optional arguments As String = "")
        args = args.Concat(arguments)
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = " -jar " + command + " " + args
        'javaw instead of java so that a console window does not pop up
        pi.FileName = "javaw.exe"
        p.StartInfo = pi
        p.Start()
    End Sub

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles MyBase.Click

    End Sub

    Shared sngRow1 As Single = -1
    Shared sngRow2 As Single = -1
    Shared sngCol1 As Single = -1
    Shared sngCol2 As Single = -1

    Private Sub pb1_Click(sender As Object, e As EventArgs) Handles pb1.Click
        If sngRow1 = -1 Then
            sngRow1 = 0
            sngCol1 = 0
        Else
            sngRow2 = 0
            sngCol2 = 0
            If Confirm() = True Then
                args = String.Concat(args, " ", sngRow1, " ", sngCol1, " ", sngRow2, " ", sngCol2)
                RunJar("Driver.jar", args)
            End If
        End If
    End Sub

    Shared Function Confirm() As Boolean
        Dim sngConfirm As Boolean = MsgBox("Do you want to move these pieces?", vbOKCancel)
        Return sngConfirm
    End Function
End Class
