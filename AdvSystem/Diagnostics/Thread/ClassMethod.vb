Imports System.Runtime.InteropServices
Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Namespace Diagnostics

    Partial Class Thread

        ''' <summary>
        ''' 쓰레드의 정보를 포함하고 있는 ThreadEntry32 구조체를 가져옵니다.
        ''' </summary>
        ''' <param name="ThreadId">정보를 가져올 쓰레드의 식별자를 입력합니다.</param>
        ''' <param name="Te32">정보가 저장될 변수를 입력합니다.</param>
        Public Shared Function GetThreadTe32(ByVal ThreadId As UInt32, ByRef Te32 As Object) As Boolean

            Dim Snapshot As IntPtr = CreateToolhelp32Snapshot(SnapshotFlags.Thread, 0)
            If Snapshot = IntPtr.Zero Then Return False

            Dim TempTe32 As New ThreadEntry32
            TempTe32.dwSize = ThreadEntry32.Size()

            If Thread32First(Snapshot, TempTe32) = 0 Then
                CloseHandle(Snapshot)
                Return False
            End If

            Do

                If TempTe32.th32ThreadID = ThreadId Then
                    CloseHandle(Snapshot)
                    Te32 = TempTe32
                    Return True
                End If

            Loop While Thread32Next(Snapshot, TempTe32)
            CloseHandle(Snapshot)
            Return False

        End Function

        ''' <summary>
        ''' 쓰레드를 종료합니다.
        ''' </summary>
        ''' <param name="ExitCode">쓰레드가 종료된 원인을 입력합니다.</param>
        Public Shared Function Terminate(ByVal ThreadId As UInt32, Optional ByVal ExitCode As Int32 = 0) As Boolean

            Dim hThread As IntPtr = OpenThread(ThreadAccess.Terminate, False, ThreadId)
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
        Public Shared Function Suspend(ByVal ThreadId As UInt32) As Boolean

            Dim hThread As IntPtr = OpenThread(ThreadAccess.SuspendResume, False, ThreadId)
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
        Public Shared Function [Resume](ByVal ThreadId As UInt32) As Boolean

            Dim hThread As IntPtr = OpenThread(ThreadAccess.SuspendResume, False, ThreadId)
            If hThread = IntPtr.Zero Then Return False

            If ResumeThread(hThread) Then
                CloseHandle(hThread)
                Return True
            Else
                CloseHandle(hThread)
                Return False
            End If

        End Function

        ''' <summary>
        ''' 프로세스의 쓰레드 목록을 가져옵니다.
        ''' </summary>
        ''' <param name="ProcessId">쓰레드 목록을 가져올 프로세스의 식별자를 입력합니다.</param>
        Public Shared Function GetProcessThreads(ByVal ProcessId As UInt32) As Thread()

            Dim Snapshot As IntPtr = CreateToolhelp32Snapshot(SnapshotFlags.Thread, 0),
                ThreadList As New List(Of Thread)

            If Snapshot = IntPtr.Zero Then Return Nothing

            Dim TempTe32 As New ThreadEntry32
            TempTe32.dwSize = ThreadEntry32.Size()

            If Thread32First(Snapshot, TempTe32) = 0 Then
                CloseHandle(Snapshot)
                Return Nothing
            End If

            Do

                If TempTe32.th32OwnerProcessID = ProcessId Then
                    ThreadList.Add(New Thread(TempTe32.th32ThreadID))
                End If

            Loop While Thread32Next(Snapshot, TempTe32)
            CloseHandle(Snapshot)
            Return ThreadList.ToArray()

        End Function

    End Class

End Namespace