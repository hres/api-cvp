﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface ISeriousnessLxRepository
    {
        IEnumerable<SeriousnessLx> GetAll();
        SeriousnessLx Get(int id);
    }
}