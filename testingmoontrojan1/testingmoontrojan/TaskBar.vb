Option Explicit On
Option Strict On
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Public NotInheritable Class TaskBar
    Private Sub New()

    End Sub
    <DllImport("user32.dll")>
    Private Shared Function GetWindowsText(ByVal hWnd As IntPtr, ByVal text As StringBuilder, ByVal count As Integer) As Integer

    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function EnumThreadWindows(ByVal threadId As Integer, ByVal pfnEnum As EnumThreadProc, ByVal lparam As Integer) As Boolean

    End Function
    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function FindWindow(ByVal lpClassName As String, ByVal WindowName As String) As System.IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function FindWindowEx(ByVal parantHandle As IntPtr, ByVal ChildAfter As IntPtr, ByVal ClassName As String, ByVal windowTitle As String) As IntPtr

    End Function
    <DllImport("user32.dll")>
    Private Shared Function FindwindowEx(ByVal parantHWnd As IntPtr, ByVal ChildAfterHWnd As IntPtr, ByVal ClassName As IntPtr, ByVal windowtext As String) As IntPtr

    End Function
    <DllImport("user32.dll")>
    Private Shared Function ShowWindow(ByVal hWnd As IntPtr, ByVal eCmdShow As Integer) As Integer

    End Function
    <DllImport("user32.dll")>
    Private Shared Function GetWindowThreadProcessId(ByVal hwnd As IntPtr, ByRef lpdwProcessId As Integer) As UInteger

    End Function

    Private Const SH_HIDE As Integer = 0
    Private Const SH_SHOW As Integer = 5

    Private Const vistaStartMenuCpation As String = "Start"
    Private Shared vistaStartMenuWnd As IntPtr = IntPtr.Zero
    Private Delegate Function EnumThreadProc(hwnd As IntPtr, lParm As IntPtr) As Boolean


    Public Shared Sub Show()
        SetVisibility(True)
    End Sub
    Public Shared Sub hide()
        SetVisibility(False)
    End Sub

    Public Shared WriteOnly Property Visible() As Boolean
        Set(ByVal value As Boolean)
            SetVisibility(value)

        End Set
    End Property

    Public Shared Property SW_SHOW As Integer

    Private Shared Sub SetVisibility(ByVal show As Boolean)
        Dim taskBarWnd As IntPtr = FindWindow("Shell_TrayWnd", Nothing)
        Dim StartWnd As IntPtr = FindWindowEx(taskBarWnd, IntPtr.Zero, "Button", "Start")
        If StartWnd = IntPtr.Zero Then
            StartWnd = FindwindowEx(IntPtr.Zero, IntPtr.Zero, CType(&HC017, IntPtr), "Start")

        End If
        If StartWnd = IntPtr.Zero Then
            StartWnd = FindWindow("Button", Nothing)
            If StartWnd = IntPtr.Zero Then
                StartWnd = GetVistaStartMenuwnd(taskBarWnd)
            End If

        End If
        ShowWindow(taskBarWnd, If(show, SW_SHOW, SH_HIDE))
        ShowWindow(StartWnd, If(show, SW_SHOW, SH_HIDE))
    End Sub
    Private Shared Function GetVistaStartMenuwnd(ByVal taskBarwnd As IntPtr) As IntPtr
        Dim procId As Integer
        GetWindowThreadProcessId(taskBarwnd, procId)
        Dim p As Process = Process.GetProcessById(procId)
        If p IsNot Nothing Then
            For Each t As ProcessThread In p.Threads
                EnumThreadWindows(t.Id, AddressOf MyEnumThreadWindowProc, CInt(IntPtr.Zero))

            Next
        End If
        Return vistaStartMenuWnd
    End Function
    Private Shared Function MyEnumThreadWindowProc(ByVal hWnd As IntPtr, ByVal lparam As IntPtr) As Boolean
        Dim buffer As New StringBuilder(256)
        If GetWindowsText(hWnd, buffer.Capacity) > 0 Then
            Console.WriteLine(buffer)
            If buffer.ToString() = vistaStartMenuCpation Then
                vistaStartMenuWnd = hWnd
                Return False
            End If
        End If

#Disable Warning BC42353 ' Function doesn't return a value on all code paths
    End Function
#Enable Warning BC42353 ' Function doesn't return a value on all code paths

    Private Shared Function GetWindowsText(hWnd As IntPtr, capacity As Integer) As Integer
        Throw New NotImplementedException()
    End Function
End Class
