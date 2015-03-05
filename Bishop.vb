'Not Completed Bishop Movement
 ElseIf moving_piece.TypeIs = 4 Then
                If (x_sel - x_cur) / (y_sel - y_cur) = -1 Then
                    For i As Integer = x_sel - x_cur To x_sel
                        Dim pnl As Panel = DirectCast(board(i, i), Panel)
                        'if it has a piece the return false
                        If pnl.Controls.Count = 1 Then
                            Return False
                        End If
                        'if it went through all of them and nothing then return true
                        If i = x_sel Then
                            Return True
                        End If
                    Next
                ElseIf x_cur / y_cur = -1 Then
                    For i As Integer = x_cur To x_sel
                        Dim pnl As Panel = DirectCast(board(x_cur - i, x_cur + i), Panel)
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
 'Not Completed Bishop Attack
