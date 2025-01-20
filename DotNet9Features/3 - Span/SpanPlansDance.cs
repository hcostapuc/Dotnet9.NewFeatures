using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9Features._3___Span
{
    
    internal static class SpanPlansDance
    {
        internal static void DoSpanPlansDance()
        {
            ReadOnlySpanAsKeyFeature();

            ReadOnlyAsParamsFeature(1, 2, 3, 2, 5, 6);

            ReadOnlyAsHashSetFeature();
        }

        private static void ReadOnlyAsHashSetFeature()
        {
            //Simple representation of a hasset in readonly mode
            var hasSet = new HashSet<string>();

            var readOnlySet = new ReadOnlySet<string>(hasSet);
        }

        /// <summary>
        /// The benefit to use ReadOnlySpan as params is that you can pass a collection of numbers without the need to create a new array
        /// more performance less memory alocation
        /// </summary>
        /// <param name="numbers"></param>
        static void ReadOnlyAsParamsFeature(params ReadOnlySpan<int> numbers)
        {
            int sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine(sum);
        }

        private static void ReadOnlySpanAsKeyFeature()
        {
            var dictionary = new Dictionary<string, int>
            {
                ["Hello"] = 45,
                [" World"] = 98
            };

            //ReadOnlySpan<char> is a readonly view of a memory block that contains characters the light representation of a string
            ReadOnlySpan<char> helloWorld = "Hello, World";

            var splitRange = helloWorld.Split(',');

            var altDictionary = dictionary.GetAlternateLookup<ReadOnlySpan<char>>();//why not use ReadOnlySpan<char> as key? Cause doens't support that type

            foreach (var range in splitRange)
            {
                ReadOnlySpan<char> key = helloWorld[range];
                Console.WriteLine(altDictionary[key]);
            }
        }
    }
}
