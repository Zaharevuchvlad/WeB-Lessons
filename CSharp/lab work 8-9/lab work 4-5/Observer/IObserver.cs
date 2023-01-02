using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_4_5.Observer
{
    public interface IObserver
    {
        void Update(int row, int colum);
    }
}
