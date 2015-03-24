using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoVersionsDLL.Interface;

namespace MockDLL.Class
{
    public class VersionA: MarshalByRefObject, IExecute
    {
        public string Execute()
        {
            return "Version A";
            //return "Version B";
        }
    }
}
