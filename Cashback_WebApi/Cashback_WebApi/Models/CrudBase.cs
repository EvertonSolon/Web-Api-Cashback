﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Models
{
    public class CrudBase
    {
        public int Id { get; set; }

        public DateTime CriadoEm { get; set; }

        public bool Excluido { get; set; }
    }
}