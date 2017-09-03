Option Explicit On
Option Strict On
Imports System.Windows.Forms

Partial Public Class Form4
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TaskBar.hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) 
        TaskBar.Show()
    End Sub
End Class