using System;
using System.Numerics;

namespace MoonTools.Core.Structs
{
    public struct Transform2D : IEquatable<Transform2D>
    {
        private static Transform2D _defaultTransform = new Transform2D
        {
            Position = Position2D.Zero,
            Rotation = 0,
            Scale = new Vector2(1, 1),
        };

        private Position2D _position;
        private float _rotation;
        private Vector2 _scale;

        public Matrix3x2 TransformMatrix { get; private set; }

        public Position2D Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                TransformMatrix = CreateTransformMatrix(value, Rotation, Scale);
            }
        }

        public float Rotation

        {
            get
            {
                return _rotation;
            }
            set
            {
                _rotation = value;
                TransformMatrix = CreateTransformMatrix(Position, value, Scale);
            }
        }

        public Vector2 Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
                TransformMatrix = CreateTransformMatrix(Position, Rotation, value);
            }
        }

        public static Transform2D DefaultTransform
        {
            get
            {
                return _defaultTransform;
            }
        }

        public Transform2D(Position2D position)
        {
            _position = position;
            _rotation = 0f;
            _scale = new Vector2(1, 1);
            TransformMatrix = CreateTransformMatrix(position, _rotation, _scale);
        }

        public Transform2D(Vector2 position)
        {
            _position = new Position2D(position.X, position.Y);
            _rotation = 0;
            _scale = new Vector2(1, 1);
            TransformMatrix = CreateTransformMatrix(_position, _rotation, _scale);
        }

        public Transform2D(Position2D position, float rotation)
        {
            _position = position;
            _rotation = rotation;
            _scale = new Vector2(1, 1);
            TransformMatrix = CreateTransformMatrix(_position, _rotation, _scale);
        }

        public Transform2D(Vector2 position, float rotation)
        {
            _position = new Position2D(position.X, position.Y);
            _rotation = rotation;
            _scale = new Vector2(1, 1);
            TransformMatrix = CreateTransformMatrix(_position, _rotation, _scale);
        }

        public Transform2D(Position2D position, float rotation, Vector2 scale)
        {
            _position = position;
            _rotation = rotation;
            _scale = scale;
            TransformMatrix = CreateTransformMatrix(_position, _rotation, _scale);
        }

        public Transform2D(Vector2 position, float rotation, Vector2 scale)
        {
            _position = new Position2D(position.X, position.Y);
            _rotation = rotation;
            _scale = scale;
            TransformMatrix = CreateTransformMatrix(_position, _rotation, _scale);
        }

        public Transform2D Compose(Transform2D other)
        {
            return new Transform2D(Position + other.Position, Rotation + other.Rotation, Scale * other.Scale);
        }

        private static Matrix3x2 CreateTransformMatrix(Position2D translation, float rotation, Vector2 scale)
        {
            return Matrix3x2.CreateScale(scale.X, scale.Y) *
                Matrix3x2.CreateRotation(rotation) *
                Matrix3x2.CreateTranslation(translation.X, translation.Y);
        }

        public override bool Equals(Object other)
        {
            if (other is Transform2D otherTransform)
            {
                return Equals(otherTransform);
            }

            return false;
        }

        public bool Equals(Transform2D other)
        {
            return TransformMatrix == other.TransformMatrix;
        }

        public override int GetHashCode()
        {
            return TransformMatrix.GetHashCode();
        }

        public static bool operator ==(Transform2D a, Transform2D b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Transform2D a, Transform2D b)
        {
            return !(a == b);
        }
    }
}
