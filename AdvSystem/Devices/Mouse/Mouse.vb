Imports System.Runtime.InteropServices
Imports AdvSystem.ReferenceCore.Api
Imports AdvSystem.ReferenceCore.Enumeration
Imports AdvSystem.ReferenceCore.Structure

Namespace Devices

    Partial Class Mouse

        ''' <summary>
        ''' 마우스 커서의 위치를 설정하거나 가져옵니다.
        ''' </summary>
        Public Shared Property Location() As Location

            Set(ByVal Location As Location)

                Call SetCursorPos(Location.X, Location.Y)

            End Set
            Get

                Dim pLocation As IntPtr = IntPtr.Zero,
                    tempLoc As Location
                Call GetCursorPos(pLocation)

                tempLoc = Marshal.PtrToStructure(pLocation, GetType(Location))
                Marshal.FreeHGlobal(pLocation)
                Return tempLoc

            End Get

        End Property

        ''' <summary>
        ''' 더블 클릭으로 판정되는 시간을 설정하거나 가져옵니다.
        ''' </summary>
        Public Shared Property DoubleClickTime() As UInt32

            Get

                Return GetDoubleClickTime()

            End Get

            Set(ByVal value As UInt32)

                Call SetDoubleClickTime(value)

            End Set

        End Property

        ''' <summary>
        ''' 마우스의 좌우 버튼을 변경합니다.
        ''' </summary>
        ''' <param name="Swap">변경하려면 True를 입력하고, 원상태로 복구하려면 False를 입력합니다.</param>
        Public Shared Function SwapButtons(ByVal Swap As Boolean) As Boolean

            If SwapMouseButton(Swap) Then Return True
            Return False

        End Function

        ''' <summary>
        ''' 마우스의 좌우 버튼이 변경되었는지 여부를 가져옵니다.
        ''' </summary>
        Public Shared Function IsMouseButtonSwapped() As Boolean

            Return CBool(GetSystemMetrics(SM_SWAPBUTTON))

        End Function

        Sub kk()
            Dim k As UIntPtr
            k = 10
            MsgBox(k)
            k += 1
            k -= 1
            
        End Sub

    End Class

End Namespace