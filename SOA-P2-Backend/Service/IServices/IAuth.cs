using Domain.Request;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IAuth
    {
        DataResponse ValidCredentials(RequestPostLogin user);
    }
}
