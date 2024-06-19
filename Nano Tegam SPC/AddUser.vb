Imports System.Data.OleDb
Public Class AddUser



    Private Sub Adduser_btn_Click_1(sender As Object, e As EventArgs) Handles Adduser_btn.Click
        If Adduser_txt.Text <> "" Then
            If Addpass_txt.Text <> "" Then
                If Addpass_txt.Text = Reenter_txt.Text Then
                    addtheuser()
                Else
                    MsgBox("Password do not match!", vbCritical)
                End If
            Else
                MsgBox("Please enter a password!", vbCritical)
            End If
        Else
            MsgBox("Please enter a user name!", vbCritical)
        End If
    End Sub
    Public username As String
    Public pass As String
    Public Sub addtheuser()
        username = Adduser_txt.Text
        pass = Addpass_txt.Text
        Dim mycommand As String
        Dim myconnection As OleDbConnection = New OleDbConnection
        Try

            myconnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Tegam Data\Resistance.accdb"
            myconnection.Open()
            mycommand = "INSERT INTO [User_tb] ([User_Name],[myPassword]) VALUES (@username, @pass)"
            Using cmd As OleDbCommand = New OleDbCommand(mycommand, myconnection)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@pass", pass)
                cmd.ExecuteNonQuery()

                '    myconnection = Nothing
            End Using
            MsgBox("Update Success", vbInformation)
            Adduser_txt.Text = ""
            Addpass_txt.Text = ""
            Reenter_txt.Text = ""
            Me.Hide()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        Finally
            myconnection.Close()
            myconnection = Nothing
        End Try

    End Sub
End Class