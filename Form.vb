Option Strict On
Option Explicit On
Public Class Form1

    'get rid of attackmove
    'put all attack moves in the checkmove sub
    'do this by having another if statement

    'if panel.count > 0 then
    'takepiece(moving_piece, pnl_to_move_to)
    'end if

    'something along those lines
    'in takepiece, have another if statement

    'if piece.typeis = 1 (isn't a pawn the only one that has different attack parameters than when it moves?) then
    'if (x_cur - x_sel = 1 AndAlso y_cur - y_sel = 1) Or (x_cur - x_sel = -1 AndAlso y_cur - y_sel = 1) Then
    'exit if (the code continues on to delete the piece that is being attacked)
    'else
    'exit sub (nothing will happen because it was a failure)
    'end if
    'end if

    'then it returns false because the piece has already been moved, so the code won't go into movepiece()
    Private board(7, 7) As Panel
    Private p1turn As Boolean = True
    Private firstturn As Boolean = True
    Friend rook1 As Integer = 2
    Friend rook2 As Integer = 2
    Friend knight1 As Integer = 2
    Friend knight2 As Integer = 2
    Friend bishop1 As Integer = 2
    Friend bishop2 As Integer = 2
    Friend queen1 As Integer = 1
    Friend queen2 As Integer = 1
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

        'clears all controls on board
        Me.Controls.Clear()

        'loads board and pieces
        Call LoadBoard()
        Call LoadPieces()

        'player1 turn
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
                .PawnFirst = True
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
                .PawnFirst = True
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
                    .PawnFirst = False
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
                    .TypeIs = 2
                    .PawnFirst = False
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
                    .PawnFirst = False
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
                    .TypeIs = 3
                    .PawnFirst = False
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
                    .TypeIs = 4
                    .PawnFirst = False
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
                    .TypeIs = 4
                    .PawnFirst = False
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
                .TypeIs = 5
                .PawnFirst = False
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
                .TypeIs = 5
                .PawnFirst = False
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
                .TypeIs = 6
                .PawnFirst = False
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
                .TypeIs = 6
                .PawnFirst = False
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

        If Not (IsNothing(selected_piece)) AndAlso CheckMove(selected_piece, pnl_clicked) Then
            MovePiece(selected_piece, pnl_clicked)
        End If

    End Sub

    Private Sub piece_click(sender As Object, e As EventArgs)

        'Get piece that was just clicked
        Dim piece_clicked As Piece = DirectCast(sender, Piece)
        Dim attack_pnl As Panel = DirectCast(piece_clicked.Parent, Panel)

        If Not (IsNothing(selected_piece)) Then
            If piece_clicked Is selected_piece Then
                'Check to see if the selected pawn is the one that was just clicked
                'If it was, then just set selected pawn to nothing
                selected_piece.IsSelected = False
                selected_piece = Nothing
            ElseIf piece_clicked.Player <> selected_piece.Player Then
                If AttackMove(selected_piece, piece_clicked) Then
                    TakePiece(selected_piece, piece_clicked)
                Else
                    selected_piece.IsSelected = False
                    selected_piece = piece_clicked
                    piece_clicked.IsSelected = True
                End If
            Else
                selected_piece = piece_clicked
                piece_clicked.IsSelected = True
            End If
        Else
            selected_piece = piece_clicked
            piece_clicked.IsSelected = True
        End If

    End Sub

    Private Function CheckMove(ByVal moving_piece As Piece, ByVal pnl_to_move_to As Panel) As Boolean

        'Get the x and y number in the board for both panels declared above
        Dim x_sel, y_sel, x_cur, y_cur As Integer
        For col As Integer = 0 To board.GetUpperBound(0)
            For row As Integer = 0 To board.GetUpperBound(1)
                If board(col, row) Is pnl_to_move_to Then
                    x_sel = col
                    y_sel = row
                End If

                If board(col, row) Is DirectCast(moving_piece.Parent, Panel) Then
                    x_cur = col
                    y_cur = row
                End If
            Next
        Next

        'player 1
        If moving_piece.Player = 1 AndAlso p1turn Then
            'pawn piece
            If moving_piece.TypeIs = 1 Then
                'pawn hasn't moved yet
                If moving_piece.PawnFirst = True Then
                    If y_cur - y_sel > 0 AndAlso y_cur - y_sel < 3 AndAlso x_sel = x_cur Then
                        Return True
                    End If
                ElseIf y_cur - y_sel > 0 AndAlso y_cur - y_sel < 2 AndAlso x_sel = x_cur Then
                    Return True
                End If
                'rook piece
            ElseIf moving_piece.TypeIs = 2 Then
                If x_cur = x_sel Or y_sel = y_cur Then
                    If x_cur = x_sel Then
                        'for loop for all panels in a straight line on x
                        If y_cur - y_sel >= 1 Then
                            For i As Integer = y_sel To y_cur - 1
                                Dim pnl As Panel = DirectCast(board(x_sel, i), Panel)
                                'if it has a piece the return false
                                If pnl.Controls.Count = 1 Then
                                    Return False
                                End If
                                'if it went through all of them and nothing then return true
                                If i = y_cur - 1 Then
                                    Return True
                                End If
                            Next
                        ElseIf y_cur - y_sel <= -1 Then
                            For i As Integer = y_cur + 1 To y_sel
                                Dim pnl As Panel = DirectCast(board(x_sel, i), Panel)
                                'if it has a piece the return false
                                If pnl.Controls.Count = 1 Then
                                    Return False
                                End If
                                'if it went through all of them and nothing then return true
                                If i = y_sel Then
                                    Return True
                                End If
                            Next
                        End If
                    ElseIf y_cur = y_sel Then
                        'for loop for all panels in a straight line on y
                        If x_cur - x_sel >= 1 Then
                            For i As Integer = x_sel To x_cur - 1
                                Dim pnl As Panel = DirectCast(board(i, y_sel), Panel)
                                'if it has a piece the return false
                                If pnl.Controls.Count = 1 Then
                                    Return False
                                End If
                                'if it went through all of them and nothing then return true
                                If i = x_cur - 1 Then
                                    Return True
                                End If
                            Next
                        ElseIf x_cur - x_sel <= -1 Then
                            For i As Integer = x_cur + 1 To x_sel
                                Dim pnl As Panel = DirectCast(board(i, y_sel), Panel)
                                'if it has a piece the return false
                                If pnl.Controls.Count = 1 Then
                                    Return False
                                End If
                                'if it went through all of them and nothing then return true
                                If i = x_sel Then
                                    Return True
                                End If
                            Next
                        End If
                    End If
                End If
            End If
            'player 2
        ElseIf moving_piece.Player = 2 AndAlso Not (p1turn) Then
            'pawn piece
            If moving_piece.TypeIs = 1 Then
                'pawn hasn't moved yet
                If moving_piece.PawnFirst = True Then
                    If y_sel - y_cur > 0 AndAlso y_sel - y_cur < 3 AndAlso x_sel = x_cur Then
                        Return True
                    End If
                ElseIf y_sel - y_cur > 0 AndAlso y_sel - y_cur < 2 AndAlso x_sel = x_cur Then
                    Return True
                End If
            ElseIf moving_piece.TypeIs = 2 Then
                If x_cur = x_sel Or y_sel = y_cur Then
                    If x_cur = x_sel Then
                        'for loop for all panels in a straight line on x
                        If y_cur - y_sel >= 1 Then
                            For i As Integer = y_sel To y_cur - 1
                                Dim pnl As Panel = DirectCast(board(x_sel, i), Panel)
                                'if it has a piece the return false
                                If pnl.Controls.Count = 1 Then
                                    Return False
                                End If
                                'if it went through all of them and nothing then return true
                                If i = y_cur - 1 Then
                                    Return True
                                End If
                            Next
                        ElseIf y_cur - y_sel <= -1 Then
                            For i As Integer = y_cur + 1 To y_sel
                                Dim pnl As Panel = DirectCast(board(x_sel, i), Panel)
                                'if it has a piece the return false
                                If pnl.Controls.Count = 1 Then
                                    Return False
                                End If
                                'if it went through all of them and nothing then return true
                                If i = y_sel Then
                                    Return True
                                End If
                            Next
                        End If
                    ElseIf y_cur = y_sel Then
                        'for loop for all panels in a straight line on y
                        If x_cur - x_sel >= 1 Then
                            For i As Integer = x_sel To x_cur - 1
                                Dim pnl As Panel = DirectCast(board(i, y_sel), Panel)
                                'if it has a piece the return false
                                If pnl.Controls.Count = 1 Then
                                    Return False
                                End If
                                'if it went through all of them and nothing then return true
                                If i = x_cur - 1 Then
                                    Return True
                                End If
                            Next
                        ElseIf x_cur - x_sel <= -1 Then
                            For i As Integer = x_cur + 1 To x_sel
                                Dim pnl As Panel = DirectCast(board(i, y_sel), Panel)
                                'if it has a piece the return false
                                If pnl.Controls.Count = 1 Then
                                    Return False
                                End If
                                'if it went through all of them and nothing then return true
                                If i = x_sel Then
                                    Return True
                                End If
                            Next
                        End If
                    End If
                End If
            End If
        End If

        Return False

    End Function

    Private Sub MovePiece(ByVal moving_checker As Piece, ByVal pnl_to_move_to As Panel)

        'Unselect the moving checker
        moving_checker.IsSelected = False

        'Check if there's a winner winner chicken dinner
        'Call CheckWin()

        'Clear the controls from the old panel
        Dim moving_from_pnl As Panel = DirectCast(moving_checker.Parent, Panel)
        moving_from_pnl.Controls.Clear()

        'Add the checker to the new panel
        pnl_to_move_to.Controls.Add(moving_checker)

        'Get the y diminsion to see if we should make it a king
        'If moving_checker.TypeIs = 1 Then
        '    For x As Integer = 0 To board.GetUpperBound(0)
        '        For y As Integer = 0 To board.GetUpperBound(1)
        '            If board(x, y) Is pnl_to_move_to Then
        '                If moving_checker.Player = 1 AndAlso y = 0 Then
        '                    'moving_checker.IsKing = True
        '                ElseIf moving_checker.Player = 2 AndAlso y = 7 Then
        '                    'moving_checker.IsKing = True
        '                End If
        '                Exit For
        '            End If
        '        Next
        '    Next
        'End If

        If moving_checker.TypeIs = 1 Then
            moving_checker.PawnFirst = False
        End If

        'It's the other person's turn
        p1turn = Not (p1turn)

        'Set the selected_checker to nothing
        selected_piece = Nothing

    End Sub

    Private Function AttackMove(ByVal attacker As Piece, ByVal victim As Piece) As Boolean

        'Get the x and y number in the board for both panels declared above
        Dim x_sel, y_sel, x_cur, y_cur As Integer
        For col As Integer = 0 To board.GetUpperBound(0)
            For row As Integer = 0 To board.GetUpperBound(1)
                If board(col, row) Is DirectCast(victim.Parent, Panel) Then
                    x_sel = col
                    y_sel = row
                End If

                If board(col, row) Is DirectCast(attacker.Parent, Panel) Then
                    x_cur = col
                    y_cur = row
                End If
            Next
        Next

        If attacker.Player = 1 AndAlso p1turn Then
            If attacker.TypeIs = 1 Then
                If (x_cur - x_sel = 1 AndAlso y_cur - y_sel = 1) Or (x_cur - x_sel = -1 AndAlso y_cur - y_sel = 1) Then
                    Return True
                End If
            ElseIf attacker.TypeIs = 2 Then
                
                If x_sel = x_cur Then
                    If y_cur - y_sel > 0 Then
                        For i As Integer = y_sel To y_cur
                            Dim pnl As Panel = DirectCast(board(x_sel, i), Panel)
                            Dim vicpnl As Panel = DirectCast(victim.Parent, Panel)
                            Dim attpnl As Panel = DirectCast(attacker.Parent, Panel)
                            If pnl.Controls.Count = 1 And pnl IsNot vicpnl And pnl IsNot attpnl Then
                                Return False
                            ElseIf i = y_cur - 1 Then
                                Return True
                            End If
                        Next
                    ElseIf y_cur - y_sel < 0 Then
                        For i As Integer = y_cur To y_sel
                            Dim pnl As Panel = DirectCast(board(x_sel, i), Panel)
                            Dim vicpnl As Panel = DirectCast(victim.Parent, Panel)
                            Dim attpnl As Panel = DirectCast(attacker.Parent, Panel)
                            If pnl.Controls.Count = 1 And pnl IsNot vicpnl And pnl IsNot attpnl Then
                                Return False
                            ElseIf i = y_sel - 1 Then
                                Return True
                            End If
                        Next
                    End If
                ElseIf y_sel = y_cur Then
                    If x_cur - x_sel > 0 Then
                        For i As Integer = x_sel To x_cur
                            Dim pnl As Panel = DirectCast(board(i, y_sel), Panel)
                            Dim vicpnl As Panel = DirectCast(victim.Parent, Panel)
                            Dim attpnl As Panel = DirectCast(attacker.Parent, Panel)
                            If pnl.Controls.Count = 1 And pnl IsNot vicpnl And pnl IsNot attpnl Then
                                Return False
                            ElseIf i = x_cur - 1 Then
                                Return True
                            End If
                        Next
                    ElseIf x_cur - x_sel < 0 Then
                        For i As Integer = x_cur To x_sel
                            Dim pnl As Panel = DirectCast(board(i, y_sel), Panel)
                            Dim vicpnl As Panel = DirectCast(victim.Parent, Panel)
                            Dim attpnl As Panel = DirectCast(attacker.Parent, Panel)
                            If pnl.Controls.Count = 1 And pnl IsNot vicpnl And pnl IsNot attpnl Then
                                Return False
                            ElseIf i = x_sel - 1 Then
                                Return True
                            End If
                        Next
                    End If
                End If

                End If
        ElseIf attacker.Player = 2 AndAlso Not p1turn Then
            If attacker.TypeIs = 1 Then
                If (x_sel - x_cur = -1 AndAlso y_sel - y_cur = 1) Or (x_sel - x_cur = 1 AndAlso y_sel - y_cur = 1) Then
                    Return True
                End If
            ElseIf attacker.TypeIs = 2 Then

                If x_sel = x_cur Then
                    If y_sel - y_cur > 0 Then
                        For i As Integer = y_cur To y_sel
                            Dim pnl As Panel = DirectCast(board(x_sel, i), Panel)
                            Dim vicpnl As Panel = DirectCast(victim.Parent, Panel)
                            Dim attpnl As Panel = DirectCast(attacker.Parent, Panel)
                            If pnl.Controls.Count = 1 And pnl IsNot vicpnl And pnl IsNot attpnl Then
                                Return False
                            ElseIf i = y_sel - 1 Then
                                Return True
                            End If
                        Next
                    ElseIf y_sel - y_cur < 0 Then
                        For i As Integer = y_cur To y_sel
                            Dim pnl As Panel = DirectCast(board(x_sel, i), Panel)
                            Dim vicpnl As Panel = DirectCast(victim.Parent, Panel)
                            Dim attpnl As Panel = DirectCast(attacker.Parent, Panel)
                            If pnl.Controls.Count = 1 And pnl IsNot vicpnl And pnl IsNot attpnl Then
                                Return False
                            ElseIf i = y_cur - 1 Then
                                Return True
                            End If
                        Next
                    End If
                ElseIf y_sel = y_cur Then
                    If x_sel - x_cur > 0 Then
                        For i As Integer = x_cur To x_sel
                            Dim pnl As Panel = DirectCast(board(i, y_sel), Panel)
                            Dim vicpnl As Panel = DirectCast(victim.Parent, Panel)
                            Dim attpnl As Panel = DirectCast(attacker.Parent, Panel)
                            If pnl.Controls.Count = 1 And pnl IsNot vicpnl And pnl IsNot attpnl Then
                                Return False
                            ElseIf i = x_sel - 1 Then
                                Return True
                            End If
                        Next
                    ElseIf x_sel - x_cur < 0 Then
                        For i As Integer = x_sel To x_cur
                            Dim pnl As Panel = DirectCast(board(i, y_sel), Panel)
                            Dim vicpnl As Panel = DirectCast(victim.Parent, Panel)
                            Dim attpnl As Panel = DirectCast(attacker.Parent, Panel)
                            If pnl.Controls.Count = 1 And pnl IsNot vicpnl And pnl IsNot attpnl Then
                                Return False
                            ElseIf i = x_cur - 1 Then
                                Return True
                            End If
                        Next
                    End If
                End If

            End If
        End If

        Return False

    End Function

    Private Sub TakePiece(ByVal attacker As Piece, ByVal victim As Piece)

        'Unselect the moving checker
        attacker.IsSelected = False

        'Clear the controls from the old panel
        Dim moving_from_pnl As Panel = DirectCast(attacker.Parent, Panel)
        moving_from_pnl.Controls.Clear()

        'Add the checker to the new panel
        Dim victim_place As Panel = DirectCast(victim.Parent, Panel)
        victim_place.Controls.Clear()
        victim_place.Controls.Add(attacker)

        'Get the y diminsion to see if we should make it a king
        'If moving_checker.TypeIs = 1 Then
        '    For x As Integer = 0 To board.GetUpperBound(0)
        '        For y As Integer = 0 To board.GetUpperBound(1)
        '            If board(x, y) Is pnl_to_move_to Then
        '                If moving_checker.Player = 1 AndAlso y = 0 Then
        '                    'moving_checker.IsKing = True
        '                ElseIf moving_checker.Player = 2 AndAlso y = 7 Then
        '                    'moving_checker.IsKing = True
        '                End If
        '                Exit For
        '            End If
        '        Next
        '    Next
        'End If

        If attacker.TypeIs = 1 Then
            attacker.PawnFirst = False
        End If

        'It's the other person's turn
        p1turn = Not (p1turn)

        'Set the selected_checker to nothing
        selected_piece = Nothing

        'Check if there's a winner winner chicken dinner
        Call CheckWin(victim)

    End Sub

    Private Sub CheckWin(sender As Piece)

        Dim p1_count As Integer = 1
        Dim p2_count As Integer = 1

        ''Loop through the board
        'For x As Integer = 0 To board.GetUpperBound(0)
        '    For y As Integer = 0 To board.GetUpperBound(1)
        '        'Check if the panel has a checker
        '        If board(x, y).Controls.Count > 0 Then
        '            'Check if the checker is p1 or p2
        '            Dim check As Piece = DirectCast(board(x, y).Controls(0), Piece)

        '            If check.Player = 1 Then
        '                p1_count += 1
        '            ElseIf check.Player = 2 Then
        '                p2_count += 1
        '            End If
        '        End If
        '    Next
        'Next

        If sender.TypeIs = 5 Then
            If sender.Player = 1 Then
                p1_count = 0
            ElseIf sender.Player = 2 Then
                p2_count = 0
            End If
        End If

        'Check if p1 or p2 count is 0
        If p1_count = 0 Then
            MessageBox.Show("Player2 wins!")

            Call NewGame()
        ElseIf p2_count = 0 Then
            MessageBox.Show("Player1 wins!")

            Call NewGame()
        End If

    End Sub
End Class
