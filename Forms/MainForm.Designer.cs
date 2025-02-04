namespace Pokedex.Forms;

partial class MainForm
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
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        
        
        //Form
        this.ClientSize = new System.Drawing.Size(900, 600);
        this.Text = "Pokedex";
        this.StartPosition = FormStartPosition.CenterScreen;
        
        //Controls
        searchBox = new TextBox();
        searchButton = new Button();
        nameLabel = new Label();
        heightLabel = new Label();
        weightLabel = new Label();
        pictureBox = new PictureBox();
        typesPanel = new FlowLayoutPanel();
        statsPanel = new FlowLayoutPanel();
        
        //Main Panne
        var mainPanel = new TableLayoutPanel();
        mainPanel.Dock = DockStyle.Fill;
        mainPanel.ColumnCount = 2;
        mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        mainPanel.RowCount = 4;
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        
        //Controls conf
        //Search Box
        searchBox.Dock = DockStyle.Fill;
        searchBox.Font = new Font("Segoe UI", 12F);
        searchBox.ForeColor = Color.White;
        searchBox.BackColor = Color.FromArgb(50, 50, 50);
        searchBox.Margin = new Padding(5);
        
        //Search Butt
        searchButton.Dock = DockStyle.Right;
        searchButton.Text = "Buscar";
        searchButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        searchButton.Width = 100;
        searchButton.FlatStyle = FlatStyle.Flat;
        searchButton.Click += searchButton_Click;
        
        //Search Panne
        var searchPanel = new Panel();
        searchPanel.Dock = DockStyle.Fill;
        searchPanel.Controls.Add(searchBox);
        searchPanel.Controls.Add(searchButton);
        
        //PictureBox
        pictureBox.Dock = DockStyle.Fill;
        pictureBox.BackColor = Color.FromArgb(40, 40, 40);
        pictureBox.Padding = new Padding(10);
        
        //Panne info
        var infoPanel = new TableLayoutPanel();
        infoPanel.Dock = DockStyle.Fill;
        infoPanel.RowCount = 3;
        infoPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
        infoPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
        infoPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
        
        //Labels conf
        nameLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        nameLabel.AutoSize = true;
        
        heightLabel.Font = new Font("Segoe UI", 14F);
        heightLabel.AutoSize = true;
        
        weightLabel.Font = new Font("Segoe UI", 14F);
        weightLabel.AutoSize = true;
        
        infoPanel.Controls.Add(nameLabel, 0, 0);
        infoPanel.Controls.Add(heightLabel, 0, 1);
        infoPanel.Controls.Add(weightLabel, 0, 2);
        
        //Panne type
        typesPanel.Dock = DockStyle.Fill;
        typesPanel.BackColor = Color.FromArgb(40, 40, 40);
        typesPanel.Padding = new Padding(10);
        typesPanel.AutoScroll = true;
        
        //Stats Panne
        statsPanel.Dock = DockStyle.Fill;
        statsPanel.BackColor = Color.FromArgb(40, 40, 40);
        statsPanel.Padding = new Padding(10);
        statsPanel.AutoScroll = true;
        statsPanel.FlowDirection = FlowDirection.TopDown;
        
        //Add ctrls to MainPanne
        mainPanel.Controls.Add(searchPanel, 0, 0);
        mainPanel.SetColumnSpan(searchPanel, 2);
        
        mainPanel.Controls.Add(pictureBox, 0, 1);
        mainPanel.Controls.Add(infoPanel, 1, 1);
        mainPanel.Controls.Add(typesPanel, 0, 2);
        mainPanel.SetColumnSpan(typesPanel, 2);
        mainPanel.Controls.Add(statsPanel, 0, 3);
        mainPanel.SetColumnSpan(statsPanel, 2);
        
        this.Controls.Add(mainPanel);
        
        
        //Events
        this.searchBox.KeyDown += MainForm_Load;
        this.searchBox.TextChanged += searchBox_TextChanged;
        this.searchBox.LostFocus += (s, e) => HideSuggestions();
        this.searchBox.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Down && suggestionsListBox.Visible)
            {
                suggestionsListBox.Focus();
                if (suggestionsListBox.Items.Count > 0)
                    suggestionsListBox.SelectedIndex = 0;
            }
        };
    }

    #endregion
}