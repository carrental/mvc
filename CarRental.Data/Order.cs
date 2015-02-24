namespace CarRental.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int id { get; set; }

        [StringLength(256)]
        public string text { get; set; }

        [StringLength(256)]
        public string description { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }

        [StringLength(256)]
        public string pick_location { get; set; }

        [StringLength(256)]
        public string drop_location { get; set; }

        public int car_id { get; set; }

        public int car_number { get; set; }

        public virtual Car Car { get; set; }
    }
}
