Imports System.Runtime.InteropServices
Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Namespace Diagnostics

    Partial Class Thread

        Partial Class ContextInfo

            ''' <summary>
            ''' 지정한 쓰레드의 컨텍스트 정보를 저장하는 ContextInfo 클래스의 새 개체를 초기화합니다.
            ''' </summary>
            ''' <param name="Context">컨텍스트 정보를 저장하고 있는 Context 구조체를 입력합니다.</param>
            Friend Sub New(ByVal Context As Context)

                With Context

                    g_Eax = .EAX
                    g_Ebp = .EBP
                    g_Ebx = .EBX
                    g_Ecx = .ECX
                    g_Edi = .EDI
                    g_Edx = .EDX
                    g_Eip = .EIP
                    g_Esi = .ESI
                    g_Esp = .ESP

                    g_Cs = .SegCs
                    g_Ds = .SegDs
                    g_Es = .SegEs
                    g_Ss = .SegSs
                    g_Fs = .SegFs

                    g_RegisterState = "0: " & .Dr0 & " | 1: " & .Dr1 & " | 2: " & .Dr2 & " | 3: " & .Dr3 & " | 4: -- | 5: -- | 6: " & .Dr6 & " | 7: " & .Dr7

                End With

            End Sub

            ''' <summary>
            ''' 레지스터의 상태 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property RegState() As String
                Get
                    Return g_RegisterState
                End Get
            End Property

            ''' <summary>
            ''' 코드 세그먼트의 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property Code() As UInt32
                Get
                    Return g_Cs
                End Get
            End Property

            ''' <summary>
            ''' 스택 세그먼트의 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property Stack() As UInt32
                Get
                    Return g_Ss
                End Get
            End Property

            ''' <summary>
            ''' 데이터 세그먼트의 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property Data() As UInt32
                Get
                    Return g_Ds
                End Get
            End Property

            ''' <summary>
            ''' 플래그 세그먼트의 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property Flag() As UInt32
                Get
                    Return g_Fs
                End Get
            End Property

            ''' <summary>
            ''' 추가 세그먼트의 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property Extra() As UInt32
                Get
                    Return g_Es
                End Get
            End Property

            ''' <summary>
            ''' EAX 레지스터의 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property EAX() As UInt32
                Get
                    Return g_Eax
                End Get
            End Property
            ''' <summary>
            ''' EBP 레지스터의 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property EBP() As UInt32
                Get
                    Return g_Ebp
                End Get
            End Property
            ''' <summary>
            ''' EBX 레지스터의 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property EBX() As UInt32
                Get
                    Return g_Ebx
                End Get
            End Property
            ''' <summary>
            ''' ECX 레지스터의 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property ECX() As UInt32
                Get
                    Return g_Ecx
                End Get
            End Property
            ''' <summary>
            ''' EDI 레지스터의 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property EDI() As UInt32
                Get
                    Return g_Edi
                End Get
            End Property
            ''' <summary>
            ''' EDX 레지스터의 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property EDX() As UInt32
                Get
                    Return g_Edx
                End Get
            End Property
            ''' <summary>
            ''' EIP 레지스터의 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property EIP() As UInt32
                Get
                    Return g_Eip
                End Get
            End Property
            ''' <summary>
            ''' ESI 레지스터의 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property ESI() As UInt32
                Get
                    Return g_Esi
                End Get
            End Property
            ''' <summary>
            ''' ESP 레지스터의 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property ESP() As UInt32
                Get
                    Return g_Esp
                End Get
            End Property

        End Class

    End Class

End Namespace