Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'AnimeDataSet.BUSCAR_ANIME' Puede moverla o quitarla según sea necesario.
        Me.BUSCAR_ANIMETableAdapter.Fill(Me.AnimeDataSet.BUSCAR_ANIME)
        Me.ReportViewer1.RefreshReport()
    End Sub

End Class
