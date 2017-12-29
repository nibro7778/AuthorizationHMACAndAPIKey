using System.Web.Http;
using SecureAPI.Models;

namespace SecureAPI.Controllers
{
    [RoutePrefix("api/v1/Customers")]
    public class CustomerController : ApiController
    {
        [Route("")]
        public IHttpActionResult Post(Customer customer)
        {
            return Ok(customer);
        }
    }
}
