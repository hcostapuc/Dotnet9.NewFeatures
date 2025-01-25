using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9Features._2___LinqStuff
{
    internal static class LinqStuff
    {
        internal static void DoLinqStuff()
        {

            var marathonCollection = new List<Marathon>
            {
                new(1,1,DateOnly.Parse("12/01/2024"),TimeOnly.Parse("01:10:00")),
                new(2,1,DateOnly.Parse("12/01/2024"),TimeOnly.Parse("01:10:00")),
                new(3,2,DateOnly.Parse("01/12/2022"),TimeOnly.Parse("00:48:00")),
                new(3,1,DateOnly.Parse("01/12/2022"),TimeOnly.Parse("00:48:00")),
                new(4,3,DateOnly.Parse("10/05/2023"),TimeOnly.Parse("02:30:00")),
                new(5,2,DateOnly.Parse("10/05/2023"),TimeOnly.Parse("02:30:00")),
                new(6,4,DateOnly.Parse("07/20/2022"),TimeOnly.Parse("04:10:00")),
                new(7,5,DateOnly.Parse("12/30/2023"),TimeOnly.Parse("03:14:00")),
                new(8,5,DateOnly.Parse("09/05/2021"),TimeOnly.Parse("03:59:00"))
            };
            AggregateFeature(marathonCollection);
            CountByFeature(marathonCollection);
        }

        private static void CountByFeature(List<Marathon> marathonCollection)
        {
            //countBy will return a dictionary with the key and the total of marathons that runner participated
            foreach (var marathon in marathonCollection.CountBy(x => x.RunnerId))
            {
                Console.WriteLine("\nCountBy");
                Console.WriteLine($"Runner id: {marathon.Key} | Total marathons: {marathon.Value}");
            }
        }

        private static void AggregateFeature(List<Marathon> marathonCollection)
        {
            //Instead of using select+groupby in order to know the total time peer runner use aggregateBy
            var groupedRunnerConcludeTimeCollection = marathonCollection.AggregateBy(x => x.RunnerId,//what is the key that will be gruppingby
                                        _ => TimeOnly.Parse("00:00:00"),//what is the initial value
                                        (time, item) => item.RunnerConcludeTime.Add(time.ToTimeSpan()));//what is the operation that will be done

            foreach (var runnerConcludeTime in groupedRunnerConcludeTimeCollection)
            {
                Console.WriteLine("AggregateBy");
                Console.WriteLine($"Runner id: {runnerConcludeTime.Key} | Total marathon time: {runnerConcludeTime.Value}");
            }
        }
    }
}
