Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration


Namespace Diagnostics

    Partial Class Process

        Partial Class AffinityInfo

            ''' <summary>
            ''' PID를 이용하여 프로세스의 CPU 선호도 정보를 포함하는 AffinityInfo 클래스의 새 개체를 초기화합니다.
            ''' </summary>
            ''' <param name="PID">CPU 선호도 정보를 가져올 대상 프로세스의 PID를 입력합니다.</param>
            Friend Sub New(ByVal PID As UInt32)
                MyBase.New(PID)

                If Not MyBase.IsValid() Then Exit Sub

                Dim hProcess As IntPtr = OpenProcess(ProcessAccess.QueryInformation Or ProcessAccess.VmRead, False, PID),
                    Dummy As IntPtr = IntPtr.Zero

                If hProcess = IntPtr.Zero Then CPUAffinityMask = -1
                If GetProcessAffinityMask(hProcess, CPUAffinityMask, Dummy) = 0 Then CPUAffinityMask = -1
                CloseHandle(hProcess)

            End Sub

            ''' <summary>
            ''' 지정한 CPU를 프로세스에서 사용할 수 있는지를 가져옵니다.
            ''' </summary>
            ''' <param name="Index">CPU 인덱스를 입력합니다. (인덱스는 0부터 시작합니다)</param>
            Public ReadOnly Property IsCoreEnabled(ByVal Index As Int32) As Boolean

                Get

                    If Not MyBase.IsValid() Then Return Nothing

                    Dim hProcess As IntPtr = OpenProcess(ProcessAccess.QueryInformation Or ProcessAccess.VmRead, False, Id),
                        Dummy As IntPtr = IntPtr.Zero

                    If hProcess = IntPtr.Zero Then CPUAffinityMask = -1
                    If GetProcessAffinityMask(hProcess, CPUAffinityMask, Dummy) = 0 Then CloseHandle(hProcess) : Return Nothing
                    CloseHandle(hProcess)

                    Return CPUAffinityMask And (2 ^ Index)

                End Get

            End Property

            ''' <summary>
            ''' CPU 선호도를 가져옵니다. (2진수 형태의 문자열을 가져옵니다)
            ''' </summary>
            Public ReadOnly Property AffinityMask() As String

                Get

                    If Not MyBase.IsValid() Then Return Nothing

                    Dim AffinityString As String = Nothing

                    For i As Byte = 0 To Environment.ProcessorCount - 1
                        AffinityString &= CInt(-IsCoreEnabled(i))
                    Next

                    Return AffinityString

                End Get

            End Property

            ''' <summary>
            ''' 지정한 CPU 코어의 선호도를 설정합니다.
            ''' </summary>
            ''' <param name="Index">CPU 코어의 인덱스를 입력합니다.</param>
            ''' <param name="Enable">활성화 할 것이면 TRUE, 비활성화 할 것이면 FALSE를 입력합니다.</param>
            Public Function SetAffinityMask(ByVal Index As Int32, ByVal Enable As Boolean) As Boolean

                Dim hProcess As IntPtr = OpenProcess(ProcessAccess.SetInformation, False, Id)
                Dim newAffinity As Int32 = 0

                If hProcess = IntPtr.Zero Then Return False

                For i As Int32 = 0 To Environment.ProcessorCount - 1
                    If i = Index Then
                        If i = 0 Then
                            newAffinity += -Enable
                        Else
                            newAffinity += (2 * -Enable) ^ i
                        End If
                    Else
                        newAffinity += (2 * -IsCoreEnabled(i)) ^ i
                    End If
                Next

                If SetProcessAffinityMask(hProcess, newAffinity) Then
                    CloseHandle(hProcess)
                    Return True
                Else
                    CloseHandle(hProcess)
                    Return False
                End If

            End Function

        End Class

    End Class

End Namespace