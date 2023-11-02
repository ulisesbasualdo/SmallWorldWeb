using SmallWorld.src.Interfaces;
using SmallWorld.src.Model;
using SmallWorld.src.Model.Interactuable;
using SmallWorld.src.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Controllers
{
    internal class FoodController
    {
        Random random = new Random();
        private static FoodController instance;
        private readonly List<Food> Foods = new List<Food>();
        private FoodController() { }

        public static FoodController GetInstance()
        {
            if (instance == null)
            {
                instance = new FoodController();
            }
            return instance;
        }


        public void AddFood(string name, List<IDiet> diet, int energyValue)
        {
            Food FoodToAdd = new Food(name,diet,energyValue);
            Foods.Add(FoodToAdd);
        }

        public void AddRandomFoods(int num)
        {
            for(int i = 0; i < num; i++)
            {
                Foods.Add(new Food($"Alimento {i + 1}", InterfacesImplementations.GetRandomDietList(), random.Next(20, 100)));
            }
        }

        public List<Food> getFoods()
        {
            return Foods;
        }




        public void Delete(Food food)
        {
            Foods.Remove(food);
        }



        public void Update(int id, string name, List<IDiet> diet, int energyValue)
        {
            foreach (Food FoodToUpdate in Foods)
            {
                if (FoodToUpdate.FoodId == id)
                {
                    FoodToUpdate.Name = name;
                    FoodToUpdate.Diet = diet;
                    FoodToUpdate.EnergyValue = energyValue;
                    break;
                }
            }
        }
        public void Update(Food foodToModify, Food foodModified)
        {

            int index = Foods.FindIndex(e => e == foodToModify);

            if (index != -1)
            {
                Foods[index] = foodModified;

            }
        }
        public Food FindFood(int id)
        {
            return Foods.Find(f => f.FoodId == id);
        }

    }
}
