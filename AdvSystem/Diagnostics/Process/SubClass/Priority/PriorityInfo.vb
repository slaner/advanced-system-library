Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Namespace Diagnostics

    Partial Class Process

        Partial Class PriorityInfo

            ''' <summary>
            ''' 지정한 프로세스의 우선 순위 정보를 저장하는 PriorityInfo 클래스의 새 개체를 초기화합니다.
            ''' </summary>
            ''' <param name="PID">우선 순위 정보를 가져올 프로세스의 식별자를 입력합니다.</param>
            Friend Sub New(ByVal PID As UInt32)

                MyBase.New(PID)

                Dim hProcess As IntPtr = OpenProcess(ProcessAccess.QueryInformation Or ProcessAccess.VmRead, False, PID)
                If hProcess = IntPtr.Zero Then MyBase.setValidation(False) : Exit Sub

                g_PriorityClass = GetPriorityClass(hProcess)
                CloseHandle(hProcess)

            End Sub

            ''' <summary>
            ''' 우선 순위 상태의 이름을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property Name() As String

                Get

                    If Not MyBase.IsValid() Then Return Nothing

                    Return g_PriorityClass.ToString()

                End Get

            End Property

            ''' <summary>
            ''' 우선 순위 상태의 값을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property Value() As Int32

                Get

                    If Not MyBase.IsValid() Then Return Nothing

                    Return CInt(g_PriorityClass)

                End Get

            End Property

            ''' <summary>
            ''' 우선 순위를 변경합니다.
            ''' </summary>
            ''' <param name="NewPriority">변경될 우선 순위를 입력합니다.</param>
            Public Function ChangePriority(ByVal NewPriority As ProcessPriorityClass) As Boolean

                If Not MyBase.IsValid() Then Return Nothing
                Dim HProcess As IntPtr = OpenProcess(ProcessAccess.SetInformation, False, MyBase.Id)
                If HProcess = IntPtr.Zero Then Return False

                If SetPriorityClass(HProcess, NewPriority) Then
                    CloseHandle(HProcess)
                    Return True
                Else
                    CloseHandle(HProcess)
                    Return False
                End If

            End Function


        End Class

    End Class

End Namespace