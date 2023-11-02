using SmallWorld.src.Controllers;
using SmallWorld.src.Interfaces;
using SmallWorld.src.Model.Interactable;
using SmallWorld.src.Model.Interactuable;
using SmallWorld.src.Model.MapModel;
using SmallWorld.src.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model
{
    public class Entity : IPositionable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntityId { get; set; }
        IKingdom kingdom;
        string name;
        IDiet diet;
        //IHabitat habitat;
        List<IHabitat> habitatList;

        int numPlayer;
        int maxEnergy;
        int currentEnergy;
        int maxLife;
        int currentLife;
        int attackPoints;
        int defensePoints;
        bool attackRange;
        int costToAttack;
        bool dieStatus;

        #region Properties
        //TODO: hacer validaciones en propiedades, informar de alguna manera si esta muerto y no puede recibir mas ataques, talvez borrandolo de la lista, o que la lista traiga solo los vivos. y los interacts se traigan los muertos para abono.



        internal IKingdom Kingdom
        {
            get => kingdom;
            set
            {
                if (value != null) kingdom = value;
                else throw new InvalidOperationException("Debe seleccionar un Reino");
            }
        }
        public string KingdomName { get { return kingdom.ToString(); } }
        public string Name
        {
            get => name;
            set
            {
                if (value != null) name = value;
                else throw new InvalidOperationException("Debe especificar un Nombre");
            }
        }

        internal IDiet Diet
        {
            get => diet;
            set
            {
                if (value != null) diet = value;
                else throw new InvalidOperationException("Debe especificar una Dieta");
            }
        }
        public string DietName { get { return diet.ToString(); } }
        /*internal IHabitat Habitat
        {
            get => habitat;
            set
            {
                if (value != null) habitat = value;
                else throw new InvalidOperationException("Debe seleccionar un Habitat");
            }
        }*/

        public string HabitatName 
        {
            get
            {
                string habitatListString = "";
                foreach (var h in habitatList)
                {
                    habitatListString = string.Join(", ", habitatList);
                }
                return habitatListString;
            }
        }
        public List<IHabitat> HabitatList
        {
            get => habitatList;
            set
            {
                if (value != null) habitatList = value;
                else throw new InvalidOperationException("Debe seleccionar al menos un Habitat");
            }
        }

        public int MaxEnergy
        {
            get => maxEnergy;
            set
            {
                if (value > 0) maxEnergy = value;
                else throw new InvalidOperationException("La energía máxima debe ser mayor a 0");
            }
        }
        public int MaxLife {
            get => maxLife;
            //get { return maxLife; }
            set
            {
                if (value > 0) maxLife = value;
                else throw new InvalidOperationException("La vida máxima debe ser mayor a 0");
            }
        }
        public int CurrentLife
        {
            get => currentLife;
            set
            {
                if (value <= 0)
                {
                    currentLife = 0;
                    DieStatus = true;
                    throw new Exception("Está muerto");
                }
                else if (value > MaxLife)
                {
                    currentLife = MaxLife;
                }
                else
                {
                    currentLife = value;
                }
            }
        }

        public int AttackPoints { get => attackPoints; set => attackPoints = value; }
        public int DefensePoints { get => defensePoints; set => defensePoints = value; }
        public bool AttackRange { get => attackRange; set => attackRange = value; }
        public int CurrentEnergy
        {
            get => currentEnergy;
            set
            {
                if (value < 0)
                {
                    currentEnergy = 0;
                }
                else if (value > MaxEnergy)
                {
                    currentEnergy = MaxEnergy;
                }
                else
                {
                    currentEnergy = value;
                }
            }
        }
        public bool DieStatus { get => dieStatus; set => dieStatus = value; }
        public int CostToAttack { get => costToAttack; set => costToAttack = value; }
        public int NumPlayer { get => numPlayer; set => numPlayer = value; }

        #endregion

        //constructor
        public Entity(IKingdom kingdom, string name, IDiet diet, List<IHabitat> habitatList, int attackPoints, int defensePoints, bool attackRange, int maxLife, int maxEnergy)
        {
            Kingdom = kingdom;
            Name = name;
            Diet = diet;
            HabitatList = habitatList;
            AttackPoints = attackPoints;
            DefensePoints = defensePoints;
            AttackRange = attackRange;
            MaxLife = maxLife;
            CurrentLife = maxLife;
            MaxEnergy = maxEnergy;
            CurrentEnergy = maxEnergy;
            CostToAttack = 30;
            PositionableObjectRegistry.Register(this);
            //CurrentTerrain = currentTerrain;
            //Position = position;
        }
        public Entity() { }

        

        public void Feed()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void RangeAttack()
        {
            throw new NotImplementedException();
        }

        public void Rest()
        {
            CurrentEnergy += 50;
            CurrentLife += 100;
        }

        public void TrowAtomicBomb()
        {
            EntityController.GetInstance().KillAllAndSaveMe(this);
        }

        


        

        public void Eat (Food food)
        {
            if (food.CanEat(this))
            {
                this.CurrentEnergy += food.EnergyValue;
            }
            else throw new Exception($"no es compatible con la dieta. {food.Name} {food.Diet} != {Name} {Diet}");
        }
        public void Interact (Item objectInteractable)
        {
            //CurrentLife = CurrentLife + objectInteractable.Points;
        }


        /*public void Move(Terrain DestinyTerrain)
        {
            //TODO: validacion de si el habitat coincide con el terreno
            CurrentTerrain = DestinyTerrain;
        }*/

        /*
        public void VerifyMaxLife()
        {
            if(CurrentLife > MaxLife)
            {
                CurrentLife = MaxLife;
            }
        }*/

        public void VerifyMinCurrentLife()
        {
            if (CurrentLife <= 0)
            {
                CurrentLife = 0;
                Die();
            }
        }

        public void VerifyMaxEnergy()
        {
            if (CurrentEnergy > MaxEnergy)
            {
                CurrentEnergy = MaxEnergy;
            }
        }

        /*esto lo hacía antes de validar en las propiedades, se puede borrar
        public void VerifyMinCurrentEnergy() 
        {
            if (CurrentEnergy <= 0)
            {
                CurrentEnergy = 0;
                MessageBox.Show($"{name} tiene energía 0, debe dormir para recuperar energía");
            }
        }*/
        public void Die()
        {
            DieStatus = true;
        }

        public bool NeedEnergyToDoAnAction(int Action)
        {
            bool needEnergy = false;
            if (Action > CurrentEnergy)
            {
                needEnergy = true;
                throw new Exception($"{Name}necesita descansar y así recuperar energía antes de hacer esta acción");
            }
            return needEnergy;
        }


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return $"{name} - {HabitatName}";
        }
        public string getAllData()
        {
            return $"Nombre:{Name}, Reino:{Kingdom}, Dieta:{Diet}, Habitats:{HabitatList}, Energía actual:{CurrentEnergy}, Energía Máxima:{MaxEnergy}, Vida Actual:{CurrentLife}, Vida Máxima:{MaxLife}, Puntos de Ataque:{AttackPoints}, Puntos de Defensa:{DefensePoints}, acepta ataque a distancia:{AttackRange}";
        }

        public List<IHabitat> HabitatsCompatible()
        {
           return HabitatList;
        }
    }
}
