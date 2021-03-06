﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiNCF.Services;
using System.Web.Script.Serialization;
using System.IO;
using System.Xml.Serialization;

namespace WebApiNCF.Controllers
{
    public class NCFController : ApiController
    {

        // POST: api/NCF
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpPost]
        [ActionName("PostNCFJSON")]
        public IHttpActionResult PostNCFJSON([FromBody]DataParam param)
        {
            
            ResponseMsg response = null;
            try
            {
                response = DbService.executeTransaction(param.TipoSecuencia, param.Sistema, param.NumeroFactura);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

          
            return Ok(response);
        }
        //

        



    }
}
