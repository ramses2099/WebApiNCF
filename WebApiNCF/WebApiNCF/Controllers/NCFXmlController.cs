using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Xml.Serialization;
using WebApiNCF.Services;

namespace WebApiNCF.Controllers
{
    public class NCFXmlController : ApiController
    {

        // POST: api/NCF
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpPost]
        [ActionName("PostNCFXML")]
        public IHttpActionResult PostNCFXML([FromBody]Services.DataParams param)
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

            return Ok(Serialize(response));
        }
        //
        private static string Serialize(object dataToSerialize)
        {
            if (dataToSerialize == null) return null;

            using (StringWriter stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(dataToSerialize.GetType());
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
        }


    }
}
