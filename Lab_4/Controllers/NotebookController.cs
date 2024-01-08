using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Laba4.Data;
using Laba4.Models;


namespace Laba4.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotebookController : Controller
    {
        private readonly ApiContext context;

        public NotebookController(ApiContext contx)
        {
            context = contx;
        }
        
        [HttpGet()]
        public JsonResult PrintAll()
        {
            var result = context.Contacts.ToList();

            return new JsonResult(Ok(result));
        }
        
        [HttpPost]
        public JsonResult Add(Contacts contact)
        {
            if(context.Contacts.Contains(contact) == false)
            {
                context.Contacts.Add(contact);
            } else
            {
                var contactInDb = context.Contacts.Find(contact.Nickname);

                if (contactInDb == null)
                    return new JsonResult(NotFound());

                contactInDb = contact;
            }

            context.SaveChanges();

            return new JsonResult(Ok(contact));

        }
        
        [HttpGet]
        public JsonResult Get(string s)
        {
            var result = context.Contacts.Find(s);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }
    }
}