Public Class database
    Dim paths As String()

  

    Private Sub database_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.path
        Dim dd As String
        For ee As Integer = 0 To ListBox1.Items.Count - 1
            If ListBox1.Items.Item(ee).ToString.Contains(TextBox1.Text) Then
                dd = ListBox1.Items.Item(ee).ToString.Substring(7)
                ListBox1.Items.RemoveAt(ee)
                ListBox1.Items.Insert(ee, "")
            End If
        Next

        Form1.trk1bttn.Text = (ListBox1.Items(0).ToString())
        Form1.trk2bttn.Text = (ListBox1.Items(1).ToString())
        Form1.trk3bttn.Text = (ListBox1.Items(2).ToString())
        Form1.trk4bttn.Text = (ListBox1.Items(3).ToString())
        Form1.trk5bttn.Text = (ListBox1.Items(4).ToString())
        Form1.trk6bttn.Text = (ListBox1.Items(5).ToString())
        Form1.trk6bttn.Text = (ListBox1.Items(6).ToString())
        Form1.trk7bttn.Text = (ListBox1.Items(7).ToString())
        Form1.trk8bttn.Text = (ListBox1.Items(8).ToString())
        Form1.trk9bttn.Text = (ListBox1.Items(9).ToString())
        Form1.trk10bttn.Text = (ListBox1.Items(10).ToString())
        Form1.trk11bttn.Text = (ListBox1.Items(11).ToString())
        Form1.trk12bttn.Text = (ListBox1.Items(12).ToString())
        Form1.trk13bttn.Text = (ListBox1.Items(13).ToString())
        Form1.trk14bttn.Text = (ListBox1.Items(14).ToString())
        Form1.trk15bttn.Text = (ListBox1.Items(15).ToString())
        Form1.trk16bttn.Text = (ListBox1.Items(16).ToString())
 


    End Sub


    Private Sub ListBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.TextChanged
        Form1.trk1bttn.Text = ListBox1.GetItemText(1)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
        Me.Visible = False

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub
End Class