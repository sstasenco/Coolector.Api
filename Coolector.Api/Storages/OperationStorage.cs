﻿using System;
using System.Threading.Tasks;
using Coolector.Common.Types;
using Coolector.Services.Operations.Shared.Dto;

namespace Coolector.Api.Storages
{
    public class OperationStorage : IOperationStorage
    {
        private readonly IStorageClient _storageClient;

        public OperationStorage(IStorageClient storageClient)
        {
            _storageClient = storageClient;
        }

        public async Task<Maybe<OperationDto>> GetAsync(Guid requestId)
            => await _storageClient.GetAsync<OperationDto>($"operations/{requestId}");
    }
}