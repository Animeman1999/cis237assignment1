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
            const String CSV_FILE_PATH = "../../../datafiles/WineList.csv";

            WineItemCollection wineItemCollection = new WineItemCollection();

            var wineCollection = wineItemCollection.CreateWineCollection();


            CSVProcessor loadRecords = new CSVProcessor();

            WineItem wineItem = new WineItem();
            wineItem.ID = "123";
            wineItem.Description = "Rose Water";
            wineItem.Pack = "Single bottle";

            UserInterface ui = new UserInterface();

            int choice = ui.GetUserInput();

            while (choice != 5)
            {
                switch (choice)
                {
                    case 1:
                        loadRecords.ReadFile(CSV_FILE_PATH, wineCollection);
                        break;
                    case 2:
                        ui.PrintOutput(ui.CreateListString(wineCollection));
                        break;
                    case 3:

                        break;

                    default:

                        break;
                }

                choice = ui.GetUserInput();
            }

        }


    }
}
