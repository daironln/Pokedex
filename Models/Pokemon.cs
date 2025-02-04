using Newtonsoft.Json;

namespace Pokedex.Models;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public SpriteData Sprites { get; set; }
    public TypeData[] Types { get; set; }
    public StatData[] Stats { get; set; }

    public class SpriteData
    {
        public OtherSprites Other { get; set; }
            
        public class OtherSprites
        {
            [JsonProperty("official-artwork")]
            public OfficialArtwork OfficialArtwork { get; set; }
        }

        public class OfficialArtwork
        {
            [JsonProperty("front_default")]
            public string FrontDefault { get; set; }
        }
    }

    public class TypeData
    {
        public TypeInfo Type { get; set; }
            
        public class TypeInfo
        {
            public string Name { get; set; }
        }
    }

    public class StatData
    {
        public int Base_Stat { get; set; }
        public StatInfo Stat { get; set; }
            
        public class StatInfo
        {
            public string Name { get; set; }
        }
    }
}