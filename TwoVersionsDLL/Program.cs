using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoVersionsDLL.Interface;

namespace TwoVersionsDLL
{
    class Program
    {
        //REF http://dotnet.dzone.com/news/dll-heaven-multiple-versions-o
        //Se ejecutan dos versiones de una misma DLL
        //Para ello se utiliza el proyecto MockDLL, cambiando el string que devuelve el método Execute
        //Se crea un appDomain para cada versión, y se instancia la clase "VersionA"
        //Luego se invoca el método execute para ambas instancias y se observa que el resultado es distinto 
        //OUTPUT
        //Version A
        //Version B
        static void Main(string[] args)
        {
            // Create an app domain
            AppDomain appDomain1 = AppDomain.CreateDomain("VersionA");
            // Instantiate the object from the app doamin and the first version file
            object obj = appDomain1.CreateInstanceFromAndUnwrap(
                AppDomain.CurrentDomain.BaseDirectory + "\\MockDLLA.dll",
                "MockDLL.Class.VersionA");
            IExecute iex = (IExecute)obj;

            // Instantiate the object from the app doamin and the second version file
            AppDomain appDomain2 = AppDomain.CreateDomain("VersionB");
            object obj2 = appDomain2.CreateInstanceFromAndUnwrap(
                AppDomain.CurrentDomain.BaseDirectory + "\\MockDLLB.dll",
                "MockDLL.Class.VersionA");
            IExecute iex2 = (IExecute)obj2;

            Console.WriteLine(iex.Execute());
            Console.WriteLine(iex2.Execute());
            Console.ReadLine();
        }
    }
}
