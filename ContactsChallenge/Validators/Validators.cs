using ContactsChallenge.Models;
using ContactsChallenge.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsChallenge.Validators
{
    public class Validator
    {

        //funcion validadora para verificar si los datos de un contacto a postear son validos
        public static List<string> IsContactValid (TempContact tempContact)
        {
            List<string> errorList = new List<string>();

            //verificamos si algun campo llega vacio o nulo
            if (string.IsNullOrWhiteSpace(tempContact.FirstName))
            {
                errorList.Add(" el campo nombre no puede estar vacío ");
            }

            if (string.IsNullOrWhiteSpace(tempContact.LastName))
            {
                errorList.Add(" el campo apellido no puede estar vacío ");
            }

            if (string.IsNullOrWhiteSpace(tempContact.Company))
            {
                //en caso afirmativo informamos el detalle correspondiente
                errorList.Add(" el campo compañia no puede ser nulo");
            }

            if (string.IsNullOrWhiteSpace(tempContact.Email))
            {
                errorList.Add(" el campo correo electrónico no puede estar vacío");
            }

            if (string.IsNullOrWhiteSpace(tempContact.PhoneNumber))
            {
                errorList.Add(" el campo número telefónico no puede estar vacío ");
            }

            return errorList;
        }

        //funcion validadora que recibe un contacto y un tempContact y devuelve el contacto original actualizado
        internal static Contact UpdateContactWithTempContact(Contact oldContact, TempContact tempContact)
        {
            //primero tomamos el contacto original
            Contact updatedContact = oldContact;

            //verificamos solo actualizar los campos que tienen valores
            if (!string.IsNullOrWhiteSpace(tempContact.Company))
            {
                updatedContact.Company = tempContact.Company;
            }

            if (!string.IsNullOrWhiteSpace(tempContact.Email))
            {
                updatedContact.Email = tempContact.Email;
            }

            if (!string.IsNullOrWhiteSpace(tempContact.FirstName))
            {
                updatedContact.FirstName = tempContact.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(tempContact.LastName))
            {
                updatedContact.LastName = tempContact.LastName;
            }

            if (!string.IsNullOrWhiteSpace(tempContact.PhoneNumber))
            {
                updatedContact.PhoneNumber = tempContact.PhoneNumber;
            }

            //retornamos el contacto actualizado
            return updatedContact;
        }
    }
}
