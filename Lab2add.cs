using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp74
{
    public class Lab2add
    {
        static void Main(string[] args)
        {
            TVector2D vec1 = new TVector2D();
            vec1.EnterVec();
            vec1.ShowVec();
            TVector2D vec2 = new TVector2D(22, 3);
            vec2.ShowVec();

            TVector2D vec3 = new TVector2D(vec1);
            vec3.ShowVec();
                Console.WriteLine(vec1.VecLength());
            vec1.VecNormal();
            vec1.VecEquals(vec2);
            
            Console.WriteLine(vec1 + vec2);
            Console.WriteLine(vec1 - vec2);
            Console.WriteLine(vec1 * vec2);
            //2)
            
            HashSet<TVector2D> hash = new HashSet<TVector2D>();
            hash.Add(vec1);

            if (hash.Contains(vec1))
            {
                Console.WriteLine("vector was found!");
            }
            else
            {
                Console.WriteLine("vector not found!");
            }
            TVector2DF vec4 = new TVector2DF(2,3);
            HashSet<TVector2DF> hash2 = new HashSet<TVector2DF>();
            TVector2DF vec5 = new TVector2DF(2,3);
            hash2.Add(vec4);
            Console.WriteLine(vec4.GetHashCode());
            Console.WriteLine(vec5.GetHashCode());
           
            if (vec5.Equals(hash2))
            {
                Console.WriteLine("vector was found!");
            }
            else
            {
                Console.WriteLine("vector not found!");
            }
            HashSet<TVector3D> hash3 = new HashSet<TVector3D>();
            TVector3D vec6 = new TVector3D(2, 3, 4);
            TVector3D vec7 = new TVector3D(2, 3, 5);
            TVector3D vec8 = new TVector3D(2, 3, 2);
            TVector3D vec9 = new TVector3D(2, 3, 7);
            TVector3D vec10 = new TVector3D(2, 3, 6);
            hash3.Add(vec6);
            hash3.Add(vec7);
            hash3.Add(vec8);
            hash3.Add(vec9);
            hash3.Add(vec10);
            Console.WriteLine(hash3.Count);

            HashSet<TVector3DF> hash4 = new HashSet<TVector3DF>();
            TVector3DF vec11 = new TVector3DF(2, 3, 4);
            TVector3DF vec12 = new TVector3DF(2, 3, 5);
            TVector3DF vec13 = new TVector3DF(2, 3, 2);
            TVector3DF vec14 = new TVector3DF(2, 3, 7);
            TVector3DF vec15 = new TVector3DF(2, 3, 6);
            hash4.Add(vec11);
            hash4.Add(vec12);
            hash4.Add(vec13);
            hash4.Add(vec14);
            hash4.Add(vec15);
            Console.WriteLine(hash4.Count);

        }
    }
    public class TVector2D
    {
        private double a_;
        private double b_;
        public double a
        {
            get { return a_; }
            set
            {
                a_ = value;
            }
        }
        public double b
        {
            get { return b_; }
            set
            {
                b_ = value;
            }
        }
        public TVector2D() { }
        public TVector2D(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public TVector2D(TVector2D vec)
        {
            this.a = vec.a;
            this.b = vec.b;
        }
        override public string ToString()
        {
            return "a: " + a + " " + "b: " + b;
        }
        public virtual void EnterVec()
        {
            Console.WriteLine("Enter a");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter b");
            int b = int.Parse(Console.ReadLine());
            this.a = a;
            this.b = b;
        }
        public virtual void EnterVec(double a, double b)
        {

            this.a = a;
            this.b = b;
        }
        public virtual void ShowVec()
        {

            Console.WriteLine("a: " + a + "  " + "b: " + b);
        }
        public virtual double VecLength()
        {
            return Math.Abs(Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)));
        }
        public virtual void VecNormal()
        {

            double n = a / this.VecLength();
            double m = b / this.VecLength();
            Console.WriteLine("Normalized Vec: (" + n + ";" + m + ")");

        }
        public virtual void VecEquals(TVector2D vec)
        {
            string equals = "";
            if (a == vec.a && b == vec.b)
            {
                equals = "Vec1 equals Vec2";
            }
            else
            {
                equals = "Vec1 not equals to vec2";
            }
            Console.WriteLine(equals);
        }

     

        public static TVector2D operator +(TVector2D a, TVector2D b)
        {
            double n = a.a + b.a;
            double m = a.b + b.b;
            TVector2D vec = new TVector2D(n, m);
            return vec;

        }
        public static TVector2D operator -(TVector2D a, TVector2D b)
        {
            double n = a.a - b.a;
            double m = a.b - b.b;
            TVector2D vec = new TVector2D(n, m);
            return vec;

        }
        public static double operator *(TVector2D a, TVector2D b)
        {
            double n = a.a * b.a;
            double m = a.b * b.b;

            return n + m;

        }
       
    }
    public class TVector2DF : TVector2D
    {
        public TVector2DF() { }
        public TVector2DF(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public TVector2DF(TVector2DF vec)
        {
            this.a = vec.a;
            this.b = vec.b;
        }
       
        override public bool Equals(object obj)
        {
            bool e = false;
            HashSet<TVector2DF> items = obj as HashSet<TVector2DF>;
            if (obj is TVector3D)
            {
                e = obj is TVector3D d &&
                    a == d.a &&
                    b == d.b;
            }
           else if (obj != null )
            {
               
                
                foreach (TVector2DF vec in items)
                { 
                    if (vec.GetHashCode()== this.GetHashCode())
                    {
                        e = true;
                    }
                }
               
            }
            
            return e;
                 
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(a, b);
        }
    }
    public class TVector3D : TVector2DF
    {
        private double c_;
        public double c
        {
            get { return c_; }
            set
            {
                c_ = value;
            }
        }
        public TVector3D() { }
        public TVector3D(double a, double b, double c) : base(a, b)
        {
            this.c = c;
        }
        public TVector3D(TVector3D vec)
        {
            this.a = vec.a;
            this.b = vec.b;
            this.c = vec.c;
        }
        override public string ToString()
        {
            return "a: " + a + " b: " + b + " c: " + c;
        }
        override public void EnterVec()
        {
            Console.WriteLine("Enter a");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter b");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter c");
            int c = int.Parse(Console.ReadLine());
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public void EnterVec(double a, double b, double c)
        {

            this.a = a;
            this.b = b;
            this.c = c;
        }
        override public void ShowVec()
        {

            Console.WriteLine("a: " + a + " b: " + b + " c: " + c);
        }
        override public double VecLength()
        {
            return Math.Abs(Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) + Math.Pow(c, 2)));
        }
        override public void VecNormal()
        {

            double n = a / this.VecLength();
            double m = b / this.VecLength();
            double z = c / this.VecLength();
            Console.WriteLine("Normalized Vec: (" + n + ";" + m + ";" + z + ")");

        }
        public void VecEquals(TVector3D vec)
        {

            if (a == vec.a && b == vec.b && c == vec.c)
            {
                Console.WriteLine("Vec1 equals Vec2");
            }
            else
            {
                Console.WriteLine("Vec1 not equals to vec2");
            }

        }
        public static TVector3D operator +(TVector3D a, TVector3D b)
        {
            double n = a.a + b.a;
            double m = a.b + b.b;
            double z = a.c + b.c;
            TVector3D vec = new TVector3D(n, m, z);
            return vec;

        }
        public static TVector3D operator -(TVector3D a, TVector3D b)
        {
            double n = a.a - b.a;
            double m = a.b - b.b;
            double z = a.c - b.c;
            TVector3D vec = new TVector3D(n, m, z);
            return vec;

        }
        public static double operator *(TVector3D a, TVector3D b)
        {
            double n = a.a * b.a;
            double m = a.b * b.b;
            double z = a.c * b.c;

            return n + m + z;

        }

    }
    public class TVector3DF : TVector3D
    {
        public TVector3DF() { }
        public TVector3DF(double a, double b, double c) 
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public TVector3DF(TVector3D vec)
        {
            this.a = vec.a;
            this.b = vec.b;
            this.c = vec.c;
        }
        override public bool Equals(object obj)
        {
            bool e = false;
            HashSet<TVector3DF> items = obj as HashSet<TVector3DF>;
            
            if (obj != null)
            {


                foreach (TVector3DF vec in items)
                {
                    if (vec.GetHashCode() == this.GetHashCode())
                    {
                        e = true;
                    }
                }

            }

            return e;

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(a, b, c);
        }
    }
}

