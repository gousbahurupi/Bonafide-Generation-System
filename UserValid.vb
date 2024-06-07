Imports System.Data.OleDb
Imports System.Data
Public Class UserValid
    Dim User, pass As String
    Dim table As New DataTable()

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        Options.Show()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\CERTIFY_DB.mdb")
            con.Open()
            Dim cmd As New OleDbCommand()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select*from Login"
            Dim ad As New OleDbDataAdapter(cmd)
            ad.Fill(table)
            If Not TextBox1.Text = (table.Rows(0)(1).ToString()) Then
                ErrorProvider1.SetError(TextBox1, "Incorrect User Name")
            ElseIf Not TextBox2.Text = (table.Rows(0)(2).ToString()) Then
                ErrorProvider1.SetError(TextBox2, "Incorrect Password")
            Else
                ErrorProvider1.Clear()
                Options.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, 0, "Application Error")
        End Try
        SysUpdate.Show()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StudRecord.Close()
        SysUpdate.Close()
        Print.Close()
    End Sub

End Class