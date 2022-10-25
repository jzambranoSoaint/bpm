using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs
{
    public class ContainerDTO
    {
        private String containerId { get; set; }
        private String version { get; set; }
        private String status { get; set; }
        private String containerAlias { get; set; }
        private List<ProcessesDTO> processes { get; set; }
        private List<MessagesDTO> messages { get; set; }
        private List<RulesDTO> rules { get; set; }

        public ContainerDTO() { }
    }
}
