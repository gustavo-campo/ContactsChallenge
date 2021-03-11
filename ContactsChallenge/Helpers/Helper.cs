using ContactsChallenge.Models;
using ContactsChallenge.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsChallenge.Helpers
{
    public class Helper
    {
        //funcion de ayuda para facilitar las respuestas con detalles al usuario
        public static Response<List<Contact>> CustomMessageResponseHelper(bool success, List<Contact> data, string error, string message)
        {
            //creamos una respuesta con informacion relevante para el usuario utilizando un wrapper
            Response<List<Contact>> ErrorResponse = new Response<List<Contact>>();

            //salvamos el caso si data es null
            if (data == null)
            {
                data = new List<Contact>();
            }

            //completamos los campos de la respuesta para informar al usuario del error
            ErrorResponse.Data = data;
            ErrorResponse.Succeeded = success;
            ErrorResponse.Errors = error;
            ErrorResponse.Message = message;

            //retornamos NotFound con el objeto que recien creamos
            return ErrorResponse;
        }

    }
}
