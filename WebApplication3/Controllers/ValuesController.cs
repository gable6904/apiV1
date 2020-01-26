using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class ValuesController : ApiController
    {
       /* private ContactRepository contactRepository;*/
        private static List<Contact> _listItems { get; set; } = new List<Contact>();

        /*public ValuesController(ContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }*/

        public IEnumerable<Contact> Get()
        {
            return _listItems;
        }
        // GET api/values
        /*public string Get()
        {
            return this.contactRepository.GetAllContacts();
        }
*/
        // GET api/values/1

        public HttpResponseMessage Get(int id)
        {
            var item = _listItems.FirstOrDefault(x => x.id == id);
            if (item != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // POST api/values

        public HttpResponseMessage Post([FromBody]Contact model)
        {
            if (string.IsNullOrEmpty(model?.text))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var maxId = 0;
            if (_listItems.Count > 0)
            {
                maxId = _listItems.Max(x => x.id);
            }
            model.id = maxId + 1;
            _listItems.Add(model);
            return Request.CreateResponse(HttpStatusCode.Created, model);
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Contact model)
        {
            if (string.IsNullOrEmpty(model?.text))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var item = _listItems.FirstOrDefault(x => x.id == id);
            if (item != null)
            {
                // Update *all* of the item's properties
                item.text = model.text;

                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            var item = _listItems.FirstOrDefault(x => x.id == id);
            if (item != null)
            {
                _listItems.Remove(item);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

    }
}
