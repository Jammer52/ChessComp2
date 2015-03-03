# ChessComp2
Computer Programming 2 Collaboration Project

Option Strict On
Option Explicit On
Public Class Form1

    Private board(7, 7) As Panel
    Private p1turn As Boolean = True
    Friend rook1 As Integer = 0
    Friend rook2 As Integer = 0
    Friend knight1 As Integer = 0
    Friend knight2 As Integer = 0
    Friend bishop1 As Integer = 0
    Friend bishop2 As Integer = 0
    Friend queen1 As Integer = 0
    Friend queen2 As Integer = 0
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Set up a new game
        Call NewGame()

        'Get the title width and height to later set the form's size
        Dim title_wid As Integer = CInt(Me.Width - Me.ClientSize.Width)
        Dim title_hei As Integer = CInt(Me.Height - Me.ClientSize.Height)

        'Set the form's properties
        With Me
            .Size = New Size(8 * 55 + title_wid, 8 * 55 + title_hei)
            .StartPosition = FormStartPosition.CenterScreen
            .Text = "Chess"
        End With

    End Sub

    Private Sub NewGame()

        Me.Controls.Clear()

        Call LoadBoard()
        Call LoadPieces()

        p1turn = True

    End Sub

    Private Sub LoadBoard()

        'Nested loop from 0 to 7 for both dimensions
        For x As Integer = 0 To board.GetUpperBound(0)
            For y As Integer = 0 To board.GetUpperBound(1)

                'A panel will hold our checker
                Dim pnl As New Panel
                With pnl
                    'Make the checkered pattern by checking if we're on an odd or even x
                    'Then alternated based if y is odd or even
                    If CBool(x Mod 2) Then
                        If CBool(y Mod 2) Then
                            .BackColor = Color.SaddleBrown
                        Else
                            .BackColor = Color.Peru
                        End If
                    Else
                        If CBool(y Mod 2) Then
                            .BackColor = Color.Peru
                        Else
                            .BackColor = Color.SaddleBrown
                        End If
                    End If
                    .BorderStyle = BorderStyle.FixedSingle
                    .Location = New Point(x * 55, y * 55)
                    .Size = New Size(55, 55)
                End With

                'Add the panel to the board and to the form
                board(x, y) = pnl
                Me.Controls.Add(pnl)

                'Add the click event handler
                AddHandler pnl.Click, AddressOf pnl_click
            Next
        Next

    End Sub

    Private Sub LoadPieces()

        Dim y As Integer = 1
        Dim x As Integer

        For i As Integer = 0 To 7
            'Set up a new check and set the properties
            Dim check As New Piece
            With check
                .BackColor = Color.Black
                .IsSelected = False
                .Location = New Point(2, 2)
                .Player = 2
                .Size = New Size(50, 50)
                .TypeIs = 1
            End With

            'Add the checker to the panel
            board(i, y).Controls.Add(check)

            'Set up the event handler
            AddHandler check.Click, AddressOf piece_click
        Next

        'Do the same thing as above, only for the last 3 rows of our board
        y = 6

        For i As Integer = 0 To 7
            Dim check As New Piece
            With check
                .BackColor = Color.White
                .IsSelected = False
                .Location = New Point(2, 2)
                .Player = 1
                .Size = New Size(50, 50)
                .TypeIs = 1
            End With

            board(i, y).Controls.Add(check)
            AddHandler check.Click, AddressOf piece_click
        Next

        y = 0

        For i As Integer = 0 To 7
            If i = 0 Or i = 7 Then
                'Set up a new check and set the properties
                Dim check As New Piece
                With check
                    .BackColor = Color.Black
                    .IsSelected = False
                    .Location = New Point(2, 2)
                    .Player = 2
                    .Size = New Size(50, 50)
                    .TypeIs = 2
                End With

                'Add the checker to the panel
                board(i, y).Controls.Add(check)

                'Set up the event handler
                AddHandler check.Click, AddressOf piece_click
            End If
        Next

        y = 7

        For i As Integer = 0 To 7
            If i = 0 Or i = 7 Then
                'Set up a new check and set the properties
                Dim check As New Piece
                With check
                    .BackColor = Color.White
                    .IsSelected = False
                    .Location = New Point(2, 2)
                    .Player = 1
                    .Size = New Size(50, 50)
                    .typeis = 2
                End With

                'Add the checker to the panel
                board(i, y).Controls.Add(check)

                'Set up the event handler
                AddHandler check.Click, AddressOf piece_click
            End If
        Next

        y = 0

        For i As Integer = 0 To 7
            If i = 1 Or i = 6 Then
                'Set up a new check and set the properties
                Dim check As New Piece
                With check
                    .BackColor = Color.Black
                    .IsSelected = False
                    .Location = New Point(2, 2)
                    .Player = 2
                    .Size = New Size(50, 50)
                    .TypeIs = 3
                End With

                'Add the checker to the panel
                board(i, y).Controls.Add(check)

                'Set up the event handler
                AddHandler check.Click, AddressOf piece_click
            End If
        Next

        y = 7

        For i As Integer = 0 To 7
            If i = 1 Or i = 6 Then
                'Set up a new check and set the properties
                Dim check As New Piece
                With check
                    .BackColor = Color.White
                    .IsSelected = False
                    .Location = New Point(2, 2)
                    .Player = 1
                    .Size = New Size(50, 50)
                    .typeis = 3
                End With

                'Add the checker to the panel
                board(i, y).Controls.Add(check)

                'Set up the event handler
                AddHandler check.Click, AddressOf piece_click
            End If
        Next

        y = 0

        For i As Integer = 0 To 7
            If i = 2 Or i = 5 Then
                'Set up a new check and set the properties
                Dim check As New Piece
                With check
                    .BackColor = Color.Black
                    .IsSelected = False
                    .Location = New Point(2, 2)
                    .Player = 2
                    .Size = New Size(50, 50)
                    .typeis = 4
                End With

                'Add the checker to the panel
                board(i, y).Controls.Add(check)

                'Set up the event handler
                AddHandler check.Click, AddressOf piece_click
            End If
        Next

        y = 7

        For i As Integer = 0 To 7
            If i = 2 Or i = 5 Then
                'Set up a new check and set the properties
                Dim check As New Piece
                With check
                    .BackColor = Color.White
                    .IsSelected = False
                    .Location = New Point(2, 2)
                    .Player = 1
                    .Size = New Size(50, 50)
                    .typeis = 4
                End With

                'Add the checker to the panel
                board(i, y).Controls.Add(check)

                'Set up the event handler
                AddHandler check.Click, AddressOf piece_click
            End If
        Next

        y = 0
        x = 3

        If x = 3 Then
            'Set up a new check and set the properties
            Dim check As New Piece
            With check
                .BackColor = Color.Black
                .IsSelected = False
                .Location = New Point(2, 2)
                .Player = 2
                .Size = New Size(50, 50)
                .typeis = 5
            End With

            'Add the checker to the panel
            board(x, y).Controls.Add(check)

            'Set up the event handler
            AddHandler check.Click, AddressOf piece_click
        End If

        y = 7
        x = 3

        If x = 3 Then
            'Set up a new check and set the properties
            Dim check As New Piece
            With check
                .BackColor = Color.White
                .IsSelected = False
                .Location = New Point(2, 2)
                .Player = 1
                .Size = New Size(50, 50)
                .typeis = 5
            End With

            'Add the checker to the panel
            board(x, y).Controls.Add(check)

            'Set up the event handler
            AddHandler check.Click, AddressOf piece_click
        End If

        y = 0
        x = 4

        If x = 4 Then
            'Set up a new check and set the properties
            Dim check As New Piece
            With check
                .BackColor = Color.Black
                .IsSelected = False
                .Location = New Point(2, 2)
                .Player = 2
                .Size = New Size(50, 50)
                .typeis = 6
            End With

            'Add the checker to the panel
            board(x, y).Controls.Add(check)

            'Set up the event handler
            AddHandler check.Click, AddressOf piece_click
        End If

        y = 7
        x = 4

        If x = 4 Then
            'Set up a new check and set the properties
            Dim check As New Piece
            With check
                .BackColor = Color.White
                .IsSelected = False
                .Location = New Point(2, 2)
                .Player = 1
                .Size = New Size(50, 50)
                .typeis = 6
            End With

            'Add the checker to the panel
            board(x, y).Controls.Add(check)

            'Set up the event handler
            AddHandler check.Click, AddressOf piece_click
        End If

    End Sub

    Private selected_piece As Piece
    Private Sub pnl_click(sender As Object, e As EventArgs)

        'Get the panel that was just clicked
        Dim pnl_clicked As Panel = DirectCast(sender, Panel)

    End Sub

    Private Sub piece_click(sender As Object, e As EventArgs)

        Dim piece_clicked As Piece = DirectCast(sender, Piece)

        If Not (IsNothing(selected_piece)) AndAlso selected_piece.Player = piece_clicked.Player Then
            If piece_clicked Is selected_piece Then
                'Check to see if the selected pawn is the one that was just clicked
                'If it was, then just set selected pawn to nothing
                selected_piece.IsSelected = False
                selected_piece = Nothing
            Else
                'If it wasn't the pawn that was just clicked then select it
                selected_piece = piece_clicked
                piece_clicked.IsSelected = True
            End If
        ElseIf selected_piece.Player = piece_clicked.Player Then
            'If it wasn't the pawn that was just clicked then select it
            selected_piece = piece_clicked
            piece_clicked.IsSelected = True
        ElseIf selected_piece.Player <> piece_clicked.Player Then
            AttackMove(piece_clicked, selected_piece)
        End If

    End Sub

    Private Function CheckMove(ByVal moving_obj As Piece, ByVal pnl_to_move_to As Panel) As Boolean

        Return False

    End Function

    Private Sub MovePiece(ByVal moving_piece As Piece, ByVal pnl_to_move_to As Panel)



    End Sub

    Private Sub AttackMove(ByVal attacker As Piece, ByVal victim As Piece)

        If attacker.Player <> victim.Player Then

        Else

        End If

    End Sub
End Class
