using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticScreenPrinterGui
{
    public interface IApplicationInterface
    {
        string FilePath { get; set; }
        int Interval { get; set; }
        void Execute();
    }
}
