using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace AGCI.Reportes
{
    partial class GuiaAutoControlReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuiaAutoControlReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.cgr = new DevExpress.XtraReports.UI.XRTableCell();
            this.otros = new DevExpress.XtraReports.UI.XRTableCell();
            this.Nop = new DevExpress.XtraReports.UI.XRTableCell();
            this.NoPreg = new DevExpress.XtraReports.UI.XRTableCell();
            this.Guia = new DevExpress.XtraReports.UI.XRTableCell();
            this.S = new DevExpress.XtraReports.UI.XRTableCell();
            this.NO = new DevExpress.XtraReports.UI.XRTableCell();
            this.NP = new DevExpress.XtraReports.UI.XRTableCell();
            this.Responsable = new DevExpress.XtraReports.UI.XRTableCell();
            this.Jefe = new DevExpress.XtraReports.UI.XRTableCell();
            this.Direccion = new DevExpress.XtraReports.UI.XRTableCell();
            this.Componente = new DevExpress.XtraReports.UI.XRTableCell();
            this.Norma = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
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
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
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
            this.cgr,
            this.otros,
            this.Nop,
            this.NoPreg,
            this.Guia,
            this.S,
            this.NO,
            this.NP,
            this.Responsable,
            this.Jefe,
            this.Direccion,
            this.Componente,
            this.Norma});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // cgr
            // 
            this.cgr.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.cgr.Name = "cgr";
            this.cgr.StylePriority.UseBorders = false;
            this.cgr.Weight = 0.21918744432930568D;
            // 
            // otros
            // 
            this.otros.Name = "otros";
            this.otros.Weight = 0.22854791110457981D;
            // 
            // Nop
            // 
            this.Nop.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Nop.Name = "Nop";
            this.Nop.StylePriority.UseBorders = false;
            this.Nop.Weight = 0.21605657741652512D;
            // 
            // NoPreg
            // 
            this.NoPreg.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.NoPreg.Font = new System.Drawing.Font("Verdana", 7F);
            this.NoPreg.Name = "NoPreg";
            this.NoPreg.StylePriority.UseBorders = false;
            this.NoPreg.StylePriority.UseFont = false;
            this.NoPreg.Weight = 0.27349028957149063D;
            // 
            // Guia
            // 
            this.Guia.Font = new System.Drawing.Font("Verdana", 8F);
            this.Guia.Name = "Guia";
            this.Guia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.Guia.StylePriority.UseFont = false;
            this.Guia.StylePriority.UsePadding = false;
            this.Guia.StylePriority.UseTextAlignment = false;
            this.Guia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            this.Guia.Weight = 1.0402902405138974D;
            // 
            // S
            // 
            this.S.Name = "S";
            this.S.Weight = 0.18653958971672627D;
            // 
            // NO
            // 
            this.NO.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.NO.Name = "NO";
            this.NO.StylePriority.UseBorders = false;
            this.NO.Weight = 0.1813476116134331D;
            // 
            // NP
            // 
            this.NP.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.NP.Name = "NP";
            this.NP.StylePriority.UseBorders = false;
            this.NP.Weight = 0.16919160189231405D;
            // 
            // Responsable
            // 
            this.Responsable.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Responsable.Font = new System.Drawing.Font("Verdana", 7F);
            this.Responsable.Name = "Responsable";
            this.Responsable.StylePriority.UseBorders = false;
            this.Responsable.StylePriority.UseFont = false;
            this.Responsable.Weight = 0.7477374899746656D;
            // 
            // Jefe
            // 
            this.Jefe.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Jefe.Font = new System.Drawing.Font("Verdana", 7F);
            this.Jefe.Name = "Jefe";
            this.Jefe.StylePriority.UseBorders = false;
            this.Jefe.StylePriority.UseFont = false;
            this.Jefe.Weight = 0.63098458965997373D;
            // 
            // Direccion
            // 
            this.Direccion.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Direccion.Font = new System.Drawing.Font("Verdana", 7F);
            this.Direccion.Name = "Direccion";
            this.Direccion.StylePriority.UseBorders = false;
            this.Direccion.StylePriority.UseFont = false;
            this.Direccion.Weight = 0.52286838485714382D;
            // 
            // Componente
            // 
            this.Componente.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Componente.Font = new System.Drawing.Font("Verdana", 7F);
            this.Componente.Name = "Componente";
            this.Componente.StylePriority.UseBorders = false;
            this.Componente.StylePriority.UseFont = false;
            this.Componente.Weight = 0.43153700492443026D;
            // 
            // Norma
            // 
            this.Norma.Font = new System.Drawing.Font("Verdana", 7F);
            this.Norma.Name = "Norma";
            this.Norma.StylePriority.UseFont = false;
            this.Norma.Weight = 0.65633298207674162D;
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
            this.xrLabel2,
            this.xrPictureBox1,
            this.xrLabel1});
            this.ReportHeader.HeightF = 88.54173F;
            this.ReportHeader.Name = "ReportHeader";
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
            this.xrLabel2.Text = "GUIA DE AUTOCONTROL";
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
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell5});
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
            this.xrTableCell1.Text = "CGR";
            this.xrTableCell1.Weight = 0.21918745648117011D;
            // 
            // entidad_name
            // 
            this.entidad_name.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.entidad_name.Font = new System.Drawing.Font("Verdana", 7F);
            this.entidad_name.Name = "entidad_name";
            this.entidad_name.StylePriority.UseBorders = false;
            this.entidad_name.StylePriority.UseFont = false;
            this.entidad_name.Text = "Otros";
            this.entidad_name.Weight = 0.22854796906835431D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell2.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.Text = "No. P/Med";
            this.xrTableCell2.Weight = 0.2160566022672491D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.Text = "NO. Preguntas";
            this.xrTableCell4.Weight = 0.27349029968770355D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell3.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.Text = "GUIA APLICADA ";
            this.xrTableCell3.Weight = 1.0402901377354157D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell9.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.Text = "S";
            this.xrTableCell9.Weight = 0.18653958998349429D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell6.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseBorders = false;
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.Text = "NO";
            this.xrTableCell6.Weight = 0.18134755404587311D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell7.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.Text = "NP";
            this.xrTableCell7.Weight = 0.16919207173220641D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell8.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.Text = "Responsable";
            this.xrTableCell8.Weight = 0.74773683930595292D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.Text = "Jefe Inmediato";
            this.xrTableCell10.Weight = 0.63098428123497363D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseFont = false;
            this.xrTableCell11.Text = "Dirección";
            this.xrTableCell11.Weight = 0.52286839478187885D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseFont = false;
            this.xrTableCell12.Text = "Componente";
            this.xrTableCell12.Weight = 0.43153762885076813D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell5.Font = new System.Drawing.Font("Verdana", 7F);
            this.xrTableCell5.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseBorders = false;
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.StylePriority.UseForeColor = false;
            this.xrTableCell5.Text = "Norma";
            this.xrTableCell5.Weight = 0.65633290643728792D;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 35.41666F;
            this.PageHeader.Name = "PageHeader";
            // 
            // GuiaAutoControlReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(26, 26, 70, 49);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "14.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DetailBand Detail;
        private TopMarginBand TopMargin;
        private BottomMarginBand BottomMargin;
        private XRTable xrTable2;
        private XRTableRow xrTableRow2;
        private XRTableCell cgr;
        private XRTableCell NoPreg;
        private XRTableCell NO;
        private ReportHeaderBand ReportHeader;
        private XRTable xrTable1;
        private XRTableRow xrTableRow1;
        private XRTableCell xrTableCell1;
        private XRTableCell xrTableCell2;
        private XRTableCell xrTableCell3;
        private XRTableCell Nop;
        private XRTableCell Responsable;
        private XRTableCell entidad_name;
        private XRTableCell xrTableCell6;
        private XRLabel xrLabel1;
        private XRTableCell Componente;
        private XRTableCell xrTableCell5;
        private XRTableCell NP;
        private XRTableCell Direccion;
        private XRTableCell xrTableCell9;
        private XRTableCell xrTableCell8;
        private XRTableCell Jefe;
        private XRTableCell xrTableCell7;
        private XRPictureBox xrPictureBox1;
        private XRPageInfo xrPageInfo2;
        private XRPageInfo xrPageInfo1;
        private XRLabel xrLabel2;
        private PageHeaderBand PageHeader;
        private XRTableCell S;
        private XRTableCell xrTableCell4;
        private XRTableCell otros;
        private XRTableCell Guia;
        private XRTableCell Norma;
        private XRTableCell xrTableCell10;
        private XRTableCell xrTableCell11;
        private XRTableCell xrTableCell12;
    }
}
