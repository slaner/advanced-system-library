Namespace Diagnostics

    Partial Class Process

        ''' <summary>
        ''' 정보를 포함하는 개체들의 기본 모델입니다.
        ''' </summary>
        Public Class InformationClassBase

            Private g_Id As UInt32
            Private g_ValidClass As Boolean

            Friend Sub New(ByVal ProcessId As UInt32)
                If Not IsProcessRunning(ProcessId) Then g_ValidClass = False : Exit Sub
                g_Id = ProcessId
                g_ValidClass = True
            End Sub

            ''' <summary>
            ''' 유효성을 설정합니다.
            ''' </summary>
            Friend Sub setValidation(ByVal Validation As Boolean)
                g_ValidClass = Validation
            End Sub

            ''' <summary>
            ''' 프로세스의 식별자를 가져옵니다.
            ''' </summary>
            Friend ReadOnly Property Id() As UInt32
                Get
                    Return g_Id
                End Get
            End Property

            ''' <summary>
            ''' 유효한 개체인지 확인합니다.
            ''' </summary>
            Friend ReadOnly Property IsValid() As Boolean
                Get
                    Return g_ValidClass
                End Get
            End Property

        End Class

    End Class

End Namespace