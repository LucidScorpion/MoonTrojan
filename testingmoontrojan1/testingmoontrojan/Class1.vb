Option Explicit On
Option Strict On
Imports System.Windows.Forms

NotInheritable Class Program
    Private Sub New()

    End Sub
    <STAThread()>
    Friend Shared Sub main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form4())
    End Sub
End Class
