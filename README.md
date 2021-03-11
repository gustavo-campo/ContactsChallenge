#Contacts API Challenge
API desarrollada en .Net Core 3.1 para almacenar y consultar contactos

#Como inicializar el proyecto
En primer lugar indicar la connection string en el modelo ContactsDBContext (ver Models/ContactsDBContext.cs, linea 12).
Para inicializar la base de datos se ejecutan los siguientes comandos en la consola PM:

add-migration FirstMigration
update-database

La migración FirstMigration contiene un set de datos de prueba.

#Métodos disponibles
(Todas las pruebas y ejemplos abajo detalladas fueron realizadas con Postman)

#POST: api/Contact
Recibe un objeto del tipo TempContact que debe contener todos los campos, caso contrario no sera tomado como valido.

Ejemplo 1:

{
	"FirstName" : "Marianela",
	"LastName" : "Ramirez",
	"Company" : "EstebanSoft",
	"Email" : "marianela@estebansoft.com",
	"PhoneNumber" : "15-4444-5555"
}

Si el posteo es exitoso el resultado es el siguiente:

{
    "data": [
        {
            "contactId": 15,
            "firstName": "Marianela",
            "lastName": "Ramirez",
            "company": "EstebanSoft",
            "email": "marianela@estebansoft.com",
            "phoneNumber": "15-4444-5555"
        }
    ],
    "succeeded": true,
    "errors": "200OK",
    "message": "El elemento fue correctamente guardado."
}

Como podemos ver devuelve el objeto creado con el id asignado, así mismo informa si fue exitoso y en el campo message la leyenda correspondiente para el usuario.

Ejemplo 2:

{
	"FirstName" : "",
	"LastName" : "Ramirez",
	"Company" : "EstebanSoft",
	"Email" : "marianela@estebansoft.com",
	"PhoneNumber" : "15-4444-5555"
}

En este caso no se completo el campo nombre, por lo que el posteo falla y devuelve lo siguiente:

{
    "data": [],
    "succeeded": false,
    "errors": "Error",
    "message": "Se produjeron los siguientes errores:  el campo nombre no puede estar vacío "
}

Como podemos ver informa si no fue exitoso y en el campo message el error que provoca el fallo.

#GET: api/Contacts
Este es el método por defecto y devuelve la totalidad de los registros existentes.

Ejemplo 1:
URL: api/Contacts
Respuesta:
{
	pageNumber: 1,
	pageSize: 5,
	totalRecords: 5,
	data: [
		{
			contactId: 1,
			firstName: "Juan",
			lastName: "Perez",
			company: "JuanPerez S.A.",
			email: "juan@juanperezsa.com",
			phoneNumber: "15-1234-4567"
		},
		{ 
			... 
		},
		{
			contactId: 5,
			firstName: "Ramiro",
			lastName: "Estevez",
			company: "JuanPerez S.A.",
			email: "Ramiro@juanperezsa.com",
			phoneNumber: "11-2233-4460"
		}
	],
	succeeded: true,
	errors: null,
	message: null
}

En la respuesta de puede ver el array Data que contiene los registros, asi como cual es el numero de pagina de resultados que estamos viendo (pagina 1 por defecto) y la cantidad de elementos que se muestran en la misma (5 elementos por defecto). También tenemos un campo que informa que la consulta fue un éxito y en caso de presentarse un error, se lo muestra en el campo message.

Para obtener otra pagina de resultados y modificar la cantidad de resultados que recibimos se deben indicar como parámetros "PageNumber" y "PageSize".

Ejemplo 2:
URL: api/Contact?pageNumber=2&PageSize=5
Respuesta:
{
	pageNumber: 2,
	pageSize: 5,
	totalRecords: 15,
	data: [
			{
				contactId: 6,
				firstName: "Josefina",
				lastName: "Gomez",
				company: "EstebanSoft",
				email: "josefina@estebansoft.com",
				phoneNumber: "11-2233-4460"
			},
			{
				...
			},
			{
				contactId: 10,
				firstName: "Sofia",
				lastName: "Perez",
				company: "JuanPerez S.A.",
				email: "Sofia@juanperezsa.com",
				phoneNumber: "11-5555-2222"
			}
		],
	succeeded: true,
	errors: null,
	message: null
}

Como vemos nos informa en que pagina de resultados estamos parados, así como la cantidad de registros que se muestran y la cantidad total de registros.

#GET: api/Contacts/id/{id: int}
Este método toma el id de un contacto y devuelve los datos completos del mismo.

Ejemplo 1:
URL: api/contacts/id/1
Respuesta:
{
    "data": [
        {
            "contactId": 1,
            "firstName": "Juan",
            "lastName": "Perez",
            "company": "JuanPerez S.A.",
            "email": "juan@juanperezsa.com",
            "phoneNumber": "15-1234-4567"
        }
    ],
    "succeeded": true,
    "errors": "200OK",
    "message": null
}

Ejemplo 2:
(En caso de indicar un id inexistente)
URL: api/contacts/id/122
Respuesta:
{
    "data": [],
    "succeeded": false,
    "errors": "404",
    "message": "No se encontró el ID indicado."
}

#GET: api/Contacts/company/{company: string}
Este método toma el nombre de la compañía de un contacto y devuelve los datos completos todos los contactos de la misma.

Para obtener otra pagina de resultados y modificar la cantidad de resultados que recibimos se deben indicar como parámetros "PageNumber" y "PageSize".

Ejemplo 1:
URL: api/contacts/company/estebansoft
Respuesta:
{
    "pageNumber": 1,
    "pageSize": 5,
    "totalRecords": 3,
    "data": [
        {
            "contactId": 6,
            "firstName": "Josefina",
            "lastName": "Gomez",
            "company": "EstebanSoft",
            "email": "josefina@estebansoft.com",
            "phoneNumber": "11-2233-4460"
        },
        {
			...
        },
        {
            "contactId": 15,
            "firstName": "Marianela",
            "lastName": "Ramirez",
            "company": "EstebanSoft",
            "email": "marianela@estebansoft.com",
            "phoneNumber": "15-4444-5555"
        }
    ],
    "succeeded": true,
    "errors": null,
    "message": null
}

Ejemplo 2:
(informamos una compañía sin usuarios registrados)
URL: api/contacts/company/empresa1
Respuesta:
{
    "pageNumber": 1,
    "pageSize": 5,
    "totalRecords": 0,
    "data": [],
    "succeeded": true,
    "errors": null,
    "message": null
}

#PUT: api/Contacts/id/{id: int}
Este método recibe el id del contacto a actualizar por parámetro y el objeto con los datos a utilizar en el cuerpo del mensaje.
Solo se actualizan los campos en los que el usuario envía datos.

Ejemplo:
URL: api/Contacts/id/1
Body:
(supongamos que queremos actualizar solo el télefono)
{
    "phoneNumber": "15-6666-5555"
}
Respuesta:
{
    "data": [
        {
            "contactId": 1,
            "firstName": "Juan",
            "lastName": "Perez",
            "company": "JuanPerez S.A.",
            "email": "juan@juanperezsa.com",
            "phoneNumber": "15-6666-5555"
        }
    ],
    "succeeded": true,
    "errors": "200OK",
    "message": "Se actualiza el registro correctamente."
}

Como podemos ver, informa que la operación fue exitosa y devuelve el objeto actualizado.

#DELETE: api/Contacts/id/{id: int}
Este metodo recibe el id del contacto a eliminar como parámetro.

Ejemplo:
URL:api/contacts/id/15
Respuesta:
{
    "data": [],
    "succeeded": true,
    "errors": null,
    "message": "Se elimino el registro indicado."
}

#Pruebas unitarias
Utilizando un proyecto MSTest se realizan las siguientes pruebas sobre el método IsContactValid(TempContact contact).
Este método es parte de la clase Validator y se utilizar para verificar que los datos que envía el usuario para crear un nuevo contacto a través de la ruta POST: api/contact son validos. El criterio que utilizamos para determinar la validez es que todos los campos tengan un valor.
El método IsContactValid recibe un TempContact, que es el tipo de objeto que contiene todos los campos asignables por el usuario del tipo de dato Contact y devuelve una lista de string que en caso de estar vacía indica que el objeto es valido.

Los métodos de prueba son los siguientes y verifican que las respuestas sean las esperadas en los casos de no incluir el nombre, el apellido, la compañía, el email, el teléfono, todos los campos o algunos de ellos, respectivamente.

IsContactValid_ShoudlReturnEmptyList()
IsContactValid_ShoudlReturnMissingFirstName()
IsContactValid_ShoudlReturnMissingLastName()
IsContactValid_ShoudlReturnMissingCompany()
IsContactValid_ShoudlReturnMissingEmail()
IsContactValid_ShoudlReturnMissingPhoneNumber()
IsContactValid_ShoudlReturnMissingAll()
IsContactValid_ShoudlReturnMissingSome()