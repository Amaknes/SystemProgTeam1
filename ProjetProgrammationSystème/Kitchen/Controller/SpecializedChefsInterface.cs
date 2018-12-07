using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{

    interface SpecializedChefsInterface
    {

    List<CommisChefInterface> CommisChefsList { get; set; }

    string Type();


    int UseOven();

    int UseHotPlate();
    
        
    int GiveOrders();


    int Preparation();



    }
}
