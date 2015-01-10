using HoochAndPexNet.Core;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoochAndPexNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var core = new ApplicationCore();
            core.Initialize();
            
            while(core.Update())
            {
                core.Draw();
            }
        }
    }
}
