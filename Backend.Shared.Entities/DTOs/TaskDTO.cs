using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs
{
    public class TaskDTO
    {
        private Integers Id { get; set; }
        private String taskName { get; set; }
        private String taskSubject { get; set; }
        private String taskDescription { get; set; }
        private String taskStatus { get; set; }
        private Integers taskPriority { get; set; }
        private String taskActualOwner { get; set; }
        private String taskCreatedBy { get; set; }
        private String taskCreatedOn { get; set; }
        private String taskActivationTime { get; set; }
        private String taskExpirationTime { get; set; }
        private String taskProcDefId { get; set; }
        private String containerId { get; set; }
        private String instanceId { get; set; }
        private Dictionary<String, Object> variables { get; set; }

        public TaskDTO() { }

    }
}
