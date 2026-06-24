using Microsoft.Data.SqlClient;
using System;
using System.ServiceProcess;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace PeCollectionApp
{
    /// <summary>
    /// Main form for the Pen Collection application. Handles loading pens & inks from
    /// the database, filtering, and the inking dashboard UI.
    /// </summary>
    public partial class PenCollectionApp : Form
    {
        #region Fields & State
        private string connString = @"Server=SOHOM-MI-NOTEBO;Database=Fountain_Pen_DB;Trusted_Connection=True;TrustServerCertificate=True;";
        private const string SqlServiceName = "MSSQLSERVER";
        private bool wasSqlServiceRunningAlready = false;
        private DataTable dtPens = new DataTable();
        private DataTable dtInks = new DataTable();
        private Dictionary<string, string> activePenFilters = new Dictionary<string, string>();
        private Dictionary<string, string> activeInkFilters = new Dictionary<string, string>();
        #endregion

        #region Constructor & Initialization
        /// <summary>
        /// Initializes the form, sets up UI lists and loads data for pens and inks.
        /// </summary>
        public PenCollectionApp()
        {
            InitializeComponent();
            // 1. Tell Windows to run our custom startup code when the window physically opens
            this.Load += PenCollectionApp_Load;

            // 2. Tell Windows to run our custom shutdown code when the window closes
            this.FormClosing += PenCollectionApp_FormClosing;

        }

        /// <summary>
        /// Fires automatically as the window draws onto the screen. Handles database ignition.
        /// </summary>
        private void PenCollectionApp_Load(object sender, EventArgs e)
        {
            // ===================================================================
            // 1. DYNAMIC UI STRUCTURE & VIEW MODE INITIALIZATION
            // ===================================================================
            try
            {
                // Explicitly set the list layout style so text entries can render visible
                lvRemainingInks.View = View.List;

                // PLACE THE PHYSICAL LIST VIEW IN THE RIGHT COLUMN (Column Index = 2, Row Index = 1)
                tableLayoutPanel2.Controls.Add(lvRemainingInks, 2, 1);
            }
            catch (Exception layoutEx)
            {
                System.Diagnostics.Debug.WriteLine("UI Component Injection Error: " + layoutEx.Message);
            }

            // ===================================================================
            // 2. BACKGROUND DATABASE ENGINE SERVICE POWER IGNITION
            // ===================================================================
            try
            {
                using (ServiceController sqlService = new ServiceController(SqlServiceName))
                {
                    if (sqlService.Status == ServiceControllerStatus.Running ||
                        sqlService.Status == ServiceControllerStatus.StartPending)
                    {
                        wasSqlServiceRunningAlready = true;
                    }
                    else
                    {
                        wasSqlServiceRunningAlready = false;
                        sqlService.Start();

                        // Wait up to 15 seconds for SQL server to fully allocate RAM boundaries
                        sqlService.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(15));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database service engine auto-start failed: {ex.Message}\n\nEnsure this application is running with Administrative Privileges.",
                                "System Elevation Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // ===================================================================
            // 3. HARDWARE HANDLERS & MASTER DATA VIEW LOADS
            // ===================================================================
            pbNewPenPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxDetail.SizeMode = PictureBoxSizeMode.Zoom;
            this.listViewInks.SelectedIndexChanged += new System.EventHandler(this.listViewInks_SelectedIndexChanged);
            filterMenu.DropShadowEnabled = true;

            tableLayoutPanel2.Controls.Add(lvRemainingInks, 2, 0);

            ConfigureLists();
            LoadPensToListView();
            LoadInksToListView();
            SetupInkedUI();
            LoadInkedDashboard();

            // Execute the relational exclusion dataset parsing script
            LoadRemainingInksToListView();
            UpdateMetricLabel();
        }

        /// <summary>
        /// Fires automatically on window exit. Shuts down background SQL if we started it.
        /// </summary>
        private void PenCollectionApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (wasSqlServiceRunningAlready) return;

            try
            {
                using (ServiceController sqlService = new ServiceController(SqlServiceName))
                {
                    if (sqlService.Status != ServiceControllerStatus.Stopped &&
                        sqlService.Status != ServiceControllerStatus.StopPending)
                    {
                        sqlService.Stop();
                        sqlService.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(15));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Service shutdown clean error: " + ex.Message);
            }
        }

        #endregion

        #region UI Configuration
        /// <summary>
        /// Configure visual properties for list views, labels and picture box used
        /// across the form.
        /// </summary>
        private void ConfigureLists()
        {
            listViewPens.View = View.Details;
            listViewPens.GridLines = true;
            listViewPens.FullRowSelect = true;
            listViewPens.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewPens.Columns.Clear();
            listViewPens.Columns.Add(new ColumnHeader { Text = "FOUNTAIN PEN LIBRARY", Width = listViewPens.Width - 25, TextAlign = HorizontalAlignment.Center });
            listViewPens.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            listViewInks.View = View.Details;
            listViewInks.GridLines = true;
            listViewInks.FullRowSelect = true;
            listViewInks.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewInks.Columns.Clear();
            listViewInks.Columns.Add(new ColumnHeader { Text = "INK LIBRARY", Width = listViewInks.Width - 25, TextAlign = HorizontalAlignment.Center });
            listViewInks.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            lblDetails.SelectionIndent = 25;
            lblDetails.ReadOnly = true;
            pictureBoxDetail.SizeMode = PictureBoxSizeMode.Zoom;

            // ADD THIS BLOCK TO INITIALIZE THE REMAINING INKS GRID
            lvRemainingInks.View = View.Details; // Switch from List to Details
            lvRemainingInks.GridLines = true;
            lvRemainingInks.FullRowSelect = true;
            lvRemainingInks.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvRemainingInks.Columns.Clear();
            lvRemainingInks.Columns.Add(new ColumnHeader { Text = "Unused Inks", Width = lvRemainingInks.Width - 25, TextAlign = HorizontalAlignment.Left });
            lvRemainingInks.Font = new Font("Segoe UI", 9, FontStyle.Regular);
        }
        #endregion

        #region Data Loading: Pens & Inks
        /// <summary>
        /// Load pens from the database into the local DataTable (dtPens) and apply
        /// the active filter to populate the ListView.
        /// </summary>
        private void LoadPensToListView()
        {
            // 1. Clear the UI list
            listViewPens.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // 2. We must select ALL columns used for filtering (Brand, Material, Size, etc.)
                string query = "SELECT Pen_id, Brand, Pen_Name, Nib_Material, Nib_Size, Body_Material FROM Pens";

                try
                {
                    conn.Open();

                    // 3. Use an Adapter to fill the DataTable (dtPens)
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    dtPens.Clear();
                    da.Fill(dtPens);

                    // 4. Delegate the actual "drawing" of the list to the Filter method.
                    // This ensures that even on first load, the list is built correctly.
                    RunFilter("PEN", null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pen Load Error: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Load inks from the database into the local DataTable (dtInks) and apply
        /// the active filter to populate the ListView.
        /// </summary>
        private void LoadInksToListView()
        {
            // 1. Clear the UI list
            listViewInks.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // 2. Select all columns mapped from your DB schema for filtering
                // Note: Using [Bottle_Volume(ml)] with brackets because of the parentheses
                string query = "SELECT Ink_id, Brand, Ink_Name, Ink_Color, Ink_Type, Container_Type, [Bottle_Volume(ml)], Price FROM Inks";

                try
                {
                    conn.Open();

                    // 3. Fill the dtInks DataTable to act as your local cache
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    dtInks.Clear();
                    da.Fill(dtInks);

                    // 4. Call RunFilter to populate the ListView for the first time
                    // This handles the "Show All" state automatically
                    RunFilter("INK", null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ink Load Error: " + ex.Message);
                }
            }
        }
        #endregion

        #region Selection Handlers
        /// <summary>
        /// Called when selection of the pens ListView changes. Switches the details
        /// panel to the library view and displays the selected pen details.
        /// </summary>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPens.SelectedItems.Count == 0) return;

            // AUTO-SWITCH: Flip right tabcontrol to Library View (Index 1)
            panelLibraryDetails.SelectedIndex = 1;

            if (listViewPens.SelectedItems.Count > 0)
            {
                DisplayDetails("PEN", Convert.ToInt32(listViewPens.SelectedItems[0].Tag));
            }
        }

        /// <summary>
        /// Called when selection of the inks ListView changes. Switches the details
        /// panel to the library view and displays the selected ink details.
        /// </summary>
        private void listViewInks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewInks.SelectedItems.Count == 0) return;

            // AUTO-SWITCH: Flip right tabcontrol to Library View (Index 1)
            panelLibraryDetails.SelectedIndex = 1;

            if (listViewInks.SelectedItems.Count > 0)
            {
                DisplayDetails("INK", Convert.ToInt32(listViewInks.SelectedItems[0].Tag));
            }
        }
        #endregion

        #region Detail Display
        /// <summary>
        /// Reads a single record (pen or ink) from the database and renders detailed
        /// information in the right-hand details pane including text and an image.
        /// </summary>
        private void DisplayDetails(string type, int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = (type == "PEN")
                    ? "SELECT * FROM Pens WHERE Pen_id = @id"
                    : "SELECT * FROM Inks WHERE Ink_id = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        penLabel.AutoSize = true;
                        penLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
                        penLabel.Text = $"{r["Brand"]} {r[(type == "PEN" ? "Pen_Name" : "Ink_Name")]}".ToUpper();

                        Font hFont = new Font("Segoe UI", 12, FontStyle.Bold);
                        Font bFont = new Font("Segoe UI", 10, FontStyle.Regular);
                        lblDetails.Clear();

                        if (type == "PEN")
                        {
                            // --- MAINTENANCE TRACKER ---
                            try
                            {
                                if (r["Date_Flushed"] != DBNull.Value)
                                {
                                    DateTime lastFlush = Convert.ToDateTime(r["Date_Flushed"]);
                                    int days = (DateTime.Today - lastFlush.Date).Days;
                                    lblFlush.Text = (days <= 0) ? "Flushed today" : $"{days} days unflushed";
                                }
                                else
                                {
                                    lblFlush.Text = "No flush history";
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                lblFlush.Text = "Flush history: N/A";
                            }
                            // ---------------------------

                            AppendText("IDENTIFICATION\n", hFont);
                            AppendText($"Brand: {r["Brand"]}\nModel: {r["Pen_Name"]}\n\n", bFont);
                            AppendText("TECHNICAL SPECS\n", hFont);
                            string mat = r["Nib_Material"].ToString();
                            string nib = mat.Equals("Steel", StringComparison.OrdinalIgnoreCase)
                                ? $"{r["Nib_Size"]} (Steel)" : $"{r["Nib_Size"]} ({r["Nib_Karats"]}K {mat})";
                            AppendText($"Nib: {nib}\nBody: {r["Body_Material"]}\nFiller: {r["Filling_Mechanism"]}\nCapacity: {r["Ink_Capacity(ml)"]} ml\n\n", bFont);

                            AppendText("VALUE\n", hFont);
                            AppendText($"Price: ₹{Convert.ToDecimal(r["Price(INR)"]):N0}\n", bFont);
                        }
                        else
                        {
                            // Clear the flush label if an Ink is selected
                            lblFlush.Text = "";

                            AppendText("INK IDENTIFICATION\n", hFont);
                            AppendText($"Brand: {r["Brand"]}\nInk: {r["Ink_Name"]}\nColor: {r["Ink_Color"]}\n\n", bFont);
                            AppendText("PROPERTIES & BOTTLE\n", hFont);
                            AppendText($"Type: {r["Ink_Type"]}\nContainer: {r["Container_Type"]}\nVolume: {r["Bottle_Volume(ml)"]} ml\n\n", bFont);

                            AppendText("VALUE\n", hFont);
                            AppendText($"Price: ₹{Convert.ToDecimal(r["Price"]):N0}\n", bFont);
                        }

                        byte[] imgData = r[(type == "PEN" ? "Pen_photo" : "Ink_photo")] as byte[];
                        if (imgData != null && imgData.Length > 2 &&
                           ((imgData[0] == 0xFF && imgData[1] == 0xD8) || (imgData[0] == 0x89 && imgData[1] == 0x50)))
                        {
                            using (var ms = new MemoryStream(imgData))
                            {
                                if (pictureBoxDetail.Image != null) pictureBoxDetail.Image.Dispose();
                                using (var tmp = Image.FromStream(ms))
                                {
                                    pictureBoxDetail.Image = new Bitmap(tmp);
                                }
                            }
                        }
                        else
                        {
                            if (pictureBoxDetail.Image != null) pictureBoxDetail.Image.Dispose();
                            pictureBoxDetail.Image = null;
                        }
                    }
                }
            }
        }
        #endregion

        #region UI Helpers
        /// <summary>
        /// Append styled text to the read-only RichTextBox used for details.
        /// </summary>
        private void AppendText(string text, Font font)
        {
            lblDetails.SelectionStart = lblDetails.TextLength;
            lblDetails.SelectionFont = font;
            lblDetails.AppendText(text);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            filterMenu.Items.Clear();

            // Fix: We check tabControl2 (the container) to see which internal tab is active
            // If your Pens are in the first tab and Inks in the second:
            if (LeftTabControl.SelectedIndex == 1)
            {
                BuildFilterMenu("PEN", new Dictionary<string, string> {
            { "Brand", "Brand" },
            { "Nib Material", "Nib_Material" },
            { "Tip Size", "Nib_Size" },
            { "Body Material", "Body_Material" }
        }, dtPens, activePenFilters);
            }
            else if (LeftTabControl.SelectedIndex == 2)
            {
                BuildFilterMenu("INK", new Dictionary<string, string> {
            { "Brand", "Brand" },
            { "Ink Color", "Ink_Color" },
            { "Ink Type", "Ink_Type" },
            { "Container", "Container_Type" }
        }, dtInks, activeInkFilters);
            }

            // Right-align the menu under the button in Panel 2
            Point screenPoint = btnFilter.PointToScreen(new Point(btnFilter.Width, btnFilter.Height));
            filterMenu.Show(screenPoint);
        }

        // 3. The Menu Builder: Creates the sub-menus dynamically
        /// <summary>
        /// Dynamically builds the filter menu for either Pens or Inks based on
        /// distinct column values from the provided DataTable.
        /// </summary>
        private void BuildFilterMenu(string mode, Dictionary<string, string> columns, DataTable data, Dictionary<string, string> activeDict)
        {
            foreach (var col in columns)
            {
                ToolStripMenuItem catMenu = new ToolStripMenuItem(col.Key);

                // Extract unique technical specs from the DataTable
                var values = data.AsEnumerable()
                    .Select(r => r.Field<string>(col.Value))
                    .Where(v => !string.IsNullOrEmpty(v))
                    .Distinct().OrderBy(v => v);

                ToolStripMenuItem allItem = new ToolStripMenuItem($"All {col.Key}s");
                allItem.Click += (s, ev) => RunFilter(mode, col.Value, null);
                catMenu.DropDownItems.Add(allItem);
                catMenu.DropDownItems.Add(new ToolStripSeparator());

                foreach (var val in values)
                {
                    ToolStripMenuItem valItem = new ToolStripMenuItem(val);
                    if (activeDict.ContainsKey(col.Value) && activeDict[col.Value] == val) valItem.Checked = true;
                    valItem.Click += (s, ev) => RunFilter(mode, col.Value, val);
                    catMenu.DropDownItems.Add(valItem);
                }
                filterMenu.Items.Add(catMenu);
            }

            filterMenu.Items.Add(new ToolStripSeparator());
            ToolStripMenuItem reset = new ToolStripMenuItem("Reset All Filters");
            reset.Click += (s, ev) => { activeDict.Clear(); RunFilter(mode, null, null); };
            filterMenu.Items.Add(reset);

        }

        // 4. The Filter Logic: Updates the UI
        /// <summary>
        /// Applies active filters to the cached DataTable (pens or inks) and
        /// repopulates the corresponding ListView.
        /// </summary>
        private void RunFilter(string mode, string column, string value)
        {
            bool isPen = (mode == "PEN");
            var activeDict = isPen ? activePenFilters : activeInkFilters;
            var lv = isPen ? listViewPens : listViewInks;
            var data = isPen ? dtPens : dtInks;

            string nameCol = isPen ? "Pen_Name" : "Ink_Name";
            string idCol = isPen ? "Pen_id" : "Ink_id";

            if (column != null)
            {
                if (value == null) activeDict.Remove(column);
                else activeDict[column] = value;
            }

            lv.BeginUpdate();
            lv.Items.Clear();

            // Filter logic
            string expression = string.Join(" AND ", activeDict.Select(f => $"[{f.Key}] = '{f.Value.Replace("'", "''")}'"));
            DataRow[] rows = data.Select(expression);

            foreach (DataRow row in rows)
            {
                ListViewItem item = new ListViewItem($"{row["Brand"]} {row[nameCol]}");
                item.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                item.Tag = row[idCol];

                // FIX for CS1061: Must use .Items.Add()
                lv.Items.Add(item);
            }
            lv.EndUpdate();

            btnFilter.BackColor = activeDict.Count > 0 ? Color.AliceBlue : SystemColors.Control;
        }
        #endregion

        #region Inking Dashboard Actions
        /// <summary>
        /// Ink the selected clean pen with the selected ink by inserting a mapping
        /// record into the Inkings table.
        /// </summary>
        private void btnInkSelectedPen_Click(object sender, EventArgs e)
        {
            // 1. MODIFIED CHECK
            int inkId = GetSelectedInkId();
            if (lvUninkedPens.SelectedItems.Count == 0 || inkId == -1)
            {
                MessageBox.Show("Please select an available pen and an ink from the 'Remaining Inks' list.");
                return;
            }

            // 2. Extract IDs
            int pId = Convert.ToInt32(lvUninkedPens.SelectedItems[0].Tag);

            // 3. Add the mapping record with the current timestamp
            // We use GETDATE() so SQL Server handles the date automatically
            ExecuteMaintenanceQuery($"INSERT INTO Inkings (Pen_id, Ink_id, Date_Inked) VALUES ({pId}, {inkId}, GETDATE())");

            // 4. Force a full synchronization 
            LoadRemainingInksToListView();
            LoadInkedDashboard();
            UpdateMetricLabel();
        }

        /// <summary>
        /// Remove the inking mapping for the selected pen (clean and store).
        /// </summary>
        private void btnCleanAndStore_Click(object sender, EventArgs e)
        {
            if (lvCurrentlyInked.SelectedItems.Count == 0) return;

            int pId = Convert.ToInt32(lvCurrentlyInked.SelectedItems[0].Tag);

            // 1. Delete from Inkings (removes the ink)
            ExecuteMaintenanceQuery($"DELETE FROM Inkings WHERE Pen_id = {pId}");

            // 2. NEW: Update the pen record to mark it as flushed today
            ExecuteMaintenanceQuery($"UPDATE Pens SET Date_Flushed = GETDATE() WHERE Pen_id = {pId}");

            // Clear the Duo-View photos when a pen is cleaned
            /*pbInkedPen.Image = null;
            pbInkedInk.Image = null;
            lblInkedPenDetails.Text = "";
            lblInkedInkDetails.Text = "";*/

            LoadRemainingInksToListView();
            LoadInkedDashboard();
        }

        /// <summary>
        /// Replace the ink used in the currently inked pen with another available ink.
        /// </summary>
        private void btnChangeCurrentInk_Click(object sender, EventArgs e)
        {
            // 1. Get the ink ID using the helper we created
            int newIId = GetSelectedInkId();
            if (lvCurrentlyInked.SelectedItems.Count == 0 || newIId == -1)
            {
                MessageBox.Show("Please select an inked pen and a new ink from the 'Remaining Inks' list.");
                return;
            }

            int savedIndex = lvCurrentlyInked.SelectedItems[0].Index;
            int pId = Convert.ToInt32(lvCurrentlyInked.SelectedItems[0].Tag);

            // 2. MODIFIED: Update the mapping table AND reset the Date_Inked to today
            ExecuteMaintenanceQuery($"UPDATE Inkings SET Ink_id = {newIId}, Date_Inked = GETDATE() WHERE Pen_id = {pId}");

            // 3. Refresh the UI
            LoadInkedDashboard();

            // 4. Restore selection
            if (lvCurrentlyInked.Items.Count > savedIndex)
            {
                lvCurrentlyInked.Items[savedIndex].Selected = true;
                lvCurrentlyInked.Items[savedIndex].Focused = true;
                lvCurrentlyInked.EnsureVisible(savedIndex);
            }

            // 5. Force update
            lvCurrentlyInked_SelectedIndexChanged(null, EventArgs.Empty);

            LoadRemainingInksToListView();
            LoadInkedDashboard();
        }

        // Helper to handle SQL execution and UI Refresh
        /// <summary>
        /// Execute a non-query maintenance SQL command and refresh the inked dashboard.
        /// </summary>
        private void ExecuteMaintenanceQuery(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadInkedDashboard(); // Refresh all lists
            }
            catch (Exception ex) { MessageBox.Show("Update Error: " + ex.Message); }
        }

        /// <summary>
        /// Handler to refresh the inked dashboard data from the database.
        /// </summary>
        private void btnRefreshDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                LoadInkedDashboard();
                LoadRemainingInksToListView(); // ADD THIS LINE
                UpdateMetricLabel();            // Refresh counts just in case
                Console.WriteLine("Inked Dashboard and Remaining Inks synced.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sync Failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Setup column headers and view modes for the three ListViews used in the
        /// inked dashboard (currently inked, uninked pens, available inks).
        /// </summary>
        private void SetupInkedUI()
        {
            // Configure Currently Inked List
            lvCurrentlyInked.View = View.Details;
            lvCurrentlyInked.FullRowSelect = true;
            lvCurrentlyInked.GridLines = true;
            lvCurrentlyInked.Columns.Clear();
            lvCurrentlyInked.Columns.Add("Fountain Pen", 220);
            lvCurrentlyInked.Columns.Add("Current Ink", 220);

            // Configure Uninked Pens List
            lvUninkedPens.View = View.Details;
            lvUninkedPens.FullRowSelect = true;
            lvUninkedPens.Columns.Clear();
            lvUninkedPens.Columns.Add("Available Pens (Clean)", 300);

            // Configure Available Inks List
            lvUnusedInks.View = View.Details;
            lvUnusedInks.FullRowSelect = true;
            lvUnusedInks.Columns.Clear();
            lvUnusedInks.Columns.Add("Available Ink Collection", 300);
        }

        /// <summary>
        /// Populate the inked dashboard lists by querying mapping and base tables.
        /// </summary>
        private void LoadInkedDashboard()
        {
            lvCurrentlyInked.Items.Clear();
            lvUninkedPens.Items.Clear();
            lvUnusedInks.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // 1. Load Currently Inked via Mapping Table
                    string q1 = @"SELECT P.Pen_id, P.Brand, P.Pen_Name, I.Brand AS IBrand, I.Ink_Name 
                          FROM Inkings Map
                          INNER JOIN Pens P ON Map.Pen_id = P.Pen_id
                          INNER JOIN Inks I ON Map.Ink_id = I.Ink_id";
                    using (SqlDataReader r = new SqlCommand(q1, conn).ExecuteReader())
                    {
                        while (r.Read())
                        {
                            ListViewItem item = new ListViewItem($"{r["Brand"]} {r["Pen_Name"]}");
                            item.SubItems.Add($"{r["IBrand"]} {r["Ink_Name"]}");
                            item.Tag = r["Pen_id"];
                            lvCurrentlyInked.Items.Add(item);
                        }
                    }

                    // 2. Load Available Pens (Not in Mapping Table)
                    string q2 = "SELECT Pen_id, Brand, Pen_Name FROM Pens WHERE Pen_id NOT IN (SELECT Pen_id FROM Inkings)";
                    using (SqlDataReader r = new SqlCommand(q2, conn).ExecuteReader())
                    {
                        while (r.Read())
                        {
                            ListViewItem item = new ListViewItem($"{r["Brand"]} {r["Pen_Name"]}");
                            item.Tag = r["Pen_id"];
                            lvUninkedPens.Items.Add(item);
                        }
                    }

                    // 3. Load Available Inks (All inks)
                    string q3 = "SELECT Ink_id, Brand, Ink_Name FROM Inks";
                    using (SqlDataReader r = new SqlCommand(q3, conn).ExecuteReader())
                    {
                        while (r.Read())
                        {
                            ListViewItem item = new ListViewItem($"{r["Brand"]} {r["Ink_Name"]}");
                            item.Tag = r["Ink_id"];
                            lvUnusedInks.Items.Add(item);
                        }
                    }
                    FitColumns();
                }
                catch (Exception ex) { MessageBox.Show("Sync Error: " + ex.Message); }
            }
        }
        /// <summary>
        /// Resize columns in the various ListViews to fit the current control sizes.
        /// </summary>
        private void FitColumns()
        {
            // For the top active list (Split 50/50)
            int totalWidth = lvCurrentlyInked.ClientSize.Width;
            if (lvCurrentlyInked.Columns.Count >= 2)
            {
                lvCurrentlyInked.Columns[0].Width = totalWidth / 2;
                lvCurrentlyInked.Columns[1].Width = totalWidth / 2;
            }

            // For the bottom available lists (Take full width of their respective containers)
            if (lvUninkedPens.Columns.Count > 0)
                lvUninkedPens.Columns[0].Width = lvUninkedPens.ClientSize.Width - 4;

            if (lvUnusedInks.Columns.Count > 0)
                lvUnusedInks.Columns[0].Width = lvUnusedInks.ClientSize.Width - 4;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Called when the details panel tab is changed; used to refresh views as needed.
        /// </summary>
        private void panelLibraryDetails_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // If we are looking at the Inking View
            if (panelLibraryDetails.SelectedIndex == 0)
            {
                // lblDetailHeader.Text = "ACTIVE INKING CONFIGURATION";

                // Refresh the Duo-View photos if something is selected in the list
                lvCurrentlyInked_SelectedIndexChanged(null, EventArgs.Empty);
            }
            else
            {
                // lblDetailHeader.Text = "COLLECTION DETAILS";
            }
        }
        /// <summary>
        /// Convert a byte array to a GDI+ Image.
        /// </summary>
        private Image ByteArrayToImage(byte[] b)
        {
            using (MemoryStream ms = new MemoryStream(b))
            {
                return Image.FromStream(ms);
            }
        }

        /// <summary>
        /// When the selected item in the currently inked list changes, update
        /// the Duo-View with images and textual details for the pen and ink.
        /// </summary>
        private void lvCurrentlyInked_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lvCurrentlyInked.SelectedItems.Count == 0) return;

            // AUTO-SWITCH: Flip right tabcontrol to Inking View (Index 0)
            panelLibraryDetails.SelectedIndex = 0;

            int pId = Convert.ToInt32(lvCurrentlyInked.SelectedItems[0].Tag);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = @"SELECT P.Brand, P.Pen_Name, P.Nib_Material, P.Pen_photo, 
                              I.Brand AS IBrand, I.Ink_Name, I.Ink_Color, I.Ink_photo, 
                              Map.Date_Inked 
                       FROM Inkings Map 
                       INNER JOIN Pens P ON Map.Pen_id = P.Pen_id 
                       INNER JOIN Inks I ON Map.Ink_id = I.Ink_id 
                       WHERE Map.Pen_id = @pid";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pid", pId);

                try
                {
                    conn.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            // 1. Fetch and format the date safely
                            string dateInfo = "Inked on: Unknown"; // Fallback

                            if (r["Date_Inked"] != DBNull.Value)
                            {
                                DateTime inkedDate = Convert.ToDateTime(r["Date_Inked"]);
                                TimeSpan ts = DateTime.Today - inkedDate.Date;

                                // Logic: If 0 days, say "today". Otherwise, show the count.
                                string dayText = (ts.Days == 0) ? "today" : $"{ts.Days} days before today";
                                dateInfo = $"Inked on {inkedDate:dd/MM/yyyy} ({dayText})";
                            }

                            // 2. Pen Side
                            lblInkedPenDetails.Text = $"{r["Brand"]} {r["Pen_Name"]}\nNib: {r["Nib_Material"]}\n{dateInfo}";
                            pbInkedPen.Image = r["Pen_photo"] != DBNull.Value ? ByteArrayToImage((byte[])r["Pen_photo"]) : null;

                            // 3. Ink Side
                            lblInkedInkDetails.Text = $"{r["IBrand"]} {r["Ink_Name"]}\nColor: {r["Ink_Color"]}";
                            pbInkedInk.Image = r["Ink_photo"] != DBNull.Value ? ByteArrayToImage((byte[])r["Ink_photo"]) : null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading details: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Ensure ListView columns remain sized proportionally when the form is resized.
        /// </summary>
        private void PenCollectionApp_Resize(object sender, EventArgs e)
        {
            FitColumns();
        }
        #endregion



        #region ARCHIVAL ENTRY: NEW FOUNTAIN PEN SUBMISSION
        /// <summary>
        /// Direct local file system entry trigger wired straight to the canvas preview container.
        /// Reads image data into memory arrays without creating file access locks.
        /// </summary>
        private void pbNewPenPreview_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Select Pen Macro Photography Profile";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            pbNewPenPreview.Image = Image.FromStream(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not cache macro file: " + ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Main verification pipeline for new hardware registration. Builds parameterized queries, 
        /// converts gold-karat specifications based on material, and processes photo buffers.
        /// Maps the realigned #6/#8 housing sizes, tip types, and pricing schemas seamlessly.
        /// </summary>
        private void btnSavePen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrand.Text) || string.IsNullOrWhiteSpace(txtPenName.Text))
            {
                MessageBox.Show("Core fields missing! Enter a Brand and Pen Name before submitting.",
                                "Validation Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = @"INSERT INTO Pens (Brand, Pen_Name, Nib_Size, Nib_Material, Nib_Karats, Tip_Type, Body_Material, Filling_Mechanism, [Ink_Capacity(ml)], [Price(INR)], Pen_photo) 
                               VALUES (@Brand, @Name, @Size, @Mat, @Karats, @TipType, @Body, @Mech, @Cap, @Price, @Photo)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Brand", txtBrand.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtPenName.Text.Trim());

                    // Maps numerical housing size (#5, #6, #8) as a string straight from the NumericUpDown value
                    cmd.Parameters.AddWithValue("@Size", numNibSize.Value.ToString());
                    cmd.Parameters.AddWithValue("@Mat", cmbNibMaterial.SelectedItem?.ToString() ?? "Steel");

                    if (cmbNibMaterial.SelectedItem?.ToString() == "Steel" || numNibKarats.Value == 0)
                        cmd.Parameters.AddWithValue("@Karats", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Karats", (byte)numNibKarats.Value);

                    // Newly mapped fine lines categorical picker selection (EF, F, M, B, Architect, etc.)
                    cmd.Parameters.AddWithValue("@TipType", cmbTipType.SelectedItem?.ToString() ?? "M");
                    cmd.Parameters.AddWithValue("@Body", txtBodyMaterial.Text.Trim());
                    cmd.Parameters.AddWithValue("@Mech", cmbFillingMech.SelectedItem?.ToString() ?? "Converter");
                    cmd.Parameters.AddWithValue("@Cap", numCapacity.Value);
                    cmd.Parameters.AddWithValue("@Price", numPrice.Value);

                    byte[] photoData = ImageToByteArray(pbNewPenPreview.Image);
                    if (photoData != null)
                        cmd.Parameters.Add("@Photo", SqlDbType.VarBinary, -1).Value = photoData;
                    else
                        cmd.Parameters.Add("@Photo", SqlDbType.VarBinary, -1).Value = DBNull.Value;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Archival record committed to database repository!", "Submission Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearPenForm();

                        // Sync system and refresh workbench data streams
                        LoadPensToListView();
                        LoadInkedDashboard();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("SQL Transaction Failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Flushes form elements and resets UI components to clear the input entry area.
        /// </summary>
        private void ClearPenForm()
        {
            txtBrand.Clear();
            txtPenName.Clear();
            txtBodyMaterial.Clear();
            numNibSize.Value = 0;
            numNibKarats.Value = 0;
            numCapacity.Value = 0;
            numPrice.Value = 0;
            cmbNibMaterial.SelectedIndex = -1;
            cmbTipType.SelectedIndex = -1;
            cmbFillingMech.SelectedIndex = -1;
            pbNewPenPreview.Image = null;
        }

        /// <summary>
        /// Converts an image asset cleanly into a serialized byte array buffer 
        /// by executing a deep memory clone to bypass active GDI+ file stream locks.
        /// </summary>
        private byte[] ImageToByteArray(Image img)
        {
            if (img == null) return null;

            // Generate a brand new, detached deep memory copy bitmap frame 
            // of the exact same pixel dimensions to drop file handle dependencies
            using (Bitmap isolatedBitmap = new Bitmap(img.Width, img.Height))
            {
                // Force a premium 32-bit ARGB graphics palette canvas
                using (Graphics g = Graphics.FromImage(isolatedBitmap))
                {
                    g.Clear(Color.Transparent);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
                }

                // Compile the detached bitmap data safely into an array stream buffer
                using (MemoryStream ms = new MemoryStream())
                {
                    // Utilizing PNG format here preserves raw macro photography details 
                    // and ink swatch clarity flawlessly
                    isolatedBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }
        #endregion

        #region RELATIONAL ARCHIVE MAINTENANCE: EDIT & REMOVE ENGINE
        /// <summary>
        /// Dynamic context router for record modification. Evaluates active visible tab controls
        /// directly to launch a perfectly tailored, spacious rectangular metadata editing window.
        /// </summary>
        private void btnEditCurrent_Click(object sender, EventArgs e)
        {
            // FOOLPROOF DETECTION: Check exactly which sub-tab layout your eyes are staring at
            bool isPenView = false;
            bool isInkView = false;

            if (panelLibraryDetails.SelectedTab != null)
            {
                string tabText = panelLibraryDetails.SelectedTab.Text.ToLower();

                if (tabText.Contains("pen"))
                {
                    isPenView = true;
                }
                else if (tabText.Contains("ink"))
                {
                    isInkView = true;
                }
            }

            // Safety baseline check: If tab parsing fails, fallback cleanly to visible list containers
            if (!isPenView && !isInkView)
            {
                if (listViewPens.Visible) isPenView = true;
                else if (listViewInks.Visible) isInkView = true;
            }

            // Enforce that a target item must actually be selected inside the active list view canvas
            if (isPenView && listViewPens.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a fountain pen from the list text grid to edit.",
                                "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (isInkView && listViewInks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an ink swatch profile from the list text grid to edit.",
                                "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a premium, spacious single-window dialog completely dynamically
            using (Form editForm = new Form())
            {
                editForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                editForm.StartPosition = FormStartPosition.CenterParent;
                editForm.MaximizeBox = false;
                editForm.MinimizeBox = false;

                // DEEP WORKSPACE FRAME: Substantially tall landscape layout
                editForm.Size = new Size(740, 310);

                // Crisp, high-readability font engine
                Font customFont = new Font("Segoe UI", 11F, FontStyle.Regular);
                editForm.Font = customFont;

                // Generous vertical grid layout - separated by 70 pixels for wide breathing room
                Label lbl1 = new Label() { Left = 35, Top = 35, Width = 150, Height = 38, TextAlign = ContentAlignment.MiddleLeft };
                Label lbl2 = new Label() { Left = 35, Top = 105, Width = 150, Height = 38, TextAlign = ContentAlignment.MiddleLeft }; // Top = 105

                // Multiline + Height 38 gives massive vertical cushion padding around your text entries
                TextBox txt1 = new TextBox() { Left = 200, Top = 35, Width = 480, Height = 38, Multiline = true };
                TextBox txt2 = new TextBox() { Left = 200, Top = 105, Width = 480, Height = 38, Multiline = true }; // Top = 105

                Label lbl3 = new Label() { Left = 35, Top = 175, Width = 150, Height = 38, TextAlign = ContentAlignment.MiddleLeft, Visible = false }; // Top = 175
                TextBox txt3 = new TextBox() { Left = 200, Top = 175, Width = 480, Height = 38, Multiline = true, Visible = false }; // Top = 175

                // Action keys aligned symmetrically in the open floor plan area
                Button btnConfirm = new Button() { Text = "Save Changes", DialogResult = DialogResult.OK, Left = 380, Top = 190, Width = 140, Height = 38 };
                Button btnCancel = new Button() { Text = "Cancel", DialogResult = DialogResult.Cancel, Left = 540, Top = 190, Width = 140, Height = 38 };

                editForm.AcceptButton = btnConfirm;
                editForm.CancelButton = btnCancel;

                int targetId = 0;

                // Configure window semantics based on active layout container state
                if (isPenView && listViewPens.SelectedItems.Count > 0)
                {
                    targetId = Convert.ToInt32(listViewPens.SelectedItems[0].Tag);
                    editForm.Text = "Modify Pen Archival Metadata";

                    lbl1.Text = "Brand Name:";
                    lbl2.Text = "Pen Model Name:";

                    string fullText = listViewPens.SelectedItems[0].Text;
                    string[] parts = fullText.Split(new char[] { ' ' }, 2);
                    txt1.Text = parts[0];
                    txt2.Text = parts.Length > 1 ? parts[1] : "";
                }
                else if (isInkView && listViewInks.SelectedItems.Count > 0)
                {
                    var selectedItem = listViewInks.SelectedItems[0];
                    targetId = Convert.ToInt32(selectedItem.Tag);
                    editForm.Text = "Modify Ink Archival Metadata";

                    lbl1.Text = "Brand Name:";
                    lbl2.Text = "Ink Variant Name:";
                    lbl3.Text = "Ink Color Tone:";

                    lbl3.Visible = true;
                    txt3.Visible = true;

                    // Drop layout buttons completely down into the deep ink canvas window
                    btnConfirm.Top = 255;
                    btnCancel.Top = 255;
                    editForm.Size = new Size(740, 380);

                    string fullText = selectedItem.Text;
                    string[] parts = fullText.Split(new char[] { ' ' }, 2);
                    txt1.Text = parts[0];
                    txt2.Text = parts.Length > 1 ? parts[1] : "";

                    if (selectedItem.SubItems.Count > 1)
                        txt3.Text = selectedItem.SubItems[1].Text;
                }
                else
                {
                    MessageBox.Show("Please explicitly highlight a collection item profile link before hitting Edit.",
                                    "Context Routing Unresolved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                editForm.Controls.AddRange(new Control[] { lbl1, lbl2, lbl3, txt1, txt2, txt3, btnConfirm, btnCancel });

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(txt1.Text) || string.IsNullOrWhiteSpace(txt2.Text))
                    {
                        MessageBox.Show("Modifications abandoned. Primary catalog markers cannot be saved blank.",
                                        "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        try
                        {
                            conn.Open();

                            if (isPenView)
                            {
                                string sql = "UPDATE Pens SET Brand = @Brand, Pen_Name = @Name WHERE Pen_id = @Id";
                                using (SqlCommand cmd = new SqlCommand(sql, conn))
                                {
                                    cmd.Parameters.AddWithValue("@Brand", txt1.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Name", txt2.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Id", targetId);
                                    cmd.ExecuteNonQuery();
                                }

                                MessageBox.Show("Pen catalog metadata updated successfully!", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadPensToListView();
                            }
                            else if (isInkView)
                            {
                                string sql = "UPDATE Inks SET Brand = @Brand, Ink_Name = @Name, Ink_Color = @Color WHERE Ink_id = @Id";
                                using (SqlCommand cmd = new SqlCommand(sql, conn))
                                {
                                    cmd.Parameters.AddWithValue("@Brand", txt1.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Name", txt2.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Color", string.IsNullOrWhiteSpace(txt3.Text) ? DBNull.Value : (object)txt3.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Id", targetId);
                                    cmd.ExecuteNonQuery();
                                }

                                MessageBox.Show("Ink chemistry index updated successfully!", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadInksToListView();
                            }

                            LoadInkedDashboard();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Modification Error: " + ex.Message, "Database Transaction Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles safety confirmations and executes structural record purging. Auto-deletes active mapping entries 
        /// from the Inkings bridge table before erasing master profiles to satisfy foreign key constraint paths.
        /// </summary>
        private void btnRemoveCurrent_Click(object sender, EventArgs e)
        {
            bool isPenView = (panelLibraryDetails.SelectedIndex == 1 && listViewPens.SelectedItems.Count > 0);
            bool isInkView = (panelLibraryDetails.SelectedIndex == 1 && listViewInks.SelectedItems.Count > 0);

            if (!isPenView && !isInkView)
            {
                MessageBox.Show("Please isolate a target record item in the selection grid lists to execute a purge command.",
                                "Purge Target Unspecified", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetLabel = isPenView ? listViewPens.SelectedItems[0].Text : listViewInks.SelectedItems[0].Text;
            DialogResult confirm = MessageBox.Show($"Are you absolutely certain you want to permanently erase '{targetLabel}' from your local library archival database?\n\nThis will safely clean up any current active workbench assignments.",
                                                   "Critical Deletion Safeguard", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    if (isPenView)
                    {
                        int penId = Convert.ToInt32(listViewPens.SelectedItems[0].Tag);

                        // 1. Clear relational bridge paths to prevent foreign key errors
                        string cleanBridgeSql = "DELETE FROM Inkings WHERE Pen_id = @Id";
                        using (SqlCommand cmd = new SqlCommand(cleanBridgeSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", penId);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Erase core data profile row
                        string deletePenSql = "DELETE FROM Pens WHERE Pen_id = @Id";
                        using (SqlCommand cmd = new SqlCommand(deletePenSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", penId);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Fountain Pen permanently cleared from core tables.", "Purge Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPensToListView();
                    }
                    else if (isInkView)
                    {
                        int inkId = Convert.ToInt32(listViewInks.SelectedItems[0].Tag);

                        // 1. Clear relational bridge paths to prevent foreign key errors
                        string cleanBridgeSql = "DELETE FROM Inkings WHERE Ink_id = @Id";
                        using (SqlCommand cmd = new SqlCommand(cleanBridgeSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", inkId);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Erase core data profile row
                        string deleteInkSql = "DELETE FROM Inks WHERE Ink_id = @Id";
                        using (SqlCommand cmd = new SqlCommand(deleteInkSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", inkId);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Ink chemistry index profile permanently cleared from core tables.", "Purge Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadInksToListView();
                    }

                    // Reset detail panel views to clear out deleted pixel matrices
                    pictureBoxDetail.Image = null;
                    lblDetails.Clear();
                    penLabel.Text = "SELECTION DETACHED";

                    LoadInkedDashboard(); // Force interface refreshing streams
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Purge Execution Interrupted: " + ex.Message, "Database Constraint Breach", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LeftTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is TabControl leftTabs && leftTabs.SelectedTab != null)
            {
                string activeTab = leftTabs.SelectedTab.Text.ToLower();

                if (activeTab.Contains("pen"))
                {
                    if (listViewInks.SelectedItems.Count > 0) listViewInks.SelectedItems.Clear();
                }
                else if (activeTab.Contains("ink"))
                {
                    if (listViewPens.SelectedItems.Count > 0) listViewPens.SelectedItems.Clear();
                }

                // FORCE THE METRIC LABEL TO SWAP HIGHLIGHTS INSTANTLY
                UpdateMetricLabel();
            }
        }
        #endregion

        #region DETAIL PANEL EVENT HANDLER INTERACTIONS
        /// <summary>
        /// Queries the database for inks that are completely unassigned to any active pen
        /// and populates the remaining inks inventory grid.
        /// </summary>
        private void LoadRemainingInksToListView()
        {
            lvRemainingInks.BeginUpdate(); // Freeze UI
            lvRemainingInks.Items.Clear();

            string sql = @"SELECT i.Ink_id, i.Brand, i.Ink_Name 
                   FROM Inks i
                   WHERE NOT EXISTS (SELECT 1 FROM Inkings p WHERE p.Ink_id = i.Ink_id)
                   ORDER BY i.Brand, i.Ink_Name;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem($"{reader["Brand"]} {reader["Ink_Name"]}");
                            item.Tag = reader["Ink_id"];
                            lvRemainingInks.Items.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Remaining Inks Query Failure: " + ex.Message);
                }
            }
            lvRemainingInks.EndUpdate(); // Force redraw of all new items
        }
        /// <summary>
        /// Retrieves the Ink_id of the currently selected ink by scanning both 
        /// the new 'Remaining Inks' list and the original 'Available Inks' list. 
        /// Provides a unified selection bridge for all inking action buttons.
        /// </summary>
        private int GetSelectedInkId()
        {
            // If something is selected in the "Remaining Inks" list, return that
            if (lvRemainingInks.SelectedItems.Count > 0)
                return Convert.ToInt32(lvRemainingInks.SelectedItems[0].Tag);

            // Fallback to your original list if needed
            if (lvUnusedInks.SelectedItems.Count > 0)
                return Convert.ToInt32(lvUnusedInks.SelectedItems[0].Tag);

            return -1; // Indicates nothing is currently selected
        }
        #endregion

        #region ARCHIVAL ENTRY: NEW INK FLUID SUBMISSION
        /// <summary>
        /// Direct local file system entry trigger wired straight to the ink canvas preview container.
        /// Reads swatch images into memory arrays without creating file access locks.
        /// </summary>
        private void pbNewInkPreview_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Select Ink Swatch or Macro Texture Profile";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            pbNewInkPreview.Image = Image.FromStream(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not cache ink profile image: " + ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Main verification pipeline for new ink fluid entry. Builds parameterized queries matching
        /// the 7 visual fields in the UI grid, processes photo buffers, and commits transactions safely.
        /// </summary>
        private void btnSaveInk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInkBrand.Text) || string.IsNullOrWhiteSpace(txtInkName.Text))
            {
                MessageBox.Show("Core fields missing! Enter an Ink Brand and Variant Name before submitting.",
                                "Validation Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // Updated query matching the exact 7 text/numeric properties plus the photo field
                string sql = @"INSERT INTO Inks (Brand, Ink_Name, Ink_Color, Ink_Type, Container_Type, [Bottle_Volume(ml)], Price, Ink_photo) 
                               VALUES (@Brand, @Name, @Color, @Type, @Container, @Volume, @Price, @Photo)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Brand", txtInkBrand.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtInkName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Color", string.IsNullOrWhiteSpace(txtInkColor.Text) ? DBNull.Value : (object)txtInkColor.Text.Trim());
                    cmd.Parameters.AddWithValue("@Type", cmbInkType.SelectedItem?.ToString() ?? "Standard");
                    cmd.Parameters.AddWithValue("@Container", cmbContainerType.SelectedItem?.ToString() ?? "Bottle");
                    cmd.Parameters.AddWithValue("@Volume", numVolume.Value);
                    cmd.Parameters.AddWithValue("@Price", numInkPrice.Value);

                    // Converts the preview image to a raw binary stream
                    byte[] photoData = ImageToByteArray(pbNewInkPreview.Image);
                    if (photoData != null)
                        cmd.Parameters.Add("@Photo", SqlDbType.VarBinary, -1).Value = photoData;
                    else
                        cmd.Parameters.Add("@Photo", SqlDbType.VarBinary, -1).Value = DBNull.Value;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Ink chemistry record successfully committed to database repository!", "Submission Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInkForm();

                        // Instantly refresh the UI master caches and active workbench views
                        LoadInksToListView();
                        LoadInkedDashboard();
                        LoadRemainingInksToListView(); // ADD THIS LINE
                        UpdateMetricLabel();           // ADD THIS LINE
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("SQL Ink Transaction Failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Flushes form elements and resets UI components to clear the ink entry area.
        /// </summary>
        private void ClearInkForm()
        {
            txtInkBrand.Clear();
            txtInkName.Clear();
            txtInkColor.Clear();
            numVolume.Value = 0;
            numInkPrice.Value = 0;
            cmbInkType.SelectedIndex = -1;
            cmbContainerType.SelectedIndex = -1;
            pbNewInkPreview.Image = null;
        }
        #endregion

        #region INVENTORY METRICS AGGREGATION
        /// <summary>
        /// Queries the database to extract both pen and ink resource counts 
        /// simultaneously and updates the global inventory tracker string.
        /// </summary>
        private void UpdateMetricLabel()
        {
            string penQuery = "SELECT COUNT(*) FROM Pens";
            string inkQuery = "SELECT COUNT(*) FROM Inks";

            int totalPens = 0;
            int totalInks = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // 1. Fetch total hardware counts
                    using (SqlCommand cmd = new SqlCommand(penQuery, conn))
                    {
                        totalPens = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 2. Fetch total fluid chemistry counts
                    using (SqlCommand cmd = new SqlCommand(inkQuery, conn))
                    {
                        totalInks = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Render the exact requested output layout format string
                    lblTotalCount.Text = $"Total Pens: {totalPens}, Total Inks: {totalInks}";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Inventory Metrics Aggregation Failure: " + ex.Message);
                    lblTotalCount.Text = "Inventory specs tracking offline";
                }
            }
        }
        #endregion
    }
}