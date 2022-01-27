using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace AGCI.Reportes
{
    partial class EstadisticaResumenComponenteReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstadisticaResumenComponenteReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.actividad = new DevExpress.XtraReports.UI.XRTableCell();
            this.positivo = new DevExpress.XtraReports.UI.XRTableCell();
            this.porcP = new DevExpress.XtraReports.UI.XRTableCell();
            this.negativo = new DevExpress.XtraReports.UI.XRTableCell();
            this.proN = new DevExpress.XtraReports.UI.XRTableCell();
            this.nop = new DevExpress.XtraReports.UI.XRTableCell();
            this.porcNP = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.entidad_name = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TotalP = new DevExpress.XtraReports.UI.XRTableCell();
            this.Ppor = new DevExpress.XtraReports.UI.XRTableCell();
            this.TotalN = new DevExpress.XtraReports.UI.XRTableCell();
            this.Npor = new DevExpress.XtraReports.UI.XRTableCell();
            this.TotalNp = new DevExpress.XtraReports.UI.XRTableCell();
            this.Nppro = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Verdana", 8F);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1097F, 25F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.actividad,
            this.positivo,
            this.porcP,
            this.negativo,
            this.proN,
            this.nop,
            this.porcNP});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // actividad
            // 
            this.actividad.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.actividad.Font = new System.Drawing.Font("Verdana", 7F);
            this.actividad.Name = "actividad";
            this.actividad.StylePriority.UseBorders = false;
            this.actividad.StylePriority.UseFont = false;
            this.actividad.Weight = 2.4299890954010253D;
            // 
            // positivo
            // 
            this.positivo.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.positivo.Name = "positivo";
            this.positivo.StylePriority.UseBorders = false;
            this.positivo.Weight = 0.57369129317346546D;
            // 
            // porcP
            // 
            this.porcP.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.porcP.Font = new System.Drawing.Font("Verdana", 7F);
            this.porcP.Name = "porcP";
            this.porcP.StylePriority.UseBorders = false;
            this.porcP.StylePriority.UseFont = false;
            this.porcP.Weight = 0.41067616406665347D;
            // 
            // negativo
            // 
            this.negativo.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.negativo.Font = new System.Drawing.Font("Verdana", 7F);
            this.negativo.Name = "negativo";
            this.negativo.StylePriority.UseBorders = false;
            this.negativo.StylePriority.UseFont = false;
            this.negativo.Weight = 0.65984732083003894D;
            // 
            // proN
            // 
            this.proN.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.proN.Font = new System.Drawing.Font("Verdana", 7F);
            this.proN.Name = "proN";
            this.proN.StylePriority.UseBorders = false;
            this.proN.StylePriority.UseFont = false;
            this.proN.Weight = 0.41067584445310373D;
            // 
            // nop
            // 
            this.nop.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.nop.Font = new System.Drawing.Font("Verdana", 7F);
            this.nop.Name = "nop";
            this.nop.StylePriority.UseBorders = false;
            this.nop.StylePriority.UseFont = false;
            this.nop.Weight = 0.60124569322754828D;
            // 
            // porcNP
            // 
            this.porcNP.Font = new System.Drawing.Font("Verdana", 7F);
            this.porcNP.Name = "porcNP";
            this.porcNP.StylePriority.UseFont = false;
            this.porcNP.Weight = 0.41798630649939217D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 70F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1});
            this.BottomMargin.HeightF = 48.95833F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.StylePriority.UseBorders = false;
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Format = "Página {0} de {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(998.1667F, 22.20834F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(108.8333F, 23F);
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Format = "{0:dd/MM/yy}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 22.20834F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(89.23615F, 23F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.fecha,
            this.xrLabel2,
            this.xrPictureBox1,
            this.xrLabel1});
            this.ReportHeader.HeightF = 88.54173F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // fecha
            // 
            this.fecha.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.fecha.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.fecha.LocationFloat = new DevExpress.Utils.PointFloat(196.8056F, 65.54174F);
            this.fecha.Name = "fecha";
            this.fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fecha.SizeF = new System.Drawing.SizeF(745.7054F, 22.99999F);
            this.fecha.StylePriority.UseBorderDashStyle = false;
            this.fecha.StylePriority.UseFont = false;
            this.fecha.StylePriority.UseTextAlignment = false;
            this.fecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(196.8056F, 38.45838F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(745.7054F, 22.99999F);
            this.xrLabel2.StylePriority.UseBorderDashStyle = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "TABLA   RESUMEN POR COMPONENTES ";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(23.6111F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(150.2778F, 78.54173F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLabel1
            // 
            this.xrLabel1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(196.8056F, 10F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(745.7054F, 22.99999F);
            this.xrLabel1.StylePriority.UseBorderDashStyle = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "AZUMAT";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTable1
            // 
            this.xrTable1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1097F, 35.41666F);
            this.xrTable1.StylePriority.UseBackColor = false;
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.entidad_name,
            this.xrTableCell2,
            this.xrTableCell4,
            this.xrTableCell3,
            this.xrTableCell9,
            this.xrTableCell6});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell1.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.Text = "COMPONENTES Y NORMAS";
            this.xrTableCell1.Weight = 2.4299889439394038D;
            // 
            // entidad_name
            // 
            this.entidad_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.entidad_name.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.entidad_name.Font = new System.Drawing.Font("Verdana", 7F);
            this.entidad_name.Name = "entidad_name";
            this.entidad_name.StylePriority.UseBackColor = false;
            this.entidad_name.StylePriority.UseBorders = false;
            this.entidad_name.StylePriority.UseFont = false;
            this.entidad_name.Text = "POSITIVO";
            this.entidad_name.Weight = 0.57369201816332516D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell2.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseBackColor = false;
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.Text = "%";
            this.xrTableCell2.Weight = 0.4106759680627789D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.xrTableCell4.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseBackColor = false;
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.Text = "NEGATIVO";
            this.xrTableCell4.Weight = 0.65984705315815628D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell3.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseBackColor = false;
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.Text = "%";
            this.xrTableCell3.Weight = 0.4106759723225335D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.BackColor = System.Drawing.Color.Yellow;
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell9.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseBackColor = false;
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.Text = "NO PROCEDE";
            this.xrTableCell9.Weight = 0.60124570308491931D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.BackColor = System.Drawing.Color.Yellow;
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell6.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseBackColor = false;
            this.xrTableCell6.StylePriority.UseBorders = false;
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.Text = "%";
            this.xrTableCell6.Weight = 0.41798607288121081D;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 35.41666F;
            this.PageHeader.Name = "PageHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.ReportFooter.HeightF = 25F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Font = new System.Drawing.Font("Verdana", 8F);
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(9.999959F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(1097F, 25F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.TotalP,
            this.Ppor,
            this.TotalN,
            this.Npor,
            this.TotalNp,
            this.Nppro});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell5.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseBackColor = false;
            this.xrTableCell5.StylePriority.UseBorders = false;
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.Text = "TOTAL";
            this.xrTableCell5.Weight = 2.4299890954010253D;
            // 
            // TotalP
            // 
            this.TotalP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TotalP.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.TotalP.Name = "TotalP";
            this.TotalP.StylePriority.UseBackColor = false;
            this.TotalP.StylePriority.UseBorders = false;
            this.TotalP.Weight = 0.57369129317346546D;
            // 
            // Ppor
            // 
            this.Ppor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Ppor.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Ppor.Font = new System.Drawing.Font("Verdana", 7F);
            this.Ppor.Name = "Ppor";
            this.Ppor.StylePriority.UseBackColor = false;
            this.Ppor.StylePriority.UseBorders = false;
            this.Ppor.StylePriority.UseFont = false;
            this.Ppor.Weight = 0.41067616406665347D;
            // 
            // TotalN
            // 
            this.TotalN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TotalN.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.TotalN.Font = new System.Drawing.Font("Verdana", 7F);
            this.TotalN.Name = "TotalN";
            this.TotalN.StylePriority.UseBackColor = false;
            this.TotalN.StylePriority.UseBorders = false;
            this.TotalN.StylePriority.UseFont = false;
            this.TotalN.Weight = 0.65984732083003894D;
            // 
            // Npor
            // 
            this.Npor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Npor.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Npor.Font = new System.Drawing.Font("Verdana", 7F);
            this.Npor.Name = "Npor";
            this.Npor.StylePriority.UseBackColor = false;
            this.Npor.StylePriority.UseBorders = false;
            this.Npor.StylePriority.UseFont = false;
            this.Npor.Weight = 0.41067584445310373D;
            // 
            // TotalNp
            // 
            this.TotalNp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TotalNp.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.TotalNp.Font = new System.Drawing.Font("Verdana", 7F);
            this.TotalNp.Name = "TotalNp";
            this.TotalNp.StylePriority.UseBackColor = false;
            this.TotalNp.StylePriority.UseBorders = false;
            this.TotalNp.StylePriority.UseFont = false;
            this.TotalNp.Weight = 0.60124569322754828D;
            // 
            // Nppro
            // 
            this.Nppro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Nppro.Font = new System.Drawing.Font("Verdana", 7F);
            this.Nppro.Name = "Nppro";
            this.Nppro.StylePriority.UseBackColor = false;
            this.Nppro.StylePriority.UseFont = false;
            this.Nppro.Weight = 0.41798630649939217D;
            // 
            // EstadisticaResumenComponenteReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(26, 26, 70, 49);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "14.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DetailBand Detail;
        private TopMarginBand TopMargin;
        private BottomMarginBand BottomMargin;
        private XRTable xrTable2;
        private XRTableRow xrTableRow2;
        private XRTableCell actividad;
        private ReportHeaderBand ReportHeader;
        private XRTable xrTable1;
        private XRTableRow xrTableRow1;
        private XRTableCell xrTableCell1;
        private XRTableCell xrTableCell2;
        private XRTableCell xrTableCell3;
        private XRTableCell porcP;
        private XRTableCell entidad_name;
        private XRTableCell xrTableCell6;
        private XRLabel xrLabel1;
        private XRTableCell nop;
        private XRTableCell positivo;
        private XRTableCell proN;
        private XRTableCell xrTableCell9;
        private XRTableCell negativo;
        private XRPictureBox xrPictureBox1;
        private XRPageInfo xrPageInfo2;
        private XRPageInfo xrPageInfo1;
        private XRLabel xrLabel2;
        private PageHeaderBand PageHeader;
        private XRTableCell xrTableCell4;
        private XRTableCell porcNP;
        private XRLabel fecha;
        private ReportFooterBand ReportFooter;
        private XRTable xrTable3;
        private XRTableRow xrTableRow3;
        private XRTableCell xrTableCell5;
        private XRTableCell TotalP;
        private XRTableCell Ppor;
        private XRTableCell TotalN;
        private XRTableCell Npor;
        private XRTableCell TotalNp;
        private XRTableCell Nppro;
    }
}
