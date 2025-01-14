﻿using DOB.Entity.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOB.EntityTypeConfiguration
{
    public class ProductMap:EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasKey(p => p.Id);

            HasMany(od => od.OrderDetails)
                .WithRequired(p => p.Product)
                .HasForeignKey(pp => pp.ProductID)
                .WillCascadeOnDelete(false);

           HasMany(x => x.ProductsExtra)
                .WithMany(x=> x.Products)
                .Map(m =>
                {
                    m.ToTable("ProductExtra");
                    m.MapLeftKey("ProductID");
                    m.MapRightKey("ExtraID");
                });
        }
        
    }
}
