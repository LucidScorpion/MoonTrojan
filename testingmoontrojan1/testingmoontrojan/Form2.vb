Public Class Form2
    Dim Random As New Random
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If DesktopLocation = New Point(Random.Next(1, 1000), Random.Next(1, 500)) Then
            DesktopLocation = New Point(Random.Next(1, 1000), Random.Next(1, 500))
        Else
            DesktopLocation = New Point(Random.Next(1, 1000), Random.Next(1, 500))
        End If
    End Sub
End Class