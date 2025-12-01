namespace AdventOfCode2025.Application.Day1;

public interface IWheelService
{
    public enum RotationDirection
    {
        Left,
        Right
    }
    
    /// <summary>
    /// Rotates the wheel to the direction specified the number of times specified.
    /// Returns the new position of the wheel.
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="numberOfRotations"></param>
    /// <returns></returns>
    void RotateWheel(RotationDirection direction, int numberOfRotations);
}

/// <summary>
/// Wheel that rotates left or right.
/// Has a starting position of 50.
/// Has a minimum and maximum position of 0 and 99,
/// the total positions of the wheel are therefore 100.
/// </summary>
public class WheelService(int wheelStaringPosition = 50, int wheelMinimumPosition = 0, 
    int wheelMaximumPosition = 99) : IWheelService
{
    public int WheelCurrentPosition { get; private set; } = wheelStaringPosition;
    
    private int WheelTotalPositionCount => wheelMaximumPosition - wheelMinimumPosition + 1;

    public int TimesWheelRotatedToZero { get; private set; } = 0;

    public void RotateWheel(IWheelService.RotationDirection direction, int numberOfRotations)
    {
        WheelCurrentPosition = direction switch
        {
            IWheelService.RotationDirection.Left => RotateLeft(numberOfRotations),
            IWheelService.RotationDirection.Right => RotateRight(numberOfRotations),
            _ => throw new UnknownRotationDirectionException(direction)
        };

        if (WheelCurrentPosition == 0)
        {
            TimesWheelRotatedToZero++;
        }

        return;
        
        int RotateLeft(int steps)
        {
            return ((WheelCurrentPosition - steps) % WheelTotalPositionCount + WheelTotalPositionCount) % WheelTotalPositionCount;
        }
        
        int RotateRight(int steps)
        {
            return ((WheelCurrentPosition + steps) % WheelTotalPositionCount + WheelTotalPositionCount) % WheelTotalPositionCount;
        }
    }
}

public class UnknownRotationDirectionException(IWheelService.RotationDirection direction)
    : Exception($"Unknown rotation direction: {direction}");