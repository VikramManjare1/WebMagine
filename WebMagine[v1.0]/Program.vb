Namespace EasyWebSimple
    Friend NotInheritable Class Program
        Public Sub New()
        End Sub
        <STAThread>
        Shared Sub Main(args() As String)
            If args.Length = 0 Then
                Application.Run(New Startup())
            Else
                Application.Run(New Startup(args(0)))
            End If
        End Sub
        Private Shared currentAssemblyCore As System.Reflection.Assembly
        Private Shared ReadOnly Property CurrentAssembly() As System.Reflection.Assembly
            Get
                If currentAssemblyCore Is Nothing Then
                    currentAssemblyCore = System.Reflection.Assembly.GetExecutingAssembly()
                End If
                Return currentAssemblyCore
            End Get
        End Property
    End Class
End Namespace
