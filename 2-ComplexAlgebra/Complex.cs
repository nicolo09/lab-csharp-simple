namespace ComplexAlgebra
{
    using System;
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex : IEquatable<Complex>
    {
        public double Real { get; private set; }
        public double Imaginary { get; private set; }
        public double Phase { get => Math.Atan2(Imaginary, Real); }
        public double Modulus { get => Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2)); }


        public Complex(double real, double imm)
        {
            Real = real;
            Imaginary = imm;
        }
        public Complex Complement()
        {
            return new Complex(Real, -Imaginary);
        }

        public Complex Plus(Complex a)
        {
            return new Complex(Real + a.Real, Imaginary + a.Imaginary);
        }

        public Complex Minus(Complex a)
        {
            return new Complex(Real-a.Real,Imaginary-a.Imaginary);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Complex);
        }

        public bool Equals(Complex other)
        {
            return other != null &&
                   Real == other.Real &&
                   Imaginary == other.Imaginary;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary);
        }
        public override string ToString()
        {
            if (Imaginary >= 0)
            {
                return Real.ToString() + " + i" + Imaginary.ToString();
            }
            else
            {
                return Real.ToString() + " - i" + Math.Abs(Imaginary).ToString();
            }
        }
    }
}