using his_lasa_managemenet_service.Common;
using his_lasa_managemenet_service.Hub;
using his_lasa_managemenet_service.Models;
using his_lasa_managemenet_service.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Siloam.System.Data;
using Siloam.System.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace his_lasa_managemenet_service.Controllers
{
  
    public class UserController : BaseController
    {
        private readonly IHubContext<MessageHub> messageHubContext;

        public UserController(IUnitOfWork unitOfWork, IHubContext<MessageHub> _messageHubContext) : base(unitOfWork)
        {
            messageHubContext = _messageHubContext;
        }
        [HttpPost("Login")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<ViewLogin>>), 200)]
        
        public IActionResult Login_byName_Password([FromBody] ParamLogin paramLogin)
        {
            int total = 0;

            try
            {
                var data = IUnitOfWorks.UnitOfWork_MS_User().GetData_user_login_SP(paramLogin);
                total = data.Count();
                if (total != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<ViewLogin>>("Get User data", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, data);
                }
                else
                {
                    Exception ex = new Exception();
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.OK, StatusMessage.Fail, "no  data available", total);
                }
            }
            catch (Exception exx)
            {
                int exCode = exx.HResult;

                if (exCode == -2147467259)
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, exx.Message, total);
                }
                else
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, "Username password salah", total);
                }
            }

            return HttpResponse(HttpResults);

        }
    }
}
