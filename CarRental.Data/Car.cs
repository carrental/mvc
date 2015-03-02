namespace CarRental.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
    {
        public Car()
        {
            Orders = new HashSet<Order>();
        }

        public int id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Price { get; set; }

        public int TypeId { get; set; }

        [StringLength(256)]
        public string Photo { get; set; }

        [StringLength(100)]
        public string Brand { get; set; }

        public int Count { get; set; }

        public CarType Type { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
