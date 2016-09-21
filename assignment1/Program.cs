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
    {//This file will handle the logic needed to run the menus in the userInterface.

        static void Main(string[] args)
        {
            //****************************
            //Constants
            //****************************
            const String CSV_FILE_PATH = "../../../datafiles/WineList.csv";//Holds path and file name of the csv file

            //****************************
            //Class Variables
            //****************************

            WineItemCollection wineItemCollection = new WineItemCollection();//Creates the array to hold WineItems by creating an instance of the class
            var wineCollection = wineItemCollection.CreateWineCollection();

            CSVProcessor loadRecords = new CSVProcessor();//Creates an instance of the CSVProcessor class to process the CSV file.

            UserInterface ui = new UserInterface();//Instance of the UserInterface class to run the menus'


            // Logic for the Start Menu found in UserInterface.cs
            int loadChoice = ui.GetUserStartMenu();

            if (loadChoice == 1)
            {

                loadRecords.ReadFile(CSV_FILE_PATH, wineCollection);
                ui.PrintOutput("********Wines have been loaded********");

                //Logic for the Maine Menu found in UserInterface.cs
                int choice = ui.GetUserInputMainMenu();

                while (choice != 4)
                {
                    switch (choice)
                    {
                        case 1:
                            ui.PrintOutput(ui.CreateListString(wineCollection));
                            break;
                        case 2:
                            SearchForWine(wineCollection);
                            break;
                        default:
                            ui.AddWine(wineCollection);
                            break;
                    }
                    choice = ui.GetUserInputMainMenu();
                }
            }
        }
        /// <summary>
        /// Logic used for the PrintSearchMenu found in UserInterface.cs
        /// </summary>
        /// <param name="WineCollection">WineItem[]</param>
        /// <param name="ExamineFile">CSVProcessor</param>
        static void SearchForWine(WineItem[] WineCollection)
        {  
            WineItem winItem = new WineItem("1","2","3");


            UserInterface ui = new UserInterface();
            int choice = ui.GetUserInputSearchMenu();
            while (choice != 4)
            {
                switch (choice)
                {
                    case 1:
                        ui.SearchBy(WineCollection, nameof(winItem.ID));
                        break;
                    case 2:
                        ui.SearchBy(WineCollection, nameof(winItem.Description));
                        break;
                    default:
                        ui.SearchBy(WineCollection, nameof(winItem.Pack));
                        break;
                }
                choice = ui.GetUserInputSearchMenu();
            }
        }

    }
}
