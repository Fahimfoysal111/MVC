using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testapi.Models;

namespace testapi.Controllers
{
    public class ContactController : ApiController
    {
        //Post
        public HttpResponseMessage Post(Contact contact)
        {
            HttpResponseMessage response = null; object resdata = null;
            try
            {
                var db = new Database1Entities();
                var newContact = db.Contacts.Add(contact);
                db.SaveChanges();
                resdata = new
                {
                    newContact,
                    message = "saved successfully."
                };
                response = Request.CreateResponse<object>(HttpStatusCode.Created, resdata);
            }
            catch (Exception ex)
            {
                resdata = new
                {
                    message = ex.Message
                };
                response = Request.CreateResponse<object>(HttpStatusCode.InternalServerError, resdata);
            }

            return response;
        }
        //Update
        public HttpResponseMessage Put(Contact contact)
        {
            HttpResponseMessage response = null; object resdata = null;
            try
            {
                var db = new Database1Entities();
                var updateContact = db.Contacts.Where(w => w.Id == contact.Id).FirstOrDefault();
                if (updateContact != null)
                {
                    updateContact.Name = contact.Name;
                    updateContact.Phone = contact.Phone;
                    db.SaveChanges();
                    resdata = new
                    {
                        updateContact,
                        message = "updated successfully."
                    };
                }
                else
                {
                    resdata = new
                    {
                        contact,
                        message = "contact id not found."
                    };
                }

                response = Request.CreateResponse<object>(HttpStatusCode.OK, resdata);
            }
            catch (Exception ex)
            {
                resdata = new
                {
                    message = ex.Message
                };
                response = Request.CreateResponse<object>(HttpStatusCode.InternalServerError, resdata);
            }

            return response;
        }
        //Delete
        public HttpResponseMessage Delete(int Id)
        {
            HttpResponseMessage response = null; object resdata = null;
            try
            {
                var db = new Database1Entities();
                var deleteContact = db.Contacts.Where(w => w.Id == Id).FirstOrDefault();
                if (deleteContact != null)
                {
                    db.Contacts.Remove(deleteContact);
                    db.SaveChanges();
                    resdata = new
                    {
                        deleteContact,
                        message = "deleted successfully."
                    };
                }
                else
                {
                    resdata = new
                    {
                        deleteContact,
                        message = "contact id not found."
                    };
                }

                response = Request.CreateResponse<object>(HttpStatusCode.OK, resdata);
            }
            catch (Exception ex)
            {
                resdata = new
                {
                    message = ex.Message
                };
                response = Request.CreateResponse<object>(HttpStatusCode.InternalServerError, resdata);
            }

            return response;
        }

        //Get
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = null; object resdata = null;
            try
            {
                var db = new Database1Entities();
                var listContact = db.Contacts.ToList();
                db.SaveChanges();
                resdata = new
                {
                    listContact
                };
                response = Request.CreateResponse<object>(HttpStatusCode.OK, resdata);
            }
            catch (Exception ex)
            {
                resdata = new
                {
                    message = ex.Message
                };
                response = Request.CreateResponse<object>(HttpStatusCode.InternalServerError, resdata);
            }

            return response;
        }
    }




}