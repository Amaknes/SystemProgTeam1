
using System;
using Kitchen.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.Threading;
using Salle.View;

namespace Kitchen.Controller
{
    public class Chef : ChefInterface
    {
        private Affichage afficher;
        private static Chef ChefInstance;

        private static List<SpecializedChefsInterface> _SpecializedChefsList;
        public static List<SpecializedChefsInterface> SpecializedChefsList
        {
            get => _SpecializedChefsList;
            set => _SpecializedChefsList = value;
        }


        public static bool DefineStrategy()
        {
            //Check if list is odd or even
            if (SpecializedChefsList.Count() % 2 == 0)
            {
                return true;
            }
            else return false;
        }

        private List<Order> _ListOrder;
        public List<Order> ListOrder
        {
            get => this._ListOrder;
            set => this._ListOrder = value;
        }


        public static void AddSpecializedChef()
        {
            if (DefineStrategy())
            {
                SpecializedChefsList.Add((SpecializedChefsInterface)new Pastry());
            }
            else
            {
                SpecializedChefsList.Add((SpecializedChefsInterface)new Cookers());
            }
        }
        
        public static Chef chefInstance()
        {
            if (ChefInstance == null)
            {
                ChefInstance = new Chef();
                AddSpecializedChef();
                AddSpecializedChef();
            }
            return ChefInstance;
        }

        private Semaphore _sem;


        private CLprocessus _process;
        public CLprocessus process
        {
            get => this._process;
            set => this._process = value;
        }

        private Chef()
        {
            SpecializedChefsList = new List<SpecializedChefsInterface>();
            _sem = new Semaphore(1, 1);
            process = new CLprocessus();
            ListOrder = new List<Order>();
            afficher = new Affichage();
        }




        public void GetOrder(String strOrder)
        {

            string[] Lists = strOrder.Split(':');
            Order order = null;


            String[] IdsTables = Regex.Split(Lists[0], @"\D+");
            order = new Order(Int32.Parse(IdsTables[0] + IdsTables[1])); 


            String[] IdsEntries = Regex.Split(Lists[1], @"\D+");
            List<int> TempListEntries = new List<int>();
            foreach (String strIds in IdsEntries)
            {
                if (!string.IsNullOrEmpty(strIds))
                {
                    int i = int.Parse(strIds);
                    TempListEntries.Add(i);
                }
            }
            order.ListEntries = TempListEntries;


            String[] IdsPlats = Regex.Split(Lists[2], @"\D+");
            List<int> TempListPlats = new List<int>();
            foreach (String strIds in IdsPlats)
            {
                if (!string.IsNullOrEmpty(strIds))
                {
                    int i = int.Parse(strIds);
                    TempListPlats.Add(i);
                }
            }
            order.ListPlats = TempListPlats;


            String[] IdsDesserts = Regex.Split(Lists[3], @"\D+");
            List<int> TempListDesserts = new List<int>();
            foreach (String strIds in IdsDesserts)
            {
                if (!string.IsNullOrEmpty(strIds))
                {
                    int i = int.Parse(strIds);
                    TempListDesserts.Add(i);
                }
            }
            order.ListDesserts = TempListDesserts;


            this.ListOrder.Add(order);

            afficher.afficherLine("The chef took the order from the table "+order.IdTable+", "+order.ListEntries.Count+" entries, "+ order.ListPlats.Count+" Plats and "+ order.ListDesserts.Count+" desserts");
            Sort();
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Sort()
        {
            bool suite = false;
            foreach (Order ord in ListOrder)
            {
                List<int> SuiteDish = new List<int>();

                if(ord.ListEntries.Count > 0)
                {
                    ord.ListEntries.Sort();
                    for (int i = 0; i < ord.ListEntries.Count - 1; i++)
                    {
                        if (!suite && ord.ListEntries[i] == ord.ListEntries[i + 1])
                        {
                            SuiteDish.Add(i);
                            SuiteDish.Add(i + 1);
                            suite = true;
                        }
                        else if (suite && ord.ListEntries[i] == ord.ListEntries[i + 1])
                        {
                            SuiteDish.Remove(i);
                            SuiteDish.Add(i + 1);
                            suite = true;
                        }
                        else
                        {
                            suite = false;
                        }
                    }
                    suite = false;


                    afficher.afficher("entries ");
                    foreach (int test in ord.ListEntries)
                    {
                        afficher.afficher(""+ test);
                    }
                    afficher.afficherLine("\n");
                    foreach (int test in SuiteDish)
                    {
                        afficher.afficher(""+test);
                    }
                    afficher.afficherLine("\n");

                    //dispatch
                    Dispatch(SuiteDish, 1, ord.IdTable);
                }
                



                SuiteDish = new List<int>();

                if(ord.ListPlats.Count > 0)
                {
                    ord.ListPlats.Sort();
                    for (int i = 0; i < ord.ListPlats.Count - 1; i++)
                    {
                        if (!suite && ord.ListPlats[i] == ord.ListPlats[i + 1])
                        {
                            SuiteDish.Add(i);
                            SuiteDish.Add(i + 1);
                            suite = true;
                        }
                        else if (suite && ord.ListPlats[i] == ord.ListPlats[i + 1])
                        {
                            SuiteDish.Remove(i);
                            SuiteDish.Add(i + 1);
                            suite = true;
                        }
                        else
                        {
                            suite = false;
                        }
                    }
                    suite = false;

                    afficher.afficher("Plats ");
                    foreach (int test in ord.ListPlats)
                    {
                        afficher.afficher(""+test);
                    }
                    afficher.afficherLine("\n");
                    foreach (int test in SuiteDish)
                    {
                        afficher.afficher(""+test);
                    }
                    afficher.afficherLine("\n");


                    //dispatch
                    Dispatch(SuiteDish, 2, ord.IdTable);
                }



                SuiteDish = new List<int>();

                if(ord.ListDesserts.Count > 0)
                {
                    ord.ListDesserts.Sort();
                    for (int i = 0; i < ord.ListDesserts.Count - 1; i++)
                    {
                        if (!suite && ord.ListDesserts[i] == ord.ListDesserts[i + 1])
                        {
                            SuiteDish.Add(i);
                            SuiteDish.Add(i + 1);
                            suite = true;
                        }
                        else if (suite && ord.ListDesserts[i] == ord.ListDesserts[i + 1])
                        {
                            SuiteDish.Remove(i);
                            SuiteDish.Add(i + 1);
                            suite = true;
                        }
                        else
                        {
                            suite = false;
                        }
                    }
                    suite = false;

                    afficher.afficher("Desserts ");
                    foreach (int test in ord.ListDesserts)
                    {
                        afficher.afficher(""+test);
                    }
                    afficher.afficherLine("\n");
                    foreach (int test in SuiteDish)
                    {
                        afficher.afficher(""+test);
                    }
                    afficher.afficherLine("\n");

                    //dispatch
                    Dispatch(SuiteDish, 3, ord.IdTable);
                }
            }
        }

        public void Dispatch(List<int> Suite, int pastry, int idTable)
        {
            //parcourir SpecializedChefsList et ordonner en fonction du plat et metier
            //parcour de la list de commandes pour rechercher ingrédients et ordres a donner
            //passer liste d'ordre au chef
            //liste des ingrédients


            DataSet setData = new DataSet();
            int count = 0;
            if (pastry == 3)
            {
                //Chef patissier
                foreach (Order ord in ListOrder)
                {
                    int i = 0;
                    while(i < ord.ListDesserts.Count)
                    {
                        if (Suite.Count != 0 && Suite[0] == i)
                        {
                            i = Suite[0+1];
                            count = 1 + Suite[1] - Suite[0];
                            Suite.RemoveAt(0);
                            Suite.RemoveAt(0);
                        }
                        else
                        {
                            count = 1;
                        }
                        setData = process.GetListCommand("ProjetProgSystem",ord.ListDesserts[i]);
                        afficher.afficherLine(count+" Desserts de "+ ord.ListDesserts[i]);

                        foreach (DataRow dr in setData.Tables[0].Rows)
                        {
                            string NameTask = dr["NameTask"].ToString();
                            int Timetask = Int32.Parse(dr["TimeStask"].ToString());
                            int OrderStep = Int32.Parse(dr["OrderStep"].ToString());

                            Model.Tasks currentTask = new Model.Tasks(NameTask, Timetask, OrderStep, 3, ord.ListDesserts.Count, count, ord.ListDesserts[i]);

                            SpecializedChefsList[0].takeOrders(currentTask, ord.IdTable);
                        }
                        i++;
                    }
                }
            }
            else
            {
                //Cuisinier
                if (pastry == 2)
                {
                    foreach (Order ord in ListOrder)
                    {
                        int i = 0;
                        while (i < ord.ListPlats.Count)
                        {
                            if (Suite.Count != 0 && Suite[0] == i)
                            {
                                i = Suite[0 + 1];
                                count = 1 + Suite[1] - Suite[0];
                                Suite.RemoveAt(0);
                                Suite.RemoveAt(0);
                            }
                            else
                            {
                                count = 1;
                            }
                            setData = process.GetListCommand("ProjetProgSystem", ord.ListPlats[i]);
                            afficher.afficherLine(count+" Desserts de "+ ord.ListPlats[i]);

                            foreach (DataRow dr in setData.Tables[0].Rows)
                            {
                                string NameTask = dr["NameTask"].ToString();
                                int Timetask = Int32.Parse(dr["TimeStask"].ToString());
                                int OrderStep = Int32.Parse(dr["OrderStep"].ToString());

                                Model.Tasks currentTask = new Model.Tasks(NameTask, Timetask, OrderStep, 3, ord.ListPlats.Count, count, ord.ListPlats[i]);

                                SpecializedChefsList[0].takeOrders(currentTask, ord.IdTable);
                            }
                            i++;
                        }
                    }
                }
                else if(pastry == 1)
                {
                    foreach (Order ord in ListOrder)
                    {
                        int i = 0;
                        while (i < ord.ListEntries.Count)
                        {
                            if (Suite.Count != 0 && Suite[0] == i)
                            {
                                i = Suite[0 + 1];
                                count = 1 + Suite[1] - Suite[0];
                                Suite.RemoveAt(0);
                                Suite.RemoveAt(0);
                            }
                            else
                            {
                                count = 1;
                            }
                            setData = process.GetListCommand("ProjetProgSystem", ord.ListEntries[i]);
                            afficher.afficherLine(count+" Desserts de "+ ord.ListEntries[i]);

                            foreach (DataRow dr in setData.Tables[0].Rows)
                            {
                                string NameTask = dr["NameTask"].ToString();
                                int Timetask = Int32.Parse(dr["TimeStask"].ToString());
                                int OrderStep = Int32.Parse(dr["OrderStep"].ToString());

                                Model.Tasks currentTask = new Model.Tasks(NameTask, Timetask, OrderStep, 3, ord.ListEntries.Count, count, ord.ListEntries[i]);

                                SpecializedChefsList[0].takeOrders(currentTask, ord.IdTable);
                            }
                            i++;
                        }
                    }
                }
            }
        }
    }
}

