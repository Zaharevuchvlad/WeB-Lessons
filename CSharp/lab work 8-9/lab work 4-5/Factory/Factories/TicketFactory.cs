using lab_work_4_5.Factory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_4_5.Factory.Factories
{
    internal abstract class TicketFactory
    {
        public abstract ITicket GetTicket();
    }
}
