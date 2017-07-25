namespace VisualTraining.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActivityLine")]
    public partial class ActivityLine
    {
        public ActivityLine()
        {
            Active = true;
        }

        [Key]
        public int ActivityLineID { get; set; }

        public int ConditionLineID { get; set; }

        public int SessionID { get; set; }

        [Required]
        [StringLength(200)]
        public string Note { get; set; }

        public bool Active { get; set; }

        public virtual ConditionLine ConditionLine { get; set; }

        public virtual Session Session { get; set; }
    }
}
