Namespace ReferenceCore

    Partial Class Enumeration

        Public Const STANDARD_RIGHTS_REQUIRED = &HF0000
        Public Const SYNCHRONIZE = &H100000
        Public Const WH_KEYBOARD_LL = &HD
        Public Const WH_MOUSE_LL = &HE
        Public Const SM_SWAPBUTTON = 23

        ''' <summary>
        ''' 특권의 이름을 열거합니다.
        ''' </summary>
        Public Class Privileges

            Public Const SeChangeNotifyPrivilege = "SeChangeNotifyPrivilege"
            Public Const SeCreateGlobalPrivilege = "SeCreateGlobalPrivilege"
            Public Const SeCreatePagefilePrivilege = "SeCreatePagefilePrivilege"
            Public Const SeCreatePermanentPrivilege = "SeCreatePermanentPrivilege"
            Public Const SeCreateSymbolicLinkPrivilege = "SeCreateSymbolicLinkPrivilege"
            Public Const SeCreateTokenPrivilege = "SeCreateTokenPrivilege"
            Public Const SeDebugPrivilege = "SeDebugPrivilege"
            Public Const SeEnableDelegationPrivilege = "SeEnableDelegationPrivilege"
            Public Const SeImpersonatePrivilege = "SeImpersonatePrivilege"
            Public Const SeIncreaseBasePriorityPrivilege = "SeIncreaseBasePriorityPrivilege"
            Public Const SeIncreaseQuotaPrivilege = "SeIncreaseQuotaPrivilege"
            Public Const SeIncreaseWorkingSetPrivilege = "SeIncreaseWorkingSetPrivilege"
            Public Const SeLoadDriverPrivilege = "SeLoadDriverPrivilege"
            Public Const SeLockMemoryPrivilege = "SeLockMemoryPrivilege"
            Public Const SeMachineAccountPrivilege = "SeMachineAccountPrivilege"
            Public Const SeManageVolumePrivilege = "SeManageVolumePrivilege"
            Public Const SeProfileSingleProcessPrivilege = "SeProfileSingleProcessPrivilege"
            Public Const SeRelabelPrivilege = "SeRelabelPrivilege"
            Public Const SeRemoteShutdownPrivilege = "SeRemoteShutdownPrivilege"
            Public Const SeRestorePrivilege = "SeRestorePrivilege"
            Public Const SeSecurityPrivilege = "SeSecurityPrivilege"
            Public Const SeShutdownPrivilege = "SeShutdownPrivilege"
            Public Const SeSyncAgentPrivilege = "SeSyncAgentPrivilege"
            Public Const SeSystemEnvironmentPrivilege = "SeSystemEnvironmentPrivilege"
            Public Const SeSystemProfilePrivilege = "SeSystemProfilePrivilege"
            Public Const SeSystemTimePrivilege = "SeSystemtimePrivilege"
            Public Const SeTakeOwnershipPrivilege = "SeTakeOwnershipPrivilege"
            Public Const SeTcbPrivilege = "SeTcbPrivilege"
            Public Const SeTimeZonePrivilege = "SeTimeZonePrivilege"
            Public Const SeTrustedCredManAccessPrivilege = "SeTrustedCredManAccessPrivilege"
            Public Const SeUndockPrivilege = "SeUndockPrivilege"
            Public Const SeUnsolicitedInputPrivilege = "SeUnsolicitedInputPrivilege"
            Private Const PrivilegesCount = 35

            Public ReadOnly Property Count() As Int32
                Get
                    Return PrivilegesCount
                End Get
            End Property

        End Class

        ''' <summary>
        ''' 특권 상태를 열거합니다.
        ''' </summary>
        Public Enum PrivilegeState

            ''' <summary>
            ''' 비활성화
            ''' </summary>

            Disabled = 0

            ''' <summary>
            ''' 기본값
            ''' </summary>

            [Default] = 1

            ''' <summary>
            ''' 활성화
            ''' </summary>

            Enabled = 2

            ''' <summary>
            ''' 기본값 (활성화)
            ''' </summary>
            EnabledByDefault = 3

            ''' <summary>
            ''' 제거됨
            ''' </summary>

            Removed = 4

            ''' <summary>
            ''' 접근을 위해 사용됨
            ''' </summary>

            UsedForAccess = &H80000000

        End Enum

        ''' <summary>
        ''' 프로세스의 개체를 가져올 때 사용하는 값들을 열거합니다.
        ''' </summary>
        Public Enum ObjectFlags

            ''' <summary>
            ''' GDI 개체를 가져옵니다.
            ''' </summary>
            Gdi = 0

            ''' <summary>
            ''' USER 개체를 가져옵니다.
            ''' </summary>
            User
        End Enum

        ''' <summary>
        ''' 시스템의 구성 정보를 열거합니다.
        ''' </summary>
        Public Enum ArchitectureInfo

            ''' <summary>
            ''' 알 수 없는 시스템 구성입니다.
            ''' </summary>
            Unknown = -1

            ''' <summary>
            ''' 64비트로 구성된 시스템입니다.
            ''' </summary>
            x64

            ''' <summary>
            ''' 32비트로 구성된 시스템입니다.
            ''' </summary>
            x86

        End Enum

        ''' <summary>
        ''' 힙 할당 옵션을 열거합니다.
        ''' </summary>
        Public Enum HeapFlags

            NoSerialize = 1
            Growable = 2
            GenerateExceptions = 4
            ZeroMemory = 8
            ReAllocInPlaceOnly = 16
            TailCheckingEnabled = 32
            FreeCheckingEnabled = 64
            DisableCoalesceOnFree = 128
            CreateAlign16 = &H10000
            CreateEnableTracing = &H20000
            CreateEnableExecute = &H40000
            MaximumTag = &HFFF
            PseudoTag = &H8000
            TagShift = 18

        End Enum

        ''' <summary>
        ''' 어떤 정보를 포함하고 있는 스냅샷을 생성할 것인지를 결정하는 값들을 열거합니다.
        ''' </summary>
        Public Enum SnapshotFlags

            ''' <summary>
            ''' 힙 리스트 정보를 포함하고 있는 스냅샷을 생성합니다.
            ''' </summary>
            HeapList = 1

            ''' <summary>
            ''' 프로세스 정보를 포함하고 있는 스냅샷을 생성합니다.
            ''' </summary>
            Process = 2

            ''' <summary>
            ''' 쓰레드 정보를 포함하고 있는 스냅샷을 생성합니다.
            ''' </summary>
            Thread = 4

            ''' <summary>
            ''' 모듈 정보를 포함하고 있는 스냅샷을 생성합니다.
            ''' </summary>
            [Module] = 8

            ''' <summary>
            ''' 32비트 모듈 정보를 포함하고 있는 스냅샷을 생성합니다. (64비트 운영체제에서만 사용)
            ''' </summary>
            Module32 = 16

            ''' <summary>
            ''' 모든 정보를 포함하고 있는 스냅샷을 생성합니다.
            ''' </summary>
            All = 31

        End Enum

        ''' <summary>
        ''' 프로세스의 우선 순위 값을 열거합니다.
        ''' </summary>
        Public Enum ProcessPriorityClass

            ''' <summary>
            ''' 알 수 없는 우선 순위
            ''' </summary>
            Unknown = -1

            ''' <summary>
            ''' 보통 우선 순위를 나타냅니다.
            ''' </summary>
            Normal = 32

            ''' <summary>
            ''' 낮은 우선 순위를 나타냅니다.
            ''' </summary>
            Idle = 64

            ''' <summary>
            ''' 높은 우선 순위를 나타냅니다.
            ''' </summary>
            High = 128

            ''' <summary>
            ''' 실시간 우선 순위를 나타냅니다.
            ''' </summary>

            Realtime = 256

            ''' <summary>
            ''' 약간 낮은 우선 순위를 나타냅니다. 이 우선 순위는 Normal 보다 낮고, Idle 보다 높습니다.
            ''' </summary>
            BelowNormal = 16384

            ''' <summary>
            ''' 약간 높은 우선 순위를 나타냅니다. 이 우선 순위는 Normal 보다 높고, High 보다 낮습니다.
            ''' </summary>
            AboveNormal = 32768

        End Enum

        ''' <summary>
        ''' CPU에 대한 선호도 비트 마스크를 열거합니다.
        ''' </summary>
        Public Enum AffinityMask

            ''' <summary>
            ''' 첫번째 CPU를 나타냅니다.
            ''' </summary>
            CPU0 = 1

            ''' <summary>
            ''' 두번째 CPU를 나타냅니다.
            ''' </summary>
            CPU1 = 2

            ''' <summary>
            ''' 세번째 CPU를 나타냅니다.
            ''' </summary>
            CPU2 = 4

            ''' <summary>
            ''' 네번째 CPU를 나타냅니다.
            ''' </summary>
            CPU3 = 8

            ''' <summary>
            ''' 다섯번째 CPU를 나타냅니다.
            ''' </summary>
            CPU4 = 16

            ''' <summary>
            ''' 여섯번째 CPU를 나타냅니다.
            ''' </summary>
            CPU5 = 32

            ''' <summary>
            ''' 일곱번째 CPU를 나타냅니다.
            ''' </summary>
            CPU6 = 64

            ''' <summary>
            ''' 여덟번째 CPU를 나타냅니다.
            ''' </summary>
            CPU7 = 128

            ''' <summary>
            ''' 아홉번째 CPU를 나타냅니다.
            ''' </summary>
            CPU8 = 256

            ''' <summary>
            ''' 열번째 CPU를 나타냅니다.
            ''' </summary>
            CPU9 = 512

            ''' <summary>
            ''' 열한번째 CPU를 나타냅니다.
            ''' </summary>
            CPU10 = 1024

            ''' <summary>
            ''' 열두번째 CPU를 나타냅니다.
            ''' </summary>
            CPU11 = 2048

            ''' <summary>
            ''' 열세번째 CPU를 나타냅니다.
            ''' </summary>
            CPU12 = 4096

            ''' <summary>
            ''' 열네번째 CPU를 나타냅니다.
            ''' </summary>
            CPU13 = 8192

            ''' <summary>
            ''' 열다섯번째 CPU를 나타냅니다.
            ''' </summary>
            CPU14 = 16384

            ''' <summary>
            ''' 열여섯번째 CPU를 나타냅니다.
            ''' </summary>
            CPU15 = 32768

            ''' <summary>
            ''' 싱글 코어(1) CPU에서의 모든 CPU를 나타냅니다.
            ''' </summary>
            SingleCore = 1

            ''' <summary>
            ''' 듀얼 코어(2) CPU에서의 모든 CPU를 나타냅니다.
            ''' </summary>
            DualCore = 3

            ''' <summary>
            ''' 트리플 코어(3) CPU에서의 모든 CPU를 나타냅니다.
            ''' </summary>
            TripleCore = 7

            ''' <summary>
            ''' 쿼드 코어(4) CPU에서의 모든 CPU를 나타냅니다.
            ''' </summary>
            QuadCore = 15

            ''' <summary>
            ''' 펜타 코어(5) CPU에서의 모든 CPU를 나타냅니다.
            ''' </summary>
            PentaCore = 31

            ''' <summary>
            ''' 헥사 코어(6) CPU에서의 모든 CPU를 나타냅니다.
            ''' </summary>
            HexaCore = 63

            ''' <summary>
            ''' 옥타 코어(8) CPU에서의 모든 CPU를 나타냅니다.
            ''' </summary>
            OctaCore = 255

            ''' <summary>
            ''' 도데카 코어(12) CPU에서의 모든 CPU를 나타냅니다.
            ''' </summary>
            DodecaCore = 4095

        End Enum

        ''' <summary>
        ''' 프로세스의 정보를 가져올 때 어떠한 정보를 가져올 것인지를 결정하는 값들을 열거합니다.
        ''' </summary>

        Public Enum ProcessInformationClass

            ''' <summary>
            ''' 기본적인 정보를 가져옵니다.
            ''' </summary>
            ProcessBasicInformation

            ''' <summary>
            ''' 할당량 제한 정보를 가져옵니다.
            ''' </summary>
            ProcessQuotaLimits

            ''' <summary>
            ''' 입출력 정보를 가져옵니다.
            ''' </summary>
            ProcessIoCounters

            ''' <summary>
            ''' 가상 메모리 정보를 가져옵니다.
            ''' </summary>
            ProcessVmCounters

            ''' <summary>
            ''' 시간 정보를 가져옵니다.
            ''' </summary>
            ProcessTimes

            ''' <summary>
            ''' 기본 우선 순위를 가져옵니다.
            ''' </summary>
            ProcessBasePriority

            ''' <summary>
            ''' 상승한 우선 순위를 가져옵니다.
            ''' </summary>
            ProcessRaisePriority

            ''' <summary>
            ''' 디버거의 포트를 가져옵니다.
            ''' </summary>
            ProcessDebugPort

            ''' <summary>
            ''' 예외 포트를 가져옵니다.
            ''' </summary>
            ProcessExceptionPort

            ''' <summary>
            ''' 토큰 정보를 가져옵니다.
            ''' </summary>
            ProcessAccessToken

            ''' <summary>
            ''' 메모리 테이블 정보를 가져옵니다.
            ''' </summary>
            ProcessLdtInformation

            ''' <summary>
            ''' 메모리 테이블의 크기를 가져옵니다.
            ''' </summary>
            ProcessLdtSize

            ''' <summary>
            ''' 기본 하드웨어 오류 모드를 가져옵니다. (이 값은 커널 모드 전용입니다)
            ''' </summary>
            ProcessDefaultHardErrorMode

            ''' <summary>
            ''' 입출력 포트 핸들러를 가져옵니다.
            ''' </summary>
            ProcessIoPortHandlers

            ''' <summary>
            ''' 풀 사용량과 제한량을 가져옵니다.
            ''' </summary>
            ProcessPooledUsageAndLimits

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            ProcessWorkingSetWatch

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            ProcessUserModeIOPL

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            ProcessEnableAlignmentFaultFixup

            ''' <summary>
            ''' 우선 순위를 가져옵니다.
            ''' </summary>
            ProcessPriorityClass

            ''' <summary>
            ''' 사용되지 않는 멤버입니다.
            ''' </summary>
            ProcessWx86Information

            ''' <summary>
            ''' 핸들 개수를 가져옵니다.
            ''' </summary>
            ProcessHandleCount

            ''' <summary>
            ''' CPU 선호도를 가져옵니다.
            ''' </summary>
            ProcessAffinityMask

            ''' <summary>
            ''' 우선 순위 부스트 정보를 가져옵니다.
            ''' </summary>
            ProcessPriorityBoost

            ''' <summary>
            ''' ProcessInfoClass의 최대 갯수(?)를 가져옵니다.
            ''' </summary>
            MaxProcessInfoClass

            ''' <summary>
            ''' 64비트 프로세스의 정보를 가져옵니다.
            ''' </summary>
            ProcessWow64Information = 26

            ''' <summary>
            ''' 이미지 파일의 이름 정보를 가져옵니다.
            ''' </summary>
            ProcessImageFileName = 27

        End Enum

        ''' <summary>
        ''' 프로세스를 열 때 어떠한 권한으로 열 것인지 결정하는 값들을 열거합니다.
        ''' </summary>
        Public Enum ProcessAccess

            ''' <summary>
            ''' 종료할 수 있는 권한을 나타냅니다.
            ''' </summary>
            Terminate = 1

            ''' <summary>
            ''' 쓰레드를 생성할 수 있는 권한을 나타냅니다.
            ''' </summary>
            CreateThread = 2

            ''' <summary>
            ''' 세션 식별자를 설정할 수 있는 권한을 나타냅니다.
            ''' </summary>
            SetSessionId = 4

            ''' <summary>
            ''' 메모리 작업을 할 수 있는 권한을 나타냅니다.
            ''' </summary>
            VmOperation = 8

            ''' <summary>
            ''' 메모리를 읽을 수 있는 권한을 나타냅니다.
            ''' </summary>
            VmRead = 16

            ''' <summary>
            ''' 메모리를 쓸 수 있는 권한을 나타냅니다.
            ''' </summary>
            VmWrite = 32

            ''' <summary>
            ''' 핸들을 복사할 수 있는 권한을 나타냅니다.
            ''' </summary>
            DuplicateHandle = 64

            ''' <summary>
            ''' 프로세스를 생성할 수 있는 권한을 나타냅니다.
            ''' </summary>
            CreateProcess = 128

            ''' <summary>
            ''' 할당량을 설정할 수 있는 권한을 나타냅니다.
            ''' </summary>
            SetQuota = 256

            ''' <summary>
            ''' 정보를 설정할 수 있는 권한을 나타냅니다.
            ''' </summary>
            SetInformation = 512

            ''' <summary>
            ''' 프로세스의 정보를 가져올 수 있는 권한을 나타냅니다.
            ''' </summary>
            QueryInformation = 1024

            ''' <summary>
            ''' 정지하거나 재개할 수 있는 권한을 나타냅니다.
            ''' </summary>
            SuspendResume = 2048

            ''' <summary>
            ''' 프로세스의 정보를 제한적으로 가져올 수 있는 권한을 나타냅니다.
            ''' </summary>
            QueryLimitedInformation = 4096

            ''' <summary>
            ''' XP 이하의 운영체제에서의 모든 권한을 나타냅니다.
            ''' </summary>
            AllAccessInXPOrLower = STANDARD_RIGHTS_REQUIRED Or SYNCHRONIZE Or &HFFF

            ''' <summary>
            ''' 비스타 이상의 운영체제에서의 모든 권한을 나타냅니다.
            ''' </summary>
            AllAccessInVistaOrHigher = STANDARD_RIGHTS_REQUIRED Or SYNCHRONIZE Or &HFFFF

            ''' <summary>
            ''' 최대한 허용 가능한 권한을 나타냅니다.
            ''' </summary>
            MaximumAllowed = &H2000000

        End Enum

        ''' <summary>
        ''' 쓰레드를 열 때 어떠한 권한으로 열 것인지 결정하는 값들을 열거합니다.
        ''' </summary>

        Public Enum ThreadAccess

            ''' <summary>
            ''' 종료할 수 있는 권한을 나타냅니다.
            ''' </summary>
            Terminate = 1

            ''' <summary>
            ''' 정지하거나 재개할 수 있는 권한을 나타냅니다.
            ''' </summary>
            SuspendResume = 2

            ''' <summary>
            ''' 경고할 수 있는 권한을 나타냅니다.
            ''' </summary>
            Alert = 4

            ''' <summary>
            ''' 컨텍스트를 가져올 수 있는 권한을 나타냅니다.
            ''' </summary>
            GetContext = 8

            ''' <summary>
            ''' 컨텍스트를 설정할 수 있는 권한을 나타냅니다.
            ''' </summary>
            SetContext = 16

            ''' <summary>
            ''' 정보를 설정할 수 있는 권한을 나타냅니다.
            ''' </summary>

            SetInformation = 32

            ''' <summary>
            ''' 정보를 가져올 수 있는 권한을 나타냅니다.
            ''' </summary>
            QueryInformation = 64

            ''' <summary>
            ''' 토큰을 설정할 수 있는 권한을 나타냅니다.
            ''' </summary>
            SetThreadToken = 128

            ''' <summary>
            ''' 가장할 수 있도록 허용하는 권한을 나타냅니다.
            ''' </summary>
            Impersonate = 256

            ''' <summary>
            ''' 토큰이 가장할 수 있도록 허용하는 권한을 나타냅니다.
            ''' </summary>
            DirectImpersonation = 512

            ''' <summary>
            ''' 제한된 정보를 설정할 수 있는 권한을 나타냅니다.
            ''' </summary>

            SetLimitedInformation = 1024

            ''' <summary>
            ''' 제한된 정보를 가져올 수 있는 권한을 나타냅니다.
            ''' </summary>

            QueryLimitedInformation = 2048

            ''' <summary>
            ''' XP 이하의 운영체제에서의 모든 권한을 나타냅니다.
            ''' </summary>

            AllAccessInXPOrLower = STANDARD_RIGHTS_REQUIRED Or SYNCHRONIZE Or &H3FF

            ''' <summary>
            ''' Vista 이상의 운영체제에서의 모든 권한을 나타냅니다.
            ''' </summary>

            AllAccessInVistaOrHigher = STANDARD_RIGHTS_REQUIRED Or SYNCHRONIZE Or &HFFFF

        End Enum

        ''' <summary>
        ''' 토큰을 열 때 어떠한 권한으로 열 것인지 결정하는 값들을 열거합니다.
        ''' </summary>
        Public Enum TokenAccess
            AssignPrimary = 1
            Duplicate = 2
            Impersonate = 4
            Query = 8
            QuerySource = 16
            AdjustPrivileges = 32
            AdjustGroups = 64
            AdjustDefault = 128
            AdjustSessionId = 256
            Read = &H20008
            Write = &H20000 Or 128 Or 64 Or 32
            Execute = &H20000 Or 4

        End Enum

        Public Enum SidNameUse
            SidTypeUser = 1
            SidTypeGroup = 2
            SidTypeDomain = 3
            SidTypeAlias = 4
            SidTypeWellKnownGroup = 5
            SidTypeDeletedAccount = 6
            SidTypeInvalid = 7
            SidTypeUnknown = 8
            SidTypeComputer = 9
            SidTypeLabel = 10
        End Enum

        ''' <summary>
        ''' 스냅샷을 열 때 어떠한 정보를 가져올 것인지 결정하는 값들을 열거합니다.
        ''' </summary>
        Public Enum Toolhelp32Flags

            ' 힙 목록을 가져올 때 사용하는 옵션입니다.
            HeapList = 1

            ' 프로세스 목록을 가져올 때 사용하는 옵션입니다.
            Process = 2

            ' 쓰레드 목록을 가져올 때 사용하는 옵션입니다.
            Thread = 4

            ' 모듈 목록을 가져올 때 사용하는 옵션입니다.
            [Module] = 8

            ' 32비트 모듈 목록을 가져올 때 사용하는 옵션입니다. (이 값은 64비트 운영체제에서만 작동합니다)
            Module32 = 16

            ' 모든 정보를 가져올 때 사용하는 옵션입니다.
            AllOn86 = 15

            ' 모든 정보를 가져올 때 사용하는 옵션입니다. (이 값은 64비트 운영체제에서만 작동합니다)
            AllOn64 = 31

        End Enum

        ''' <summary>
        ''' 토큰의 정보를 가져올 때 어떠한 정보를 가져올 것인지를 결정하는 값들을 열거합니다.
        ''' </summary>
        Public Enum TokenInformationClass
            None
            TokenUser
            TokenGroups
            TokenPrivileges
            TokenOwner
            TokenPrimaryGroup
            TokenDefaultDacl
            TokenSource
            TokenType
            TokenImpersonationLevel
            TokenStatistics
            TokenRestrictedSids
            TokenSessionId
            TokenGroupsAndPrivileges
            TokenSessionReference
            TokenSandBoxInert
            TokenAuditPolicy
            TokenOrigin
            TokenElevationType
            TokenLinkedToken
            TokenElevation
            TokenHasRestrictions
            TokenAccessInformation
            TokenVirtualizationAllowed
            TokenVirtualizationEnabled
            TokenIntegrityLevel
            TokenUIAccess
            TokenMandatoryPolicy
            TokenLogonSid
            MaxTokenInfoClass
        End Enum

        ''' <summary>
        ''' 디버그 상태를 나타냅니다.
        ''' </summary>
        Public Enum DebuggedState

            ''' <summary>
            ''' 알 수 없음
            ''' </summary>
            Unknown = -1

            ''' <summary>
            ''' 디버거가 부착되어 있지 않음
            ''' </summary>
            NotDebugged = 0

            ''' <summary>
            ''' 디버거가 부착되어 있음
            ''' </summary>
            Debugged = 1

        End Enum

        ''' <summary>
        ''' 프로세스 목록을 리스트뷰에 출력할 때 어떠한 정보들을 출력할 지 결정하는 값들을 열거합니다.
        ''' </summary>
        Public Enum ProcessInfoDisplayOptions

            ''' <summary>
            ''' 식별자를 출력합니다.
            ''' </summary>
            Pid = &H1

            ''' <summary>
            ''' 플랫폼을 출력합니다.
            ''' </summary>
            Platform = &H2

            ''' <summary>
            ''' 메모리 사용량을 출력합니다.
            ''' </summary>
            MemoryUsage = &H4

            ''' <summary>
            ''' 설명을 출력합니다.
            ''' </summary>
            Description = &H8

            ''' <summary>
            ''' 버전을 출력합니다.
            ''' </summary>
            Version = &H10

            ''' <summary>
            ''' 실행 경로를 출력합니다.
            ''' </summary>
            Path = &H20

            ''' <summary>
            ''' 명령줄 인수를 출력합니다.
            ''' </summary>
            CommandLine = &H40

            ''' <summary>
            ''' 쓰레드 수를 출력합니다.
            ''' </summary>
            ThreadCount = &H80

            ''' <summary>
            ''' 우선 순위를 출력합니다.
            ''' </summary>
            Priority = &H100

            ''' <summary>
            ''' 핸들 수를 출력합니다.
            ''' </summary>
            HandleCount = &H200

            ''' <summary>
            ''' GDI 개체 수를 출력합니다.
            ''' </summary>
            GdiObjectCount = &H400

            ''' <summary>
            ''' USER 개체 수를 출력합니다.
            ''' </summary>
            GdiUserCount = &H800

        End Enum

    End Class

End Namespace