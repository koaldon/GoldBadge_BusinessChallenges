

using Challenge1_Cafe_Data;
using Challenge1_Cafe_Repository;
using Challenge1_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Cafe_ProgramUI
{
    public class Program
    {
       public static void Main(string [] args)
       {
            MenuApp app = new MenuApp();
            app.Run();
        }
    }
}
