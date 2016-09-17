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
            UserInterface ui = new UserInterface();

            int choice = ui.GetUserInput();

            while (choice != 5)
            {
                choice = ui.GetUserInput();
            }
        }
    }
}
