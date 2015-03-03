Option Strict On
Option Explicit On
Public Class Piece
    Inherits Control

    Private selected As Boolean
    Public Property IsSelected() As Boolean
        Get
            Return selected
        End Get
        Set(ByVal value As Boolean)
            selected = value
        End Set
    End Property

    Private _player As Integer
    Public Property Player() As Integer
        Get
            Return _player
        End Get
        Set(ByVal value As Integer)
            _player = value
        End Set
    End Property

    Private _type As Integer
    Public Property TypeIs() As Integer
        Get
            Return _type
        End Get
        Set(ByVal value As Integer)
            _type = value
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim path As New Drawing2D.GraphicsPath
        Dim rect As Rectangle = Me.DisplayRectangle

        rect.Inflate(-1, -1)

        e.Graphics.DrawEllipse(New Pen(Brushes.Black, 3), rect)

        rect.Inflate(-1, -1)

        e.Graphics.FillEllipse(New SolidBrush(Me.BackColor), rect)

        rect.Inflate(2, 2)

        path.AddEllipse(rect)

        Me.Region = New Region(path)

        If Player = 1 Then
            If Me.TypeIs = 1 Then
                e.Graphics.DrawString("Pa", Me.Font, Brushes.Black, New PointF(CSng(Me.Width / 2 - Me.FontHeight / 2), CSng(Me.Height / 2 - Me.FontHeight / 2)))
            ElseIf Me.TypeIs = 2 Then
                e.Graphics.DrawString("Rk", Me.Font, Brushes.Black, New PointF(CSng(Me.Width / 2 - Me.FontHeight / 2), CSng(Me.Height / 2 - Me.FontHeight / 2)))
            ElseIf Me.TypeIs = 3 Then
                e.Graphics.DrawString("Kt", Me.Font, Brushes.Black, New PointF(CSng(Me.Width / 2 - Me.FontHeight / 2), CSng(Me.Height / 2 - Me.FontHeight / 2)))
            ElseIf Me.TypeIs = 4 Then
                e.Graphics.DrawString("B", Me.Font, Brushes.Black, New PointF(CSng(Me.Width / 2 - Me.FontHeight / 2), CSng(Me.Height / 2 - Me.FontHeight / 2)))
            ElseIf Me.TypeIs = 5 Then
                e.Graphics.DrawString("K", Me.Font, Brushes.Black, New PointF(CSng(Me.Width / 2 - Me.FontHeight / 2), CSng(Me.Height / 2 - Me.FontHeight / 2)))
            ElseIf Me.TypeIs = 6 Then
                e.Graphics.DrawString("Q", Me.Font, Brushes.Black, New PointF(CSng(Me.Width / 2 - Me.FontHeight / 2), CSng(Me.Height / 2 - Me.FontHeight / 2)))
            End If
        Else
            If Me.TypeIs = 1 Then
                e.Graphics.DrawString("Pa", Me.Font, Brushes.White, New PointF(CSng(Me.Width / 2 - Me.FontHeight / 2), CSng(Me.Height / 2 - Me.FontHeight / 2)))
            ElseIf Me.TypeIs = 2 Then
                e.Graphics.DrawString("Rk", Me.Font, Brushes.White, New PointF(CSng(Me.Width / 2 - Me.FontHeight / 2), CSng(Me.Height / 2 - Me.FontHeight / 2)))
            ElseIf Me.TypeIs = 3 Then
                e.Graphics.DrawString("Kt", Me.Font, Brushes.White, New PointF(CSng(Me.Width / 2 - Me.FontHeight / 2), CSng(Me.Height / 2 - Me.FontHeight / 2)))
            ElseIf Me.TypeIs = 4 Then
                e.Graphics.DrawString("B", Me.Font, Brushes.White, New PointF(CSng(Me.Width / 2 - Me.FontHeight / 2), CSng(Me.Height / 2 - Me.FontHeight / 2)))
            ElseIf Me.TypeIs = 5 Then
                e.Graphics.DrawString("K", Me.Font, Brushes.White, New PointF(CSng(Me.Width / 2 - Me.FontHeight / 2), CSng(Me.Height / 2 - Me.FontHeight / 2)))
            ElseIf Me.TypeIs = 6 Then
                e.Graphics.DrawString("Q", Me.Font, Brushes.White, New PointF(CSng(Me.Width / 2 - Me.FontHeight / 2), CSng(Me.Height / 2 - Me.FontHeight / 2)))
            End If
        End If
    End Sub
End Class
