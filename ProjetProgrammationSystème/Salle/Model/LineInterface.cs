using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    interface LineInterface
    {

        int IdLine { get; set; }
        List<TableInterface> ListTable { get; set; }

    }
}
