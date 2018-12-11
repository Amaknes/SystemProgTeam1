
using System;
using Kitchen.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

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




        private Chef()
        {
            SpecializedChefsList = new List<SpecializedChefsInterface>();

            ListOrder = new List<Order>();
        }




        public void GetOrder(String strOrder)
        {
            string[] Lists = strOrder.Split(':');
            Order order = new Order(Int32.Parse(Lists[0]));


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

                foreach (int test in ord.ListEntries)
                {
                    Console.Write(" {0} ", test);
                }
                Console.WriteLine("\n");
                foreach (int test in SuiteDish)
                {
                    Console.WriteLine(test);
                }

                //dispatch



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

                foreach (int test in ord.ListPlats)
                {
                    Console.Write(" {0} ", test);
                }
                Console.WriteLine("\n");
                foreach (int test in SuiteDish)
                {
                    Console.WriteLine(test);
                }

                //dispatch



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

                foreach (int test in ord.ListDesserts)
                {
                    Console.Write(" {0} ", test);
                }
                Console.WriteLine("\n");
                foreach (int test in SuiteDish)
                {
                    Console.WriteLine(test);
                }

                //dispatch
            }
        }

        public void Dispatch(int Order, int IdSpecializedChefs)
        {

        }
    }
}

