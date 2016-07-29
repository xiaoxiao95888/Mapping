using System.Windows.Forms;

namespace Mapping
{
    partial class MainForm
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.SubView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.place_gridColumn_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.place_gridColumn_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.place_gridColumn_TypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.place_gridColumn_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.place_gridColumn_Province = new DevExpress.XtraGrid.Columns.GridColumn();
            this.place_gridColumn_City = new DevExpress.XtraGrid.Columns.GridColumn();
            this.place_gridColumn_District = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.MasterView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MasterView_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MasterView_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MasterView_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MasterView_TypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MasterView_Province = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MasterView_City = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MasterView_District = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MasterView_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MasterView_Words = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btn_importexcel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.SubView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // SubView
            // 
            this.SubView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.place_gridColumn_Name,
            this.place_gridColumn_Type,
            this.place_gridColumn_TypeCode,
            this.place_gridColumn_Address,
            this.place_gridColumn_Province,
            this.place_gridColumn_City,
            this.place_gridColumn_District});
            this.SubView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.SubView.GridControl = this.gridControl1;
            this.SubView.Name = "SubView";
            this.SubView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.SubView.OptionsView.EnableAppearanceOddRow = true;
            this.SubView.Click += new System.EventHandler(this.SubView_Click);
            // 
            // place_gridColumn_Name
            // 
            this.place_gridColumn_Name.Caption = "名称";
            this.place_gridColumn_Name.FieldName = "Name";
            this.place_gridColumn_Name.Name = "place_gridColumn_Name";
            this.place_gridColumn_Name.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_Name.Visible = true;
            this.place_gridColumn_Name.VisibleIndex = 0;
            // 
            // place_gridColumn_Type
            // 
            this.place_gridColumn_Type.Caption = "类别";
            this.place_gridColumn_Type.FieldName = "Type";
            this.place_gridColumn_Type.Name = "place_gridColumn_Type";
            this.place_gridColumn_Type.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_Type.Visible = true;
            this.place_gridColumn_Type.VisibleIndex = 1;
            // 
            // place_gridColumn_TypeCode
            // 
            this.place_gridColumn_TypeCode.Caption = "类别编码";
            this.place_gridColumn_TypeCode.FieldName = "TypeCode";
            this.place_gridColumn_TypeCode.Name = "place_gridColumn_TypeCode";
            this.place_gridColumn_TypeCode.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_TypeCode.Visible = true;
            this.place_gridColumn_TypeCode.VisibleIndex = 2;
            // 
            // place_gridColumn_Address
            // 
            this.place_gridColumn_Address.Caption = "地址";
            this.place_gridColumn_Address.FieldName = "Address";
            this.place_gridColumn_Address.Name = "place_gridColumn_Address";
            this.place_gridColumn_Address.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_Address.Visible = true;
            this.place_gridColumn_Address.VisibleIndex = 6;
            // 
            // place_gridColumn_Province
            // 
            this.place_gridColumn_Province.Caption = "省份";
            this.place_gridColumn_Province.FieldName = "Province";
            this.place_gridColumn_Province.Name = "place_gridColumn_Province";
            this.place_gridColumn_Province.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_Province.Visible = true;
            this.place_gridColumn_Province.VisibleIndex = 3;
            // 
            // place_gridColumn_City
            // 
            this.place_gridColumn_City.Caption = "城市";
            this.place_gridColumn_City.FieldName = "City";
            this.place_gridColumn_City.Name = "place_gridColumn_City";
            this.place_gridColumn_City.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_City.Visible = true;
            this.place_gridColumn_City.VisibleIndex = 4;
            // 
            // place_gridColumn_District
            // 
            this.place_gridColumn_District.Caption = "区县";
            this.place_gridColumn_District.FieldName = "District";
            this.place_gridColumn_District.Name = "place_gridColumn_District";
            this.place_gridColumn_District.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_District.Visible = true;
            this.place_gridColumn_District.VisibleIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.SubView;
            gridLevelNode1.RelationName = "Places";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 147);
            this.gridControl1.MainView = this.MasterView;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1065, 513);
            this.gridControl1.TabIndex = 19;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.MasterView,
            this.SubView});
            // 
            // MasterView
            // 
            this.MasterView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MasterView_Code,
            this.MasterView_Name,
            this.MasterView_Type,
            this.MasterView_TypeCode,
            this.MasterView_Province,
            this.MasterView_City,
            this.MasterView_District,
            this.MasterView_Address,
            this.MasterView_Words});
            this.MasterView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.MasterView.GridControl = this.gridControl1;
            this.MasterView.Name = "MasterView";
            this.MasterView.OptionsFind.AlwaysVisible = true;
            this.MasterView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.MasterView.OptionsSelection.MultiSelect = true;
            this.MasterView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.MasterView.OptionsView.EnableAppearanceEvenRow = true;
            this.MasterView.OptionsView.ShowFooter = true;
            this.MasterView.OptionsView.ShowIndicator = false;
            this.MasterView.DoubleClick += new System.EventHandler(this.MasterView_DoubleClick);
            // 
            // MasterView_Code
            // 
            this.MasterView_Code.Caption = "编号";
            this.MasterView_Code.FieldName = "Code";
            this.MasterView_Code.Name = "MasterView_Code";
            this.MasterView_Code.OptionsColumn.AllowEdit = false;
            this.MasterView_Code.Visible = true;
            this.MasterView_Code.VisibleIndex = 1;
            // 
            // MasterView_Name
            // 
            this.MasterView_Name.Caption = "名称";
            this.MasterView_Name.FieldName = "Name";
            this.MasterView_Name.Name = "MasterView_Name";
            this.MasterView_Name.OptionsColumn.AllowEdit = false;
            this.MasterView_Name.Visible = true;
            this.MasterView_Name.VisibleIndex = 2;
            // 
            // MasterView_Type
            // 
            this.MasterView_Type.Caption = "行业";
            this.MasterView_Type.FieldName = "Type";
            this.MasterView_Type.Name = "MasterView_Type";
            this.MasterView_Type.OptionsColumn.AllowEdit = false;
            this.MasterView_Type.Visible = true;
            this.MasterView_Type.VisibleIndex = 3;
            // 
            // MasterView_TypeCode
            // 
            this.MasterView_TypeCode.Caption = "行业编码";
            this.MasterView_TypeCode.FieldName = "TypeCode";
            this.MasterView_TypeCode.Name = "MasterView_TypeCode";
            this.MasterView_TypeCode.Visible = true;
            this.MasterView_TypeCode.VisibleIndex = 5;
            // 
            // MasterView_Province
            // 
            this.MasterView_Province.Caption = "省份";
            this.MasterView_Province.FieldName = "Province";
            this.MasterView_Province.Name = "MasterView_Province";
            this.MasterView_Province.Visible = true;
            this.MasterView_Province.VisibleIndex = 4;
            // 
            // MasterView_City
            // 
            this.MasterView_City.Caption = "城市";
            this.MasterView_City.FieldName = "City";
            this.MasterView_City.Name = "MasterView_City";
            this.MasterView_City.Visible = true;
            this.MasterView_City.VisibleIndex = 6;
            // 
            // MasterView_District
            // 
            this.MasterView_District.Caption = "区县";
            this.MasterView_District.FieldName = "District";
            this.MasterView_District.Name = "MasterView_District";
            this.MasterView_District.Visible = true;
            this.MasterView_District.VisibleIndex = 7;
            // 
            // MasterView_Address
            // 
            this.MasterView_Address.Caption = "地址";
            this.MasterView_Address.FieldName = "Address";
            this.MasterView_Address.Name = "MasterView_Address";
            this.MasterView_Address.OptionsColumn.AllowEdit = false;
            this.MasterView_Address.Visible = true;
            this.MasterView_Address.VisibleIndex = 8;
            // 
            // MasterView_Words
            // 
            this.MasterView_Words.Caption = "分词";
            this.MasterView_Words.FieldName = "Words";
            this.MasterView_Words.Name = "MasterView_Words";
            this.MasterView_Words.OptionsColumn.AllowEdit = false;
            this.MasterView_Words.Visible = true;
            this.MasterView_Words.VisibleIndex = 9;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btn_importexcel,
            this.barButtonItem2,
            this.barButtonItem1,
            this.barButtonItem4,
            this.barButtonItem5});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 13;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(1065, 147);
            // 
            // btn_importexcel
            // 
            this.btn_importexcel.Caption = "导入数据";
            this.btn_importexcel.Id = 1;
            this.btn_importexcel.ImageUri.Uri = "Add";
            this.btn_importexcel.Name = "btn_importexcel";
            this.btn_importexcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_importexcel_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "分析";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.ImageUri.Uri = "Pie";
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "设定";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.ImageUri.Uri = "CustomizeGrid";
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "主数据管理";
            this.barButtonItem4.Id = 7;
            this.barButtonItem4.ImageUri.Uri = "EditDataSource";
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "开始匹配";
            this.barButtonItem5.Id = 12;
            this.barButtonItem5.ImageUri.Uri = "Find";
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_importexcel);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Common";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Auto-Process";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "Setting";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 660);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.Text = "终端Mapping辅助工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SubView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btn_importexcel;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView SubView;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_Name;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_Type;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_TypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_Address;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_Province;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_City;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_District;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView MasterView;
        private DevExpress.XtraGrid.Columns.GridColumn MasterView_Code;
        private DevExpress.XtraGrid.Columns.GridColumn MasterView_Name;
        private DevExpress.XtraGrid.Columns.GridColumn MasterView_Type;
        private DevExpress.XtraGrid.Columns.GridColumn MasterView_TypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn MasterView_Province;
        private DevExpress.XtraGrid.Columns.GridColumn MasterView_City;
        private DevExpress.XtraGrid.Columns.GridColumn MasterView_District;
        private DevExpress.XtraGrid.Columns.GridColumn MasterView_Address;
        private DevExpress.XtraGrid.Columns.GridColumn MasterView_Words;
    }
}

