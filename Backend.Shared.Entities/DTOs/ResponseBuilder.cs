using Azure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.DTOs
{
    public class ResponseBuilder<T>
    {
        private T response;
        private HttpStatusCode httpStatus;
        private String httpBusinessStatus;
        private DateTime timeResponse;
        private String path;
        private String message;
        private TransactionState state;

        private ResponseBuilder() { this.httpBusinessStatus = ""; }

        public static ResponseBuilder<T> newBuilder()
        {
            return new ResponseBuilder<T>();
        }

        public ResponseBuilder<T> withResponse(T response)
        {
            this.response = response;
            this.timeResponse = DateTime.Now;
            return this;
        }

        public ResponseBuilder<T> withPath(String path)
        {
            this.path = path;
            this.timeResponse = DateTime.Now;
            return this;
        }

        public ResponseBuilder<T> withStatus(HttpStatusCode status)
        {
            this.httpStatus = status;
            return this;
        }

        public ResponseBuilder<T> withBusinessStatus(String status)
        {
            this.httpBusinessStatus = status;
            return this;
        }

        public ResponseBuilder<T> withMessage(String message)
        {
            this.message = message;
            this.timeResponse = DateTime.Now;
            return this;
        }

        public ResponseBuilder<T> withTransactionState(TransactionState state)
        {
            this.state = state;
            this.timeResponse = DateTime.Now;
            return this;
        }

        public Response buildResponse()
        {
            BaseResponse<T> baseResponse = new BaseResponse<T>(this.response, this.httpStatus, this.httpBusinessStatus, this.timeResponse, this.message, this.path, this.state);
            return new Response(baseResponse, httpStatus);
        }

        public BaseResponse<T> buildSimpleResponse()
        {
            return new BaseResponse<T>(this.response, this.httpStatus, this.httpBusinessStatus, this.timeResponse, this.message, this.path, this.state);
        }

    }
}
