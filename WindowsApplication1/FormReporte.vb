Public Class FormReporte


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.BUSCAR_ANIMETableAdapter.Fill(Me.DataSet1.BUSCAR_ANIME, (txtBuscar.Text))

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class
