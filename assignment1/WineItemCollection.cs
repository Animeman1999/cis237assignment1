﻿/* Jeffrey Martin
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
    {//Class to hold the array of WineItems

        //*********************************
        //Backing Fields
        //*********************************
        WineItem[] WineCollection; 

        //*********************************
        //Constructor
        //*********************************


        public WineItem[] CreateWineCollection()
        {
            WineCollection = new WineItem[4000];
            return WineCollection;
        }


    }
}
