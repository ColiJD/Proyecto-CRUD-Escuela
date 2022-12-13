Public NotInheritable Class frmsplash

    Private Sub frmsplash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Timer1.Interval = 30
        Timer1.Enabled = True
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            Dim L As New frmlogin
            L.Show()
            Me.Hide()
            Timer1.Stop()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        End
    End Sub
End Class
