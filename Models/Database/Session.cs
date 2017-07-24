namespace VisualTraining.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Session")]
    public partial class Session
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Session()
        {
            ActivityLines = new HashSet<ActivityLine>();
        }

        [Key]
        public int SessionID { get; set; }

        public int WeekNo { get; set; }

        public int DiagnosisID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityLine> ActivityLines { get; set; }

        public virtual Diagnosis Diagnosi { get; set; }
    }
}
