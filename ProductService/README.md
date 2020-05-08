# Product Service (API)﻿

## Configuration:

- Create a Database (SQL Server)

- Set up Connection String within DatabaseContext class

  ```
  // Ex:
  optionsBuilder.UseSqlServer(@"data source=DESKTOP-RFM\SQLEXPRESS; initial catalog=products; 
                                           persist security info=True; Integrated Security=SSPI;");
  ```

- To migrate the data base run the following command (Package Manager Console): 

  ```
  Update-Database
  ```

- Run the project

- Register a user:  http://localhost:54844/api/auth/register

  ```
  {
  	"Username": "ricky",
  	"Name": "Ricky FM",
  	"Password": "Test",
  	"Email": "test@example.com"
  }
  ```

- Authenticate a user: http://localhost:54844/api/auth/login

  ```
  {
  	"Username": "ricky",
  	"Password": "Test"
  }
  ```

- To surf by the endpoints use authentication token (Header: Authorization):

  ```
  Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIyIiwidW5pcXVlX25hbWUiOiJyaWNreSIsInJvbGUiOiJzdXBlciIsIm5iZiI6MTU4ODkwODEwNywiZXhwIjoxNTg4OTk0NTA3LCJpYXQiOjE1ODg5MDgxMDd9.YgzKfPpXHvNL2njq1ghcX_0a7hKWOPCdhGrwKqozWzLugi5xFqnNQ4Qv4cfKCcUX7gTGv2On--4EbadCcERbgg
  ```

## Endpoints

- GET - POST
  - http://localhost:54844/api/products
  - http://localhost:54844/api/categories
- GET
  - http://localhost:54844/api/products/{id}

### Examples:

Insert Category:

```
{
    "code": "CAT1",
    "name": "Category 1"
}
```

Insert Product:

```
{
    "code": "PROD1",
    "name": "Product 1",
    "description": "Description prod 1",
    "categoryId": 1
}
```

## Swagger

http://localhost:54844/swagger/index.html



`Note.- Register Categories and Products (The project doesn't include validations)`