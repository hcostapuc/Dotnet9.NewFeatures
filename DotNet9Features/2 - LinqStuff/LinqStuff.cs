using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9Features._2___LinqStuff
{
    internal static class LinqStuff
    {
        internal static void DoLiqnStuff()
        {
            var totalDurationTimeCollection = new List<(int Id, TimeOnly Duration)>();

            var movieCollection = new List<Marathon>
            {
                new(1,1,DateOnly.Parse("12/01/2024"),TimeOnly.Parse("01:10:00")),
                new(2,1,DateOnly.Parse("12/01/2024"),TimeOnly.Parse("01:10:00")),
                new(3,2,DateOnly.Parse("01/12/2022"),TimeOnly.Parse("00:48:10")),
                new(3,1,DateOnly.Parse("01/12/2022"),TimeOnly.Parse("00:48:10")),
                new(4,3,DateOnly.Parse("10/05/2023"),TimeOnly.Parse("02:30:00")),
                new(5,4,DateOnly.Parse("07/20/2022"),TimeOnly.Parse("04:10:00")),
                new(6,5,DateOnly.Parse("12/30/2023"),TimeOnly.Parse("03:14:56")),
                new(7,5,DateOnly.Parse("09/05/2021"),TimeOnly.Parse("03:59:12"))
            };

            //Instead of select+group by in order to know the total of runner 
            foreach (var movie in movieCollection)
            {
                totalDurationTimeCollection.Add((movie.Id, movie.Duration));
            }
        }
    }
}
