Public Class Options

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Login.Close()
        StudRecord.Close()
        SysUpdate.Close()
        Print.Close()
        UserValid.Close()
    End Sub



    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Me.Close()
    End Sub


    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        StudRecord.Show()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        UserValid.Show()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.Hide()
        Print.Show()
    End Sub
End Class