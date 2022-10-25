using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs
{
    public class ProcessesDTO
    {
        private String processId { get; set; }
        private String processName { get; set; }
        private String processVersion { get; set; }
        private BigInteger startdate { get; set; }
        private String initiator { get; set; }
        private String packages { get; set; }
        private InstanceDTO instance { get; set; }
        private List<TaskDTO> taskList { get; set; }
        private ParametrosDTO parametros { get; set; }
        private String containerId { get; set; }

        public ProcessesDTO() { }
    }
}
