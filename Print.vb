Imports System.Data.OleDb
Imports System.Data
Public Class Print

    Dim dt As New DataTable
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Login.Close()
        UserValid.Close()
        StudRecord.Close()
        SysUpdate.Close()
        Me.ReportViewer1.RefreshReport()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Using con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\CERTIFY_DB.mdb")
                con.Open()
                Using cmd As New OleDbCommand("select * from Student_record Where Enrollment_no= " & TextBox1.Text & "", con)
                    Dim da As New OleDbDataAdapter
                    da.SelectCommand = cmd
                    da.Fill(dt)
                End Using
                con.Close()
            End Using
            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "C:\Users\Lenovo\Documents\Gous Pro\Certify\Bonafide.rdlc"
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
            End With

        Catch ex As Exception

            MsgBox(ex.Message, 0, "Application Error")
        End Try

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Me.Hide()
        Options.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class