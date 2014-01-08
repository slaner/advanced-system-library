Namespace Devices

    ''' <summary>
    ''' 마우스 장치를 제어 및 관리하는 작업을 구현합니다. 이 클래스는 상속될 수 없습니다.
    ''' </summary>
    Public Class Mouse

    End Class

    ' ''' <summary>
    ' ''' 키보드 장치를 제어 및 관리하는 작업을 구현합니다. 이 클래스는 상속될 수 없습니다.
    ' ''' </summary>
    'Public MustInherit Class Keyboard

    '    Private Shared __reservedOwnerHInstance As IntPtr

    '    ''' <summary>
    '    ''' 확장 개체를 초기화할 수 있는지의 여부를 저장하는 변수입니다.
    '    ''' </summary>
    '    Private Shared g_CanInitiate As Boolean = True

    '    ''' <summary>
    '    ''' 입력이 정지되었는지의 여부를 저장하는 변수입니다.
    '    ''' </summary>
    '    Private Shared g_InputSuspended As Boolean

    '    ''' <summary>
    '    ''' 후킹 개체의 핸들을 저장하는 변수입니다.
    '    ''' </summary>
    '    Private Shared g_HookHandle As IntPtr

    '    Public Delegate Function KeyboardDeviceHook(ByVal Code As Int32, ByVal WParam As IntPtr, ByVal LParam As IntPtr) As Int32

    'End Class

End Namespace