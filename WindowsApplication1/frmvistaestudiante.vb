Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports word = Microsoft.Office.Interop.Word
Imports System.IO
Public Class frmvistaestudiante

    Private Sub frmvistaestudiante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New Data.DataSet
        Dim da As New SqlDataAdapter("select *from estudiante", conexion)
        da.Fill(dt, "tabla")
        DataGridView1.DataSource = dt.Tables("tabla")
    End Sub

  
    Private Sub txtbusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtbusqueda.TextChanged
        Dim da As New SqlDataAdapter("select * from estudiante", conexion)
        Dim ds As New DataSet
        Dim dv As New DataView
        da.Fill(ds)
        dv.Table = ds.Tables(0)
        DataGridView1.DataSource = dv

        dv.RowFilter = String.Format("nombres like '{0}%'", txtbusqueda.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub btexportar_Click(sender As Object, e As EventArgs) Handles btexportar.Click
        MessageBox.Show("Esta es un versión DEMO, adquiere la versión completa en http://www.facebook.com/anthoncode", "informe", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
   

   
    Private Sub btnexpow_Click(sender As Object, e As EventArgs) Handles btnexpow.Click
        MessageBox.Show("Esta es un versión DEMO, adquiere la versión completa en http://www.facebook.com/anthoncode", "informe", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    
    'Desarrollado por: AnthonCode
    'Visual Basic.NET 2012
    'Versión: 1.0

End Class