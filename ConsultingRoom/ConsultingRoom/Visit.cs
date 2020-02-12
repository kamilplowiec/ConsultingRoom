namespace ConsultingRoom
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visit")]
    public partial class Visit
    {
        public int Id { get; set; }

        public int Person_Id { get; set; }

        public int Doctor_Id { get; set; }

        public DateTime Date { get; set; }

        public bool VisitWasHeld { get; set; }

        public string Comment { get; set; }
    }
}
