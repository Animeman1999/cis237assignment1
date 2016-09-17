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
{// Class to hold one record of a wine item.
    class WineItem
    {
        //*********************************
        //Backing Fields
        //*********************************
        private string _id;

        //*********************************
        //Properties
        //*********************************

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Description { get; set; }
        public string Pack { get; set; }
    }
}
