'Imports System.Runtime.InteropServices
'Imports AdvSystem.ReferenceCore.Api
'Imports AdvSystem.ReferenceCore.Enumeration
'Imports AdvSystem.ReferenceCore.Structure

'Namespace Devices

'    Partial Class Keyboard

'        ''' <summary>
'        ''' 지정한 키가 눌려진 상태인지 확인합니다.
'        ''' </summary>
'        ''' <param name="vKey">상태를 확인할 키의 코드값을 입력합니다.</param>
'        Public Shared Function IsKeyPressed(ByVal vKey As Int32) As Boolean
'            Return IIf(GetAsyncKeyState(vKey) = -32768, True, False)
'        End Function

'        ''' <summary>
'        ''' 확장 개체를 생성합니다. (확장 개체를 모두 사용한 경우 반드시 FreeExtendObject() 함수를 호출하여 확장 개체의 사용을 종료하여야 합니다)
'        ''' </summary>
'        Public Shared Function InitiateExtendObject() As Boolean

'            If g_CanInitiate Then

'                g_HookHandle = 0
'                __reservedOwnerHInstance = Marshal.GetHINSTANCE(System.Reflection.Assembly.GetCallingAssembly().GetModules()(0))
'                g_HookHandle = SetWindowsHookEx(WH_KEYBOARD_LL,
'                                                New KeyboardDeviceHook(AddressOf KeyboardMessageCallback),
'                                                __reservedOwnerHInstance,
'                                                0)

'                If g_HookHandle = 0 Then Return False
'                g_CanInitiate = False
'                g_InputSuspended = False

'                Return True

'            End If

'            Return False

'        End Function

'        ''' <summary>
'        ''' 확장 개체의 사용을 종료합니다.
'        ''' </summary>
'        Public Shared Sub FreeExtendObject()

'            Call UnhookWindowsHookEx(g_HookHandle)
'            Call KillTimer(IntPtr.Zero, 2)
'            g_HookHandle = 0
'            g_CanInitiate = True
'            g_InputSuspended = False

'        End Sub

'        ''' <summary>
'        ''' 확장 메서드를 사용할 수 있는지 확인합니다.
'        ''' </summary>
'        Public Shared Function IsExtendMethodAvailable() As Boolean
'            Return CBool(g_HookHandle.ToInt64)
'        End Function

'        ''' <summary>
'        ''' 윈도우의 키보드 메세지를 처리하는 콜백 함수입니다.
'        ''' </summary>
'        Private Shared Function KeyboardMessageCallback(ByVal Code As Int32, ByVal WParam As IntPtr, ByVal LParam As IntPtr) As Int32

'            Dim hFile As Int32 = FreeFile()
'            FileOpen(hFile, "C:\HookLog.log", OpenMode.Append) : PrintLine(hFile, Now & "  MouseMessageCallback") : FileClose(hFile)

'            If g_InputSuspended Then Return 1

'            ' 후킹된 메세지를 처리한다
'            Return CallNextHookEx(g_HookHandle, Code, WParam, LParam)

'        End Function

'    End Class

'End Namespace