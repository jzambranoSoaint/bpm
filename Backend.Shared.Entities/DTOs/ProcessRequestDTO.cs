using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs
{
    public class ProcessRequestDTO
    {
        private String containerId { get; set; }
        private String processId { get; set; }
        private String processInstance { get; set; }
        private String taskId { get; set; }
        private String taskStatus { get; set; }
        private String processInstanceId { get; set; }
        private UserDTO ownerUser { get; set; }
        private UserDTO assignment { get; set; }
        private ParametrosDTO parametros { get; set; }
        private SignalDTO signal { get; set; }
        private List<String> groups { get; set; }
        private List<String> taskStates { get; set; }
        private int page { get; set; }
        private int pageSize { get; set; }
        private int instanceStatus { get; set; }
        private List<String> instanceStates { get; set; }

        public ProcessRequestDTO(string containerId, string processId, string processInstance, string taskId, string taskStatus, string processInstanceId, UserDTO ownerUser, UserDTO assignment, ParametrosDTO parametros, SignalDTO signal, List<string> groups, List<string> taskStates, int page, int pageSize, int instanceStatus, List<string> instanceStates)
        {
            this.containerId = containerId;
            this.processId = processId;
            this.processInstance = processInstance;
            this.taskId = taskId;
            this.taskStatus = taskStatus;
            this.processInstanceId = processInstanceId;
            this.ownerUser = ownerUser;
            this.assignment = assignment;
            this.parametros = parametros;
            this.signal = signal;
            this.groups = groups;
            this.taskStates = taskStates;
            this.page = page;
            this.pageSize = pageSize;
            this.instanceStatus = instanceStatus;
            this.instanceStates = instanceStates;
        }
    }
}
