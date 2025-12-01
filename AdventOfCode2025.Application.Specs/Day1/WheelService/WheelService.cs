using AdventOfCode2025.Application.Day1;
using Shouldly;
using Xunit;

namespace AdventOfCode2025.Tests.Day1.WheelService;

public class WheelServiceSpecs
{
    [Theory]
    [InlineData(IWheelService.RotationDirection.Left, 49, 1)]
    [InlineData(IWheelService.RotationDirection.Left, 50, 0)]
    [InlineData(IWheelService.RotationDirection.Left, 51, 99)]
    [InlineData(IWheelService.RotationDirection.Left, 151, 99)]
    [InlineData(IWheelService.RotationDirection.Left, 199, 51)]
    [InlineData(IWheelService.RotationDirection.Left, 351, 99)]
    [InlineData(IWheelService.RotationDirection.Right, 49, 99)]
    [InlineData(IWheelService.RotationDirection.Right, 50, 0)]
    [InlineData(IWheelService.RotationDirection.Right, 51, 1)]
    [InlineData(IWheelService.RotationDirection.Right, 151, 1)]
    [InlineData(IWheelService.RotationDirection.Right, 199, 49)]
    [InlineData(IWheelService.RotationDirection.Right, 399, 49)]
    public void ShouldSetWheelCurrentPosition(IWheelService.RotationDirection direction, int numberOfRotations,
        int expectedWheelPositionAfterRotation)
    {
        var sut = new Application.Day1.WheelService();
        sut.RotateWheel(direction, numberOfRotations);
        
        sut.WheelCurrentPosition.ShouldBe(expectedWheelPositionAfterRotation);
    }

    [Theory]
    [InlineData(IWheelService.RotationDirection.Left, 50, 1)]
    [InlineData(IWheelService.RotationDirection.Left, 49, 0)]
    [InlineData(IWheelService.RotationDirection.Left, 51, 0)]
    [InlineData(IWheelService.RotationDirection.Right, 49, 0)]
    [InlineData(IWheelService.RotationDirection.Right, 50, 1)]
    [InlineData(IWheelService.RotationDirection.Right, 51, 0)]
    public void ShouldSetTimesWheelRotatedPreciselyToZero(IWheelService.RotationDirection direction, int numberOfRotations,
        int timesWheelRotatedPreciselyToZero)
    {
        var sut = new Application.Day1.WheelService();
        sut.RotateWheel(direction, numberOfRotations);
        
        sut.TimesWheelRotatedPreciselyToZero.ShouldBe(timesWheelRotatedPreciselyToZero);
    }
    
    [Theory]
    [InlineData(IWheelService.RotationDirection.Left, 50, 50, 0)]
    [InlineData(IWheelService.RotationDirection.Left, 50,51, 1)]
    [InlineData(IWheelService.RotationDirection.Left, 50,49, 0)]
    [InlineData(IWheelService.RotationDirection.Left, 50,149, 1)]
    [InlineData(IWheelService.RotationDirection.Left, 50,151, 2)]
    [InlineData(IWheelService.RotationDirection.Left, 50,351, 4)]
    [InlineData(IWheelService.RotationDirection.Right, 50,49, 0)]
    [InlineData(IWheelService.RotationDirection.Right, 50,149, 1)]
    [InlineData(IWheelService.RotationDirection.Right, 50,50, 0)]
    [InlineData(IWheelService.RotationDirection.Right, 50,51, 1)]
    [InlineData(IWheelService.RotationDirection.Right, 50,151, 2)]
    [InlineData(IWheelService.RotationDirection.Right, 50,351, 4)]
    [InlineData(IWheelService.RotationDirection.Left, 0,1, 0)]
    [InlineData(IWheelService.RotationDirection.Left, 0,100, 0)]
    [InlineData(IWheelService.RotationDirection.Left, 0,101, 1)]
    [InlineData(IWheelService.RotationDirection.Right, 0,1, 0)]
    [InlineData(IWheelService.RotationDirection.Right, 0,100, 0)]
    [InlineData(IWheelService.RotationDirection.Right, 0,101, 1)]
    [InlineData(IWheelService.RotationDirection.Right, 99,1, 0)]
    [InlineData(IWheelService.RotationDirection.Right, 99,2, 1)]
    [InlineData(IWheelService.RotationDirection.Right, 99,3, 1)]
    [InlineData(IWheelService.RotationDirection.Left, 99,1, 0)]
    [InlineData(IWheelService.RotationDirection.Left, 99,99, 0)]
    [InlineData(IWheelService.RotationDirection.Left, 99,100, 1)]
    [InlineData(IWheelService.RotationDirection.Left, 99,199, 1)]
    public void ShouldSetTimesWheelRotatedOverZero(IWheelService.RotationDirection direction,
        int startPosition,
        int numberOfRotations,
        int timesWheelRotatedOverZero)
    {
        var sut = new Application.Day1.WheelService(startPosition);
        sut.RotateWheel(direction, numberOfRotations);
        
        sut.TimesWheelRotatedOverZero.ShouldBe(timesWheelRotatedOverZero);
    }
}