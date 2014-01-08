Imports System.Runtime.InteropServices
Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Namespace Diagnostics

    Partial Class Process

        Partial Class PrivilegeList

            ''' <summary>
            ''' 지정한 프로세스의 특권 목록을 저장하는 PriorityInfo 클래스의 새 개체를 초기화합니다.
            ''' </summary>
            ''' <param name="PID">특권 목록을 가져올 프로세스의 식별자를 입력합니다.</param>
            Friend Sub New(ByVal PID As UInt32)
                
                MyBase.New(PID)

                Dim hProcess As IntPtr = OpenProcess(ProcessAccess.QueryInformation Or ProcessAccess.VmRead, False, PID),
                    hToken As IntPtr = IntPtr.Zero

                If hProcess = IntPtr.Zero Then MyBase.setValidation(False) : Exit Sub
                If OpenProcessToken(hProcess, TokenAccess.AdjustPrivileges Or TokenAccess.Query, hToken) = 0 Then
                    CloseHandle(hProcess)
                    MyBase.setValidation(False)
                    Exit Sub
                End If

                If hToken = IntPtr.Zero Then
                    CloseHandle(hProcess)
                    MyBase.setValidation(False)
                    Exit Sub
                End If

                Dim iRetLen As Int32 = 0
                Dim iTokenInfoLen As Int32 = 0
                If GetTokenInformation(hToken, TokenInformationClass.TokenPrivileges, IntPtr.Zero, iTokenInfoLen, iRetLen) <> 0 Then
                    CloseHandle(hProcess)
                    CloseHandle(hToken)
                    MyBase.setValidation(False)
                    Exit Sub
                End If

                iTokenInfoLen = iRetLen
                iRetLen = 0

                Dim MemPtr As IntPtr = Marshal.AllocHGlobal(iTokenInfoLen)
                If GetTokenInformation(hToken, TokenInformationClass.TokenPrivileges, MemPtr, iTokenInfoLen, iRetLen) = 0 Then
                    CloseHandle(hProcess)
                    CloseHandle(hToken)
                    Marshal.FreeHGlobal(MemPtr)
                    MyBase.setValidation(False)
                    Exit Sub
                End If

                Dim PrivilegeCounts As Int32 = Marshal.ReadInt32(MemPtr)
                Dim LOffset As Int64 = MemPtr.ToInt64() + Marshal.SizeOf(PrivilegeCounts)

                g_PrivilegeList = New List(Of PrivilegeInfo)

                For i As Int32 = 0 To PrivilegeCounts - 1

                    g_PrivilegeList.Add(New PrivilegeList.PrivilegeInfo(PID, Marshal.PtrToStructure(New IntPtr(LOffset), GetType(LuidAndAttributes))))
                    LOffset += Marshal.SizeOf(GetType(LuidAndAttributes))

                Next
                Marshal.FreeHGlobal(MemPtr)

            End Sub

            ''' <summary>
            ''' 권한 목록을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property Privileges() As PrivilegeInfo()
                Get
                    If Not MyBase.IsValid() Then Return Nothing
                    Return g_PrivilegeList.ToArray()
                End Get
            End Property

        End Class

    End Class

End Namespace