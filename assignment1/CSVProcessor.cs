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
    }
}
