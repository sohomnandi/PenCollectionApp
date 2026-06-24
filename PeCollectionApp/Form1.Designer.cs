namespace PeCollectionApp
{
    partial class PenCollectionApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PenCollectionApp));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            splitContainer1 = new SplitContainer();
            LeftTabControl = new TabControl();
            tabPage4 = new TabPage();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnInkSelectedPen = new Button();
            btnRefreshDashboard = new Button();
            btnCleanAndStore = new Button();
            btnChangeCurrentInk = new Button();
            splitContainer2 = new SplitContainer();
            tableLayoutPanel4 = new TableLayoutPanel();
            lvCurrentlyInked = new ListView();
            Pen = new ColumnHeader();
            Ink = new ColumnHeader();
            tableLayoutPanel2 = new TableLayoutPanel();
            lvUninkedPens = new ListView();
            available_pens = new ColumnHeader();
            lvUnusedInks = new ListView();
            available_inks = new ColumnHeader();
            lvRemainingInks = new ListView();
            tabPage5 = new TabPage();
            listViewPens = new ListView();
            imageList1 = new ImageList(components);
            tabPage6 = new TabPage();
            listViewInks = new ListView();
            panelLibraryDetails = new TabControl();
            panelInkingDetails = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            pbInkedInk = new PictureBox();
            pbInkedPen = new PictureBox();
            lblInkedPenDetails = new Label();
            lblInkedInkDetails = new Label();
            tabPage8 = new TabPage();
            lblFlush = new Label();
            lblTotalCount = new Label();
            tableLayoutPanel8 = new TableLayoutPanel();
            btnEditCurrent = new Button();
            btnRemoveCurrent = new Button();
            penLabel = new Label();
            btnFilter = new Button();
            lblDetails = new RichTextBox();
            pictureBoxDetail = new PictureBox();
            tabPage2 = new TabPage();
            tableLayoutPanel6 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtBodyMaterial = new TextBox();
            txtPenName = new TextBox();
            numNibSize = new NumericUpDown();
            numNibKarats = new NumericUpDown();
            numCapacity = new NumericUpDown();
            numPrice = new NumericUpDown();
            cmbNibMaterial = new ComboBox();
            cmbTipType = new ComboBox();
            cmbFillingMech = new ComboBox();
            label7 = new Label();
            txtBrand = new TextBox();
            pbNewPenPreview = new PictureBox();
            btnSavePen = new Button();
            tabPage3 = new TabPage();
            tableLayoutPanel7 = new TableLayoutPanel();
            numInkPrice = new NumericUpDown();
            cmbContainerType = new ComboBox();
            txtInkName = new TextBox();
            txtInkColor = new TextBox();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label21 = new Label();
            cmbInkType = new ComboBox();
            label22 = new Label();
            txtInkBrand = new TextBox();
            pbNewInkPreview = new PictureBox();
            numVolume = new NumericUpDown();
            btnSaveInk = new Button();
            filterMenu = new ContextMenuStrip(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            LeftTabControl.SuspendLayout();
            tabPage4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage6.SuspendLayout();
            panelLibraryDetails.SuspendLayout();
            panelInkingDetails.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbInkedInk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbInkedPen).BeginInit();
            tabPage8.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDetail).BeginInit();
            tabPage2.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numNibSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNibKarats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCapacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbNewPenPreview).BeginInit();
            tabPage3.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numInkPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbNewInkPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numVolume).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(2327, 1303);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer1);
            tabPage1.Location = new Point(8, 46);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(2311, 1249);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "View";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(LeftTabControl);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelLibraryDetails);
            splitContainer1.Size = new Size(2305, 1243);
            splitContainer1.SplitterDistance = 1136;
            splitContainer1.TabIndex = 0;
            // 
            // LeftTabControl
            // 
            LeftTabControl.Controls.Add(tabPage4);
            LeftTabControl.Controls.Add(tabPage5);
            LeftTabControl.Controls.Add(tabPage6);
            LeftTabControl.Dock = DockStyle.Fill;
            LeftTabControl.Location = new Point(0, 0);
            LeftTabControl.Name = "LeftTabControl";
            LeftTabControl.SelectedIndex = 0;
            LeftTabControl.Size = new Size(1136, 1243);
            LeftTabControl.TabIndex = 1;
            LeftTabControl.SelectedIndexChanged += LeftTabControl_SelectedIndexChanged;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(tableLayoutPanel3);
            tabPage4.Controls.Add(splitContainer2);
            tabPage4.Location = new Point(8, 46);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1120, 1189);
            tabPage4.TabIndex = 0;
            tabPage4.Text = "Inkings";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.Controls.Add(btnInkSelectedPen, 0, 0);
            tableLayoutPanel3.Controls.Add(btnRefreshDashboard, 3, 0);
            tableLayoutPanel3.Controls.Add(btnCleanAndStore, 1, 0);
            tableLayoutPanel3.Controls.Add(btnChangeCurrentInk, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(1114, 118);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // btnInkSelectedPen
            // 
            btnInkSelectedPen.Dock = DockStyle.Fill;
            btnInkSelectedPen.Location = new Point(3, 3);
            btnInkSelectedPen.Name = "btnInkSelectedPen";
            btnInkSelectedPen.Size = new Size(272, 112);
            btnInkSelectedPen.TabIndex = 3;
            btnInkSelectedPen.Text = "Ink Selected Pen";
            btnInkSelectedPen.UseVisualStyleBackColor = true;
            btnInkSelectedPen.Click += btnInkSelectedPen_Click;
            // 
            // btnRefreshDashboard
            // 
            btnRefreshDashboard.Dock = DockStyle.Fill;
            btnRefreshDashboard.Location = new Point(837, 3);
            btnRefreshDashboard.Name = "btnRefreshDashboard";
            btnRefreshDashboard.Size = new Size(274, 112);
            btnRefreshDashboard.TabIndex = 4;
            btnRefreshDashboard.Text = "Refresh Dashboard";
            btnRefreshDashboard.UseVisualStyleBackColor = true;
            btnRefreshDashboard.Click += btnRefreshDashboard_Click;
            // 
            // btnCleanAndStore
            // 
            btnCleanAndStore.Dock = DockStyle.Fill;
            btnCleanAndStore.Location = new Point(281, 3);
            btnCleanAndStore.Name = "btnCleanAndStore";
            btnCleanAndStore.Size = new Size(272, 112);
            btnCleanAndStore.TabIndex = 4;
            btnCleanAndStore.Text = "Clean/Store Pen";
            btnCleanAndStore.UseVisualStyleBackColor = true;
            btnCleanAndStore.Click += btnCleanAndStore_Click;
            // 
            // btnChangeCurrentInk
            // 
            btnChangeCurrentInk.Dock = DockStyle.Fill;
            btnChangeCurrentInk.Location = new Point(559, 3);
            btnChangeCurrentInk.Name = "btnChangeCurrentInk";
            btnChangeCurrentInk.Size = new Size(272, 112);
            btnChangeCurrentInk.TabIndex = 5;
            btnChangeCurrentInk.Text = "Change Current Ink";
            btnChangeCurrentInk.UseVisualStyleBackColor = true;
            btnChangeCurrentInk.Click += btnChangeCurrentInk_Click;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(tableLayoutPanel4);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainer2.Size = new Size(1114, 1183);
            splitContainer2.SplitterDistance = 668;
            splitContainer2.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Controls.Add(lvCurrentlyInked, 0, 0);
            tableLayoutPanel4.Location = new Point(0, 121);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(1114, 547);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // lvCurrentlyInked
            // 
            lvCurrentlyInked.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvCurrentlyInked.Columns.AddRange(new ColumnHeader[] { Pen, Ink });
            lvCurrentlyInked.Location = new Point(3, 3);
            lvCurrentlyInked.MultiSelect = false;
            lvCurrentlyInked.Name = "lvCurrentlyInked";
            lvCurrentlyInked.Size = new Size(1108, 541);
            lvCurrentlyInked.TabIndex = 0;
            lvCurrentlyInked.UseCompatibleStateImageBehavior = false;
            lvCurrentlyInked.View = View.Details;
            lvCurrentlyInked.SelectedIndexChanged += lvCurrentlyInked_SelectedIndexChanged;
            // 
            // Pen
            // 
            Pen.Text = "Pen";
            // 
            // Ink
            // 
            Ink.Text = "Ink";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.701088F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.298912F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 395F));
            tableLayoutPanel2.Controls.Add(lvUninkedPens, 0, 0);
            tableLayoutPanel2.Controls.Add(lvUnusedInks, 1, 0);
            tableLayoutPanel2.Controls.Add(lvRemainingInks, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(1114, 511);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // lvUninkedPens
            // 
            lvUninkedPens.Columns.AddRange(new ColumnHeader[] { available_pens });
            lvUninkedPens.Dock = DockStyle.Fill;
            lvUninkedPens.Location = new Point(3, 3);
            lvUninkedPens.MultiSelect = false;
            lvUninkedPens.Name = "lvUninkedPens";
            lvUninkedPens.Size = new Size(315, 505);
            lvUninkedPens.TabIndex = 1;
            lvUninkedPens.UseCompatibleStateImageBehavior = false;
            lvUninkedPens.View = View.Details;
            // 
            // available_pens
            // 
            available_pens.Text = "Available Pens";
            // 
            // lvUnusedInks
            // 
            lvUnusedInks.Columns.AddRange(new ColumnHeader[] { available_inks });
            lvUnusedInks.Dock = DockStyle.Fill;
            lvUnusedInks.Location = new Point(324, 3);
            lvUnusedInks.MultiSelect = false;
            lvUnusedInks.Name = "lvUnusedInks";
            lvUnusedInks.Size = new Size(391, 505);
            lvUnusedInks.TabIndex = 2;
            lvUnusedInks.UseCompatibleStateImageBehavior = false;
            lvUnusedInks.View = View.Details;
            // 
            // available_inks
            // 
            available_inks.Text = "Available Inks";
            // 
            // lvRemainingInks
            // 
            lvRemainingInks.Dock = DockStyle.Fill;
            lvRemainingInks.Location = new Point(721, 3);
            lvRemainingInks.Name = "lvRemainingInks";
            lvRemainingInks.Size = new Size(390, 505);
            lvRemainingInks.TabIndex = 3;
            lvRemainingInks.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(listViewPens);
            tabPage5.Location = new Point(8, 46);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1120, 1189);
            tabPage5.TabIndex = 1;
            tabPage5.Text = "Library - Pens";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // listViewPens
            // 
            listViewPens.Dock = DockStyle.Fill;
            listViewPens.Location = new Point(3, 3);
            listViewPens.MultiSelect = false;
            listViewPens.Name = "listViewPens";
            listViewPens.Size = new Size(1114, 1183);
            listViewPens.SmallImageList = imageList1;
            listViewPens.TabIndex = 0;
            listViewPens.UseCompatibleStateImageBehavior = false;
            listViewPens.View = View.Tile;
            listViewPens.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(listViewInks);
            tabPage6.Location = new Point(8, 46);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1120, 1189);
            tabPage6.TabIndex = 2;
            tabPage6.Text = "Library - Inks";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // listViewInks
            // 
            listViewInks.Dock = DockStyle.Fill;
            listViewInks.Location = new Point(0, 0);
            listViewInks.MultiSelect = false;
            listViewInks.Name = "listViewInks";
            listViewInks.Size = new Size(1120, 1189);
            listViewInks.TabIndex = 0;
            listViewInks.UseCompatibleStateImageBehavior = false;
            listViewInks.SelectedIndexChanged += listViewInks_SelectedIndexChanged;
            // 
            // panelLibraryDetails
            // 
            panelLibraryDetails.Controls.Add(panelInkingDetails);
            panelLibraryDetails.Controls.Add(tabPage8);
            panelLibraryDetails.Dock = DockStyle.Fill;
            panelLibraryDetails.Location = new Point(0, 0);
            panelLibraryDetails.Name = "panelLibraryDetails";
            panelLibraryDetails.SelectedIndex = 0;
            panelLibraryDetails.Size = new Size(1165, 1243);
            panelLibraryDetails.TabIndex = 4;
            panelLibraryDetails.SelectedIndexChanged += panelLibraryDetails_SelectedIndexChanged;
            // 
            // panelInkingDetails
            // 
            panelInkingDetails.Controls.Add(tableLayoutPanel1);
            panelInkingDetails.Location = new Point(8, 46);
            panelInkingDetails.Name = "panelInkingDetails";
            panelInkingDetails.Padding = new Padding(3);
            panelInkingDetails.Size = new Size(1149, 1189);
            panelInkingDetails.TabIndex = 0;
            panelInkingDetails.Text = "Inking View";
            panelInkingDetails.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pbInkedInk, 1, 0);
            tableLayoutPanel1.Controls.Add(pbInkedPen, 0, 0);
            tableLayoutPanel1.Controls.Add(lblInkedPenDetails, 0, 1);
            tableLayoutPanel1.Controls.Add(lblInkedInkDetails, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 56.2130165F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 43.7869835F));
            tableLayoutPanel1.Size = new Size(1143, 1183);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pbInkedInk
            // 
            pbInkedInk.Dock = DockStyle.Fill;
            pbInkedInk.Location = new Point(576, 5);
            pbInkedInk.Margin = new Padding(5);
            pbInkedInk.Name = "pbInkedInk";
            pbInkedInk.Size = new Size(562, 655);
            pbInkedInk.SizeMode = PictureBoxSizeMode.Zoom;
            pbInkedInk.TabIndex = 1;
            pbInkedInk.TabStop = false;
            // 
            // pbInkedPen
            // 
            pbInkedPen.Dock = DockStyle.Fill;
            pbInkedPen.Location = new Point(5, 5);
            pbInkedPen.Margin = new Padding(5);
            pbInkedPen.Name = "pbInkedPen";
            pbInkedPen.Size = new Size(561, 655);
            pbInkedPen.SizeMode = PictureBoxSizeMode.Zoom;
            pbInkedPen.TabIndex = 0;
            pbInkedPen.TabStop = false;
            // 
            // lblInkedPenDetails
            // 
            lblInkedPenDetails.AutoSize = true;
            lblInkedPenDetails.Dock = DockStyle.Fill;
            lblInkedPenDetails.Font = new Font("Segoe UI", 10F);
            lblInkedPenDetails.Location = new Point(3, 665);
            lblInkedPenDetails.Name = "lblInkedPenDetails";
            lblInkedPenDetails.Size = new Size(565, 518);
            lblInkedPenDetails.TabIndex = 2;
            lblInkedPenDetails.Text = "Select a Pen/Ink Pair";
            lblInkedPenDetails.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblInkedInkDetails
            // 
            lblInkedInkDetails.AutoSize = true;
            lblInkedInkDetails.Dock = DockStyle.Fill;
            lblInkedInkDetails.Font = new Font("Segoe UI", 10F);
            lblInkedInkDetails.Location = new Point(574, 665);
            lblInkedInkDetails.Name = "lblInkedInkDetails";
            lblInkedInkDetails.Size = new Size(566, 518);
            lblInkedInkDetails.TabIndex = 3;
            lblInkedInkDetails.Text = "Select a Pen/Ink Pair";
            lblInkedInkDetails.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabPage8
            // 
            tabPage8.Controls.Add(lblFlush);
            tabPage8.Controls.Add(lblTotalCount);
            tabPage8.Controls.Add(tableLayoutPanel8);
            tabPage8.Controls.Add(penLabel);
            tabPage8.Controls.Add(btnFilter);
            tabPage8.Controls.Add(lblDetails);
            tabPage8.Controls.Add(pictureBoxDetail);
            tabPage8.Location = new Point(8, 46);
            tabPage8.Name = "tabPage8";
            tabPage8.Padding = new Padding(3);
            tabPage8.Size = new Size(1149, 1189);
            tabPage8.TabIndex = 1;
            tabPage8.Text = "Library View";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // lblFlush
            // 
            lblFlush.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblFlush.AutoSize = true;
            lblFlush.Location = new Point(1052, 529);
            lblFlush.Name = "lblFlush";
            lblFlush.Size = new Size(91, 32);
            lblFlush.TabIndex = 8;
            lblFlush.Text = "label23";
            lblFlush.TextAlign = ContentAlignment.BottomRight;
            // 
            // lblTotalCount
            // 
            lblTotalCount.AutoSize = true;
            lblTotalCount.Dock = DockStyle.Bottom;
            lblTotalCount.Location = new Point(3, 532);
            lblTotalCount.Name = "lblTotalCount";
            lblTotalCount.Size = new Size(91, 32);
            lblTotalCount.TabIndex = 7;
            lblTotalCount.Text = "label23";
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Controls.Add(btnEditCurrent, 0, 0);
            tableLayoutPanel8.Controls.Add(btnRemoveCurrent, 1, 0);
            tableLayoutPanel8.Dock = DockStyle.Bottom;
            tableLayoutPanel8.Location = new Point(3, 564);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel8.Size = new Size(1143, 63);
            tableLayoutPanel8.TabIndex = 6;
            // 
            // btnEditCurrent
            // 
            btnEditCurrent.Dock = DockStyle.Fill;
            btnEditCurrent.Location = new Point(3, 3);
            btnEditCurrent.Name = "btnEditCurrent";
            btnEditCurrent.Size = new Size(565, 57);
            btnEditCurrent.TabIndex = 4;
            btnEditCurrent.Text = "Edit Selection";
            btnEditCurrent.UseVisualStyleBackColor = true;
            btnEditCurrent.Click += btnEditCurrent_Click;
            // 
            // btnRemoveCurrent
            // 
            btnRemoveCurrent.Dock = DockStyle.Fill;
            btnRemoveCurrent.Location = new Point(574, 3);
            btnRemoveCurrent.Name = "btnRemoveCurrent";
            btnRemoveCurrent.Size = new Size(566, 57);
            btnRemoveCurrent.TabIndex = 5;
            btnRemoveCurrent.Text = "Remove from Library";
            btnRemoveCurrent.UseVisualStyleBackColor = true;
            btnRemoveCurrent.Click += btnRemoveCurrent_Click;
            // 
            // penLabel
            // 
            penLabel.AutoSize = true;
            penLabel.Location = new Point(6, 6);
            penLabel.Name = "penLabel";
            penLabel.Size = new Size(341, 32);
            penLabel.TabIndex = 0;
            penLabel.Text = "Click a Pen/Ink to View Details.";
            // 
            // btnFilter
            // 
            btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilter.Location = new Point(1058, 6);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(85, 47);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // lblDetails
            // 
            lblDetails.Dock = DockStyle.Bottom;
            lblDetails.Location = new Point(3, 627);
            lblDetails.Name = "lblDetails";
            lblDetails.ReadOnly = true;
            lblDetails.Size = new Size(1143, 559);
            lblDetails.TabIndex = 2;
            lblDetails.Text = "";
            // 
            // pictureBoxDetail
            // 
            pictureBoxDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxDetail.Location = new Point(346, 112);
            pictureBoxDetail.Name = "pictureBoxDetail";
            pictureBoxDetail.Size = new Size(473, 418);
            pictureBoxDetail.TabIndex = 1;
            pictureBoxDetail.TabStop = false;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tableLayoutPanel6);
            tabPage2.Location = new Point(8, 46);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(2311, 1249);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "New Pen";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel6.Controls.Add(btnSavePen, 0, 1);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel6.Size = new Size(2305, 1243);
            tableLayoutPanel6.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 255F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(label1, 0, 0);
            tableLayoutPanel5.Controls.Add(label2, 0, 1);
            tableLayoutPanel5.Controls.Add(label3, 0, 2);
            tableLayoutPanel5.Controls.Add(label4, 0, 3);
            tableLayoutPanel5.Controls.Add(label5, 0, 4);
            tableLayoutPanel5.Controls.Add(label6, 0, 5);
            tableLayoutPanel5.Controls.Add(label8, 0, 7);
            tableLayoutPanel5.Controls.Add(label9, 0, 8);
            tableLayoutPanel5.Controls.Add(label10, 0, 9);
            tableLayoutPanel5.Controls.Add(label11, 0, 10);
            tableLayoutPanel5.Controls.Add(txtBodyMaterial, 1, 6);
            tableLayoutPanel5.Controls.Add(txtPenName, 1, 1);
            tableLayoutPanel5.Controls.Add(numNibSize, 1, 2);
            tableLayoutPanel5.Controls.Add(numNibKarats, 1, 4);
            tableLayoutPanel5.Controls.Add(numCapacity, 1, 8);
            tableLayoutPanel5.Controls.Add(numPrice, 1, 9);
            tableLayoutPanel5.Controls.Add(cmbNibMaterial, 1, 3);
            tableLayoutPanel5.Controls.Add(cmbTipType, 1, 5);
            tableLayoutPanel5.Controls.Add(cmbFillingMech, 1, 7);
            tableLayoutPanel5.Controls.Add(label7, 0, 6);
            tableLayoutPanel5.Controls.Add(txtBrand, 1, 0);
            tableLayoutPanel5.Controls.Add(pbNewPenPreview, 1, 10);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 11;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 9.90991F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 74F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 90.09009F));
            tableLayoutPanel5.Size = new Size(2299, 1170);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(176, 12);
            label1.Name = "label1";
            label1.Size = new Size(76, 32);
            label1.TabIndex = 0;
            label1.Text = "Brand";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(128, 68);
            label2.Name = "label2";
            label2.Size = new Size(124, 32);
            label2.TabIndex = 1;
            label2.Text = "Pen Name";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(150, 124);
            label3.Name = "label3";
            label3.Size = new Size(102, 32);
            label3.TabIndex = 2;
            label3.Text = "Nib Size";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(106, 183);
            label4.Name = "label4";
            label4.Size = new Size(146, 32);
            label4.TabIndex = 3;
            label4.Text = "Nib Material";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(129, 244);
            label5.Name = "label5";
            label5.Size = new Size(123, 32);
            label5.TabIndex = 4;
            label5.Text = "Nib Karats";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(147, 310);
            label6.Name = "label6";
            label6.Size = new Size(105, 32);
            label6.TabIndex = 5;
            label6.Text = "Tip Type";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(44, 461);
            label8.Name = "label8";
            label8.Size = new Size(208, 32);
            label8.TabIndex = 7;
            label8.Text = "Filling Mechanism";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(68, 537);
            label9.Name = "label9";
            label9.Size = new Size(184, 32);
            label9.TabIndex = 8;
            label9.Text = "Ink Capacity(ml)";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(128, 605);
            label10.Name = "label10";
            label10.Size = new Size(124, 32);
            label10.TabIndex = 9;
            label10.Text = "Price (INR)";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new Point(129, 896);
            label11.Name = "label11";
            label11.Size = new Size(123, 32);
            label11.TabIndex = 10;
            label11.Text = "Pen Photo";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtBodyMaterial
            // 
            txtBodyMaterial.Anchor = AnchorStyles.Left;
            txtBodyMaterial.Location = new Point(258, 379);
            txtBodyMaterial.Name = "txtBodyMaterial";
            txtBodyMaterial.Size = new Size(611, 39);
            txtBodyMaterial.TabIndex = 13;
            // 
            // txtPenName
            // 
            txtPenName.Anchor = AnchorStyles.Left;
            txtPenName.Location = new Point(258, 64);
            txtPenName.Name = "txtPenName";
            txtPenName.Size = new Size(611, 39);
            txtPenName.TabIndex = 12;
            // 
            // numNibSize
            // 
            numNibSize.Anchor = AnchorStyles.Left;
            numNibSize.Location = new Point(258, 120);
            numNibSize.Name = "numNibSize";
            numNibSize.Size = new Size(611, 39);
            numNibSize.TabIndex = 15;
            // 
            // numNibKarats
            // 
            numNibKarats.Anchor = AnchorStyles.Left;
            numNibKarats.Location = new Point(258, 240);
            numNibKarats.Name = "numNibKarats";
            numNibKarats.Size = new Size(611, 39);
            numNibKarats.TabIndex = 16;
            // 
            // numCapacity
            // 
            numCapacity.Anchor = AnchorStyles.Left;
            numCapacity.DecimalPlaces = 1;
            numCapacity.Location = new Point(258, 534);
            numCapacity.Name = "numCapacity";
            numCapacity.Size = new Size(611, 39);
            numCapacity.TabIndex = 17;
            // 
            // numPrice
            // 
            numPrice.Anchor = AnchorStyles.Left;
            numPrice.Location = new Point(258, 602);
            numPrice.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(611, 39);
            numPrice.TabIndex = 18;
            // 
            // cmbNibMaterial
            // 
            cmbNibMaterial.Anchor = AnchorStyles.Left;
            cmbNibMaterial.FormattingEnabled = true;
            cmbNibMaterial.Items.AddRange(new object[] { "Solid Gold", "Steel", "Titanium" });
            cmbNibMaterial.Location = new Point(258, 179);
            cmbNibMaterial.Name = "cmbNibMaterial";
            cmbNibMaterial.Size = new Size(611, 40);
            cmbNibMaterial.TabIndex = 19;
            // 
            // cmbTipType
            // 
            cmbTipType.Anchor = AnchorStyles.Left;
            cmbTipType.FormattingEnabled = true;
            cmbTipType.Items.AddRange(new object[] { "EF", "F", "MF", "M", "B", "BB", "Stub", "Italic", "Architect", "Music", "Fude", "Flex", "Zoom", "Naginata" });
            cmbTipType.Location = new Point(258, 306);
            cmbTipType.Name = "cmbTipType";
            cmbTipType.Size = new Size(611, 40);
            cmbTipType.TabIndex = 20;
            // 
            // cmbFillingMech
            // 
            cmbFillingMech.Anchor = AnchorStyles.Left;
            cmbFillingMech.FormattingEnabled = true;
            cmbFillingMech.Items.AddRange(new object[] { "Cartridge/Converter", "Piston Filler", "Vacuum Filler", "Eyedropper ", "Capillary Filler" });
            cmbFillingMech.Location = new Point(258, 457);
            cmbFillingMech.Name = "cmbFillingMech";
            cmbFillingMech.Size = new Size(611, 40);
            cmbFillingMech.TabIndex = 21;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(90, 383);
            label7.Name = "label7";
            label7.Size = new Size(162, 32);
            label7.TabIndex = 6;
            label7.Text = "Body Material";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtBrand
            // 
            txtBrand.Anchor = AnchorStyles.Left;
            txtBrand.Location = new Point(258, 8);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(611, 39);
            txtBrand.TabIndex = 11;
            // 
            // pbNewPenPreview
            // 
            pbNewPenPreview.BackColor = Color.Gainsboro;
            pbNewPenPreview.BorderStyle = BorderStyle.FixedSingle;
            pbNewPenPreview.Dock = DockStyle.Left;
            pbNewPenPreview.Location = new Point(258, 657);
            pbNewPenPreview.Name = "pbNewPenPreview";
            pbNewPenPreview.Size = new Size(622, 510);
            pbNewPenPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pbNewPenPreview.TabIndex = 22;
            pbNewPenPreview.TabStop = false;
            pbNewPenPreview.Click += pbNewPenPreview_Click;
            // 
            // btnSavePen
            // 
            btnSavePen.Dock = DockStyle.Fill;
            btnSavePen.Font = new Font("Segoe UI", 10F);
            btnSavePen.Location = new Point(3, 1179);
            btnSavePen.Name = "btnSavePen";
            btnSavePen.Size = new Size(2299, 61);
            btnSavePen.TabIndex = 1;
            btnSavePen.Text = "Save Pen";
            btnSavePen.UseVisualStyleBackColor = true;
            btnSavePen.Click += btnSavePen_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(tableLayoutPanel7);
            tabPage3.Controls.Add(btnSaveInk);
            tabPage3.Location = new Point(8, 46);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(2311, 1249);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "New Ink";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 255F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(numInkPrice, 1, 6);
            tableLayoutPanel7.Controls.Add(cmbContainerType, 1, 4);
            tableLayoutPanel7.Controls.Add(txtInkName, 1, 1);
            tableLayoutPanel7.Controls.Add(txtInkColor, 1, 2);
            tableLayoutPanel7.Controls.Add(label12, 0, 0);
            tableLayoutPanel7.Controls.Add(label13, 0, 1);
            tableLayoutPanel7.Controls.Add(label14, 0, 2);
            tableLayoutPanel7.Controls.Add(label15, 0, 3);
            tableLayoutPanel7.Controls.Add(label16, 0, 4);
            tableLayoutPanel7.Controls.Add(label17, 0, 5);
            tableLayoutPanel7.Controls.Add(label21, 0, 7);
            tableLayoutPanel7.Controls.Add(cmbInkType, 1, 3);
            tableLayoutPanel7.Controls.Add(label22, 0, 6);
            tableLayoutPanel7.Controls.Add(txtInkBrand, 1, 0);
            tableLayoutPanel7.Controls.Add(pbNewInkPreview, 1, 7);
            tableLayoutPanel7.Controls.Add(numVolume, 1, 5);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(0, 0);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 8;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 9.90991F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 74F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 90.09009F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel7.Size = new Size(2311, 1176);
            tableLayoutPanel7.TabIndex = 2;
            // 
            // numInkPrice
            // 
            numInkPrice.Anchor = AnchorStyles.Left;
            numInkPrice.Location = new Point(258, 401);
            numInkPrice.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numInkPrice.Name = "numInkPrice";
            numInkPrice.Size = new Size(611, 39);
            numInkPrice.TabIndex = 27;
            // 
            // cmbContainerType
            // 
            cmbContainerType.Anchor = AnchorStyles.Left;
            cmbContainerType.FormattingEnabled = true;
            cmbContainerType.Items.AddRange(new object[] { "Bottle", "Cartridge" });
            cmbContainerType.Location = new Point(258, 262);
            cmbContainerType.Name = "cmbContainerType";
            cmbContainerType.Size = new Size(611, 40);
            cmbContainerType.TabIndex = 25;
            // 
            // txtInkName
            // 
            txtInkName.Anchor = AnchorStyles.Left;
            txtInkName.Location = new Point(258, 86);
            txtInkName.Name = "txtInkName";
            txtInkName.Size = new Size(611, 39);
            txtInkName.TabIndex = 24;
            // 
            // txtInkColor
            // 
            txtInkColor.Anchor = AnchorStyles.Left;
            txtInkColor.Location = new Point(258, 142);
            txtInkColor.Name = "txtInkColor";
            txtInkColor.Size = new Size(611, 39);
            txtInkColor.TabIndex = 23;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new Point(176, 23);
            label12.Name = "label12";
            label12.Size = new Size(76, 32);
            label12.TabIndex = 0;
            label12.Text = "Brand";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Location = new Point(135, 90);
            label13.Name = "label13";
            label13.Size = new Size(117, 32);
            label13.TabIndex = 1;
            label13.Text = "Ink Name";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Location = new Point(128, 146);
            label14.Name = "label14";
            label14.Size = new Size(124, 32);
            label14.TabIndex = 2;
            label14.Text = "Ink Colour";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Location = new Point(148, 205);
            label15.Name = "label15";
            label15.Size = new Size(104, 32);
            label15.TabIndex = 3;
            label15.Text = "Ink Type";
            label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Location = new Point(76, 266);
            label16.Name = "label16";
            label16.Size = new Size(176, 32);
            label16.TabIndex = 4;
            label16.Text = "Container Type";
            label16.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Right;
            label17.AutoSize = true;
            label17.Location = new Point(46, 332);
            label17.Name = "label17";
            label17.Size = new Size(206, 32);
            label17.TabIndex = 5;
            label17.Text = "Bottle Volume(ml)";
            label17.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            label21.Anchor = AnchorStyles.Right;
            label21.AutoSize = true;
            label21.Location = new Point(136, 801);
            label21.Name = "label21";
            label21.Size = new Size(116, 32);
            label21.TabIndex = 10;
            label21.Text = "Ink Photo";
            label21.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbInkType
            // 
            cmbInkType.Anchor = AnchorStyles.Left;
            cmbInkType.FormattingEnabled = true;
            cmbInkType.Items.AddRange(new object[] { "Dye", "Pigment", "Iron Gall", "Shimmer" });
            cmbInkType.Location = new Point(258, 201);
            cmbInkType.Name = "cmbInkType";
            cmbInkType.Size = new Size(611, 40);
            cmbInkType.TabIndex = 19;
            // 
            // label22
            // 
            label22.Anchor = AnchorStyles.Right;
            label22.AutoSize = true;
            label22.Location = new Point(128, 405);
            label22.Name = "label22";
            label22.Size = new Size(124, 32);
            label22.TabIndex = 6;
            label22.Text = "Price (INR)";
            label22.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtInkBrand
            // 
            txtInkBrand.Anchor = AnchorStyles.Left;
            txtInkBrand.Location = new Point(258, 19);
            txtInkBrand.Name = "txtInkBrand";
            txtInkBrand.Size = new Size(611, 39);
            txtInkBrand.TabIndex = 11;
            // 
            // pbNewInkPreview
            // 
            pbNewInkPreview.BackColor = Color.Gainsboro;
            pbNewInkPreview.BorderStyle = BorderStyle.FixedSingle;
            pbNewInkPreview.Dock = DockStyle.Left;
            pbNewInkPreview.Location = new Point(258, 461);
            pbNewInkPreview.Name = "pbNewInkPreview";
            pbNewInkPreview.Size = new Size(622, 712);
            pbNewInkPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pbNewInkPreview.TabIndex = 22;
            pbNewInkPreview.TabStop = false;
            pbNewInkPreview.Click += pbNewInkPreview_Click;
            // 
            // numVolume
            // 
            numVolume.Anchor = AnchorStyles.Left;
            numVolume.DecimalPlaces = 1;
            numVolume.Location = new Point(258, 328);
            numVolume.Name = "numVolume";
            numVolume.Size = new Size(611, 39);
            numVolume.TabIndex = 26;
            // 
            // btnSaveInk
            // 
            btnSaveInk.Dock = DockStyle.Bottom;
            btnSaveInk.Font = new Font("Segoe UI", 10F);
            btnSaveInk.Location = new Point(0, 1176);
            btnSaveInk.Name = "btnSaveInk";
            btnSaveInk.Size = new Size(2311, 73);
            btnSaveInk.TabIndex = 3;
            btnSaveInk.Text = "Save Ink";
            btnSaveInk.UseVisualStyleBackColor = true;
            btnSaveInk.Click += btnSaveInk_Click;
            // 
            // filterMenu
            // 
            filterMenu.ImageScalingSize = new Size(32, 32);
            filterMenu.Name = "filterMenu";
            filterMenu.Size = new Size(61, 4);
            // 
            // PenCollectionApp
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2327, 1303);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PenCollectionApp";
            Text = "Pen Collection App";
            Resize += PenCollectionApp_Resize;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            LeftTabControl.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage6.ResumeLayout(false);
            panelLibraryDetails.ResumeLayout(false);
            panelInkingDetails.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbInkedInk).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbInkedPen).EndInit();
            tabPage8.ResumeLayout(false);
            tabPage8.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxDetail).EndInit();
            tabPage2.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numNibSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNibKarats).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCapacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbNewPenPreview).EndInit();
            tabPage3.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numInkPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbNewInkPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVolume).EndInit();
            ResumeLayout(false);
        }



        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private SplitContainer splitContainer1;
        private TabControl LeftTabControl;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private ListView listViewPens;
        private ImageList imageList1;
        private Label penLabel;
        private PictureBox pictureBoxDetail;
        private RichTextBox lblDetails;
        private TabPage tabPage6;
        private ListView listViewInks;
        private Button btnFilter;
        private ContextMenuStrip filterMenu;
        private ListView lvUnusedInks;
        private ListView lvUninkedPens;
        private ListView lvCurrentlyInked;
        private ColumnHeader Pen;
        private ColumnHeader Ink;
        private ColumnHeader available_pens;
        private Button btnChangeCurrentInk;
        private Button btnCleanAndStore;
        private Button btnInkSelectedPen;
        private ColumnHeader available_inks;
        private Button btnRefreshDashboard;
        private TabControl panelLibraryDetails;
        private TabPage panelInkingDetails;
        private TabPage tabPage8;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pbInkedInk;
        private PictureBox pbInkedPen;
        private Label lblInkedPenDetails;
        private Label lblInkedInkDetails;
        private SplitContainer splitContainer2;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txtBrand;
        private TextBox txtBodyMaterial;
        private TextBox txtPenName;
        private NumericUpDown numNibSize;
        private NumericUpDown numNibKarats;
        private NumericUpDown numCapacity;
        private NumericUpDown numPrice;
        private ComboBox cmbNibMaterial;
        private ComboBox cmbTipType;
        private ComboBox cmbFillingMech;
        private PictureBox pbNewPenPreview;
        private TableLayoutPanel tableLayoutPanel6;
        private Button btnSavePen;
        private Button btnRemoveCurrent;
        private Button btnEditCurrent;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private TextBox textBox2;
        private NumericUpDown numVolume;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private ComboBox cmbInkType;
        private ComboBox comboBox3;
        private Label label22;
        private TextBox txtInkBrand;
        private PictureBox pbNewInkPreview;
        private Button btnSaveInk;
        private TextBox txtInkColor;
        private TextBox txtInkName;
        private ComboBox cmbContainerType;
        private NumericUpDown numInkPrice;
        private TableLayoutPanel tableLayoutPanel8;
        private Label lblTotalCount;
        private ListView lvRemainingInks;
        private Label lblFlush;
    }
}
