﻿using System;
using System.Net;
using System.Net.Http;
using Kudu.Contracts.Infrastructure;
using Microsoft.ApplicationServer.Http.Dispatcher;

namespace Kudu.Services.Infrastructure
{
    internal static class LockExtensions
    {
        public static void LockHttpOperation(this IOperationLock lockObj, Action action)
        {
            lockObj.LockOperation(action, () =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict);
                response.Content = new StringContent(Resources.Error_DeploymentInProgess);
                throw new HttpResponseException(response);
            });
        }
    }
}
