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
    {

        
        public void ReadFile(string csvFilePath, WineItem[] wineCollection)
        {

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

        //internal void ReadFile(string cSV_FILE_PATH, WineItem[] wineCollection)
        //{
        //    throw new NotImplementedException();
        //}

        static void processRecord(string inputString, WineItem[] wineCollection, int index)
        {
            string[] inputParts = inputString.Split(',');

            string id = inputParts[0];
            string description = inputParts[1];
            string pack = inputParts[2];

            wineCollection[index] = new WineItem(id, description, pack);
        }

        public string SearchBy(WineItem[] wineCollection, string searchFor, string propertyName)
        {
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

        //public string SearchByID(WineItem[] wineCollection, string SearchID)
        //{
        //    bool found = false;
        //    string listString = "*********************************************************************" + Environment.NewLine;
        //    foreach (WineItem wineItem in wineCollection)
        //    {
                
        //        if (wineItem != null)
        //        {
        //            if (SearchID == wineItem.ID)
        //            {
        //                found = true;
        //                listString += wineItem + Environment.NewLine;
        //            }
        //        }
        //    }
        //    if (!found)
        //    {
        //        listString += SearchID + " was not found." + Environment.NewLine;
        //    }
        //    listString += "*********************************************************************" + Environment.NewLine;
        //    return listString;
        //}

        //public string SearchByDescription(WineItem[] wineCollection, string SearchDescription)
        //{
        //    bool found = false;
        //    string listString = "*********************************************************************" + Environment.NewLine;
        //    foreach (WineItem wineItem in wineCollection)
        //    {

        //        if (wineItem != null)
        //        {
        //            if (SearchDescription == wineItem.Description)
        //            {
        //                found = true;
        //                listString += wineItem + Environment.NewLine;
        //            }
        //        }
        //    }
        //    if (!found)
        //    {
        //        listString += SearchDescription + " was not found." + Environment.NewLine;
        //    }
        //    listString += "*********************************************************************" + Environment.NewLine;
        //    return listString;
        //}

        //public string SearchByPack(WineItem[] wineCollection, string SearchDescription)
        //{
        //    bool found = false;
        //    string listString = "*********************************************************************" + Environment.NewLine;
        //    foreach (WineItem wineItem in wineCollection)
        //    {

        //        if (wineItem != null)
        //        {
        //            if (SearchDescription == wineItem.Pack)
        //            {
        //                found = true;
        //                listString += wineItem + Environment.NewLine;
        //            }
        //        }
        //    }
        //    if (!found)
        //    {
        //        listString += SearchDescription + " was not found." + Environment.NewLine;
        //    }
        //    listString += "*********************************************************************" + Environment.NewLine;
        //    return listString;
        //}

        public void AddWineItem(WineItem[] wineCollection, WineItem wineItemToAdd)
        {
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
