using System.Web.Http;
using SecureAPI.Models;
using SecureAPI.Filters;

namespace SecureAPI.Controllers
{
    [HMACAuthentication]
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
