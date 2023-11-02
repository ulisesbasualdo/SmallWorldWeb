using SmallWorld.src.Interfaces;
using SmallWorld.src.Model.Habitat;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model.Terreno
{
    internal class Earth : ITerrainType
    {
        private string name = "Tierra";
        private Color color = Color.Green;
        private List<IHabitat> habitatsSupported = new List<IHabitat>() { new Terrestrial(), new Aerial()};


        //TODO: no carga el crear entidad porque me parece que busca todos los ihabitat para añadirlos al clb
        public Color Color { get => color; set => color = value; }
        public List<IHabitat> getHabitatsSupported() { return habitatsSupported; }


        //private string ImageRute = $@"I:\itec3\disenio\SmallWorld-mio\SmallWorld\SmallWorld\Resources\EarthGreen.jpg";

        public override string ToString()
        {
            return name;
        }

        public Color getColor()
        {
            return Color;
        }
    }
}
