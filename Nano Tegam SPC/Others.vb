Imports System.Data.OleDb
Imports LFPHWIADBLib
Public Class Others
    Private NANODb As New WIADb("Data Source=BTMESSQLPROD;Initial Catalog=LFPHNANO;User ID=mesaccount;Password=superfuse;Persist Security Info=True;")
    'Console.Writeline(NANODb.PartNo)
    'Console.Writeline(NANODb.Rating)
    'Console.Writeline(NANODb.Minimum)
    'Console.Writeline(NANODb.Nominal)
    'Console.Writeline(NANODb.Maximum)
    'Console.Writeline(NANODb.LoLim)
    'Console.Writeline(NANODb.HiLim)
    'Console.Writeline(NANODb.Range)
    'Console.Writeline(NANODb.Marking)
    'Console.Writeline(NANODb.mRating)
    'Console.Writeline(NANODb.PackQty)
    Private Sub Others_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public sqlconn As String
    Public sqlfindpn As String
    Public sqlfindproc As String
    Dim _line As String
    Public Sub loadProcess()
        Dim conn As New OleDbConnection
        Try
            conn.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Tegam data\Resistance.accdb")
            conn.Open()
            Dim cmd As New OleDbCommand(sqlfindproc, conn)
            Dim myreader As OleDbDataReader
            myreader = cmd.ExecuteReader
            Product_box.Items.Clear()
            Associate_box.Items.Clear()
            While myreader.Read()
                _line = myreader("lines").ToString()
                If _line IsNot "" Then
                    Product_box.Items.Add(_line)
                End If
                Associate_box.Items.Add(myreader("Associate").ToString())
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
    Public Sub loadPN()
        Dim conn As New OleDbConnection
        Partnum_box.Items.Clear()
        Try
            conn.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Tegam data\Resistance.accdb")
            conn.Open()
            Dim strsql As String
            strsql = sqlfindpn
            Dim cmd As New OleDbCommand(strsql, conn)
            Dim myreader As OleDbDataReader
            myreader = cmd.ExecuteReader
            myreader.Read()
            While myreader.Read()
                Partnum_box.Items.Add(myreader("my_partnumber").ToString())
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
    'Public product_type As String
    Private Sub fuse_res_rad_CheckedChanged(sender As Object, e As EventArgs) Handles fuse_res_rad.CheckedChanged
        If fuse_res_rad.Checked Then
            sqlfindpn = "SELECT my_partnumber FROM Fuse_Partnum_tb"
            sqlfindproc = "SELECT Lines, Associate FROM Fuse_Resistance_tb"

            Main.product_type = "fuse"
            loadProcess()
            loadPN()
        End If
    End Sub

    Private Sub wound_res_rad_CheckedChanged(sender As Object, e As EventArgs) Handles wound_res_rad.CheckedChanged
        If wound_res_rad.Checked Then
            sqlfindpn = "SELECT my_partnumber FROM Wound_Partnum_tb"
            sqlfindproc = "SELECT Lines, Associate FROM Woundwire_Resistance_tb"

            Main.product_type = "wire"
            loadProcess()
            loadPN()
        End If
    End Sub

    Private Sub corrug_res_rad_CheckedChanged(sender As Object, e As EventArgs) Handles corrug_res_rad.CheckedChanged
        If corrug_res_rad.Checked Then
            sqlfindpn = "SELECT my_partnumber FROM Wire_Partnum_tb"
            sqlfindproc = "SELECT Lines, Associate FROM Wire_Resistance_tb"

            Main.product_type = "wire"
            loadProcess()
            loadPN()
        End If
    End Sub

    Private Sub str_wire_rad_CheckedChanged(sender As Object, e As EventArgs) Handles str_wire_rad.CheckedChanged
        If str_wire_rad.Checked Then
            sqlfindpn = "SELECT my_partnumber FROM Wire_Partnum_tb"
            sqlfindproc = "SELECT Lines, Associate FROM Wire_Resistance_tb"

            Main.product_type = "wire"
            loadProcess()
            loadPN()
        End If
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If Product_box.Items.Contains(Product_box.Text) Then
            If Partnum_box.Items.Contains(Partnum_box.Text) Then
                If Lot_txt.Text IsNot "" Then
                    If Associate_box.Items.Contains(Associate_box.Text) Then
                        If Shift_box.Text IsNot "" Then
                            get_resistance()
                            set_param()
                            Main.sample_qty = CInt(myqty)
                            Me.Hide()
                            With Main
                                .Newlot_list.Items.Clear()
                                .Result_list.Items.Clear()
                                .Newlot_btn.Enabled = False
                                .Start_btn.Enabled = True
                                .product = Product_box.Text
                                .Newlot_list.Items.Add("Line: " & Product_box.Text)
                                .Newlot_list.Items.Add(" ")
                                .partnum = Partnum_box.Text
                                .Newlot_list.Items.Add("Partnumber: " & Partnum_box.Text)
                                .Newlot_list.Items.Add(" ")
                                .lotnum = Lot_txt.Text
                                .Newlot_list.Items.Add("Lotnumber: " & Lot_txt.Text)
                                .Newlot_list.Items.Add(" ")
                                .associate = Associate_box.Text
                                .Newlot_list.Items.Add("Associate: " & Associate_box.Text)
                                .Newlot_list.Items.Add(" ")
                                .shift = Shift_box.Text
                                .Newlot_list.Items.Add("Shift: " & Shift_box.Text)
                                .Label3.ForeColor = Color.Green
                            End With


                        Else
                            MsgBox("Please enter your shift", vbCritical)
                        End If
                    Else
                        MsgBox("Please enter a valid name", vbCritical)
                    End If
                Else
                    MsgBox("Please enter a valid lot number", vbCritical)
                End If
            Else
                MsgBox("Please enter a valid part number", vbCritical)
            End If
        Else
            MsgBox("Please enter a valid product line", vbCritical)
        End If
    End Sub

    Public Sub set_param()
        If fuse_res_rad.Checked = True Then

            Main.get_FolderPath = "\\lffile001\infinity\Philippines\Buffer File\Nano\Fuse Resistance offline tester.csv"
            'Main.get_FolderPath = "C:\Tegam Data\Sample\test.csv"
            Main.get_message = """Part,""" & "," & """Process,""" & "," & """Shift,""" & "," & """Square Nano Associate,""" & "," & """Lot No,""" & "," & """Fuse Resistance,""" & vbCrLf
        End If
        If wound_res_rad.Checked = True Then

            Main.get_FolderPath = "\\lffile001\infinity\Philippines\Buffer File\Nano\Wound Wire Resistance offline tester Wire winding.csv"
            Main.get_message = """Part,""" & "," & """Process,""" & "," & """Shift,""" & "," & """Square Nano Associate,""" & "," & """Lot No,""" & "," & """Nano Wound Wire Resistance,""" & vbCrLf
        End If
        If corrug_res_rad.Checked = True Then

            Main.get_FolderPath = "\\lffile001\infinity\Philippines\Buffer File\Nano\Corrugated Wire Resistance offline tester.csv"
            Main.get_message = """Part,""" & "," & """Process,""" & "," & """Shift,""" & "," & """Square Nano Associate,""" & "," & """Lot No,""" & "," & """Corrugated Wire Resistance wire1,""" & vbCrLf
        End If
        If str_wire_rad.Checked = True Then

            Main.get_FolderPath = "\\lffile001\infinity\Philippines\Buffer File\Nano\Straight Wire Resistance offline tester.csv"
            Main.get_message = """Part,""" & "," & """Process,""" & "," & """Shift,""" & "," & """Square Nano Associate,""" & "," & """Lot No,""" & "," & """Straight Wire Resistance wire1,""" & vbCrLf
        End If

    End Sub
    Public my_rating As String
    Public my_maximum As String
    Public my_minimum As String
    Public my_nominal As String
    Public truemin As Decimal
    Public truemax As Decimal
    Public fuse_range As Decimal
    Public myqty As String
    Public to_NANODb As Boolean
    Public Sub get_resistance()
        If fuse_res_rad.Checked Then
            to_NANODb = True
            sqlconn = "SELECT * FROM Fuse_Partnum_tb WHERE my_partnumber='" + Partnum_box.Text + "'"
        End If
        If corrug_res_rad.Checked Then
            to_NANODb = False
            sqlconn = "SELECT my_rating, my_nominal, my_maximum, Infinity_Qty FROM Wire_Partnum_tb WHERE my_partnumber='" + Partnum_box.Text + "'"
        End If
        If wound_res_rad.Checked Then
            to_NANODb = False
            sqlconn = "SELECT my_rating, my_nominal, my_maximum, Infinity_Qty FROM Wound_Partnum_tb WHERE my_partnumber='" + Partnum_box.Text + "'"
        End If
        If str_wire_rad.Checked Then
            to_NANODb = False
            sqlconn = "SELECT my_rating, my_nominal, my_maximum, Infinity_Qty FROM Wire_Partnum_tb WHERE my_partnumber='" + Partnum_box.Text + "'"
        End If
        Try
            Dim conn As New OleDbConnection
            conn.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Tegam data\Resistance.accdb")
            conn.Open()
            Dim strsql As String
            strsql = sqlconn
            Dim cmd As New OleDbCommand(strsql, conn)
            Dim myreader As OleDbDataReader
            myreader = cmd.ExecuteReader
            myreader.Read()
            my_rating = myreader("my_rating")
            my_nominal = myreader("my_nominal")
            my_maximum = myreader("my_maximum")
            If fuse_res_rad.Checked = True Then
                my_minimum = myreader("my_minimum")
                truemin = Math.Round(CDec(my_nominal) * (((100 - (CDec(my_minimum))) / 100)), 3)
                Main.minimum = truemin
            End If

            myqty = myreader("Infinity_Qty")
            'If to_NANODb Then
            '    If NANODb.IsValidPartNumber(Partnum_box.Text) Then
            '        fuse_range = NANODb.Range
            '        Console.WriteLine(fuse_range)
            '    End If
            'End If
            truemax = Math.Round(CDec(my_nominal) * ((CDec(my_maximum) / 100) + 1), 3)

            Main.rating = my_rating
            Main.maximum = truemax

            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
        'Console.WriteLine(my_rating)
        'Console.WriteLine(truemax)
    End Sub



End Class