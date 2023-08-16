using System;
using System.Text.Json.Serialization;

namespace Task2Flowers.Entities
{
    public class MyColor : Entity, IEquatable<MyColor>
    {
        public String Title { get; }

        public Byte R { get; }
        public Byte G { get; }
        public Byte B { get; }

        //public static readonly MyColor Red = new("Red", 255, 0, 0);
        //public static readonly MyColor Green = new("Green", 0, 255, 0);
        //public static readonly MyColor Blue = new("Blue", 0, 0, 255);
        //public static readonly MyColor Black = new("Black", 0, 0, 0);
        //public static readonly MyColor White = new("White", 255, 255, 255);
        //public static readonly MyColor Yelow = new("Blue", 255, 255, 0);
        //public static readonly MyColor Cyan = new("Cyan", 0, 255, 255);
        //public static readonly MyColor Fuchsia = new("Fuchsia", 255, 0, 255);

        [JsonConstructor]
        public MyColor(int id, String title, Byte r, Byte g, Byte b)
        {
            this.Id = id;
            this.Title = title;
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public bool Equals(MyColor? obj)
        {
            if (obj is null || this is null)
            {
                return false;
            }

            return this.Title == obj.Title
                && this.G == obj.G
                && this.R == obj.R
                && this.B == obj.B;
        }

        public int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(this.Title);
            hashCode.Add(this.R);
            hashCode.Add(this.G);
            hashCode.Add(this.B);

            return hashCode.ToHashCode();
        }
    }
}
