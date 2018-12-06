﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    public class Hall : HallInterface
    {
        private static HallInterface HallInstance;

        private List<SquareInterface> _SquareList;
        public List<SquareInterface> SquareList
        {

            get { return this._SquareList; }

            set { this._SquareList = value; }

        }


        private Hall()
        {
            List<SquareInterface> newSquareList = new List<SquareInterface>();

            newSquareList.Add((SquareInterface)new Square());
            newSquareList.Add((SquareInterface)new Square());

            SquareList  = newSquareList;
        }

        public static HallInterface hallInstance()
        {
            if(HallInstance == null)
            {
                HallInstance = (HallInterface) new Hall();
            }

            return HallInstance;
        }
    }
}
