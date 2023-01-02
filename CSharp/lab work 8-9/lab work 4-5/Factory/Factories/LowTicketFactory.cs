using lab_work_4_5.Factory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_4_5.Factory.Factories
{
    internal class LowTicketFactory : TicketFactory
    {
        private readonly int _price;
        private readonly int _row;
        private readonly int _colum;

        public LowTicketFactory(int price, int row, int colum)
        {
            _price = price;
            _row = row;
            _colum = colum;
        }

        public override ITicket GetTicket()
        {
            LowTicket topTicket = new(_price, _row, _colum)
            {
                Date = DateTime.Now

            };
            return topTicket;
        }
    }
}
