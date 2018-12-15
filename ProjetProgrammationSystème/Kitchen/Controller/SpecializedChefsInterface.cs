using Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{

    public interface SpecializedChefsInterface
    {

        CommisChefInterface CommisChefs { get; set; }
        CLprocessus process { get; set; }

        void UseOven(int time);
        void Preparation(int time);
        void UseHotPlate(int time);
        void UseRaper(int time);
        void UseMixer(int time);
        void UseBlend(int time);
        void UseCut(int time);

        void GiveOrders(object t);
        //void GiveOrders(string NameIngredient, int TypeIngredient, Tasks firstTask, int idTable);
        void takeOrders(Tasks newTask);
    }
}
