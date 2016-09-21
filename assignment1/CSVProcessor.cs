﻿/* Jeffrey Martin
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
    }
}
