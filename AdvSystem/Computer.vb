Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Public Class Computer

    ''' <summary>
    ''' 시스템 운영체제의 프로세서 구성 정보를 가져옵니다.
    ''' </summary>
    Public Shared Function GetSystemArchitecture() As ArchitectureInfo

        Dim si As New SystemInfo
        Call GetNativeSystemInfo(si)

        Select Case si.wProcessorArchitecture
            Case 0
                Return ArchitectureInfo.x86
            Case 9
                Return ArchitectureInfo.x64
            Case Else
                Return ArchitectureInfo.Unknown
        End Select

    End Function

End Class