Imports System.Data.SqlClient
Public Class frmlogin


    Private Sub frmlogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False 'para deshabilitar la opcion de minimizar y maximizar
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        End
    End Sub

    Private Sub bntingresar_Click(sender As Object, e As EventArgs) Handles bntingresar.Click
        Try
            ' Dim conexion As New SqlConnection("Data Source=ANTONIO-PC\SQLINFOCAL;Initial Catalog=colegio1.0;Integrated Security=False;User ID=sa;Password=sqlserver;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
            Dim ds1 As New DataSet
            Dim da1 As New SqlDataAdapter("select * from usuario where usuario='" & Trim(txtusuario.Text) & "'and contraseña='" & Trim(txtcontraseña.Text) & "'", conexion)
            If da1.Fill(ds1) Then
                frmmenu.Show()
                Me.Hide()
            Else
                MsgBox("Usuario y/o contraseña incorrecto", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    'Desarrollado por: AnthonCode
    'Visual Basic.NET 2012
    'Versión: 1.0
End Class