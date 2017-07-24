namespace VisualTraining.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activity")]
    public partial class Activity
    {
        [Key]
        public int ActivityID { get; set; }

        public int ConditionID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public virtual Condition Condition { get; set; }
    }
}
