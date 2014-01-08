Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Namespace Diagnostics

    Partial Class Process

        '==========================================================
        ' Constructor                                   생성자
        '==========================================================
        ''' <summary>
        ''' 프로세스를 제어 및 관리하고, 정보를 저장하는 Process 클래스의 새 개체를 초기화합니다.
        ''' </summary>
        ''' <param name="ProcessId">Process 클래스의 새 개체를 만들 프로세스의 식별자를 입력합니다.</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal ProcessId As UInt32)

            initProcess(ProcessId)

        End Sub



        '==========================================================
        ' Internal Function                             내부 함수
        '==========================================================
        ''' <summary>
        ''' 개체를 초기화합니다.
        ''' </summary>
        ''' <param name="ProcessId">프로세스 식별자를 입력합니다.</param>
        Private Sub initProcess(ByVal ProcessId As UInt32)

            If Not IsProcessRunning(ProcessId) Then Exit Sub

            g_Id = ProcessId
            g_ImageName = GetProcessName(ProcessId)
            g_DomainName = GetProcessDomainUsername(ProcessId)

            g_Access = New AccessInfo(ProcessId)
            'Debug.Print("AccessInfo        Ok")

            g_Affinity = New AffinityInfo(ProcessId)
            'Debug.Print("AffinityInfo      Ok")

            g_MemoryUsage = New MemoryUsageInfo(ProcessId)
            'Debug.Print("MemoryUsageInfo   Ok")

            g_Module = New ModuleList(ProcessId)
            'Debug.Print("ModuleList        Ok")

            g_StringInfo = New StringInfo(ProcessId)
            'Debug.Print("StringInfo        Ok")

            g_Privilege = New PrivilegeList(ProcessId)
            'Debug.Print("PrivilegeList     Ok")

            g_Priority = New PriorityInfo(ProcessId)
            'Debug.Print("PriorityInfo      Ok")

            g_Icon = New IconInfo(ProcessId)
            'Debug.Print("IconInfo          Ok")

            'Debug.Print("Path              {0}", g_StringInfo.Path)

            If g_StringInfo.Path <> Nothing Then g_File = FileVersionInfo.GetVersionInfo(g_StringInfo.Path)

            Dim tempPe32 As New ProcessEntry32
            If GetProcessPe32(ProcessId, tempPe32) Then g_MotherId = tempPe32.th32ParentProcessID

        End Sub



        '==========================================================
        ' Property                                      속성
        '==========================================================
        ''' <summary>
        ''' 프로세스의 이름을 가져옵니다.
        ''' </summary>
        Public ReadOnly Property Name() As String
            Get
                Return g_ImageName
            End Get
        End Property

        ''' <summary>
        ''' 프로세스의 식별자를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property Id() As UInt32
            Get
                Return g_Id
            End Get
        End Property

        ''' <summary>
        ''' 프로세스의 도메인 및 사용자 이름을 가져옵니다.
        ''' </summary>
        Public ReadOnly Property DomainUsername() As String
            Get
                Return g_DomainName
            End Get
        End Property

        ''' <summary>
        ''' 프로세스의 우선 순위 정보를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property Priority() As PriorityInfo
            Get
                Return g_Priority
            End Get
        End Property

        ''' <summary>
        ''' 프로세스의 CPU 선호도 정보를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property Affinity() As AffinityInfo
            Get
                Return g_Affinity
            End Get
        End Property

        ''' <summary>
        ''' 프로세스의 메모리 정보를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property MemoryUsage() As MemoryUsageInfo
            Get
                Return g_MemoryUsage
            End Get
        End Property

        ''' <summary>
        ''' 프로세스의 특권 목록을 가져옵니다.
        ''' </summary>
        Public ReadOnly Property Privilege() As PrivilegeList
            Get
                Return g_Privilege
            End Get
        End Property

        ''' <summary>
        ''' 프로세스에 연결된 모듈 목록을 가져옵니다.
        ''' </summary>
        Public ReadOnly Property [Module]() As ModuleList
            Get
                Return g_Module
            End Get
        End Property

        ''' <summary>
        ''' 프로세스의 파일 정보를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property File() As FileVersionInfo
            Get
                Return g_File
            End Get
        End Property

        ''' <summary>
        ''' 프로세스가 디버그 상태에 있는지 여부를 나타내는 값을 가져옵니다.
        ''' </summary>
        Public ReadOnly Property IsDebugged() As DebuggedState
            Get
                Dim PEB As New ProcessEnvironmentBlock,
                    hProcess As IntPtr = OpenProcess(ProcessAccess.QueryInformation Or ProcessAccess.VmRead, False, g_Id)

                If hProcess = IntPtr.Zero Then Return DebuggedState.Unknown
                If Not GetProcessPEB(hProcess, PEB) Then CloseHandle(hProcess) : Return DebuggedState.Unknown
                CloseHandle(hProcess)
                Return PEB.BeingDebugged
            End Get
        End Property

        ''' <summary>
        ''' 프로세스의 부모 프로세스 정보를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property MotherProcess() As Process
            Get
                If g_MotherId = 0 Then Return Nothing
                If IsProcessRunning(g_MotherId) Then Return New Process(g_MotherId)
                Return Nothing
            End Get
        End Property

        ''' <summary>
        ''' 프로세스의 플랫폼 정보를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property Platform() As ArchitectureInfo
            Get
                If g_Id < 8 Then Return Computer.GetSystemArchitecture()
                Dim Process As IntPtr = OpenProcessInfo(g_Id)
                If Process = IntPtr.Zero Then Return ArchitectureInfo.Unknown

                Dim Result As Boolean = False
                If IsWow64Process(Process, Result) = 0 Then Return Computer.GetSystemArchitecture()

                CloseHandle(Process)
                Return -Result

            End Get
        End Property

        ''' <summary>
        ''' 프로세스의 파일 경로를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property Path() As String
            Get
                Return g_StringInfo.Path
            End Get
        End Property

        ''' <summary>
        ''' 프로세스의 명령줄 인수를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property CommandLine() As String
            Get
                Return g_StringInfo.CommandLine
            End Get
        End Property

        ''' <summary>
        ''' 프로세스의 아이콘 정보를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property Icon() As IconInfo
            Get
                Return g_Icon
            End Get
        End Property

        ''' <summary>
        ''' 권한 정보를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property Access() As AccessInfo
            Get
                Return g_Access
            End Get
        End Property

        Public ReadOnly Property Threads() As Thread()
            Get
                Return Thread.GetProcessThreads(Id)
            End Get
        End Property

        ''' <summary>
        ''' 식별자를 저장하는 변수입니다.
        ''' </summary>
        Private g_Id As UInt32

        ''' <summary>
        ''' 이미지 파일 이름을 저장하는 변수입니다.
        ''' </summary>
        Private g_ImageName As String

        ''' <summary>
        ''' 도메인 이름을 저장하는 변수입니다.
        ''' </summary>
        Private g_DomainName As String

        ''' <summary>
        ''' 부모 프로세스의 식별자를 저장하는 변수입니다.
        ''' </summary>
        Private g_MotherId As UInt32

        ''' <summary>
        ''' 프로세스의 접근 권한에 대한 정보를 저장하는 변수입니다.
        ''' </summary>
        Private g_Access As AccessInfo

        ''' <summary>
        ''' CPU 선호도 정보를 저장하는 변수입니다.
        ''' </summary>
        Private g_Affinity As AffinityInfo

        ''' <summary>
        ''' 모듈 목록의 정보를 저장하는 변수입니다.
        ''' </summary>
        Private g_Module As ModuleList

        ''' <summary>
        ''' 우선 순위를 저장하는 변수입니다.
        ''' </summary>
        Private g_Priority As PriorityInfo

        ''' <summary>
        ''' 메모리 정보를 저장하는 변수입니다.
        ''' </summary>
        Private g_MemoryUsage As MemoryUsageInfo

        ''' <summary>
        ''' 아이콘 정보를 저장하는 변수입니다.
        ''' </summary>
        Private g_Icon As IconInfo

        ''' <summary>
        ''' 특권 목록을 저장하는 변수입니다.
        ''' </summary>
        Private g_Privilege As PrivilegeList

        ''' <summary>
        ''' 파일 정보를 저장하는 변수입니다.
        ''' </summary>
        Private g_File As FileVersionInfo

        ''' <summary>
        ''' 문자열 정보를 저장하는 변수입니다.
        ''' </summary>
        Private g_StringInfo As StringInfo

        ''' <summary>
        ''' 특정 프로세스에 대한 권한별 접근 정보를 저장합니다.
        ''' </summary>
        Public Class AccessInfo
            Inherits InformationClassBase

            ''' <summary>
            ''' 특정 권한에 대한 접근이 가능한지를 저장하는 변수입니다.
            ''' </summary>
            Private g_AccessInfo() As Boolean

        End Class

        ''' <summary>
        ''' 특정 프로세스에 대한 CPU 선호도 정보를 저장합니다.
        ''' </summary>
        Public Class AffinityInfo
            Inherits InformationClassBase

            ''' <summary>
            ''' CPU 선호도를 저장하는 변수입니다.
            ''' </summary>
            Private CPUAffinityMask As Int32

        End Class

        ''' <summary>
        ''' 프로세스의 아이콘 정보를 저장합니다.
        ''' </summary>
        Public Class IconInfo
            Inherits InformationClassBase

            ''' <summary>
            ''' 프로세스의 실행 파일 위치를 저장하는 변수입니다.
            ''' </summary>
            Private g_ProcessImagePath As String

        End Class

        ''' <summary>
        ''' 프로세스에 로드된 모듈 목록을 저장합니다.
        ''' </summary>
        Public Class ModuleList
            Inherits InformationClassBase

            ''' <summary>
            ''' 모듈 목록을 리스트로 저장하는 변수입니다.
            ''' </summary>
            Private g_ModuleInfoList As List(Of ModuleInfo)

            ''' <summary>
            ''' 모듈에 대한 정보를 포함하는 클래스입니다.
            ''' </summary>
            Public Class ModuleInfo

                ''' <summary>
                ''' 모듈의 기본 주소를 저장하는 변수입니다.
                ''' </summary>
                Private g_DllBase As IntPtr

                ''' <summary>
                ''' 모듈의 진입점(Entry point)을 저장하는 변수입니다.
                ''' </summary>
                Private g_EntryPoint As IntPtr

                ''' <summary>
                ''' 모듈의 전체 경로를 저장하는 변수입니다.
                ''' </summary>
                Private g_FullDllName As String

                ''' <summary>
                ''' 모듈의 파일 이름을 저장하는 변수입니다.
                ''' </summary>
                Private g_BaseDllName As String

                ''' <summary>
                ''' 모듈의 파일 크기를 저장하는 변수입니다.
                ''' </summary>
                Private g_ImageSize As UInt64

            End Class

        End Class

        ''' <summary>
        ''' 프로세스의 메모리 정보를 저장합니다.
        ''' </summary>
        Public Class MemoryUsageInfo
            Inherits InformationClassBase

            ''' <summary>
            ''' 페이지 폴트의 갯수를 저장하는 변수입니다.
            ''' </summary>
            Private g_PageFaultCount As UInt32

            ''' <summary>
            ''' 워킹셋 크기를 저장하는 변수입니다.
            ''' </summary>
            Private g_WorkingSetSize As UIntPtr

            ''' <summary>
            ''' 페이지 파일의 사용량을 저장하는 변수입니다.
            ''' </summary>
            Private g_PageFileUsage As UIntPtr

            ''' <summary>
            ''' 개인 작업 메모리 사용량을 저장하는 변수입니다.
            ''' </summary>
            Private g_PrivateUsage As UIntPtr

            ''' <summary>
            ''' 페이징되지 않은 풀의 사용량을 저장하는 변수입니다.
            ''' </summary>
            Private g_CurrentNonPagedPoolUsage As UIntPtr

            ''' <summary>
            ''' 페이징된 풀의 사용량을 저장하는 변수입니다.
            ''' </summary>
            Private g_CurrentPagedPoolUsage As UIntPtr

        End Class

        ''' <summary>
        ''' 프로세스의 우선 순위 정보를 저장합니다.
        ''' </summary>
        Public Class PriorityInfo
            Inherits InformationClassBase

            ''' <summary>
            ''' 우선 순위를 저장하는 변수입니다.
            ''' </summary>
            Private g_PriorityClass As ProcessPriorityClass

        End Class

        ''' <summary>
        ''' 프로세스의 이미지 파일 경로 및 명령줄 인수에 대한 정보를 저장합니다.
        ''' </summary>
        Public Class StringInfo
            Inherits InformationClassBase

            ''' <summary>
            ''' 이미지 파일의 경로를 저장하는 변수입니다.
            ''' </summary>
            Private g_Path As String

            ''' <summary>
            ''' 명령줄 인수를 저장하는 변수입니다.
            ''' </summary>
            Private g_CommandLine As String

        End Class

        ''' <summary>
        ''' 프로세스의 특권 목록을 저장합니다.
        ''' </summary>
        Public Class PrivilegeList
            Inherits InformationClassBase

            Private g_PrivilegeList As List(Of PrivilegeInfo)

            ''' <summary>
            ''' 특권의 정보를 포함하는 클래스입니다.
            ''' </summary>
            Public Class PrivilegeInfo

                ''' <summary>
                ''' 식별자를 저장하는 변수입니다.
                ''' </summary>
                Private tempPid As UInt32

                ''' <summary>
                ''' 특권의 이름을 저장하는 변수입니다.
                ''' </summary>
                Private g_Name As String

                ''' <summary>
                ''' 특권의 상태를 저장하는 변수입니다.
                ''' </summary>
                Private g_State As PrivilegeState

                ''' <summary>
                ''' 특권의 번호를 저장하는 변수입니다.
                ''' </summary>
                Private g_Index As Int32

            End Class

        End Class

    End Class

End Namespace