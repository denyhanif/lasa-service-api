using his_lasa_managemenet_service.Models;
using his_lasa_managemenet_service.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace his_lasa_managemenet_service.Repositories.IRepositories
{
    interface IUserRepository
    {
        IEnumerable<ViewLogin> GetData_user_login_SP(ParamLogin paramlogin);
       // List<ViewLogin> GetData_user_login_SP(ParamLogin paramlogin);
        //DataTable GetData_user_login_SP(ParamLogin paramlogin);
    }
}
