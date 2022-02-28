//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Web;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using System.Collections.Generic;
using Siloam.System.Web;
using Siloam.System.Data;
using Microsoft.AspNetCore.Mvc;
using his_lasa_managemenet_service.Common;

namespace his_lasa_managemenet_service.Controllers
{
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseMessage), 500)]
    [ProducesResponseType(typeof(ResponseMessage), 400)]
    [ProducesResponseType(typeof(ResponseData<Dictionary<string, string>>), 422)]

    public class BaseController : Controller
    {
        protected HttpResult HttpResults;
        protected IUnitOfWork IUnitOfWorks;

        public BaseController() { }

        public BaseController(IUnitOfWork iUnitofWorks)
        {
            IUnitOfWorks = iUnitofWorks;
        }

        public ObjectResult HttpResponse(HttpResult result)
        {
            ObjectResult objectResult = new ObjectResult(result);

            objectResult.StatusCode = result.GetResponseStatusCode();
            objectResult.Value = result;

            return objectResult;
        }

        protected override void Dispose(bool disposing)
        {
            IUnitOfWorks.Dispose();
            base.Dispose(disposing);
        }
    }
}
