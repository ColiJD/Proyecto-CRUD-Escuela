
Imports System.Data
Imports System.Data.SqlClient
Public Class frmestudiante


    'carga automaticamente la base de datos al datagridview1
    Private Sub Frmestudiante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.habilitar(True)

        'llamamos al procedimiento buscar

        Me.habilitar(False) 'deshabilita todo los text box
        Me.colortextblock()
        Me.btnguardar.Enabled = False
        Me.btneliminar.Enabled = False
        Me.btneditar.Enabled = False
        Me.txtid.Enabled = False
        cargardatos()
        'alterna dos colores diferentes para el datagridview
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.Tan
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque
        DataGridView2.AllowUserToResizeColumns = False
        DataGridView2.AllowUserToAddRows = False
        datag()

        lbltotal.Text = CStr(DataGridView1.RowCount)
    End Sub
    Public Sub datag()
        Dim consulta As String = "select [id_Encargado],[nombre],[apellido] from [dbo].[Encargado]"
        Dim adactador As New SqlDataAdapter(consulta, conexion)
        Dim dt As New DataTable
        adactador.Fill(dt)
        DataGridView2.DataSource = dt
    End Sub

    Private Sub limpiar()
        'procedimiento para limpiar los registros
        txtid.Text = ""
        txtnombres.Text = ""
        txtpaterno.Text = ""
        txtnacimiento.Text = ""
        txtsexo.Text = ""
        txtdireccion.Text = ""
        txtinscripcion.Text = ""
        txtGraduacion.Text = ""
        txttutor.Text = ""


    End Sub
    Sub habilitar(ByVal e As Boolean)
        With Me
            ' .txtid_usuario.Enabled = e
            .txtnombres.Enabled = e
            .txtpaterno.Enabled = e
            .txtnacimiento.Enabled = e
            .txtsexo.Enabled = e
            .txtdireccion.Enabled = e
            .txtinscripcion.Enabled = e
            .txtGraduacion.Enabled = e
            .txttutor.Enabled = e

        End With
    End Sub
    Sub colortexthab()

        txtnombres.BackColor = Color.White
        txtpaterno.BackColor = Color.White
        txtnacimiento.BackColor = Color.White
        txtsexo.BackColor = Color.White
        txtdireccion.BackColor = Color.White
        txtsexo.BackColor = Color.White
        txtdireccion.BackColor = Color.White
        txtinscripcion.BackColor = Color.White
        txtGraduacion.BackColor = Color.White
        txttutor.BackColor = Color.White
    End Sub
    'cambia los colores para que se vean bloqueados con un color silver
    Sub colortextblock()
        txtid.BackColor = Color.Silver
        txtnombres.BackColor = Color.Silver
        txtpaterno.BackColor = Color.Silver
        txtnacimiento.BackColor = Color.Silver
        txtsexo.BackColor = Color.Silver
        txtdireccion.BackColor = Color.Silver
        txtinscripcion.BackColor = Color.Silver
        txtGraduacion.BackColor = Color.Silver
        txttutor.BackColor = Color.Silver


    End Sub



    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        '*****************boton de nuevo registro***********************************

        Me.btnnuevo.Enabled = False
        Me.btnguardar.Enabled = True
        Me.btncargar.Enabled = False
        txtci2.Enabled = False
        Me.habilitar(True)
        Me.colortexthab()
    End Sub
    Sub cargar_datos() Handles MyBase.Load
        Dim dt As New Data.DataSet
        Dim da As New SqlDataAdapter("select *from estudiante", conexion)
        da.Fill(dt, "tabla")
        DataGridView1.DataSource = dt.Tables("tabla")
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Dim respuesta As Integer 'verifica llenado correcto, si falta registro da mensaje de llenar

        If txtnombres.Text <> "" And txtpaterno.Text <> "" And txtnacimiento.Text <> "" And txtsexo.Text <> "" And txtdireccion.Text <> "" And txtinscripcion.Text <> "" And txtGraduacion.Text <> "" And txttutor.Text <> "" Then
            Try
                Dim insert_per As New SqlCommand("guardar_estudiante", conexion)
                insert_per.CommandType = CommandType.StoredProcedure
                ' insert_per.Parameters.Add("id_usuario", SqlDbType.Int).Value = txtid_usuario.Text 'no se puede habilitar porque es incremental
                insert_per.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = txtnombres.Text
                insert_per.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = txtpaterno.Text
                insert_per.Parameters.Add("@fecha_nacimiento", SqlDbType.Date).Value = txtnacimiento.Text
                insert_per.Parameters.Add("@sexo", SqlDbType.VarChar, 1).Value = txtsexo.Text
                insert_per.Parameters.Add("@direccion", SqlDbType.VarChar, 80).Value = txtdireccion.Text
                insert_per.Parameters.Add("@fecha_inscripcion", SqlDbType.Date).Value = txtinscripcion.Text
                insert_per.Parameters.Add("@fecha_graduacion", SqlDbType.Date).Value = txtinscripcion.Text
                insert_per.Parameters.Add("@id_Encargado", SqlDbType.Int).Value = Val(txttutor.Text)

                conexion.Open()
                respuesta = insert_per.ExecuteNonQuery
                conexion.Close()
                If respuesta = 1 Then
                    MsgBox("El registro se grabó correctamente ", MsgBoxStyle.Information)
                    cargar_datos()
                    'otro procedimiento
                    limpiar()
                    'btnguardar.Visible = True
                    ' btnnuevo.Visible = False
                    lbltotal.Text = CStr(DataGridView1.RowCount)
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

    Private Sub btnact_Click(sender As Object, e As EventArgs) Handles btnact.Click
        Dim dt As New Data.DataSet
        Dim da As New SqlDataAdapter("select *from estudiante", conexion)
        da.Fill(dt, "tabla")
        DataGridView1.DataSource = dt.Tables("tabla")
    End Sub

    Private Sub btncargar_Click(sender As Object, e As EventArgs) Handles btncargar.Click
        Me.colortexthab() 'habilita los text box para su edicion
        Me.habilitar(True)
        Me.btneliminar.Enabled = True
        Me.btneditar.Enabled = True
        txtbusqueda.Enabled = False
        txtid.Enabled = False
        If txtci2.Text <> "" Then
            Try


                Dim consulta As String = "select *from estudiante where @id_estudiante=id_estudiante"
                Dim cmd As New SqlCommand(consulta, conexion)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@id_estudiante", txtci2.Text)
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count = 0 Then
                    MsgBox("No existe registro!", MsgBoxStyle.Critical)
                Else
                    txtid.Text = dt.Rows(0).Item("id_estudiante")
                    txtnombres.Text = dt.Rows(0).Item("nombre")
                    txtpaterno.Text = dt.Rows(0).Item("apellido")
                    txtnacimiento.Text = dt.Rows(0).Item("fecha_nacimiento")
                    txtsexo.Text = dt.Rows(0).Item("sexo")
                    txtdireccion.Text = dt.Rows(0).Item("direccion")
                    txtinscripcion.Text = dt.Rows(0).Item("fecha_inscripcion")
                    txtGraduacion.Text = dt.Rows(0).Item("fecha_graduacion")
                    txttutor.Text = dt.Rows(0).Item("id_Encargado")

                    Me.btnnuevo.Enabled = False
                    Me.btnguardar.Enabled = False
                End If
            Catch ex As Exception : MsgBox(ex.Message) 'mensaje de exception en caso de llenar datos

            End Try
        Else
            MessageBox.Show("Asegúrese de haber llenado los campo para poder continuar", "informe", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub
    Public Sub cargardatos()

        Dim consulta As String = "select *from estudiante"
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
        Dim cmd As New SqlCommand("eliminar_estudiante", conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@id_estudiante", txtid.Text)
        conexion.Open()
        respuesta = cmd.ExecuteNonQuery()
        conexion.Close()
        MsgBox(" el registro se ha borrado correctamente", MsgBoxStyle.Information)

        If respuesta = 1 Then
            cargardatos()
            limpiar() 'limpia datos de los textbox despues de borrar
            txtid.Text = ""
        End If
        lbltotal.Text = CStr(DataGridView1.RowCount)
    End Sub

    Private Sub btneditar_Click(sender As Object, e As EventArgs) Handles btneditar.Click
        Dim respuesta As Integer
        Me.btnnuevo.Enabled = False
        Me.btnguardar.Enabled = False
        Me.habilitar(True)
        Me.colortexthab()

        Dim cmd As New SqlCommand("editar_estudiante", conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@id_estudiante", txtid.Text)
        cmd.Parameters.AddWithValue("@nombre", txtnombres.Text)
        cmd.Parameters.AddWithValue("@apellido", txtpaterno.Text)
        cmd.Parameters.AddWithValue("@fecha_nacimiento", txtnacimiento.Text)
        cmd.Parameters.AddWithValue("@sexo", txtsexo.Text)
        cmd.Parameters.AddWithValue("@direccion", txtdireccion.Text)
        cmd.Parameters.AddWithValue("@fecha_inscripcion", txtinscripcion.Text)
        cmd.Parameters.AddWithValue("@fecha_graduacion", txtinscripcion.Text)
        cmd.Parameters.AddWithValue("@id_Encargado", txttutor.Text)


        conexion.Open()
        respuesta = cmd.ExecuteNonQuery()
        conexion.Close()
        cargardatos()

        If respuesta = 1 Then
            MsgBox(" El registro se modifico correctamente ", MsgBoxStyle.Information)

            'otro procedimiento
            limpiar() 'limpia todo los textbox
        End If
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

    Private Sub btnprimero_Click(sender As Object, e As EventArgs) Handles btnprimero.Click
        If (Not (DataGridView1.Rows(0).IsNewRow)) Then
            'nos posiciona en la primera celda de la primera fila
            DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(0)

        End If
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

    Private Sub btnultimo_Click(sender As Object, e As EventArgs) Handles btnultimo.Click
        'nos posiciona al ultimo registro 
        Dim celda As DataGridViewCell = DataGridView1.CurrentCell
        celda = DataGridView1.Rows(DataGridView1.RowCount - 2).Cells(0)
        DataGridView1.CurrentCell = celda
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Close()
    End Sub

   

    Private Sub txtnombres_TextChanged(sender As Object, e As EventArgs) Handles txtnombres.TextChanged
        txtnombres.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtnombres.Text)
        txtnombres.SelectionStart = txtnombres.Text.Length
    End Sub



    Private Sub txtpaterno_TextChanged(sender As Object, e As EventArgs) Handles txtpaterno.TextChanged
        txtpaterno.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtpaterno.Text)
        txtpaterno.SelectionStart = txtpaterno.Text.Length
    End Sub
    Private Sub txtdireccion_TextChanged(sender As Object, e As EventArgs) Handles txtdireccion.TextChanged
        txtdireccion.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtdireccion.Text)
        txtdireccion.SelectionStart = txtdireccion.Text.Length
    End Sub
    Private Sub txtpaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpaterno.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtnombres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnombres.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        frmvistaestudiante.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        frmvistaestudiante.Show()
    End Sub
End Class