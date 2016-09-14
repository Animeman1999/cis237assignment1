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
            Console.WriteLine("Menu: Press the number of the item you wish to do.");
            Console.WriteLine("1) Load Wine List 2) Print Wine List 3) Search for Wine 4) Add a new Wine 5) Exit");

        }
    }
}
