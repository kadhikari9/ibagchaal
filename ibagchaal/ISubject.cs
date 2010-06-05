using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    interface ISubject
    {
        void registerObserver(IObserver o);
        void removeObserver(IObserver o);
        void nofityObservers(String notiFicationType);
    }
}
