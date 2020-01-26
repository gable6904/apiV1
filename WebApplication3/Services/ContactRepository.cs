using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class ContactRepository
    {

        private static List<Contact> _listItems { get; set; } = new List<Contact>();

        /* public List<Contact> GetAllContacts()
         {
             return _listItems;
         }*/
        public string GetAllContacts()
        {
            return "vfkfvkfv";
           /* return new Contact[]
            {
            new Contact
            {
                id = 1,
                text = "Glenn Block"
            },
            new Contact
            {
                id = 2,
                text = "Dan Roth"
            }
            ,
            new Contact
            {
                id = 3,
                text = "Dan Roth"
            }
            };*/
        }
    }

   
}