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

        public int GetUserStartMenu()
        {
            this.StartMenu();
            String _input = Console.ReadLine();
            while (_input != "1" && _input != "2")
            {
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                Console.WriteLine("Not a valid entry, please make another choice");
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                Console.WriteLine();
                this.StartMenu();
                _input = Console.ReadLine();
            }
            return Int16.Parse(_input);
        }

        public int GetUserInputMenu()
        {
            this.PrintMenu();
            String _input = Console.ReadLine();
            while (_input != "1" && _input != "2" && _input !="3" && _input != "4")
            {
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                Console.WriteLine("Not a valid entry, please make another choice");
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                Console.WriteLine();
                this.PrintMenu();
                _input = Console.ReadLine();
            }
            return Int16.Parse(_input);
        }


        public int GetUserInputSearch()
        {
            this.PrintSubMenu();

            String _input = Console.ReadLine();

            while (_input != "1" && _input != "2" && _input != "3" && _input != "4")
            {
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                Console.WriteLine("Not a valid entry, please make another choice");
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                Console.WriteLine();

                this.PrintSubMenu();

                _input = Console.ReadLine();
            }

            return Int16.Parse(_input);

        }

        public void SearchByID(WineItem[] WineCollection, CSVProcessor ExamineFile)
        {
            Console.Write("Enter ID: ");
            string input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine("XXXXXXXXXXXXX");
                Console.WriteLine("No ID entered");
                Console.WriteLine("XXXXXXXXXXXXX");
                Console.WriteLine();

            }
            else
            {
               PrintOutput( ExamineFile.SearchByID(WineCollection, input));
            }
        }

        public void SearchByDescription(WineItem[] WineCollection, CSVProcessor ExamineFile)
        {
            Console.Write("Enter Description: ");
            string input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXX");
                Console.WriteLine("No Descriptioin entered");
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXX");
                Console.WriteLine();

            }
            else
            {
                PrintOutput(ExamineFile.SearchByDescription(WineCollection, input));
            }
        }

        public void SearchByPack(WineItem[] WineCollection, CSVProcessor ExamineFile)
        {
            Console.Write("Enter Pack: ");
            string input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine("XXXXXXXXXXXXXXX");
                Console.WriteLine("No Pack entered");
                Console.WriteLine("XXXXXXXXXXXXXXX");
                Console.WriteLine();

            }
            else
            {
                PrintOutput(ExamineFile.SearchByPack(WineCollection, input));
            }
        }

        public void AddWine(WineItem[] WineCollection, CSVProcessor ExamineFile)
        {
            Console.Write("Enter Wine ID: ");
            string idInput = Console.ReadLine();
            if (idInput == "")
            {
                Console.WriteLine("XXXXXXXXXXXXXXXXXX");
                Console.WriteLine("No Wine ID entered");
                Console.WriteLine("XXXXXXXXXXXXXXXXXX");
                Console.WriteLine();

            }
            else
            {
                Console.Write("Enter Wine Description: ");
                string descriptionInput = Console.ReadLine();
                if (descriptionInput == "")
                {
                    Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXX");
                    Console.WriteLine("No Wine Description entered");
                    Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXX");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("Enter Wine Description: ");
                    string packInput = Console.ReadLine();
                    if (packInput == "")
                    {
                        Console.WriteLine("XXXXXXXXXXXXXXXXXXXX");
                        Console.WriteLine("No Wine Pack entered");
                        Console.WriteLine("XXXXXXXXXXXXXXXXXXXX");
                        Console.WriteLine();
                    }
                    else
                    {
                        WineItem wineItemToAdd = new WineItem();
                        wineItemToAdd.ID = idInput;
                        wineItemToAdd.Description = descriptionInput;
                        wineItemToAdd.Pack = packInput;

                        ExamineFile.AddWineItem(WineCollection, wineItemToAdd);
                        Console.WriteLine("**************************************************************************");
                        Console.WriteLine(wineItemToAdd + " has been added to the file");
                        Console.WriteLine("**************************************************************************");
                        Console.WriteLine();    
                    }
                }
            }
        }

        public void PrintOutput (string printOutput)
        {
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.WriteLine(printOutput);
        }

        private void StartMenu()
        {
            Console.WriteLine("Welcome to the wine list program.");
            Console.WriteLine("To start the program you must load the wine list.");
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1) Load Wine List");
            Console.WriteLine("2) Exit the program");
            Console.Write("Press the number of the menu item: ");

        }

        private void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1) Print Wine List");
            Console.WriteLine("2) Search for Wine");
            Console.WriteLine("3) Add a new Wine");
            Console.WriteLine("4) Exit the program");
            Console.Write("Press the number of the menu item: ");

        }

        private void PrintSubMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Menu: Search for Wine");
            Console.WriteLine("1) Search by ID");
            Console.WriteLine("2) Search by Discription");
            Console.WriteLine("3) Search by Pack");
            Console.WriteLine("4) Return to Main Menu");
            Console.Write("Press the number of the menu item: ");

        }

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
                    //listString += wineItem.ToString() + Environment.NewLine;
                }
                
            }
            return listString;
        }
    }
}
