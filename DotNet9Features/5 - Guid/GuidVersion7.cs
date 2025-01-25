using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9Features._5___Guid
{
    internal static class GuidVersion7
    {
        internal static void GenerateGuidVersion7()
        {
            Console.WriteLine(Guid.CreateVersion7());
            Console.WriteLine(Guid.CreateVersion7());
            Console.WriteLine(Guid.CreateVersion7());
        }
    }
}
