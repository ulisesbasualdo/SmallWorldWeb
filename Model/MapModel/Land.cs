using SmallWorld.src.Interfaces;
using SmallWorld.src.Model.Interactuable;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model.MapModel
{
    public class Land
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LandId { get; set; }
        [NotMapped]
        private ITerrainType terrainType;
        private List<Land> borderingLands = new List<Land>();
        private List<IPositionable> positionables;
        private List<Item> items = new List<Item>();
        private List<Food> foods = new List<Food>();
        private List<Entity> entities = new List<Entity>();
        private List<Entity> p1entities = new List<Entity>();
        private List<Entity> p2entities = new List<Entity>();
        [ForeignKey("MapId")]
        public virtual Map map { get; set; }

        #region Properties
        [NotMapped]
        public ITerrainType TerrainType { get => terrainType; set => terrainType = value; }
        public string TerrainTypeName { get => terrainType.ToString(); }
        internal List<Land> BorderingLands { get => borderingLands; set => borderingLands = value; }
        internal List<IPositionable> Positionables { get => positionables; set => positionables = value; }
        public string BorderingLandsIds
        {
            get
            {
                string borderingLandsIds = "";
                foreach (var b in BorderingLands)
                {
                    borderingLandsIds = string.Join(", ", BorderingLands);
                }
                return borderingLandsIds;
            }
        }
        public List<Item> Items { get => items; set => items = value; }
        public List<Food> Foods { get => foods; set => foods = value; }
        public List<Entity> P1entities { get => p1entities; set => p1entities = value; }
        public List<Entity> P2entities { get => p2entities; set => p2entities = value; }
        public List<Entity> Entities { get => entities; set => entities = value; }

        #endregion

        public Land(ITerrainType terrainType)
        {
            TerrainType = terrainType;
            Positionables = new List<IPositionable>();
        }
        public Land() { }
        public override string ToString()
        {
            return $"Id: {LandId} , tipo: {TerrainType}";
        }
    }
}
