using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    public interface HallInterface
    {

        List<SquareInterface> SquareList { get; set; }

        TableInterface FindTableById(int IdTable);
        TableInterface VerifTableById(int idSquare, int idLine, int idTable);
        SquareInterface FindSquareByTableId(int IdTable);
    }
}
