using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Schema;
using System.Threading.Tasks;

namespace DotNet9Features._4___Json
{
    internal static class JsonStuff
    {
        public static void FeatureSchemeAsNode()
        {
            var options = JsonSerializerOptions.Default;
            var text = options.GetJsonSchemaAsNode(typeof(Person));
            Console.WriteLine(text);
        }

    }
    class Person
    {
        public string Name { get; set; }
        public DateOnly Birth { get; set; }
        public string? NickName { get; set; }
    }
}
