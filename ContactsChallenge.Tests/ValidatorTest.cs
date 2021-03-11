using ContactsChallenge.Models;
using ContactsChallenge.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsChallenge.Tests
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        //esta prueba contiene un contacto valido, por lo que el validador deberia devolver una lista de errores vacia
        public void IsContactValid_ShoudlReturnEmptyList ()
        {
            //este es contacto de prueba
            TempContact contact = new TempContact()
            {
                FirstName = "Juan",
                LastName = "Perez",
                Company = "JuanPerez S.A.",
                Email = "juan@juanperezsa.com",
                PhoneNumber = "11-1212-4455"
            };

            //este es el valor esperado
            List<string> expected = new List<string>();

            //ejecutamos la prueba
            List<string> actual = Validator.IsContactValid(contact);

            //se comparan los valores
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        //esta prueba contiene un contacto sin nombre, por lo que el validador deberia devolver una lista solo con dicho error
        public void IsContactValid_ShoudlReturnMissingFirstName()
        {
            //este es contacto de prueba
            TempContact contact = new TempContact()
            {
                FirstName = "",
                LastName = "Perez",
                Company = "JuanPerez S.A.",
                Email = "juan@juanperezsa.com",
                PhoneNumber = "11-1212-4455"
            };

            //este es el valor esperado con el detalle de error correspondiente
            List<string> expected = new List<string>();
            expected.Add(" el campo nombre no puede estar vacío ");

            List<string> actual = Validator.IsContactValid(contact);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        //esta prueba contiene un contacto sin apellido, por lo que el validador deberia devolver una lista solo con dicho error
        public void IsContactValid_ShoudlReturnMissingLastName()
        {
            //este es contacto de prueba
            TempContact contact = new TempContact()
            {
                FirstName = "Juan",
                LastName = "",
                Company = "JuanPerez S.A.",
                Email = "juan@juanperezsa.com",
                PhoneNumber = "11-1212-4455"
            };

            //este es el valor esperado con el detalle de error correspondiente
            List<string> expected = new List<string>();
            expected.Add(" el campo apellido no puede estar vacío ");

            List<string> actual = Validator.IsContactValid(contact);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        //esta prueba contiene un contacto sin compañia, por lo que el validador deberia devolver una lista solo con dicho error
        public void IsContactValid_ShoudlReturnMissingCompany()
        {
            //este es contacto de prueba
            TempContact contact = new TempContact()
            {
                FirstName = "Juan",
                LastName = "Perez",
                Company = "",
                Email = "juan@juanperezsa.com",
                PhoneNumber = "11-1212-4455"
            };

            //este es el valor esperado con el detalle de error correspondiente
            List<string> expected = new List<string>();
            expected.Add(" el campo compañia no puede ser nulo");

            List<string> actual = Validator.IsContactValid(contact);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        //esta prueba contiene un contacto sin email, por lo que el validador deberia devolver una lista solo con dicho error
        public void IsContactValid_ShoudlReturnMissingEmail()
        {
            //este es contacto de prueba
            TempContact contact = new TempContact()
            {
                FirstName = "Juan",
                LastName = "Perez",
                Company = "JuanPerez S.A.",
                Email = "",
                PhoneNumber = "11-1212-4455"
            };

            //este es el valor esperado con el detalle de error correspondiente
            List<string> expected = new List<string>();
            expected.Add(" el campo correo electrónico no puede estar vacío");

            List<string> actual = Validator.IsContactValid(contact);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        //esta prueba contiene un contacto sin telefono, por lo que el validador deberia devolver una lista solo con dicho error
        public void IsContactValid_ShoudlReturnMissingPhoneNumber()
        {
            //este es contacto de prueba
            TempContact contact = new TempContact()
            {
                FirstName = "Juan",
                LastName = "Perez",
                Company = "JuanPerez S.A.",
                Email = "juan@juanperezsa.com",
                PhoneNumber = ""
            };

            //este es el valor esperado con el detalle de error correspondiente
            List<string> expected = new List<string>();
            expected.Add(" el campo número telefónico no puede estar vacío ");

            List<string> actual = Validator.IsContactValid(contact);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        //esta prueba contiene un contacto vacio, por lo que el validador deberia devolver una lista con todos los errores
        public void IsContactValid_ShoudlReturnMissingAll()
        {
            //este es contacto de prueba
            TempContact contact = new TempContact()
            {
                FirstName = "",
                LastName = "",
                Company = "",
                Email = "",
                PhoneNumber = ""
            };

            //este es el valor esperado con el detalle de error correspondiente
            List<string> expected = new List<string>();
            expected.Add(" el campo nombre no puede estar vacío ");
            expected.Add(" el campo apellido no puede estar vacío ");
            expected.Add(" el campo compañia no puede ser nulo");
            expected.Add(" el campo correo electrónico no puede estar vacío");
            expected.Add(" el campo número telefónico no puede estar vacío ");

            List<string> actual = Validator.IsContactValid(contact);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        //esta prueba contiene un contacto al que le faltan el nombre y el email, por lo que el validador deberia devolver una lista con dos errores solamente
        public void IsContactValid_ShoudlReturnMissingSome()
        {
            //este es contacto de prueba
            TempContact contact = new TempContact()
            {
                FirstName = "",
                LastName = "Perez",
                Company = "JuanPerez S.A.",
                Email = "",
                PhoneNumber = "11-1212-4455"
            };

            //este es el valor esperado con el detalle de error correspondiente
            List<string> expected = new List<string>();
            expected.Add(" el campo nombre no puede estar vacío ");
            expected.Add(" el campo correo electrónico no puede estar vacío");

            List<string> actual = Validator.IsContactValid(contact);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
