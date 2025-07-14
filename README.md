
# **Product Service API**

This APi that allows you to **create**, **retrieve**, **update**, and **delete** products.

---

## **Requirements**

To run the project, you need the following:

- .NET Core SDK (latest version)
- Visual Studio 2022 or the latest available version
- IIS (optional for hosting)

---

## **Technologies Used**

- ASP.NET Core
- Swagger UI
- xUnit for unit testing

---



## **How to Use the API**

Run the app app, the **Swagger UI** will appear.

- Click the **POST PRODUCT** button to add a new product.
- You can add as many records as you want.
- Use the **GET PRODUCT** to retrieve a list of products.
- Click **Delete** to remove a product record from the list.
- You can retreve a product by ProductId
- Click **PUT PRODUCT** to update product 

# Unit Testing

This project includes a dedicated unit testing project to ensure the functionality of the Library Management System.

## Running the Tests

To run the unit tests:

1. Open the testing project in **Visual Studio**.
2. Go to the menu and select **Test > Test Explorer**.
3. Run all tests to validate that the system behaves as expected.

## Test Coverage

The unit tests cover the following core functionalities:

- Creating a Product  
- Retrieving a Product by ID  
- Updating a Product  
- Deleting a Product  

These tests are implemented using the **xUnit** testing framework.
