﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    interface ChefInterface
    {
        List<SpecializedChefsInterface> SpecializedChefsList { get; set; }

        void GetOrder();
    
        void Sort();

        void Dispatch();
    }
}
