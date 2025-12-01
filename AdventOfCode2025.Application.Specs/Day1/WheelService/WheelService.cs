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
    public void ShouldReturnWheelPosition(IWheelService.RotationDirection direction, int numberOfRotations,
        int expectedWheelPositionAfterRotation)
    {
        var sut = new Application.Day1.WheelService();
        sut.RotateWheel(direction, numberOfRotations);
        
        sut.WheelCurrentPosition.ShouldBe(expectedWheelPositionAfterRotation);
    }
}