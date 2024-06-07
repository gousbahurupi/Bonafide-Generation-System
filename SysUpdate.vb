Imports System.Data.OleDb
Imports System.Data
Public Class SysUpdate
    Dim ch As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\CERTIFY_DB.mdb")
            con.Open()
            Dim cmd As New OleDbCommand()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            While ch > 2 Or ch < 0
                ErrorProvider1.SetError(PictureBox1, "Incorect choice")
                ch = Val(InputBox("What do you Want to Update : " & vbCrLf & "Enter 1 to Update User Password " & vbCrLf & "Enter 2 to Update User Name " & vbCrLf & "Enter 0 to Update both of them ", "Update Selection Window", "Enter your Choice here ", 0))
            End While

            If ch = 1 Then
                cmd.CommandText = "Update Login set [Password] ='" & TextBox2.Text & "' "
            ElseIf ch = 2 Then
                cmd.CommandText = "Update Login set [User] ='" & TextBox1.Text & "' "
            Else
                cmd.CommandText = "Update Login set [User] ='" & TextBox1.Text & "' AND [Password] ='" & TextBox2.Text & "' "
            End If

            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox("New User Name and passWord Are Successfuly Saved")
        Catch ex As Exception
            MsgBox(ex.Message, 0, "Application Error")
        End Try
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Login.Close()
        StudRecord.Close()
        Print.Close()
        UserValid.Close()
        ch = Val(InputBox("What do you Want to Update : " & vbCrLf & "Enter 1 to Update User Password " & vbCrLf & "Enter 2 to Update User Name " & vbCrLf & "Enter 0 to Update both of them ", "Update Selection Window", "Enter your Choice here ", 0))

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Options.Show()
        Close()
    End Sub

   
End Class