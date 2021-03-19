using ContactsChallenge.Filters;
using ContactsChallenge.Helpers;
using ContactsChallenge.Validators;
using ContactsChallenge.Models;
using ContactsChallenge.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace ContactsChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        // POST: api/Contacts
        // mediante esta ruta se crean nuevos elementos en la base
        [EnableCors]
        [HttpPost]
        public async Task<IActionResult> PostContactAsync(TempContact tempContact)
        {
            //creamos un nuevo contacto vacio
            Contact contact = new Contact();

            //preparamos una lista de errores en caso de algun valor nulo
            //consideramos todos los campos como obligatorios
            List<string> errorList = new List<string>();

            //consultamos con la funcion helper que verifica si hay algun campo vacio
            errorList = Validator.IsContactValid(tempContact);

            //si recibimos algun error se cancela la operacion y se devuelve un mensaje al usuario con los errores
            if (errorList.Count > 0)
            {
                return Ok(
                        Helper.CustomMessageResponseHelper(false, null, "Error", "Se produjeron los siguientes errores: " + string.Join<string>(",", errorList))
                        );
            } 
            else
            {
                //si no hay errores se completa el objeto contacto con los datos recibidos
                contact.Company = tempContact.Company;
                contact.Email = tempContact.Email;
                contact.FirstName = tempContact.FirstName;
                contact.LastName = tempContact.LastName;
                contact.PhoneNumber = tempContact.PhoneNumber;
            }

            try
            {
                using (var _context = new ContactsDBContext())
                {
                    //agregamos y guardamos cambios
                    _context.Contacts.Add(contact);
                    await _context.SaveChangesAsync();
                }

                //retornamos el mensaje de exito con todos los detalles
                return Ok(
                    Helper.CustomMessageResponseHelper(true, new List<Contact>() { contact }, "200OK", "El elemento fue correctamente guardado.")
                    );
            }
            catch (Exception e)
            {
                //capturamos la excepcion
                return NotFound(
                    Helper.CustomMessageResponseHelper(false, null, "Excepción inesperada", "Se ha producido el siguiente error: " + e.ToString())
                    );
            }
        }

        // GET: api/Contacts
        // mediante esta ruta se consulta la lista completa de contactos
        [EnableCors]
        [HttpGet]
        public async Task<IActionResult> GetAllContactsAsync([FromQuery] PaginationFilter filter)
        {
            //filtro que valida si los parametros son validos o no
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            //inicializamos mensajes para el usuario
            string usrMessage = "";
            string errorMessage = "";

            try {
                //creamos una lista para guardar los resultados de la base paginados
                List<Contact> pagedContacts = new List<Contact>();

                //creamos una lista para guardar todos los resultados de la base
                List<Contact> totalContacts = new List<Contact>();

                using (var _context = new ContactsDBContext())
                {
                    //en primer lugar consultamos la cantidad de elementos en la base
                    totalContacts = await _context.Contacts.ToListAsync();

                    //consultamos todo el contenido de la base
                    pagedContacts = await _context.Contacts
                                            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                            .Take(validFilter.PageSize)
                                            .ToListAsync();

                }

                //modificamos los mensajes para el usuario de acuerdo a lo necesitado
                if (pagedContacts.Count() == 0)
                {
                    //en caso de no encontrar registros
                    errorMessage = "404";
                    usrMessage = "No se encontraron registros en la base.";
                }
                else
                {
                    //en caso afirmativo
                    errorMessage = "200OK";
                    usrMessage = "";
                }

                //retornamos la lista utilizando un wrapper
                return Ok(
                    new PagedResponse<List<Contact>>(pagedContacts, validFilter.PageNumber, validFilter.PageSize, totalContacts.Count(), errorMessage, usrMessage)
                    );
            }
            catch (Exception e)
            {
                //capturamos la excepcion
                return NotFound(
                    Helper.CustomMessageResponseHelper(false, null, "Excepción inesperada", "Se ha producido el siguiente error: " + e.ToString())
                    );
            }
        }

        // GET: api/Contacs/id/1
        // mediante esta ruta se consultan los contactos filtrando por id
        [EnableCors]
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetContactByIdAsync(int id)
        {
            try
            {
                //creamos una lista para guardar todos los resultados de la base
                Contact contactById = new Contact();

                using (var _context = new ContactsDBContext())
                {
                    //consultamos todo el contenido de la base y filtramos por id
                    contactById = await _context.Contacts
                                            .Where(i => i.ContactId == id)
                                            .FirstOrDefaultAsync();
                }

                //en caso de no encontrarse el id informamos el error
                if (contactById == null)
                {
                    //si el resultado es nulo lo informamos
                    return NotFound(
                        Helper.CustomMessageResponseHelper(false, null, "404", "No se encontró el ID indicado.")
                        );
                } 
                else
                {
                    //si hay un resultado se informa el mismo
                    return Ok(
                        Helper.CustomMessageResponseHelper(true, new List<Contact>() { contactById }, "200OK", null)
                        );
                }

            }
            catch (Exception e)
            {
                //capturamos la excepcion
                return NotFound(
                    Helper.CustomMessageResponseHelper(false, null, "Excepción inesperada", "Se ha producido el siguiente error: " + e.ToString())
                    );
            }
        }

        // GET: api/Contacts/company/JuanPerez S.A.
        // mediante esta ruta se consulta la lista completa de contactos filtrando por el nombre de empresa
        // recibimos el nombre de la empresa como parametro
        [EnableCors]
        [HttpGet("company/{company}")]
        public async Task<IActionResult> GetContactsByCompanyAsync([FromQuery] PaginationFilter filter, string company)
        {
            //filtro que valida si los parametros son validos o no
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            //inicializamos mensajes para el usuario
            string usrMessage = "";
            string errorMessage = "";

            try
            {
                //creamos una lista para guardar los resultados de la base paginados
                List<Contact> pagedContacts = new List<Contact>();

                //creamos una lista para guardar todos los resultados de la base
                List<Contact> totalContacts = new List<Contact>();

                using (var _context = new ContactsDBContext())
                {
                    //en primer lugar consultamos la cantidad de elementos en la base
                    totalContacts = await _context.Contacts.Where(i => i.Company == company).ToListAsync();

                    //consultamos todo el contenido de la base
                    pagedContacts = await _context.Contacts
                                            .Where(i => i.Company == company)
                                            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                            .Take(validFilter.PageSize)
                                            .ToListAsync();

                }

                //modificamos los mensajes para el usuario de acuerdo a lo necesitado
                if (pagedContacts.Count() == 0)
                {
                    //en caso de no encontrar registros
                    errorMessage = "404";
                    usrMessage = "No se encontraron registros para la compañía indicada.";
                } 
                else
                {
                    //en caso afirmativo
                    errorMessage = "200OK";
                    usrMessage = "";
                }

                //retornamos la lista utilizando un wrapper
                return Ok(
                    new PagedResponse<List<Contact>>(pagedContacts, validFilter.PageNumber, validFilter.PageSize, totalContacts.Count(), errorMessage, usrMessage)
                    );
            }
            catch (Exception e)
            {
                //capturamos la excepcion
                return NotFound(
                    Helper.CustomMessageResponseHelper(false, null, "Excepción inesperada", "Se ha producido el siguiente error: " + e.ToString())
                    );
            }
        }

        // PUT: api/Contacts/id/1
        // mediante esta ruta se actualizan los datos de un registro indicado por id
        [EnableCors]
        [HttpPut("id/{id}")]
        public async Task<IActionResult> UpdateContactAsync(int id, TempContact tempContact)
        {
            //creamos un contacto nuevo
            Contact contact = new Contact();
            try
            {
                using (var _context = new ContactsDBContext())
                {
                    //Buscamos el contacto que va a ser modificado
                    contact = await _context.Contacts.Where(i => i.ContactId == id).FirstAsync();

                    //funcion helper que recibe el contacto inicial y actualiza los campos en funcion del tempContact enviado, pisando solo los campos que no sean nulos
                    contact = Validator.UpdateContactWithTempContact(contact, tempContact);

                    //guardamos los cambios
                    await _context.SaveChangesAsync();

                    //informamos que la operacion fue existosa
                    return Ok(
                        Helper.CustomMessageResponseHelper(true, new List<Contact>() { contact }, "200OK", "Se actualiza el registro correctamente.")
                        );
                }
            }
            catch (Exception e)
            {
                //capturamos la excepcion
                return NotFound(
                    Helper.CustomMessageResponseHelper(false, null, "Excepción inesperada", "Se ha producido el siguiente error: " + e.ToString())
                    );
            }

        }

        // DELETE: api/Contacts/id/1
        //mediante esta ruta se elimina un registro, si se le pasa un id valido
        [EnableCors]
        [HttpDelete("id/{id}")]
        public async Task<ActionResult<Contact>> DeleteContactAsync(int id)
        {
            try
            {
                using (var _context = new ContactsDBContext())
                {
                    //buscamos el elemento que tenga el id indicado
                    var contact = await _context.Contacts.FindAsync(id);

                    //si no se encuentra el elemento retornamos NotFound
                    if (contact == null)
                    {
                        return NotFound(
                            Helper.CustomMessageResponseHelper(false, null, "404","No se encontró el ID indicado.")
                            );
                    }

                    //caso afirmativo eliminamos de la base y guardamos los cambios
                    _context.Contacts.Remove(contact);
                    await _context.SaveChangesAsync();

                    return Ok(
                        Helper.CustomMessageResponseHelper(true, null, null, "Se elimino el registro indicado.")
                        );
                }

            }
            catch (Exception e)
            {
                //capturamos la excepcion
                return NotFound(
                    Helper.CustomMessageResponseHelper(false, null, "Excepción inesperada","Se ha producido el siguiente error: " + e.ToString())
                    );
            }

        }

    }
}
