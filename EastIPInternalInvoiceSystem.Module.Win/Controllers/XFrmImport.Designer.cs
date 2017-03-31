namespace EastIPInternalInvoiceSystem.Module.Win.Controllers
{
    partial class XFrmImport
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
            this.xlueFormatType = new DevExpress.XtraEditors.LookUpEdit();
            this.xsbExport = new DevExpress.XtraEditors.SimpleButton();
            this.xsbOk = new DevExpress.XtraEditors.SimpleButton();
            this.xgcResult = new DevExpress.XtraGrid.GridControl();
            this.xgvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xlueSheet = new DevExpress.XtraEditors.LookUpEdit();
            this.xbeExcelFile = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xlueFormatType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgcResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xlueSheet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xbeExcelFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.xlueFormatType);
            this.layoutControl1.Controls.Add(this.xsbExport);
            this.layoutControl1.Controls.Add(this.xsbOk);
            this.layoutControl1.Controls.Add(this.xgcResult);
            this.layoutControl1.Controls.Add(this.xlueSheet);
            this.layoutControl1.Controls.Add(this.xbeExcelFile);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(607, 435);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // xlueFormatType
            // 
            this.xlueFormatType.Location = new System.Drawing.Point(75, 36);
            this.xlueFormatType.Name = "xlueFormatType";
            this.xlueFormatType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.xlueFormatType.Properties.DisplayMember = "Value";
            this.xlueFormatType.Properties.ShowFooter = false;
            this.xlueFormatType.Properties.ShowHeader = false;
            this.xlueFormatType.Properties.ShowLines = false;
            this.xlueFormatType.Properties.ValueMember = "Key";
            this.xlueFormatType.Size = new System.Drawing.Size(520, 20);
            this.xlueFormatType.StyleController = this.layoutControl1;
            this.xlueFormatType.TabIndex = 9;
            // 
            // xsbExport
            // 
            this.xsbExport.Location = new System.Drawing.Point(504, 60);
            this.xsbExport.Name = "xsbExport";
            this.xsbExport.Size = new System.Drawing.Size(91, 22);
            this.xsbExport.StyleController = this.layoutControl1;
            this.xsbExport.TabIndex = 8;
            this.xsbExport.Text = "导出到Excel";
            this.xsbExport.Click += new System.EventHandler(this.xsbExport_Click);
            // 
            // xsbOk
            // 
            this.xsbOk.Location = new System.Drawing.Point(413, 60);
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
            this.xgcResult.Size = new System.Drawing.Size(583, 337);
            this.xgcResult.TabIndex = 6;
            this.xgcResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.xgvResult});
            // 
            // xgvResult
            // 
            this.xgvResult.GridControl = this.xgcResult;
            this.xgvResult.Name = "xgvResult";
            this.xgvResult.OptionsBehavior.Editable = false;
            this.xgvResult.OptionsDetail.EnableMasterViewMode = false;
            this.xgvResult.OptionsSelection.MultiSelect = true;
            this.xgvResult.OptionsView.ColumnAutoWidth = false;
            this.xgvResult.OptionsView.ShowFooter = true;
            // 
            // xlueSheet
            // 
            this.xlueSheet.Location = new System.Drawing.Point(369, 12);
            this.xlueSheet.Name = "xlueSheet";
            this.xlueSheet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.xlueSheet.Size = new System.Drawing.Size(226, 20);
            this.xlueSheet.StyleController = this.layoutControl1;
            this.xlueSheet.TabIndex = 5;
            this.xlueSheet.EditValueChanged += new System.EventHandler(this.xlueSheet_EditValueChanged);
            // 
            // xbeExcelFile
            // 
            this.xbeExcelFile.Location = new System.Drawing.Point(75, 12);
            this.xbeExcelFile.Name = "xbeExcelFile";
            this.xbeExcelFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.xbeExcelFile.Size = new System.Drawing.Size(227, 20);
            this.xbeExcelFile.StyleController = this.layoutControl1;
            this.xbeExcelFile.TabIndex = 4;
            this.xbeExcelFile.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.xbeExcelFile_ButtonClick);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(607, 435);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.xbeExcelFile;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(294, 24);
            this.layoutControlItem1.Text = "Excel：";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.xlueSheet;
            this.layoutControlItem2.Location = new System.Drawing.Point(294, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(293, 24);
            this.layoutControlItem2.Text = "Sheet:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.xgcResult;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(587, 341);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(401, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.xsbOk;
            this.layoutControlItem4.Location = new System.Drawing.Point(401, 48);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(91, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(91, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(91, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.xlueFormatType;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(587, 24);
            this.layoutControlItem6.Text = "处理内容：";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.xsbExport;
            this.layoutControlItem5.Location = new System.Drawing.Point(492, 48);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(95, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(95, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(95, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Excel文件|*.xlsx;*.xls";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "Result.xlsx";
            this.saveFileDialog.Filter = "Excel文件|*.xls;*.xlsx|所有文件|*.*";
            // 
            // XFrmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 435);
            this.Controls.Add(this.layoutControl1);
            this.Name = "XFrmImport";
            this.Text = "导入草单";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xlueFormatType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgcResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xlueSheet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xbeExcelFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.ButtonEdit xbeExcelFile;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit xlueSheet;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevExpress.XtraGrid.GridControl xgcResult;
        private DevExpress.XtraGrid.Views.Grid.GridView xgvResult;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton xsbOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton xsbExport;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private DevExpress.XtraEditors.LookUpEdit xlueFormatType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}

