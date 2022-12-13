Imports System.Data
Imports System.Data.SqlClient
Public Class frmmatricula

    Private Sub frmmaterias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.habilitar(True)
        Me.habilitar(False)
        Me.colortextblock()
        Me.btnguardar.Enabled = False
        Me.btneliminar.Enabled = False
        Me.btneditar.Enabled = False
        Me.txtid_matricula.Enabled = False
        '  cargardatos()
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.Tan
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque
        DataGridView2.AllowUserToResizeColumns = False
        DataGridView2.AllowUserToAddRows = False
        datag()
    End Sub
    Private Sub limpiar()
        'procedimiento para limpiar los registros
        txtid_matricula.Text = ""
        txtid_estudiante.Text = ""
        txtgrado.Text = ""
        txtseccion.Text = ""


    End Sub
    Sub habilitar(ByVal e As Boolean)
        With Me
            '.txtid.Enabled = e
            .txtid_matricula.Enabled = e
            .txtid_estudiante.Enabled = e
            .txtgrado.Enabled = e
            .txtseccion.Enabled = e


        End With
    End Sub
    'cambia los colores para que se vean bloqueados con un color silver
    Sub colortextblock()
        txtid_matricula.BackColor = Color.Silver
        txtid_estudiante.BackColor = Color.Silver
        txtgrado.BackColor = Color.Silver
        txtseccion.BackColor = Color.Silver


    End Sub
    Sub colortexthab()
        ' txtci.BackColor = Color.White
        ' txtid.BackColor = Color.White
        txtid_estudiante.BackColor = Color.White
        txtgrado.BackColor = Color.White
        txtseccion.BackColor = Color.White


    End Sub


    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        limpiar()
        Me.btnnuevo.Enabled = False
        Me.btnguardar.Enabled = True
        Me.btncargar.Enabled = False
        Me.btneliminar.Enabled = False
        txtci2.Enabled = False
        Me.habilitar(True)
        Me.colortexthab()

    End Sub
    '*********************boton guardar***********************************
    Sub cargar_datos() Handles MyBase.Load
        Dim dt As New Data.DataSet
        Dim da As New SqlDataAdapter("select *from Matricula", conexion)
        da.Fill(dt, "tabla")
        DataGridView1.DataSource = dt.Tables("tabla")
    End Sub

    Public Sub datag()
        Dim consulta As String = "select [id_estudiante],[nombre],[apellido],[id_Encargado]from [dbo].[estudiante]"
        Dim adactador As New SqlDataAdapter(consulta, conexion)
        Dim dt As New DataTable
        adactador.Fill(dt)
        DataGridView2.DataSource = dt
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click

        Dim respuesta As Integer 'verifica llenado correcto, si falta registro da mensaje de llenar

        If txtid_estudiante.Text <> "" And txtgrado.Text <> "" And txtseccion.Text <> "" Then
            Try
                Dim insert_per As New SqlCommand("guardar_Matricula", conexion)
                insert_per.CommandType = CommandType.StoredProcedure

                'insert_per.Parameters.Add("@id", SqlDbType.Int).Value = txtid.Text'no se puede habilitar porque es incremental

                insert_per.Parameters.Add("@id_estudiante", SqlDbType.Int).Value = Val(txtid_estudiante.Text)
                insert_per.Parameters.Add("@grado", SqlDbType.VarChar, 15).Value = txtgrado.Text
                insert_per.Parameters.Add("@seccion", SqlDbType.VarChar, 10).Value = txtseccion.Text

                conexion.Open()
                respuesta = insert_per.ExecuteNonQuery
                conexion.Close()
                If respuesta = 1 Then
                    MsgBox("** Se grabo el registro correctamente **", MsgBoxStyle.Information)
                    cargar_datos()
                    'otro procedimiento
                    limpiar()
                    'btnguardar.Visible = True
                    ' btnnuevo.Visible = False
                    Me.habilitar(False)
                    Me.btnguardar.Enabled = False
                    Me.btnnuevo.Enabled = True
                    Me.btncargar.Enabled = True
                    Me.colortextblock() 'bloquear textbox al guardar
                    txtci2.Enabled = True
                End If
            Catch ex As Exception : MsgBox(ex.Message) 'mensaje de exception en caso de llenar datos
            End Try

        Else
            MessageBox.Show("Asegúrese de haber llenado todos los campos para poder continuar", "informe", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        limpiar()
        Me.habilitar(False) 'deshabilita todo los text box
        Me.colortextblock()
        Me.btnnuevo.Enabled = True
        Me.btnguardar.Enabled = False
        Me.btncargar.Enabled = True
        Me.btneliminar.Enabled = False
        Me.btneditar.Enabled = False
        txtci2.Enabled = True
        txtbusqueda.Text = ""
        txtbusqueda.Enabled = True
        txtci2.Text = ""

    End Sub

    Private Sub btncargar_Click(sender As Object, e As EventArgs) Handles btncargar.Click
        Me.colortexthab() 'habilita los text box para su edicion
        Me.habilitar(True)
        Me.btneliminar.Enabled = True
        Me.btneditar.Enabled = True
        txtbusqueda.Enabled = False
        txtid_matricula.Enabled = False
        If txtci2.Text <> "" Then
            Try


                Dim consulta As String = "select *from matricula where @id_matricula=id_matricula"
                Dim cmd As New SqlCommand(consulta, conexion)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@id_matricula", txtci2.Text)
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count = 0 Then
                    MsgBox("No existe registro!", MsgBoxStyle.Critical)
                Else
                    txtid_matricula.Text = dt.Rows(0).Item("id_matricula")
                    txtid_estudiante.Text = dt.Rows(0).Item("id_estudiante")
                    txtgrado.Text = dt.Rows(0).Item("grado")
                    txtseccion.Text = dt.Rows(0).Item("seccion")


                    Me.btnnuevo.Enabled = False
                    Me.btnguardar.Enabled = False
                End If
            Catch ex As Exception : MsgBox(ex.Message) 'mensaje de exception en caso de llenar datos

            End Try
        Else
            MessageBox.Show("Asegúrese de haber llenado el campo para poder continuar", "informe", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub
    Public Sub cargardatos()

        Dim consulta As String = "select *from matricula"
        Dim cmd As New SqlCommand(consulta, conexion)
        Dim dt As New DataTable
        cmd.CommandType = CommandType.Text
        Dim da As New SqlDataAdapter(cmd)
        Dim st As New DataSet
        da.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub
    Private Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        Dim respuesta As Integer
        Dim cmd As New SqlCommand("elimina_matricula", conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@id_matricula", txtid_matricula.Text)
        conexion.Open()
        respuesta = cmd.ExecuteNonQuery()
        conexion.Close()
        MsgBox(" el registro se ha borrado correctamente", MsgBoxStyle.Information)
        If respuesta = 1 Then
            cargardatos()
            limpiar() 'limpia datos de los textbox despues de borrar
            txtci2.Text = ""
        End If
    End Sub

    Private Sub btneditar_Click(sender As Object, e As EventArgs) Handles btneditar.Click
        Dim respuesta As Integer
        Me.btnnuevo.Enabled = False
        Me.btnguardar.Enabled = False
        Me.habilitar(True)
        Me.colortexthab()

        Dim cmd As New SqlCommand("editar_materia", conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@id_matricula", txtid_matricula.Text)
        cmd.Parameters.AddWithValue("@id_estudiante", txtid_estudiante.Text)
        cmd.Parameters.AddWithValue("@grado", txtgrado.Text)
        cmd.Parameters.AddWithValue("@seccion", txtseccion.Text)
        conexion.Open()
        respuesta = cmd.ExecuteNonQuery()
        conexion.Close()
        cargardatos()

        If respuesta = 1 Then
            MsgBox(" Se  modifico correctamente ", MsgBoxStyle.Information)

            'otro procedimiento
            limpiar() 'limpia todo los textbox
        End If
    End Sub

    Private Sub btnact_Click(sender As Object, e As EventArgs) Handles btnact.Click
        Dim dt As New Data.DataSet
        Dim da As New SqlDataAdapter("select *from matricula", conexion)
        da.Fill(dt, "tabla")
        DataGridView1.DataSource = dt.Tables("tabla")
    End Sub

    Private Sub txtestudiante_TextChanged(sender As Object, e As EventArgs) Handles txtid_estudiante.TextChanged
        txtid_estudiante.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtid_estudiante.Text)
        txtid_estudiante.SelectionStart = txtid_estudiante.Text.Length
    End Sub

    Private Sub txtaula_TextChanged(sender As Object, e As EventArgs) Handles txtgrado.TextChanged
        txtgrado.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtgrado.Text)
        txtgrado.SelectionStart = txtgrado.Text.Length
    End Sub

    Private Sub txtseccion_TextChanged(sender As Object, e As EventArgs) Handles txtseccion.TextChanged
        txtseccion.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtseccion.Text)
        txtseccion.SelectionStart = txtseccion.Text.Length
    End Sub
    '*******************************  botones de direcionamiento**************************

    Private Sub btnultimo_Click_1(sender As Object, e As EventArgs) Handles btnultimo.Click
        'nos posiciona al ultimo registro 
        Dim celda As DataGridViewCell = DataGridView1.CurrentCell
        celda = DataGridView1.Rows(DataGridView1.RowCount - 2).Cells(0)
        DataGridView1.CurrentCell = celda
    End Sub

    Private Sub btnanterior_Click(sender As Object, e As EventArgs) Handles btnanterior.Click
        'nos posicionara en el anterior registro
        Dim celda As DataGridViewCell = DataGridView1.CurrentCell
        Dim fila As Int32 = celda.RowIndex
        fila -= 1 'ponemos menos uno para restar de uno en uno 
        If fila < 0 Then fila = 0
        celda = DataGridView1.Rows(fila).Cells(0)
        DataGridView1.CurrentCell = celda
    End Sub

    Private Sub btnsiguiente_Click(sender As Object, e As EventArgs) Handles btnsiguiente.Click
        'nos posicionara en el siguiente registro 
        Dim celda As DataGridViewCell = DataGridView1.CurrentCell
        Dim fila As Int32 = celda.RowIndex
        fila += 1 'ponemos mas uno porque sumara de uno en uno para ir al siguiente
        If fila > DataGridView1.RowCount - 1 Then fila = DataGridView1.RowCount - 1
        celda = DataGridView1.Rows(fila).Cells(0)
        DataGridView1.CurrentCell = celda
    End Sub

    Private Sub btnprimero_Click(sender As Object, e As EventArgs) Handles btnprimero.Click
        If (Not (DataGridView1.Rows(0).IsNewRow)) Then
            'nos posiciona en la primera celda de la primera fila
            DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(0)

        End If
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Close()
    End Sub
End Class