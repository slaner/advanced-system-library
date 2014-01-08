Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Namespace Diagnostics

    Partial Class Process

        Partial Class StringInfo

            ''' <summary>
            ''' 지정한 프로세스의 문자열 정보를 저장하는 StringInfo 클래스의 새 개체를 초기화합니다.
            ''' </summary>
            ''' <param name="PID">문자열 정보를 가져올 프로세스의 식별자를 입력합니다.</param>
            Friend Sub New(ByVal PID As UInt32)
                MyBase.New(PID)

                If Not MyBase.IsValid() Then Exit Sub

                Dim hProcess As IntPtr = OpenProcessInfo(PID)
                If hProcess = 0 Then MyBase.setValidation(False) : Exit Sub

                Dim Pbi As New ProcessBasicInformation,
                    Peb As New ProcessEnvironmentBlock,
                    Upp As New RtlUserProcessParameters,
                    ValidPath As Boolean = True,
                    ValidCommandline As Boolean = True

                If Not GetProcessParam(hProcess, Upp) Then MyBase.setValidation(False) : Exit Sub
                If Not getProcessParamString(hProcess, Upp.ImagePathName, g_Path) Then
                    g_Path = Nothing
                    ValidPath = False
                End If

                If Not getProcessParamString(hProcess, Upp.CommandLine, g_CommandLine) Then
                    g_CommandLine = Nothing
                    ValidCommandline = False
                End If

                If ValidPath = False And ValidCommandline = False Then
                    CloseHandle(hProcess)
                    MyBase.setValidation(False)
                    Exit Sub
                End If

                Dim TempWinSb As New System.Text.StringBuilder(260)
                Call GetWindowsDirectory(TempWinSb, 260)

                g_Path = Replace$(g_Path, "\systemroot", TempWinSb.ToString(), , , CompareMethod.Text)
                g_Path = Replace$(g_Path, "\??", Nothing, , , CompareMethod.Text)
                g_CommandLine = Replace$(g_CommandLine, "\systemroot", TempWinSb.ToString(), , , CompareMethod.Text)
                g_CommandLine = Replace$(g_CommandLine, "\??", Nothing, , , CompareMethod.Text)

            End Sub

            ''' <summary>
            ''' 실행 파일의 경로를 가져옵니다.
            ''' </summary>
            Public ReadOnly Property Path() As String
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_Path
                End Get
            End Property

            ''' <summary>
            ''' 명령줄 인수를 가져옵니다.
            ''' </summary>
            Public ReadOnly Property CommandLine() As String
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_CommandLine
                End Get
            End Property

        End Class

    End Class

End Namespace