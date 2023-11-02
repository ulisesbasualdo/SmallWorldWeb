using SmallWorld.src.Interfaces;
using SmallWorld.src.Model;
using SmallWorld.src.Model.Interactable.ItemEffects;
using SmallWorld.src.Model.Interactuable;
using SmallWorld.src.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Controllers
{
    internal class ItemController
    {
        Random random = new Random();
        private static ItemController instance;
        private readonly List<Item> Items = new List<Item>(); //TODO: terminar esto para que no haya buenos o malos
        private static List<IEffectStrategy> EffectsAvailables = new List<IEffectStrategy>(){
            new FillCurrentLife(), new GodMode(), new MaxAttackPoints(), /* MysteriousItem()*/ new AtomicBombLauncher()
        };
        private ItemController() { }

        public static ItemController GetInstance()
        {
            if (instance == null)
            {
                instance = new ItemController();
            }
            return instance;
        }


        public void AddItem(List<IEffectStrategy> effectStrategies, string name)
        {
            Item ItemToAdd = new Item(effectStrategies, name);
            Items.Add(ItemToAdd);
        }

        public void AddRandomItems(int num)
        {
            //int totalGoodItems = random.Next(1, num);

            for (int i = 0; i < num; i++)
            {
                Items.Add(new Item(getOneRandomEffectInList(), $"item n {i+1}"));
            }

            /*for (int i = 0; i < totalGoodItems; i++)
            {
                Items.Add(new Item(InterfacesImplementations.GetGoodRandomEffects(), $"item n{i + 1}"));
            }
            for (int i = totalGoodItems; i < totalGoodItems - num; i++)
            {
                Items.Add(new Item(InterfacesImplementations.GetBadRandomEffects(), $"item n{i + 1}"));
            }*/
        }


        public List<Item> getItems()
        {
            return Items;
        }
        



        public void Delete(Item item)
        {
            Items.Remove(item);
        }



        public void Update(int id, IEffectStrategy effecStrategy)
        {/*
            foreach (Item ItemToUpdate in Items)
            {
                if (ItemToUpdate.Id == id)
                {
                    ItemToUpdate.EffectStrategy = effecStrategy;
                    break;
                }
            }*/
        }

        public void Update(Item itemToModify, Item itemModified)
        {

            int index = Items.FindIndex(e => e == itemToModify);

            if (index != -1)
            {
                Items[index] = itemModified;

            }
        }
        public Item FindItem(int id)
        {
            return Items.Find(i => i.ItemId == id);
        }

        public List<IEffectStrategy> getRandomEffectList()
        {
            int maxCount = EffectsAvailables.Count;
            int count = random.Next(1, maxCount + 1);
            List<IEffectStrategy> shuffledEffects = EffectsAvailables.OrderBy(x => random.Next()).ToList();
            List<IEffectStrategy> randomEffectsList = shuffledEffects.Take(count).ToList();
            return randomEffectsList;
        }

        public List<IEffectStrategy> getOneRandomEffectInList()
        {
            int maxCount = EffectsAvailables.Count;
            int count = random.Next(0, maxCount);
            List<IEffectStrategy> randomEffectsList = new List<IEffectStrategy>() { EffectsAvailables[count] };
            return randomEffectsList;
        }

        public IEffectStrategy getRandomEffect()
        {
            int maxCount = EffectsAvailables.Count;
            int count = random.Next(0, maxCount);
            return EffectsAvailables[count];
        }
    }
}
