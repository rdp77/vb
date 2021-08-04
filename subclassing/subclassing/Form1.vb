''============================================================
'' Dibuat oleh: Novian Agung
'' Kontak: pujanggabageur@yahoo.com
'' Copyright 2013
''============================================================
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Form1
    Event ClickMainMenu(ByVal e As MainMenuArgs)

    Public Class MainMenuArgs
        Public Property Left As Long
        Public Property Top As Long
        Public Property Width As Long
        Public Property Height As Long

        Sub New()
            MyBase.New()
        End Sub
    End Class

#Region " Windows Form Designer generated code "
    Private Enum ButtonState As Byte
        Normal
        Hot
        Pressed
    End Enum

#Region " Variables and Constants"
    Private MainButton As Rectangle
    Private MainButtonState As ButtonState
    Private IsMainButtonDown As Boolean

    Private CloseButton As Rectangle
    Private CloseButtonState As ButtonState
    Private IsCloseButtonDown As Boolean

    Private MinButton As Rectangle
    Private MinButtonState As ButtonState
    Private IsMinButtonDown As Boolean

    Private MaxButton As Rectangle
    Private MaxButtonState As ButtonState
    Private IsMaxButtonDown As Boolean

    Private RestoreButton As Rectangle
    Private RestoreButtonState As ButtonState
    Private IsRestoreButtonDown As Boolean

    Private Const SM_CXFRAME As System.Int32 = 32
    Private Const SM_CYFRAME As System.Int32 = 33
    Private Const SM_CXSIZE As System.Int32 = 30
    Private Const SM_CYCAPTION As System.Int32 = 4

    Private Const WM_ACTIVATE As System.Int32 = &H6

    Private Const WM_NCCREATE As System.Int32 = &H81
    Private Const WM_NCPAINT As System.Int32 = &H85
    Private Const WM_NCACTIVATE As System.Int32 = &H86
    Private Const WM_NCHITTEST As System.Int32 = &H84
    Private Const WM_NCMOUSELEAVE As Integer = 674
    Private Const WM_NCMOUSEMOVE As System.Int32 = &HA0
    Private Const WM_NCLBUTTONDOWN As System.Int32 = &HA1
    Private Const WM_NCLBUTTONUP As System.Int32 = &HA2
    Private Const WM_NCLBUTTONDBLCLK As System.Int32 = &HA3

    Private Const WM_MDIACTIVATE As System.Int32 = &H222
    Private Const WM_SETTEXT As System.Int32 = &HC
    Private Const WM_SYSCOMMAND As System.Int32 = &H112

    Private Const SC_CLOSE As System.Int32 = &HF060&
    Private Const SC_MAXIMIZE As System.Int32 = &HF030
    Private Const SC_MINIMIZE As System.Int32 = &HF020
    Private Const SC_RESTORE As System.Int32 = &HF120

    Private Const WM_MOVE As System.Int32 = &H3
    Private Const WM_SIZE As System.Int32 = &H5

    Private Const WM_GETMINMAXINFO As System.Int32 = &H24
    Private Const WM_MOUSEMOVE As System.Int32 = &H200
#End Region

    Private mMenuText As String

    Public Property MenuText() As String
        Get
            'Debug.Print(mMenuText)
            Return mMenuText
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                value = Me.Text
            End If
            mMenuText = value
        End Set
    End Property

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Dim uMsg As Integer = m.Msg
        Dim wParam As Integer = m.WParam
        Dim lParam As Integer = m.LParam
        Dim intNewResult As Integer = 0
        Dim i As Integer = 0

        Select Case uMsg
            Case WM_NCHITTEST
                MyBase.WndProc(m)
            Case WM_SYSCOMMAND
                MyBase.WndProc(m)
            Case WM_NCMOUSELEAVE
                MyBase.WndProc(m)
                Call PaintTitlebarActive()
            Case WM_NCPAINT, WM_NCACTIVATE, WM_NCCREATE, WM_ACTIVATE
                MyBase.WndProc(m)
                Call PaintTitlebarActive()
            Case WM_NCMOUSEMOVE ', WM_NCMOUSELEAVE
                If wParam = 20 Then
                    'Close
                ElseIf wParam = 9 Then
                    'Maximized
                ElseIf wParam = 8 Then
                    'Minimized
                Else
                    MyBase.WndProc(m)
                End If

                If MainButton.Contains(GetNonClientPoint(CInt(m.LParam))) Then
                    If IsMainButtonDown Then
                        If MainButtonState <> ButtonState.Pressed Then
                            MainButtonState = ButtonState.Pressed
                            DrawMainButton(MainButtonState)
                        End If
                    Else
                        If MainButtonState <> ButtonState.Hot Then
                            MainButtonState = ButtonState.Hot
                            DrawMainButton(MainButtonState)
                        End If
                    End If
                Else
                    If IsMainButtonDown Then
                        If MainButtonState <> ButtonState.Hot Then
                            MainButtonState = ButtonState.Hot
                            DrawMainButton(MainButtonState)
                        End If
                    Else
                        If MainButtonState <> ButtonState.Normal Then
                            MainButtonState = ButtonState.Normal
                            DrawMainButton(MainButtonState)
                        End If
                    End If

                End If

                If CloseButton.Contains(GetNonClientPoint(CInt(m.LParam))) Then
                    If IsCloseButtonDown Then
                        If CloseButtonState <> ButtonState.Pressed Then
                            CloseButtonState = ButtonState.Pressed
                            DrawCloseButton(CloseButtonState)
                        End If
                    Else
                        If CloseButtonState <> ButtonState.Hot Then
                            CloseButtonState = ButtonState.Hot
                            DrawCloseButton(CloseButtonState)
                        End If
                    End If
                Else
                    If IsCloseButtonDown Then
                        If CloseButtonState <> ButtonState.Hot Then
                            CloseButtonState = ButtonState.Hot
                            DrawCloseButton(CloseButtonState)
                        End If
                    Else
                        If CloseButtonState <> ButtonState.Normal Then
                            CloseButtonState = ButtonState.Normal
                            DrawCloseButton(CloseButtonState)
                        End If
                    End If
                End If

                If MinButton.Contains(GetNonClientPoint(CInt(m.LParam))) Then
                    If IsMinButtonDown Then
                        If MinButtonState <> ButtonState.Pressed Then
                            MinButtonState = ButtonState.Pressed
                            DrawMinButton(MinButtonState)
                        End If
                    Else
                        If MinButtonState <> ButtonState.Hot Then
                            MinButtonState = ButtonState.Hot
                            DrawMinButton(MinButtonState)
                        End If
                    End If
                Else
                    If IsMinButtonDown Then
                        If MinButtonState <> ButtonState.Hot Then
                            MinButtonState = ButtonState.Hot
                            DrawMinButton(MinButtonState)
                        End If
                    Else
                        If MinButtonState <> ButtonState.Normal Then
                            MinButtonState = ButtonState.Normal
                            DrawMinButton(MinButtonState)
                        End If
                    End If
                End If

                If MaxButton.Contains(GetNonClientPoint(CInt(m.LParam))) Then
                    If IsMaxButtonDown Then
                        If MaxButtonState <> ButtonState.Pressed Then
                            MaxButtonState = ButtonState.Pressed
                        End If
                    Else
                        If MaxButtonState <> ButtonState.Hot Then
                            MaxButtonState = ButtonState.Hot
                        End If
                    End If
                    If Me.WindowState = FormWindowState.Maximized Then
                        DrawRestoreButton(MaxButtonState)
                    Else
                        DrawMaxButton(MaxButtonState)
                    End If
                Else
                    If IsMaxButtonDown Then
                        If MaxButtonState <> ButtonState.Hot Then
                            MaxButtonState = ButtonState.Hot
                            DrawMaxButton(MaxButtonState)
                        End If
                    Else
                        If MaxButtonState <> ButtonState.Normal Then
                            MaxButtonState = ButtonState.Normal
                            DrawMaxButton(MaxButtonState)
                        End If
                    End If
                    If Me.WindowState = FormWindowState.Maximized Then
                        DrawRestoreButton(MaxButtonState)
                    Else
                        DrawMaxButton(MaxButtonState)
                    End If
                End If
            Case WM_NCLBUTTONDOWN
                If MainButton.Contains(GetNonClientPoint(CInt(m.LParam))) Then
                    MainButtonState = ButtonState.Pressed
                    DrawMainButton(MainButtonState)
                    IsMainButtonDown = True 
                ElseIf CloseButton.Contains(GetNonClientPoint(CInt(m.LParam))) Then
                    CloseButtonState = ButtonState.Pressed
                    DrawCloseButton(CloseButtonState)
                    IsCloseButtonDown = True
                ElseIf MinButton.Contains(GetNonClientPoint(CInt(m.LParam))) Then
                    MinButtonState = ButtonState.Pressed
                    DrawMinButton(MinButtonState)
                    IsMinButtonDown = True
                ElseIf MaxButton.Contains(GetNonClientPoint(CInt(m.LParam))) Then
                    MaxButtonState = ButtonState.Pressed
                    If Me.WindowState = FormWindowState.Maximized Then
                        DrawRestoreButton(MaxButtonState)
                    Else
                        DrawMaxButton(MaxButtonState)
                    End If
                    IsMaxButtonDown = True
                Else
                    MyBase.WndProc(m)
                End If
            Case WM_NCLBUTTONUP
                If IsMainButtonDown AndAlso MainButton.Contains(GetNonClientPoint(CInt(m.LParam))) Then
                    MainButtonState = ButtonState.Hot
                    DrawMainButton(MainButtonState)

                    Dim e As New MainMenuArgs
                    e.Left = Me.Left + MainButton.X
                    e.Top = Me.Top + MainButton.Y
                    e.Width = MainButton.Width
                    e.Height = MainButton.Height

                    RaiseEvent ClickMainMenu(e)
                    'MsgBox("Anda mengklik tombol utama", vbInformation)
                ElseIf IsCloseButtonDown AndAlso CloseButton.Contains(GetNonClientPoint(CInt(m.LParam))) Then
                    CloseButtonState = ButtonState.Hot
                    DrawCloseButton(CloseButtonState)
                    Me.Close()
                ElseIf IsMinButtonDown AndAlso MinButton.Contains(GetNonClientPoint(CInt(m.LParam))) Then
                    MinButtonState = ButtonState.Hot
                    DrawMinButton(MinButtonState)
                    Me.WindowState = FormWindowState.Minimized
                ElseIf IsMaxButtonDown AndAlso MaxButton.Contains(GetNonClientPoint(CInt(m.LParam))) Then
                    MaxButtonState = ButtonState.Hot
                    DrawMaxButton(MaxButtonState)
                    If Me.WindowState = FormWindowState.Maximized Then
                        Me.WindowState = FormWindowState.Normal
                    Else
                        Me.WindowState = FormWindowState.Maximized
                    End If
                Else
                    MyBase.WndProc(m)
                    If MainButtonState <> ButtonState.Normal Then
                        MainButtonState = ButtonState.Normal
                        DrawMainButton(MainButtonState)
                    End If
                    If CloseButtonState <> ButtonState.Normal Then
                        CloseButtonState = ButtonState.Normal
                        DrawCloseButton(CloseButtonState)
                    End If
                    If MinButtonState <> ButtonState.Normal Then
                        MinButtonState = ButtonState.Normal
                        DrawMinButton(MinButtonState)
                    End If
                    If MaxButtonState <> ButtonState.Normal Then
                        MaxButtonState = ButtonState.Normal
                        If Me.WindowState = FormWindowState.Maximized Then
                            DrawRestoreButton(MaxButtonState)
                        Else
                            DrawMaxButton(MaxButtonState)
                        End If
                    End If
                End If
                'Reset that the mouse is down
                IsMainButtonDown = False
            Case WM_NCLBUTTONDBLCLK
                If Not MainButton.Contains(GetNonClientPoint(CInt(m.LParam))) Then
                    MyBase.WndProc(m)
                End If
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub

    Sub DrawGradient(ByVal Canvas As Graphics, ByVal X As Integer, ByVal Y As Integer,
                     ByVal nWidth As Integer, ByVal nHeight As Integer,
                     ByVal ColorTop As System.Drawing.Color,
                     ByVal ColorBottom As System.Drawing.Color)

        Dim linGrBrush As New LinearGradientBrush(New Point(0, 0), New Point(0, nHeight), ColorTop, ColorBottom)

        Dim pen As New Pen(linGrBrush)

        Canvas.FillRectangle(linGrBrush, X, Y, nWidth, nHeight)
    End Sub

    Private Function GetNonClientPoint(ByVal lParam As Integer) As Point
        Dim ScreenPoint As New Point(CInt(lParam And Short.MaxValue), CInt(lParam >> 16))
        Return ScreenPoint - CType(Me.Location, Size)
    End Function

    Public Sub DrawRoundedRectangle(ByVal objGraphics As Graphics, _
                                ByVal m_intxAxis As Integer, _
                                ByVal m_intyAxis As Integer, _
                                ByVal m_intWidth As Integer, _
                                ByVal m_intHeight As Integer, _
                                ByVal m_diameter As Integer,
                                Optional ByVal PenColor As System.Drawing.Pen = Nothing)


        If PenColor Is Nothing Then PenColor = Pens.Black

        'Dim g As Graphics
        Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth,
                                      m_intHeight)
        Dim ArcRect As New RectangleF(BaseRect.Location,
                                  New SizeF(m_diameter, m_diameter))
        'top left Arc
        objGraphics.DrawArc(PenColor, ArcRect, 180, 90)
        objGraphics.DrawLine(PenColor, m_intxAxis + CInt(m_diameter / 2),
                             m_intyAxis,
                             m_intxAxis + m_intWidth - CInt(m_diameter / 2),
                             m_intyAxis)

        ' top right arc
        ArcRect.X = BaseRect.Right - m_diameter
        objGraphics.DrawArc(PenColor, ArcRect, 270, 90)
        objGraphics.DrawLine(PenColor, m_intxAxis + m_intWidth,
                             m_intyAxis + CInt(m_diameter / 2),
                             m_intxAxis + m_intWidth,
                             m_intyAxis + m_intHeight - CInt(m_diameter / 2))

        ' bottom right arc
        ArcRect.Y = BaseRect.Bottom - m_diameter
        objGraphics.DrawArc(PenColor, ArcRect, 0, 90)
        objGraphics.DrawLine(PenColor, m_intxAxis + CInt(m_diameter / 2),
                             m_intyAxis + m_intHeight,
                             m_intxAxis + m_intWidth - CInt(m_diameter / 2),
                             m_intyAxis + m_intHeight)

        ' bottom left arc
        ArcRect.X = BaseRect.Left
        objGraphics.DrawArc(PenColor, ArcRect, 90, 90)
        objGraphics.DrawLine(PenColor,
                             m_intxAxis, m_intyAxis + CInt(m_diameter / 2),
                             m_intxAxis,
                             m_intyAxis + m_intHeight - CInt(m_diameter / 2))

    End Sub

    Private Sub DrawMainButton(ByVal State As ButtonState)
        Dim WinDC As IntPtr = Subclassing.GetWindowDC(Me.Handle)
        Dim TitleBarCanvas As Graphics = Graphics.FromHdc(WinDC)
        Dim StrFrmt As New StringFormat
        Dim IconWidth As Int32 = Me.Icon.Width / 2

        Dim PosX As Integer = MainButton.X + CInt((MainButton.Height - IconWidth) / 2)
        Dim PosY As Integer = CInt((MainButton.Height - IconWidth) / 2)
         
        StrFrmt.LineAlignment = StringAlignment.Center
        StrFrmt.Alignment = StringAlignment.Center
        StrFrmt.FormatFlags = StringFormatFlags.NoWrap
        StrFrmt.Trimming = StringTrimming.EllipsisCharacter

        Dim ColorTop, ColorBottom As Color

        ColorTop = Color.FromArgb(243, 172, 73)
        ColorBottom = Color.FromArgb(217, 103, 15)

        Dim myFont As New System.Drawing.Font(Me.Font.FontFamily, 10, FontStyle.Bold)

        Select Case State
            Case ButtonState.Normal
                'If VisualStyles.VisualStyleRenderer.IsSupported Then
                '    'Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Button.PushButton.Normal)
                '    Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Window.CloseButton.Normal)
                '    VisualRenderer.DrawBackground(TitleBarCanvas, MainButton)
                'Else
                '    ControlPaint.DrawButton(TitleBarCanvas,  MainButton, Windows.Forms.ButtonState.Normal)
                'End If
                'TitleBarCanvas.DrawEllipse(
                Call DrawGradient(TitleBarCanvas, MainButton.X + 0, MainButton.Y + 0, MainButton.Width, MainButton.Height - 2, ColorTop, ColorBottom)
                TitleBarCanvas.DrawImage(Me.Icon.ToBitmap, PosX, PosY, IconWidth, IconWidth)
                Call DrawRoundedRectangle(TitleBarCanvas, MainButton.X + 1, MainButton.Y - 2, MainButton.Width - 2, MainButton.Height - 1, 8, Pens.Orange)
                Call DrawRoundedRectangle(TitleBarCanvas, MainButton.X + 0, MainButton.Y - 3, MainButton.Width, MainButton.Height + 1, 8, Pens.Black)
            Case ButtonState.Hot
                'If VisualStyles.VisualStyleRenderer.IsSupported Then
                '    'Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Button.PushButton.Hot)
                '    Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Window.CloseButton.Hot)
                '    VisualRenderer.DrawBackground(TitleBarCanvas, MainButton)
                'Else
                '    ControlPaint.DrawButton(TitleBarCanvas, MainButton, Windows.Forms.ButtonState.Normal)
                'End If

                Call DrawGradient(TitleBarCanvas, MainButton.X + 0, MainButton.Y + 0, MainButton.Width, MainButton.Height - 2, ColorBottom, ColorTop)
                TitleBarCanvas.DrawImage(Me.Icon.ToBitmap, PosX, PosY, IconWidth, IconWidth)
                Call DrawRoundedRectangle(TitleBarCanvas, MainButton.X + 1, MainButton.Y - 2, MainButton.Width - 2, MainButton.Height - 1, 8, Pens.Orange)
                Call DrawRoundedRectangle(TitleBarCanvas, MainButton.X + 0, MainButton.Y - 3, MainButton.Width, MainButton.Height + 1, 8, Pens.Black)
            Case ButtonState.Pressed
                'If VisualStyles.VisualStyleRenderer.IsSupported Then
                '    'Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Button.PushButton.Pressed)
                '    Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Window.CloseButton.Pressed)
                '    VisualRenderer.DrawBackground(TitleBarCanvas, MainButton)
                'Else
                '    ControlPaint.DrawButton(TitleBarCanvas, MainButton, Windows.Forms.ButtonState.Pushed)
                'End If

                Call DrawGradient(TitleBarCanvas, MainButton.X + 0, MainButton.Y + 0, MainButton.Width, MainButton.Height - 2, Color.FromArgb(234, 143, 50), Color.FromArgb(207, 75, 1))
                TitleBarCanvas.DrawImage(Me.Icon.ToBitmap, PosX, PosY, IconWidth, IconWidth)
                Call DrawRoundedRectangle(TitleBarCanvas, MainButton.X + 1, MainButton.Y - 2, MainButton.Width - 2, MainButton.Height - 1, 8, Pens.Orange)
                Call DrawRoundedRectangle(TitleBarCanvas, MainButton.X + 0, MainButton.Y - 3, MainButton.Width, MainButton.Height + 1, 8, Pens.Black)
        End Select

        Dim PA2 As New PointF(MainButton.X + MainButton.Width - 7, MainButton.Height - 13)
        Dim PA3 As New PointF(MainButton.X + MainButton.Width - 13, MainButton.Height - 13)
        Dim PA1 As New PointF(MainButton.X + MainButton.Width - 10, MainButton.Height - 9)
        Dim ShadowPoints() As PointF = {PA1, PA2, PA3}
        TitleBarCanvas.FillPolygon(Brushes.Black, ShadowPoints, FillMode.Winding)

        Dim P2 As New PointF(MainButton.X + MainButton.Width - 6, MainButton.Height - 14)
        Dim P3 As New PointF(MainButton.X + MainButton.Width - 12, MainButton.Height - 14)
        Dim P1 As New PointF(MainButton.X + MainButton.Width - 9, MainButton.Height - 8)
        Dim TrianglePoints() As PointF = {P1, P2, P3}
        TitleBarCanvas.FillPolygon(Brushes.White, TrianglePoints, FillMode.Winding)

        TitleBarCanvas.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        TitleBarCanvas.DrawString(StrDup(2, " ") & Me.MenuText, myFont, Brushes.White, MainButton, StrFrmt)

        TitleBarCanvas.Dispose()
        StrFrmt.Dispose()
        myFont.Dispose()

        Subclassing.ReleaseDC(Me.Handle, WinDC)
    End Sub

    Private Sub DrawCloseButton(ByVal State As ButtonState)
        Dim WinDC As IntPtr = Subclassing.GetWindowDC(Me.Handle)
        Dim TitleBarCanvas As Graphics = Graphics.FromHdc(WinDC)

        Select Case State
            Case ButtonState.Normal
                If VisualStyles.VisualStyleRenderer.IsSupported Then
                    'Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Button.PushButton.Normal)
                    Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Window.CloseButton.Normal)
                    VisualRenderer.DrawBackground(TitleBarCanvas, CloseButton)
                Else
                    ControlPaint.DrawButton(TitleBarCanvas, CloseButton, Windows.Forms.ButtonState.Normal)
                End If
            Case ButtonState.Hot
                If VisualStyles.VisualStyleRenderer.IsSupported Then
                    'Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Button.PushButton.Hot)
                    Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Window.CloseButton.Hot)
                    VisualRenderer.DrawBackground(TitleBarCanvas, CloseButton)
                Else
                    ControlPaint.DrawButton(TitleBarCanvas, CloseButton, Windows.Forms.ButtonState.Normal)
                End If
            Case ButtonState.Pressed
                If VisualStyles.VisualStyleRenderer.IsSupported Then
                    'Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Button.PushButton.Pressed)
                    Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Window.CloseButton.Pressed)
                    VisualRenderer.DrawBackground(TitleBarCanvas, CloseButton)
                Else
                    ControlPaint.DrawButton(TitleBarCanvas, CloseButton, Windows.Forms.ButtonState.Pushed)
                End If
        End Select

        Subclassing.ReleaseDC(Me.Handle, WinDC)
    End Sub

    Private Sub DrawMinButton(ByVal State As ButtonState)
        Dim WinDC As IntPtr = Subclassing.GetWindowDC(Me.Handle)
        Dim TitleBarCanvas As Graphics = Graphics.FromHdc(WinDC)

        Select Case State
            Case ButtonState.Normal
                If VisualStyles.VisualStyleRenderer.IsSupported Then
                    'Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Button.PushButton.Normal)
                    Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Window.MinButton.Normal)
                    VisualRenderer.DrawBackground(TitleBarCanvas, MinButton)
                Else
                    ControlPaint.DrawButton(TitleBarCanvas, MinButton, Windows.Forms.ButtonState.Normal)
                End If
            Case ButtonState.Hot
                If VisualStyles.VisualStyleRenderer.IsSupported Then
                    'Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Button.PushButton.Hot)
                    Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Window.MinButton.Hot)
                    VisualRenderer.DrawBackground(TitleBarCanvas, MinButton)
                Else
                    ControlPaint.DrawButton(TitleBarCanvas, MinButton, Windows.Forms.ButtonState.Normal)
                End If
            Case ButtonState.Pressed
                If VisualStyles.VisualStyleRenderer.IsSupported Then
                    'Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Button.PushButton.Pressed)
                    Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Window.MinButton.Pressed)
                    VisualRenderer.DrawBackground(TitleBarCanvas, MinButton)
                Else
                    ControlPaint.DrawButton(TitleBarCanvas, MinButton, Windows.Forms.ButtonState.Pushed)
                End If
        End Select

        'TitleBarCanvas.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        TitleBarCanvas.Dispose()

        Subclassing.ReleaseDC(Me.Handle, WinDC)
    End Sub

    Private Sub DrawMaxButton(ByVal State As ButtonState)
        Dim WinDC As IntPtr = Subclassing.GetWindowDC(Me.Handle)
        Dim TitleBarCanvas As Graphics = Graphics.FromHdc(WinDC)

        Select Case State
            Case ButtonState.Normal
                If VisualStyles.VisualStyleRenderer.IsSupported Then
                    'Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Button.PushButton.Normal)
                    Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Window.MaxButton.Normal)
                    VisualRenderer.DrawBackground(TitleBarCanvas, MaxButton)
                Else
                    ControlPaint.DrawButton(TitleBarCanvas, MaxButton, Windows.Forms.ButtonState.Normal)
                End If
            Case ButtonState.Hot
                If VisualStyles.VisualStyleRenderer.IsSupported Then
                    'Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Button.PushButton.Hot)
                    Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Window.MaxButton.Hot)
                    VisualRenderer.DrawBackground(TitleBarCanvas, MaxButton)
                Else
                    ControlPaint.DrawButton(TitleBarCanvas, MaxButton, Windows.Forms.ButtonState.Normal)
                End If
            Case ButtonState.Pressed
                If VisualStyles.VisualStyleRenderer.IsSupported Then
                    'Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Button.PushButton.Pressed)
                    Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Window.MaxButton.Pressed)
                    VisualRenderer.DrawBackground(TitleBarCanvas, MaxButton)
                Else
                    ControlPaint.DrawButton(TitleBarCanvas, MaxButton, Windows.Forms.ButtonState.Pushed)
                End If
        End Select

        'TitleBarCanvas.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        TitleBarCanvas.Dispose()

        Subclassing.ReleaseDC(Me.Handle, WinDC)
    End Sub

    Private Sub DrawRestoreButton(ByVal State As ButtonState)
        Dim WinDC As IntPtr = Subclassing.GetWindowDC(Me.Handle)
        Dim TitleBarCanvas As Graphics = Graphics.FromHdc(WinDC)

        Select Case State
            Case ButtonState.Normal
                If VisualStyles.VisualStyleRenderer.IsSupported Then
                    'Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Button.PushButton.Normal)
                    Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Window.RestoreButton.Normal)
                    VisualRenderer.DrawBackground(TitleBarCanvas, MaxButton)
                Else
                    ControlPaint.DrawButton(TitleBarCanvas, MaxButton, Windows.Forms.ButtonState.Normal)
                End If
            Case ButtonState.Hot
                If VisualStyles.VisualStyleRenderer.IsSupported Then
                    'Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Button.PushButton.Hot)
                    Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Window.RestoreButton.Hot)
                    VisualRenderer.DrawBackground(TitleBarCanvas, MaxButton)
                Else
                    ControlPaint.DrawButton(TitleBarCanvas, MaxButton, Windows.Forms.ButtonState.Normal)
                End If
            Case ButtonState.Pressed
                If VisualStyles.VisualStyleRenderer.IsSupported Then
                    'Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Button.PushButton.Pressed)
                    Dim VisualRenderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.Window.RestoreButton.Pressed)
                    VisualRenderer.DrawBackground(TitleBarCanvas, MaxButton)
                Else
                    ControlPaint.DrawButton(TitleBarCanvas, MaxButton, Windows.Forms.ButtonState.Pushed)
                End If
        End Select

        'TitleBarCanvas.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        TitleBarCanvas.Dispose()

        Subclassing.ReleaseDC(Me.Handle, WinDC)
    End Sub

    Private Sub SizeMenuButton()
        Dim BorderWidth As Int32 = (Me.Width - Me.ClientSize.Width) / 2 ' Subclassing.GetSystemMetrics(SM_CXFRAME)
        Dim ButtonWidth As Int32 = Subclassing.GetSystemMetrics(SM_CXSIZE)
        Dim ButtonHeight As Int32 = Subclassing.GetSystemMetrics(SM_CXSIZE)

        Dim TitleBarWidth As Int32 = Me.Width
        Dim ClientWidth As Int32 = Me.ClientSize.Width
        'Dim TitleBarHeight As Int32 = (Me.Height - Me.ClientSize.Height) - BorderWidth ' Subclassing.GetSystemMetrics(SM_CYCAPTION)

        Dim TitleBarHeight As Int32 = Subclassing.GetSystemMetrics(SM_CYCAPTION)
        TitleBarHeight += BorderWidth

        Dim CloseButtonPosXBegin As Integer = 0
        Dim CloseButtonPosXEnd As Integer = 0

        Dim MaxButtonPosXBegin As Integer = 0
        Dim MaxButtonPosXEnd As Integer = 0

        Dim MinButtonPosXBegin As Integer = 0
        Dim MinButtonPosXEnd As Integer = 0

        Dim IconButtonPosXBegin As Integer = 0
        Dim IconButtonPosXEnd As Integer = 0

        Dim AddButtonPosXBegin As Integer = 0
        Dim AddButtonPosXEnd As Integer = 0

        Dim TextPosXBegin As Integer = 0
        Dim TextPosXEnd As Integer = 0

        Dim ButtonPosYBegin As Integer = 0
        Dim ButtonPosYEnd As Integer = 0

        Dim PosY As Integer = BorderWidth

        MainButton = New Rectangle(0, 0, 125, TitleBarHeight - 4)
        MinButton = New Rectangle(0, 0, 25, 25)
        MaxButton = New Rectangle(0, 0, 25, 25)
        CloseButton = New Rectangle(0, 0, 25, 25)

        ButtonWidth -= 4
        ButtonHeight -= 4

        IconButtonPosXBegin = 0
        IconButtonPosXEnd = ButtonWidth

        CloseButtonPosXBegin = ClientWidth - ButtonWidth + 2
        CloseButtonPosXEnd = ClientWidth

        MaxButtonPosXBegin = CloseButtonPosXBegin - ButtonWidth - 2
        MaxButtonPosXEnd = CloseButtonPosXBegin - 1

        MinButtonPosXBegin = MaxButtonPosXBegin - ButtonWidth - 2
        MinButtonPosXEnd = MaxButtonPosXEnd - 1

        ButtonPosYBegin = BorderWidth / 2
        ButtonPosYEnd = BorderWidth / 2 + ButtonWidth

        TextPosXBegin = IconButtonPosXEnd + 1
        TextPosXEnd = MinButtonPosXBegin - 1

        With CloseButton
            .Y = PosY
            .X = CloseButtonPosXBegin
            .Width = ButtonWidth
            .Height = ButtonHeight
        End With

        With MinButton
            .Y = PosY
            .X = MinButtonPosXBegin
            .Width = ButtonWidth
            .Height = ButtonHeight
        End With

        With MaxButton
            .Y = PosY
            .X = MaxButtonPosXBegin
            .Width = ButtonWidth
            .Height = ButtonHeight
        End With

        With RestoreButton
            .Y = PosY
            .X = CloseButtonPosXBegin
            .Width = ButtonWidth
            .Height = ButtonHeight
        End With

        If Me.WindowState = FormWindowState.Normal Then
            MainButton.X = BorderWidth
            MainButton.Y = 0
            'MainButton.Height = SystemInformation.CaptionHeight + SystemInformation.HorizontalResizeBorderThickness
        Else
            MainButton.X = 0
            MainButton.Y = 0
            'MainButton.Height = SystemInformation.CaptionHeight + SystemInformation.HorizontalResizeBorderThickness
        End If

        MainButtonState = ButtonState.Normal
        IsMainButtonDown = False
        DrawMainButton(MainButtonState)

        CloseButtonState = ButtonState.Normal
        IsCloseButtonDown = False

        MinButtonState = ButtonState.Normal
        IsMinButtonDown = False
        MaxButtonState = ButtonState.Normal
        IsMaxButtonDown = False

        DrawCloseButton(CloseButtonState)
        DrawMinButton(MinButtonState)

        If Me.WindowState = FormWindowState.Maximized Then
            DrawRestoreButton(MaxButtonState)
        Else
            DrawMaxButton(MaxButtonState)
        End If

    End Sub

    Sub PaintTitlebarActive()
        Dim WinDC As IntPtr = Subclassing.GetWindowDC(Me.Handle)
        Dim BorderWidth As Int32 = (Me.Width - Me.ClientSize.Width) / 2 ' Subclassing.GetSystemMetrics(SM_CXFRAME)
        Dim ButtonSize As Int32 = Subclassing.GetSystemMetrics(SM_CXSIZE)
        Dim TitleBarWidth As Int32 = Me.Width
        'Dim TitleBarHeight As Int32 = (Me.Height - Me.ClientSize.Height) - BorderWidth ' Subclassing.GetSystemMetrics(SM_CYCAPTION)


        Dim TitleBarHeight As Int32 = Subclassing.GetSystemMetrics(SM_CYCAPTION)
        TitleBarHeight += BorderWidth

        Dim CommandBarWidth As Int32 = ButtonSize * 3
        Dim IconWidth As Int32 = Me.Icon.Width / 2
        Dim TitleBarTextAreaWidth As Int32 = TitleBarWidth - ((CommandBarWidth + IconWidth) / 2)

        Dim TextWidth As Integer = 0
        Dim TextHeight As Integer = 0

        'TitleBarHeight += 10

        Dim ColorTop As Color = Color.FromArgb(155, 187, 230)
        Dim ColorBottom As Color = Color.FromArgb(214, 226, 242)

        'ColorTop = Color.FromArgb(0, 0, 0)
        'ColorBottom = Color.FromArgb(220, 220, 220)

        Try
            Dim TitleBarCanvas As Graphics
            TitleBarCanvas = Graphics.FromHdc(WinDC)

            Dim PosX As Integer = CInt((TitleBarHeight - IconWidth) / 2)
            Dim PosY As Integer = PosX
            Dim myFont As New System.Drawing.Font(Me.Font.FontFamily, 10, FontStyle.Bold)

            'Me.ClientSize = New Size(350, 350)

            Try
                With TitleBarCanvas
                    TextWidth = .MeasureString(Me.Text, myFont).Width
                    TextHeight = .MeasureString(Me.Text, myFont).Height

                    'Top
                    Call DrawGradient(TitleBarCanvas, 0, 0, TitleBarWidth, TitleBarHeight, ColorTop, ColorBottom)
                    'Left
                    Call DrawGradient(TitleBarCanvas, 0, TitleBarHeight, BorderWidth, Height, ColorBottom, ColorTop)
                    'Right
                    Call DrawGradient(TitleBarCanvas, Width - BorderWidth, TitleBarHeight, BorderWidth, Height, ColorBottom, ColorTop)
                    'Bottom
                    Call DrawGradient(TitleBarCanvas, 0, Height - BorderWidth, TitleBarWidth, BorderWidth, ColorTop, ColorTop)

                    .DrawString(Me.Text, myFont, Brushes.White, (TitleBarTextAreaWidth - TextWidth + 75) / 2, (TitleBarHeight - TextHeight) / 2)
                    .DrawImage(Me.Icon.ToBitmap, PosX, PosY, IconWidth, IconWidth)
                End With
            Finally
                TitleBarCanvas.Dispose()
                myFont.Dispose()
            End Try
        Finally
            Subclassing.ReleaseDC(Me.Handle, WinDC)
        End Try

        Call SizeMenuButton()

        Me.Refresh()
    End Sub

#End Region

    'Ketika tombol utama diklik
    Private Sub Form1_ClickMainMenu(ByVal e As MainMenuArgs) Handles Me.ClickMainMenu
        'Menampilkan menu popup
        Me.ContextMenuStrip1.Show(e.Left, e.Top + e.Height)
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ganti teks pada tombol utama
        Me.MenuText = "PVBI Cool"
        Form2.Show()
    End Sub
     
End Class
