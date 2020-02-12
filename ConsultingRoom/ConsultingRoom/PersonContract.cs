namespace ConsultingRoom
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonContract")]
    public partial class PersonContract
    {
        public int Id { get; set; }

        public int Person_Id { get; set; }

        public int Contract_Id { get; set; }
    }
}
