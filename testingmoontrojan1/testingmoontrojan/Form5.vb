Option Strict On
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.Reflection
Public Class Form5

    Private Structure KBDLLHOOKSTRUCT

        Public key As Keys
        Public scanCode As Integer
        Public flags As Integer
        Public time As Integer
        Public extra As IntPtr
    End Structure

    'System level functions to be used for hook and unhook keyboard input
    Private Delegate Function LowLevelKeyboardProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function SetWindowsHookEx(ByVal id As Integer, ByVal callback As LowLevelKeyboardProc, ByVal hMod As IntPtr, ByVal dwThreadId As UInteger) As IntPtr
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function UnhookWindowsHookEx(ByVal hook As IntPtr) As Boolean
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function CallNextHookEx(ByVal hook As IntPtr, ByVal nCode As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr
    End Function
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function GetModuleHandle(ByVal name As String) As IntPtr
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetAsyncKeyState(ByVal key As Keys) As Short
    End Function

    'Declaring Global objects
    Private ptrHook As IntPtr
    Private objKeyboardProcess As LowLevelKeyboardProc



    Public Sub New()

        Try
            Dim objCurrentModule As ProcessModule = Process.GetCurrentProcess().MainModule
            'Get Current Module
            objKeyboardProcess = New LowLevelKeyboardProc(AddressOf captureKey)
            'Assign callback function each time keyboard process
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0)
            'Setting Hook of Keyboard Process for current module
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        Catch ex As Exception

        End Try
    End Sub

    Private Function captureKey(ByVal nCode As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr

        Try
            If nCode >= 0 Then

            End If
            Dim objKeyInfo As KBDLLHOOKSTRUCT = DirectCast(Marshal.PtrToStructure(lp, GetType(KBDLLHOOKSTRUCT)), KBDLLHOOKSTRUCT)
            If objKeyInfo.key = Keys.RWin OrElse objKeyInfo.key = Keys.LWin Then
                ' Disabling Windows keys
                Return CType(1, IntPtr)
            End If
            If objKeyInfo.key = Keys.ControlKey OrElse objKeyInfo.key = Keys.Escape Then
                ' Disabling Ctrl + Esc keys
                Return CType(1, IntPtr)
            End If
            If objKeyInfo.key = Keys.ControlKey OrElse objKeyInfo.key = Keys.Down Then
                ' Disabling Ctrl + Esc keys
                Return CType(1, IntPtr)
            End If
            If objKeyInfo.key = Keys.Alt OrElse objKeyInfo.key = Keys.Tab Then
                ' Disabling Ctrl + Esc keys
                Return CType(1, IntPtr)
            End If
            If objKeyInfo.key = Keys.F2 Then
                ' Disabling Ctrl + Esc keys
                Return CType(1, IntPtr)
            End If
            If objKeyInfo.key = Keys.Down Then
                'Disabling Down key
                Return CType(1, IntPtr)
            End If
            If objKeyInfo.key = Keys.F1 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F3 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F4 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F5 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F6 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F7 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F8 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F9 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F10 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F11 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F12 Then
                '  
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F13 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F14 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F15 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F16 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F17 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F18 Then
                ' 
            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.F19 Then

            End If
            If objKeyInfo.key = Keys.Scroll Then

            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.LShiftKey Then

            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.RShiftKey Then

            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.RControlKey Then

            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.LControlKey Then

            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.VolumeDown Then

            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.VolumeMute Then

            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.Escape Then

            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.Delete Then

            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.RWin Then

            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.LWin Then

            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.Scroll Then

            End If
            Return CType(1, IntPtr)
            If objKeyInfo.key = Keys.Tab Then

            End If
            If objKeyInfo.key = Keys.ControlKey OrElse objKeyInfo.key = Keys.Alt Then
                ' 
                Return CType(1, IntPtr)
            End If

        Catch ex As Exception

        End Try
    End Function
End Class
