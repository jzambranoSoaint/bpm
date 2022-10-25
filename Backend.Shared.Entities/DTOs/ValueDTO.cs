using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs
{
    public class ValueDTO
    {
        private String key { get; set; }
        private String value { get; set; }

        public ValueDTO(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
