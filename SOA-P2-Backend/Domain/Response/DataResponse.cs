﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response
{
    public class DataResponse
    {
        public int Code { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
