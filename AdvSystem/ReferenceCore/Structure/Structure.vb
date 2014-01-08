Imports System.Runtime.InteropServices

Namespace ReferenceCore

    Partial Class [Structure]

        ''' <summary>
        ''' 위치 값을 X, Y 값으로 저장하는 구조체입니다.
        ''' </summary>
        Public Structure Location

            ''' <summary>
            ''' 지정한 X, Y 값을 이용하여 Location 구조체의 새 개체를 초기화합니다.
            ''' </summary>
            ''' <param name="X">X 좌표 값을 입력합니다.</param>
            ''' <param name="Y">Y 좌표 값을 입력합니다.</param>
            Public Sub New(ByVal X As Int32, ByVal Y As Int32)
                __X = X
                __Y = Y
            End Sub

            Private __X As Int32
            Private __Y As Int32

            ''' <summary>
            ''' X 좌표 값을 나타냅니다.
            ''' </summary>
            Public ReadOnly Property X() As Int32
                Get
                    Return __X
                End Get
            End Property

            ''' <summary>
            ''' Y 좌표 값을 나타냅니다.
            ''' </summary>
            Public ReadOnly Property Y() As Int32
                Get
                    Return __Y
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 토큰의 특권에 대한 정보를 저장하는 구조체입니다.
        ''' </summary>
        Public Structure TokenPrivileges

            ''' <summary>
            ''' 특권의 갯수를 나타냅니다.
            ''' </summary>

            Public PrivilegeCount As Int32

            ''' <summary>
            ''' 로컬 유저 식별자를 나타냅니다.
            ''' </summary>

            Public Luid As LUID

            ''' <summary>
            ''' 권한 활성화 여부를 나타냅니다.
            ''' </summary>

            Public Attributes As Int32

            ''' <summary>
            ''' TokenPrivileges 구조체의 크기를 가져옵니다.
            ''' </summary>
            ''' <value></value>


            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(TokenPrivileges))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 로컬 유저 식별자에 대한 정보를 저장하는 구조체입니다.
        ''' </summary>

        Public Structure LUID

            ''' <summary>
            ''' 하위 4바이트를 나타냅니다.
            ''' </summary>

            Public LowPart As Int32

            ''' <summary>
            ''' 상위 4바이트를 나타냅니다.
            ''' </summary>

            Public HighPart As Int32

            ''' <summary>
            ''' LUID 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(LUID))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 로컬 유저 식별자 및 속성을 저장하는 구조체입니다.
        ''' </summary>

        Public Structure LuidAndAttributes

            ''' <summary>
            ''' 로컬 유저 식별자를 나타냅니다.
            ''' </summary>

            Public Luid As LUID

            ''' <summary>
            ''' 속성을 나타냅니다.
            ''' </summary>

            Public Attributes As Int32

            ''' <summary>
            ''' LuidAndAttributes 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(LuidAndAttributes))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 프로세스의 시작 정보를 저장하는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure StartupInfo

            ''' <summary>
            ''' StartupInfo 구조체의 크기를 저장합니다.
            ''' </summary>
            Public cb As UInt32

            ''' <summary>
            ''' 사용되지 않는 필드
            ''' </summary>
            Public Reserved As String

            ''' <summary>
            ''' -
            ''' </summary>
            Public Desktop As String

            ''' <summary>
            ''' -
            ''' </summary>
            Public Title As String

            ''' <summary>
            ''' X 좌표를 결정합니다.
            ''' </summary>
            Public X As UInt32

            ''' <summary>
            ''' Y 좌표를 결정합니다.
            ''' </summary>
            Public Y As UInt32

            ''' <summary>
            ''' 윈도우 창의 넓이를 결정합니다.
            ''' </summary>
            Public XSize As UInt32

            ''' <summary>
            ''' 윈도우 창의 높이를 결정합니다.
            ''' </summary>
            Public YSize As UInt32

            ''' <summary>
            ''' -
            ''' </summary>
            Public XCountChars As UInt32

            ''' <summary>
            ''' -
            ''' </summary>
            Public YCountChars As UInt32

            ''' <summary>
            ''' -
            ''' </summary>
            Public FillAttributes As UInt32

            ''' <summary>
            ''' -
            ''' </summary>
            Public Flags As UInt32

            ''' <summary>
            ''' 윈도우 창을 표시하는 방법을 결정합니다.
            ''' </summary>

            Public ShowWindow As UInt16

            ''' <summary>
            ''' 사용되지 않는 필드
            ''' </summary>
            Public Reserved2 As UInt16

            ''' <summary>
            ''' 사용되지 않는 필드
            ''' </summary>
            Public Reserved3 As IntPtr

            ''' <summary>
            ''' 콘솔 입력에 대한 핸들을 결정합니다.
            ''' </summary>
            Public StdInput As IntPtr

            ''' <summary>
            ''' 콘솔 출력에 대한 핸들을 결정합니다.
            ''' </summary>
            Public StdOutput As IntPtr

            ''' <summary>
            ''' 콘솔 오류에 대한 핸들을 결정합니다.
            ''' </summary>
            Public StdError As IntPtr

            ''' <summary>
            ''' StartupInfo 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(StartupInfo))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 프로세스의 정보를 저장하는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure ProcessInformation

            ''' <summary>
            ''' 프로세스의 핸들을 나타냅니다.
            ''' </summary>
            Public Process As IntPtr

            ''' <summary>
            ''' 쓰레드의 핸들을 나타냅니다.
            ''' </summary>
            Public Thread As IntPtr

            ''' <summary>
            ''' 식별자를 나타냅니다.
            ''' </summary>
            Public Id As UInt32

            ''' <summary>
            ''' 쓰레드 식별자를 나타냅니다.
            ''' </summary>
            Public ThreadId As UInt32

            ''' <summary>
            ''' ProcessInformation 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(ProcessInformation))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 프로세스 생성 옵션에 관한 정보를 저장하는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure ProcessStartOption

            ''' <summary>
            ''' 프로세스의 시작 폴더를 설정합니다.
            ''' </summary>
            Public Directory As String

            ''' <summary>
            ''' 실행할 프로세스의 파일 경로를 설정합니다.
            ''' </summary>
            Public ApplicationPath As String

            ''' <summary>
            ''' 명령줄 인수를 설정합니다.
            ''' </summary>
            Public CommandLine As String

            ''' <summary>
            ''' 생성 옵션을 설정합니다.
            ''' </summary>
            Public Flags As Int32

            ''' <summary>
            ''' StartupInfo 구조체의 포인터 식을 설정합니다.
            ''' </summary>
            Public StartupInfo As IntPtr

            ''' <summary>
            ''' ProcessStartOption 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(ProcessStartOption))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 파일의 정보를 저장하는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure SHFileInfo
            Public hIcon As IntPtr
            Public iIcon As IntPtr
            Public Attributes As UInt32
            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Public DisplayName As String
            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public TypeName As String
            ''' <summary>
            ''' SHFileInfo 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(SHFileInfo))
                End Get
            End Property
        End Structure

        ''' <summary>
        ''' 시스템 정보를 저장하는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure SystemInfo

            ''' <summary>
            ''' 프로세서의 아키텍쳐를 가져옵니다.
            ''' </summary>
            Public wProcessorArchitecture As UInt16

            ''' <summary>
            ''' 사용되지 않는 필드입니다.
            ''' </summary>
            Public wReserved As UInt16

            ''' <summary>
            ''' 커밋된 페이지의 크기를 가져옵니다.
            ''' </summary>
            Public dwPageSize As UInt32

            ''' <summary>
            ''' 프로그램이 접근할 수 있는 가장 낮은 메모리 주소를 가져옵니다.
            ''' </summary>
            Public lpMinimumApplicationAddress As IntPtr

            ''' <summary>
            ''' 프로그램이 접근할 수 있는 가장 높은 메모리 주소를 가져옵니다.
            ''' </summary>
            Public lpMaximumApplicationAddress As IntPtr

            ''' <summary>
            ''' CPU 선호도를 가져옵니다.
            ''' </summary>
            Public dwActiveProcessorMask As IntPtr

            ''' <summary>
            ''' 프로세서의 수를 가져옵니다.
            ''' </summary>
            Public dwNumberOfProcessors As UInt32

            ''' <summary>
            ''' 프로세서의 종류을 가져옵니다.
            ''' </summary>
            Public dwProcessorType As UInt32

            ''' <summary>
            ''' 가상 메모리가 할당될 수 있는 시작 주소를 가져옵니다.
            ''' </summary>
            Public dwAllocationGranularity As UInt32

            ''' <summary>
            ''' 사용되지 않는 필드입니다.
            ''' </summary>
            Public wProcessorLevel As UInt16

            ''' <summary>
            ''' 프로세서의 Revision 정보를 가져옵니다.
            ''' </summary>
            Public wProcessorRevision As UInt16

            ''' <summary>
            ''' SystemInfo 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(SystemInfo))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 성능 정보를 저장하는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure PerformanceInformation

            ''' <summary>
            ''' PerformanceInformation 구조체의 크기를 저장합니다.
            ''' </summary>
            Public cb As UInt32

            ''' <summary>
            ''' 
            ''' </summary>
            Public CommitTotal As UIntPtr

            ''' <summary>
            ''' 
            ''' </summary>
            Public CommitLimit As UIntPtr

            ''' <summary>
            ''' 
            ''' </summary>
            Public CommitPeak As UIntPtr

            ''' <summary>
            ''' 
            ''' </summary>
            Public PhysicalTotal As UIntPtr

            ''' <summary>
            ''' 
            ''' </summary>
            Public PhysicalAvailable As UIntPtr

            ''' <summary>
            ''' 
            ''' </summary>
            Public SystemCache As UIntPtr

            ''' <summary>
            ''' 
            ''' </summary>
            Public KernelTotal As UIntPtr

            ''' <summary>
            ''' 
            ''' </summary>
            Public KernelPaged As UIntPtr

            ''' <summary>
            ''' 
            ''' </summary>
            Public KernelNonpaged As UIntPtr

            ''' <summary>
            ''' 
            ''' </summary>
            Public PageSize As UIntPtr

            ''' <summary>
            ''' 
            ''' </summary>
            Public HandleCount As UInt32

            ''' <summary>
            ''' 실행 중인 프로세스의 수를 가져옵니다.
            ''' </summary>
            Public ProcessCount As UInt32

            ''' <summary>
            ''' 
            ''' </summary>
            Public ThreadCount As UInt32

            ''' <summary>
            ''' PerformanceInformation 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(PerformanceInformation))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 토큰에 접근하기 위한 유저의 식별자를 나타내는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure TokenUser

            ''' <summary>
            ''' 유저의 식별자가 저장된 SidAndAttributes 구조체를 가져옵니다.
            ''' </summary>
            Public User As SidAndAttributes

        End Structure

        ''' <summary>
        ''' 보안 식별자(SID)와 SID의 특성을 저장하는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure SidAndAttributes

            ''' <summary>
            ''' Sid 구조체가 저장된 메모리 주소를 가져옵니다.
            ''' </summary>
            Public Sid As IntPtr

            ''' <summary>
            ''' 보안 식별자의 특성을 가져옵니다.
            ''' </summary>
            Public Attributes As UInt32

        End Structure

        ''' <summary>
        ''' 보안 식별자의 정보를 저장하는 구조채입니다.
        ''' </summary>

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure Sid

            Public Revision As Byte
            Public SubAuthorityCount As Byte
            Public IdentifierAuthority As SidIdentifierAuthority
            Public SubAuthority As UInt32

        End Structure

        ''' <summary>
        ''' 보안 식별자의 권한 정보를 저장하는 구조체입니다.
        ''' </summary>

        Public Structure SidIdentifierAuthority
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public Value() As Byte
        End Structure

        ''' <summary>
        ''' 시간 정보를 저장하는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure FileTime

            ''' <summary>
            ''' 시간의 상위 비트를 가져옵니다.
            ''' </summary>
            Public dwHighDateTime As UInteger

            ''' <summary>
            ''' 시간의 하위 비트를 가져옵니다.
            ''' </summary>
            Public dwLowDateTime As UInteger

            ''' <summary>
            ''' 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(FileTime))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 프로세스의 메모리 정보를 저장하는 구조체입니다.
        ''' </summary>

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure ProcessMemoryCountersEx

            ''' <summary>
            ''' ProcessMemoryCountersEx 구조체의 크기를 저장하는 변수입니다.
            ''' </summary>

            Public cb As UInt32

            ''' <summary>
            ''' 페이지 폴트의 갯수를 가져옵니다.
            ''' </summary>

            Public PageFaultCount As UInt32

            ''' <summary>
            ''' 워킹셋의 최대 크기를 가져옵니다.
            ''' </summary>
            Public PeakWorkingSetSize As UIntPtr

            ''' <summary>
            ''' 현재 워킹셋의 크기를 가져옵니다.
            ''' </summary>
            Public WorkingSetSize As UIntPtr

            ''' <summary>
            ''' 페이징된 풀의 최대 사용량을 가져옵니다.
            ''' </summary>
            Public QuotaPeakPagedPoolUsage As UIntPtr

            ''' <summary>
            ''' 현재 페이징된 풀의 사용량을 가져옵니다.
            ''' </summary>
            Public QuotaPagedPoolUsage As UIntPtr

            ''' <summary>
            ''' 페이징되지 않은 풀의 최대 사용량을 가져옵니다.
            ''' </summary>
            Public QuotaPeakNonPagedPoolUsage As UIntPtr

            ''' <summary>
            ''' 현재 페이징되지 않은 풀의 사용량을 가져옵니다.
            ''' </summary>
            Public QuotaNonPagedPoolUsage As UIntPtr

            ''' <summary>
            ''' 페이지 파일의 사용량을 가져옵니다.
            ''' </summary>
            Public PagefileUsage As UIntPtr

            ''' <summary>
            ''' 페이지 파일의 최대 사용량을 가져옵니다.
            ''' </summary>
            Public PeakPagefileUsage As UIntPtr

            ''' <summary>
            ''' 개인 메모리 사용량을 가져옵니다. PagefileUsage 와 같음
            ''' </summary>
            Public PrivateUsage As UIntPtr

            ''' <summary>
            ''' 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(ProcessMemoryCountersEx))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 프로세스의 입출력(I/O) 정보를 저장하는 구조체입니다.
        ''' </summary>

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure IoCounters

            ''' <summary>
            ''' 읽기 작업이 수행된 양을 가져옵니다.
            ''' </summary>
            Public ReadOperationCount As UInt64

            ''' <summary>
            ''' 쓰기 작업이 수행된 양을 가져옵니다.
            ''' </summary>
            Public WriteOperationCount As UInt64

            ''' <summary>
            ''' 읽기 및 쓰기 작업 외의 I/O 작업이 수행된 양을 가져옵니다.
            ''' </summary>
            Public OtherOperationCount As UInt64

            ''' <summary>
            ''' 읽은 데이터의 양을 가져옵니다.
            ''' </summary>
            Public ReadTransferCount As UInt64

            ''' <summary>
            ''' 쓴 데이터의 양을 가져옵니다.
            ''' </summary>
            Public WriteTransferCount As UInt64

            ''' <summary>
            ''' 읽기 및 쓰기 작업 외에 전송된 데이터의 양을 가져옵니다.
            ''' </summary>

            Public OtherTransferCount As UInt64

            ''' <summary>
            ''' 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(IoCounters))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 프로세스의 정보를 저장하는 구조체입니다.
        ''' </summary>

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure ProcessEntry32

            ''' <summary>
            ''' ProcessEntry32 구조체의 크기를 저장하는 변수입니다.
            ''' </summary>
            Public dwSize As Int32

            ''' <summary>
            ''' 사용량을 가져옵니다.
            ''' </summary>
            Public cntUsage As Int32

            ''' <summary>
            ''' 프로세스 식별자(PID)를 가져옵니다.
            ''' </summary>
            Public th32ProcessID As Int32

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            Public th32DefaultHeapID As IntPtr

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            Public th32ModuleID As Int32

            ''' <summary>
            ''' 쓰레드 개수를 가져옵니다.
            ''' </summary>
            Public cntThreads As Int32

            ''' <summary>
            ''' 자식 프로세스인 경우, 부모 프로세스의 식별자(PID)를 가져옵니다.
            ''' </summary>
            Public th32ParentProcessID As Int32

            ''' <summary>
            ''' 기본 우선 순위를 가져옵니다.
            ''' </summary>
            Public pcPriClassBase As Int32

            ''' <summary>
            ''' 프로세스의 옵션을 가져옵니다.
            ''' </summary>
            Public dwFlags As Int32

            ''' <summary>
            ''' 프로세스의 이미지 이름을 가져옵니다.
            ''' </summary>
            <VBFixedString(260), MarshalAs(UnmanagedType.ByValTStr, sizeConst:=260)> _
            Public szExeFile As String

            ''' <summary>
            ''' 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(ProcessEntry32))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 프로세스의 기본 정보를 저장하는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure ProcessBasicInformation

            ''' <summary>
            ''' 종료 상태를 가져옵니다.
            ''' </summary>
            Public ExitStatus As IntPtr

            ''' <summary>
            ''' PEB 시작 주소를 가져옵니다.
            ''' </summary>
            Public PebBaseAddress As IntPtr

            ''' <summary>
            ''' CPU 선호도 마스크를 가져옵니다.
            ''' </summary>
            Public AffinityMask As UIntPtr

            ''' <summary>
            ''' 기본 우선 순위를 가져옵니다.
            ''' </summary>
            Public BasePriority As UIntPtr

            ''' <summary>
            ''' 고유 식별자(PID)를 가져옵니다.
            ''' </summary>
            Public UniqueProcessId As UIntPtr

            ''' <summary>
            ''' 고유 식별자로부터의 상속 여부를 가져옵니다.
            ''' </summary>
            Public InheritedFromUniqueProcessId As UIntPtr

            ''' <summary>
            ''' 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(ProcessBasicInformation))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 프로세스에 대한 상세 정보들을 저장하는 구조체입니다.
        ''' </summary>

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure ProcessEnvironmentBlock

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> _
            Public Reserved1() As Byte

            ''' <summary>
            ''' 프로세스에 디버거가 설치되었는지 여부를 가져옵니다.
            ''' </summary>
            Public BeingDebugged As Byte

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> _
            Public Reserved2() As Byte

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> _
            Public Reserved3() As IntPtr

            ''' <summary>
            ''' PEB_LDR_DATA 구조체의 주소를 가져옵니다.
            ''' </summary>
            Public Ldr As IntPtr

            ''' <summary>
            ''' RTL_USER_PROCESS_PARAMETERS 구조체의 주소를 가져옵니다.
            ''' </summary>
            Public ProcessParameters As IntPtr

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=104)> _
            Public Reserved4() As Byte

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=52)> _
            Public Reserved5() As IntPtr

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            Public PostProcessInitRoutine As IntPtr

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=128)> _
            Public Reserved6() As Byte

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> _
            Public Reserved7() As IntPtr

            ''' <summary>
            ''' 세션 식별자를 가져옵니다.
            ''' </summary>
            Public SessionId As UIntPtr

            ''' <summary>
            ''' 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(ProcessEnvironmentBlock))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 프로세스의 모듈 데이터를 저장하는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure PebLdrData

            ''' <summary>
            ''' 구조체의 길이를 가져옵니다.
            ''' </summary>
            Public Length As UInt32

            ''' <summary>
            ''' 초기화 여부를 가져옵니다.
            ''' </summary>
            Public Initialized As Boolean

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            Public SsHandle As IntPtr

            ''' <summary>
            ''' 모듈을 불러와진 순서대로 저장해놓은 ListEntry 구조체를 가져옵니다.
            ''' </summary>
            Public InLoadOrderModuleList As ListEntry

            ''' <summary>
            ''' 모듈을 메모리 위치 순서대로 저장해놓은 ListEntry 구조체를 가져옵니다.
            ''' </summary>
            Public InMemoryOrderModuleList As ListEntry

            ''' <summary>
            ''' 모듈을 초기화된 순서대로 저장해놓은 ListEntry 구조체를 가져옵니다.
            ''' </summary>
            Public InInitializationOrderModuleList As ListEntry

            ''' <summary>
            ''' 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(PebLdrData))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 모듈에 대한 데이터를 저장하는 구조체입니다.
        ''' </summary>

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure LdrModule

            ''' <summary>
            ''' 모듈을 불러와진 순서대로 저장해놓은 ListEntry 구조체를 가져옵니다.
            ''' </summary>
            Public InLoadOrderModuleList As ListEntry

            ''' <summary>
            ''' 모듈을 메모리 위치 순서대로 저장해놓은 ListEntry 구조체를 가져옵니다.
            ''' </summary>
            Public InMemoryOrderModuleList As ListEntry

            ''' <summary>
            ''' 모듈을 초기화된 순서대로 저장해놓은 ListEntry 구조체를 가져옵니다.
            ''' </summary>
            Public InInitializationOrderModuleList As ListEntry

            ''' <summary>
            ''' 모듈의 시작 주소를 가져옵니다.
            ''' </summary>
            Public DllBase As IntPtr

            ''' <summary>
            ''' 모듈의 시작점(EntryPoint) 주소를 가져옵니다.
            ''' </summary>
            Public EntryPoint As IntPtr

            ''' <summary>
            ''' 모듈 파일의 크기를 가져옵니다.
            ''' </summary>
            Public SizeOfImage As UInt32

            ''' <summary>
            ''' 모듈의 전체 경로를 가져옵니다.
            ''' </summary>
            Public FullDllName As UnicodeString

            ''' <summary>
            ''' 모듈의 이름을 가져옵니다.
            ''' </summary>
            Public BaseDllName As UnicodeString

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            Public Flags As UInt32

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            Public LoadCount As UInt16

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            Public TlsIndex As UInt16

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            Public HashTableEntry As ListEntry

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            Public TimeDateStamp As UInt32

            ''' <summary>
            ''' 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(LdrModule))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 부호있는 8바이트 정수를 표현할 때 사용하는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Explicit, Size:=8)> _
        Public Structure LargeInteger

            ''' <summary>
            ''' 8바이트 정수를 가져옵니다.
            ''' </summary>
            <FieldOffset(0)> Public QuadPart As Int64

            ''' <summary>
            ''' 정수의 하위 4바이트를 가져옵니다.
            ''' </summary>
            <FieldOffset(0)> Public LowPart As UInt32

            ''' <summary>
            ''' 정수의 상위 4바이트를 가져옵니다.
            ''' </summary>
            <FieldOffset(4)> Public HighPart As Int32

            ''' <summary>
            ''' 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(LargeInteger))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 부호없는 8바이트 정수를 표현할 때 사용하는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Explicit, Size:=8)> _
        Public Structure ULargeInteger

            ''' <summary>
            ''' 8바이트 정수를 가져옵니다.
            ''' </summary>
            <FieldOffset(0)> Public QuadPart As UInt64

            ''' <summary>
            ''' 정수의 하위 4바이트를 가져옵니다.
            ''' </summary>
            <FieldOffset(0)> Public LowPart As UInt32

            ''' <summary>
            ''' 정수의 상위 4바이트를 가져옵니다.
            ''' </summary>
            <FieldOffset(4)> Public HighPart As Int32

            ''' <summary>
            ''' 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(ULargeInteger))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 유니코드 문자열을 표현할 때 사용하는 구조체입니다.
        ''' </summary>

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure UnicodeString

            ''' <summary>
            ''' 문자열의 유효 길이를 가져옵니다.
            ''' </summary>
            Public Length As UInt16

            ''' <summary>
            ''' 문자열의 최대 길이를 가져옵니다.
            ''' </summary>
            Public MaximumLength As UInt16

            ''' <summary>
            ''' 저장된 유니코드 문자열을 가져옵니다.
            ''' </summary>
            Public Buffer As IntPtr

            ''' <summary>
            ''' 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(UnicodeString))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' Linked List를 구현하는 구조체입니다.
        ''' </summary>

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure ListEntry

            ''' <summary>
            ''' 다음 ListEntry 구조체의 주소값을 가져옵니다.
            ''' </summary>
            Public FLink As IntPtr

            ''' <summary>
            ''' 이전 ListEntry 구조체의 주소값을 가져옵니다.
            ''' </summary>
            Public BLink As IntPtr

            ''' <summary>
            ''' 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(ListEntry))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 모듈의 정보를 저장하는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure ModuleEntry32

            ''' <summary>
            ''' ModuleEntry32 구조체의 크기를 저장하는 변수입니다.
            ''' </summary>
            Public dwSize As Int32

            ''' <summary>
            ''' 사용되지 않는 멤버입니다. (이 멤버는 항상 1임)
            ''' </summary>
            Public th32ModuleID As Int32

            ''' <summary>
            ''' 모듈을 불러온 프로세스의 식별자를 가져옵니다.
            ''' </summary>
            Public th32ProcessID As Int32

            ''' <summary>
            ''' 모듈의 로드 카운트를 가져옵니다.
            ''' </summary>
            Public GlblcntUsage As Int32

            ''' <summary>
            ''' GlblcntUsage 멤버와 같음
            ''' </summary>
            Public ProccntUsage As Int32

            ''' <summary>
            ''' 소유자 프로세스에서의 모듈의 시작 주소를 가져옵니다.
            ''' </summary>
            Public modBaseAddr As IntPtr

            ''' <summary>
            ''' 모듈의 크기를 가져옵니다.
            ''' </summary>
            Public modBaseSize As Int32

            ''' <summary>
            ''' 소유자 프로세스에서의 모듈의 핸들을 가져옵니다.
            ''' </summary>

            Public hModule As IntPtr

            ''' <summary>
            ''' 모듈의 이름을 가져옵니다.
            ''' </summary>
            <VBFixedString(256), MarshalAs(UnmanagedType.ByValTStr, sizeConst:=256)> _
            Public szModule As String

            ''' <summary>
            ''' 모듈의 경로를 가져옵니다.
            ''' </summary>
            <VBFixedString(260), MarshalAs(UnmanagedType.ByValTStr, sizeConst:=260)> _
            Public szExePath As String

            ''' <summary>
            ''' 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(ModuleEntry32))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 쓰레드의 정보를 저장하는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure ThreadEntry32

            ''' <summary>
            ''' ThreadEntry32 구조체의 크기를 저장하는 변수입니다.
            ''' </summary>
            Public dwSize As Int32

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            Public cntUsage As Int32

            ''' <summary>
            ''' 쓰레드의 식별자를 가져옵니다.
            ''' </summary>

            Public th32ThreadID As Int32

            ''' <summary>
            ''' 쓰레드가 만들어진 프로세스의 식별자를 가져옵니다.
            ''' </summary>
            Public th32OwnerProcessID As Int32

            ''' <summary>
            ''' 커널에서 쓰레드에 할당한 우선 순위를 가져옵니다.
            ''' </summary>
            Public tpBasePri As Int32

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            Public tpDeltaPri As Int32

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            Public dwFlags As Int32

            ''' <summary>
            ''' 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(ThreadEntry32))
                End Get
            End Property

        End Structure

        ''' <summary>
        ''' 프로세스의 경로에 대한 정보를 저장하는 구조체입니다.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure RtlUserProcessParameters

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=16)> Public Reserved1() As Byte

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public Reserved2() As IntPtr

            ''' <summary>
            ''' 프로세스의 이미지 파일이 있는 경로를 가져옵니다.
            ''' </summary>
            Public ImagePathName As UnicodeString

            ''' <summary>
            ''' 프로세스의 명령줄 정보를 가져옵니다.
            ''' </summary>
            Public CommandLine As UnicodeString

            ''' <summary>
            ''' 구조체의 크기를 가져옵니다.
            ''' </summary>
            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(RtlUserProcessParameters))
                End Get
            End Property

        End Structure

        Public Structure Context

            Public ContextFlags As UInt32

            Public Dr0 As UInt32
            Public Dr1 As UInt32
            Public Dr2 As UInt32
            Public Dr3 As UInt32
            Public Dr6 As UInt32
            Public Dr7 As UInt32

            Public FloatSave As FloatingSaveArea

            Public SegGs As UInt32
            Public SegFs As UInt32
            Public SegEs As UInt32
            Public SegDs As UInt32

            Public EDI As UInt32
            Public ESI As UInt32
            Public EBX As UInt32
            Public EDX As UInt32
            Public ECX As UInt32
            Public EAX As UInt32
            Public EBP As UInt32
            Public EIP As UInt32

            Public SegCs As UInt32
            Public EFlags As UInt32
            Public ESP As UInt32
            Public SegSs As UInt32

            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=512)> _
            Public ExtendedRegisters() As Byte

            Public Shared ReadOnly Property Size() As Int32
                Get
                    Return Marshal.SizeOf(GetType(Context))
                End Get
            End Property

        End Structure

        Public Structure FloatingSaveArea

            Public ControlWord As UInt32
            Public StatusWord As UInt32
            Public TagWord As UInt32

            Public ErrorOffset As UInt32
            Public ErrorSelector As UInt32

            Public DataOffset As UInt32
            Public DataSelector As UInt32

            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=80)> _
            Public RegisterArea() As Byte

            Public Cr0NpxState As UInt32

        End Structure

    End Class

End Namespace