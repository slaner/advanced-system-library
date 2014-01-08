Imports System.Runtime.InteropServices
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure
Imports AdvSystem.ReferenceCore.Delegate

Namespace ReferenceCore

    Partial Class Api

        <DllImport("user32.dll")> _
        Public Shared Function GetSystemMetrics(ByVal Index As Int32) As Int32
        End Function

        ''' <summary>
        ''' 키의 상태를 가져옵니다. (눌린 경우 -32,768 이 반환됩니다)
        ''' </summary>
        ''' <param name="vkey">키의 상태를 확인할 코드를 입력합니다.</param>
        <DllImport("user32.dll")> _
        Public Shared Function GetAsyncKeyState(ByVal vKey As Integer) As Short
        End Function

        ''' <summary>
        ''' 타이머를 제거합니다.
        ''' </summary>
        ''' <param name="Handle">제거할 타이머를 소유하고 있는 윈도우의 핸들을 입력합니다.</param>
        ''' <param name="EventId">타이머 고유 식별자를 입력합니다.</param>
        <DllImport("user32.dll")> _
        Public Shared Function KillTimer(ByVal Handle As IntPtr, ByVal EventId As IntPtr) As Int32
        End Function

        ''' <summary>
        ''' 타이머를 생성합니다.
        ''' </summary>
        ''' <param name="Handle">타이머를 소유하고 있는 윈도우의 핸들을 입력합니다.</param>
        ''' <param name="EventId">타이머 고유 식별자를 입력합니다.</param>
        ''' <param name="Interval">타이머 호출 시간을 입력합니다.</param>
        ''' <param name="Callbacks">타이머 메세지의 콜백 함수를 입력합니다.</param>
        <DllImport("user32.dll")> _
        Public Shared Function SetTimer(ByVal Handle As IntPtr, ByVal EventId As IntPtr, ByVal Interval As UInt64, <MarshalAs(UnmanagedType.FunctionPtr)> ByVal Callbacks As System.Delegate) As IntPtr
        End Function

        ''' <summary>
        ''' 마우스 좌우 버튼을 변경합니다.
        ''' </summary>
        ''' <param name="Swap">변경할 것이면, TRUE를 입력하고 원상태로 되돌려놓으려면 FALSE를 입력합니다.</param>
        <DllImport("user32.dll")> _
        Public Shared Function SwapMouseButton(ByVal Swap As Boolean) As Int32
        End Function

        ''' <summary>
        ''' 후킹을 중단하고, 후킹 개체를 제거합니다.
        ''' </summary>
        ''' <param name="Hook">제거할 후킹 개체의 핸들을 입력합니다.</param>
        <DllImport("user32.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Auto)> _
        Public Shared Function UnhookWindowsHookEx(ByVal Hook As IntPtr) As Int32
        End Function

        ''' <summary>
        ''' 후킹된 개체의 메세지를 처리합니다.
        ''' </summary>
        ''' <param name="Hook">후킹된 개체의 핸들을 입력합니다.</param>
        ''' <param name="Code">메세지 코드를 입력합니다.</param>
        ''' <param name="WParam">추가 메세지 정보를 입력합니다.</param>
        ''' <param name="LParam">추가 메세지 정보를 입력합니다.</param>
        <DllImport("user32.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Auto)> _
        Public Shared Function CallNextHookEx(ByVal Hook As IntPtr, ByVal Code As Int32, ByVal WParam As IntPtr, ByVal LParam As IntPtr) As Int32
        End Function

        ''' <summary>
        ''' 윈도우를 후킹합니다.
        ''' </summary>
        ''' <param name="HookId">어떤 종류를 후킹할 것인지 입력합니다.</param>
        ''' <param name="Function">콜백 함수를 입력합니다.</param>
        ''' <param name="Module">모듈 시작 주소를 입력합니다.</param>
        ''' <param name="ThreadId">쓰레드 식별자를 입력합니다.</param>
        <DllImport("user32.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Auto)> _
        Public Shared Function SetWindowsHookEx(ByVal HookId As Int32, <MarshalAs(UnmanagedType.FunctionPtr)> ByVal [Function] As System.Delegate, ByVal [Module] As IntPtr, ByVal ThreadId As Int32) As IntPtr
        End Function

        ''' <summary>
        ''' 특정 키를 누릅니다.
        ''' </summary>
        ''' <param name="KeyCode">누를 키의 코드를 입력합니다.</param>
        ''' <param name="ScanCode">스캔 코드를 입력합니다.</param>
        ''' <param name="Flags">옵션을 입력합니다.</param>
        ''' <param name="ExtraInfo">추가 정보를 입력합니다.</param>
        <DllImport("user32.dll")> _
        Public Shared Sub RaiseKeyPress(ByVal KeyCode As Byte, ByVal ScanCode As Byte, ByVal Flags As UInt32, ByVal ExtraInfo As UIntPtr)
        End Sub

        ''' <summary>
        ''' 마우스를 더블 클릭하는 시간을 설정합니다.
        ''' </summary>
        ''' <param name="Interval">더블 클릭의 시간을 입력합니다.</param>
        <DllImport("user32.dll")> _
        Public Shared Function SetDoubleClickTime(ByVal Interval As UInt32) As Int32
        End Function

        ''' <summary>
        ''' 마우스를 더블 클릭하는 시간을 가져옵니다.
        ''' </summary>
        <DllImport("user32.dll")> _
        Public Shared Function GetDoubleClickTime() As UInt32
        End Function

        ''' <summary>
        ''' 커서의 위치를 가져옵니다.
        ''' </summary>
        ''' <param name="Point">커서의 위치가 저장될 변수를 입력합니다.</param>
        <DllImport("user32.dll")> _
        Public Shared Sub GetCursorPos(ByVal Point As IntPtr)
        End Sub

        ''' <summary>
        ''' 커서의 위치를 설정합니다.
        ''' </summary>
        ''' <param name="X">커서의 X 위치를 입력합니다.</param>
        ''' <param name="Y">커서의 Y 위치를 입력합니다.</param>
        <DllImport("user32.dll")> _
        Public Shared Sub SetCursorPos(ByVal X As Int32, ByVal Y As Int32)
        End Sub

        ''' <summary>
        ''' 지정된 시스템의 LUID(Local User Identifier)를 가져옵니다.
        ''' </summary>
        ''' <param name="SystemName">검색할 시스템의 이름을 입력합니다.</param>
        ''' <param name="Name">권한의 이름을 입력합니다.</param>
        ''' <param name="Luid">로컬 유저 식별자(LUID)가 저장될 LUID 구조체를 입력합니다.</param>
        <DllImport("advapi32.dll", EntryPoint:="LookupPrivilegeValueA")> _
        Public Shared Function LookupPrivilegeValue(ByVal SystemName As String, ByVal Name As String, ByRef Luid As LUID) As Int32
        End Function

        ''' <summary>
        ''' 특정한 토큰의 권한을 활성화하거나 비활성화합니다.
        ''' </summary>
        ''' <param name="TokenHandle">권한을 변경할 토큰의 핸들을 입력합니다.</param>
        ''' <param name="DisableAllPrivileges">모든 권한을 비활성화할 것인지 여부를 입력합니다.</param>
        ''' <param name="NewState">변경될 상태를 저장하고 있는 TokenPrivileges 구조체를 입력합니다.</param>
        ''' <param name="BufferLength">PreviousState 매개 변수에 값이 지정된 경우, 매개 변수의 길이를 입력하고 PreviousState 매개 변수가 NULL(Nothing)일 경우 0을 입력합니다.</param>
        ''' <param name="PreviousState">토큰의 이전 상태를 저장하고 있는 TokenPrivileges 구조체를 입력합니다.</param>
        ''' <param name="ReturnLength">얼마만큼의 크기가 필요한지 저장할 변수를 입력합니다.</param>
        <DllImport("advapi32.dll")> _
        Public Shared Function AdjustTokenPrivileges(ByVal TokenHandle As IntPtr, ByVal DisableAllPrivileges As Int32, ByRef NewState As TokenPrivileges, ByVal BufferLength As Int32, ByRef PreviousState As TokenPrivileges, ByRef ReturnLength As Int32) As Int32
        End Function

        ''' <summary>
        ''' 토큰의 정보를 얻어옵니다.
        ''' </summary>
        ''' <param name="TokenHandle">정보를 얻어올 토큰의 정보를 입력합니다.</param>
        ''' <param name="TokenInformationClass">어떤 정보를 가져올 것인지를 입력합니다.</param>
        ''' <param name="TokenInformation">토큰의 정보가 저장될 구조체 혹은 포인터 식을 입력합니다.</param>
        ''' <param name="TokenInformationLength">토큰의 정보가 저장될 구조체 혹은 포인터 식이 저장될 변수에 필요한 크기를 입력합니다.</param>
        ''' <param name="ReturnLength">얼마만큼의 크기가 필요한지 저장할 변수를 입력합니다.</param>
        <DllImport("advapi32.dll")> _
        Public Shared Function GetTokenInformation(ByVal TokenHandle As IntPtr, ByVal TokenInformationClass As Int32, ByVal TokenInformation As IntPtr, ByVal TokenInformationLength As Int32, ByRef ReturnLength As Int32) As Int32
        End Function

        ''' <summary>
        ''' 지정한 시스템의 LUID(Local User Identifier)를 이용하여 권한 이름을 가져옵니다.
        ''' </summary>
        ''' <param name="SystemName">검색할 시스템의 이름을 입력합니다.</param>
        ''' <param name="Luid">권한 정보가 저장되있는 로컬 유저 식별자(LUID)를 입력합니다.</param>
        ''' <param name="Name">권한 이름이 저장될 변수를 입력합니다.</param>
        ''' <param name="NameLen">권한 이름을 찾은 경우, 권한 이름에 해당하는 길이가 저장될 변수를 입력합니다.</param>
        <DllImport("advapi32.dll", EntryPoint:="LookupPrivilegeNameA")> _
        Public Shared Function LookupPrivilegeName(ByVal SystemName As String, ByRef Luid As LUID, ByVal Name As System.Text.StringBuilder, ByRef NameLen As IntPtr) As Int32
        End Function

        ''' <summary>
        ''' 쓰레드의 컨텍스트 정보를 가져옵니다.
        ''' </summary>
        ''' <param name="Thread">컨텍스트 정보를 가져올 쓰레드의 핸들을 입력합니다.</param>
        ''' <param name="Context">컨텍스트 정보를 저장할 포인터를 입력합니다.</param>
        <DllImport("kernel32.dll")> _
        Public Shared Function GetThreadContext(ByVal Thread As IntPtr, ByVal Context As IntPtr) As Boolean
        End Function

        ''' <summary>
        ''' 쓰레드의 컨텍스트 정보를 설정합니다.
        ''' </summary>
        ''' <param name="Thread"></param>
        ''' <param name="Context"></param>


        <DllImport("kernel32.dll")> _
        Public Shared Function SetThreadContext(ByVal Thread As IntPtr, ByVal Context As IntPtr) As Boolean
        End Function

        ''' <summary>
        ''' 쓰레드의 작업을 정지합니다.
        ''' </summary>
        ''' <param name="Thread">작업을 정지할 쓰레드의 핸들을 입력합니다.</param>


        <DllImport("kernel32.dll")> _
        Public Shared Function SuspendThread(ByVal Thread As IntPtr) As Int32
        End Function

        ''' <summary>
        ''' 쓰레드의 작업을 재개합니다.
        ''' </summary>
        ''' <param name="Thread">작업이 정지된 쓰레드의 핸들을 입력합니다.</param>


        <DllImport("kernel32.dll")> _
        Public Shared Function ResumeThread(ByVal Thread As IntPtr) As Int32
        End Function

        ''' <summary>
        ''' 쓰레드를 종료합니다.
        ''' </summary>
        ''' <param name="Thread">종료할 쓰레드의 핸들을 입력합니다.</param>
        ''' <param name="ExitCode">쓰레드가 종료된 이유를 설정합니다. 대부분의 경우 이 옵션을 0으로 설정합니다.</param>
        <DllImport("kernel32.dll")> _
        Public Shared Function TerminateThread(ByVal Thread As IntPtr, ByVal ExitCode As Int32) As Int32
        End Function

        ''' <summary>
        ''' 쓰레드의 핸들을 엽니다.
        ''' </summary>
        ''' <param name="Access">쓰레드 핸들에 대한 접근 권한을 설정합니다.</param>
        ''' <param name="Inherit">핸들을 상속할 것인지 결정합니다. 대부분의 경우 이 옵션을 FALSE로 설정합니다.</param>
        ''' <param name="ThreadId">핸들을 가져올 쓰레드의 대상 식별자(TID)를 입력합니다.</param>
        <DllImport("kernel32.dll")> _
        Public Shared Function OpenThread(ByVal Access As ThreadAccess, ByVal Inherit As Boolean, ByVal ThreadId As UInt32) As IntPtr
        End Function

        ''' <summary>
        ''' 스냅샷의 첫번째 쓰레드 정보를 가져옵니다.
        ''' </summary>
        ''' <param name="Snapshot">쓰레드 정보를 가져올 대상 스냅샷을 입력합니다.</param>
        ''' <param name="TE32">쓰레드 정보가 저장될 ThreadEntry32 구조체 변수를 입력합니다.</param>
        <DllImport("kernel32.dll")> _
        Public Shared Function Thread32First(ByVal Snapshot As IntPtr, ByRef TE32 As ThreadEntry32) As Int32
        End Function

        ''' <summary>
        ''' 스냅샷에 기록된 다음 쓰레드의 정보를 가져옵니다.
        ''' </summary>
        ''' <param name="Snapshot">쓰레드 정보를 가져올 대상 스냅샷을 입력합니다.</param>
        ''' <param name="TE32">쓰레드 정보가 저장될 ThreadEntry32 구조체 변수를 입력합니다.</param>
        <DllImport("kernel32.dll")> _
        Public Shared Function Thread32Next(ByVal Snapshot As IntPtr, ByRef TE32 As ThreadEntry32) As Int32
        End Function

        ''' <summary>
        ''' 프로세스를 생성합니다.
        ''' </summary>
        ''' <param name="ApplicationName">실행될 파일의 이름을 포함한 경로를 입력합니다.</param>
        ''' <param name="CommandLine">명령줄 인수를 입력합니다.</param>
        ''' <param name="ProcessAttributes"></param>
        ''' <param name="ThreadAttributes"></param>
        ''' <param name="InheritHandles">생성되는 프로세스가 부모 프로세스의 핸들을 상속받을 것인지 결정합니다.</param>
        ''' <param name="CreationFlags">생성 옵션을 결정합니다. 이 값을 이용해서 우선 순위를 결정할 수도 있습니다.</param>
        ''' <param name="Environment">환경 변수를 입력합니다.</param>
        ''' <param name="CurrentDirectory">생성될 프로세스의 현재 경로를 입력합니다.</param>
        ''' <param name="StartupInfo">생성 옵션을 결정하는 StartupInfo 구조체의 포인터 식을 입력합니다.</param>
        ''' <param name="ProcessInformation">생성된 프로세스의 정보를 담고있는 ProcessInformation 구조체가 저장될 변수의 포인터 식을 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="CreateProcessA")> _
        Public Shared Function CreateProcess(ByVal ApplicationName As String, ByVal CommandLine As String, ByVal ProcessAttributes As IntPtr, ByVal ThreadAttributes As IntPtr, ByVal InheritHandles As Boolean, ByVal CreationFlags As UInt32, ByVal Environment As IntPtr, ByVal CurrentDirectory As String, ByVal StartupInfo As IntPtr, ByVal ProcessInformation As IntPtr) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 핸들 갯수를 가져옵니다.
        ''' </summary>
        ''' <param name="Process">핸들 갯수를 가져올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="HandleCount">핸들 갯수가 저장될 부호없는 4바이트 정수 변수를 입력합니다.</param>
        <DllImport("kernel32.dll")> _
        Public Shared Function GetProcessHandleCount(ByVal Process As IntPtr, ByRef HandleCount As UInt32) As Int32
        End Function

        ''' <summary>
        ''' 네이티브 시스템의 정보를 가져옵니다.
        ''' </summary>
        ''' <param name="SystemInfo">시스템 정보가 저장될 구조체 변수를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="GetNativeSystemInfo")> _
        Public Shared Sub GetNativeSystemInfo(ByRef SystemInfo As SystemInfo)
        End Sub

        ''' <summary>
        ''' 프로세스가 64비트 프로세스인지 확인합니다.
        ''' </summary>
        ''' <param name="Process">확인할 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="Is64BitProcess">프로세스가 64비트인지 판별 여부가 저장될 변수를 입력합니다. (64비트인 경우 TRUE, 그 외의 경우 FALSE 입니다)</param>
        <DllImport("kernel32.dll", EntryPoint:="IsWow64Process")> _
        Public Shared Function IsWow64Process(ByVal Process As IntPtr, ByRef Is64BitProcess As Boolean) As Int32
        End Function

        ''' <summary>
        ''' 시스템 폴더의 경로를 가져옵니다.
        ''' </summary>
        ''' <param name="Buffer">시스템 경로가 저장될 문자열 변수를 입력합니다.</param>
        ''' <param name="Size">문자열 변수의 길이를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="GetSystemDirectory")> _
        Public Shared Function GetSystemDirectory(ByVal Buffer As System.Text.StringBuilder, ByVal Size As Int32) As Int32
        End Function

        ''' <summary>
        ''' 시스템 폴더의 경로를 가져옵니다.
        ''' </summary>
        ''' <param name="Buffer">시스템 경로가 저장될 문자열 변수를 입력합니다.</param>
        ''' <param name="Size">문자열 변수의 길이를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="GetWindowsDirectory")> _
        Public Shared Function GetWindowsDirectory(ByVal Buffer As System.Text.StringBuilder, ByVal Size As Int32) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 특정 정보를 포함하고 있는 스냅샷을 생성합니다.
        ''' </summary>
        ''' <param name="Flags">어떤 정보를 포함한 스냅샷을 생성할 것인지에 대한 옵션을 설정합니다.</param>
        ''' <param name="ProcessId">정보를 가져올 프로세스의 식별자를 입력합니다. (쓰레드나 프로세스의 정보를 가져오는 경우에는 해당되지 않음)</param>
        <DllImport("kernel32.dll", EntryPoint:="CreateToolhelp32Snapshot")> _
        Public Shared Function CreateToolhelp32Snapshot(ByVal Flags As SnapshotFlags, ByVal ProcessId As Int32) As Int32
        End Function

        ''' <summary>
        ''' 열려진 핸들을 닫습니다.
        ''' </summary>
        ''' <param name="Handle">닫을 핸들을 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="CloseHandle")> _
        Public Shared Function CloseHandle(ByVal Handle As IntPtr) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 핸들을 엽니다.
        ''' </summary>
        ''' <param name="Access">프로세스 핸들에 대한 접근 권한을 설정합니다.</param>
        ''' <param name="Inherit">핸들을 상속할 것인지 결정합니다. 대부분의 경우 이 옵션을 FALSE로 설정합니다.</param>
        ''' <param name="ProcessId">핸들을 가져올 프로세스의 대상 식별자(PID)를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="OpenProcess")> _
        Public Shared Function OpenProcess(ByVal Access As ProcessAccess, ByVal Inherit As Boolean, ByVal ProcessId As UInt32) As IntPtr
        End Function

        ''' <summary>
        ''' 프로세스를 종료합니다.
        ''' </summary>
        ''' <param name="Process">종료할 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="ExitCode">프로세스가 종료된 이유를 설정합니다. 대부분의 경우 이 옵션을 0으로 설정합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="TerminateProcess")> _
        Public Shared Function TerminateProcess(ByVal Process As IntPtr, ByVal ExitCode As Int32) As Int32
        End Function

        ''' <summary>
        ''' 스냅샷의 첫번째 프로세스 정보를 가져옵니다.
        ''' </summary>
        ''' <param name="Snapshot">프로세스 정보를 가져올 대상 스냅샷을 입력합니다.</param>
        ''' <param name="PE32">프로세스 정보가 저장될 ProcessEntry32 구조체 변수를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="Process32First")> _
        Public Shared Function Process32First(ByVal Snapshot As IntPtr, ByRef PE32 As ProcessEntry32) As Int32
        End Function

        ''' <summary>
        ''' 스냅샷에 기록된 다음 프로세스의 정보를 가져옵니다.
        ''' </summary>
        ''' <param name="Snapshot">프로세스 정보를 가져올 대상 스냅샷을 입력합니다.</param>
        ''' <param name="PE32">프로세스 정보가 저장될 ProcessEntry32 구조체 변수를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="Process32Next")> _
        Public Shared Function Process32Next(ByVal Snapshot As IntPtr, ByRef PE32 As ProcessEntry32) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 우선 순위를 가져옵니다.
        ''' </summary>
        ''' <param name="Process">우선 순위를 가져올 프로세스의 핸들을 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="GetPriorityClass")> _
        Public Shared Function GetPriorityClass(ByVal Process As IntPtr) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 CPU 선호도를 가져옵니다.
        ''' </summary>
        ''' <param name="Process">CPU 선호도를 가져올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="ProcessAffinityMask">지정된 프로세스의 CPU 선호도가 저장될 변수를 입력합니다.</param>
        ''' <param name="SystemProcessAffinityMask">시스템의 CPU 선호도가 저장될 변수를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="GetProcessAffinityMask")> _
        Public Shared Function GetProcessAffinityMask(ByVal Process As IntPtr, ByRef ProcessAffinityMask As Int32, ByRef SystemProcessAffinityMask As Int32) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 입출력(I/O) 정보를 가져옵니다.
        ''' </summary>
        ''' <param name="Process">입출력(I/O) 정보를 가져올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="IOC">프로세스의 입출력(I/O) 정보가 저장될 IoCounters 구조체 변수를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="GetProcessIoCounters")> _
        Public Shared Function GetProcessIoCounters(ByVal Process As IntPtr, ByRef IOC As IoCounters) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 우선 순위를 설정합니다.
        ''' </summary>
        ''' <param name="Process">우선 순위를 설정할 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="PriorityClass">우선 순위를 입력합니다. 자세한 항목은 ProcessPriorityClass 열거형을 참고하세요.</param>
        <DllImport("kernel32.dll", EntryPoint:="SetPriorityClass")> _
        Public Shared Function SetPriorityClass(ByVal Process As IntPtr, ByVal PriorityClass As ProcessPriorityClass) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 CPU 선호도를 설정합니다.
        ''' </summary>
        ''' <param name="Process">CPU 선호도를 설정할 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="ProcessAffinityMask">CPU 선호도를 비트 마스크로 표현한 값이 저장된 변수를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="SetProcessAffinityMask")> _
        Public Shared Function SetProcessAffinityMask(ByVal Process As IntPtr, ByVal ProcessAffinityMask As Int32) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 우선 순위 제어 상태를 설정합니다.
        ''' </summary>
        ''' <param name="Process">우선 순위 제어 상태를 설정할 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="DisablePriorityBoost">동적 부스트를 비활성화하려면 TRUE를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="SetProcessPriorityBoost")> _
        Public Shared Function SetProcessPriorityBoost(ByVal Process As IntPtr, ByVal DisablePriorityBoost As Int32) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 워킹셋 크기를 설정합니다.
        ''' </summary>
        ''' <param name="Process">워킹셋 크기를 설정할 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="MinWorkingSetSize">최소 워킹셋 크기를 입력합니다.</param>
        ''' <param name="MaxWorkingSetSize">최대 워킹셋 크기를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="SetProcessWorkingSetSize")> _
        Public Shared Function SetProcessWorkingSetSize(ByVal Process As IntPtr, ByVal MinWorkingSetSize As Int32, ByVal MaxWorkingSetSize As Int32) As Int32

        End Function

        ''' <summary>
        ''' 프로세스의 우선 순위 제어 상태를 가져옵니다.
        ''' </summary>
        ''' <param name="Process">우선 순위 제어 상태를 가져올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="Disable">우선 순위 제어 상태가 저장될 변수를 입력합니다. 이 값이 TRUE일 경우 동적 부스트가 비활성화된 것이고, FALSE일 경우 정상적인 상태를 나타냅니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="GetProcessPriorityBoost")> _
        Public Shared Function GetProcessPriorityBoost(ByVal Process As IntPtr, ByRef Disable As Int32) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 버전을 가져옵니다.
        ''' </summary>
        ''' <param name="ProcessId">버전을 가져올 프로세스의 식별자(PID)를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="GetProcessVersion")> _
        Public Shared Function GetProcessVersion(ByVal ProcessId As Int32) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 시간 정보를 가져옵니다.
        ''' </summary>
        ''' <param name="Process">시간 정보를 가져올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="CreationTime">프로세스의 생성 시간 정보가 저장될 FileTime 구조체 변수를 입력합니다.</param>
        ''' <param name="ExitTime">프로세스의 종료 시간 정보가 저장될 FileTime 구조체 변수를 입력합니다.</param>
        ''' <param name="KernelTime">프로세스의 커널 시간 정보가 저장될 FileTime 구조체 변수를 입력합니다.</param>
        ''' <param name="UserTime">프로세스의 유저 시간 정보가 저장될 FileTime 구조체 변수를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="GetProcessTimes")> _
        Public Shared Function GetProcessTimes(ByVal Process As IntPtr, ByRef CreationTime As [Structure].FileTime, ByRef ExitTime As [Structure].FileTime, ByRef KernelTime As [Structure].FileTime, ByRef UserTime As [Structure].FileTime) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 메모리를 할당합니다.
        ''' </summary>
        ''' <param name="Heap">메모리를 할당할 힙의 핸들을 입력합니다.</param>
        ''' <param name="Flags">메모리를 할당하는 옵션을 설정합니다.</param>
        ''' <param name="Size">할당할 메모리의 크기를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="HeapAlloc")> _
        Public Shared Function HeapAlloc(ByVal Heap As IntPtr, ByVal Flags As Int32, ByVal Size As Int32) As IntPtr
        End Function

        ''' <summary>
        ''' 프로세스의 힙을 가져옵니다.
        ''' </summary>
        <DllImport("kernel32.dll", EntryPoint:="GetProcessHeap")> _
        Public Shared Function GetProcessHeap() As IntPtr
        End Function

        ''' <summary>
        ''' 지정한 프로세스의 메모리에 데이터를 씁니다.
        ''' </summary>
        ''' <param name="Process">메모리에 데이터를 쓸 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="BaseAddress">메모리에 쓸 시작 주소를 입력합니다.</param>
        ''' <param name="Buffer">쓸 데이터가 저장될 변수를 입력합니다.</param>
        ''' <param name="Size">쓸 데이터의 크기를 입력합니다.</param>
        ''' <param name="BytesRead">쓰여진 데이터의 크기가 저장될 변수를 입력합니다.</param>


        <DllImport("kernel32.dll")> _
        Public Shared Function WriteProcessMemory(ByVal Process As IntPtr, ByVal BaseAddress As IntPtr, ByVal Buffer As IntPtr, ByVal Size As Int32, ByRef BytesRead As Int32) As Boolean
        End Function

        ''' <summary>
        ''' 지정한 프로세스의 메모리를 읽어옵니다.
        ''' </summary>
        ''' <param name="Process">메모리를 읽어올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="BaseAddress">메모리를 읽어올 시작 주소를 입력합니다.</param>
        ''' <param name="Buffer">읽어올 데이터가 저장될 변수를 입력합니다.</param>
        ''' <param name="Size">읽어올 데이터의 크기를 입력합니다.</param>
        ''' <param name="BytesRead">읽혀진 데이터의 크기가 저장될 변수를 입력합니다.</param>


        <DllImport("kernel32.dll")> _
        Public Shared Function ReadProcessMemory(ByVal Process As IntPtr, ByVal BaseAddress As IntPtr, ByVal Buffer As IntPtr, ByVal Size As Int32, ByRef BytesRead As Int32) As Boolean
        End Function

        ''' <summary>
        ''' 프로세스의 토큰을 엽니다.
        ''' </summary>
        ''' <param name="Process">토큰을 열 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="DesiredAccess">토큰을 어떤 권한으로 열 것인지 입력합니다.</param>
        ''' <param name="Token">토큰의 핸들이 저장될 포인터 변수를 입력합니다.</param>
        <DllImport("advapi32.dll", EntryPoint:="OpenProcessToken")> _
        Public Shared Function OpenProcessToken(ByVal Process As IntPtr, ByVal DesiredAccess As Int32, ByRef Token As IntPtr) As Int32
        End Function

        ''' <summary>
        ''' 프로세스에 디버거를 부착합니다.
        ''' </summary>
        ''' <param name="ProcessId">디버거를 부착할 프로세스의 식별자를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="DebugActiveProcess")> _
        Public Shared Function DebugActiveProcess(ByVal ProcessId As UInt32) As Int32
        End Function

        ''' <summary>
        ''' 프로세스에 부착된 디버거를 제거합니다.
        ''' </summary>
        ''' <param name="ProcessId">디버거를 제거할 프로세스의 식별자를 입력합니다.</param>
        <DllImport("kernel32.dll", EntryPoint:="DebugActiveProcessStop")> _
        Public Shared Function DebugActiveProcessStop(ByVal ProcessId As UInt32) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 이미지 이름을 가져옵니다.
        ''' </summary>
        ''' <param name="Process">이미지 이름을 가져올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="Buffer">이미지 이름이 저장될 문자열 변수를 입력합니다.</param>
        ''' <param name="BufferLength">문자열 변수의 길이를 입력합니다.</param>
        <DllImport("psapi.dll", EntryPoint:="GetProcessImageFileName")> _
        Public Shared Function GetProcessImageFileName(ByVal Process As IntPtr, ByRef Buffer As String, ByVal BufferLength As Int32) As Int32
        End Function

        ''' <summary>
        ''' 프로세스 목록을 가져옵니다.
        ''' </summary>
        ''' <param name="Processes">프로세스 목록이 저장될 배열 변수를 입력합니다.</param>
        ''' <param name="SizeOfArray">배열 변수의 길이를 입력합니다.</param>
        ''' <param name="RequiredLength">필요한 배열 변수의 길이가 저장될 변수를 입력합니다.</param>
        <DllImport("psapi.dll", EntryPoint:="EnumProcesses")> _
        Public Shared Function EnumProcesses(ByVal Processes() As UInt32, ByVal SizeOfArray As Int32, ByRef RequiredLength As Int32) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 메모리 사용량을 가져옵니다.
        ''' </summary>
        ''' <param name="Process">메모리 사용량을 가져올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="PMCEX">프로세스의 메모리 사용량 정보가 저장될 구조체 변수를 입력합니다.</param>
        ''' <param name="Size">ProcessMemoryCountersEx 구조체의 크기를 입력합니다.</param>
        <DllImport("psapi.dll", EntryPoint:="GetProcessMemoryInfo")> _
        Public Shared Function GetProcessMemoryInfo(ByVal Process As IntPtr, ByRef PMCEX As ProcessMemoryCountersEx, ByVal Size As Int32) As Int32
        End Function

        ''' <summary>
        ''' 성능 정보를 가져옵니다.
        ''' </summary>
        ''' <param name="PerformanceInformation">성능 정보가 저장될 PerformanceInfo 구조체를 입력합니다.</param>
        ''' <param name="Size">PerformanceInfo 구조체의 크기를 입력합니다.</param>
        <DllImport("psapi.dll", EntryPoint:="GetPerformanceInfo")> _
        Public Shared Function GetPerformanceInfo(ByRef PerformanceInformation As PerformanceInformation, ByVal Size As UInt32) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 정보를 가져옵니다.
        ''' </summary>
        ''' <param name="Process">정보를 가져올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="ProcessInformationClass">어떤 정보를 가져올 것인지를 결정합니다.</param>
        ''' <param name="ProcessInformation">프로세스의 정보가 저장될 구조체의 주소값이 저장될 포인터 변수를 입력합니다.</param>
        ''' <param name="ProcessInformationLength">구조체의 크기를 입력합니다.</param>
        ''' <param name="ReturnLength">쓰여진 데이터의 크기가 저장될 정수형 변수를 입력합니다.</param>
        <DllImport("ntdll.dll", EntryPoint:="NtQueryInformationProcess")> _
        Public Shared Function NtQueryInformationProcess(ByVal Process As IntPtr, ByVal ProcessInformationClass As ProcessInformationClass, ByVal ProcessInformation As IntPtr, ByVal ProcessInformationLength As Int32, ByRef ReturnLength As Int32) As Int32
        End Function

        ''' <summary>
        ''' 토큰의 정보를 가져옵니다.
        ''' </summary>
        ''' <param name="Token">정보를 가져올 토큰의 핸들을 입력합니다.</param>
        ''' <param name="TokenInformationClass">어떤 정보를 가져올 것인지를 결정합니다.</param>
        ''' <param name="TokenInformation">토큰의 정보가 저장될 구조체의 주소값이 저장될 포인터 변수를 입력합니다.</param>
        ''' <param name="TokenInformationLength">구조체의 크기를 입력합니다.</param>
        ''' <param name="ReturnLength">쓰여진 데이터의 크기가 저장될 정수형 변수를 입력합니다.</param>
        <DllImport("Advapi32.dll", EntryPoint:="GetTokenInformation")> _
        Public Shared Function GetTokenInformation(ByVal Token As IntPtr, ByVal TokenInformationClass As TokenInformationClass, ByVal TokenInformation As IntPtr, ByVal TokenInformationLength As Int32, ByRef ReturnLength As Int32) As Int32
        End Function

        ''' <summary>
        ''' 지정한 사용자 계정의 보안 식별자(SID)를 검색합니다.
        ''' </summary>
        ''' <param name="SystemName">시스템 이름을 입력합니다.</param>
        ''' <param name="Sid">Sid 구조체를 입력합니다.</param>
        ''' <param name="AccountName">사용자 계정의 이름이 저장될 변수를 입력합니다.</param>
        ''' <param name="AccountNameLength">사용자 계정의 이름이 저장될 변수의 길이를 입력합니다.</param>
        ''' <param name="DomainName">도메인 이름이 저장될 변수를 입력합니다.</param>
        ''' <param name="DomainNameLength">도메인 이름이 저장될 변수의 길이를 입력합니다.</param>
        ''' <param name="use">SidNameUse 구조체를 입력합니다.</param>


        <DllImport("advapi32.dll", EntryPoint:="LookupAccountSid")> _
        Public Shared Function LookupAccountSid(ByVal SystemName As String, ByVal Sid As IntPtr, ByVal AccountName As System.Text.StringBuilder, ByRef AccountNameLength As UInt32, ByVal DomainName As System.Text.StringBuilder, ByRef DomainNameLength As UInt32, ByRef use As Int32) As Int32
        End Function

        ''' <summary>
        ''' 프로세스의 GDI 혹은 USER 개체의 수를 가져옵니다.
        ''' </summary>
        ''' <param name="Process">개체의 수를 가져올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="Flags">어떤 개체를 가져올 것인지 입력합니다.</param>
        <DllImport("user32.dll")> _
        Public Shared Function GetGuiResources(ByVal Process As IntPtr, ByVal Flags As ObjectFlags) As Int32
        End Function

        ''' <summary>
        ''' 파일의 정보를 가져옵니다.
        ''' </summary>
        ''' <param name="Path">파일의 경로를 입력합니다.</param>
        ''' <param name="FileAttributes">파일의 특성을 입력합니다.</param>
        ''' <param name="FileInfo">파일 정보가 저장될 SHFileInfo 구조체의 포인터를 입력합니다.</param>
        ''' <param name="SizeFileInfo">SHFileInfo 구조체의 크기를 입력합니다.</param>
        ''' <param name="Flags">어떤 정보를 가져올 것인지를 결정하는 옵션 값을 입력합니다.</param>
        <DllImport("shell32.dll", EntryPoint:="SHGetFileInfoA")> _
        Public Shared Function SHGetFileInfo(ByVal Path As String, ByVal FileAttributes As Int32, ByVal FileInfo As IntPtr, ByVal SizeFileInfo As Int32, ByVal Flags As Int32) As Int32
        End Function

    End Class

End Namespace