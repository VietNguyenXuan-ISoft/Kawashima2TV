namespace NucPos123
{
  partial class frmMain
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
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
      this.tmrDateTime = new System.Windows.Forms.Timer(this.components);
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
      this.lblSafetyDay = new System.Windows.Forms.Label();
      this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
      this.lblQualityDay = new System.Windows.Forms.Label();
      this.lbShift = new System.Windows.Forms.Label();
      this.lbOperator = new System.Windows.Forms.Label();
      this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.lbTargetOR = new System.Windows.Forms.Label();
      this.lbProcessingValueOR = new System.Windows.Forms.Label();
      this.gaugeOR = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.panel3 = new System.Windows.Forms.Panel();
      this.lbTargetOLE = new System.Windows.Forms.Label();
      this.lbProcessingValueOLE = new System.Windows.Forms.Label();
      this.gaugeOLE = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
      this.lblActual = new System.Windows.Forms.Label();
      this.lblTarget = new System.Windows.Forms.Label();
      this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
      this.lbLoss = new System.Windows.Forms.Label();
      this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
      this.lbLossSFGs = new System.Windows.Forms.Label();
      this.lbLossPM = new System.Windows.Forms.Label();
      this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
      this.lbCodeProduct = new System.Windows.Forms.Label();
      this.lnNameProduct = new System.Windows.Forms.Label();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
      this.lbFillerSFGs = new System.Windows.Forms.Label();
      this.lbFillerPM = new System.Windows.Forms.Label();
      this.ptbFill = new System.Windows.Forms.PictureBox();
      this.lbPackerSFGs = new System.Windows.Forms.Label();
      this.lbErectorPM = new System.Windows.Forms.Label();
      this.lbPackerPM = new System.Windows.Forms.Label();
      this.ptbErector = new System.Windows.Forms.PictureBox();
      this.ptbPacker = new System.Windows.Forms.PictureBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.tableLayoutPanel2.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.tableLayoutPanel4.SuspendLayout();
      this.tableLayoutPanel5.SuspendLayout();
      this.tableLayoutPanel6.SuspendLayout();
      this.tableLayoutPanel8.SuspendLayout();
      this.tableLayoutPanel10.SuspendLayout();
      this.tableLayoutPanel13.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gaugeOR)).BeginInit();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gaugeOLE)).BeginInit();
      this.tableLayoutPanel11.SuspendLayout();
      this.tableLayoutPanel9.SuspendLayout();
      this.tableLayoutPanel17.SuspendLayout();
      this.tableLayoutPanel16.SuspendLayout();
      this.tableLayoutPanel7.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel12.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ptbFill)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ptbErector)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ptbPacker)).BeginInit();
      this.SuspendLayout();
      // 
      // tmrDateTime
      // 
      this.tmrDateTime.Enabled = true;
      this.tmrDateTime.Interval = 5000;
      this.tmrDateTime.Tick += new System.EventHandler(this.tmrDateTime_Tick);
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel2.ColumnCount = 5;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9302326F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.20155F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.472868F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.23256F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.086957F));
      this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 3, 0);
      this.tableLayoutPanel2.Location = new System.Drawing.Point(27, 113);
      this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(1864, 618);
      this.tableLayoutPanel2.TabIndex = 0;
      // 
      // tableLayoutPanel3
      // 
      this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel3.ColumnCount = 3;
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.41796F));
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.22483F));
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.357208F));
      this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 5);
      this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 7);
      this.tableLayoutPanel3.Controls.Add(this.lbShift, 1, 1);
      this.tableLayoutPanel3.Controls.Add(this.lbOperator, 1, 3);
      this.tableLayoutPanel3.Location = new System.Drawing.Point(17, 0);
      this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 9;
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.09325F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.061489F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.750809F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.41424F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.47573F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.928802F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.12298F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.252427F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.tableLayoutPanel3.Size = new System.Drawing.Size(488, 618);
      this.tableLayoutPanel3.TabIndex = 1;
      // 
      // tableLayoutPanel4
      // 
      this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel4.ColumnCount = 2;
      this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.5F));
      this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.5F));
      this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
      this.tableLayoutPanel4.Controls.Add(this.lblSafetyDay, 1, 0);
      this.tableLayoutPanel4.Location = new System.Drawing.Point(187, 301);
      this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel4.Name = "tableLayoutPanel4";
      this.tableLayoutPanel4.RowCount = 1;
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
      this.tableLayoutPanel4.Size = new System.Drawing.Size(289, 49);
      this.tableLayoutPanel4.TabIndex = 2;
      // 
      // lblSafetyDay
      // 
      this.lblSafetyDay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblSafetyDay.AutoSize = true;
      this.lblSafetyDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lblSafetyDay.ForeColor = System.Drawing.Color.White;
      this.lblSafetyDay.Location = new System.Drawing.Point(32, 0);
      this.lblSafetyDay.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
      this.lblSafetyDay.Name = "lblSafetyDay";
      this.lblSafetyDay.Size = new System.Drawing.Size(249, 49);
      this.lblSafetyDay.TabIndex = 5;
      this.lblSafetyDay.Text = "0";
      this.lblSafetyDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tableLayoutPanel5
      // 
      this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel5.ColumnCount = 2;
      this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.5F));
      this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.5F));
      this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
      this.tableLayoutPanel5.Controls.Add(this.lblQualityDay, 1, 0);
      this.tableLayoutPanel5.Location = new System.Drawing.Point(187, 462);
      this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel5.Name = "tableLayoutPanel5";
      this.tableLayoutPanel5.RowCount = 1;
      this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
      this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
      this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
      this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
      this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
      this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
      this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
      this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
      this.tableLayoutPanel5.Size = new System.Drawing.Size(289, 51);
      this.tableLayoutPanel5.TabIndex = 3;
      // 
      // lblQualityDay
      // 
      this.lblQualityDay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblQualityDay.AutoSize = true;
      this.lblQualityDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lblQualityDay.ForeColor = System.Drawing.Color.White;
      this.lblQualityDay.Location = new System.Drawing.Point(32, 0);
      this.lblQualityDay.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
      this.lblQualityDay.Name = "lblQualityDay";
      this.lblQualityDay.Size = new System.Drawing.Size(249, 51);
      this.lblQualityDay.TabIndex = 6;
      this.lblQualityDay.Text = "0";
      this.lblQualityDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lbShift
      // 
      this.lbShift.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbShift.AutoSize = true;
      this.lbShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lbShift.ForeColor = System.Drawing.Color.White;
      this.lbShift.Location = new System.Drawing.Point(195, 68);
      this.lbShift.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
      this.lbShift.Name = "lbShift";
      this.lbShift.Size = new System.Drawing.Size(273, 56);
      this.lbShift.TabIndex = 4;
      this.lbShift.Text = "3";
      this.lbShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lbOperator
      // 
      this.lbOperator.AutoSize = true;
      this.lbOperator.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lbOperator.ForeColor = System.Drawing.Color.White;
      this.lbOperator.Location = new System.Drawing.Point(195, 141);
      this.lbOperator.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
      this.lbOperator.Name = "lbOperator";
      this.lbOperator.Size = new System.Drawing.Size(273, 52);
      this.lbOperator.TabIndex = 5;
      this.lbOperator.Text = "...";
      this.lbOperator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tableLayoutPanel6
      // 
      this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel6.ColumnCount = 1;
      this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel8, 0, 3);
      this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 1);
      this.tableLayoutPanel6.Location = new System.Drawing.Point(532, 0);
      this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel6.Name = "tableLayoutPanel6";
      this.tableLayoutPanel6.RowCount = 4;
      this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.376206F));
      this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.899676F));
      this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.750809F));
      this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.27508F));
      this.tableLayoutPanel6.Size = new System.Drawing.Size(1310, 618);
      this.tableLayoutPanel6.TabIndex = 3;
      // 
      // tableLayoutPanel8
      // 
      this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel8.ColumnCount = 3;
      this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.18681F));
      this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.197802F));
      this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.61538F));
      this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel10, 0, 0);
      this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 2, 0);
      this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 90);
      this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel8.Name = "tableLayoutPanel8";
      this.tableLayoutPanel8.RowCount = 1;
      this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel8.Size = new System.Drawing.Size(1310, 528);
      this.tableLayoutPanel8.TabIndex = 4;
      // 
      // tableLayoutPanel10
      // 
      this.tableLayoutPanel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel10.ColumnCount = 1;
      this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel13, 0, 3);
      this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel11, 0, 1);
      this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel10.Name = "tableLayoutPanel10";
      this.tableLayoutPanel10.RowCount = 4;
      this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.28788F));
      this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.22727F));
      this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.030303F));
      this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.45454F));
      this.tableLayoutPanel10.Size = new System.Drawing.Size(827, 528);
      this.tableLayoutPanel10.TabIndex = 4;
      // 
      // tableLayoutPanel13
      // 
      this.tableLayoutPanel13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel13.ColumnCount = 5;
      this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
      this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
      this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
      this.tableLayoutPanel13.Controls.Add(this.label3, 1, 0);
      this.tableLayoutPanel13.Controls.Add(this.label4, 3, 0);
      this.tableLayoutPanel13.Controls.Add(this.panel1, 3, 1);
      this.tableLayoutPanel13.Controls.Add(this.panel3, 1, 1);
      this.tableLayoutPanel13.Location = new System.Drawing.Point(0, 155);
      this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel13.Name = "tableLayoutPanel13";
      this.tableLayoutPanel13.RowCount = 2;
      this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.6F));
      this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.4F));
      this.tableLayoutPanel13.Size = new System.Drawing.Size(827, 373);
      this.tableLayoutPanel13.TabIndex = 5;
      this.tableLayoutPanel13.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel13_Paint);
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new System.Drawing.Point(0, 5);
      this.label3.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(413, 30);
      this.label3.TabIndex = 10;
      this.label3.Text = "OLE";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.label4.ForeColor = System.Drawing.Color.White;
      this.label4.Location = new System.Drawing.Point(413, 5);
      this.label4.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(413, 30);
      this.label4.TabIndex = 11;
      this.label4.Text = "OR";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.lbTargetOR);
      this.panel1.Controls.Add(this.lbProcessingValueOR);
      this.panel1.Controls.Add(this.gaugeOR);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(413, 35);
      this.panel1.Margin = new System.Windows.Forms.Padding(0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(413, 338);
      this.panel1.TabIndex = 12;
      // 
      // lbTargetOR
      // 
      this.lbTargetOR.AutoSize = true;
      this.lbTargetOR.BackColor = System.Drawing.Color.Transparent;
      this.lbTargetOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lbTargetOR.ForeColor = System.Drawing.Color.White;
      this.lbTargetOR.Location = new System.Drawing.Point(113, 200);
      this.lbTargetOR.Margin = new System.Windows.Forms.Padding(0);
      this.lbTargetOR.Name = "lbTargetOR";
      this.lbTargetOR.Size = new System.Drawing.Size(189, 31);
      this.lbTargetOR.TabIndex = 19;
      this.lbTargetOR.Text = "Target: 100%";
      // 
      // lbProcessingValueOR
      // 
      this.lbProcessingValueOR.AutoSize = true;
      this.lbProcessingValueOR.BackColor = System.Drawing.Color.Transparent;
      this.lbProcessingValueOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lbProcessingValueOR.ForeColor = System.Drawing.Color.White;
      this.lbProcessingValueOR.Location = new System.Drawing.Point(163, 129);
      this.lbProcessingValueOR.Margin = new System.Windows.Forms.Padding(0);
      this.lbProcessingValueOR.Name = "lbProcessingValueOR";
      this.lbProcessingValueOR.Size = new System.Drawing.Size(109, 39);
      this.lbProcessingValueOR.TabIndex = 18;
      this.lbProcessingValueOR.Text = "100%";
      // 
      // gaugeOR
      // 
      this.gaugeOR.BackColor = System.Drawing.Color.Transparent;
      chartArea1.BackColor = System.Drawing.Color.Transparent;
      chartArea1.Name = "ChartArea1";
      this.gaugeOR.ChartAreas.Add(chartArea1);
      this.gaugeOR.Dock = System.Windows.Forms.DockStyle.Fill;
      legend1.BackColor = System.Drawing.Color.Transparent;
      legend1.Enabled = false;
      legend1.Name = "Legend1";
      this.gaugeOR.Legends.Add(legend1);
      this.gaugeOR.Location = new System.Drawing.Point(0, 0);
      this.gaugeOR.Margin = new System.Windows.Forms.Padding(0);
      this.gaugeOR.Name = "gaugeOR";
      series1.BackImageTransparentColor = System.Drawing.Color.Transparent;
      series1.BackSecondaryColor = System.Drawing.Color.Transparent;
      series1.BorderColor = System.Drawing.Color.Transparent;
      series1.ChartArea = "ChartArea1";
      series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
      series1.Color = System.Drawing.Color.Transparent;
      series1.CustomProperties = "PieStartAngle=180, DoughnutRadius=40";
      series1.Legend = "Legend1";
      series1.Name = "Series1";
      this.gaugeOR.Series.Add(series1);
      this.gaugeOR.Size = new System.Drawing.Size(413, 338);
      this.gaugeOR.TabIndex = 15;
      this.gaugeOR.Text = "chart2";
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.lbTargetOLE);
      this.panel3.Controls.Add(this.lbProcessingValueOLE);
      this.panel3.Controls.Add(this.gaugeOLE);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(0, 35);
      this.panel3.Margin = new System.Windows.Forms.Padding(0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(413, 338);
      this.panel3.TabIndex = 13;
      // 
      // lbTargetOLE
      // 
      this.lbTargetOLE.AutoSize = true;
      this.lbTargetOLE.BackColor = System.Drawing.Color.Transparent;
      this.lbTargetOLE.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lbTargetOLE.ForeColor = System.Drawing.Color.White;
      this.lbTargetOLE.Location = new System.Drawing.Point(113, 200);
      this.lbTargetOLE.Margin = new System.Windows.Forms.Padding(0);
      this.lbTargetOLE.Name = "lbTargetOLE";
      this.lbTargetOLE.Size = new System.Drawing.Size(189, 31);
      this.lbTargetOLE.TabIndex = 18;
      this.lbTargetOLE.Text = "Target: 100%";
      // 
      // lbProcessingValueOLE
      // 
      this.lbProcessingValueOLE.AutoSize = true;
      this.lbProcessingValueOLE.BackColor = System.Drawing.Color.Transparent;
      this.lbProcessingValueOLE.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lbProcessingValueOLE.ForeColor = System.Drawing.Color.White;
      this.lbProcessingValueOLE.Location = new System.Drawing.Point(160, 129);
      this.lbProcessingValueOLE.Margin = new System.Windows.Forms.Padding(0);
      this.lbProcessingValueOLE.Name = "lbProcessingValueOLE";
      this.lbProcessingValueOLE.Size = new System.Drawing.Size(109, 39);
      this.lbProcessingValueOLE.TabIndex = 17;
      this.lbProcessingValueOLE.Text = "100%";
      // 
      // gaugeOLE
      // 
      this.gaugeOLE.BackColor = System.Drawing.Color.Transparent;
      chartArea2.BackColor = System.Drawing.Color.Transparent;
      chartArea2.Name = "ChartArea1";
      this.gaugeOLE.ChartAreas.Add(chartArea2);
      this.gaugeOLE.Dock = System.Windows.Forms.DockStyle.Fill;
      legend2.BackColor = System.Drawing.Color.Transparent;
      legend2.Enabled = false;
      legend2.Name = "Legend1";
      this.gaugeOLE.Legends.Add(legend2);
      this.gaugeOLE.Location = new System.Drawing.Point(0, 0);
      this.gaugeOLE.Margin = new System.Windows.Forms.Padding(0);
      this.gaugeOLE.Name = "gaugeOLE";
      series2.BackImageTransparentColor = System.Drawing.Color.Transparent;
      series2.BackSecondaryColor = System.Drawing.Color.Transparent;
      series2.BorderColor = System.Drawing.Color.Transparent;
      series2.ChartArea = "ChartArea1";
      series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
      series2.Color = System.Drawing.Color.Transparent;
      series2.CustomProperties = "PieStartAngle=180, DoughnutRadius=40";
      series2.Legend = "Legend1";
      series2.Name = "Series1";
      this.gaugeOLE.Series.Add(series2);
      this.gaugeOLE.Size = new System.Drawing.Size(413, 338);
      this.gaugeOLE.TabIndex = 14;
      this.gaugeOLE.Text = "chart2";
      // 
      // tableLayoutPanel11
      // 
      this.tableLayoutPanel11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel11.ColumnCount = 5;
      this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.78261F));
      this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.3913F));
      this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
      this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.56522F));
      this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.26087F));
      this.tableLayoutPanel11.Controls.Add(this.lblActual, 1, 0);
      this.tableLayoutPanel11.Controls.Add(this.lblTarget, 3, 0);
      this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 86);
      this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel11.Name = "tableLayoutPanel11";
      this.tableLayoutPanel11.RowCount = 1;
      this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel11.Size = new System.Drawing.Size(827, 53);
      this.tableLayoutPanel11.TabIndex = 4;
      // 
      // lblActual
      // 
      this.lblActual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblActual.AutoSize = true;
      this.lblActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lblActual.ForeColor = System.Drawing.Color.White;
      this.lblActual.Location = new System.Drawing.Point(196, 0);
      this.lblActual.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
      this.lblActual.Name = "lblActual";
      this.lblActual.Size = new System.Drawing.Size(160, 53);
      this.lblActual.TabIndex = 7;
      this.lblActual.Text = "0";
      this.lblActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblTarget
      // 
      this.lblTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblTarget.AutoSize = true;
      this.lblTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lblTarget.ForeColor = System.Drawing.Color.White;
      this.lblTarget.Location = new System.Drawing.Point(570, 0);
      this.lblTarget.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
      this.lblTarget.Name = "lblTarget";
      this.lblTarget.Size = new System.Drawing.Size(162, 53);
      this.lblTarget.TabIndex = 8;
      this.lblTarget.Text = "0";
      this.lblTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tableLayoutPanel9
      // 
      this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel9.ColumnCount = 1;
      this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel17, 0, 1);
      this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel16, 0, 0);
      this.tableLayoutPanel9.Location = new System.Drawing.Point(855, 0);
      this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel9.Name = "tableLayoutPanel9";
      this.tableLayoutPanel9.RowCount = 3;
      this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.43182F));
      this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.575758F));
      this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.99242F));
      this.tableLayoutPanel9.Size = new System.Drawing.Size(455, 528);
      this.tableLayoutPanel9.TabIndex = 5;
      // 
      // tableLayoutPanel17
      // 
      this.tableLayoutPanel17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel17.ColumnCount = 2;
      this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.11581F));
      this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.88419F));
      this.tableLayoutPanel17.Controls.Add(this.lbLoss, 1, 0);
      this.tableLayoutPanel17.Location = new System.Drawing.Point(0, 393);
      this.tableLayoutPanel17.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel17.Name = "tableLayoutPanel17";
      this.tableLayoutPanel17.RowCount = 1;
      this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel17.Size = new System.Drawing.Size(455, 40);
      this.tableLayoutPanel17.TabIndex = 14;
      // 
      // lbLoss
      // 
      this.lbLoss.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbLoss.AutoSize = true;
      this.lbLoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lbLoss.ForeColor = System.Drawing.Color.DarkOrange;
      this.lbLoss.Location = new System.Drawing.Point(237, 0);
      this.lbLoss.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
      this.lbLoss.Name = "lbLoss";
      this.lbLoss.Size = new System.Drawing.Size(210, 40);
      this.lbLoss.TabIndex = 11;
      this.lbLoss.Text = "0 %";
      this.lbLoss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel16
      // 
      this.tableLayoutPanel16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel16.ColumnCount = 4;
      this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.031746F));
      this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.34921F));
      this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.03175F));
      this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.5873F));
      this.tableLayoutPanel16.Controls.Add(this.lbLossSFGs, 1, 3);
      this.tableLayoutPanel16.Controls.Add(this.lbLossPM, 3, 1);
      this.tableLayoutPanel16.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel16.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel16.Name = "tableLayoutPanel16";
      this.tableLayoutPanel16.RowCount = 5;
      this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.80153F));
      this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.923664F));
      this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.361323F));
      this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.17812F));
      this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.20207F));
      this.tableLayoutPanel16.Size = new System.Drawing.Size(455, 393);
      this.tableLayoutPanel16.TabIndex = 6;
      // 
      // lbLossSFGs
      // 
      this.lbLossSFGs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbLossSFGs.AutoSize = true;
      this.lbLossSFGs.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lbLossSFGs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(49)))));
      this.lbLossSFGs.Location = new System.Drawing.Point(27, 244);
      this.lbLossSFGs.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
      this.lbLossSFGs.Name = "lbLossSFGs";
      this.lbLossSFGs.Size = new System.Drawing.Size(202, 40);
      this.lbLossSFGs.TabIndex = 9;
      this.lbLossSFGs.Text = "0";
      this.lbLossSFGs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lbLossPM
      // 
      this.lbLossPM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbLossPM.AutoSize = true;
      this.lbLossPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lbLossPM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(206)))), ((int)(((byte)(127)))));
      this.lbLossPM.Location = new System.Drawing.Point(355, 180);
      this.lbLossPM.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
      this.lbLossPM.Name = "lbLossPM";
      this.lbLossPM.Size = new System.Drawing.Size(92, 39);
      this.lbLossPM.TabIndex = 10;
      this.lbLossPM.Text = "0";
      this.lbLossPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel7
      // 
      this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel7.ColumnCount = 5;
      this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
      this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.86259F));
      this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.07634F));
      this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.87786F));
      this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.868132F));
      this.tableLayoutPanel7.Controls.Add(this.lbCodeProduct, 1, 0);
      this.tableLayoutPanel7.Controls.Add(this.lnNameProduct, 3, 0);
      this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 20);
      this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel7.Name = "tableLayoutPanel7";
      this.tableLayoutPanel7.RowCount = 1;
      this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel7.Size = new System.Drawing.Size(1310, 54);
      this.tableLayoutPanel7.TabIndex = 3;
      // 
      // lbCodeProduct
      // 
      this.lbCodeProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbCodeProduct.AutoSize = true;
      this.lbCodeProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbCodeProduct.ForeColor = System.Drawing.Color.White;
      this.lbCodeProduct.Location = new System.Drawing.Point(195, 0);
      this.lbCodeProduct.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
      this.lbCodeProduct.Name = "lbCodeProduct";
      this.lbCodeProduct.Size = new System.Drawing.Size(218, 54);
      this.lbCodeProduct.TabIndex = 5;
      this.lbCodeProduct.Text = "...";
      this.lbCodeProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lnNameProduct
      // 
      this.lnNameProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lnNameProduct.AutoSize = true;
      this.lnNameProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lnNameProduct.ForeColor = System.Drawing.Color.White;
      this.lnNameProduct.Location = new System.Drawing.Point(561, 0);
      this.lnNameProduct.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
      this.lnNameProduct.Name = "lnNameProduct";
      this.lnNameProduct.Size = new System.Drawing.Size(716, 54);
      this.lnNameProduct.TabIndex = 6;
      this.lnNameProduct.Text = "...";
      this.lnNameProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.421092F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96.93343F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.645475F));
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel12, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.label2, 1, 3);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 4;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.65033F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.24694F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.55796F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.544769F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1924, 1061);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // tableLayoutPanel12
      // 
      this.tableLayoutPanel12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel12.ColumnCount = 10;
      this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.60515F));
      this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.457081F));
      this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.038627F));
      this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.92918F));
      this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.51073F));
      this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.092275F));
      this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.95708F));
      this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.403433F));
      this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.984979F));
      this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.02146F));
      this.tableLayoutPanel12.Controls.Add(this.lbFillerSFGs, 1, 1);
      this.tableLayoutPanel12.Controls.Add(this.lbFillerPM, 1, 3);
      this.tableLayoutPanel12.Controls.Add(this.ptbFill, 2, 0);
      this.tableLayoutPanel12.Controls.Add(this.lbErectorPM, 7, 3);
      this.tableLayoutPanel12.Controls.Add(this.ptbErector, 8, 0);
      this.tableLayoutPanel12.Controls.Add(this.ptbPacker, 5, 0);
      this.tableLayoutPanel12.Controls.Add(this.lbPackerPM, 4, 3);
      this.tableLayoutPanel12.Controls.Add(this.lbPackerSFGs, 4, 1);
      this.tableLayoutPanel12.Location = new System.Drawing.Point(27, 731);
      this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel12.Name = "tableLayoutPanel12";
      this.tableLayoutPanel12.RowCount = 5;
      this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.56954F));
      this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.609271F));
      this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.311258F));
      this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.609271F));
      this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.35644F));
      this.tableLayoutPanel12.Size = new System.Drawing.Size(1864, 302);
      this.tableLayoutPanel12.TabIndex = 5;
      // 
      // lbFillerSFGs
      // 
      this.lbFillerSFGs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbFillerSFGs.AutoSize = true;
      this.lbFillerSFGs.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lbFillerSFGs.ForeColor = System.Drawing.Color.White;
      this.lbFillerSFGs.Location = new System.Drawing.Point(448, 44);
      this.lbFillerSFGs.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
      this.lbFillerSFGs.Name = "lbFillerSFGs";
      this.lbFillerSFGs.Size = new System.Drawing.Size(123, 26);
      this.lbFillerSFGs.TabIndex = 7;
      this.lbFillerSFGs.Text = "0";
      this.lbFillerSFGs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lbFillerPM
      // 
      this.lbFillerPM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbFillerPM.AutoSize = true;
      this.lbFillerPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lbFillerPM.ForeColor = System.Drawing.Color.White;
      this.lbFillerPM.Location = new System.Drawing.Point(448, 80);
      this.lbFillerPM.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
      this.lbFillerPM.Name = "lbFillerPM";
      this.lbFillerPM.Size = new System.Drawing.Size(123, 26);
      this.lbFillerPM.TabIndex = 8;
      this.lbFillerPM.Text = "0";
      this.lbFillerPM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // ptbFill
      // 
      this.ptbFill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ptbFill.Image = ((System.Drawing.Image)(resources.GetObject("ptbFill.Image")));
      this.ptbFill.Location = new System.Drawing.Point(579, 0);
      this.ptbFill.Margin = new System.Windows.Forms.Padding(0);
      this.ptbFill.Name = "ptbFill";
      this.ptbFill.Size = new System.Drawing.Size(38, 44);
      this.ptbFill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.ptbFill.TabIndex = 12;
      this.ptbFill.TabStop = false;
      // 
      // lbPackerSFGs
      // 
      this.lbPackerSFGs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbPackerSFGs.AutoSize = true;
      this.lbPackerSFGs.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lbPackerSFGs.ForeColor = System.Drawing.Color.White;
      this.lbPackerSFGs.Location = new System.Drawing.Point(865, 44);
      this.lbPackerSFGs.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
      this.lbPackerSFGs.Name = "lbPackerSFGs";
      this.lbPackerSFGs.Size = new System.Drawing.Size(124, 26);
      this.lbPackerSFGs.TabIndex = 9;
      this.lbPackerSFGs.Text = "0";
      this.lbPackerSFGs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lbErectorPM
      // 
      this.lbErectorPM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbErectorPM.AutoSize = true;
      this.lbErectorPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lbErectorPM.ForeColor = System.Drawing.Color.White;
      this.lbErectorPM.Location = new System.Drawing.Point(1416, 80);
      this.lbErectorPM.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
      this.lbErectorPM.Name = "lbErectorPM";
      this.lbErectorPM.Size = new System.Drawing.Size(122, 26);
      this.lbErectorPM.TabIndex = 11;
      this.lbErectorPM.Text = "0";
      this.lbErectorPM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lbPackerPM
      // 
      this.lbPackerPM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbPackerPM.AutoSize = true;
      this.lbPackerPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.lbPackerPM.ForeColor = System.Drawing.Color.White;
      this.lbPackerPM.Location = new System.Drawing.Point(865, 80);
      this.lbPackerPM.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
      this.lbPackerPM.Name = "lbPackerPM";
      this.lbPackerPM.Size = new System.Drawing.Size(124, 26);
      this.lbPackerPM.TabIndex = 10;
      this.lbPackerPM.Text = "0";
      this.lbPackerPM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // ptbErector
      // 
      this.ptbErector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ptbErector.Image = ((System.Drawing.Image)(resources.GetObject("ptbErector.Image")));
      this.ptbErector.Location = new System.Drawing.Point(1546, 0);
      this.ptbErector.Margin = new System.Windows.Forms.Padding(0);
      this.ptbErector.Name = "ptbErector";
      this.ptbErector.Size = new System.Drawing.Size(37, 44);
      this.ptbErector.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.ptbErector.TabIndex = 14;
      this.ptbErector.TabStop = false;
      // 
      // ptbPacker
      // 
      this.ptbPacker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ptbPacker.Image = ((System.Drawing.Image)(resources.GetObject("ptbPacker.Image")));
      this.ptbPacker.Location = new System.Drawing.Point(997, 0);
      this.ptbPacker.Margin = new System.Windows.Forms.Padding(0);
      this.ptbPacker.Name = "ptbPacker";
      this.ptbPacker.Size = new System.Drawing.Size(39, 44);
      this.ptbPacker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.ptbPacker.TabIndex = 13;
      this.ptbPacker.TabStop = false;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(1752, 1038);
      this.label2.Margin = new System.Windows.Forms.Padding(2, 5, 2, 2);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(137, 21);
      this.label2.TabIndex = 6;
      this.label2.Text = "Disconnect PLC";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.IndianRed;
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(85, 29);
      this.label1.TabIndex = 6;
      this.label1.Text = "label1";
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ClientSize = new System.Drawing.Size(1924, 1061);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Controls.Add(this.label1);
      this.DoubleBuffered = true;
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
      this.Name = "frmMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel3.ResumeLayout(false);
      this.tableLayoutPanel3.PerformLayout();
      this.tableLayoutPanel4.ResumeLayout(false);
      this.tableLayoutPanel4.PerformLayout();
      this.tableLayoutPanel5.ResumeLayout(false);
      this.tableLayoutPanel5.PerformLayout();
      this.tableLayoutPanel6.ResumeLayout(false);
      this.tableLayoutPanel8.ResumeLayout(false);
      this.tableLayoutPanel10.ResumeLayout(false);
      this.tableLayoutPanel13.ResumeLayout(false);
      this.tableLayoutPanel13.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gaugeOR)).EndInit();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gaugeOLE)).EndInit();
      this.tableLayoutPanel11.ResumeLayout(false);
      this.tableLayoutPanel11.PerformLayout();
      this.tableLayoutPanel9.ResumeLayout(false);
      this.tableLayoutPanel17.ResumeLayout(false);
      this.tableLayoutPanel17.PerformLayout();
      this.tableLayoutPanel16.ResumeLayout(false);
      this.tableLayoutPanel16.PerformLayout();
      this.tableLayoutPanel7.ResumeLayout(false);
      this.tableLayoutPanel7.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.tableLayoutPanel12.ResumeLayout(false);
      this.tableLayoutPanel12.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ptbFill)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ptbErector)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ptbPacker)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Timer tmrDateTime;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
    private System.Windows.Forms.Label lblSafetyDay;
    private System.Windows.Forms.Label lblQualityDay;
    private System.Windows.Forms.Label lbShift;
    private System.Windows.Forms.Label lbOperator;
    private System.Windows.Forms.Label lblActual;
    private System.Windows.Forms.Label lblTarget;
    private System.Windows.Forms.Label lbCodeProduct;
    private System.Windows.Forms.Label lnNameProduct;
    private System.Windows.Forms.Label lbFillerSFGs;
    private System.Windows.Forms.Label lbFillerPM;
    private System.Windows.Forms.Label lbPackerSFGs;
    private System.Windows.Forms.Label lbPackerPM;
    private System.Windows.Forms.Label lbErectorPM;
    private System.Windows.Forms.PictureBox ptbFill;
    private System.Windows.Forms.PictureBox ptbPacker;
    private System.Windows.Forms.PictureBox ptbErector;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
    private System.Windows.Forms.Label lbLoss;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
    private System.Windows.Forms.Label lbLossSFGs;
    private System.Windows.Forms.Label lbLossPM;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label lbProcessingValueOR;
    private System.Windows.Forms.Label lbProcessingValueOLE;
    private System.Windows.Forms.DataVisualization.Charting.Chart gaugeOR;
    private System.Windows.Forms.DataVisualization.Charting.Chart gaugeOLE;
    private System.Windows.Forms.Label lbTargetOR;
    private System.Windows.Forms.Label lbTargetOLE;
        private System.Windows.Forms.Label label2;
    }
}

