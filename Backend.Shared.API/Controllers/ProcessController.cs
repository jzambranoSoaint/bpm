using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Backend.Shared.Entities.DTOs;
using System.Net;

namespace Backend.Shared.Controller.Impl
{
    [ApiController, Route("/pamec/bpm-api/v1/processes")]
    public class ProcessController : ControllerBase
    {

        [HttpPost("/startProcess")]
        public async Task<ActionResult> iniProcessIntances(ProcessRequestDTO processRequestDTO)
        {
            ResponseBuilder res = ResponseBuilder.newBuilder();

            return null;
        }


        [HttpGet("/task/potOwners")]
        public async Task<bool> listAllTaskByPotOwner()
        {

            var httpClient = new HttpClient();

            using HttpResponseMessage response = await httpClient.GetAsync("http://sdspam-kieserver-des-sds-infra-transversal.apps.openshiftdev.soain.lcl/services/rest/server/queries/tasks/instances/pot-owners");

            Console.Write(response.EnsureSuccessStatusCode());

            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"{jsonResponse}\n");

            return true;
        }
    }
}
