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
        private double x_;
        private double y_;

        public double x
        {
            get { return x_; }
            set
            {
                x_ = value;
            }
        }
        public double y
        {
            get { return y_; }
            set
            {
                y_ = value;
            }
        }
     
        public TVector2D() { }
        public TVector2D(double x, double y, double x2, double y2)
        {
            this.x = x2 - x;
            this.y = y2 - y;

        }
        public TVector2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public TVector2D(TVector2D vec)
        {
            this.x = vec.x;
            this.y = vec.y;
        }
        override public string ToString()
        {
            return "[x: " + (this.x) + " " + "y: " + (this.y) + "]";
        }
        public virtual void EnterVec()
        {
            Console.WriteLine("Enter a");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter b");
            double y = double.Parse(Console.ReadLine());
            this.x = x;
            this.y = y;
        }
        public virtual void EnterVec(double x, double y, double x2, double y2)
        {
            this.x = x2 - x;
            this.y = y2 - y;
        }
        public virtual void EnterVec(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public virtual void ShowVec()
        {
            Console.WriteLine("[x: " + this.x + " " + "y: " + this.y + "]");
        }
        public virtual double VecLength()
        {
            return Math.Abs(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
        }
        public virtual void VecNormal()
        {

            double n = x / this.VecLength();
            double m = y / this.VecLength();
            Console.WriteLine("Normalized Vec: (" + n + ";" + m + ")");

        }
        public virtual void VecEquals(TVector2D vec)
        {
            string equals = "";
            if (x == vec.x && y == vec.y)
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
            double n = a.x + b.x;
            double m = a.y + b.y;
            TVector2D vec = new TVector2D(n, m);
            return vec;

        }
        public static TVector2D operator -(TVector2D a, TVector2D b)
        {
            double n = a.x - b.x;
            double m = a.y - b.y;
            TVector2D vec = new TVector2D(n, m);
            return vec;

        }
        public static double operator *(TVector2D a, TVector2D b)
        {
            double n = a.x * b.x;
            double m = a.y * b.y;

            return n + m;

        }
       
    }
    public class TVector2DF : TVector2D
    {
        public TVector2DF() { }
        public TVector2DF(double x, double y, double x2, double y2)
        {
            this.x = x2 - x;
            this.y = y2 - y;

        }
        public TVector2DF(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public TVector2DF(TVector2D vec)
        {
            this.x = vec.x;
            this.y = vec.y;
        }

        override public bool Equals(object obj)
        {
            bool e = false;
            HashSet<TVector2DF> items = obj as HashSet<TVector2DF>;
            if (obj is TVector3D)
            {
                e = obj is TVector3D d &&
                    x == d.x &&
                    y == d.y;
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
            return HashCode.Combine(x, y);
        }
    }
    public class TVector3D : TVector2DF
    {
        private double z_;
        public double z
        {
            get { return z_; }
            set
            {
                z_ = value;
            }
        }
        public TVector3D() { }
        public TVector3D(double x, double y, double z) : base(x, y)
        {
            this.z = z;
        }
        public TVector3D(TVector3D vec)
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
        }
        public TVector3D(double x, double y, double x2, double y2, double z, double z2)
        {
            this.x = x2 - x;
            this.y = y2 - y;
            this.z = z2 - z;

        }
        override public void EnterVec()
        {
            Console.WriteLine("Enter a");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter b");
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter c");
            double z = double.Parse(Console.ReadLine());
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public void EnterVec(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        override public void ShowVec()
        {

            Console.WriteLine("[x: " + (x) + " y: " + (y) + " y: " + (z) + "]");
        }

        override public double VecLength()
        {
            return Math.Abs(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2)));
        }
        public new void VecNormal()
        {
            double n = x / this.VecLength();
            double m = y / this.VecLength();
            double k = z / this.VecLength();
            Console.WriteLine("Normalized Vec: (" + n + ";" + m + ";" + k + ")");
        }
        public void VecEquals(TVector3D vec)
        {

            if (x == vec.x && y == vec.y && z == vec.z)
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
            double n = a.x + b.x;
            double m = a.y + b.y;
            double k = a.z + b.z;
            TVector3D vec = new TVector3D(n, m, k);
            return vec;

        }
        public static TVector3D operator -(TVector3D a, TVector3D b)
        {
            double n = a.x - b.x;
            double m = a.y - b.y;
            double k = a.z - b.z;
            TVector3D vec = new TVector3D(n, m, k);
            return vec;

        }
        public static double operator *(TVector3D a, TVector3D b)
        {
            double n = a.x * b.x;
            double m = a.y * b.y;
            double k = a.z * b.z;

            return n + m + k;

        }

    }
    public class TVector3DF : TVector3D
    {
        public TVector3DF() { }
        public TVector3DF(double x, double y, double z)
        {
            this.z = z;
        }
        public TVector3DF(TVector3D vec)
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
        }
        public TVector3DF(double x, double y, double x2, double y2, double z, double z2)
        {
            this.x = x2 - x;
            this.y = y2 - y;
            this.z = z2 - z;

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
            return HashCode.Combine(x, y, z);
        }
    }
}


