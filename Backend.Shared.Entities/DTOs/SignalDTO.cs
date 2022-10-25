using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs
{
    public class SignalDTO
    {
        private String signalName { get; set; }
        private ParametrosDTO parametros { get; set; }

        public SignalDTO()
        {
        }
    }
}
