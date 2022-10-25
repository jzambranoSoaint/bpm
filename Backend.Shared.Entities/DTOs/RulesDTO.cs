using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs
{
    public class RulesDTO
    {
        private String ruleNamespace { get; set; }
        private String ruleName { get; set; }
        private String ruleId { get; set; }
        private List<DecisionDTO> decisionList { get; set; }
        private List<InputDTO> inputList { get; set; }
        private Dictionary<String, Object> context { get; set; }

        public RulesDTO() { }
    }
}
