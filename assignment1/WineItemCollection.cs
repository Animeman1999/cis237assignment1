/* Jeffrey Martin
   CIS237 Advanced C3
   9-20-20196
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class WineItemCollection
    {
        //*********************************
        //Backing Fields
        //*********************************
       // WineItem[] WineCollection; 

        //*********************************
        //Constructor
        //*********************************

        
        //public WineItemCollection()
        //{
        //    WineCollection = new WineItem[4000];
        //}

        public WineItem[] CreateWineCollection()
        {
            WineItem[] WineCollection = new WineItem[4000];
            return WineCollection;
        }
    }
}
