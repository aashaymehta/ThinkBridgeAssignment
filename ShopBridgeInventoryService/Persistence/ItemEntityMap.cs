using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopBridge.Inventory.DomainModel;

namespace ShopBridge.Inventory.Persistence
{
    class ItemEntityMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.Name).HasColumnName("Name");
            builder.Property(t => t.Price).HasColumnName("Price");
            builder.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
