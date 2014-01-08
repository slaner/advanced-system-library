Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Namespace Diagnostics

    Partial Class Process

        Partial Class ModuleList

            Partial Class ModuleInfo

                ''' <summary>
                ''' 지정한 프로세스의 모듈 목록을 저장하는 ModuleList 클래스의 새 개체를 초기화합니다.
                ''' </summary>
                ''' <param name="PID">모듈 목록을 가져올 프로세스의 식별자를 입력합니다.</param>
                ''' <param name="Ldr">모듈에 대한 정보를 포함하고 있는 LdrModule 구조체를 입력합니다.</param>
                ''' <remarks></remarks>
                Friend Sub New(ByVal PID As UInt32, ByVal Ldr As LdrModule)

                    Dim Name As String = Nothing,
                        Path As String = Nothing,
                        Handle As IntPtr = OpenProcess(ProcessAccess.QueryInformation Or ProcessAccess.VmRead, False, PID)

                    Call GetProcessParamString(Handle, Ldr.BaseDllName, Name)
                    Call GetProcessParamString(Handle, Ldr.FullDllName, Path)
                    CloseHandle(Handle)

                    g_DllBase = Ldr.DllBase
                    g_EntryPoint = Ldr.EntryPoint
                    g_BaseDllName = Name
                    g_FullDllName = Path
                    g_ImageSize = Ldr.SizeOfImage

                End Sub

                ''' <summary>
                ''' 모듈의 시작 주소를 가져옵니다.
                ''' </summary>
                Public ReadOnly Property BaseAddress() As IntPtr
                    Get
                        Return g_DllBase
                    End Get
                End Property

                ''' <summary>
                ''' 모듈의 진입점 주소를 가져옵니다.
                ''' </summary>
                Public ReadOnly Property EntryPoint() As IntPtr
                    Get
                        Return g_EntryPoint
                    End Get
                End Property

                ''' <summary>
                ''' 모듈 파일의 크기를 가져옵니다.
                ''' </summary>
                Public ReadOnly Property Size() As ULong
                    Get
                        Return g_ImageSize
                    End Get
                End Property

                ''' <summary>
                ''' 모듈의 이름을 가져옵니다.
                ''' </summary>
                Public ReadOnly Property Name() As String
                    Get
                        Return g_BaseDllName
                    End Get
                End Property

                ''' <summary>
                ''' 모듈의 이름을 포함한 경로를 가져옵니다.
                ''' </summary>
                Public ReadOnly Property Path() As String
                    Get
                        Return g_FullDllName
                    End Get
                End Property

            End Class

        End Class

    End Class

End Namespace