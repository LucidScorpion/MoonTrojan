Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Me.Hide()
        Form2.Show()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MsgBox("You are fucked now nigger!", MsgBoxStyle.Critical, "Error")
    End Sub
End Class