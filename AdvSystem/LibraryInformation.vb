''' <summary>
''' 라이브러리의 정보를 포함하고 있습니다.
''' </summary>
Public Class LibraryInformation

#Region "Pre-compile directives"

#If PLATFORM = "x86" Then
    #If DEBUG Then
        ''' <summary>
        ''' 라이브러리 생성 옵션을 표시합니다.
        ''' </summary>
        Public Const BuildOption As String = "x86, Debug"
    #Else
        ''' <summary>
        ''' 라이브러리 생성 옵션을 표시합니다.
        ''' </summary>
        Public Const BuildOption As String = "x86, Release"
    #End If

    ''' <summary>
    ''' 호환성 정보를 표시합니다.
    ''' </summary>
    Public Const Compatibility As String = "x86"
#ElseIf PLATFORM = "x64" Then
    #If DEBUG Then
        ''' <summary>
        ''' 라이브러리 생성 옵션을 표시합니다.
        ''' </summary>
        Public Const BuildOption As String = "x64, Debug"
    #Else
        ''' <summary>
        ''' 라이브러리 생성 옵션을 표시합니다.
        ''' </summary>
        Public Const BuildOption As String = "x64, Release"
    #End If

    ''' <summary>
    ''' 호환성 정보를 표시합니다.
    ''' </summary>
    Public Const Compatibility As String = "x64"
#ElseIf PLATFORM = "AnyCPU" Then
    #If DEBUG Then
        ''' <summary>
        ''' 라이브러리 생성 옵션을 표시합니다.
        ''' </summary>
        Public Const BuildOption As String = "AnyCPU, Debug"
    #Else
            ''' <summary>
            ''' 라이브러리 생성 옵션을 표시합니다.
            ''' </summary>
            Public Const BuildOption As String = "AnyCPU, Release"
    #End If

    ''' <summary>
    ''' 호환성 정보를 표시합니다.
    ''' </summary>
    Public Const Compatibility As String = "AnyCPU"
#ElseIf PLATFORM = "Itanium" Then
    #If DEBUG Then
        ''' <summary>
        ''' 라이브러리 생성 옵션을 표시합니다.
        ''' </summary>
        Public Const BuildOption As String = "Itanium, Debug"
    #Else
        ''' <summary>
        ''' 라이브러리 생성 옵션을 표시합니다.
        ''' </summary>
        Public Const BuildOption As String = "Itanium, Release"
    #End If

    ''' <summary>
    ''' 호환성 정보를 표시합니다.
    ''' </summary>
   Public Const Compatibility As String = "Itanium"
#Else
    #If DEBUG Then
        ''' <summary>
        ''' 라이브러리 생성 옵션을 표시합니다.
        ''' </summary>
        Public Const BuildOption As String = "Unknown, Debug"
    #Else
        ''' <summary>
        ''' 라이브러리 생성 옵션을 표시합니다.
        ''' </summary>
        Public Const BuildOption As String = "Unknown, Release"
    #End If

    ''' <summary>
    ''' 호환성 정보를 표시합니다.
    ''' </summary>
    Public Const Compatibility As String = "Unknown"
#End If

#End Region

    ''' <summary>
    ''' 라이브러리의 개발자를 표시합니다.
    ''' </summary>
    Public Const Author As String = "Hye won, Hwang"

    ''' <summary>
    ''' 개발자의 연락처 주소(E-Mail)를 표시합니다.
    ''' </summary>
    Public Const Contact As String = "dev.slaner@gmail.com;black_scv@naver.com"

    ''' <summary>
    ''' 라이브러리의 버전을 표시합니다.
    ''' </summary>
    Public Const Version As String = "1.0.0.0"

End Class