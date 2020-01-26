using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.Interfaces
{
    interface IHaikuContext
    {
        int GetSyllableCount(string argWord);

        string CheckIfHikauIsValid(List<int> argHikauData);

    }
}
