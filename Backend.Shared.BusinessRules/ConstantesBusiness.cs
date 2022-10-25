using Backend.Shared.Entities.Interface.Repository;
using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Utilities.Telemetry;
using Backend.Shared.Entities.Responses;
using Backend.Shared.Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Net.Http;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Backend.Shared.BusinessRules
{
    public class ConstantesBusiness : IConstantesBusiness
    {
        #region Attributes
        private readonly ITelemetryException _telemetryException;
        private readonly IConstantesRepository _respositoryConstantes;
        #endregion 

        #region Constructor
        public ConstantesBusiness(IConstantesRepository respositoryConstantes, ITelemetryException telemetryException)
        {
            _telemetryException = telemetryException;
            _respositoryConstantes = respositoryConstantes;
        }
        #endregion 

        #region Methods
        public async Task<ResponseBase<List<ConstantesDTO>>> GetAllConstantesByIdPadre(int idPadre)
        {
            try
            {
                var resultQuery = await _respositoryConstantes.GetAllAsync(p => p.idPadre == idPadre);
                var listResponseConstantes = new List<ConstantesDTO>();

                if (resultQuery == null)
                {
                    return new ResponseBase<List<ConstantesDTO>>(code: System.Net.HttpStatusCode.OK, message: "No se encontraron resultados", data: null);
                }
                else
                {
                    foreach (var item in resultQuery)
                    {
                        ConstantesDTO constantesDTO = new ConstantesDTO
                        {
                            id = item.id,
                            nombre = item.nombre
                        };
                        listResponseConstantes.Add(constantesDTO);
                    }
                    return new ResponseBase<List<ConstantesDTO>>(code: System.Net.HttpStatusCode.OK, message: "Ok", data: listResponseConstantes);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                _telemetryException.RegisterException(ex);
                return new ResponseBase<List<ConstantesDTO>>(code: System.Net.HttpStatusCode.InternalServerError, message: msg, data: null);
            }
        }


        public async Task<ResponseBase<bool>> bmp()
        {
            var httpClient = new HttpClient();

            using HttpResponseMessage response = await httpClient.GetAsync("https://apm-aeu-sds-dev-shared.azure-api.net/filemanager/api/v1/Storage/AllBlobs/inhumacionindividual");

           Console.Write( response.EnsureSuccessStatusCode());

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");
            return new ResponseBase<bool>(code: System.Net.HttpStatusCode.OK, message: "ok", data: true);
        }
        #endregion
    }
}
