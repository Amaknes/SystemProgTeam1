
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

namespace Kitchen.Controller
{
    public class Chef : ChefInterface
    {
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
        private CLprocessus process
        {
            get => this._process;
            set => this._process = value;
        }
        public object Dataset { get; private set; }

        private Chef()
        {
            SpecializedChefsList = new List<SpecializedChefsInterface>();
            _sem = new Semaphore(1, 1);
            process = new CLprocessus();
            ListOrder = new List<Order>();
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

            Console.WriteLine("The chef took the order from the table {0}, {1} entries, {2} Plats and {3} desserts", order.IdTable, order.ListEntries.Count, order.ListPlats.Count, order.ListDesserts.Count);
            Sort();
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Sort()
        {
            bool suite = false;
            foreach (Order ord in ListOrder)
            {
                ord.ListEntries.Sort();
                List<int> SuiteDish = new List<int>();
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


                Console.Write("entries ");
                foreach (int test in ord.ListEntries)
                {
                    Console.Write(" {0} ", test);
                }
                Console.WriteLine("\n");
                foreach (int test in SuiteDish)
                {
                    Console.Write(test);
                }
                Console.WriteLine("\n");

                //dispatch
                Dispatch(SuiteDish, 1, ord.IdTable);



                SuiteDish = new List<int>();
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

                Console.Write("Plats ");
                foreach (int test in ord.ListPlats)
                {
                    Console.Write("{0} ", test);
                }
                Console.WriteLine("\n");
                foreach (int test in SuiteDish)
                {
                    Console.Write(test);
                }
                Console.WriteLine("\n");

                //dispatch
                Dispatch(SuiteDish, 2, ord.IdTable);



                SuiteDish = new List<int>();
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

                Console.Write("Desserts ");
                foreach (int test in ord.ListDesserts)
                {
                    Console.Write(" {0} ", test);
                }
                Console.WriteLine("\n");
                foreach (int test in SuiteDish)
                {
                    Console.Write(test);
                }
                Console.WriteLine("\n");

                //dispatch
                Dispatch(SuiteDish, 3, ord.IdTable);
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
                foreach(Order ord in ListOrder)
                {
                    int i = 0;
                    while(i < ord.ListDesserts.Count)
                    {
                        if (Suite.Count != 0 && Suite[0] == i)
                        {
                            i = Suite[0+1];
                            count = 1 + Suite[1] - Suite[0];
                            Suite.RemoveAt(0);
                            Suite.RemoveAt(1);
                        }
                        else
                        {
                            count = 1;
                        }
                        setData = process.GetListCommand("ProjetProgSystem",ord.ListDesserts[i]);
                        Console.WriteLine("{0} Desserts de {1}", count,count);

                        foreach (DataRow dr in setData.Tables[0].Rows)
                        {
                            string NameTask = dr["NameTask"].ToString();
                            int Timetask = Int32.Parse(dr["TimeStask"].ToString());
                            int OrderStep = Int32.Parse(dr["OrderStep"].ToString());

                            Model.Tasks currentTask = new Model.Tasks(NameTask, Timetask, OrderStep, 3, ord.ListDesserts.Count, count);
                            //ordres : 1.Couper   2.Cuire   3.Mélanger     4.Cuire (Four)    5.Fondre    6.Préparation    7.Cuire(plaques)  8.Mixer     9.Raper
                            SpecializedChefsList[0].takeOrders(currentTask);
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


                    //ordres : 1.Couper   2.Cuire   3.Mélanger     4.Cuire (Four)    5.Fondre    6.Préparation    7.Cuire(plaques)  8.Mixer     9.Raper
                }
                else if(pastry == 1)
                {

                    //ordres : 1.Couper   2.Cuire   3.Mélanger     4.Cuire (Four)    5.Fondre    6.Préparation    7.Cuire(plaques)  8.Mixer     9.Raper
                }

            }
        }
    }
}

