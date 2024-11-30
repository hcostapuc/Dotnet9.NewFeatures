using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9Features._2___LinqStuff
{
    internal record Marathon(int Id, int RunnerId, DateOnly StartDate, TimeOnly RunnerConcludeTime);
}
