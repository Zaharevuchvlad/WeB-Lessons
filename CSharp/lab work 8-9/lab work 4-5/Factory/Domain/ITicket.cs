using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_4_5.Factory.Domain
{
    internal interface ITicket
    {
        string Type { get; }
        DateTime Date { get; set; }
        int Row { get; }
        int Colum { get;  }
        int GetPrice();
    }
}
