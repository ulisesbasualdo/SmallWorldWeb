using Newtonsoft.Json.Linq;
using SmallWorld.src.Interfaces;
using SmallWorld.src.Model;
using SmallWorld.src.Model.Dieta;
using SmallWorld.src.Model.Interactable;
using SmallWorld.src.Model.Interactuable;
using SmallWorld.src.Model.Reino;
using SmallWorld.src.Static;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmallWorld.src.Controllers
{
    internal class EntityController
    {
        private static EntityController instance;
        private readonly List<Entity> Entities = new List<Entity>();
        private readonly List<Entity> p1Entities = new List<Entity>();
        private readonly List<Entity> p2Entities = new List<Entity>();
        Random random = new Random();

        private EntityController() { }

        public static EntityController GetInstance()
        {
            if (instance == null)
            {
                instance = new EntityController();
            }
            return instance;
        }

        public void AddEntity(IKingdom kingdom, string name, IDiet diet, List<IHabitat> habitatList, int atkPonints, int defPoints, bool range, int maxLife, int maxEnergy)
        {
            Entity EntityToAdd = new Entity(kingdom, name, diet, habitatList, atkPonints, defPoints, range, maxLife, maxEnergy);
            Entities.Add(EntityToAdd);
        }

        public async Task AddRandomsEntitiesAsync(int numP1, int numP2)
        {
            List<string> randomNames = await RandomNames(numP1 + numP2);
            for (int i = 0; i < numP1; i++)
            {
                p1Entities.Add(new Entity(InterfacesImplementations.GetRandomKingdom(), 
                    randomNames[i], InterfacesImplementations.GetRandomDiet(),
                    InterfacesImplementations.GetRandomHabitatList(), random.Next(1, 100),
                    random.Next(1, 100), random.Next(2) == 0, 100, 100));
            }
            for (int i = 0; i < numP2; i++)
            {
                p2Entities.Add(new Entity(InterfacesImplementations.GetRandomKingdom(),
                    randomNames[numP1 + i], InterfacesImplementations.GetRandomDiet(),
                    InterfacesImplementations.GetRandomHabitatList(), random.Next(1, 100),
                    random.Next(1, 100), random.Next(2) == 0, 100, 100));
            }
        }
        public async Task AddRandomsEntitiesAsync(Dictionary<int, int> playerEntityCounts)
        {
            List<string> randomNames = await RandomNames(playerEntityCounts.Values.Sum());
            

            foreach (var kvp in playerEntityCounts)
            {
                int player = kvp.Key;
                int entityCount = kvp.Value;

                for (int i = 0; i < entityCount; i++)
                {
                    Entity entity = new Entity(
                        InterfacesImplementations.GetRandomKingdom(),
                        randomNames[i],
                        InterfacesImplementations.GetRandomDiet(),
                        InterfacesImplementations.GetRandomHabitatList(),
                        random.Next(1, 100),
                        random.Next(1, 100),
                        random.Next(2) == 0,
                        100,
                        100);

                    entity.NumPlayer = player; 
                    Entities.Add(entity);
                }
            }
        }


        public int CountEntitiesPerPlayer(int numPlayer)
        {
            return Entities.Count(e => e.NumPlayer == numPlayer && e.DieStatus == false);
        }
        public List<Entity> getEntitiesP2()
        {
            return p2Entities;
        }
        public List<Entity> getEntities()
        {
            return Entities;
        }
        public List<Entity> getEntitiesCopy1()
        {
            List<Entity> ListForComboBox1 = new List<Entity>(Entities);
            return ListForComboBox1;
        }
        public List<Entity> getEntitiesCopy2()
        {
            List<Entity> ListForComboBox2 = new List<Entity>(Entities);
            return ListForComboBox2;
        }



        public void Delete(Entity entity)
        {
            Entities.Remove(entity);
        }


        /*
        public void Update(int id, IKingdom kingdom, string name, IDiet diet, IHabitat habitat, int atkPoints, int defPoints, bool rangeAttack, int maxLife, int maxEnergy, int defenseShield)
        {
            foreach (Entity EntityToUpdate in Entities)
            {
                if (EntityToUpdate.Id == id)
                {
                    EntityToUpdate.Kingdom = kingdom;
                    EntityToUpdate.Name = name;
                    EntityToUpdate.Diet = diet;
                    EntityToUpdate.Habitat = habitat;
                    EntityToUpdate.AttackPoints = atkPoints;
                    EntityToUpdate.DefensePoints = defPoints;
                    EntityToUpdate.AttackRange = rangeAttack;
                    EntityToUpdate.MaxLife = maxLife;
                    EntityToUpdate.MaxEnergy = maxEnergy;
                    EntityToUpdate.DefenseShield = defenseShield;
                    break;
                }
            }
        }*/

        public void Update(Entity entityToModify, Entity entityModified)
        {

            int index = Entities.FindIndex(e => e == entityToModify);

            if (index != -1)
            {
                Entities[index] = entityModified;

            }
        }
        public Entity FindEntityP1(int id)
        {
            return p1Entities.Find(e => e.EntityId == id);
        }
        public Entity FindEntityP2(int id)
        {
            return p2Entities.Find(e => e.EntityId == id);
        }

        public Entity FindEntity(int id)
        {
            return Entities.Find(e => e.EntityId == id);
        }
        public void Eat(Entity entity, Food food)
        {
            if (food.Diet.Contains(entity.Diet))
            {
                entity.CurrentEnergy += food.EnergyValue;
            }
            else throw new Exception($"no es compatible con la dieta.");
        }

        public async Task<string> RandomName()
        {
            string apiRandomsNamesUrl = "https://randomuser.me/api/?nat=es";
            string randomName = "";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiRandomsNamesUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var data = JObject.Parse(content);

                        // Accede al campo "results" y obtén el primer nombre
                        randomName = data["results"][0]["name"]["first"].ToString();
                    }
                    else throw new Exception("Error al realizar la solicitud HTTP. Código de estado: " + response.StatusCode);
                    
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Error al realizar la solicitud HTTP: " + e.Message);
                }
            }
            return randomName;
        }

        public async Task<List<string>> RandomNames(int numberOfNames)
        {
            string apiRandomsNamesUrl = "https://randomuser.me/api/?nat=es&results=" + numberOfNames;
            List<string> randomNames = new List<string>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiRandomsNamesUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var data = JObject.Parse(content);

                        var results = data["results"];
                        foreach (var result in results)
                        {
                            string firstName = result["name"]["first"].ToString();
                            randomNames.Add(firstName);
                        }
                    }
                    else throw new Exception("Error al realizar la solicitud\n HTTP. Código de estado: " + response.StatusCode);

                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Error al realizar la solicitud HTTP: " + e.Message);
                }
            }
            return randomNames;
        }
        public void Rest(Entity entity)
        {
            entity.CurrentEnergy += 50;
            entity.CurrentLife += 100;
        }

        #region AttackLogic
        public void Attack(Entity AttackingEntity, Entity EntityToAttack)
        {
            if (!NeedEnergyToDoAnAction(AttackingEntity, AttackingEntity.CostToAttack))
            {
                AttackingEntity.CurrentEnergy -= AttackingEntity.CostToAttack;
                int DicePoints = Dice.TrowDice(6);

                int AttackResult = TakeDamage(AttackingEntity.AttackPoints, DicePoints, EntityToAttack);
                if (AttackResult > 0)
                {
                    AttackingEntity.CurrentLife -= AttackResult;
                    throw new Exception("Ganó la defensa, \nse te quitaron puntos de vida.");
                }

            }
        }

        public int TakeDamage(int AttackPointsOfTheAttackingEntity, int AttackDicePoints, Entity EntityThatReceivesDamage)
        {
            int DicePoints2 = Dice.TrowDice(6);
            Console.WriteLine($"Dado atacante: {AttackDicePoints} Dado Victima: {DicePoints2}");
            //MessageBox.Show($"Dado atacante: {AttackDicePoints} Dado Victima: {DicePoints2}");

            int AttackResult = EntityThatReceivesDamage.CurrentLife + ((EntityThatReceivesDamage.DefensePoints + DicePoints2) - (AttackPointsOfTheAttackingEntity + AttackDicePoints));

            if (AttackResult < EntityThatReceivesDamage.CurrentLife)
            {
                EntityThatReceivesDamage.CurrentLife = AttackResult;
                AttackResult = 0;
                throw new Exception("Ataque exitoso");
            }
            else if (AttackResult > EntityThatReceivesDamage.CurrentLife)
            {
                AttackResult -= EntityThatReceivesDamage.CurrentLife;
            }
            else if (AttackResult == EntityThatReceivesDamage.CurrentLife)
            {
                AttackResult = 0;
                throw new Exception("Hay un empate");
            }
            return AttackResult;
        }
        #endregion

        public void Die(Entity entity)
        {
            entity.DieStatus = true;
        }

        public bool NeedEnergyToDoAnAction(Entity entity, int Action)
        {
            bool needEnergy = false;
            if (Action > entity.CurrentEnergy)
            {
                needEnergy = true;
                throw new Exception($"{entity.Name} Necesita descansar y \nasí recuperar energía antes \nde hacer esta acción");
            }
            return needEnergy;
        }
        public void KillAllAndSaveMe(Entity entity)
        {
            foreach(Entity e in Entities)
            {
                if (!e.Equals(entity))
                {
                    e.DieStatus = true;
                }
            }
        }
    }
}




