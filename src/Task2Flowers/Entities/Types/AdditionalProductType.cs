﻿namespace Task2Flowers.Entities.Types
{
    public class AdditionalProductType: Entity
    {

        public string Title { get; }

        public AdditionalProductType(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }
    }
}
