using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs
{
    public class ProcessResponseDTO
    {
        private String processInstanceId { get; set; }
        private List<ContainerDTO> containers { get; set; }
        private ResponseDTO response { get; set; }

        public ProcessResponseDTO()
        {
        }

        public ProcessResponseDTO(String processInstanceId)
        {
            this.processInstanceId = processInstanceId;
        }
    }
}
