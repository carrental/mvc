namespace CarRental.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Type")]
    public partial class CarType
    {
        public CarType()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
