﻿using System.Net.Http;
using System.Threading.Tasks;
using Coolector.Services.Operations.Shared.Dto;

namespace Coolector.Api.Tests.EndToEnd.Framework
{
    public interface IOperationHandler
    {
        Task<OperationDto> PostAsync(string endpoint, object data = null);
        Task<OperationDto> PutAsync(string endpoint, object data = null);
        Task<OperationDto> DeleteAsync(string endpoint);
        Task<OperationDto> HandleOperationAsync(HttpResponseMessage response);
        Task<OperationDto> HandleOperationAsync(string endpoint);
    }
}