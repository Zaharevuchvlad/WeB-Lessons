using lab4_5;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_4_5.Observer
{
    public interface IObservable
    {
         void AddObserver(IObserver observer);
         void RemoveObserver(IObserver observer);
         void Notify(CChair chair);   
    }
}
