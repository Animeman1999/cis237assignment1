/* Jeffrey Martin
   CIS237 Advanced C3
   9-20-20196
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace assignment1
{
    class CSVProcessor
    {//This class will do all the manipulation being done to the WineItem array. The logic is placed
        //here for easy update should the file change from a CSV file do a database.
               
        public void ReadFile(string csvFilePath, WineItem[] wineCollection)
        {// Method to place data into the WineItem array.

            StreamReader streamReader = null;

            try
            {
                string inputString;

                streamReader = new StreamReader(csvFilePath);

                int counter = 0;

                while ((inputString = streamReader.ReadLine()) != null)
                {
                    processRecord(inputString, wineCollection, counter++);
                }
                
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);
                
            }
            
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }

            
        }


        static void processRecord(string inputString, WineItem[] wineCollection, int index)
        {// Internal method used for tacking a single record from the CSV file and placing into the array
            string[] inputParts = inputString.Split(',');

            string id = inputParts[0];
            string description = inputParts[1];
            string pack = inputParts[2];

            wineCollection[index] = new WineItem(id, description, pack);
        }

        public string SearchBy(WineItem[] wineCollection, string searchFor, string propertyName)
        {//Generic method to search any of the WineItem properties for the data specified by the user
            bool found = false;
            string listString = "*********************************************************************" + Environment.NewLine;
            foreach (WineItem wineItem in wineCollection)
            {

                if (wineItem != null)
                {
                    
                    if (searchFor == wineItem.GetType().GetProperty(propertyName).GetValue(wineItem).ToString())
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

        public void AddWineItem(WineItem[] wineCollection, WineItem wineItemToAdd)
        {// Method used to fine a the first index of the WineItem array that does not have a record. Then it will 
            // create a new WineItem to add the record to at the discovered index. 
            for (int index = 0; index<=4000; index++)
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
