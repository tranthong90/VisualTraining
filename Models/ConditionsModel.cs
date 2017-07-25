using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualTraining.Models
{
    public class ConditionsModel
    {
        public int DiagnosisId { get; set; }
        public List<int> SelectedConditions { get; set; }
    }
}