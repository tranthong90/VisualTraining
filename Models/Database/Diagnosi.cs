namespace VisualTraining.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Diagnosi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diagnosi()
        {
            ConditionLines = new HashSet<ConditionLine>();
            Sessions = new HashSet<Session>();
            Created = new DateTime();
            Modified = new DateTime();
        }

        [Key]
      
        public int DiagnosisID { get; set; }

        public int PatientID { get; set; }

        [Column(TypeName = "money")]
        public decimal Optometrist { get; set; }

        public int StatusID { get; set; }

        public int NoOfSession { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConditionLine> ConditionLines { get; set; }

        public virtual Patient Patient { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Session> Sessions { get; set; }

        [Column(TypeName = "date")]
        public DateTime Created { get; set; }

        [Column(TypeName = "date")]
        public DateTime Modified { get; set; }


    }
}
