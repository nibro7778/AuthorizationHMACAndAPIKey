using System.Web.Http;
using SecureAPI.Models;

namespace SecureAPI.Controllers
{
    public class CustomerController : ApiController
    {
        public IHttpActionResult Post(Customer customer)
        {
            return Ok(customer);
        }
    }
}
