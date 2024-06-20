Imports System.Data.OleDb
Imports System.Threading

Public Class Main

    Private Sub Newlot_btn_Click(sender As Object, e As EventArgs) Handles Newlot_btn.Click
        Dim reset As String
        reset = MsgBox("All existing data will be lost!", vbYesNo, vbInformation)
        If reset = vbYes Then
            _clear()

            Others.ShowDialog()
            With Others
                .fuse_res_rad.Checked = False
                .str_wire_rad.Checked = False
                .corrug_res_rad.Checked = False
                .wound_res_rad.Checked = False
                .Product_box.Items.Clear()
                .Product_box.Text = Nothing
                .Partnum_box.Items.Clear()
                .Partnum_box.Text = Nothing
                .Lot_txt.Text = ""
                .Associate_box.Items.Clear()
                .Associate_box.Text = Nothing
                .Shift_box.SelectedText = Nothing
                .Shift_box.Text = Nothing
            End With
        End If

    End Sub
    Public Sub _clear()
        Array.Clear(res, 0, res.Length)
        get_message = ""
        count = 0
        resave = False
        Result_list.Enabled = True
        Result_list.Items.Clear()
        Newlot_list.Items.Clear()
        Start_btn.Enabled = False
        Read_btn.Enabled = False
        Export_btn.Visible = False
        Label3.ForeColor = Color.LightGray
        Label4.ForeColor = Color.LightGray
        Label5.ForeColor = Color.LightGray


    End Sub

    Private Sub Start_btn_Click(sender As Object, e As EventArgs) Handles Start_btn.Click

        If COM_box.Text IsNot "" Then
            Try
                If SerialPort1.IsOpen = False Then
                    SerialPort1.PortName = COM_box.Text
                    SerialPort1.BaudRate = "9600"
                    SerialPort1.Open()
                End If
                Label4.ForeColor = Color.Green
                Read_btn.Enabled = True
                PictureBox3.Visible = False
                Start_btn.Enabled = False
                COM_box.Enabled = False
                To_Tegam()
                If product_type = "fuse" Then
                    minimum = minimum / multi
                    maximum = maximum / multi
                End If

            Catch ex As Exception
                MsgBox(ex.Message, vbCritical)
            End Try
        Else
            PictureBox3.Visible = True
            MsgBox("Please select port number", vbInformation)
        End If

    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        For Each sp As String In My.Computer.Ports.SerialPortNames
            COM_box.Items.Add(sp)
        Next
        Newlot_btn.Enabled = True
        Start_btn.Enabled = False
        Read_btn.Enabled = False
        Export_btn.Visible = False

        Console.WriteLine("Grant Git")
    End Sub

    Private Sub Connect_btn_Click(sender As Object, e As EventArgs)

    End Sub

    Dim obj As Object
    Dim comcount As Integer
    Public rating As Decimal
    Public nominal As Decimal
    Public minimum As Decimal
    Public maximum As Decimal
    Public HighLim As Decimal
    Public meteropen As String
    Public strRange As String
    Public TegamTrig As String
    Public multi As Decimal
    Public divide As Decimal = 1
    Const limit200ohm = 18000
    Const limit20ohm = 1800
    Const limit2ohm = 180
    Const limit200mohm = 18
    Const limit20mohm = 1.8
    Const limit2mohm = 0.18
    Public strRangeTxt As String
    Public product_type As String

    Public Sub To_Tegam()
        Select Case product_type
            Case "fuse"
                If maximum > limit20ohm Then
                    If rating >= 0.1 Then
                        strRange = "R8"
                        strRangeTxt = strRange & "  10mA 20 Ohm"
                    Else
                        strRange = "R9"
                        strRangeTxt = strRange & "  1mA 20 Ohm"
                    End If
                    meteropen = "29.999"
                    multi = 1000
                ElseIf maximum > limit2ohm Then
                    If rating >= 1 Then
                        strRange = "R6"
                        strRangeTxt = strRange & "  100mA 2 Ohm"
                        meteropen = "2.9999"
                        multi = 1000
                    ElseIf rating >= 0.1 Then
                        strRange = "R7"
                        strRangeTxt = strRange & "  10mA 2 Ohm"
                        meteropen = "2.9999"
                        multi = 1000
                    Else
                        strRange = "R9"
                        strRangeTxt = strRange & "  1mA 20 Ohm"
                        meteropen = "29.999"
                        multi = 1000
                    End If
                ElseIf maximum > limit200mohm Then      ' Go to 200 mohm range
                    If rating >= 1 Then
                        strRange = "R5"
                        strRangeTxt = strRange & "  100mA 200 mOhm"
                        meteropen = "299.99"
                        multi = 1
                    ElseIf rating >= 10 Then
                        strRange = "R4"
                        strRangeTxt = strRange & "  1A 200 mOhm"
                        meteropen = "299.99"
                        multi = 1
                    Else
                        strRange = "R7"
                        strRangeTxt = strRange & "  10mA 2 Ohm"
                        meteropen = "2.9999"
                        multi = 1000
                    End If
                ElseIf maximum > limit20mohm Then     ' Go to 20 mohm range
                    If rating >= 10 Then
                        strRange = "R2"
                        strRangeTxt = strRange & "  1A 20 mOhm"
                        meteropen = "29.999"
                        multi = 1
                    ElseIf rating >= 1 Then
                        strRange = "R3"
                        strRangeTxt = strRange & "  100mA 20 mOhm"
                        meteropen = "29.999"
                        multi = 1
                    Else
                        strRange = "R7"
                        strRangeTxt = strRange & "  10mA 2 Ohm"
                        meteropen = "2.9999"
                        multi = 1000
                    End If
                Else                          ' Go to 2 mohm range
                    If rating >= 10 Then
                        strRange = "R1"
                        strRangeTxt = strRange & "  1A 2 mOhm"
                        meteropen = "2.9999"
                        multi = 1
                    Else
                        strRange = "R7"
                        strRangeTxt = strRange & "  10mA 2 Ohm"
                        meteropen = "2.9999"
                        multi = 1000

                        'Else
                        '    strRange = "R3"
                        '    strRangeTxt = strRange & "  100mA 20 mOhm"
                        '    meteropen = "29.999"
                        '    multi = 1
                    End If
                End If
            Case "wire"
                If rating >= 10 Then
                    strRange = "R6" 'R1
                    strRangeTxt = strRange & "  100mA 2 Ohm" '1A 2mOhm
                    meteropen = "2.9999"
                    multi = 1
                ElseIf rating >= 1 Then
                    strRange = "R6"
                    strRangeTxt = strRange & "  100mA 2 Ohm"
                    meteropen = "2.9999"
                    multi = 1
                ElseIf rating >= 0.1 Then
                    strRange = "R7"
                    strRangeTxt = strRange & "  10mA 2 Ohm"
                    meteropen = "2.9999"
                    multi = 1
                    If maximum > limit2mohm Then
                        strRange = "R8"
                        strRangeTxt = strRange & "  10mA 20 Ohm"
                        meteropen = "29.999"
                        multi = 1
                    End If

                Else
                        strRange = "R9"
                    strRangeTxt = strRange & "  1mA 20 Ohm"
                    meteropen = "29.999"
                    multi = 1
                End If
        End Select
        Try
            range_lbl.Text = strRangeTxt
            Console.WriteLine(strRangeTxt)
            SerialPort1.Write(strRange & vbCr) 'set range
            SerialPort1.Write("X" & vbCr)
            SerialPort1.Write("P0" & vbCr) 'display resistance mode
            SerialPort1.Write("X" & vbCr)
            SerialPort1.Write("T3" & vbCr) 'delay one shot on talk
            SerialPort1.Write("X" & vbCr)
            SerialPort1.Write("D001" & vbCr) 'delay set to 1ms
            SerialPort1.Write("X" & vbCr)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub Read_btn_Click(sender As Object, e As EventArgs)
        Try
            SerialPort1.WriteLine("E" & vbCr)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try


    End Sub
    Public TegamRead As Object
    Public res(5000) As Decimal
    Private Sub SerialPort1_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        TegamRead = SerialPort1.ReadLine()
        TegamRead = TegamRead.Substring(0, 6)
        If TegamRead = meteropen Then
            MsgBox("Open fuse!", vbExclamation)
            'additional sequence to discard OOS
        Else
            'MsgBox(maximum & vbCr & TegamRead)
            If product_type = "fuse" Then
                If TegamRead < minimum Or TegamRead > maximum Then
                    MsgBox("OOS detected!" & vbCr & "data will be discarded" & vbCr & "Resistance = " & TegamRead, vbInformation)
                Else
                    _read()
                End If
            Else
                _read()
            End If

        End If


    End Sub
    Public count As Integer
    Public sample_qty As Integer
    Public Sub _read()
        res(count) = CDec(TegamRead)
        count += 1
        Result_list.Items.Add(count & ") " & TegamRead)
        If count >= sample_qty Then
            Read_btn.Enabled = False
            Label5.ForeColor = Color.Green
            Newlot_btn.Enabled = True
            export()
        End If
    End Sub
    Public resave As Boolean
    Public partnum As String
    Public product As String
    Public lotnum As String
    Public associate As String
    Public shift As String
    Public Sub export()
        If Not resave Then

            For x As Integer = 0 To res.Length - 1
                If res(x) > 0 Then
                    get_message = get_message & partnum & "," & product & "," & shift & "," & associate & "," & lotnum & "," & res(x).ToString & vbCrLf
                Else
                    Exit For
                End If
            Next
        End If

        Try
            My.Computer.FileSystem.WriteAllText(get_FolderPath, get_message, False)
            MsgBox("Successfully saved to " & get_FolderPath)
            Thread.Sleep(100)
            Dim newpath As String = "\\lffile001\infinity\Philippines\Buffer File\Nano\Software Data Monitoring.csv"
            My.Computer.FileSystem.WriteAllText(newpath, get_message, True)
            resave = True
            Export_btn.Visible = True
            Result_list.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub Read_btn_Click_1(sender As Object, e As EventArgs) Handles Read_btn.Click
        Try
            SerialPort1.Write(strRange & vbCr) 'set range
            SerialPort1.Write("X" & vbCr)
            SerialPort1.Write("P0" & vbCr) 'display resistance mode
            SerialPort1.Write("X" & vbCr)
            SerialPort1.Write("T3" & vbCr) 'delay one shot on talk
            SerialPort1.Write("X" & vbCr)
            SerialPort1.Write("D001" & vbCr) 'delay set to 1ms
            SerialPort1.Write("X" & vbCr)
            Thread.Sleep(10)
            SerialPort1.WriteLine("E" & vbCr)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Public get_FolderPath As String
    Public get_message As String
    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        export()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'TegamRead = TextBox1.Text
        '_read()

    End Sub

    Public access As Integer
    Private Sub AddNewAdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewAdminToolStripMenuItem.Click
        access = 1
        User.Username_txt.Text = ""
        User.Pass_txt.Text = ""
        User.Show()
    End Sub
    Dim change As String
    Private Sub Result_List_DoubleClick(sender As Object, e As EventArgs) Handles Result_list.DoubleClick
        change = MsgBox("Change the value of the selected item?", vbYesNo)
        User.roll = Result_list.SelectedIndex
        If change = vbYes Then
            User.Username_txt.Text = ""
            User.Pass_txt.Text = ""
            access = 4
            User.Show()
        End If

    End Sub

End Class
