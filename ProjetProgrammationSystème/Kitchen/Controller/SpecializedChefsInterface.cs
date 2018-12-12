using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{

    public interface SpecializedChefsInterface
    {

    List<CommisChefInterface> CommisChefsList { get; set; }

    int UseOven(int time);

    int UseHotPlate(int time);
    
        
    int GiveOrders(int Order, int idCommisChef);


    int Preparation();



    }
}
