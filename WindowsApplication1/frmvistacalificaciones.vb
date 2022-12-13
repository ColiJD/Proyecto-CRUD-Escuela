Imports System.Data
Imports System.Data.SqlClient

Public Class frmvistacalificaciones

    Private Sub frmvistacalificaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New Data.DataSet
        Dim da As New SqlDataAdapter("select *from calificaciones_sec", conexion)
        da.Fill(dt, "tabla")
        DataGridView1.DataSource = dt.Tables("tabla")
    End Sub

    Private Sub txtbusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtbusqueda.TextChanged
        Dim da As New SqlDataAdapter("select * from calificaciones_sec", conexion)
        Dim ds As New DataSet
        Dim dv As New DataView
        da.Fill(ds)
        dv.Table = ds.Tables(0)
        DataGridView1.DataSource = dv

        dv.RowFilter = String.Format("estudiante like '{0}%'", txtbusqueda.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
    'Desarrollado por: AnthonCode
    'Visual Basic.NET 2012
    'Versión: 1.0
End Class