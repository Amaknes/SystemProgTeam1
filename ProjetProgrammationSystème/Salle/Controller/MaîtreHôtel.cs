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

        private static Semaphore _semOccuper;
        private static MaîtreHôtel MaîtreHôtelInstance;

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
            _semOccuper = new Semaphore(0,1);

            List<ClientsInterface> newListClient = new List<ClientsInterface>();
            this.ListClients = (List<ClientsInterface>) newListClient;

            List<HeadWaiterInterface> newListHeadWaiter = new List<HeadWaiterInterface>
            {
                new HeadWaiter(1),
                new HeadWaiter(2)
            };

            ListHeadWaiter = newListHeadWaiter;
        }



        public void AssignTable(ClientsInterface groupe)
        {
            int idTable = -1;

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
                Console.WriteLine("IdTable : {0}", idTable);
                CallHeadWaiter(idTable);
            }
        }

        public int VerifTables(int idSquare, int idLine, ClientsInterface groupe)
        {
            int res = -1;
            int i = 0;

            while (i < ListSquare[idSquare].LineList[idLine].ListTable.Count)
            {
                if (ListSquare[idSquare].LineList[idLine].ListTable[i].NbPlace >= groupe.ClientsNumber && ListSquare[idSquare].LineList[idLine].ListTable[i].Clients == null)
                {

                    if (res != -1)
                    {
                        res = ListSquare[idSquare].LineList[idLine].ListTable[i].IdTable;
                    }

                    if (ListSquare[idSquare].LineList[idLine].ListTable[i].NbPlace < ListSquare[idSquare].LineList[idLine].ListTable[res].NbPlace)
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
                ListSquare[idSquare].LineList[idLine].ListTable[res].Clients = groupe;
            }
            return res;
        }

        public void CallHeadWaiter(int idTable)
        {
            HeadWaiter HWaiter = (HeadWaiter) GetHeadWaiterDisposable();
            //Hwaiter vient voir le maître d'hôtel
            HWaiter.SitClient(idTable);
        }

        public HeadWaiterInterface GetHeadWaiterDisposable()
        {
            HeadWaiterInterface repHeadWaiter = null;

            if (!ListHeadWaiter[0].Busy)
            {
                repHeadWaiter = ListHeadWaiter[0];
            }else if (!ListHeadWaiter[0].Busy)
            {
                repHeadWaiter = ListHeadWaiter[1];
            }
            else
            {
                System.Threading.Thread.Sleep(700);
                repHeadWaiter = GetHeadWaiterDisposable();
            }

            return repHeadWaiter;
        }

        public void ClientsReception()
        {
            if(this.ListClients.Count > 0)
            {
                ClientsInterface premierGroupe = this.ListClients[0];
                //AssignTable(premierGroupe);
                this.ListClients.Remove(premierGroupe);
            }
        }
    }
}
