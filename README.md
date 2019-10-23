# mug-of-joe (CoffeeMugWebApi)
A minimal Web API created in .NET Core.

# Disclaimer
As this project is open source and allows free access to the underlying database, the author claims zero responsibility for the 1-100 character strings that might be posted therein. As of the time of publishing the project, the database contains a set of seven products with everyday names.

The database is a free service provided by [remotemysql.com](https://remotemysql.com/).

# Prerequisites
* Visual Studio 2017 version 15.7 or higher
* .NET Core 2.1 and a few other packages which should be automatically collected by the Studio

# Description
A simple Web Api allowing for CRUD operations on a set of Product entities, defined as follows:

* **Guid** Id
* **string** Name *(length between 1 and 100)*
* **Decimal** Price *(between 0.01 and 99999999.99)*

After being ran, the API presents the following endpoints:

* **GET** /api/products - *displays all Products*
* **GET** /api/products/id - *displays the product with the given id*
* **POST** /api/products - *adds a new product (requires both name and price)*
* **PUT** /api/products - *updates a product (requires all fields)*
* **DELETE** /api/products/id - *deletes the product with the given id*

# Contributions
Any changes and further development will not be merged with master in this repository, as the project was created in adherence to strict instructions.

Extra features may later be added to the **dev** branch.

# Built with
[Visual Studio 2019](https://visualstudio.microsoft.com)

# Author
**Artur Szpot** ([GitHub](https://github.com/artur-szpot))

# License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.