﻿using Cashback_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Service.Contracts
{
    public interface IRevendedoraService : ICrudBaseService<RevendedoraModel>
    {
        RevendedoraModel Obter(string email, string password);
    }
}
