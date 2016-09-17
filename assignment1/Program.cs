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
    class Program
    {
        static void Main(string[] args)
        {
            const String CSV_FILE_PATH = "../../datafiles/WineList.csv";

            WineItemCollection wineCollection = new WineItemCollection();

            CSVProcessor loadRecords = new CSVProcessor();

            WineItem wineItem = new WineItem();
            wineItem.ID = "123";
            wineItem.Description = "Rose Water";
            wineItem.Pack = "Single bottle";

            UserInterface ui = new UserInterface();

            int choice = ui.GetUserInput();

            while (choice != 5)
            {
                if (choice == 2)
                {
                    ui.PrintOutput("wine item " + wineItem.ID + wineItem.Description + wineItem.Pack);
                    ui.PrintOutput(wineItem.ToString());
                }
                if (choice == 1)
                {
                    loadRecords.ReadFile(CSV_FILE_PATH, wineCollection);
                }
                choice = ui.GetUserInput();
            }
        }
    }
}
