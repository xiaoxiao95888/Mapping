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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true);
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode4 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.place_gridColumn_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.place_gridColumn_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.place_gridColumn_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.place_gridColumn_TypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.place_gridColumn_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.place_gridColumn_Location = new DevExpress.XtraGrid.Columns.GridColumn();
            this.place_gridColumn_Province = new DevExpress.XtraGrid.Columns.GridColumn();
            this.place_gridColumn_City = new DevExpress.XtraGrid.Columns.GridColumn();
            this.place_gridColumn_District = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.word_gridColumn_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.word_gridColumn_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_WordCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_PlaceCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.appMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.btn_importexcel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.place_gridColumn_ItemCode,
            this.place_gridColumn_Name,
            this.place_gridColumn_Type,
            this.place_gridColumn_TypeCode,
            this.place_gridColumn_Address,
            this.place_gridColumn_Location,
            this.place_gridColumn_Province,
            this.place_gridColumn_City,
            this.place_gridColumn_District});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView3.GridControl = this.gridControl1;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.EnableAppearanceOddRow = true;
            this.gridView3.OptionsView.ShowIndicator = false;
            this.gridView3.DoubleClick += new System.EventHandler(this.gridView3_DoubleClick);
            // 
            // place_gridColumn_ItemCode
            // 
            this.place_gridColumn_ItemCode.Caption = "原始编号";
            this.place_gridColumn_ItemCode.FieldName = "ItemCode";
            this.place_gridColumn_ItemCode.Name = "place_gridColumn_ItemCode";
            this.place_gridColumn_ItemCode.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_ItemCode.Visible = true;
            this.place_gridColumn_ItemCode.VisibleIndex = 0;
            // 
            // place_gridColumn_Name
            // 
            this.place_gridColumn_Name.Caption = "名称";
            this.place_gridColumn_Name.FieldName = "Name";
            this.place_gridColumn_Name.Name = "place_gridColumn_Name";
            this.place_gridColumn_Name.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_Name.Visible = true;
            this.place_gridColumn_Name.VisibleIndex = 1;
            // 
            // place_gridColumn_Type
            // 
            this.place_gridColumn_Type.Caption = "类别";
            this.place_gridColumn_Type.FieldName = "Type";
            this.place_gridColumn_Type.Name = "place_gridColumn_Type";
            this.place_gridColumn_Type.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_Type.Visible = true;
            this.place_gridColumn_Type.VisibleIndex = 2;
            // 
            // place_gridColumn_TypeCode
            // 
            this.place_gridColumn_TypeCode.Caption = "类别编号";
            this.place_gridColumn_TypeCode.FieldName = "TypeCode";
            this.place_gridColumn_TypeCode.Name = "place_gridColumn_TypeCode";
            this.place_gridColumn_TypeCode.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_TypeCode.Visible = true;
            this.place_gridColumn_TypeCode.VisibleIndex = 3;
            // 
            // place_gridColumn_Address
            // 
            this.place_gridColumn_Address.Caption = "地址";
            this.place_gridColumn_Address.FieldName = "Address";
            this.place_gridColumn_Address.Name = "place_gridColumn_Address";
            this.place_gridColumn_Address.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_Address.Visible = true;
            this.place_gridColumn_Address.VisibleIndex = 4;
            // 
            // place_gridColumn_Location
            // 
            this.place_gridColumn_Location.Caption = "坐标";
            this.place_gridColumn_Location.FieldName = "Location";
            this.place_gridColumn_Location.Name = "place_gridColumn_Location";
            this.place_gridColumn_Location.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_Location.Visible = true;
            this.place_gridColumn_Location.VisibleIndex = 5;
            // 
            // place_gridColumn_Province
            // 
            this.place_gridColumn_Province.Caption = "省份";
            this.place_gridColumn_Province.FieldName = "Province";
            this.place_gridColumn_Province.Name = "place_gridColumn_Province";
            this.place_gridColumn_Province.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_Province.Visible = true;
            this.place_gridColumn_Province.VisibleIndex = 6;
            // 
            // place_gridColumn_City
            // 
            this.place_gridColumn_City.Caption = "城市";
            this.place_gridColumn_City.FieldName = "City";
            this.place_gridColumn_City.Name = "place_gridColumn_City";
            this.place_gridColumn_City.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_City.Visible = true;
            this.place_gridColumn_City.VisibleIndex = 7;
            // 
            // place_gridColumn_District
            // 
            this.place_gridColumn_District.Caption = "区县";
            this.place_gridColumn_District.FieldName = "District";
            this.place_gridColumn_District.Name = "place_gridColumn_District";
            this.place_gridColumn_District.OptionsColumn.AllowEdit = false;
            this.place_gridColumn_District.Visible = true;
            this.place_gridColumn_District.VisibleIndex = 8;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode3.LevelTemplate = this.gridView3;
            gridLevelNode3.RelationName = "Places";
            gridLevelNode4.LevelTemplate = this.gridView2;
            gridLevelNode4.RelationName = "Words";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode3,
            gridLevelNode4});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridControl1.Size = new System.Drawing.Size(703, 319);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2,
            this.gridView1,
            this.gridView3});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.word_gridColumn_Id,
            this.word_gridColumn_Name});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.EnableAppearanceOddRow = true;
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            // 
            // word_gridColumn_Id
            // 
            this.word_gridColumn_Id.Caption = "Id";
            this.word_gridColumn_Id.Name = "word_gridColumn_Id";
            this.word_gridColumn_Id.OptionsColumn.AllowEdit = false;
            // 
            // word_gridColumn_Name
            // 
            this.word_gridColumn_Name.Caption = "名称";
            this.word_gridColumn_Name.FieldName = "Name";
            this.word_gridColumn_Name.Name = "word_gridColumn_Name";
            this.word_gridColumn_Name.OptionsColumn.AllowEdit = false;
            this.word_gridColumn_Name.Visible = true;
            this.word_gridColumn_Name.VisibleIndex = 0;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_Code,
            this.gridColumn_Name,
            this.gridColumn_WordCount,
            this.gridColumn_PlaceCount});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // gridColumn_Code
            // 
            this.gridColumn_Code.Caption = "编号";
            this.gridColumn_Code.FieldName = "Code";
            this.gridColumn_Code.Name = "gridColumn_Code";
            this.gridColumn_Code.OptionsColumn.AllowEdit = false;
            this.gridColumn_Code.Visible = true;
            this.gridColumn_Code.VisibleIndex = 0;
            // 
            // gridColumn_Name
            // 
            this.gridColumn_Name.Caption = "名称";
            this.gridColumn_Name.FieldName = "Name";
            this.gridColumn_Name.Name = "gridColumn_Name";
            this.gridColumn_Name.OptionsColumn.AllowEdit = false;
            this.gridColumn_Name.Visible = true;
            this.gridColumn_Name.VisibleIndex = 1;
            // 
            // gridColumn_WordCount
            // 
            this.gridColumn_WordCount.Caption = "分词数量";
            this.gridColumn_WordCount.FieldName = "WordCount";
            this.gridColumn_WordCount.Name = "gridColumn_WordCount";
            this.gridColumn_WordCount.OptionsColumn.AllowEdit = false;
            this.gridColumn_WordCount.Visible = true;
            this.gridColumn_WordCount.VisibleIndex = 2;
            // 
            // gridColumn_PlaceCount
            // 
            this.gridColumn_PlaceCount.Caption = "地理信息数量";
            this.gridColumn_PlaceCount.FieldName = "PlaceCount";
            this.gridColumn_PlaceCount.Name = "gridColumn_PlaceCount";
            this.gridColumn_PlaceCount.OptionsColumn.AllowEdit = false;
            this.gridColumn_PlaceCount.Visible = true;
            this.gridColumn_PlaceCount.VisibleIndex = 3;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonDropDownControl = this.appMenu;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btn_importexcel,
            this.barButtonItem2,
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(808, 147);
            // 
            // appMenu
            // 
            this.appMenu.Name = "appMenu";
            this.appMenu.Ribbon = this.ribbonControl1;
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
            this.barButtonItem2.Caption = "处理";
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
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_importexcel);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Common";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "地址";
            this.gridColumn1.FieldName = "Address";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 147);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(808, 319);
            this.splitContainerControl2.TabIndex = 10;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 466);
            this.Controls.Add(this.splitContainerControl2);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.Text = "终端Mapping辅助工具";
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.ApplicationMenu appMenu;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btn_importexcel;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Code;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Name;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_WordCount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_PlaceCount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_Name;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_Type;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_TypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_Address;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_Location;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_Province;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_City;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_District;
        private DevExpress.XtraGrid.Columns.GridColumn word_gridColumn_Id;
        private DevExpress.XtraGrid.Columns.GridColumn word_gridColumn_Name;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn place_gridColumn_ItemCode;
    }
}

