using SmallWorld.src.Interfaces;
using SmallWorld.src.Model.Habitat;
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
    //TODO: Importante hacer que una entidad utilize un item. Un item lo usas o lo dejas, debe haber un crud de items, puede tocar un item negativo, que sea malo. El item puede sumar ataque, vida, etc. Patron strategy para agregar otro objeto que determina a que se lo da.
    public class Item : IInteractable
    {
        //podria haber un item que te agregue valores por este turno, permanentemente o por un ataque
        //un item se agarra y se activa. requiere energía. no se va a saber que hace cada item.
        //item implementa un reino, es decir no todos los items pueden ser usados por todos los reinos. Esto falta implementar

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        private string name;
        [NotMapped]
        IEffectStrategy effectStrategy;
        [NotMapped]
        List<IEffectStrategy> effectStrategies;

        //properties
        public string Name { get => name; set => name = value; }
        [NotMapped]
        internal List<IEffectStrategy> EffectStrategies { get => effectStrategies; set => effectStrategies = value; }

        public string StrategyNames
        {
            get
            {
                string effectsListString = "";
                foreach (var e in effectStrategies)
                {
                    effectsListString = string.Join(", ", effectStrategies);
                }
                return effectsListString;
            }
        }
        [NotMapped]
        public IEffectStrategy EffectStrategy { get => effectStrategy; set => effectStrategy = value; }
        public Item(List<IEffectStrategy> effectStrategies, string name)
        {
            EffectStrategies = effectStrategies;
            Name = name;
        }
        public Item(IEffectStrategy effecStrategy, string name)
        {
            EffectStrategy = effectStrategy;
            Name = name;
        }
        

        public Item() { }

        public void ExecuteEffectStrategy(Entity entity)
        {
            foreach(var e in EffectStrategies)
            {
                e.Effect(entity);
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public string GetAllData()
        {
            return $"nombre: {name}, efectos: {effectStrategies}";
        }

        public List<IHabitat> HabitatsCompatible()
        {
            List<IHabitat> habitats = new List<IHabitat>() { new Terrestrial(), new Aerial(), new Aquatic() };
            return habitats;
        }
    }
}
