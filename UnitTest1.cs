using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp74;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                double s = r.Next(-1000, 1000);
                double g = r.Next(-1000, 1000);
                TVector2D vec2d = new TVector2D(s, g);

                double s2 = r.Next(-1000, 1000);
                double g2 = r.Next(-1000, 1000);
                TVector2D vec2d2 = new TVector2D(s2, g2);

                TVector2D vec = new TVector2D(vec2d + vec2d2);
                Assert.AreEqual(s + s2, vec.x);

            }
            for (int i = 0; i < 20; i++)
            {
                double s = r.Next(-1000, 1000);
                double g = r.Next(-1000, 1000);
                TVector2D vec2d = new TVector2D(s, g);

                double s2 = r.Next(-1000, 1000);
                double g2 = r.Next(-1000, 1000);
                TVector2D vec2d2 = new TVector2D(s2, g2);

                TVector2D vec = new TVector2D(vec2d + vec2d2);
                Assert.AreEqual(g + g2, vec.y);
                Assert.AreEqual(s + s2, vec.x);

            }
            for (int i = 0; i < 20; i++)
            {
                double s = r.Next(-1000, 1000);
                double g = r.Next(-1000, 1000);
                TVector2D vec2d = new TVector2D(s, g);

                double s2 = r.Next(-1000, 1000);
                double g2 = r.Next(-1000, 1000);
                TVector2D vec2d2 = new TVector2D(s2, g2);



                Assert.AreEqual(vec2d * vec2d2, (s * s2) + (g * g2));

            }
            
            for (int i = 0; i < 20; i++)
            {
                double s = r.Next(-1000, 1000);
                double g = r.Next(-1000, 1000);
                double z = r.Next(-1000, 1000);
                TVector3D vec2d = new TVector3D(s, g, z);

                double s2 = r.Next(-1000, 1000);
                double g2 = r.Next(-1000, 1000);
                double z2 = r.Next(-1000, 1000);
                TVector3D vec2d2 = new TVector3D(s2, g2, z2);
                TVector3D vec = new TVector3D(vec2d - vec2d2);
                Console.WriteLine(vec);
                Console.WriteLine(s-s2);
                Assert.AreEqual(vec.x, s - s2);
                Assert.AreEqual(vec.y, g - g2);
                Assert.AreEqual(vec.z, z - z2);
            }
        }
    }
}
