Imports System.Data.OleDb
Public Class User
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Username_txt.Text <> "" Then
            If Pass_txt.Text <> "" Then
                checkadmin()
            End If
        End If
    End Sub
    Dim get_password As String
    Dim newvalue As String
    Dim indexvalue As Integer
    Dim indexchange As Integer
    Public roll As Integer
    Public Sub checkadmin()
        Dim conn As New OleDbConnection
        conn.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Tegam Data\Resistance.accdb")
        Try
            conn.Open()
            Dim strsql As String
            strsql = "select myPassword FROM User_tb WHERE User_Name='" + Username_txt.Text + "'"
            Dim cmd As New OleDbCommand(strsql, conn)
            Dim myreader As OleDbDataReader
            myreader = cmd.ExecuteReader
            myreader.Read()
            get_password = myreader("myPassword")

            If Pass_txt.Text = get_password Then
                Me.Hide()
                Select Case Main.access
                    Case 1
                        AddUser.Show()
                        Username_txt.Text = ""
                        Pass_txt.Text = ""
                    Case 4
                        While newvalue Is Nothing
                            newvalue = InputBox("Enter new value:")
                            If IsNumeric(newvalue) Then
                                Main.Result_list.Items(Main.Result_list.SelectedIndex) = CStr(Main.Result_list.SelectedIndex + 1) & ") " & CStr(newvalue)
                            ElseIf newvalue = "d" Or newvalue = "D" Then
                                Main.Result_list.Items.RemoveAt(Main.Result_list.SelectedIndex)

                                For rolling As Integer = roll To Main.res.Length - 1
                                    If Main.res(roll) = Nothing Then
                                        Exit For
                                    Else
                                        Main.res(roll) = Main.res(roll + 1)
                                    End If
                                Next
                                Main.count -= 1
                                newvalue = Nothing
                                Exit While
                            Else
                                newvalue = Nothing
                            End If
                        End While
                End Select
            Else
                MsgBox("Incorrect Password!", vbCritical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        Finally
            conn.Close()
            conn = Nothing
            newvalue = Nothing
        End Try
    End Sub


End Class