using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_4_5.Factory.Domain
{
    internal class LowTicket:ITicket
    {
        private readonly string _type;
        private readonly int _price;
        private readonly int _row;
        private readonly int _colum;
        public LowTicket(int price,int row,int colum)
        {
            _type = "LOW TICKET";
            _price = price;
            _row = row;
            _colum = colum;

        }
        public string Type { get { return _type; } }
        public DateTime Date { get; set; }
        public int Row { get { return _row; } }
        public int Colum { get { return _colum; }  }
        public int GetPrice()
        {
            return _price;
        }
    }
}
