Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure


Namespace Diagnostics

    Partial Class Process

        Partial Class ModuleList

            ''' <summary>
            ''' 지정한 프로세스의 모듈 목록을 저장하는 ModuleList 클래스의 새 개체를 초기화합니다.
            ''' </summary>
            ''' <param name="PID">모듈 목록을 가져올 프로세스의 식별자를 입력합니다.</param>
            Friend Sub New(ByVal PID As UInt32)
                MyBase.New(PID)

                If Not MyBase.IsValid() Then Exit Sub

                Dim hProcess As IntPtr = OpenProcess(ProcessAccess.QueryInformation Or ProcessAccess.VmRead, False, PID)
                If hProcess = IntPtr.Zero Then MyBase.setValidation(False) : Exit Sub

                ' 로드된 모듈 정보를 포함하고 있는 구조체 정보를 가져온다
                Dim Pld As New PebLdrData
                Dim Ldm As New LdrModule

                If Not GetProcessLdrData(hProcess, Pld) Then CloseHandle(hProcess) : MyBase.setValidation(False) : Exit Sub
                If Not GetProcessLdrDataTable(hProcess, Pld.InLoadOrderModuleList.FLink, Ldm) Then CloseHandle(hProcess) : MyBase.setValidation(False) : Exit Sub

                g_ModuleInfoList = New List(Of ModuleInfo)

                Do

                    g_ModuleInfoList.Add(New ModuleInfo(PID, Ldm))
                    Call GetProcessLdrDataTable(HProcess, Ldm.InLoadOrderModuleList.FLink, Ldm)

                Loop While Ldm.DllBase <> IntPtr.Zero

                ' 핸들 닫기
                CloseHandle(HProcess)

            End Sub

            ''' <summary>
            ''' 모듈의 정보가 들어있는 리스트를 가져옵니다.
            ''' </summary>
            Public ReadOnly Property Modules() As List(Of ModuleInfo)
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_ModuleInfoList
                End Get
            End Property

            ''' <summary>
            ''' 모듈 리스트를 갱신합니다.
            ''' </summary>
            Public Sub Refresh(ByVal ProcessId As UInt32)
                BuildModuleList(ProcessId)
            End Sub

            ''' <summary>
            ''' 모듈 리스트를 생성합니다.
            ''' </summary>
            Private Sub BuildModuleList(ByVal ProcessId As UInt32)

                ' 프로세스 핸들을 얻어온다
                Dim HProcess As IntPtr = OpenProcess(ProcessAccess.QueryInformation Or ProcessAccess.VmRead, False, ProcessId)
                If HProcess = 0 Then Exit Sub

                ' 로드된 모듈 정보를 포함하고 있는 구조체 정보를 가져온다
                Dim Pld As New PebLdrData
                Dim Ldm As New LdrModule
                If Not getProcessLdrData(HProcess, Pld) Then CloseHandle(HProcess) : Exit Sub
                If Not GetProcessLdrDataTable(HProcess, Pld.InLoadOrderModuleList.FLink, Ldm) Then CloseHandle(HProcess) : Exit Sub

                g_ModuleInfoList = New List(Of ModuleInfo)

                Do

                    g_ModuleInfoList.Add(New ModuleInfo(ProcessId, Ldm))
                    Call GetProcessLdrDataTable(HProcess, Ldm.InLoadOrderModuleList.FLink, Ldm)

                Loop While Ldm.DllBase <> IntPtr.Zero

                ' 핸들 닫기
                CloseHandle(HProcess)

            End Sub

        End Class

    End Class

End Namespace