using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Backend.Shared.Entities.DTOs
{
    public class BaseResponse<T>
    {
        private T body;
        private HttpStatusCode status;
        private String businessStatus;
        private DateTime timeResponse;
        private String message;
        private String path;
        private TransactionState transactionState;

        public BaseResponse(T body, HttpStatusCode status, String httpBusinessStatus, DateTime timeResponse, String message, String path, TransactionState transactionState)
        {
            this.body = body;
            this.status = status;
            this.businessStatus = httpBusinessStatus;
            this.timeResponse = timeResponse;
            this.message = message;
            this.path = path;
            this.transactionState = transactionState;
        }

    }
}
