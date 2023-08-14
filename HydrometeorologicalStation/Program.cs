namespace HydrometeorologicalStation
{
    internal class Program
    {
        static void Main()
        {
            HydrometeorologicalCentre hc = new HydrometeorologicalCentre(
                new Temperature(new DateTime(2023, 8, 13), 27),
                new Temperature(new DateTime(2023, 8, 14), 26),
                new Temperature(new DateTime(2023, 8, 15), 27),
                new Temperature(new DateTime(2023, 8, 16), 21),
                new Temperature(new DateTime(2023, 8, 17), 25),
                new Temperature(new DateTime(2023, 8, 18), 22),
                new Temperature(new DateTime(2023, 8, 19), 22),
                new Temperature(new DateTime(2023, 8, 20), 24));


            //hc.Add(new Temperature(new DateTime(2023, 8, 21), 19));
            //hc.Add(new Temperature(new DateTime(2023, 8, 22), 21));

            //var q = hc[new DateTime(2023, 8, 13), new DateTime(2023, 8, 20)];
            /*foreach (var x in q)
            {
                Console.WriteLine(x.GetTemperature());
            }*/


            //hc[new Temperature(DateTime.Now,19)]= new Temperature(DateTime.Now, 19);


            //hc.Add(new Temperature(new DateTime(2023, 8, 21), 19));
            //hc.Add(new Temperature(new DateTime(2023, 8, 22), 21));
            var q = hc[new DateTime(2023, 8, 13), new DateTime(2023, 8, 20)];

            q= hc[new DateTime(2023, 8, 18), new DateTime(2023, 8, 21)];
            Console.WriteLine();

            foreach (var x in q)
            {
                Console.WriteLine(x.GetTemperature());
            }
        }
    }
}