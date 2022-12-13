Imports System.Data
Imports System.Data.SqlClient
Public Class frmEncargado

    Private Sub frmhorarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.habilitar(True)

        'llamamos al procedimiento buscar

        Me.habilitar(False) 'deshabilita todo los text box
        Me.colortextblock()
        Me.btnguardar.Enabled = False
        Me.btneliminar.Enabled = False
        Me.btneditar.Enabled = False
        Me.txtid.Enabled = False

        ' Me.btneliminar.Enabled = False
        ' txtbusqueda.Enabled = False
        cargardatos()
        'alterna dos colores diferentes para el datagridview
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.Tan
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque
    End Sub


    'error en eliminar datos
    Sub elimina_datos() Handles MyBase.Load
        Dim dt As New Data.DataSet
        Dim da As New SqlDataAdapter("select *from Encargado", conexion)
        da.Fill(dt, "tabla")
        DataGridView1.DataSource = dt.Tables("tabla")

    End Sub
    Private Sub limpiar()
        'procedimiento para limpiar los registros
        txtid.Text = ""
        txtname.Text = ""
        txtApellido.Text = ""
        txtnacimiento.Text = ""
        txtsexo.Text = ""
        txtDIreccion.Text = ""
        txtParentesco.Text = ""
        txtTelefono.Text = ""


    End Sub
    Sub habilitar(ByVal e As Boolean)
        With Me
            ' .txtid_usuario.Enabled = e
            txtname.Enabled = e
            txtApellido.Enabled = e
            txtnacimiento.Enabled = e
            txtsexo.Enabled = e
            txtDIreccion.Enabled = e
            txtParentesco.Enabled = e
            txtTelefono.Enabled = e



        End With
    End Sub
    'cambia los colores para que se vean bloqueados con un color silver
    Sub colortextblock()
        txtid.BackColor = Color.Silver
        txtname.BackColor = Color.Silver
        txtApellido.BackColor = Color.Silver
        txtnacimiento.BackColor = Color.Silver
        txtsexo.BackColor = Color.Silver
        txtDIreccion.BackColor = Color.Silver
        txtParentesco.BackColor = Color.Silver
        txtTelefono.BackColor = Color.Silver
    End Sub




    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
    Sub colortexthab()

        txtname.BackColor = Color.White
        txtApellido.BackColor = Color.White
        txtnacimiento.BackColor = Color.White
        txtsexo.BackColor = Color.White
        txtDIreccion.BackColor = Color.White
        txtParentesco.BackColor = Color.White
        txtTelefono.BackColor = Color.White
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
        Dim da As New SqlDataAdapter("select *from Encargado", conexion)
        da.Fill(dt, "tabla")
        DataGridView1.DataSource = dt.Tables("tabla")
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Dim respuesta As Integer 'verifica llenado correcto, si falta registro da mensaje de llenar

        If txtname.Text <> "" And txtApellido.Text <> "" And txtnacimiento.Text <> "" And txtsexo.Text <> "" And txtDIreccion.Text <> "" And txtParentesco.Text <> "" And txtTelefono.Text <> "" Then
            Try
                Dim insert_per As New SqlCommand("guardar_Encargado", conexion)
                insert_per.CommandType = CommandType.StoredProcedure
                ' insert_per.Parameters.Add("id_usuario", SqlDbType.Int).Value = txtid_usuario.Text 'no se puede habilitar porque es incremental
                insert_per.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = txtname.Text
                insert_per.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = txtApellido.Text
                insert_per.Parameters.Add("@fehca_nacimiento", SqlDbType.Date).Value = txtnacimiento.Text
                insert_per.Parameters.Add("@sexo", SqlDbType.VarChar, 1).Value = txtsexo.Text
                insert_per.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = txtDIreccion.Text
                insert_per.Parameters.Add("@parentesco", SqlDbType.VarChar, 50).Value = txtParentesco.Text
                insert_per.Parameters.Add("@telefono", SqlDbType.VarChar, 8).Value = txtTelefono.Text
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

    Private Sub btnact_Click(sender As Object, e As EventArgs) Handles btnact.Click
        Dim dt As New Data.DataSet
        Dim da As New SqlDataAdapter("select *from Encargado", conexion)
        da.Fill(dt, "tabla")
        DataGridView1.DataSource = dt.Tables("tabla")
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
    Private Sub btncargar_Click_1(sender As Object, e As EventArgs) Handles btncargar.Click
        Me.colortexthab() 'habilita los text box para su edicion
        Me.habilitar(True)
        Me.btneliminar.Enabled = True
        Me.btneditar.Enabled = True
        txtbusqueda.Enabled = False
        txtid.Enabled = False
        If txtci2.Text <> "" Then
            Try


                Dim consulta As String = "select *from Encargado where @id_Encargado=id_Encargado"
                Dim cmd As New SqlCommand(consulta, conexion)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@id_Encargado", txtci2.Text)
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count = 0 Then
                    MsgBox("No existe registro!", MsgBoxStyle.Critical)
                Else
                    txtid.Text = dt.Rows(0).Item("id_Encargado")
                    txtname.Text = dt.Rows(0).Item("nombre")
                    txtApellido.Text = dt.Rows(0).Item("apellido")
                    txtnacimiento.Text = dt.Rows(0).Item("fehca_nacimiento")
                    txtsexo.Text = dt.Rows(0).Item("sexo")
                    txtDIreccion.Text = dt.Rows(0).Item("direccion")
                    txtParentesco.Text = dt.Rows(0).Item("parentesco")
                    txtTelefono.Text = dt.Rows(0).Item("telefono")

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

        Dim consulta As String = "select *from Encargado"
        Dim cmd As New SqlCommand(consulta, conexion)
        Dim dt As New DataTable
        cmd.CommandType = CommandType.Text
        Dim da As New SqlDataAdapter(cmd)
        Dim st As New DataSet
        da.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub
    Private Sub btneliminar_Click_1(sender As Object, e As EventArgs) Handles btneliminar.Click
        Dim respuesta As Integer
        Dim cmd As New SqlCommand("Eliminar_encargado", conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@id_Encargado", txtid.Text)
        conexion.Open()
        respuesta = cmd.ExecuteNonQuery()
        conexion.Close()
        MsgBox("el usuario se ha borrado correctamente", MsgBoxStyle.Information)
        If respuesta = 1 Then
            cargardatos()
            limpiar() 'limpia datos de los textbox despues de borrar
        End If

    End Sub

    Private Sub btneditar_Click_1(sender As Object, e As EventArgs) Handles btneditar.Click
        Dim respuesta As Integer
        Me.btnnuevo.Enabled = False
        Me.btnguardar.Enabled = False
        Me.habilitar(True)
        Me.colortexthab()

        Dim cmd As New SqlCommand("editar_Encargado", conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@id_Encargado", txtid.Text)
        cmd.Parameters.AddWithValue("@nombre", txtname.Text)
        cmd.Parameters.AddWithValue("@apellido", txtApellido.Text)
        cmd.Parameters.AddWithValue("@fehca_nacimiento", txtnacimiento.Text)
        cmd.Parameters.AddWithValue("@sexo", txtsexo.Text)
        cmd.Parameters.AddWithValue("@direccion", txtDIreccion.Text)
        cmd.Parameters.AddWithValue("@parentesco", txtParentesco.Text)
        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text)
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
    ''***********************validamos que solo sean insertados letras a letras y numeros a numeros************ 

    Private Sub txtname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtname.KeyPress

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

    Private Sub txtapellido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellido.KeyPress
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
    Private Sub txtsexo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsexo.KeyPress
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


    Private Sub txttelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Char.IsDigit(e.KeyChar) Then 'solo insertar caracteres de tipo numerico
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    '**********************los texttbox que esten en estas lineas de codigo empienzan en mayuscula-.*************
    Private Sub txtname_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged
        txtname.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtname.Text)
        txtname.SelectionStart = txtname.Text.Length
    End Sub

    Private Sub txtpaterno_TextChanged(sender As Object, e As EventArgs) Handles txtApellido.TextChanged
        txtApellido.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellido.Text)
        txtApellido.SelectionStart = txtApellido.Text.Length
    End Sub
    Private Sub txtdireccion_TextChanged(sender As Object, e As EventArgs) Handles txtDIreccion.TextChanged
        txtDIreccion.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtDIreccion.Text)
        txtDIreccion.SelectionStart = txtDIreccion.Text.Length
    End Sub
End Class