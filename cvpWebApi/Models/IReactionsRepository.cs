using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IReactionsRepository
    {
        IEnumerable<Reactions> GetAll();
        Reactions Get(int id);
    }
}
