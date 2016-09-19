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
        public int GetUserInput()
        {
            this.PrintMenu();

            String _input = Console.ReadLine();
            
            while (_input != "1" && _input != "2" && _input !="3" && _input != "4" && _input != "5")
            {
                Console.WriteLine("Not a valid entry, please make another choice");
                Console.WriteLine();

                this.PrintMenu();

                _input = Console.ReadLine();
            }

            return Int16.Parse(_input);

        }

        public void PrintOutput (string printOutput)
        {
            Console.WriteLine(printOutput);
        }

        private void PrintMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1) Load Wine List");
            Console.WriteLine("2) Print Wine List");
            Console.WriteLine("3) Search for Wine");
            Console.WriteLine("4) Add a new Wine");
            Console.WriteLine("5) Exit");
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
