using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    interface IObserver
    {
        void update(String type);
        //implemet this method to change the view according to the change in model
        //variable type distinguish between various changes in model
        // I have implementated simple MVC using observer pattern.
        //use registerObserver method to register itself as the observer (view)
    }
}
