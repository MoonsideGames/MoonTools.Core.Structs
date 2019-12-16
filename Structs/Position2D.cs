using System;
using System.Numerics;

namespace MoonTools.Core.Structs
{
    public struct Position2D : IEquatable<Position2D>
    {
        private Vector2 remainder;

        private int _x;
        private int _y;

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                remainder.X = 0;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                remainder.Y = 0;
            }
        }

        public Position2D(float X, float Y)
        {
            _x = Floor(X);
            _y = Floor(Y);
            remainder = new Vector2(Remainder(X), Remainder(Y));
        }

        public Vector2 ToVector2()
        {
            return new Vector2
            {
                X = X + remainder.X,
                Y = Y + remainder.Y
            };
        }

        public Position2D Truncated()
        {
            return new Position2D(X, Y);
        }

        public static Position2D Zero
        {
            get
            {
                return new Position2D { X = 0, Y = 0 };
            }
        }

        public static implicit operator Vector2(Position2D positionVector)
        {
            return positionVector.ToVector2();
        }

        public static explicit operator Position2D(Vector2 vector)
        {
            return new Position2D(vector.X, vector.Y);
        }

        public static Position2D operator +(Position2D value1, Position2D value2)
        {
            var newRemainder = new Vector2
            {
                X = value1.remainder.X + value2.X + value2.remainder.X,
                Y = value1.remainder.Y + value2.Y + value2.remainder.Y
            };

            var xAmount = Floor(newRemainder.X);
            var yAmount = Floor(newRemainder.Y);
            newRemainder.X -= xAmount;
            newRemainder.Y -= yAmount;

            return new Position2D
            {
                X = value1.X + xAmount,
                Y = value1.Y + yAmount,
                remainder = newRemainder
            };
        }

        public static Position2D operator +(Position2D value1, Vector2 value2)
        {
            var newRemainder = new Vector2
            {
                X = value1.remainder.X + value2.X,
                Y = value1.remainder.Y + value2.Y
            };

            var xAmount = Floor(newRemainder.X);
            var yAmount = Floor(newRemainder.Y);
            newRemainder.X -= xAmount;
            newRemainder.Y -= yAmount;

            return new Position2D
            {
                X = value1.X + xAmount,
                Y = value1.Y + yAmount,
                remainder = newRemainder
            };
        }

        public static Vector2 operator -(Position2D value1, Position2D value2)
        {
            return value1.ToVector2() - value2.ToVector2();
        }

        public static Vector2 operator -(Position2D value1, Vector2 value2)
        {
            return value1.ToVector2() - value2;
        }

        private static int Whole(float value)
        {
            return (int)Math.Truncate(value);
        }

        private static float Remainder(float value)
        {
            return value - (float)Math.Truncate(value);
        }

        private static int Round(float value)
        {
            return (int)Math.Round(value, 0);
        }

        private static int Floor(float value)
        {
            return (int)Math.Floor(value);
        }

        public override bool Equals(object other)
        {
            if (other is Position2D otherPosition)
            {
                return Equals(otherPosition);
            }

            return false;
        }

        public bool Equals(Position2D other)
        {
            return
                X == other.X &&
                Y == other.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public static bool operator ==(Position2D a, Position2D b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Position2D a, Position2D b)
        {
            return !(a == b);
        }
    }
}
