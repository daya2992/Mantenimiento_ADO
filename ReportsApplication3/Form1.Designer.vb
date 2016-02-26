<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTA: Windows Form Designer requiere el procedimiento siguiente
    'No puede modificarse con Windows Form Designer.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.AnimeDataSet = New ReportsApplication3.AnimeDataSet()
        Me.BUSCAR_ANIMEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BUSCAR_ANIMETableAdapter = New ReportsApplication3.AnimeDataSetTableAdapters.BUSCAR_ANIMETableAdapter()
        CType(Me.AnimeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BUSCAR_ANIMEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.BUSCAR_ANIMEBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ReportsApplication3.Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(682, 386)
        Me.ReportViewer1.TabIndex = 0
        '
        'AnimeDataSet
        '
        Me.AnimeDataSet.DataSetName = "AnimeDataSet"
        Me.AnimeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BUSCAR_ANIMEBindingSource
        '
        Me.BUSCAR_ANIMEBindingSource.DataMember = "BUSCAR_ANIME"
        Me.BUSCAR_ANIMEBindingSource.DataSource = Me.AnimeDataSet
        '
        'BUSCAR_ANIMETableAdapter
        '
        Me.BUSCAR_ANIMETableAdapter.ClearBeforeFill = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 386)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.AnimeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BUSCAR_ANIMEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents BUSCAR_ANIMEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AnimeDataSet As ReportsApplication3.AnimeDataSet
    Friend WithEvents BUSCAR_ANIMETableAdapter As ReportsApplication3.AnimeDataSetTableAdapters.BUSCAR_ANIMETableAdapter

End Class
