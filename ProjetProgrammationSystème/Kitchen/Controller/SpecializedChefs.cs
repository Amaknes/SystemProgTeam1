using Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    public class SpecializedChefs : SpecializedChefsInterface
    {

        private List<Tasks> _ListTask;
        public List<Tasks> ListTask { get => this._ListTask; set => this._ListTask = value; }
        

        private CommisChefInterface _CommisChefs;
        public CommisChefInterface CommisChefs { get => this._CommisChefs; set => this._CommisChefs = value; }
        
        public SpecializedChefsInterface Strategy { get; set; }

        private CLprocessus _process;
        public CLprocessus process
        {
            get => this._process;
            set => this._process = value;
        }

        public static Semaphore semFour;
        public static Semaphore semFeux;
        public static Semaphore semMixeur;
        public static Semaphore semCouper;
        public static Semaphore semMelange;
        public static Semaphore semRaper;




        public SpecializedChefs()
        {
            this.ListTask = new List<Tasks>();
            this.CommisChefs = new CommisChef(0);
            this.process = new CLprocessus();

            if(semCouper == null)
            {
                semCouper = new Semaphore(5, 5);
                semFeux = new Semaphore(5, 5);
                semMixeur = new Semaphore(1, 1);
                semFour = new Semaphore(1, 1);
                semRaper = new Semaphore(2, 2);
                semMelange = new Semaphore(5, 5);
            }

        }



        //ordres : 1.Couper   2.Cuire(plaques)   3.Mélanger     4.Cuire (Four)    2.Fondre    6.Préparation    7.Mixer     8.Raper

        
        public void UseCut(int time)
        {
            semCouper.WaitOne();
            Thread.Sleep(time * 1000);
            semCouper.Release();
        }

        public void UseHotPlate(int time)
        {
            semFeux.WaitOne();
            Thread.Sleep(time * 1000);
            semFeux.Release();
        }

        public void UseBlend(int time)
        {
            semMelange.WaitOne();
            Thread.Sleep(time * 1000);
            semMelange.Release();
        }

        public void UseMixer(int time)
        {
            semMixeur.WaitOne();
            Thread.Sleep(time * 1000);
            semMixeur.Release();
        }

        public void UseRaper(int time)
        {
            semRaper.WaitOne();
            Thread.Sleep(time * 1000);
            semRaper.Release();
        }
        
        public void UseOven(int time)
        {
            semFour.WaitOne();
            Thread.Sleep(time * 1000);
            semFour.Release();
        }


        public void Preparation(int time)
        {
            Thread.Sleep(time * 1000);
        }



        public void GiveOrders(string NameIngredient, int TypeIngredient, Tasks firstTask, int idTable)
        {
            this.CommisChefs.SearchIngredients(NameIngredient, TypeIngredient, firstTask.NbSameDish);

            int i = 0;
            bool currentDish = false;
            bool endDish = false;
            int currentStep = 0;

            while (i < this.ListTask.Count && !endDish)
            {
                if (this.ListTask[i].OrderStep == currentStep)
                {
                    currentDish = true;
                    string nomEtape = this.ListTask[i].NameTask;
                    int tempsEtape = this.ListTask[i].TimeTask;

                    //ordres : 1.Couper   2.Cuire(plaques)   3.Mélanger     4.Cuire (Four)    2.Fondre    6.Préparation    7.Mixer     8.Raper
                    switch (nomEtape)
                    {
                        case "Couper":
                            UseCut(tempsEtape);
                            break;
                        case "Cuire":
                            UseHotPlate(tempsEtape);
                            break;
                        case "Fondre":
                            UseHotPlate(tempsEtape);
                            break;
                        case "Mélanger":
                            UseBlend(tempsEtape);
                            break;
                        case "Préparation":
                            Preparation(tempsEtape);
                            break;
                        case "Four":
                            UseOven(tempsEtape);
                            break;
                        case "Raper":
                            UseRaper(tempsEtape);
                            break;
                        case "Mixer":
                            UseMixer(tempsEtape);
                            break;
                        default:
                            break;
                    }

                    this.ListTask.RemoveAt(i);
                    currentStep += 1;
                }
                else if (this.ListTask[i].OrderStep != currentStep && currentStep != 0)
                {
                    endDish = true;
                }

                if (!currentDish)
                {
                    i++;
                }
            }

            //envoi l'id de la table : l'id de la préparation : si c est un entree/plat/dessert : nombre de plats de ce type dans la commande
            CommisChefs.SendDishes(idTable, firstTask.IdDish, firstTask.Dish, firstTask.NbDishesList);
        }

        public void takeOrders(Tasks newTask, int idTable)
        {
            this.ListTask.Add(newTask);

            if (newTask.OrderStep == 0)
            {
                DataSet setData = process.GetLieuxIngredients("ProjetProgSystem", newTask.IdDish);

                foreach (DataRow dr in setData.Tables[0].Rows)
                {
                    string NameIngredient = dr["NameIngredient"].ToString();
                    int TypeIngredient = Int32.Parse(dr["TypeIngredient"].ToString());


                    //ordres : 1.Couper   2.Cuire   3.Mélanger     4.Cuire (Four)    5.Fondre    6.Préparation    7.Cuire(plaques)  8.Mixer     9.Raper
                    Thread threadSpeChefOrder = new Thread(() => GiveOrders(NameIngredient, TypeIngredient, newTask, idTable));
                    threadSpeChefOrder.Start();
                } 
            }
        }
    }
}
