using SmallWorld.src.Interfaces;
using SmallWorld.src.Model.Habitat;
using SmallWorld.src.Model.Reino;
using SmallWorld.src.Model.MapModel;
using SmallWorld.src.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model.Interactuable
{
    public class Food : IInteractable, IPositionable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodId { get; set; }
        private string name;
        private List<IDiet> diet;
        private int energyValue;

        public string Name { get => name; set => name = value; }
        public List<IDiet> Diet { get => diet; set => diet = value; }
        public string DietNames { 
            get 
            {
                string dietListString = "";
                foreach(var d in diet)
                {
                    dietListString = string.Join(", ", diet);
                }
                return dietListString;
            } 
        }
        public int EnergyValue { get => energyValue; set => energyValue = value; }

        public Food(string name, List<IDiet> diet, int energyValue)
        {
            Name = name;
            Diet = diet;
            EnergyValue = energyValue;
            PositionableObjectRegistry.Register(this);
        }

        public Food()
        {
        }

        //TODO: sacar esto de acá, ya no lo uso
        public bool CanEat(Entity entity)
        {
            bool canEat = false;
            if (entity.Diet == Diet)
            {
                canEat = true;
            }
            return canEat;
        }

        public override string ToString()
        {
            return Name;
        }

        public string GetAllData()
        {
            return $"nombre: {Name}, dietas que acepta: {Diet}, valor energético: {EnergyValue}";
        }

        public List<IHabitat> HabitatsCompatible()
        {
            //este método se puede usar si pensamos que las comidas pueden tener un habitat
            //por ejemplo para no poner una manzana en el agua.
            List<IHabitat> habitats = new List<IHabitat>() { new Terrestrial(), new Aerial(), new Aquatic() };
            return habitats;
        }
    }
}
