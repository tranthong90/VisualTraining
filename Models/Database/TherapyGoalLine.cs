namespace VisualTraining.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TherapyGoalLine")]
    public partial class TherapyGoalLine
    {
        [Key]
        public int TherapyGoalLineID { get; set; }

        public int ConditionLineID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public virtual ConditionLine ConditionLine { get; set; }
    }
}
