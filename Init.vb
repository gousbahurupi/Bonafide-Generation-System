Public Class Init

    Private Sub Form1_Loa(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = "Loading... " & ProgressBar1.Value + 2 & "%"
        ProgressBar1.Increment(1)
        If ProgressBar1.Value = 100 Then
            Login.Show()
            Me.Hide()
            Timer1.Enabled = False
        End If
    End Sub

    
    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub
End Class
