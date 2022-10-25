using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs
{
    public class MessagesDTO
    {
        private String severity { get; set; }
        private BigInteger fecha { get; set; }
        private List<String> content { get; set; }

        public MessagesDTO() { }
    }
}
