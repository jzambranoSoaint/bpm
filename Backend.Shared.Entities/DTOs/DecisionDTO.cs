using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs
{
    public class DecisionDTO
    {
        private String decisionId { get; set; }
        private String decisionName { get; set; }
        private bool decisionResult { get; set; }
        private String decisionStatus { get; set; }

        public DecisionDTO() { }
    }
}
