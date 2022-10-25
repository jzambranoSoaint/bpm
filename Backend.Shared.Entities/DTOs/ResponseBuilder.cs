using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.DTOs
{
    public class ResponseBuilder
    {
        private String response;
        private HttpStatusCode httpStatus;
        private String httpBusinessStatus;
        private DateTime timeResponse;
        private String path;
        private String message;
        private TransactionState state;

        private ResponseBuilder() { this.httpBusinessStatus = ""; }

        public static ResponseBuilder newBuilder()
        {
            return new ResponseBuilder();
        }

        public ResponseBuilder withResponse(T response)
        {
            this.response = response;
            this.timeResponse = DateTime.Now;
            return this;
        }

        public ResponseBuilder withPath(String path)
        {
            this.path = path;
            this.timeResponse = DateTime.Now;
            return this;
        }

        public ResponseBuilder withStatus(HttpStatusCode status)
        {
            this.httpStatus = status;
            return this;
        }

        public ResponseBuilder withBusinessStatus(String status)
        {
            this.httpBusinessStatus = status;
            return this;
        }

        public ResponseBuilder withMessage(String message)
        {
            this.message = message;
            this.timeResponse = DateTime.Now;
            return this;
        }

        public ResponseBuilder withTransactionState(TransactionState state)
        {
            this.state = state;
            this.timeResponse = DateTime.Now;
            return this;
        }

        public ActionResult<BaseResponse> buildResponse()
        {
            //BaseResponse<T> baseResponse = new BaseResponse<T>(this.response, this.httpStatus, this.httpBusinessStatus, this.timeResponse, this.message, this.path, this.state);
            return new BaseResponse(this.response, this.httpStatus, this.httpBusinessStatus, this.timeResponse, this.message, this.path, this.state);
        }

        public BaseResponse buildSimpleResponse()
        {
            return new BaseResponse(this.response, this.httpStatus, this.httpBusinessStatus, this.timeResponse, this.message, this.path, this.state);
        }

    }
}
