namespace SIST_VENTAS_01
{
    partial class frmComprobante
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.comporbantePBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASE_SIST_VENT_CDataSet = new SIST_VENTAS_01.BASE_SIST_VENT_CDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.comporbantePTableAdapter = new SIST_VENTAS_01.BASE_SIST_VENT_CDataSetTableAdapters.comporbantePTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.comporbantePBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASE_SIST_VENT_CDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // comporbantePBindingSource
            // 
            this.comporbantePBindingSource.DataMember = "comporbanteP";
            this.comporbantePBindingSource.DataSource = this.bASE_SIST_VENT_CDataSet;
            // 
            // bASE_SIST_VENT_CDataSet
            // 
            this.bASE_SIST_VENT_CDataSet.DataSetName = "BASE_SIST_VENT_CDataSet";
            this.bASE_SIST_VENT_CDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.comporbantePBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SIST_VENTAS_01.MODULOS.reportes.rptComporbanteP.rdlc";
            this.reportViewer1.LocalReport.ReportPath = "G:\\PROYECTOS C#\\SIST_VENTAS_01\\MODULOS\\rptComporbanteP.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(574, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // comporbantePTableAdapter
            // 
            this.comporbantePTableAdapter.ClearBeforeFill = true;
            // 
            // frmComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmComprobante";
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.frmComprobante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comporbantePBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASE_SIST_VENT_CDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource comporbantePBindingSource;
        private BASE_SIST_VENT_CDataSet bASE_SIST_VENT_CDataSet;
        private BASE_SIST_VENT_CDataSetTableAdapters.comporbantePTableAdapter comporbantePTableAdapter;
    }
}