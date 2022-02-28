using his_lasa_managemenet_service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace his_lasa_managemenet_service.Common
{
    public interface IUnitOfWork : IDisposable
    {
        LasaRepository UnitOfWork_TR_Lasa();
        UserRepository UnitOfWork_MS_User();
    }
}
