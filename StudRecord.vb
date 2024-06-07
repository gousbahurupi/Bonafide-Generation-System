Imports System.Data.OleDb
Imports System.Data
    Public Class StudRecord


        Sub view()

            Dim con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\CERTIFY_DB.mdb")
            con.Open()
            Dim adp As New OleDbDataAdapter("select*from Student_record", con)
            Dim ds As New DataSet
            adp.Fill(ds, "dd")
            DataGridView1.DataSource = ds.Tables("dd")
            con.Close()

        End Sub

        Sub clear_fields()

            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox6.Clear()
            TextBox1.Focus()
            ComboBox1.Text = ""
            ComboBox2.Text = ""

        End Sub

        Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

        End Sub

        Dim index As Integer = 0
        Dim table As New DataTable()
        Public Sub Show_data(ByRef position As Integer)                                                     'To show data in TextBoxis
        Try
            Dim con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\CERTIFY_DB.mdb")
            con.Open()
            Dim cmd As New OleDbCommand()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select*from Student_record"
            Dim ad As New OleDbDataAdapter(cmd)
            ad.Fill(table)
            TextBox1.Text = table.Rows(position)(0).ToString()
            TextBox2.Text = table.Rows(position)(1).ToString()
            TextBox3.Text = table.Rows(position)(2).ToString()
            ComboBox1.Text = table.Rows(position)(3).ToString()
            ComboBox2.Text = table.Rows(position)(4).ToString()
            TextBox6.Text = table.Rows(position)(5).ToString()
            DateTimePicker1.Value = table.Rows(position)(6).ToString()
            TextBox8.Clear()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, 0, "Application Error")
        End Try

        End Sub

        Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
            Me.Hide()
            Options.Show()
        End Sub

        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            Try
                Dim con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\CERTIFY_DB.mdb")
                con.Open()
                Dim cmd As New OleDbCommand()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
            cmd.CommandText = "insert into Student_record values(" & TextBox1.Text & "," & TextBox2.Text & ",'" & UCase(TextBox3.Text) & "','" & ComboBox1.SelectedItem & "','" & ComboBox2.SelectedItem & "','" & TextBox6.Text & "','" & DateTimePicker1.Value.ToString & "')"
            cmd.ExecuteNonQuery()

                clear_fields()
                con.Close()
                MsgBox("Record Inserted..!")
                view()
            Catch ex As Exception
            MsgBox(ex.Message, 0, "Application Error")
        End Try
        End Sub

        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
            Try
                Dim con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\CERTIFY_DB.mdb")
                con.Open()
                Dim cmd As New OleDbCommand()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
            cmd.CommandText = "update Student_record set SR_No= " & TextBox1.Text & ", Name='" & UCase(TextBox3.Text) & "', Year_Of_Study='" & ComboBox1.SelectedItem & "', Department_Name='" & ComboBox2.SelectedItem & "', Academic_Year='" & TextBox6.Text & "', Date_Of_Birth='" & DateTimePicker1.Value.ToString & "' where Enrollment_no= " & TextBox2.Text
                cmd.ExecuteNonQuery()
                clear_fields()
                con.Close()
                MsgBox("Record Updated..!")
                view()
            Catch ex As Exception
            MsgBox(ex.Message, 0, "Application Error")
        End Try
        End Sub

        Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
            Try
                Dim con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\CERTIFY_DB.mdb")
                con.Open()
                Dim cmd As New OleDbCommand()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "delete from Student_record  where Enrollment_no= " & TextBox2.Text & ""
                cmd.ExecuteNonQuery()

                clear_fields()
                con.Close()
                MsgBox("Record Deleted..!")
                view()
            Catch ex As Exception
            MsgBox(ex.Message, 0, "Application Error")
        End Try
        End Sub

        Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
            index -= 1
            Show_data(index)
        End Sub

        Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
            index += 1
            Show_data(index)
        End Sub

        Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
            index = table.Rows.Count() - 1
            Show_data(index)
        End Sub

        Public Sub search_data(ByRef Enroll_no As Double)                                                   'To search record from Database
        Try
            Dim con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\CERTIFY_DB.mdb")
            con.Open()
            Dim cnt As Integer = 0
            Dim found As Boolean = False
            Dim cmd As New OleDbCommand()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select*from Student_record"
            Dim ad As New OleDbDataAdapter(cmd)
            ad.Fill(table)
            While (Not cnt = table.Rows.Count() - 1)
                If Enroll_no = Val(table.Rows(cnt)(1).ToString()) Then
                    found = True
                    GoTo Success
                End If
                cnt += 1
            End While
success:
            If found Then
                Show_data(cnt)
            Else
                MsgBox("Data Not Found...!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, 0, "Application Error")
        End Try
        

        End Sub

        Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
            Dim enroll As Double = Val(TextBox8.Text)
            search_data(enroll)
        End Sub
        Private Sub PictureBox3_Click(sender As Object, e As EventArgs)

        End Sub

        Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs) Handles PictureBox2.Click
            clear_fields()
        End Sub

        Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            view()
        End Sub
    End Class