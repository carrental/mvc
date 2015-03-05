namespace CarRental.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public User()
        {
           
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string UserFullName { get; set; }


        [StringLength(100)]
        public string UserEmailAddress { get; set; }


        [StringLength(100)]
        public string UserPassword { get; set; }

    }
}
