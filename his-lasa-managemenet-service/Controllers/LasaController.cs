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
using System.Threading.Tasks;

namespace his_lasa_managemenet_service.Controllers
{

    public class LasaController : BaseController
    {
        private readonly IHubContext<MessageHub> messageHubContext;

        public LasaController(IUnitOfWork unitOfWork, IHubContext<MessageHub> _messageHubContext) : base(unitOfWork)
        {
            messageHubContext = _messageHubContext;
        }
        [HttpGet("dataLassa")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<Lasa>>), 200)]
        public IActionResult GetData_Lassa()
        {
            int total = 0;

            try
            {
                var data = IUnitOfWorks.UnitOfWork_TR_Lasa().GetAllData_Lasa();
                total = data.Count();

                if (total != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<Lasa>>("Get All Data Lasa", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, data);
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
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, exx.Message, total);
                }
            }

            return HttpResponse(HttpResults);

        }

        [HttpGet("selectLassabyname/{product_name}")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<ViewPageLassa>>), 200)]
        public IActionResult GetData_Lassa_byName([FromRoute] string product_name)
        {
            int total = 0;

            try
            {
                var data = IUnitOfWorks.UnitOfWork_TR_Lasa().Search_lasa_byName(product_name);
                total = data.Count();

                if (total != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<Lasa>>("Get All Data Lasa", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, data);
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
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, "data tidak di temukan", total);
                }
            }

            return HttpResponse(HttpResults);

        }


        [HttpPost("InsertLasa")]
        [ProducesResponseType(typeof(ResponseData<string>), 200)]
        public IActionResult Insert_Lasa([FromBody] Lasa lasa)
        {
                int total = 0;
                try
                {
                    Lasa data = IUnitOfWorks.UnitOfWork_TR_Lasa().MapingLasa(lasa);
                    total = data.ToString().Count();
                    

                    HttpResults = new ResponseData<Lasa>("Data successfully updated", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, data);
                }
                catch (Exception ex)
                {
                    int exCode = ex.HResult;

                    if (exCode == -2147467259)
                    {
                        HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, ex.Message, total);
                    }
                    else
                    {
                        HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, ex.Message, total);
                    }
                }

                return HttpResponse(HttpResults);
            
        }

        [HttpPut("UpdateLasa/{item_id}")]
        [ProducesResponseType(typeof(ResponseData<string>), 200)]
        public IActionResult Update_Lasa([FromRoute] int item_id ,[FromBody] UpdateLasa updateLasa)
        {
            int total = 0;
            try
            {
                UpdateLasa data = IUnitOfWorks.UnitOfWork_TR_Lasa().UpdateLasa(item_id,updateLasa);
                total = data.ToString().Count();
                HttpResults = new ResponseData<UpdateLasa>("Data successfully updated", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, data);
            }
            catch (Exception ex)
            {
                int exCode = ex.HResult;

                if (exCode == -2147467259)
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, ex.Message, total);
                }
                else
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, ex.Message, total);
                }
            }

            return HttpResponse(HttpResults);

        }

        [HttpGet("tabel_TR_Lasa")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<DataTabelLasa>>), 200)]
        public IActionResult GetTabelLasa()
        {
            int total = 0;

            try
            {
                var data = IUnitOfWorks.UnitOfWork_TR_Lasa().Tabel_TR_Lasa();
                total = data.Count();

                if (total != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<DataTabelLasa>>("Berikut semua tabel lasa", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, data);
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
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, exx.Message, total);
                }
            }

            return HttpResponse(HttpResults);

        }


    }

}
