Imports System.Runtime.InteropServices
Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Namespace Diagnostics

    Partial Class Process

        Private Shared iDummy As Int32 = 0

        ''' <summary>
        ''' 프로세스를 시작합니다.
        ''' </summary>
        ''' <param name="StartOption">시작 옵션이 들어있는 ProcessStartOption 구조체를 입력합니다.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function Start(ByVal StartOption As ProcessStartOption) As Process

            Dim PProcInfo As IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(GetType(ProcessInformation)))
            If CreateProcess(StartOption.ApplicationPath,
                                           StartOption.CommandLine,
                                           IntPtr.Zero,
                                           IntPtr.Zero,
                                           False,
                                           StartOption.Flags,
                                           IntPtr.Zero,
                                           StartOption.Directory,
                                           StartOption.StartupInfo,
                                           PProcInfo) = 0 Then

                Marshal.FreeHGlobal(PProcInfo)
                Return Nothing

            End If

            Dim pi As New ProcessInformation
            pi = Marshal.PtrToStructure(PProcInfo, GetType(ProcessInformation))
            Marshal.FreeHGlobal(PProcInfo)
            Return New Process(pi.Id)

        End Function

        ''' <summary>
        ''' 실행 중인 프로세스의 식별자를 포함하고 있는 UInteger 배열을 가져옵니다.
        ''' </summary>
        Public Shared Function GetProcessesId() As UInt32()

            Dim ProcessIds(1023) As UInt32, Temp As UInt32, SystemProcessCut As Boolean = False, arrSize As Int32 = 0
            Call EnumProcesses(ProcessIds, 1024, Temp)

            For i As Int32 = 0 To Temp / 4
                If ProcessIds(i) = 0 And Not SystemProcessCut Then SystemProcessCut = True : Continue For
                If ProcessIds(i) = 0 And SystemProcessCut Then arrSize = i
            Next

            Dim newArray As New List(Of UInt32)(arrSize)
            For i As Int32 = 0 To arrSize
                newArray.Add(ProcessIds(i))
            Next
            Return newArray.ToArray()

        End Function

        ''' <summary>
        ''' 프로세스의 메모리 정보를 가져옵니다.
        ''' </summary>
        ''' <param name="ProcessId">메모리 정보를 가져올 프로세스의 식별자를 입력합니다.</param>
        Public Shared Function GetMemoryInfo(ByVal ProcessId As UInt32) As MemoryUsageInfo

            Return New MemoryUsageInfo(ProcessId)

        End Function

        ''' <summary>
        ''' 지정한 프로세스의 부모 프로세스를 가져옵니다.
        ''' </summary>
        ''' <param name="ProcessId">부모 프로세스를 찾을 자식 프로세스의 식별자를 입력합니다.</param>
        Public Shared Function GetParentProcess(ByVal ProcessId As UInt32) As Process

            Dim Pe32 As New ProcessEntry32
            If Not GetProcessPe32(ProcessId, Pe32) Then Return Nothing
            If Not IsProcessRunning(Pe32.th32ParentProcessID) Then Return Nothing
            Return New Process(Pe32.th32ParentProcessID)

        End Function

        ''' <summary>
        ''' 지정한 식별자를 가진 프로세스가 실행 중인지를 확인합니다.
        ''' </summary>
        ''' <param name="ProcessId">실행 중인지 확인할 프로세스의 식별자를 입력합니다.</param>
        Public Shared Function IsProcessRunning(ByVal ProcessId As UInt32) As Boolean

            Dim ProcessIds(1023) As UInt32, Temp As UInt32
            Call EnumProcesses(ProcessIds, 1024, Temp)

            For i As Int32 = 0 To Temp / 4
                If ProcessIds(i) = ProcessId Then Return True
            Next
            Return False

        End Function

        ''' <summary>
        ''' 프로세스의 정보를 포함하고 있는 ProcessBasicInformation 구조체를 가져옵니다.
        ''' </summary>
        ''' <param name="Handle">가져올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="Pbi">정보가 저장될 변수를 입력합니다.</param>
        Public Shared Function GetProcessPBI(ByVal Handle As IntPtr, ByRef Pbi As Object) As Boolean

            If Handle = IntPtr.Zero Then Return False

            Dim pPbi As IntPtr = Marshal.AllocHGlobal(ProcessBasicInformation.Size())

            If NtQueryInformationProcess(Handle, ProcessInformationClass.ProcessBasicInformation, pPbi, ProcessBasicInformation.Size, iDummy) <> 0 Then
                Marshal.FreeHGlobal(pPbi)
                Return False
            End If

            Pbi = Marshal.PtrToStructure(pPbi, GetType(ProcessBasicInformation))
            Marshal.FreeHGlobal(pPbi)
            Return True

        End Function

        ''' <summary>
        ''' 프로세스의 정보를 포함하고 있는 ProcessEnvironmentBlock(PEB) 구조체를 가져옵니다.
        ''' </summary>
        ''' <param name="Handle">가져올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="Peb">정보가 저장될 변수를 입력합니다.</param>
        Public Shared Function GetProcessPEB(ByVal Handle As IntPtr, ByRef Peb As Object) As Boolean

            If Handle = IntPtr.Zero Then Return False

            Dim Pbi As ProcessBasicInformation,
                pPeb As IntPtr = IntPtr.Zero

            If Not GetProcessPBI(Handle, Pbi) Then Return False
            If Pbi.PebBaseAddress = IntPtr.Zero Then Return False

            pPeb = Marshal.AllocHGlobal(ProcessEnvironmentBlock.Size)

            ' 메모리를 읽어오지 못한 경우, False 반환
            If ReadProcessMemory(Handle, Pbi.PebBaseAddress, pPeb, ProcessEnvironmentBlock.Size, iDummy) = 0 Then
                Marshal.FreeHGlobal(Handle)
                Return False
            End If

            Peb = Marshal.PtrToStructure(pPeb, GetType(ProcessEnvironmentBlock))
            Marshal.FreeHGlobal(pPeb)
            Return True

        End Function

        ''' <summary>
        ''' 프로세스의 문자열 정보를 포함하고 있는 RtlUserProcessParameters 구조체를 가져옵니다.
        ''' </summary>
        ''' <param name="Handle">가져올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="RtlUserProcessParam">정보가 저장될 변수를 입력합니다.</param>
        Public Shared Function GetProcessParam(ByVal Handle As IntPtr, ByRef RtlUserProcessParam As Object) As Boolean

            If Handle = IntPtr.Zero Then Return False

            Dim Peb As New ProcessEnvironmentBlock,
                pUpp As IntPtr = IntPtr.Zero

            If Not GetProcessPEB(Handle, Peb) Then Return False
            If Peb.ProcessParameters = IntPtr.Zero Then Return False

            ' RtlUserProcessParameters 구조체 크기만큼 메모리 주소를 할당한다
            pUpp = Marshal.AllocHGlobal(RtlUserProcessParameters.Size())

            ' 메모리를 읽는다
            If ReadProcessMemory(Handle, Peb.ProcessParameters, pUpp, RtlUserProcessParameters.Size, iDummy) = 0 Then
                Marshal.FreeHGlobal(pUpp)
                Return False
            End If

            Peb = Nothing
            RtlUserProcessParam = Marshal.PtrToStructure(pUpp, GetType(RtlUserProcessParameters))
            Marshal.FreeHGlobal(pUpp)
            Return True

        End Function

        ''' <summary>
        ''' 프로세스의 문자열을 읽어옵니다.
        ''' </summary>
        ''' <param name="Handle">문자열을 읽어올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="UnicodeStr">문자열이 저장되어있는 UnicodeString 구조체를 입력합니다.</param>
        ''' <param name="String">문자열이 저장될 변수를 입력합니다.</param>
        Public Shared Function GetProcessParamString(ByVal Handle As IntPtr, ByVal UnicodeStr As UnicodeString, ByRef [String] As String) As Boolean

            If Handle = IntPtr.Zero Then Return False

            Dim pString As IntPtr = Marshal.AllocHGlobal(UnicodeStr.MaximumLength)

            If ReadProcessMemory(Handle, UnicodeStr.Buffer, pString, UnicodeStr.MaximumLength, iDummy) = 0 Then
                Marshal.FreeHGlobal(pString)
                Return False
            End If

            [String] = Marshal.PtrToStringUni(pString)
            Marshal.FreeHGlobal(pString)
            Return True

        End Function

        ''' <summary>
        ''' 프로세스의 정보를 포함하고 있는 ProcessEntry32 구조체를 가져옵니다.
        ''' </summary>
        ''' <param name="ProcessId">정보를 가져올 프로세스의 식별자를 입력합니다.</param>
        ''' <param name="Pe32">정보가 저장될 변수를 입력합니다.</param>
        Public Shared Function GetProcessPe32(ByVal ProcessId As UInt32, ByRef Pe32 As Object) As Boolean

            Dim Snapshot As IntPtr = CreateToolhelp32Snapshot(SnapshotFlags.Process, 0)
            If Snapshot = IntPtr.Zero Then Return False

            Dim TempPe32 As New ProcessEntry32
            TempPe32.dwSize = ProcessEntry32.Size()

            If Process32First(Snapshot, TempPe32) = 0 Then
                CloseHandle(Snapshot)
                Return False
            End If

            Do

                If TempPe32.th32ProcessID = ProcessId Then
                    CloseHandle(Snapshot)
                    Pe32 = TempPe32
                    Return True
                End If

            Loop While Process32Next(Snapshot, TempPe32)
            CloseHandle(Snapshot)
            Return False

        End Function

        ''' <summary>
        ''' 프로세스의 모듈 목록에 대한 정보를 포함하고 있는 PebLdrData 구조체를 가져옵니다.
        ''' </summary>
        ''' <param name="Handle">가져올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="LdrData">정보가 저장될 변수를 입력합니다.</param>
        Public Shared Function GetProcessLdrData(ByVal Handle As IntPtr, ByRef LdrData As Object) As Boolean

            If Handle = IntPtr.Zero Then Return False

            Dim Peb As New ProcessEnvironmentBlock
            If Not GetProcessPEB(Handle, Peb) Then Return False
            Dim pLdr As IntPtr = Marshal.AllocHGlobal(PebLdrData.Size)

            If ReadProcessMemory(Handle, Peb.Ldr, pLdr, PebLdrData.Size, iDummy) = 0 Then Return False

            LdrData = Marshal.PtrToStructure(pLdr, GetType(PebLdrData))
            Marshal.FreeHGlobal(pLdr)
            Return True

        End Function

        ''' <summary>
        ''' 프로세스의 모듈에 대한 정보를 포함하고 있는 LdrModule 구조체를 가져옵니다.
        ''' </summary>
        ''' <param name="Handle">가져올 프로세스의 핸들을 입력합니다.</param>
        ''' <param name="LdmAddress">모듈에 대한 정보가 있는 주소를 입력합니다.</param>
        ''' <param name="Ldm">정보가 저장될 LdrModule 구조체 변수를 입력합니다.</param>
        Public Shared Function GetProcessLdrDataTable(ByVal Handle As IntPtr, ByVal LdmAddress As IntPtr, ByRef Ldm As Object) As Boolean

            If Handle = IntPtr.Zero Then Return False

            Dim pModule As IntPtr = Marshal.AllocHGlobal(LdrModule.Size)

            If ReadProcessMemory(Handle, LdmAddress, pModule, LdrModule.Size(), iDummy) = 0 Then Return False

            Ldm = Marshal.PtrToStructure(pModule, GetType(LdrModule))
            Marshal.FreeHGlobal(pModule)
            Return True

        End Function

        ''' <summary>
        ''' 프로세스의 도메인, 이름을 가져옵니다.
        ''' </summary>
        ''' <param name="ProcessId">가져올 프로세스의 식별자를 입력합니다.</param>
        Public Shared Function GetProcessDomainUsername(ByVal ProcessId As Int32) As String

            If Not IsProcessRunning(ProcessId) Then Return Nothing

            ' 변수 선언
            Dim HProcess As IntPtr = OpenProcess(ProcessAccess.QueryInformation Or ProcessAccess.VmRead, False, ProcessId),
                HToken As IntPtr = IntPtr.Zero,
                TokenAddress As IntPtr = IntPtr.Zero,
                User As New System.Text.StringBuilder(260),
                Domain As New System.Text.StringBuilder(260),
                TokenLength As Int32 = 0,
                Token As New TokenUser
            Dim Ref1 As Int32 = 260, Ref2 As Int32 = 260, snu As SidNameUse

            ' 프로세스의 핸들이 유효하지 않을 경우, 빈 문자열 반환
            If HProcess = IntPtr.Zero Then Return Nothing

            ' 프로세스의 토큰을 열지 못한 경우, 빈 문자열 반환
            If OpenProcessToken(HProcess, TokenAccess.Query, HToken) = 0 Then
                CloseHandle(HProcess)
                Return Nothing
            End If

            ' 필요한 바이트 수를 얻기 위해서 구조체 주소값에 0을 입력하여 호출한다.
            Call GetTokenInformation(HToken, TokenInformationClass.TokenUser, IntPtr.Zero, TokenLength, iDummy)

            ' 필요한 바이트 수를 변수에 저장하고 RefLen 변수의 값을 0으로 
            TokenLength = iDummy
            iDummy = 0

            ' 메모리 공간을 필요한 바이트 수만큼 할당한다
            TokenAddress = Marshal.AllocHGlobal(TokenLength)

            ' 토큰의 정보를 얻어오지 못한 경우, 빈 문자열 반환
            If GetTokenInformation(HToken, TokenInformationClass.TokenUser, TokenAddress, TokenLength, iDummy) = 0 Then
                Marshal.FreeHGlobal(TokenAddress)
                CloseHandle(HProcess)
                Return Nothing
            End If

            Token = Marshal.PtrToStructure(TokenAddress, GetType(TokenUser))

            ' API 호출
            If LookupAccountSid(vbNullString, Token.User.Sid, User, Ref1, Domain, Ref2, snu) = 0 Then
                Marshal.FreeHGlobal(TokenAddress)
                CloseHandle(HProcess)
                Return Nothing
            End If

            Dim TempString As String = Domain.ToString() & "\" & User.ToString()
            Marshal.FreeHGlobal(TokenAddress)
            Return TempString

        End Function

        ''' <summary>
        ''' 프로세스의 정보를 얻기 위해서 프로세스를 엽니다. (QueryInformation 과 VmRead 를 사용함)
        ''' </summary>
        ''' <param name="ProcessId">핸들을 열 프로세스의 식별자를 입력합니다.</param>
        Public Shared Function OpenProcessInfo(ByVal ProcessId As UInt32) As IntPtr

            ' 프로세스 핸들을 저장할 포인터 변수
            Dim Process As IntPtr = IntPtr.Zero

            ' OpenProcess 호출
            Process = OpenProcess(ProcessAccess.QueryInformation Or ProcessAccess.VmRead, False, ProcessId)

            ' 프로세스의 핸들을 반환한다
            Return Process

        End Function

        ''' <summary>
        ''' 프로세스의 이미지 이름을 가져옵니다.
        ''' </summary>
        ''' <param name="ProcessId">이미지 이름을 가져올 프로세스의 식별자를 입력합니다.</param>
        Public Shared Function GetProcessName(ByVal ProcessId As UInt32) As String

            If Not IsProcessRunning(ProcessId) Then Return Nothing
            Dim TempPe32 As New ProcessEntry32
            If Not GetProcessPe32(ProcessId, TempPe32) Then Return Nothing
            Return TempPe32.szExeFile

        End Function

        ''' <summary>
        ''' 프로세스의 특정 메모리 주소에 저장되어 있는 데이터를 읽어옵니다.
        ''' </summary>
        ''' <param name="ProcessId">데이터를 읽어올 프로세스의 식별자를 입력합니다.</param>
        ''' <param name="BaseAddress">데이터가 저장되있는 메모리의 시작 주소를 입력합니다.</param>
        ''' <param name="Size">읽어올 데이터의 크기를 입력합니다.</param>
        ''' <param name="Data">읽어올 데이터가 저장될 바이트 배열 변수를 입력합니다.</param>
        Public Shared Function ReadMemory(ByVal ProcessId As UInt32, ByVal BaseAddress As IntPtr, ByRef Data() As Byte, ByVal Size As Int32) As Boolean

            Dim HProcess As IntPtr = OpenProcess(ProcessAccess.VmRead, False, ProcessId),
                TempPtr As IntPtr = Marshal.AllocHGlobal(Size),
                APIResult As Int32 = 0

            If HProcess = IntPtr.Zero Then Return False
            If ReadProcessMemory(HProcess, BaseAddress, TempPtr, Size, APIResult) = 0 Then CloseHandle(HProcess) : Return False

            ReDim Data(APIResult - 1)
            For i As Int32 = 0 To APIResult - 1
                Data(i) = Marshal.ReadByte(TempPtr, i)
            Next

            Return True

        End Function

        ''' <summary>
        ''' 프로세스의 특정 메모리 주소에 데이터를 씁니다.
        ''' </summary>
        ''' <param name="ProcessId">데이터를 쓸 프로세스의 식별자를 입력합니다.</param>
        ''' <param name="BaseAddress">데이터가 쓰여질 메모리의 시작 주소를 입력합니다.</param>
        ''' <param name="Data">쓸 데이터를 입력합니다.</param>
        ''' <param name="Size">쓸 데이터의 크기를 입력합니다.</param>
        Public Shared Function WriteMemory(ByVal ProcessId As UInt32, ByVal BaseAddress As IntPtr, ByVal Data() As Byte, ByVal Size As Int32) As Boolean

            Dim HProcess As IntPtr = OpenProcess(ProcessAccess.VmWrite, False, ProcessId),
                TempPtr As IntPtr = Marshal.AllocHGlobal(Size),
                APIResult As Int32 = 0

            For i As Int32 = 0 To Size - 1
                Marshal.WriteByte(TempPtr, i, Data(i))
            Next
            If HProcess = IntPtr.Zero Then Return False
            If WriteProcessMemory(HProcess, BaseAddress, TempPtr, Size, APIResult) = 0 Then CloseHandle(HProcess) : Return False

            Return True

        End Function

        ''' <summary>
        ''' 실행 중인 프로세스의 수를 가져옵니다.
        ''' </summary>
        Public Shared Function GetProcessCount() As UInt32

            Dim pi As New PerformanceInformation
            pi.cb = Marshal.SizeOf(GetType(PerformanceInformation))
            If GetPerformanceInfo(pi, pi.cb) = 0 Then Return 0

            Return pi.ProcessCount

        End Function

        ''' <summary>
        ''' 현재 컴퓨터에서 실행 중인 프로세스의 목록을 가져옵니다.
        ''' </summary>
        Public Shared Function GetProcesses() As Process()

            Dim Processes As New List(Of Process)

            ' 프로세스 정보를 얻어오기 위해 스냅샷 생성
            Dim Snapshot As IntPtr = CreateToolhelp32Snapshot(SnapshotFlags.Process, 0),
                PE32 As New ProcessEntry32
            PE32.dwSize = ProcessEntry32.Size()

            ' 스냅샷 생성에 실패한 경우 빈 개체 반환
            If Snapshot = IntPtr.Zero Then Return Nothing

            ' 프로세스 순회에 실패한 경우 빈 개체 반환
            If Process32First(Snapshot, PE32) = 0 Then
                CloseHandle(Snapshot)
                Return Nothing
            End If

            Do
                Processes.Add(New Process(PE32.th32ProcessID))
            Loop While Process32Next(Snapshot, PE32)

            CloseHandle(Snapshot)
            Return Processes.ToArray

        End Function

        ''' <summary>
        ''' 프로세스를 종료합니다.
        ''' </summary>
        ''' <param name="ProcessId">종료할 프로세스의 식별자를 입력합니다.</param>
        ''' <param name="ExitCode">종료 코드를 입력합니다. (기본값은 0입니다)</param>
        Public Shared Function Terminate(ByVal ProcessId As UInt32, Optional ByVal ExitCode As Int32 = 0) As Boolean

            Dim HProcess As IntPtr = OpenProcess(ProcessAccess.Terminate, False, ProcessId)
            If HProcess = IntPtr.Zero Then Return False

            If TerminateProcess(HProcess, ExitCode) <> 0 Then
                CloseHandle(HProcess)
                Return True
            Else
                CloseHandle(HProcess)
                Return False
            End If

        End Function

        ''' <summary>
        ''' 지정한 프로세스와 자식 프로세스를 모두 종료합니다. (모든 자식 프로세스가 종료되었다면 0을 반환합니다)
        ''' </summary>
        ''' <param name="ProcessId">종료할 프로세스의 식별자를 입력합니다.</param>
        ''' <param name="ExitCode">프로세스의 종료 이유를 입력합니다. (기본값은 0입니다)</param>
        Public Shared Function TerminateTree(ByVal ProcessId As UInt32, Optional ByVal ExitCode As Int32 = 0) As Int32

            If Not IsProcessRunning(ProcessId) Then Return -1

            Dim Childs As Process() = GetChildProcesses(ProcessId),
                Result As Int32
            Result = Childs.Length + 1

            ' 자식 프로세스를 모두 종료한다
            For Each pi As Process In Childs

                If pi.Terminate(ExitCode) Then Result -= 1

            Next

            If Terminate(ProcessId, ExitCode) Then Result -= 1
            Return Result

        End Function

        ''' <summary>
        ''' 지정한 프로세스의 자식 프로세스를 가져옵니다.
        ''' </summary>
        ''' <param name="ProcessId">자식 프로세스를 가져올 프로세스의 식별자를 입력합니다.</param>
        Public Shared Function GetChildProcesses(ByVal ProcessId As UInt32) As Process()

            If Not IsProcessRunning(ProcessId) Then Return Nothing

            ' 필요한 변수 선언
            Dim Processes As New List(Of Process),
                PE32 As New ProcessEntry32,
                Snapshot As IntPtr = CreateToolhelp32Snapshot(SnapshotFlags.Process, 0)
            PE32.dwSize = ProcessEntry32.Size()

            ' 스냅샷 생성에 실패한 경우 빈 개체를 반환한다.
            If Snapshot = IntPtr.Zero Then Return Nothing

            ' 프로세스 순회에 실패한 경우, 스냅샷 핸들을 닫고 빈 개체를 반환한다.
            If Process32First(Snapshot, PE32) = 0 Then
                CloseHandle(Snapshot)
                Return Nothing
            End If

            ' 식별자가 다르고, 부모 프로세스가 같은 경우 리스트에 추가한다
            Do
                If PE32.th32ProcessID = ProcessId Then Continue Do
                If PE32.th32ParentProcessID = ProcessId Then Processes.Add(New Process(PE32.th32ProcessID))
            Loop While Process32Next(Snapshot, PE32)

            CloseHandle(Snapshot)
            Return Processes.ToArray

        End Function

    End Class

End Namespace