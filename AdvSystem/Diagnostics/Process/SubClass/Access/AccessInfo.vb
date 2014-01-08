Imports System.Runtime.InteropServices
Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration

Namespace Diagnostics

    Partial Class Process

        Partial Class AccessInfo

            ''' <summary>
            ''' 지정한 프로세스의 권한별 접근 정보를 저장하는 AccessInfo 클래스의 새 개체를 초기화합니다.
            ''' </summary>
            ''' <param name="PID">권한별 접근 정보를 가져올 프로세스의 식별자를 입력합니다.</param>
            Friend Sub New(ByVal PID As UInt32)

                MyBase.New(PID)

                If Not MyBase.IsValid() Then Exit Sub

                ReDim g_AccessInfo(0 To 14)
                For i As Int32 = 0 To 14
                    g_AccessInfo(i) = False
                Next

                Dim Handle As IntPtr = IntPtr.Zero, Idx As Int32 = 0

                Handle = OpenProcess(ProcessAccess.Terminate, False, PID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenProcess(ProcessAccess.CreateThread, False, PID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenProcess(ProcessAccess.SetSessionId, False, PID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenProcess(ProcessAccess.VmOperation, False, PID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenProcess(ProcessAccess.VmRead, False, PID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenProcess(ProcessAccess.VmWrite, False, PID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenProcess(ProcessAccess.DuplicateHandle, False, PID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenProcess(ProcessAccess.CreateProcess, False, PID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenProcess(ProcessAccess.SetQuota, False, PID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenProcess(ProcessAccess.SetInformation, False, PID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenProcess(ProcessAccess.QueryInformation, False, PID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenProcess(ProcessAccess.SuspendResume, False, PID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenProcess(ProcessAccess.QueryLimitedInformation, False, PID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenProcess(ProcessAccess.AllAccessInXPOrLower, False, PID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenProcess(ProcessAccess.AllAccessInVistaOrHigher, False, PID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

            End Sub

#Region "속성"

            ''' <summary>
            ''' 프로세스를 종료할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property Terminate() As Boolean
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_AccessInfo(0)
                End Get
            End Property

            ''' <summary>
            ''' 쓰레드를 만들 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property CreateThread() As Boolean
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_AccessInfo(1)
                End Get
            End Property

            ''' <summary>
            ''' 세션 식별자를 설정할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property SetSessionId() As Boolean
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_AccessInfo(2)
                End Get
            End Property

            ''' <summary>
            ''' 메모리 작업을 할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property VmOperation() As Boolean
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_AccessInfo(3)
                End Get
            End Property

            ''' <summary>
            ''' 메모리를 읽을 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property VmRead() As Boolean
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_AccessInfo(4)
                End Get
            End Property

            ''' <summary>
            ''' 메모리를 쓸 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property VmWrite() As Boolean
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_AccessInfo(5)
                End Get
            End Property

            ''' <summary>
            ''' 핸들을 복제할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property DuplicateHandle() As Boolean
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_AccessInfo(6)
                End Get
            End Property

            ''' <summary>
            ''' 프로세스를 만들 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property CreateProcess() As Boolean
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_AccessInfo(7)
                End Get
            End Property

            ''' <summary>
            ''' 메모리/디스크 사용량을 제한할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property SetQuota() As Boolean
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_AccessInfo(8)
                End Get
            End Property

            ''' <summary>
            ''' 정보를 설정할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property SetInformation() As Boolean
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_AccessInfo(9)
                End Get
            End Property

            ''' <summary>
            ''' 정보를 가져올 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property QueryInformation() As Boolean
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_AccessInfo(10)
                End Get
            End Property

            ''' <summary>
            ''' 작업을 중지하거나 재개할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property SuspendResume() As Boolean
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_AccessInfo(11)
                End Get
            End Property

            ''' <summary>
            ''' 제한된 정보를 가져올 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property QueryLimitedInformation() As Boolean
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_AccessInfo(12)
                End Get
            End Property

            ''' <summary>
            ''' XP 이하의 운영체제에서 모든 권한을 가지고 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property AllAccessInXPOrLower() As Boolean
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_AccessInfo(13)
                End Get
            End Property

            ''' <summary>
            ''' 비스타 이상의 운영체제에서 모든 권한을 가지고 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property AllAccessInVistaOrHigher() As Boolean
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_AccessInfo(14)
                End Get
            End Property

#End Region
#Region "메소드"

            ''' <summary>
            ''' 프로세스의 권한별 접근 정보 목록을 갱신합니다.
            ''' </summary>
            Public Sub Update()

            End Sub

#End Region

        End Class

    End Class

End Namespace