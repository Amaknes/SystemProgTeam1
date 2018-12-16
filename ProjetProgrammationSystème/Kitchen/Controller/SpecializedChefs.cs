using Kitchen.Model;
using Salle.View;
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
    public abstract class SpecializedChefs : SpecializedChefsInterface
    {
        Affichage afficher;
        private List<Tasks> _ListTask;
        public List<Tasks> ListTask { get => this._ListTask; set => this._ListTask = value; }

        private static Semaphore _sem;

        private CommisChefInterface _CommisChefs;
        public CommisChefInterface CommisChefs { get => this._CommisChefs; set => this._CommisChefs = value; }

        public SpecializedChefsInterface Strategy { get; set; }

        private CLprocessus _process;
        public CLprocessus process
        {
            get => this._process;
            set => this._process = value;
        }





        public SpecializedChefs()
        {
            this.ListTask = new List<Tasks>();
            this.CommisChefs = new CommisChef(0);
            this.process = new CLprocessus();
            this.afficher = new Affichage();
            _sem = new Semaphore(1, 1);
        }



        //ordres : 1.Couper   2.Cuire(plaques)   3.Mélanger     4.Cuire (Four)    2.Fondre    6.Préparation    7.Mixer     8.Raper


        public void UseCut(int time)
        {
            afficher.afficherLine("The " + Type() + " is cutting ingredients");
            Thread.Sleep(time * 1000);
        }

        public void UseHotPlate(int time)
        {
            afficher.afficherLine("The " + Type() + " is cooking ingredients");
            Thread.Sleep(time * 1000);
        }

        public void UseBlend(int time)
        {
            afficher.afficherLine("The " + Type() + " is blending ingredients");
            Thread.Sleep(time * 1000);
        }

        public void UseMixer(int time)
        {
            afficher.afficherLine("The " + Type() + " is mixing ingredients");
            Thread.Sleep(time * 1000);
        }

        public void UseRaper(int time)
        {
            afficher.afficherLine("The " + Type() + " is grating ingredients");
            Thread.Sleep(time * 1000);
        }

        public void UseOven(int time)
        {
            afficher.afficherLine("The " + Type() + " is baking ingredients");
            Thread.Sleep(time * 1000);
        }

        public void UseFriteuse(int time)
        {
            afficher.afficherLine("The " + Type() + " is frying french fries");
            Thread.Sleep(time * 1000);
        }

        public void Preparation(int time)
        {
            afficher.afficherLine("The " + Type() + " is preparing ingredients");
            Thread.Sleep(time * 1000);
        }


        public abstract string Type();


        public void GiveOrders(object firstTask)
        {
            new Pause().AddThread(Thread.CurrentThread);
            Tasks TaskNew = (Tasks)firstTask;

            int i = 0;

            bool endDish = false;
            bool taskFound = false;

            string nomEtape = null;
            int tempsEtape = 0;

            while (!endDish)
            {

                _sem.WaitOne();

                while (i < this.ListTask.Count && !taskFound)
                {
                    if (this.ListTask[i].OrderStep == TaskNew.OrderStep && this.ListTask[i].IdDish == TaskNew.IdDish)
                    {
                        taskFound = true;
                    }
                    else
                    {
                        i++;
                    }
                }

                if (taskFound)
                {
                    nomEtape = this.ListTask[i].NameTask;
                    tempsEtape = this.ListTask[i].TimeTask;

                    if (i + 1 < this.ListTask.Count)
                    {
                        firstTask = this.ListTask[i + 1];
                    }

                    this.ListTask.RemoveAt(i);

                }
                if (i + 1 < this.ListTask.Count && this.ListTask[i].OrderStep + 1 == this.ListTask[i + 1].OrderStep && this.ListTask[i].IdDish == this.ListTask[i + 1].IdDish)
                {
                    endDish = true;
                }
                else if (i + 1 >= this.ListTask.Count)
                {
                    endDish = true;
                }

                _sem.Release();

                //ordres : 1.Couper   2.Cuire(plaques)   3.Mélanger     4.Cuire (Four)    2.Fondre    6.Préparation    7.Mixer     8.Raper
                switch (nomEtape)
                {
                    case "Eplucher":
                        Preparation(tempsEtape);
                        break;
                    case "Couper":
                        UseCut(tempsEtape);
                        break;
                    case "Cuire":
                        if (tempsEtape < 30)
                        {
                            UseHotPlate(tempsEtape);
                        }
                        else
                        {
                            UseOven(tempsEtape);
                        }
                        break;
                    case "Fondre":
                        UseHotPlate(tempsEtape);
                        break;
                    case "Melanger":
                        UseBlend(tempsEtape);
                        break;
                    case "Raper":
                        UseRaper(tempsEtape);
                        break;
                    case "Frire":
                        UseFriteuse(tempsEtape);
                        break;
                    case "Mixer":
                        UseMixer(tempsEtape);
                        break;
                    case "Présenter":
                        Preparation(tempsEtape);
                        break;
                    case "Ouvrir_huitres":
                        Preparation(tempsEtape);
                        break;
                    default:
                        break;
                }

                i = 0;
                taskFound = false;

            }

            //envoi l'id de la table : l'id de la préparation : si c est un entree/plat/dessert : nombre de plats de ce type dans la commande 

            for (int o = 0; o < TaskNew.NbSameDish; o++)
            {
                CommisChefs.SendDishes(TaskNew.IdTable, TaskNew.IdDish, TaskNew.Dish, TaskNew.NbDishesList);
            }
        }




        public void takeOrders(Tasks newTask)
        {
            this.ListTask.Add(newTask);
            if (newTask.OrderStep == 1)
            {
                string NameIngredient = null;
                int TypeIngredient = 0;

                DataSet setData = process.GetLieuxIngredients("Projet_Syst2", newTask.IdDish, newTask.Dish - 1);

                foreach (DataRow dr in setData.Tables[0].Rows)
                {
                    NameIngredient = dr["NameIngredient"].ToString();
                    TypeIngredient = Int32.Parse(dr["TypeIngredient"].ToString());


                    //ordres : 1.Couper   2.Cuire   3.Mélanger     4.Cuire (Four)    5.Fondre    6.Préparation    7.Cuire(plaques)  8.Mixer     9.Raper
                    this.CommisChefs.SearchIngredients(NameIngredient, TypeIngredient, newTask.NbSameDish);
                }


                ThreadPool.QueueUserWorkItem(GiveOrders, newTask);

            }
        }
    }
}
