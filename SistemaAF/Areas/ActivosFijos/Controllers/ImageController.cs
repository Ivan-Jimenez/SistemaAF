using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SistemaAF.Areas.ActivosFijos.Controllers
{
    public class ImageController : ApiController
    {
        // Upload an image
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;

            var httpRequest = HttpContext.Current.Request;
            var imageName = httpRequest.Params[0];

            if (httpRequest.Files.Count > 0)
            {
                var imageFiles = new List<string>();
                foreach (string image in httpRequest.Files)
                {
                    var postedImage = httpRequest.Files[image];
                    var imagePath = HttpContext.Current.Server.MapPath("~/Public/Images/"+imageName+".PNG");
                    postedImage.SaveAs(imagePath);
                    imageFiles.Add(imagePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, "OK");
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest, "ERROR");
            }
            return result; 
        }
    }
}
