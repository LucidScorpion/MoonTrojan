Public Class Form6
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

    Private Sub Moon2_closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub

    Private Sub Moon2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
End Class