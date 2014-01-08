Imports System.Runtime.InteropServices
Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Namespace Diagnostics

    Partial Class Thread

        '==========================================================
        ' Constructor                                   생성자
        '==========================================================
        ''' <summary>
        ''' 쓰레드를 제어 및 관리하고, 정보를 저장하는 Thread 클래스의 새 개체를 초기화합니다.
        ''' </summary>
        ''' <param name="ThreadId">Thread 클래스의 새 개체를 만들 쓰레드의 식별자를 입력합니다.</param>
        Friend Sub New(ByVal ThreadId As UInt32)

            ' 쓰레드 식별자 및 소유 프로세스의 식별자 정보를 저장한다
            Dim te32 As New ThreadEntry32
            Call GetThreadTe32(ThreadId, te32)
            g_Id = te32.th32ThreadID
            g_OwnerId = te32.th32OwnerProcessID

            ' 컨텍스트 정보를 가져오기 위해 쓰레드의 핸들을 연다.
            Dim hThread As IntPtr = OpenThread(ThreadAccess.GetContext, False, g_Id),
                pContext As IntPtr = IntPtr.Zero,
                sContext As Context
            If hThread = IntPtr.Zero Then Exit Sub

            ' 컨텍스트 정보를 가져온다.
            pContext = Marshal.AllocHGlobal(ReferenceCore.Structure.Context.Size())
            If Not GetThreadContext(hThread, pContext) Then Marshal.FreeHGlobal(pContext) : CloseHandle(hThread) : Exit Sub
            sContext = Marshal.PtrToStructure(pContext, GetType(Context))

            ' 할당받은 메모리 공간을 비운다
            Marshal.FreeHGlobal(pContext)
            CloseHandle(hThread)

            ' 컨텍스트 정보를 포함하고 있는 개체를 초기화한다
            g_Context = New ContextInfo(sContext)

        End Sub




        '==========================================================
        ' Internal Function                             내부 함수
        '==========================================================



        '==========================================================
        ' Class                                         클래스
        '==========================================================
        Public Class AccessInfo

            Private g_AccessInfo() As Boolean

        End Class

        ''' <summary>
        ''' 쓰레드의 컨텍스트 정보를 저장하는 클래스입니다.
        ''' </summary>
        Public Class ContextInfo

            Private g_Eax As UInt32
            Private g_Eip As UInt32
            Private g_Ebp As UInt32
            Private g_Ebx As UInt32
            Private g_Ecx As UInt32
            Private g_Edi As UInt32
            Private g_Edx As UInt32
            Private g_Esi As UInt32
            Private g_Esp As UInt32

            Private g_Cs As UInt32
            Private g_Ss As UInt32
            Private g_Ds As UInt32
            Private g_Es As UInt32
            Private g_Fs As UInt32

            Private g_RegisterState As String

        End Class



        '==========================================================
        ' Property                                      속성
        '==========================================================
        ''' <summary>
        ''' 이 쓰레드를 소유하고 있는 프로세스의 식별자를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property OwnerId() As UInt32
            Get
                Return g_OwnerId
            End Get
        End Property

        ''' <summary>
        ''' 쓰레드의 식별자를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property Id() As UInt32
            Get
                Return g_Id
            End Get
        End Property

        ''' <summary>
        ''' 쓰레드의 접근 권한 정보를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property Access() As AccessInfo
            Get
                If g_Access Is Nothing Then g_Access = New AccessInfo(g_Id)
                Return g_Access
            End Get
        End Property
        Public ReadOnly Property Context() As ContextInfo
            Get
                Return g_Context
            End Get
        End Property

        Private g_Context As ContextInfo
        Private g_Access As AccessInfo

        ''' <summary>
        ''' 식별자를 저장하는 변수입니다.
        ''' </summary>
        Private g_Id As UInt32

        ''' <summary>
        ''' 소유자 식별자를 저장하는 변수입니다.
        ''' </summary>
        Private g_OwnerId As UInt32

    End Class

End Namespace