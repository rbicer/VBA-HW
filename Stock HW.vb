Sub Multiper_Year_Ticker()
For Each ws In Worksheets
    Dim Ticker_Name As String
    Dim Ticker_Row As Double
    Dim Total_Volume As Double
    Dim Table_Row As Integer
    Dim Row_Counter As Double
    Dim Open_Value As Double
    Dim First_Row As Double
    Dim Last_Row As Double
    Dim Change As Double
    Dim iRow As Long
    Ticker_Row = 0
    Table_Row = 2
    Row_Counter = 1
    First_Row = 0
    Close_Value = 0
    Open_Value = 0
    Change = 0
    iRow = ws.Cells(Rows.Count, 1).End(xlUp).Row
    For I = 2 To iRow
        Row_Counter = Row_Counter + 1
        If ws.Cells(I + 1, 1).Value <> ws.Cells(I, 1).Value Then
            Ticker_Name = ws.Cells(I, 1).Value
            Ticker_Row = Ticker_Row + 1
            Total_Volume = Total_Volume + ws.Cells(I, 7).Value
            First_Row = Row_Counter - Ticker_Row + 1
            Close_Value = ws.Cells(Row_Counter, 6).Value
            Open_Value = ws.Cells(First_Row, 3).Value
            Change = Close_Value - Open_Value
            ws.Range("I" & Table_Row).Value = Ticker_Name
            ws.Range("J" & Table_Row).Value = Change
            ws.Range("L" & Table_Row).Value = Total_Volume
            If Open_Value = 0 Then
                Open_Value = Open_Value + 0.0001
            End If
            ws.Range("K" & Table_Row).Value = (Change / Open_Value) * 100
            Table_Row = Table_Row + 1
            Total_Volume = 0
            Ticker_Row = 0
        Else
            Total_Volume = Total_Volume + ws.Cells(I, 7).Value
            Ticker_Row = Ticker_Row + 1
        End If
    Next I
    For I = 2 To iRow
        If ws.Cells(I, 10).Value > 0 Then
            ws.Cells(I, 10).Interior.ColorIndex = 4
        End If
        If ws.Cells(I, 10).Value < 0 Then
            ws.Cells(I, 10).Interior.ColorIndex = 3
        End If
    Next I
    Dim Greater As Double
    Dim Great_Ticker As String
    Dim Short_Ticker As String
    Dim Shorter As Double
    Dim T_GTV As String
    Dim GTV As Double
    Greater = ws.Cells(2, 11).Value
    For I = 2 To iRow
        If Greater < ws.Cells(I + 1, 11).Value Then
            Greater = ws.Cells(I + 1, 11).Value
            Great_Ticker = ws.Cells(I + 1, 9).Value
            ws.Cells(2, 16).Value = Great_Tickerju8
            ws.Cells(2, 18).Value = ws.Cells(I + 1, 12).Value
        End If
    Next I
    Shorter = ws.Cells(2, 11).Value
    For j = 2 To iRow
        If ws.Cells(j + 1, 11).Value < Shorter Then
            Shorter = ws.Cells(j + 1, 11).Value
            ws.Cells(3, 17).Value = Shorter
            Shorter_Ticker = ws.Cells(j + 1, 9).Value
            ws.Cells(3, 16).Value = Shorter_Ticker
            ws.Cells(3, 18).Value = ws.Cells(j + 1, 12).Value
        End If
    Next j
    GTV = ws.Cells(2, 12).Value
    For k = 2 To iRow
        If ws.Cells(k + 1, 12).Value > GTV Then
            GTV = ws.Cells(k + 1, 12).Value
            ws.Cells(4, 17).Value = GTV
            T_GTV = ws.Cells(k + 1, 9).Value
            ws.Cells(4, 16).Value = T_GTV
            ws.Cells(4, 18).Value = ws.Cells(k + 1, 12).Value
        End If
    Next k
Next ws
End Sub
