Imports System.Data.OleDb
Imports System.Data

Public Class Login
    Dim User, pass As String
    Dim table As New DataTable()
    Public con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\CERTIFY_DB.mdb")
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim flag = 0, a As Integer
            If TextBox1.Text = "" Then
                ErrorProvider1.SetError(TextBox1, "Enter Username Plz...")
                flag = 1
            End If
            If TextBox2.Text = "" Then
                ErrorProvider1.SetError(TextBox2, "Enter Password Plz...")
                flag = 1
            End If

            If flag = 0 Then
                Con.Open()
                Dim query = "Select * From Login Where [User]='" & TextBox1.Text & "' And [Password]='" & TextBox2.Text & "'"
                Dim cmd = New OleDbCommand(query, Con)
                Dim da = New OleDbDataAdapter
                da = New OleDbDataAdapter(cmd)
                Dim builder = New OleDbCommandBuilder(da)
                Dim ds As New DataSet()
                da.Fill(ds)
                a = ds.Tables(0).Rows.Count
                If a = 0 Then
                    MsgBox("User Name Or Password Is Wrong...", 0, "Invalid Credentials..")
                Else
                    MsgBox("Logged in Successfully..!", 0, "Login")
                    TextBox1.Clear()
                    TextBox2.Clear()
                    Me.Hide()
                    Options.Show()
                End If
                Con.Close()
            End If
        Catch ex As Exception
            Con.Close()
            MsgBox(ex.Message, 0, "Application Error")
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

End Class