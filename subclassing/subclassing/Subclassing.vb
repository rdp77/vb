Imports System.Runtime.InteropServices

Public Class Subclassing
    <DllImport("user32.dll")> Shared Function GetWindowDC(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")> Shared Function GetSystemMetrics(ByVal Index As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")> Shared Function GetDC(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")> Shared Function ReleaseDC(ByVal hwnd As IntPtr, ByVal hdc As IntPtr) As IntPtr
    End Function

End Class
