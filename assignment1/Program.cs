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
    class Program
    {//This file will hande instansciating the various classes used for this program and to handle
        // the logic from the UserInterface class.

        static void Main(string[] args)
        {
            const String CSV_FILE_PATH = "../../../datafiles/WineList.csv";

            WineItemCollection wineItemCollection = new WineItemCollection();

            var wineCollection = wineItemCollection.CreateWineCollection();

            CSVProcessor loadRecords = new CSVProcessor();

            WineItem wineItem = new WineItem();

            UserInterface ui = new UserInterface();


            // Logic for the Start Menu found in UserInterface.cs
            int loadChoice = ui.GetUserStartMenu();

            if (loadChoice == 1)
            {

                loadRecords.ReadFile(CSV_FILE_PATH, wineCollection);
                ui.PrintOutput("********Wines have been loaded********");

                //Logic for the Maine Menu found in UserInterface.cs
                int choice = ui.GetUserInputMenu();

                while (choice != 4)
                {
                    switch (choice)
                    {
                        case 1:
                            ui.PrintOutput(ui.CreateListString(wineCollection));
                            break;
                        case 2:
                            SearchForWine(wineCollection, loadRecords);
                            break;
                        default:
                            ui.AddWine(wineCollection, loadRecords);
                            break;
                    }
                    choice = ui.GetUserInputMenu();
                }
            }

        }
        static void SearchForWine(WineItem[] WineCollection, CSVProcessor ExamineFile)
        {   // Logic for the Search Menu found in UserInterface.cs
            
            UserInterface ui = new UserInterface();
            int choice = ui.GetUserInputSearch();
            while (choice != 4)
            {
                switch (choice)
                {
                    case 1:
                        ui.SearchBy(WineCollection, ExamineFile, "ID");
                        break;
                    case 2:
                        ui.SearchBy(WineCollection, ExamineFile, "Description");
                        break;
                    default:
                        ui.SearchBy(WineCollection, ExamineFile, "Pack");
                        break;
                }
                choice = ui.GetUserInputSearch();
            }
        }

    }
}
