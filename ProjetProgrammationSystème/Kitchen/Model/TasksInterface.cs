using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public interface TasksInterface
    {
        String NameTask { get; set; }
        int TimeTask { get; set; }
        int OrderStep { get; set; }
        int Dish { get; set; }
        int NbDishesList { get; set; }
        int NbSameDish { get; set; }
        int IdDish { get; set; }
    }
}
