using System.Windows.Forms;

namespace Pokedex.Controls;

public partial class StatControl : UserControl
{
    public StatControl(string statName, int value)
    {
        InitializeComponent();
        CreateControls(statName, value);
    }

    private void CreateControls(string statName, int value)
    {
        this.Size = new Size(250, 30);
        this.BackColor = Color.Transparent;

        var container = new Panel();
        container.Dock = DockStyle.Fill;
        container.Padding = new Padding(0, 5, 0, 5);

        var nameLabel = new Label();
        nameLabel.Text = statName.ToUpper();
        nameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        nameLabel.ForeColor = Color.White;
        nameLabel.AutoSize = false;
        nameLabel.Size = new Size(100, 20);

        nameLabel.TextAlign = ContentAlignment.MiddleLeft;

        var progressBar = new Panel();
        progressBar.BackColor = Color.FromArgb(70, 70, 70);
        progressBar.Size = new Size(120, 20);
        progressBar.Location = new Point(130, 0);

        var fillBar = new Panel();
        fillBar.BackColor = Color.FromArgb(0, 150, 255);
        fillBar.Size = new Size((int)(value / 255.0 * 120), 20);
        fillBar.Dock = DockStyle.Left;
        
        Console.WriteLine(value.ToString());

        // var valueLabel = new Label();
        // valueLabel.Text = value.ToString();
        // valueLabel.Font = new Font("Segoe UI", 10F);
        // valueLabel.ForeColor = Color.White;
        // valueLabel.AutoSize = false;
        // valueLabel.Size = new Size(30, 20);
        // valueLabel.TextAlign = ContentAlignment.MiddleRight;
        // valueLabel.Location = new Point(100, 0);

        // progressBar.Controls.Add(valueLabel);
        progressBar.Controls.Add(fillBar);
        container.Controls.Add(nameLabel);
        container.Controls.Add(progressBar);
        // container.Controls.Add(valueLabel);
        this.Controls.Add(container);
    }
}