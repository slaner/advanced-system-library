Namespace Exceptions

    ''' <summary>
    ''' 라이브러리에서 사용되는 예외의 최상위 클래스입니다. Exception 클래스를 상속하고, 추가 정보를 저장하는 AdditionalData 속성이 추가되었습니다.
    ''' </summary>
    Public Class Super
        Inherits Exception

        Private g_Data As Object
        Private g_Code As Int32

        ''' <summary>
        ''' 예외 클래스를 초기화합니다.
        ''' </summary>
        Public Sub New()
            MyBase.New()
            g_Code = Err.LastDllError
        End Sub
        ''' <summary>
        ''' 지정된 메세지를 이용하여 예외 클래스를 초기화합니다.
        ''' </summary>
        ''' <param name="Message">오류를 설명하는 메세지입니다.</param>
        Public Sub New(ByVal Message As String)
            MyBase.New(Message)
            g_Code = Err.LastDllError
        End Sub
        ''' <summary>
        ''' 지정된 메세지와 추가 정보를 이용하여 예외 클래스를 초기화합니다.
        ''' </summary>
        ''' <param name="Message">오류를 설명하는 메세지입니다.</param>
        ''' <param name="Data">예외에 대한 추가 정보입니다.</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal Message As String, ByVal Data As Object)
            MyBase.New(Message)
            g_Data = Data
            g_Code = Err.LastDllError
        End Sub

        ''' <summary>
        ''' 예외에 대한 추가 정보를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property AdditionalData() As Object
            Get
                Return g_Data
            End Get
        End Property
        ''' <summary>
        ''' 오류 코드를 가져옵니다.
        ''' </summary>
        Public ReadOnly Property ErrorCode() As Int32
            Get
                Return g_Code
            End Get
        End Property

    End Class

End Namespace