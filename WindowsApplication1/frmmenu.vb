Public Class frmmenu

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'lbltime.Text = TimeOfDay
        Dim h, m As Double
        h = TimeOfDay.Hour
        m = TimeOfDay.Minute
        lbltime.Text = h & ":" & m
    End Sub

    Private Sub trestudiante_Click(sender As Object, e As EventArgs) Handles trestudiante.Click
        frmestudiante.Show()
    End Sub

    Private Sub trdocente_Click(sender As Object, e As EventArgs) Handles trdocente.Click
        frmdocente.Show()
    End Sub

    Private Sub truser_Click(sender As Object, e As EventArgs) Handles truser.Click
        frmusuario.Show()
    End Sub
    Private Sub trmatricula_Click(sender As Object, e As EventArgs) Handles trmatricula.Click
        frmmatricula.Show()
    End Sub

    Private Sub trencargado_Click(sender As Object, e As EventArgs) Handles trencargado.Click
        frmEncargado.Show()
    End Sub

    Private Sub dtdestudiante_Click(sender As Object, e As EventArgs) Handles dtdestudiante.Click
        frmestudiante.Show()
    End Sub

    Private Sub btddocente_Click(sender As Object, e As EventArgs) Handles btddocente.Click
        frmdocente.Show()
    End Sub

    Private Sub btdaulas_Click(sender As Object, e As EventArgs) Handles btdaulas.Click
        frmusuario.Show()
    End Sub
    Private Sub btdmatricula_Click(sender As Object, e As EventArgs) Handles btdmaterias.Click
        frmmatricula.Show()
    End Sub

    Private Sub buttonItem21_Click(sender As Object, e As EventArgs) Handles buttonItem21.Click
        frmusuario.Show()
    End Sub

    Private Sub buttonItem20_Click(sender As Object, e As EventArgs) Handles buttonItem20.Click
        frmacerca.Show()
    End Sub

    Private Sub buttonItem7_Click(sender As Object, e As EventArgs) Handles buttonItem7.Click
        frmmatricula.Show()
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        frmvistaestudiante.Show()
    End Sub

    Private Sub ButtonItem10_Click(sender As Object, e As EventArgs) Handles ButtonItem10.Click
        frmvistadocente.Show()
    End Sub
    Private Sub ButtonItem11_Click(sender As Object, e As EventArgs) Handles ButtonItem11.Click
        frmvistacalificaciones.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://www.facebook.com/anthoncode")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        frmacerca.Show()
    End Sub
End Class