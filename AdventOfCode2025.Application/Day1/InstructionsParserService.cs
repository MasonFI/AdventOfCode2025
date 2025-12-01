namespace AdventOfCode2025.Application.Day1;

public class RotationInstruction
{
    public IWheelService.RotationDirection Direction { get; set; }

    public int NumberOfRotations { get; set; }
}

public static class InstructionsParserService
{
    public static IEnumerable<RotationInstruction> ParseFromFile(string filepath)
    {
        var instructions = new List<RotationInstruction>();
        foreach (var line in File.ReadLines(filepath))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var directionChar = line[0];
            var direction = directionChar switch
            {
                'L' => IWheelService.RotationDirection.Left,
                'R' => IWheelService.RotationDirection.Right,
                _ => throw new Exception($"Virheellinen rivi, suuntaa ei voida lukea: {line}. ")
            };
            
            var numberPart = line[1..];

            if (!int.TryParse(numberPart, out int steps))
            {
                Console.WriteLine($"Virheellinen rivi, steppien määrää ei voida lukea: {line}");

                continue;
            }
            
            instructions.Add(new RotationInstruction { Direction = direction, NumberOfRotations = steps });
        }

        return instructions;
    }
}