using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashApi.Models;

namespace DashApi.Service
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}