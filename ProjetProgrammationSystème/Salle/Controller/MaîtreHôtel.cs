using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Salle.Model;

namespace Salle.Controller
{
    public class MaîtreHôtel : MaîtreHôtelInterface
    { 
        private static MaîtreHôtel MaîtreHôtelInstance;
        private Semaphore _sem;

        private bool _Busy;
        public bool Busy
        {
            get => this._Busy;
            set => this._Busy = value;
        }

        private List<ClientsInterface> _ListClients;
        public List<ClientsInterface> ListClients
        {
            get => this._ListClients;
            set => this._ListClients = value;
        }

        private static List<HeadWaiterInterface> _ListHeadWaiter;
        public List<HeadWaiterInterface> ListHeadWaiter
        {
            get => _ListHeadWaiter;
            set => _ListHeadWaiter = value;
        }

        private static List<SquareInterface> _ListSquare;
        public List<SquareInterface> ListSquare
        {
            get => _ListSquare;
            set => _ListSquare = value;
        }



        public static MaîtreHôtel maîtreHôtelInstance()
        {

            if (MaîtreHôtelInstance == null)
            {
                MaîtreHôtelInstance = new MaîtreHôtel();
            }

            return MaîtreHôtelInstance;
        }

        private MaîtreHôtel()
        {
            Busy = false;

            List<ClientsInterface> newListClient = new List<ClientsInterface>();
            this.ListClients = (List<ClientsInterface>) newListClient;
            this._sem = new Semaphore(1,1);

            List<HeadWaiterInterface> newListHeadWaiter = new List<HeadWaiterInterface>
            {
                new HeadWaiter(1),
                new HeadWaiter(2)
            };

            ListHeadWaiter = newListHeadWaiter;
        }



        public bool AssignTable(ClientsInterface groupe)
        {
            int idTable = -1;
            bool res = false;
            if (ListSquare[0].NbClients <= ListSquare[1].NbClients)
            {
                if(ListSquare[0].LineList[0].NbClients <= ListSquare[0].LineList[1].NbClients)
                {
                    idTable = VerifTables(0, 0, groupe);
                    if (idTable == -1)
                    {
                        idTable = VerifTables(0, 1, groupe);
                        if (idTable == -1)
                        {
                            idTable = VerifTables(1, 0, groupe);
                            if (idTable == -1)
                            {
                                idTable = VerifTables(1, 1, groupe);
                            }
                        }
                    }
                }
                else
                {
                    idTable = VerifTables(0, 1, groupe);
                    if (idTable == -1)
                    {
                        idTable = VerifTables(0, 0, groupe);
                        if (idTable == -1)
                        {
                            idTable = VerifTables(1, 0, groupe);
                            if (idTable == -1)
                            {
                                idTable = VerifTables(1, 1, groupe);
                            }
                        }
                    }
                }
            }
            else
            {
                if (ListSquare[1].LineList[0].NbClients <= ListSquare[1].LineList[1].NbClients)
                {
                    idTable = VerifTables(1, 0, groupe);
                    if (idTable == -1)
                    {
                        idTable = VerifTables(1, 1, groupe);
                        if (idTable == -1)
                        {
                            idTable = VerifTables(0, 0, groupe);
                            if (idTable == -1)
                            {
                                idTable = VerifTables(0, 1, groupe);
                            }
                        }
                    }
                }
                else
                {
                    idTable = VerifTables(1, 1, groupe);
                    if (idTable == -1)
                    {
                        idTable = VerifTables(1, 0, groupe);
                        if (idTable == -1)
                        {
                            idTable = VerifTables(0, 0, groupe);
                            if (idTable == -1)
                            {
                                idTable = VerifTables(0, 1, groupe);
                            }
                        }
                    }
                }
            }

            if(idTable >= 0)
            {

                if(Hall.hallInstance().FindTableById(idTable).Cutlery == false)
                {
                    GetHeadWaiterDisposable().DrowUpTable(idTable, groupe.ClientsNumber);
                }
                Console.WriteLine("IdTable : {0}, nbClients {1}", idTable, groupe.ClientsNumber);
                CallHeadWaiter(idTable,groupe.ClientsNumber);
                res = true;
            }

            return res;
        }

        public int VerifTables(int idSquare, int idLine, ClientsInterface groupe)
        {
            int res = -1;
            int i = 0;
            int countMal = 0;

            while (i < ListSquare[idSquare].LineList[idLine].ListTable.Count)
            {
                if (ListSquare[idSquare].LineList[idLine].ListTable[i].NbPlace >= groupe.ClientsNumber && ListSquare[idSquare].LineList[idLine].ListTable[i].Clients == null)
                {


                    if (res == -1)
                    {
                        res = ListSquare[idSquare].LineList[idLine].ListTable[i].IdTable;
                    }

                    if (res >= 7 && res < 17)
                    {
                        countMal = 7;
                    }
                    else if (res >= 17 && res < 25)
                    {
                        countMal = 17;
                    }
                    else if (res >= 25 && res <= 32)
                    {
                        countMal = 25;
                    }

                    if (res != -1 && ListSquare[idSquare].LineList[idLine].ListTable[i].NbPlace < ListSquare[idSquare].LineList[idLine].ListTable[res-countMal].NbPlace)
                    {
                        res = ListSquare[idSquare].LineList[idLine].ListTable[i].IdTable;
                    }

                }

                i++;
            }

            if (res != -1)
            {
                ListSquare[idSquare].NbClients += groupe.ClientsNumber;
                ListSquare[idSquare].LineList[idLine].NbClients += groupe.ClientsNumber;
                ListSquare[idSquare].LineList[idLine].ListTable[res - countMal].Clients = groupe;
                groupe.idTable = res;
            }
            return res;
        }

        public void CallHeadWaiter(int idTable, int nbClients)
        {
            HeadWaiter HWaiter = (HeadWaiter) GetHeadWaiterDisposable();
            Console.WriteLine("Headwaiter disponible : {0}", HWaiter.IdHeadWaiter);
            //Hwaiter vient voir le maître d'hôtel
            
            Thread threadHWaiter = new Thread(() => HWaiter.SitClient(idTable, nbClients));
            threadHWaiter.Start();
        }

        public HeadWaiterInterface GetHeadWaiterDisposable()
        {
            HeadWaiterInterface repHeadWaiter = null;

            if (!ListHeadWaiter[0].Busy)
            {
                repHeadWaiter = ListHeadWaiter[0];
            }else if (!ListHeadWaiter[1].Busy)
            {
                repHeadWaiter = ListHeadWaiter[1];
            }
            else
            {
                System.Threading.Thread.Sleep(300);
                repHeadWaiter = GetHeadWaiterDisposable();
            }

            return repHeadWaiter;
        }

        public void ClientsReception()
        {
            _sem.WaitOne();

            if (this.ListClients.Count > 0)
            {
                if (this.ListClients[0] != null)
                {
                    ClientsInterface premierGroupe = this.ListClients[0];
                    Console.WriteLine(premierGroupe.IdClients);
                    if (AssignTable(premierGroupe))
                    {
                        this.ListClients.Remove(premierGroupe);
                    }
                    else
                    {
                        this.ListClients.Add(premierGroupe);
                        this.ListClients.Remove(premierGroupe);
                    }
                }
            }

            _sem.Release();
        }

        public bool GetMoney(int Bill, ClientsInterface groupe)
        {
            _sem.WaitOne();

            Thread.Sleep(333);
            groupe.leave();

            _sem.Release();
            return true;
        }

        public void SecondOrderFromClient(int IdTable)
        {
            HeadWaiter HWaiter = (HeadWaiter)GetHeadWaiterDisposable();
            HWaiter.GiveOrder(HWaiter.getOrder(IdTable,true));
        }
    }
}
