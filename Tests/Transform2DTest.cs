using FluentAssertions;
using NUnit.Framework;

using MoonTools.Core.Structs;
using System.Numerics;

namespace Tests
{
    public class Transform2DTest
    {
        [Test]
        public void Equals()
        {
            var transformA = new Transform2D(new Position2D(0, 1), 4f, new Vector2(2, 1));
            var transformB = new Transform2D(new Position2D(0, 1), 4f, new Vector2(2, 1));

            transformA.Should().BeEquivalentTo(transformB);
        }

        [Test]
        public void NotEquals()
        {
            var transformA = new Transform2D(new Position2D(2, 3));
            var transformB = new Transform2D(new Position2D(5, 1));

            transformA.Should().NotBeEquivalentTo(transformB);
        }

        [Test]
        public void EqualsOperator()
        {
            var transformA = new Transform2D(new Position2D(0, 1), 4f, new Vector2(2, 1));
            var transformB = new Transform2D(new Position2D(0, 1), 4f, new Vector2(2, 1));

            (transformA == transformB).Should().BeTrue();
        }

        [Test]
        public void NotEqualsOperator()
        {
            var transformA = new Transform2D(new Position2D(2, 3));
            var transformB = new Transform2D(new Position2D(5, 1));

            (transformA != transformB).Should().BeTrue();
        }

        [Test]
        public void Compose()
        {
            var transformA = new Transform2D(new Position2D(4, 1), (float)System.Math.PI / 2, new Vector2(3, 1));
            var transformB = new Transform2D(new Position2D(15, 2), (float)System.Math.PI / 4, new Vector2(1, 2));

            transformA.Compose(transformB).Should().BeEquivalentTo(new Transform2D(new Position2D(19, 3), 3 * (float)System.Math.PI / 4, new Vector2(3, 2)));
        }
    }
}