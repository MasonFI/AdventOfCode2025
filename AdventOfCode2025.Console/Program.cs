using AdventOfCode2025.Application.Day1;

namespace ConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Anna päivän numero (1–12): ");
            var input = Console.ReadLine();

            // Yritetään muuntaa syöte numeroksi
            if (!int.TryParse(input, out int paiva))
            {
                Console.WriteLine("Syötteen tulee olla numero.");
                return;
            }

            // Tarkistetaan että luku on välillä 1–12
            if (paiva < 1 || paiva > 12)
            {
                Console.WriteLine("Päivän numeron tulee olla välillä 1–12.");
                return;
            }

            // Suoritetaan päivän koodi
            RunDay(paiva);
        }

        static void RunDay(int paiva)
        {
            switch (paiva)
            {
                case 1:
                    Console.WriteLine("Suoritetaan päivän 1 koodi...");
                    
                    var instructions = InstructionsParserService.ParseFromFile("day1.txt");
                    var wheelService = new WheelService();

                    foreach (var instruction in instructions)
                    {
                        wheelService.RotateWheel(instruction.Direction, instruction.NumberOfRotations);    
                    }
                    
                    Console.WriteLine("Times wheel rotated precisely to zero: " + wheelService2.TimesWheelRotatedPreciselyToZero);
                    Console.WriteLine("Times wheel rotated over the zero: " + wheelService2.TimesWheelRotatedOverZero);
                    Console.WriteLine("Total: " + (wheelService2.TimesWheelRotatedPreciselyToZero + wheelService2.TimesWheelRotatedOverZero));
                    
                    break;

                case 2:
                    Console.WriteLine("Suoritetaan päivän 2 koodi...");
                    
                    break;

                case 3:
                    Console.WriteLine("Suoritetaan päivän 3 koodi...");
                    // TODO
                    break;

                // ...

                case 12:
                    Console.WriteLine("Suoritetaan päivän 12 koodi...");
                    // TODO
                    break;

                default:
                    Console.WriteLine("Tuntematon päivä.");
                    break;
            }
        }
    }
}