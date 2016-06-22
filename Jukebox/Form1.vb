Public Class Form1

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'first_time.Hide()
        'database.Hide()
    End Sub

    Private Sub Form1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        first_time.Visible = False
        first_time.Hide()
    End Sub

    Private Sub Form1_GiveFeedback(ByVal sender As Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles Me.GiveFeedback

    End Sub

    Private Sub Form1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        first_time.Visible = False
        first_time.Hide()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        ' database.Show()
        TextBox3.Text = database.ListBox1.Items.Count.ToString
        Button11.Enabled = False
        If My.Settings.top1 > "" And My.Settings.top2 > "" And My.Settings.top3 > "" And My.Settings.top4 > "" And My.Settings.top5 > "" And My.Settings.top6 > "" And My.Settings.top7 > "" And My.Settings.top8 > "" And My.Settings.top9 > "" And My.Settings.top10 > "" And My.Settings.top11 > "" And My.Settings.top12 > "" And My.Settings.top13 > "" And My.Settings.top14 > "" And My.Settings.top15 > "" And My.Settings.top16 > "" Then
            Button11.Enabled = True
        End If
        'database.Hide()

    End Sub

    Private Sub AxWindowsMediaPlayer1_PlayStateChange(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer1.PlayStateChange

        Static Dim PlayMe As Boolean = True
        Select Case AxWindowsMediaPlayer1.playState
            Case 10
                If PlayMe = True Then
                    Try
                        AxWindowsMediaPlayer1.Ctlcontrols.play()
                        TextBox5.Text = AxWindowsMediaPlayer1.currentMedia.getItemInfo("Artist") & Environment.NewLine + AxWindowsMediaPlayer1.currentMedia.getItemInfo("Title") & Environment.NewLine + AxWindowsMediaPlayer1.currentMedia.getItemInfo("Album")

                    Catch ex As Exception
                        Dim strText() As String
                        strText = Split(TextBox2.Text, vbCrLf)
                        TextBox1.Text = (strText(0))
                        Dim b As String() = Split(TextBox2.Text, vbNewLine)
                        Dim lineCount As Integer = TextBox2.Lines.Count()
                        TextBox2.Text = String.Join(vbNewLine, b, 1, b.Length - 1)
                        AxWindowsMediaPlayer1.URL = database.TextBox1.Text + TextBox1.Text
                    End Try
                End If

            Case 8
                PlayMe = False

                If TextBox1.Text = "" Then

                    Button9.Enabled = True
                    'Timer1.Enabled = False
                Else
                    Dim strText() As String
                    strText = Split(TextBox2.Text, vbCrLf)
                    TextBox1.Text = (strText(0))
                    '
                    Dim b As String() = Split(TextBox2.Text, vbNewLine)
                    Dim lineCount As Integer = TextBox2.Lines.Count()
                    TextBox2.Text = String.Join(vbNewLine, b, 1, b.Length - 1)
                    Button9.Enabled = True
                    PlayMe = False

                    ' Timer1.Enabled = False

                    AxWindowsMediaPlayer1.URL = database.TextBox1.Text + TextBox1.Text
                    AxWindowsMediaPlayer1.Ctlcontrols.play()
                    TextBox5.Text = AxWindowsMediaPlayer1.currentMedia.getItemInfo("Artist") & Environment.NewLine + AxWindowsMediaPlayer1.currentMedia.getItemInfo("Title") & Environment.NewLine + AxWindowsMediaPlayer1.currentMedia.getItemInfo("Album")
                    PlayMe = True
                    Button9.Enabled = True
                    ' Timer1.Enabled = True
                End If
            Case WMPLib.WMPPlayState.wmppsMediaEnded
                Button9.Enabled = True
            Case WMPLib.WMPPlayState.wmppsPlaying
                Button9.Enabled = False
        End Select

    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk2bttn.Click
        TextBox2.AppendText(trk2bttn.Text & Environment.NewLine)
        My.Settings.top2 = trk2bttn.Text
        Label2.Text = "1"
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If Button14.Text = "PAUSE" Then
            AxWindowsMediaPlayer1.Ctlcontrols.pause()
            Button14.Text = "Un-Pause"
        ElseIf Button14.Text = "Un-Pause" Then
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            Button14.Text = "PAUSE"
        End If

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        If TextBox1.Text = "" And TextBox2.Text = "" Then
            Button9.Enabled = True
            TextBox5.Text = "no song selected"
        Else
            Dim strText() As String
            strText = Split(TextBox2.Text, vbCrLf)
            TextBox1.Text = (strText(0))
            Dim b As String() = Split(TextBox2.Text, vbNewLine)
            Dim lineCount As Integer = TextBox2.Lines.Count()
            TextBox2.Text = String.Join(vbNewLine, b, 1, b.Length - 1)
            AxWindowsMediaPlayer1.URL = database.TextBox1.Text + TextBox1.Text
            Button9.Enabled = False
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            Timer1.Enabled = True

        End If

    End Sub

    Private Sub AxWindowsMediaPlayer1_MediaChange(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_MediaChangeEvent) Handles AxWindowsMediaPlayer1.MediaChange

        TextBox5.Text = AxWindowsMediaPlayer1.currentMedia.getItemInfo("Artist") & Environment.NewLine + AxWindowsMediaPlayer1.currentMedia.getItemInfo("Title") & Environment.NewLine + AxWindowsMediaPlayer1.currentMedia.getItemInfo("Album")

    End Sub



    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        TextBox2.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox4.Text = "16"
        trk1bttn.Text = (database.ListBox1.Items(0).ToString())
        trk2bttn.Text = (database.ListBox1.Items(1).ToString())
        trk3bttn.Text = (database.ListBox1.Items(2).ToString())
        trk4bttn.Text = (database.ListBox1.Items(3).ToString())
        trk5bttn.Text = (database.ListBox1.Items(4).ToString())
        trk6bttn.Text = (database.ListBox1.Items(5).ToString())
        trk6bttn.Text = (database.ListBox1.Items(6).ToString())
        trk7bttn.Text = (database.ListBox1.Items(7).ToString())
        trk8bttn.Text = (database.ListBox1.Items(8).ToString())
        trk9bttn.Text = (database.ListBox1.Items(9).ToString())
        trk10bttn.Text = (database.ListBox1.Items(10).ToString())
        trk11bttn.Text = (database.ListBox1.Items(11).ToString())
        trk12bttn.Text = (database.ListBox1.Items(12).ToString())
        trk13bttn.Text = (database.ListBox1.Items(13).ToString())
        trk14bttn.Text = (database.ListBox1.Items(14).ToString())
        trk15bttn.Text = (database.ListBox1.Items(15).ToString())
        trk16bttn.Text = (database.ListBox1.Items(16).ToString())
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox4.Text = "32"
        trk1bttn.Text = (database.ListBox1.Items(16).ToString())
        trk2bttn.Text = (database.ListBox1.Items(17).ToString())
        trk3bttn.Text = (database.ListBox1.Items(18).ToString())
        trk4bttn.Text = (database.ListBox1.Items(19).ToString())
        trk5bttn.Text = (database.ListBox1.Items(20).ToString())
        trk6bttn.Text = (database.ListBox1.Items(21).ToString())
        trk6bttn.Text = (database.ListBox1.Items(22).ToString())
        trk7bttn.Text = (database.ListBox1.Items(23).ToString())
        trk8bttn.Text = (database.ListBox1.Items(24).ToString())
        trk9bttn.Text = (database.ListBox1.Items(25).ToString())
        trk10bttn.Text = (database.ListBox1.Items(26).ToString())
        trk11bttn.Text = (database.ListBox1.Items(27).ToString())
        trk12bttn.Text = (database.ListBox1.Items(28).ToString())
        trk13bttn.Text = (database.ListBox1.Items(29).ToString())
        trk14bttn.Text = (database.ListBox1.Items(30).ToString())
        trk15bttn.Text = (database.ListBox1.Items(31).ToString())
        trk16bttn.Text = (database.ListBox1.Items(32).ToString())
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox4.Text = "48"
        trk1bttn.Text = (database.ListBox1.Items(33).ToString())
        trk2bttn.Text = (database.ListBox1.Items(34).ToString())
        trk3bttn.Text = (database.ListBox1.Items(35).ToString())
        trk4bttn.Text = (database.ListBox1.Items(36).ToString())
        trk5bttn.Text = (database.ListBox1.Items(37).ToString())
        trk6bttn.Text = (database.ListBox1.Items(38).ToString())
        trk6bttn.Text = (database.ListBox1.Items(39).ToString())
        trk7bttn.Text = (database.ListBox1.Items(40).ToString())
        trk8bttn.Text = (database.ListBox1.Items(41).ToString())
        trk9bttn.Text = (database.ListBox1.Items(42).ToString())
        trk10bttn.Text = (database.ListBox1.Items(43).ToString())
        trk11bttn.Text = (database.ListBox1.Items(44).ToString())
        trk12bttn.Text = (database.ListBox1.Items(45).ToString())
        trk13bttn.Text = (database.ListBox1.Items(46).ToString())
        trk14bttn.Text = (database.ListBox1.Items(47).ToString())
        trk15bttn.Text = (database.ListBox1.Items(48).ToString())
        trk16bttn.Text = (database.ListBox1.Items(49).ToString())
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox4.Text = "64"
        trk1bttn.Text = (database.ListBox1.Items(50).ToString())
        trk2bttn.Text = (database.ListBox1.Items(51).ToString())
        trk3bttn.Text = (database.ListBox1.Items(52).ToString())
        trk4bttn.Text = (database.ListBox1.Items(53).ToString())
        trk5bttn.Text = (database.ListBox1.Items(54).ToString())
        trk6bttn.Text = (database.ListBox1.Items(55).ToString())
        trk6bttn.Text = (database.ListBox1.Items(56).ToString())
        trk7bttn.Text = (database.ListBox1.Items(57).ToString())
        trk8bttn.Text = (database.ListBox1.Items(58).ToString())
        trk9bttn.Text = (database.ListBox1.Items(59).ToString())
        trk10bttn.Text = (database.ListBox1.Items(60).ToString())
        trk11bttn.Text = (database.ListBox1.Items(61).ToString())
        trk12bttn.Text = (database.ListBox1.Items(62).ToString())
        trk13bttn.Text = (database.ListBox1.Items(63).ToString())
        trk14bttn.Text = (database.ListBox1.Items(64).ToString())
        trk15bttn.Text = (database.ListBox1.Items(65).ToString())
        trk16bttn.Text = (database.ListBox1.Items(66).ToString())
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TextBox4.Text = "80"
        trk1bttn.Text = (database.ListBox1.Items(67).ToString())
        trk2bttn.Text = (database.ListBox1.Items(68).ToString())
        trk3bttn.Text = (database.ListBox1.Items(69).ToString())
        trk4bttn.Text = (database.ListBox1.Items(70).ToString())
        trk5bttn.Text = (database.ListBox1.Items(71).ToString())
        trk6bttn.Text = (database.ListBox1.Items(72).ToString())
        trk6bttn.Text = (database.ListBox1.Items(73).ToString())
        trk7bttn.Text = (database.ListBox1.Items(74).ToString())
        trk8bttn.Text = (database.ListBox1.Items(75).ToString())
        trk9bttn.Text = (database.ListBox1.Items(76).ToString())
        trk10bttn.Text = (database.ListBox1.Items(77).ToString())
        trk11bttn.Text = (database.ListBox1.Items(78).ToString())
        trk12bttn.Text = (database.ListBox1.Items(79).ToString())
        trk13bttn.Text = (database.ListBox1.Items(80).ToString())
        trk14bttn.Text = (database.ListBox1.Items(81).ToString())
        trk15bttn.Text = (database.ListBox1.Items(82).ToString())
        trk16bttn.Text = (database.ListBox1.Items(83).ToString())
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox4.Text = "96"
        trk1bttn.Text = (database.ListBox1.Items(84).ToString())
        trk2bttn.Text = (database.ListBox1.Items(85).ToString())
        trk3bttn.Text = (database.ListBox1.Items(86).ToString())
        trk4bttn.Text = (database.ListBox1.Items(87).ToString())
        trk5bttn.Text = (database.ListBox1.Items(88).ToString())
        trk6bttn.Text = (database.ListBox1.Items(89).ToString())
        trk6bttn.Text = (database.ListBox1.Items(90).ToString())
        trk7bttn.Text = (database.ListBox1.Items(91).ToString())
        trk8bttn.Text = (database.ListBox1.Items(92).ToString())
        trk9bttn.Text = (database.ListBox1.Items(93).ToString())
        trk10bttn.Text = (database.ListBox1.Items(94).ToString())
        trk11bttn.Text = (database.ListBox1.Items(95).ToString())
        trk12bttn.Text = (database.ListBox1.Items(96).ToString())
        trk13bttn.Text = (database.ListBox1.Items(97).ToString())
        trk14bttn.Text = (database.ListBox1.Items(98).ToString())
        trk15bttn.Text = (database.ListBox1.Items(99).ToString())
        trk16bttn.Text = (database.ListBox1.Items(100).ToString())
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        TextBox4.Text = "112"
        trk1bttn.Text = (database.ListBox1.Items(101).ToString())
        trk2bttn.Text = (database.ListBox1.Items(102).ToString())
        trk3bttn.Text = (database.ListBox1.Items(103).ToString())
        trk4bttn.Text = (database.ListBox1.Items(104).ToString())
        trk5bttn.Text = (database.ListBox1.Items(105).ToString())
        trk6bttn.Text = (database.ListBox1.Items(106).ToString())
        trk6bttn.Text = (database.ListBox1.Items(107).ToString())
        trk7bttn.Text = (database.ListBox1.Items(108).ToString())
        trk8bttn.Text = (database.ListBox1.Items(109).ToString())
        trk9bttn.Text = (database.ListBox1.Items(110).ToString())
        trk10bttn.Text = (database.ListBox1.Items(111).ToString())
        trk11bttn.Text = (database.ListBox1.Items(112).ToString())
        trk12bttn.Text = (database.ListBox1.Items(113).ToString())
        trk13bttn.Text = (database.ListBox1.Items(114).ToString())
        trk14bttn.Text = (database.ListBox1.Items(115).ToString())
        trk15bttn.Text = (database.ListBox1.Items(116).ToString())
        trk16bttn.Text = (database.ListBox1.Items(117).ToString())
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        TextBox4.Text = "128"
        trk1bttn.Text = (database.ListBox1.Items(118).ToString())
        trk2bttn.Text = (database.ListBox1.Items(119).ToString())
        trk3bttn.Text = (database.ListBox1.Items(120).ToString())
        trk4bttn.Text = (database.ListBox1.Items(121).ToString())
        trk5bttn.Text = (database.ListBox1.Items(122).ToString())
        trk6bttn.Text = (database.ListBox1.Items(123).ToString())
        trk6bttn.Text = (database.ListBox1.Items(124).ToString())
        trk7bttn.Text = (database.ListBox1.Items(125).ToString())
        trk8bttn.Text = (database.ListBox1.Items(126).ToString())
        trk9bttn.Text = (database.ListBox1.Items(127).ToString())
        trk10bttn.Text = (database.ListBox1.Items(128).ToString())
        trk11bttn.Text = (database.ListBox1.Items(129).ToString())
        trk12bttn.Text = (database.ListBox1.Items(130).ToString())
        trk13bttn.Text = (database.ListBox1.Items(131).ToString())
        trk14bttn.Text = (database.ListBox1.Items(132).ToString())
        trk15bttn.Text = (database.ListBox1.Items(133).ToString())
        trk16bttn.Text = (database.ListBox1.Items(134).ToString())
    End Sub

    Private Sub trk1bttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk1bttn.Click
        TextBox2.AppendText(trk1bttn.Text & Environment.NewLine)
        My.Settings.top1 = trk1bttn.Text
        Label1.Text = "1"

    End Sub

    Private Sub trk3bttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk3bttn.Click
        TextBox2.AppendText(trk3bttn.Text & Environment.NewLine)
        My.Settings.top3 = trk3bttn.Text
        Label3.Text = "1"
    End Sub

    Private Sub trk4bttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk4bttn.Click
        TextBox2.AppendText(trk4bttn.Text & Environment.NewLine)
        My.Settings.top4 = trk4bttn.Text
        Label4.Text = "1"
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If TextBox4.Text >= 16 Then
            trk1bttn.Text = (database.ListBox1.Items(TextBox4.Text - 0).ToString())
            trk2bttn.Text = (database.ListBox1.Items(TextBox4.Text - 1).ToString())
            trk3bttn.Text = (database.ListBox1.Items(TextBox4.Text - 2).ToString())
            trk4bttn.Text = (database.ListBox1.Items(TextBox4.Text - 3).ToString())
            trk5bttn.Text = (database.ListBox1.Items(TextBox4.Text - 4).ToString())
            trk6bttn.Text = (database.ListBox1.Items(TextBox4.Text - 5).ToString())
            trk6bttn.Text = (database.ListBox1.Items(TextBox4.Text - 6).ToString())
            trk7bttn.Text = (database.ListBox1.Items(TextBox4.Text - 7).ToString())
            trk8bttn.Text = (database.ListBox1.Items(TextBox4.Text - 8).ToString())
            trk9bttn.Text = (database.ListBox1.Items(TextBox4.Text - 9).ToString())
            trk10bttn.Text = (database.ListBox1.Items(TextBox4.Text - 10).ToString())
            trk11bttn.Text = (database.ListBox1.Items(TextBox4.Text - 11).ToString())
            trk12bttn.Text = (database.ListBox1.Items(TextBox4.Text - 12).ToString())
            trk13bttn.Text = (database.ListBox1.Items(TextBox4.Text - 13).ToString())
            trk14bttn.Text = (database.ListBox1.Items(TextBox4.Text - 14).ToString())
            trk15bttn.Text = (database.ListBox1.Items(TextBox4.Text - 15).ToString())
            trk16bttn.Text = (database.ListBox1.Items(TextBox4.Text - 16).ToString())
            TextBox4.Text = TextBox4.Text - 16
        ElseIf TextBox4.Text <= 16 Then
            TextBox4.Text = 0
        End If


    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        If TextBox4.Text <= TextBox3.Text - 16 Then
            trk1bttn.Text = (database.ListBox1.Items(0 + TextBox4.Text).ToString())
            trk2bttn.Text = (database.ListBox1.Items(1 + TextBox4.Text).ToString())
            trk3bttn.Text = (database.ListBox1.Items(2 + TextBox4.Text).ToString())
            trk4bttn.Text = (database.ListBox1.Items(3 + TextBox4.Text).ToString())
            trk5bttn.Text = (database.ListBox1.Items(4 + TextBox4.Text).ToString())
            trk6bttn.Text = (database.ListBox1.Items(5 + TextBox4.Text).ToString())
            trk6bttn.Text = (database.ListBox1.Items(6 + TextBox4.Text).ToString())
            trk7bttn.Text = (database.ListBox1.Items(7 + TextBox4.Text).ToString())
            trk8bttn.Text = (database.ListBox1.Items(8 + TextBox4.Text).ToString())
            trk9bttn.Text = (database.ListBox1.Items(9 + TextBox4.Text).ToString())
            trk10bttn.Text = (database.ListBox1.Items(10 + TextBox4.Text).ToString())
            trk11bttn.Text = (database.ListBox1.Items(11 + TextBox4.Text).ToString())
            trk12bttn.Text = (database.ListBox1.Items(12 + TextBox4.Text).ToString())
            trk13bttn.Text = (database.ListBox1.Items(13 + TextBox4.Text).ToString())
            trk14bttn.Text = (database.ListBox1.Items(14 + TextBox4.Text).ToString())
            trk15bttn.Text = (database.ListBox1.Items(15 + TextBox4.Text).ToString())
            trk16bttn.Text = (database.ListBox1.Items(16 + TextBox4.Text).ToString())
            TextBox4.Text = TextBox4.Text + 16
        ElseIf TextBox4.Text >= TextBox3.Text - 16 Then
            TextBox4.Text = TextBox3.Text - 1
        End If
    End Sub

    Private Sub trk5bttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk5bttn.Click
        TextBox2.AppendText(trk5bttn.Text & Environment.NewLine)
        My.Settings.top5 = trk5bttn.Text
        Label5.Text = "1"
    End Sub

    Private Sub trk6bttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk6bttn.Click
        TextBox2.AppendText(trk6bttn.Text & Environment.NewLine)
        My.Settings.top6 = trk6bttn.Text
        Label6.Text = "1"
    End Sub

    Private Sub trk7bttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk7bttn.Click
        TextBox2.AppendText(trk7bttn.Text & Environment.NewLine)
        My.Settings.top7 = trk7bttn.Text
        Label7.Text = "1"
    End Sub

    Private Sub trk8bttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk8bttn.Click
        TextBox2.AppendText(trk8bttn.Text & Environment.NewLine)
        My.Settings.top8 = trk8bttn.Text
        Label8.Text = "1"
    End Sub

    Private Sub trk9bttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk9bttn.Click
        TextBox2.AppendText(trk9bttn.Text & Environment.NewLine)
        My.Settings.top9 = trk9bttn.Text
        Label9.Text = "1"
    End Sub

    Private Sub trk10bttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk10bttn.Click
        TextBox2.AppendText(trk10bttn.Text & Environment.NewLine)
        My.Settings.top10 = trk10bttn.Text
        Label10.Text = "1"
    End Sub

    Private Sub trk11bttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk11bttn.Click
        TextBox2.AppendText(trk11bttn.Text & Environment.NewLine)
        My.Settings.top11 = trk11bttn.Text
        Label11.Text = "1"
    End Sub

    Private Sub trk12bttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk12bttn.Click
        TextBox2.AppendText(trk12bttn.Text & Environment.NewLine)
        My.Settings.top12 = trk12bttn.Text
        Label12.Text = "1"
    End Sub

    Private Sub trk13bttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk13bttn.Click
        TextBox2.AppendText(trk13bttn.Text & Environment.NewLine)
        My.Settings.top13 = trk13bttn.Text
        Label13.Text = "1"
    End Sub

    Private Sub trk14bttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk14bttn.Click
        TextBox2.AppendText(trk14bttn.Text & Environment.NewLine)
        My.Settings.top14 = trk14bttn.Text
        Label14.Text = "1"
    End Sub

    Private Sub trk15bttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk15bttn.Click
        TextBox2.AppendText(trk15bttn.Text & Environment.NewLine)
        My.Settings.top15 = trk15bttn.Text
        Label15.Text = "1"
    End Sub

    Private Sub trk16bttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk16bttn.Click
        TextBox2.AppendText(trk16bttn.Text & Environment.NewLine)
        My.Settings.top16 = trk16bttn.Text
        Label16.Text = "1"
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim t As Double = Math.Floor(AxWindowsMediaPlayer1.currentMedia.duration - AxWindowsMediaPlayer1.Ctlcontrols.currentPosition)

        ' Display the time remaining in the current media.
        TextBox7.Text = ("Seconds remaining: " + t.ToString())
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        trk1bttn.Text = My.Settings.top1
        trk2bttn.Text = My.Settings.top2
        trk3bttn.Text = My.Settings.top3
        trk4bttn.Text = My.Settings.top4
        trk5bttn.Text = My.Settings.top5
        trk6bttn.Text = My.Settings.top6
        trk7bttn.Text = My.Settings.top7
        trk8bttn.Text = My.Settings.top8
        trk9bttn.Text = My.Settings.top9
        trk10bttn.Text = My.Settings.top10
        trk11bttn.Text = My.Settings.top11
        trk12bttn.Text = My.Settings.top12
        trk13bttn.Text = My.Settings.top13
        trk14bttn.Text = My.Settings.top14
        trk15bttn.Text = My.Settings.top15
        trk16bttn.Text = My.Settings.top16


    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

    End Sub

    Private Sub Label13_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label13.TextChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click

    End Sub

    Private Sub Label16_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label16.TextChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click

    End Sub

    Private Sub Label14_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label14.TextChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub Label15_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label15.TextChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.TextChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label10.TextChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label11.TextChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub Label12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label12.TextChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label8_DockChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.DockChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.TextChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.TextChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.TextChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.TextChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.TextChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.TextChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.TextChanged
        If Label1.Text = "1" And Label2.Text = "1" And Label3.Text = "1" And Label4.Text = "1" And Label5.Text = "1" And Label6.Text = "1" And Label7.Text = "1" And Label8.Text = "1" And Label9.Text = "1" And Label10.Text = "1" And Label11.Text = "1" And Label12.Text = "1" And Label13.Text = "1" And Label14.Text = "1" And Label15.Text = "1" And Label16.Text = "1" Then
            Button11.Enabled = True

        End If
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        first_time.Close()


    End Sub

    Private Sub Form1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
   
    End Sub

    Private Sub Form1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
     
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

    End Sub

    Private Sub Button16_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        first_time.Show()
        first_time.TopMost = True
    End Sub
End Class
