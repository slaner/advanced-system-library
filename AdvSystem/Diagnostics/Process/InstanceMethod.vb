Imports System.Runtime.InteropServices
Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Namespace Diagnostics

    Partial Class Process

        ''' <summary>
        ''' 프로세스를 종료합니다.
        ''' </summary>
        ''' <param name="ExitCode">종료 코드를 입력합니다. (기본값은 0입니다)</param>
        Public Function Terminate(Optional ByVal ExitCode As Int32 = 0) As Boolean

            Dim HProcess As IntPtr = OpenProcess(ProcessAccess.Terminate, False, g_Id)
            If HProcess = IntPtr.Zero Then Return False

            If TerminateProcess(HProcess, ExitCode) <> 0 Then
                CloseHandle(HProcess)
                Return True
            Else
                CloseHandle(HProcess)
                Return False
            End If

        End Function

        ''' <summary>
        ''' 프로세스의 정보를 갱신합니다.
        ''' </summary>
        Public Sub Update()
            If IsProcessRunning(g_Id) Then
                initProcess(g_Id)
            Else
                Throw New Exceptions.Super("프로세스가 유효하지 않습니다.")
            End If
        End Sub

        ''' <summary>
        ''' 프로세스의 작업을 정지합니다.
        ''' </summary>
        Public Function Suspend() As Boolean
            If Not IsProcessRunning(g_Id) Then Return False
            Return CBool(DebugActiveProcess(g_Id))
        End Function

        ''' <summary>
        ''' 프로세스의 작업을 재개합니다.
        ''' </summary>
        Public Function [Resume]() As Boolean
            If Not IsProcessRunning(g_Id) Then Return False
            Return CBool(DebugActiveProcessStop(g_Id))
        End Function

        ''' <summary>
        ''' 프로세스의 우선 순위를 설정합니다.
        ''' </summary>
        ''' <param name="PriorityClass">변경할 우선 순위를 입력합니다.</param>
        Public Function SetPriority(ByVal PriorityClass As ProcessPriorityClass) As Boolean

            If Not IsProcessRunning(g_Id) Then Return False
            Return g_Priority.ChangePriority(PriorityClass)

        End Function

    End Class

End Namespace