Imports System.IO
Imports System.Data.SqlClient

Imports WindowsApplication1
Public Class Form1
    Dim db As New AnimeEntities
    Dim wf As New WindowsApplication1.FormReporte



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call llenaGrilla()
    End Sub


   Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

        Dim Ms As New MemoryStream
        Me.PictureBox1.Image.Save(Ms, Imaging.ImageFormat.Bmp)
        Dim DATA() As Byte = Ms.ToArray

        Dim objanime As New RegistroAnime

        With objanime
            .CodAnime = txtCodigo.Text
            .NomAnime = txtNombre.Text
            .Temporadas = txtTemporadas.Text
            .foto = DATA

            If cbxDSi.Checked = True Then
                .Descargar = cbxDSi.Text
            Else
                .Descargar = cbxDNo.Text
            End If

            If cbxVSi.Checked = True Then
                .Visto = cbxVSi.Text
            Else
                .Visto = cbxVNo.Text
            End If


            db.RegistroAnime.Add(objanime)
            db.SaveChanges()
            MessageBox.Show("Registro Exitoso")

            'Me.dgvGrilla.Rows.Add(txtCodigo.Text, txtNombre.Text, txtTemporadas.Text, cbxVSi.Text, cbxVNo.Text)

            Call llenaGrilla()

            limpiarcampos()


        End With
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        Dim Ms As New MemoryStream
        Me.PictureBox1.Image.Save(Ms, Imaging.ImageFormat.Jpeg)
        Dim DATA() As Byte = Ms.ToArray

        Dim objmod As RegistroAnime = db.RegistroAnime.ToList.ElementAt(dgvGrilla.CurrentRow.Index)
        With objmod
            .CodAnime = txtCodigo.Text
            .NomAnime = txtNombre.Text
            .Temporadas = txtTemporadas.Text
            .foto = DATA

            If cbxDSi.Checked = True Then
                objmod.Descargar = cbxDSi.Text
            Else
                objmod.Descargar = cbxDNo.Text
            End If

            If cbxVSi.Checked = True Then
                objmod.Visto = cbxVSi.Text
            Else
                objmod.Visto = cbxVNo.Text
            End If

            db.SaveChanges()
            MessageBox.Show("Actualización exitosa")
            Call llenaGrilla()
        End With
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Dim objanime As RegistroAnime = db.RegistroAnime.ToList.ElementAt(dgvGrilla.CurrentRow.Index)
        db.RegistroAnime.Remove(objanime)
        db.SaveChanges()
        Me.dgvGrilla.DataSource = db.RegistroAnime.ToList

        MessageBox.Show("Se eliminó Registro Correctamente")

    End Sub

    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click

        'Buscar la imágen que se visualza en el Picturebox
        Dim buscar As New OpenFileDialog
        buscar.Filter = "Archivo de Imagen|*.jpg"
        'Si se presiona el boton OK
        If buscar.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.PictureBox1.Image = Image.FromFile(buscar.FileName)
        End If

    End Sub

    Sub llenaGrilla()
        dgvGrilla.DataSource = db.RegistroAnime.ToList
    End Sub

    Sub limpiarcampos()
        Dim x As Control

        For Each x In Me.Controls
            If TypeOf x Is System.Windows.Forms.TextBox Then x.Text = ""
        Next

        cbxDSi.Checked = False
        cbxDNo.Checked = False
        cbxVSi.Checked = False
        cbxVNo.Checked = False

    End Sub


    Private Sub dgvGrilla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGrilla.CellClick
   
        With dgvGrilla.CurrentRow
            txtCodigo.Text = .Cells(0).Value
            txtNombre.Text = .Cells(1).Value
            txtTemporadas.Text = .Cells(2).Value
            cbxDSi.Text = .Cells(3).Value

                Try
                    'Obtener datos de imagen de la columna gridview
                    Dim imageData As Byte() = DirectCast(.Cells(5).Value, Byte())
                    'Initialize image variable
                    Dim newImage As Image
                    'Inicialice la variable imagen
                    Using ms As New MemoryStream(imageData, 0, imageData.Length)
                        ms.Write(imageData, 0, imageData.Length)
                        'Establecer imagen valor de la variable usando secuencia de memoria
                        newImage = Image.FromStream(ms, True)
                    End Using
                    'Foto
                    PictureBox1.Image = newImage
                Catch ex As Exception
                    'MessageBox.Show(ex.ToString())
                    MessageBox.Show("No se tiene una imagen que mostrar, actualice imágen")
                End Try
        End With
    End Sub

  
  
    Private Sub txtTemporadas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTemporadas.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    'limpias el portapapeles de esa manera no podras pegar nada de nada en el textBox
    Private Sub txtCodigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.GotFocus
        Clipboard.Clear()
    End Sub

    'cada vez que un usuario quiera dar click derecho le va a salir el mensaje "No se permite utilizar el boton derecho del mouse en este campo
    Private Sub txtTemporadas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtTemporadas.MouseDown
        If (e.Button = Windows.Forms.MouseButtons.Right) Then
            MsgBox("No se permite utilizar el boton derecho del mouse en este campo",
            MsgBoxStyle.Critical, "Atencion")
            Exit Sub
        End If
    End Sub

    Private Sub txtCodigo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCodigo.MouseDown
        If (e.Button = Windows.Forms.MouseButtons.Right) Then
            MsgBox("No se permite utilizar el boton derecho del mouse en este campo",
            MsgBoxStyle.Critical, "Atencion")
            Exit Sub
        End If
    End Sub
 

    Private Sub cbxDSi_Click(sender As Object, e As EventArgs) Handles cbxDSi.Click
        If cbxDSi.Checked = False Then
            cbxDSi.Visible = True
            If cbxDSi.Checked = True Then
            Else : cbxDNo.Enabled = True
            End If
        Else : cbxDNo.Enabled = False
        End If
    End Sub

    Private Sub cbxDNo_Click(sender As Object, e As EventArgs) Handles cbxDNo.Click
        If cbxDNo.Checked = False Then
            cbxDNo.Visible = True
            If cbxDNo.Checked = True Then
            Else : cbxDSi.Enabled = True
            End If
        Else : cbxDSi.Enabled = False
        End If
    End Sub

    Private Sub cbxVSi_Click(sender As Object, e As EventArgs) Handles cbxVSi.Click
        If cbxVSi.Checked = False Then
            cbxVSi.Visible = True
            If cbxVSi.Checked = True Then
            Else : cbxVNo.Enabled = True
            End If
        Else : cbxVNo.Enabled = False
        End If
    End Sub

    Private Sub cbxVNo_Click(sender As Object, e As EventArgs) Handles cbxVNo.Click
        If cbxVNo.Checked = False Then
            cbxVNo.Visible = True
            If cbxVNo.Checked = True Then
            Else : cbxVSi.Enabled = True
            End If
        Else : cbxVSi.Enabled = False
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

        wf.Show()

    End Sub
End Class
