using FluentAssertions;
using NUnit.Framework;

using MoonTools.Core.Structs;
using System.Numerics;

namespace Tests
{
    public class Position2DTest
    {
        [Test]
        public void PositionVectorAddition()
        {
            var one = new Position2D(1.3f, 3.5f);
            var two = new Position2D(4.8f, 0.9f);

            var result = one + two;
            result.X.Should().Be(6);
            result.Y.Should().Be(4);
        }

        [Test]
        public void PositionVectorNegativeAddition()
        {
            var one = new Position2D(1.4f, 2.8f);
            var two = new Position2D(-1, -2);

            var result = one + two;
            result.X.Should().Be(0);
            result.Y.Should().Be(0);
        }

        [Test]
        public void PositionVectorVector2Addition()
        {
            var one = new Position2D(1.6f, 3.4f);
            var two = new Vector2(8.2f, 4.7f);

            var result = one + two;
            result.X.Should().Be(9);
            result.Y.Should().Be(8);
        }

        [Test]
        public void PositionVectorSubtraction()
        {
            var one = new Position2D(1.3f, 3.5f);
            var two = new Position2D(4.8f, 0.9f);

            var result = one - two;
            result.X.Should().BeApproximately(-3.5f, 0.01f);
            result.Y.Should().BeApproximately(2.6f, 0.01f);
        }

        [Test]
        public void PositionVectorVector2Subtraction()
        {
            var one = new Position2D(5.4f, 7.6f);
            var two = new Vector2(4.2f, 1.2f);

            var result = one - two;
            result.X.Should().BeApproximately(1.2f, 0.01f);
            result.Y.Should().BeApproximately(6.4f, 0.01f);
        }

        [Test]
        public void Equals()
        {
            var one = new Position2D(5.2f, 4.7f);
            var two = new Position2D(5.1f, 4.4f);

            one.Equals(two).Should().BeTrue();
        }

        [Test]
        public void EqualsOperator()
        {
            var one = new Position2D(5.2f, 4.7f);
            var two = new Position2D(5.1f, 4.4f);

            (one == two).Should().BeTrue();
        }

        [Test]
        public void NotEquals()
        {
            var one = new Position2D(5.2f, 4.7f);
            var two = new Position2D(3.1f, 2.4f);

            one.Equals(two).Should().BeFalse();
        }

        [Test]
        public void NotEqualsOperator()
        {
            var one = new Position2D(5.2f, 4.7f);
            var two = new Position2D(3.1f, 2.4f);

            (one != two).Should().BeTrue();
        }
    }
}