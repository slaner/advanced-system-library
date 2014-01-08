Imports System.Runtime.InteropServices
Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Namespace Diagnostics

    Partial Class Thread

        ''' <summary>
        ''' 쓰레드를 종료합니다.
        ''' </summary>
        ''' <param name="ExitCode">쓰레드가 종료된 원인을 입력합니다.</param>
        Public Function Terminate(Optional ByVal ExitCode As Int32 = 0) As Boolean

            Dim hThread As IntPtr = OpenThread(ThreadAccess.Terminate, False, g_Id)
            If hThread = IntPtr.Zero Then Return False

            If TerminateThread(hThread, ExitCode) Then
                CloseHandle(hThread)
                Return True
            Else
                CloseHandle(hThread)
                Return False
            End If

        End Function

        ''' <summary>
        ''' 쓰레드의 작업을 정지합니다.
        ''' </summary>
        Public Function Suspend() As Boolean

            Dim hThread As IntPtr = OpenThread(ThreadAccess.SuspendResume, False, g_Id)
            If hThread = IntPtr.Zero Then Return False

            If SuspendThread(hThread) Then
                CloseHandle(hThread)
                Return True
            Else
                CloseHandle(hThread)
                Return False
            End If

        End Function

        ''' <summary>
        ''' 쓰레드의 작업을 재개합니다.
        ''' </summary>
        Public Function [Resume]() As Boolean

            Dim hThread As IntPtr = OpenThread(ThreadAccess.SuspendResume, False, g_Id)
            If hThread = IntPtr.Zero Then Return False

            If ResumeThread(hThread) Then
                CloseHandle(hThread)
                Return True
            Else
                CloseHandle(hThread)
                Return False
            End If

        End Function



    End Class

End Namespace