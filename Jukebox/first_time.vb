Public Class first_time

    Public Function FileNameWithoutPath(ByVal FullPath As String) As String

        Return System.IO.Path.GetFileName(FullPath).ToString

    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Using FD As New OpenFileDialog()
            Dim strFileName As String
            FD.Title = "Open txt File that contains locations of mp3's"
            FD.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            FD.InitialDirectory = "c:\Jukebox\"
            FD.RestoreDirectory = True

            If FD.ShowDialog = Windows.Forms.DialogResult.OK Then
                strFileName = FD.SafeFileName
                TextBox2.Text = FD.SafeFileName
                My.Settings.mp3text = FD.InitialDirectory + FD.SafeFileName
                database.ListBox1.Items.Clear()
                database.ListBox1.Items.AddRange(IO.File.ReadAllLines(FD.FileName))
                TextBox4.Text = FD.FileName
                My.Settings.mp3text = TextBox4.Text
                For i = 0 To database.ListBox1.Items.Count - 1
                    If database.ListBox1.Items(i).ToString.Contains(TextBox1.Text) Then
                        database.ListBox1.Items(i) = database.ListBox1.Items(i).ToString.Replace(TextBox1.Text, "")
                        Label1.Text = "Ready"
                    End If
                Next
            End If
        End Using

    End Sub

    Private Sub first_time_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckBox1.CheckState = My.Settings.cursor
        TextBox1.Text = My.Settings.path
        TextBox4.Text = My.Settings.mp3text
        TextBox2.Text = My.Settings.mp3text
        If TextBox2.Text = My.Settings.mp3text Then
            Label2.Text = "Ready"
        End If

        If My.Settings.First_time = "1" Then
            Dim strFileName As String
            strFileName = TextBox4.Text
            database.ListBox1.Items.Clear()
            database.ListBox1.Items.AddRange(IO.File.ReadAllLines(strFileName))

            For i = 0 To database.ListBox1.Items.Count - 1
                If database.ListBox1.Items(i).ToString.Contains(TextBox1.Text) Then
                    database.ListBox1.Items(i) = database.ListBox1.Items(i).ToString.Replace(TextBox1.Text, "")
                    Label1.Text = "Ready"


                End If


            Next


            If database.ListBox1.Items.Count >= 2 Then
                Label1.Text = "Ready"
                Me.Visible = False
                database.Show()
                database.Visible = False
                Form1.Show()
                Me.Hide()

            End If
        End If
        


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        database.Show()
        database.TopMost = True

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        ' TextBox2.Text = My.Settings.path
        If database.ListBox1.Items.Count <= 2 Then
            Label1.Text = "Ready"
            '     TextBox1.Text = My.Settings.path
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim folderDlg As New FolderBrowserDialog
        folderDlg.SelectedPath = "C:\Users\"
        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            TextBox1.Text = folderDlg.SelectedPath + "\"
            My.Settings.path = TextBox1.Text
        End If

       
        TextBox3.Text = ("ECHO OFF" & Environment.NewLine & "cd/" & Environment.NewLine & "cls" & Environment.NewLine & "ECHO Looking for Mp3's Please Wait!" & Environment.NewLine & "ECHO OFF" & Environment.NewLine & "c:" & Environment.NewLine & "md Jukebox" & Environment.NewLine & "dir.exe " + TextBox1.Text + "*.mp3 /s /b > c:\Jukebox\mp3list.txt" & Environment.NewLine & "exit")
        My.Computer.FileSystem.WriteAllText("make_mp3.bat", TextBox3.Text, False)
        'Dim objWriter As New System.IO.StreamWriter("c:\value1.txt", False)
        'objWriter.WriteLine(TextBox1.Text)
        'objWriter.Close()

        database.TextBox1.Text = My.Settings.path
        Button4.Enabled = True

    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Visible = False
        Form1.Visible = False
        Form1.TopMost = False

        database.Visible = False

        Shell("make_mp3.bat", FormStartPosition.CenterScreen, AppWinStyle.MaximizedFocus)

        My.Settings.mp3text = TextBox4.Text
        Label2.Text = "Ready"
        Me.Visible = True
        ' Form1.Visible = True
        ' database.Visible = True
        ' Form1.TopMost = True
        Me.TopMost = True
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        My.Settings.First_time = "1"
        My.Settings.mp3text = TextBox4.Text
        My.Settings.path = TextBox1.Text
        Form1.Show()
        Me.Hide()

    End Sub

   
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click


        '  If database.ListBox1.Items.Count >= 2 Then
        ' Label1.Text = "Ready"
        ' database.Show()
        'database.Visible = False
        ' Me.Hide()
        ' Me.Visible = False
        ' Form1.Show()
        ' End If



    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            Windows.Forms.Cursor.Hide()
            My.Settings.cursor = "1"
        ElseIf CheckBox1.CheckState = CheckState.Unchecked Then
            Windows.Forms.Cursor.Show()
            My.Settings.cursor = "0"
        End If
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
End Class