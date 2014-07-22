//==============================================//
// Content: 3D Vector class                     //
// File:    Vector.cs                           //
//                                              //
// Copyright (c) 2013, Max Giller               //
//==============================================//

#region Using-Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Cosmic.Collision
{
    /// <summary>
    /// 3D Vector
    /// </summary>
    public class Vector
    {
        #region Parameter (private)
        private float x, y, z;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Vector with the default value of 0 for x, y and z.
        /// </summary>
        public Vector()
        {
            this.x = this.y = this.z = 0;
        }

        /// <summary>
        /// Creates a new Vector with the given x, y and z values.
        /// </summary>
        /// <param name="_x">x-coordinate of the Vector.</param>
        /// <param name="_y">y-coordinate of the Vector.</param>
        /// <param name="_z">z-coordinate of the Vector.</param>
        public Vector(float _x, float _y, float _z)
        {
            this.x = _x;
            this.y = _y;
            this.z = _z;
        }
        #endregion

        #region Methods (public)
        /// <summary>
        /// Returns a new Vector with the default value of 0 for x, y and z.
        /// </summary>
        public static Vector Zero
        {
            get { return new Vector(0, 0, 0); }
        }

        /// <summary>
        /// Returns a new Vector with x = 1, y = 0 and z = 0.
        /// </summary>
        public static Vector UnitX
        {
            get { return new Vector(1.0f, 0.0f, 0.0f); }
        }

        /// <summary>
        /// Returns a new Vector with x = 0, y = 1 and z = 0.
        /// </summary>
        public static Vector UnitY
        {
            get { return new Vector(0.0f, 1.0f, 0.0f); }
        }

        /// <summary>
        /// Returns a new Vector with x = 0, y = 0 and z = 1.
        /// </summary>
        public static Vector UnitZ
        {
            get { return new Vector(0.0f, 0.0f, 1.0f); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "[x=" + this.x + " y=" + this.y + " z=" + this.z + "]";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj.GetType() == typeof(Vector) ? (((Vector)obj).X == this.x && ((Vector)obj).Y == this.y && ((Vector)obj).Z == this.z) : false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns the length of the vector.
        /// </summary>
        public float Length
        {
            get { return (float)Math.Sqrt(Math.Pow(this.x, 2.0f) + Math.Pow(this.y, 2.0f) + Math.Pow(this.z, 2.0f)); }
        }

        /// <summary>
        /// Returns a vector with the length 1 and the same direction as the parent vector.
        /// </summary>
        public Vector Normal
        {
            get { return (this / this.Length); }
        }

        /// <summary>
        /// Shrinks the vector to a length of 1 without changing its direction.
        /// </summary>
        public void Normalize()
        {
            Vector temp = this.Normal;
            this.x = temp.X;
            this.y = temp.Y;
            this.z = temp.Z;
        }

        /// <summary>
        /// Returns the distance between two given Vectors _v1 and _v2 as a float.
        /// </summary>
        /// <param name="_v1">Position of the first Vector.</param>
        /// <param name="_v2">Position of the second Vector.</param>
        /// <returns>Distance between the first and the second Vector.</returns>
        public static float Distance(Vector _v1, Vector _v2)
        {
            return (float)Math.Sqrt(Math.Pow(_v2.X - _v1.X, 2.0f) + Math.Pow(_v2.Y - _v1.Y, 2.0f) + Math.Pow(_v2.Z - _v1.Z, 2.0f));
        }

        /// <summary>
        /// Returns the cross product of two given vectors _v1 and _v2 as a vector.
        /// </summary>
        /// <param name="_v1"></param>
        /// <param name="_v2"></param>
        /// <returns></returns>
        public static Vector Cross(Vector _v1, Vector _v2)
        {
            return new Vector(_v1.Y * _v2.Z - _v1.Z * _v2.Y, _v1.Z * _v2.X - _v1.X * _v2.Z, _v1.X * _v2.Y - _v1.Y * _v2.X);
        }

        /// <summary>
        /// Returns the dot product of two given vectors _v1 and _v2 as a float  .
        /// </summary>
        /// <param name="_v1"></param>
        /// <param name="_v2"></param>
        /// <returns></returns>
        public static float Dot(Vector _v1, Vector _v2)
        {
            return (_v1.X * _v2.X + _v1.Y * _v2.Y + _v1.Z * _v2.Z);
        }
        #endregion

        #region Operator-Overloads
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_v1"></param>
        /// <param name="_v2"></param>
        /// <returns></returns>
        public static Vector operator +(Vector _v1, Vector _v2)
        {
            return new Vector(_v1.X + _v2.X, _v1.Y + _v2.Y, _v1.Z + _v2.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_v1"></param>
        /// <param name="_v2"></param>
        /// <returns></returns>
        public static Vector operator -(Vector _v1, Vector _v2)
        {
            return new Vector(_v1.X - _v2.X, _v1.Y - _v2.Y, _v1.Z - _v2.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_v1"></param>
        /// <returns></returns>
        public static Vector operator -(Vector _v1)
        {
            return new Vector(-_v1.X, -_v1.Y, -_v1.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_vector"></param>
        /// <param name="_constant"></param>
        /// <returns></returns>
        public static Vector operator *(Vector _vector, float _constant)
        {
            return new Vector(_vector.X * _constant, _vector.Y * _constant, _vector.Z * _constant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_constant"></param>
        /// <param name="_vector"></param>
        /// <returns></returns>
        public static Vector operator *(float _constant, Vector _vector)
        {
            return new Vector(_vector.X * _constant, _vector.Y * _constant, _vector.Z * _constant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_vector"></param>
        /// <param name="_constant"></param>
        /// <returns></returns>
        public static Vector operator /(Vector _vector, float _constant)
        {
            return new Vector(_vector.X / _constant, _vector.Y / _constant, _vector.Z / _constant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_v1"></param>
        /// <param name="_v2"></param>
        /// <returns></returns>
        public static float operator *(Vector _v1, Vector _v2)
        {
            return (_v1.X * _v2.X + _v1.Y * _v2.Y + _v1.Z * _v2.Z);
        }
        #endregion

        #region Getter/Setter
        /// <summary>
        /// Gets/sets the x-coordinate of the Vector.
        /// </summary>
        public float X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        /// <summary>
        /// Gets/sets the y-coordinate of the Vector.
        /// </summary>
        public float Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        /// <summary>
        /// Gets/sets the z-coordinate of the Vector.
        /// </summary>
        public float Z
        {
            get { return this.z; }
            set { this.z = value; }
        }
        #endregion
    }
}
