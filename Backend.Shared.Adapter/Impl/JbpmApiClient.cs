using Backend.Shared.Entities.DTOs;
using System;
using System.Net.Http.Headers;

namespace Backend.Shared.Adapter.Impl
{
    public class JbpmApiClient
    {
        public ProcessResponseDTO iniciarInstanciaProceso(ProcessRequestDTO processRq)
        {
            ProcessResponseDTO responseDTO = new ProcessResponseDTO();
            try
            {
                String url = Environment.GetEnvironmentVariable(Utilities.Constants.Properties.EndpointApiJbpmProcessStartProcessInstance).ToString()
                    + processRq.getContainerId() + "/processes/" + processRq.getProcessId() + "/instances";

                
                
                
            } catch (Exception ex)
            {
                throw new Exception();
            }

            return responseDTO;
        }
    }
}
