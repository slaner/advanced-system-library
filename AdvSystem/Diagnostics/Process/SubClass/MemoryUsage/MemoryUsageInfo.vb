Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Namespace Diagnostics

    Partial Class Process

        Partial Class MemoryUsageInfo

            ''' <summary>
            ''' 지정한 프로세스의 메모리 사용량 정보를 저장하는 MemoryUsageInfo 클래스의 새 개체를 초기화합니다.
            ''' </summary>
            ''' <param name="PID">메모리 사용량 정보를 가져올 프로세스의 식별자를 입력합니다.</param>
            Friend Sub New(ByVal PID As UInt32)

                MyBase.New(PID)

                If Not MyBase.IsValid() Then Exit Sub

                Dim pmcex As New ProcessMemoryCountersEx,
                    hProcess As IntPtr = OpenProcess(ProcessAccess.QueryInformation Or ProcessAccess.VmRead, False, PID)

                If hProcess = IntPtr.Zero Then

                    Dim myProcess As System.Diagnostics.Process
                    Try

                        myProcess = System.Diagnostics.Process.GetProcessById(PID)

                    Catch ex As Exception

                        MyBase.setValidation(False)
                        Exit Sub

                    End Try

                    ' 프로세스의 핸들을 여는데 실패한 경우, Process 개체를 이용해서 정보를 얻는다
                    g_PrivateUsage = myProcess.PrivateMemorySize64
                    myProcess.Dispose()


                Else

                    pmcex.cb = ProcessMemoryCountersEx.Size()

                    If GetProcessMemoryInfo(hProcess, pmcex, pmcex.cb) = 0 Then
                        MyBase.setValidation(False)
                        CloseHandle(hProcess)
                        Exit Sub
                    End If

                    g_PrivateUsage = pmcex.PrivateUsage
                    g_PageFaultCount = pmcex.PageFaultCount
                    g_PageFileUsage = pmcex.PagefileUsage
                    g_CurrentPagedPoolUsage = pmcex.QuotaPagedPoolUsage
                    g_CurrentNonPagedPoolUsage = pmcex.QuotaNonPagedPoolUsage
                    g_WorkingSetSize = pmcex.WorkingSetSize
                    CloseHandle(hProcess)

                End If

            End Sub

            ''' <summary>
            ''' 개인 메모리 사용량을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property PrivateUsage() As Int32

                Get

                    If Not MyBase.IsValid() Then Return Nothing

                    Return g_PrivateUsage

                End Get

            End Property

            ''' <summary>
            ''' 개인 메모리 사용량을 형식에 맞춰서 표기한 문자열을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property PrivateUsageKb() As String
                Get

                    If Not MyBase.IsValid() Then Return Nothing

                    Return FormatNumber(Int(g_PrivateUsage.ToUInt64 / 1024), 0) & " KB"

                End Get

            End Property

            ''' <summary>
            ''' 페이지 폴트 개수를 가져옵니다.
            ''' </summary>
            Public ReadOnly Property PageFaultCount() As Int32

                Get

                    If Not MyBase.IsValid() Then Return Nothing

                    Return g_PageFaultCount

                End Get

            End Property

            ''' <summary>
            ''' 페이지 파일 사용량을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property PagefileUsage() As Int32

                Get

                    If Not MyBase.IsValid() Then Return Nothing

                    Return g_PageFileUsage

                End Get

            End Property

            ''' <summary>
            ''' 워킹셋 크기를 가져옵니다.
            ''' </summary>
            Public ReadOnly Property WorkingSet() As Int32

                Get

                    If Not MyBase.IsValid() Then Return Nothing

                    Return g_WorkingSetSize

                End Get

            End Property

            ''' <summary>
            ''' 페이징된 풀 사용량을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property PagedPoolUsage() As Int32

                Get

                    If Not MyBase.IsValid() Then Return Nothing

                    Return g_CurrentPagedPoolUsage

                End Get

            End Property

            ''' <summary>
            ''' 페이징되지 않은 풀 사용량을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property NonPagedPoolUsage() As Int32

                Get

                    If Not MyBase.IsValid() Then Return Nothing

                    Return g_CurrentNonPagedPoolUsage

                End Get

            End Property

        End Class

    End Class

End Namespace