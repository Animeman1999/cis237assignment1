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
    class UserInterface
    {// Class to handle all input and output for the program

        WineArrayProcessor wineProcessor = new WineArrayProcessor();

        /// <summary>
        /// Handles input and output of the Start Menu
        /// </summary>
        /// <returns></returns>
        public int GetUserStartMenu()
        {
            this.LoadMenu();
            ConsoleKeyInfo inputChar = Console.ReadKey();
            string inputString = inputChar.KeyChar.ToString();
            Console.WriteLine();
            while (inputString != "1" && inputString != "2")
            {
                Console.WriteLine(WriteInvalidEntry());
                this.LoadMenu();
                inputChar = Console.ReadKey();
                inputString = inputChar.KeyChar.ToString();
                Console.WriteLine();
            }
            return Int16.Parse(inputString);
        }
        /// <summary>
        /// Handles input and output of the Main Menu
        /// </summary>
        /// <returns></returns>
        public int GetUserInputMainMenu()
        {
            this.PrintMainMenu();
            ConsoleKeyInfo inputChar = Console.ReadKey();
            string inputString = inputChar.KeyChar.ToString();
            Console.WriteLine();
            while (inputString != "1" && inputString != "2" && inputString != "3" && inputString != "4" )
            {
                Console.WriteLine(WriteInvalidEntry());
                this.PrintMainMenu();
                inputChar = Console.ReadKey();
                inputString = inputChar.KeyChar.ToString();
                Console.WriteLine();
            }
            return Int16.Parse(inputString);
        }

        /// <summary>
        /// Handles the input and output of the Search Menu
        /// </summary>
        /// <returns></returns>
        public int GetUserInputSearchMenu()
        {
            this.PrintSearchMenu();

            ConsoleKeyInfo inputChar = Console.ReadKey();
            string inputString = inputChar.KeyChar.ToString();
            Console.WriteLine();
            while (inputString != "1" && inputString != "2" && inputString != "3" && inputString != "4")
            {
                Console.WriteLine(WriteInvalidEntry());
                this.PrintSearchMenu();
                inputChar = Console.ReadKey();
                inputString = inputChar.KeyChar.ToString();
                Console.WriteLine();
            }
            return Int16.Parse(inputString);
        }

        /// <summary>
        /// Generic invalid entry error message
        /// </summary>
        /// <returns></returns>
        private string WriteInvalidEntry()
        {
            string invalidEntry;
            invalidEntry = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" + Environment.NewLine +
                            "Not a valid entry, please make another choice" + Environment.NewLine +
                            "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" + Environment.NewLine;
            return invalidEntry;
        }

        /// <summary>
        /// Specific invalid entry error message
        /// </summary>
        /// <param name="propertyName">string</param>
        /// <returns></returns>
        private string WriteInvalidSpecificEntry(string propertyName)
        {
            string errorMessage = "XXXXXXXXXXXXXXXXXXXXXXXXXX" + Environment.NewLine +
                                    $"No {propertyName} entered" + Environment.NewLine +
                                    "XXXXXXXXXXXXXXXXXXXXXXXXXX";
            return errorMessage;
        }

        /// <summary>
        /// Inputs porperty to search and call the function to do so and outputs the results
        /// </summary>
        /// <param name="WineCollection">WineItem[]</param>
        /// <param name="propertyName">string</param>
        public void SearchBy(WineItem[] WineCollection, string propertyName)
        {               
            Console.Write($"Enter {propertyName}: ");
            string input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine( WriteInvalidSpecificEntry(propertyName));
            }
            else
            {
                PrintOutput(wineProcessor.SearchBy(WineCollection, input, propertyName));
            }
        }

        /// <summary>
        /// Input sequence to create a new WineItem than calls method to add to WineItem array.
        /// </summary>
        /// <param name="WineCollection">WineItem[]</param>
        public void AddWine(WineItem[] WineCollection)
        {
            Console.Write("Enter Wine ID: ");
            string idInput = Console.ReadLine();
            if (idInput == "")
            {
                Console.WriteLine(WriteInvalidSpecificEntry("Wine Id"));

            }
            else
            {
                Console.Write("Enter Wine Description: ");
                string descriptionInput = Console.ReadLine();
                while (descriptionInput == "")
                {
                    Console.WriteLine(WriteInvalidSpecificEntry("Wine Description"));
                    Console.Write("Enter Wine Description: ");
                    descriptionInput = Console.ReadLine();
                }
                
                
                Console.Write("Enter Wine Pack: ");
                string packInput = Console.ReadLine();
                while (packInput == "")
                {
                    Console.WriteLine(WriteInvalidSpecificEntry("Wine Pack"));
                    Console.Write("Enter Wine Pack: ");
                    packInput = Console.ReadLine();
                }
                
                WineItem wineItemToAdd = new WineItem();
                wineItemToAdd.ID = idInput;
                wineItemToAdd.Description = descriptionInput;
                wineItemToAdd.Pack = packInput;

                wineProcessor.AddWineItem(WineCollection, wineItemToAdd);
                Console.WriteLine("**************************************************************************");
                Console.WriteLine(wineItemToAdd + " has been added to the file");
                Console.WriteLine("**************************************************************************");
                Console.WriteLine();    
                
                
            }
        }

        /// <summary>
        /// Method to ouput any string to the console
        /// </summary>
        /// <param name="printOutput">string</param>
        public void PrintOutput (string printOutput)
        {
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.WriteLine(printOutput);
        }
        /// <summary>
        /// Outputs the Load Menu to the console
        /// </summary>
        private void LoadMenu()
        {
            Console.WriteLine("Welcome to the wine list program.");
            Console.WriteLine("To start the program you must load the wine list.");
            Console.WriteLine();
            Console.WriteLine("#############-Load Menu-#############");
            Console.WriteLine("1) Load Wine List");
            Console.WriteLine("2) Exit the program");
            Console.WriteLine("#############-Load Menu-#############");
            Console.Write("Press the number of the menu item: ");
        }

        /// <summary>
        /// Outputs the Main Menu to the console
        /// </summary>
        private void PrintMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("#############-Main Menu-#############");
            Console.WriteLine("1) Print Wine List");
            Console.WriteLine("2) Search for Wine");
            Console.WriteLine("3) Add a new Wine");
            Console.WriteLine("4) Exit the program");
            Console.WriteLine("#############-Main Menu-#############");

            Console.Write("Press the number of the menu item: ");

        }
        /// <summary>
        /// Outputs the Search Menu to the console
        /// </summary>
        private void PrintSearchMenu()
        {
            Console.WriteLine();
            Console.WriteLine("############-Search Menu-############");
            Console.WriteLine("1) Search by ID");
            Console.WriteLine("2) Search by Discription");
            Console.WriteLine("3) Search by Pack");
            Console.WriteLine("4) Return to Main Menu");
            Console.WriteLine("############-Search Menu-############");
            Console.Write("Press the number of the menu item: ");

        }

        /// <summary>
        /// Creates the wine list into a string for output
        /// </summary>
        /// <param name="WineCollection"></param>
        /// <returns></returns>
        public string CreateListString(WineItem[] WineCollection)
        {
            string headingString = Environment.NewLine + 
                "ID:   Description                                                      Pack" + Environment.NewLine;
            string listString = headingString;
            int count = 0;

            foreach (WineItem wineItem in WineCollection)
            {
                count++;

                if (wineItem != null)
                {
                    if (count % 20 == 0)
                    {
                        listString += headingString;
                    }
                    listString += $"{wineItem.ID,5} {wineItem.Description,-60} {wineItem.Pack,10}" + Environment.NewLine;
                }              
            }
            return listString;
        }
    }
}
