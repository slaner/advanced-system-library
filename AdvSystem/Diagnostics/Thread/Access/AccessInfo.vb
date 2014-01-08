Imports System.Runtime.InteropServices
Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration

Namespace Diagnostics

    Partial Class Thread

        Partial Class AccessInfo

            ''' <summary>
            ''' 지정한 쓰레드의 권한별 접근 정보를 저장하는 AccessInfo 클래스의 새 개체를 초기화합니다.
            ''' </summary>
            ''' <param name="TID">권한별 접근 정보를 가져올 쓰레드 식별자를 입력합니다.</param>
            Friend Sub New(ByVal TID As UInt32)

                ReDim g_AccessInfo(0 To 13)
                For i As Int32 = 0 To 13
                    g_AccessInfo(i) = False
                Next

                Dim Handle As IntPtr = IntPtr.Zero, Idx As Int32 = 0

                Handle = OpenThread(ThreadAccess.Terminate, False, TID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenThread(ThreadAccess.SuspendResume, False, TID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenThread(ThreadAccess.Alert, False, TID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenThread(ThreadAccess.GetContext, False, TID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenThread(ThreadAccess.SetContext, False, TID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenThread(ThreadAccess.SetInformation, False, TID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenThread(ThreadAccess.QueryInformation, False, TID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenThread(ThreadAccess.SetThreadToken, False, TID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenThread(ThreadAccess.Impersonate, False, TID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenThread(ThreadAccess.DirectImpersonation, False, TID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenThread(ThreadAccess.SetLimitedInformation, False, TID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenThread(ThreadAccess.QueryLimitedInformation, False, TID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenThread(ThreadAccess.AllAccessInXPOrLower, False, TID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

                Handle = OpenThread(ThreadAccess.AllAccessInVistaOrHigher, False, TID)
                If Handle <> IntPtr.Zero Then g_AccessInfo(Idx) = True : CloseHandle(Handle)
                Idx += 1

            End Sub

            ''' <summary>
            ''' 쓰레드를 종료할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property Terminate() As Boolean
                Get
                    Return g_AccessInfo(0)
                End Get
            End Property

            ''' <summary>
            ''' 작업을 중지하거나 재개할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property SuspendResume() As Boolean
                Get
                    Return g_AccessInfo(1)
                End Get
            End Property

            ''' <summary>
            ''' 경고할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property Alert() As Boolean
                Get
                    Return g_AccessInfo(2)
                End Get
            End Property

            ''' <summary>
            ''' 컨텍스트를 가져올 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property GetContext() As Boolean
                Get
                    Return g_AccessInfo(3)
                End Get
            End Property

            ''' <summary>
            ''' 컨텍스트를 설정할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property SetContext() As Boolean
                Get
                    Return g_AccessInfo(4)
                End Get
            End Property

            ''' <summary>
            ''' 정보를 설정할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property SetInformation() As Boolean
                Get
                    Return g_AccessInfo(5)
                End Get
            End Property

            ''' <summary>
            ''' 정보를 가져올 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property QueryInformation() As Boolean
                Get
                    Return g_AccessInfo(6)
                End Get
            End Property

            ''' <summary>
            ''' 쓰레드의 토큰을 설정할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property SetThreadToken() As Boolean
                Get
                    Return g_AccessInfo(7)
                End Get
            End Property

            ''' <summary>
            ''' 클라이언트로 가장할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property Impersonate() As Boolean
                Get
                    Return g_AccessInfo(8)
                End Get
            End Property

            ''' <summary>
            ''' 직접 클라이언트로 가장할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property DirectImpersonation() As Boolean
                Get
                    Return g_AccessInfo(9)
                End Get
            End Property

            ''' <summary>
            ''' 제한된 정보를 설정할 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property SetLimitedInformation() As Boolean
                Get
                    Return g_AccessInfo(10)
                End Get
            End Property

            ''' <summary>
            ''' 제한된 정보를 가져올 권한이 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property QueryLimitedInformation() As Boolean
                Get
                    Return g_AccessInfo(11)
                End Get
            End Property

            ''' <summary>
            ''' XP 이하의 운영체제에서 모든 권한을 가지고 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property AllAccessInXPOrLower() As Boolean
                Get
                    Return g_AccessInfo(12)
                End Get
            End Property

            ''' <summary>
            ''' 비스타 이상의 운영체제에서 모든 권한을 가지고 있는지 확인합니다.
            ''' </summary>
            Public ReadOnly Property AllAccessInVistaOrHigher() As Boolean
                Get
                    Return g_AccessInfo(13)
                End Get
            End Property

        End Class

    End Class

End Namespace