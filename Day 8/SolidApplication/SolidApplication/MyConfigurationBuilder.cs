using SolidApplicationn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidApplication
{


    public class MyConfigurationBuilder
    {
        class MyConfiguration : MyApplicationConfiguration
        {

        }
        public MyApplicationConfiguration BuildConfiguration(int size, string name)
        {
            var obj = new MyConfiguration();
            obj.Size = size;
            obj.Label = name;
            return obj;
        }
    }
}