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
    class WineArrayProcessor
    {   //Methods to handle all the processing of the WineItem array that is done internally for the program

        /// <summary>
        /// Searches the array for a value in the spicified property.
        /// </summary>
        /// <param name="wineCollection">WineItem[]</param>
        /// <param name="searchFor">string</param>
        /// <param name="propertyName">string</param>
        /// <returns>string</returns>
        public string SearchBy(WineItem[] wineCollection, string searchFor, string propertyName)
        {//Generic method to search any of the WineItem properties for the data specified by the user
            bool found = false;
            string listString = "*********************************************************************" + Environment.NewLine;
            foreach (WineItem wineItem in wineCollection)
            {

                if (wineItem != null)
                {
                    //String to hold the value held in the property converted to lowercase. The various Gets are used to enable any property to be passed in.
                    string propertyValue = wineItem.GetType().GetProperty(propertyName).GetValue(wineItem).ToString().ToLower();

                    //String to hold the value of the searchFor converted to lowercase.
                    string searchValue = searchFor.ToString();
                    if (propertyValue.Contains(searchValue))
                    {
                        found = true;
                        listString += wineItem + Environment.NewLine;
                    }
                }
            }
            if (!found)
            {
                listString += searchFor + " was not found." + Environment.NewLine;
            }
            listString += "*********************************************************************" + Environment.NewLine;
            return listString;
        }

        /// <summary>
        /// Adds a new record to the end of the array
        /// </summary>
        /// <param name="wineCollection">WineItem[]</param>
        /// <param name="wineItemToAdd">WineItem</param>
        public void AddWineItem(WineItem[] wineCollection, WineItem wineItemToAdd)
        {// Method used to finf the first index of the WineItem array that does not have a record. Then it will 
            // create a new WineItem to add the record to at the discovered index. 
            for (int index = 0; index <= 4000; index++)
            {
                if (wineCollection[index] == null)
                {
                    wineCollection[index] = new WineItem(wineItemToAdd.ID, wineItemToAdd.Description, wineItemToAdd.Pack);
                    index = 5000;
                }
            }
        }
    }
}
