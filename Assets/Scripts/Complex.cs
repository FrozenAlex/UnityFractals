
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComplexMath
{
    
    // Complex num
    public class Complex
    {
        public float r;
        public float i;

        public Complex(float r, float i)
        {
            this.r = r;
            this.i=i;
        }


        // Complex operations 
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.r - b.r, a.i - b.i);
        }

        public static Complex operator -(Complex a, float b)
        {
            return new Complex(a.r - b, a.i);
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.r + b.r, a.i + b.i);
        }

        public static Complex operator +(Complex a, float b)
        {
            return new Complex(a.r + b, a.i);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            float x, y;

            x = a.r * b.r - a.i * b.i;
            y = a.r * b.i + a.i * b.r;
            return new Complex(x, y);
        }

        public static Complex operator *(Complex a, float b)
        {
            return new Complex(a.r * b, a.i * b);
        }

        public float Module()
        {
            return Mathf.Sqrt((float)(r * r + i * i));
        }

        public override string ToString()
        {
            return this.r.ToString() + "  " + this.i.ToString() + i;
        }
    }
}
