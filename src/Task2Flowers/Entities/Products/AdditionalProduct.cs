﻿using System.Text.Json.Serialization;
using Task2Flowers.Entities.Types;

namespace Task2Flowers.Entities.Products
{
    public class AdditionalProduct : Product
    {
        public AdditionalProductType Type { get; }
        public string Title { get; }
        public MyColor Color { get; }
        public string Description { get; }

        [JsonConstructor]
        public AdditionalProduct(int id, AdditionalProductType type, string title, MyColor color, string description) : base(id)
        {
            this.Title = title;
            this.Type = type;
            this.Color = color;
            this.Description = description;
        }
    }
}
