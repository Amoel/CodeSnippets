//==============================================//
// Content: Sphere class                        //
// File:    Sphere.cs                           //
//                                              //
// Copyright (c) 2013, Max Giller               //
//==============================================//

#region Using-Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Cosmic.Collision
{
    /// <summary>
    /// Sphere containing a Vector center and a float radius.
    /// </summary>
    public class Sphere
    {
        #region Parameter (private)
        private Vector center;
        private float radius;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructs a new Sphere with the default position of x=0, y=0, z=0 and a radius of 0.0f.
        /// </summary>
        public Sphere()
        {
            this.center = Vector.Zero;
            this.radius = 0.0f;
        }

        /// <summary>
        /// Constructs a new sphere with the given parameters.
        /// </summary>
        /// <param name="_center">The center of the sphere.</param>
        /// <param name="_radius">The radius of the sphere.</param>
        public Sphere(Vector _center, float _radius)
        {
            this.center = _center;
            this.radius = _radius;
        }

        /// <summary>
        /// Constructs a new sphere with the given parameters.
        /// </summary>
        /// <param name="_center">The center of the sphere.</param>
        /// <param name="_pointOnSphereSurface">A point on the surface of the sphere.</param>
        public Sphere(Vector _center, Vector _pointOnSphereSurface)
        {
            this.center = _center;
            this.radius = Vector.Distance(_center, _pointOnSphereSurface);
        }
        #endregion

        #region Methods (public)
        /// <summary>
        /// Checks if the sphere intersects with a given sphere.
        /// </summary>
        /// <param name="_sphere"></param>
        /// <returns></returns>
        public bool Intersects(Sphere _sphere)
        {
            return (radius > 0.0f ? (Vector.Distance(this.center, _sphere.Center) < this.radius + _sphere.Radius) : false);
        }

        /// <summary>
        /// Checks if two given spheres intersect with each other.
        /// </summary>
        /// <param name="_first">First sphere.</param>
        /// <param name="_second">Second sphere.</param>
        /// <returns></returns>
        public static bool Intersects(Sphere _first, Sphere _second)
        {
            return (radius > 0.0f ? (Vector.Distance(_first.Center, _second.Center) < _first.Radius + _second.Radius) : false);
        }

        /// <summary>
        /// Returns the distance of the sphere surface from another sphere surface.
        /// </summary>
        /// <param name="_sphere"></param>
        /// <returns></returns>
        public float SurfaceDistance(Sphere _sphere)
        {
            return Vector.Distance(this.Center, _sphere.Center) - (this.Radius + _sphere.Radius);
        }

        /// <summary>
        /// Return the distance between the distance of the surfaces of two given spheres.
        /// </summary>
        /// <param name="_first">First sphere.</param>
        /// <param name="_second">Second sphere.</param>
        /// <returns></returns>
        public static float SurfaceDistance(Sphere _first, Sphere _second)
        {
            return Vector.Distance(_first.Center, _second.Center) - (_first.Radius + _second.Radius);
        }
        #endregion

        #region Getter/Setter
        /// <summary>
        /// Gets/sets the center of the sphere.
        /// </summary>
        public Vector Center
        {
            get { return this.center; }
            set { this.center = value; }
        }

        /// <summary>
        /// Gets/sets the radius of the sphere.
        /// </summary>
        public float Radius
        {
            get { return this.radius; }
            set
            {
                this.radius = Math.Max(0.0f, value);
            }
        }
        #endregion
    }
}
