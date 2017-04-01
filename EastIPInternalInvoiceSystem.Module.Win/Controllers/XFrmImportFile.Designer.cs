namespace EastIPInternalInvoiceSystem.Module.Win.Controllers
{
    partial class XFrmImportFile
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.xlueImportType = new DevExpress.XtraEditors.LookUpEdit();
            this.xsbExport = new DevExpress.XtraEditors.SimpleButton();
            this.xsbOk = new DevExpress.XtraEditors.SimpleButton();
            this.xgcResult = new DevExpress.XtraGrid.GridControl();
            this.xgvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xbeFilePath = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xlueImportType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgcResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xbeFilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.xlueImportType);
            this.layoutControl1.Controls.Add(this.xsbExport);
            this.layoutControl1.Controls.Add(this.xsbOk);
            this.layoutControl1.Controls.Add(this.xgcResult);
            this.layoutControl1.Controls.Add(this.xbeFilePath);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(720, 483);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // xlueImportType
            // 
            this.xlueImportType.Location = new System.Drawing.Point(75, 36);
            this.xlueImportType.Name = "xlueImportType";
            this.xlueImportType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.xlueImportType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "类型")});
            this.xlueImportType.Properties.DisplayMember = "Value";
            this.xlueImportType.Properties.ValueMember = "Key";
            this.xlueImportType.Size = new System.Drawing.Size(633, 20);
            this.xlueImportType.StyleController = this.layoutControl1;
            this.xlueImportType.TabIndex = 9;
            // 
            // xsbExport
            // 
            this.xsbExport.Location = new System.Drawing.Point(617, 60);
            this.xsbExport.Name = "xsbExport";
            this.xsbExport.Size = new System.Drawing.Size(91, 22);
            this.xsbExport.StyleController = this.layoutControl1;
            this.xsbExport.TabIndex = 8;
            this.xsbExport.Text = "导出到Excel";
            this.xsbExport.Click += new System.EventHandler(this.xsbExport_Click);
            // 
            // xsbOk
            // 
            this.xsbOk.Location = new System.Drawing.Point(526, 60);
            this.xsbOk.Name = "xsbOk";
            this.xsbOk.Size = new System.Drawing.Size(87, 22);
            this.xsbOk.StyleController = this.layoutControl1;
            this.xsbOk.TabIndex = 7;
            this.xsbOk.Text = "导入";
            this.xsbOk.Click += new System.EventHandler(this.xsbOk_Click);
            // 
            // xgcResult
            // 
            this.xgcResult.Location = new System.Drawing.Point(12, 86);
            this.xgcResult.MainView = this.xgvResult;
            this.xgcResult.Name = "xgcResult";
            this.xgcResult.Size = new System.Drawing.Size(696, 385);
            this.xgcResult.TabIndex = 6;
            this.xgcResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.xgvResult});
            // 
            // xgvResult
            // 
            this.xgvResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.xgvResult.GridControl = this.xgcResult;
            this.xgvResult.Name = "xgvResult";
            this.xgvResult.OptionsBehavior.Editable = false;
            this.xgvResult.OptionsDetail.EnableMasterViewMode = false;
            this.xgvResult.OptionsSelection.MultiSelect = true;
            this.xgvResult.OptionsView.ColumnAutoWidth = false;
            this.xgvResult.OptionsView.ShowFooter = true;
            // 
            // xbeFilePath
            // 
            this.xbeFilePath.Location = new System.Drawing.Point(75, 12);
            this.xbeFilePath.Name = "xbeFilePath";
            this.xbeFilePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.xbeFilePath.Properties.ReadOnly = true;
            this.xbeFilePath.Size = new System.Drawing.Size(633, 20);
            this.xbeFilePath.StyleController = this.layoutControl1;
            this.xbeFilePath.TabIndex = 4;
            this.xbeFilePath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.xbeExcelFile_ButtonClick);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(720, 483);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.xbeFilePath;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(700, 24);
            this.layoutControlItem1.Text = "文件夹：";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.xgcResult;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(700, 389);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(514, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.xsbOk;
            this.layoutControlItem4.Location = new System.Drawing.Point(514, 48);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(91, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(91, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(91, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.xsbExport;
            this.layoutControlItem5.Location = new System.Drawing.Point(605, 48);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(95, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(95, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(95, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.xlueImportType;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(700, 24);
            this.layoutControlItem2.Text = "导入类型：";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 14);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "Result.xlsx";
            this.saveFileDialog.Filter = "Excel文件|*.xls;*.xlsx|所有文件|*.*";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "文件";
            this.gridColumn1.FieldName = "Key";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "导入结果";
            this.gridColumn2.FieldName = "Value";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // XFrmImportFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 483);
            this.Controls.Add(this.layoutControl1);
            this.Name = "XFrmImportFile";
            this.Text = "导入电子件";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xlueImportType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgcResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xbeFilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.ButtonEdit xbeFilePath;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl xgcResult;
        private DevExpress.XtraGrid.Views.Grid.GridView xgvResult;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton xsbOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton xsbExport;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private DevExpress.XtraEditors.LookUpEdit xlueImportType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}

