using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFlightRouthBetweenTwoDestinations
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Tuple<string, string>> flights = new List<Tuple<string, string>>();
            flights.Add(new Tuple<string, string>("A", "B"));
            flights.Add(new Tuple<string, string>("A", "C"));
            flights.Add(new Tuple<string, string>("B", "C"));
            flights.Add(new Tuple<string, string>("B", "D"));
            flights.Add(new Tuple<string, string>("D", "E"));

             var flightPath = FindFlightPath(flights, "A", "D");
            Console.WriteLine(string.Join(" => ", flightPath.ToArray()));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press ANY key to continue!");
            Console.ReadKey();
        }

        private static List<string> FindFlightPath(List<Tuple<string, string>> flights, string source, string destination)
        {
            if (source == destination)
                return new List<string>(new string[] { source });

            Stack<string> path = new Stack<string>();
            path.Push(source);

            var sources = flights.Where(x => x.Item1 == source).Select(x => x.Item2).ToList();
            if (FindFlightPath(flights, sources, destination, path))
            {
                List<string> flightPath = path.ToList();
                flightPath.Reverse();

                return flightPath;
            }

            return new List<string>(new string[] { "Path not found or not exists" });
        }

        private static bool FindFlightPath(List<Tuple<string, string>> flights, List<string> sources, string desiredDestination, Stack<string> path)
        {
            var availableDestinations = new Dictionary<string, List<string>>();
            foreach (var source in sources)
            {
                // Break condition
                if (source == desiredDestination)
                {
                    path.Push(source);
                    return true;
                }

                // Fill next connections
                var desinations = flights.Where(x => x.Item1 == source).Select(x => x.Item2).ToList();
                availableDestinations.Add(source, desinations);
            }

            foreach (var destination in availableDestinations)
            {
                // Add connection we about to test
                path.Push(destination.Key);

                if (FindFlightPath(flights, destination.Value, desiredDestination, path))
                    return true;

                // Remove tested destination as irrelevnat
                path.Pop();
            }

            return false;
        }
    }
}
