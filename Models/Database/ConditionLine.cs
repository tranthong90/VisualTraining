namespace VisualTraining.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConditionLine")]
    public partial class ConditionLine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConditionLine()
        {
            ActivityLines = new HashSet<ActivityLine>();
            TherapyGoalLines = new HashSet<TherapyGoalLine>();
        }

        [Key]
        public int ConditionLineID { get; set; }

        public int ConditionID { get; set; }

        public int DiagnosisID { get; set; }

        [Required]
        [StringLength(20)]
        public string Level { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityLine> ActivityLines { get; set; }

        public virtual Condition Condition { get; set; }

        public virtual Diagnosi Diagnosi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TherapyGoalLine> TherapyGoalLines { get; set; }
    }
}
