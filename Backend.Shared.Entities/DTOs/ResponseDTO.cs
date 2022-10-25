using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs
{
    public class ResponseDTO
    {
        private String type { get; set; }
        private String msg { get; set; }
        private String statusCode { get; set; }

        public ResponseDTO()
        {
        }
    }
}
