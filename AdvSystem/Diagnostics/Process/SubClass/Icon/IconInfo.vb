Imports System.Runtime.InteropServices
Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Namespace Diagnostics

    Partial Class Process

        Partial Class IconInfo

            ''' <summary>
            ''' 지정한 프로세스의 아이콘 정보를 저장하는 IconInfo 클래스의 새 개체를 초기화합니다.
            ''' </summary>
            ''' <param name="PID">아이콘 정보를 가져올 프로세스의 식별자를 입력합니다.</param>
            Friend Sub New(ByVal PID As UInt32)

                MyBase.New(PID)

                If Not MyBase.IsValid() Then Exit Sub
                g_ProcessImagePath = New StringInfo(PID).Path
                If Not FileIO.FileSystem.FileExists(g_ProcessImagePath) Then MyBase.setValidation(False) : Exit Sub

            End Sub

            ''' <summary>
            ''' 작은 아이콘의 핸들을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property Small() As IntPtr

                Get

                    If Not MyBase.IsValid() Then Return Nothing

                    Dim PFileInfo As IntPtr = Marshal.AllocHGlobal(SHFileInfo.Size()),
                        FileInfo As New SHFileInfo

                    If Not FileIO.FileSystem.FileExists(g_ProcessImagePath) Then
                        Marshal.FreeHGlobal(PFileInfo)
                        Return IntPtr.Zero
                    End If

                    If SHGetFileInfo(g_ProcessImagePath, 0, PFileInfo, SHFileInfo.Size(), &H101) = 0 Then
                        Marshal.FreeHGlobal(PFileInfo)
                        Return IntPtr.Zero
                    End If

                    FileInfo = Marshal.PtrToStructure(PFileInfo, GetType(SHFileInfo))
                    Marshal.FreeHGlobal(PFileInfo)
                    Return FileInfo.hIcon

                End Get

            End Property

            ''' <summary>
            ''' 큰 아이콘의 핸들을 가져옵니다.
            ''' </summary>
            Public ReadOnly Property Large() As IntPtr

                Get

                    If Not MyBase.IsValid() Then Return Nothing

                    Dim PFileInfo As IntPtr = Marshal.AllocHGlobal(SHFileInfo.Size()),
                        FileInfo As New SHFileInfo

                    If Not FileIO.FileSystem.FileExists(g_ProcessImagePath) Then
                        Marshal.FreeHGlobal(PFileInfo)
                        Return IntPtr.Zero
                    End If

                    If SHGetFileInfo(g_ProcessImagePath, 0, PFileInfo, SHFileInfo.Size(), &H100) = 0 Then
                        Marshal.FreeHGlobal(PFileInfo)
                        Return IntPtr.Zero
                    End If

                    FileInfo = Marshal.PtrToStructure(PFileInfo, GetType(SHFileInfo))
                    Marshal.FreeHGlobal(PFileInfo)
                    Return FileInfo.hIcon

                End Get

            End Property

        End Class

    End Class

End Namespace