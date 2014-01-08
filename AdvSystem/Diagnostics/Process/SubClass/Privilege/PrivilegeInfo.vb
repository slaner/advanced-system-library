Imports System.Runtime.InteropServices
Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Namespace Diagnostics

    Partial Class Process

        Partial Class PrivilegeList

            Partial Class PrivilegeInfo

                ''' <summary>
                ''' 특권의 정보를 저장하는 PrivilegeInfo 클래스의 새 개체를 초기화합니다.
                ''' </summary>
                ''' <param name="LuidAttr">특권에 대한 정보를 저장하고 있는 LuidAndAttributes 구조체 변수를 입력합니다.</param>
                Friend Sub New(ByVal tempId As UInt32, ByVal LuidAttr As LuidAndAttributes)

                    ' 특권의 이름을 얻어온다:
                    Dim PrivilegeName As New System.Text.StringBuilder(120),
                        NameLen As Int32 = 120,
                        Luid As LUID
                    If LookupPrivilegeName(vbNullString, LuidAttr.Luid, PrivilegeName, NameLen) = 0 Then
                        g_Name = "<Unknown Privilege>"
                    Else
                        g_Name = PrivilegeName.ToString()
                    End If
                    g_Name = Trim$(g_Name)

                    If LookupPrivilegeValue(vbNullString, g_Name, Luid) = 0 Then
                        g_Index = -1
                    Else
                        g_Index = Luid.LowPart
                    End If

                    ' 특권 속성을 얻어온다:
                    g_State = LuidAttr.Attributes

                    tempPid = tempId

                End Sub

                ''' <summary>
                ''' 특권의 이름을 가져옵니다.
                ''' </summary>
                Public ReadOnly Property Name() As String
                    Get
                        Return g_Name
                    End Get
                End Property

                ''' <summary>
                ''' 특권의 상태를 가져옵니다.
                ''' </summary>
                Public ReadOnly Property State() As PrivilegeState

                    Get

                        Return g_State

                    End Get

                End Property

                ''' <summary>
                ''' 특권의 번호를 가져옵니다.
                ''' </summary>
                Public ReadOnly Property Index() As Int32
                    Get
                        Return g_Index
                    End Get
                End Property

                ''' <summary>
                ''' 특권의 상태를 변경합니다.
                ''' </summary>
                ''' <param name="State">특권의 변경될 상태를 입력합니다.</param>
                Public Function SetPrivilege(ByVal State As PrivilegeState) As Boolean

                    ' 변경할 상태와 특권의 현재 상태가 같을 경우, 실행하지 않는다
                    If State = g_State Then Return False

                    Dim Luid As New LUID,
                        TokenPrivilege As New TokenPrivileges,
                        HProcess As IntPtr = IntPtr.Zero,
                        HToken As IntPtr = IntPtr.Zero,
                        Dummy As New TokenPrivileges

                    HProcess = OpenProcess(ProcessAccess.QueryInformation, False, tempPid)
                    If HProcess = IntPtr.Zero Then Return False
                    If OpenProcessToken(HProcess, TokenAccess.AdjustPrivileges Or TokenAccess.Query, HToken) = 0 Then
                        CloseHandle(HProcess)
                        Return False
                    End If

                    If HToken = IntPtr.Zero Then
                        CloseHandle(HProcess)
                        Return False
                    End If

                    If LookupPrivilegeValue(Nothing, g_Name, Luid) = 0 Then
                        CloseHandle(HProcess)
                        CloseHandle(HToken)
                        Return False
                    End If

                    With TokenPrivilege

                        .PrivilegeCount = 1
                        .Luid = Luid
                        .Attributes = State

                    End With

                    If AdjustTokenPrivileges(HToken, False, TokenPrivilege, TokenPrivileges.Size(), Dummy, 0) = 0 Then

                        CloseHandle(HProcess)
                        CloseHandle(HToken)
                        Return False

                    End If

                    CloseHandle(HProcess)
                    CloseHandle(HToken)
                    g_State = State
                    Return True

                End Function

            End Class

        End Class

    End Class

End Namespace