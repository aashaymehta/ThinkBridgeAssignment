using System;

namespace ShopBridge.Inventory.DomainModel
{
    public class Item
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

    }
}
