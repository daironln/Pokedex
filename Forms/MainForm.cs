using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using Pokedex.Models;
using Pokedex.Controls;

namespace Pokedex.Forms;


public partial class MainForm : Form
{
        
        
    private TextBox searchBox;
    private Button searchButton;
    private Label nameLabel;
    private Label heightLabel;
    private Label weightLabel;
    private PictureBox pictureBox;
    private FlowLayoutPanel typesPanel;
    private FlowLayoutPanel statsPanel;
        
        
    private HttpClient client = new HttpClient();
    private string apiUrl = "https://pokeapi.co/api/v2/pokemon/";

    public MainForm()
    {
        InitializeComponent();
        ConfigureStyles();

        this.searchBox.KeyDown += MainForm_Load;
    }
        
    private void MainForm_Load(object sender, KeyEventArgs e)
    { 
        if (e.KeyCode == Keys.Enter)
        {
            searchButton.PerformClick();
        }
    }

    private void ConfigureStyles()
    { 
        this.BackColor = Color.FromArgb(30, 30, 30);
        this.ForeColor = Color.White;
            
        searchBox.BackColor = Color.FromArgb(50, 50, 50);
        searchButton.BackColor = Color.FromArgb(70, 70, 70);
        searchButton.FlatStyle = FlatStyle.Flat;
        
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
    }

    private async void searchButton_Click(object sender, EventArgs e)
    {
        string searchTerm = searchBox.Text.ToLower().Trim();
        if (string.IsNullOrEmpty(searchTerm)) return;

        try
        {
            var response = await client.GetAsync($"{apiUrl}{searchTerm}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var pokemon = JsonConvert.DeserializeObject<Pokemon>(json);
                UpdatePokemonDisplay(pokemon);
            }
            else
            {
                MessageBox.Show("Pokémon no encontrado");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }

    private void UpdatePokemonDisplay(Pokemon pokemon)
    {
        //Info
        nameLabel.Text = $"{pokemon.Name.ToUpper()} # {pokemon.Id}";
        heightLabel.Text = $"Altura: {pokemon.Height / 10.0}m";
        weightLabel.Text = $"Peso: {pokemon.Weight / 10.0}kg";

        //Typ
        typesPanel.Controls.Clear();
        foreach (var type in pokemon.Types)
        {
            var typeLabel = new Label
            {
                Text = type.Type.Name.ToUpper(),
                BackColor = GetTypeColor(type.Type.Name),
                ForeColor = Color.White,
                Margin = new Padding(3),
                Padding = new Padding(5, 3, 5, 3),
                AutoSize = true
            };
            typesPanel.Controls.Add(typeLabel);
        }

        //Img
        var spriteUrl = pokemon.Sprites.Other.OfficialArtwork.FrontDefault;
        pictureBox.Image = DownloadImage(spriteUrl);

        //Starts
        statsPanel.Controls.Clear();
        foreach (var stat in pokemon.Stats)
        {
            var statControl = new StatControl(stat.Stat.Name, stat.Base_Stat);
            statsPanel.Controls.Add(statControl);
        }
    }

    private Color GetTypeColor(string type)
    {
        return type.ToLower() switch
        {
            "fire" => Color.FromArgb(238, 129, 48),
            "water" => Color.FromArgb(99, 144, 240),
            "grass" => Color.FromArgb(122, 199, 76),
            "electric" => Color.FromArgb(247, 208, 44),
            "psychic" => Color.FromArgb(249, 85, 135),
            "ice" => Color.FromArgb(150, 217, 214),
            "dragon" => Color.FromArgb(111, 53, 252),
            "dark" => Color.FromArgb(112, 88, 72),
            "fairy" => Color.FromArgb(238, 153, 172),
            "normal" => Color.FromArgb(168, 168, 120),
            "fighting" => Color.FromArgb(194, 46, 40),
            "flying" => Color.FromArgb(169, 143, 243),
            "poison" => Color.FromArgb(163, 62, 161),
            "ground" => Color.FromArgb(226, 191, 101),
            "rock" => Color.FromArgb(182, 161, 54),
            "bug" => Color.FromArgb(166, 185, 26),
            "ghost" => Color.FromArgb(115, 87, 151),
            "steel" => Color.FromArgb(183, 183, 206),
            _ => Color.Gray
        };
    }

    private Image DownloadImage(string url)
    {
        using (var response = client.GetAsync(url).Result)
        {
            using (var stream = response.Content.ReadAsStreamAsync().Result)
            {
                return Image.FromStream(stream);
            } 
        }
    }
}