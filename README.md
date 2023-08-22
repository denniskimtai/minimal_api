# Minimal API
A minimal API project built using ASP.NET Core that provides a simple interface for managing transactions in a local SQL Server database.

## Features

- Create new transactions with details like transaction code, amount, initiator, and recipient.
- View a list of all transactions.
- Retrieve transaction details by transaction ID.
- Update transaction details, such as amount or initiator.
- Delete transactions.

## Technology Stack

- ASP.NET Core
- Entity Framework Core (EF Core)
- SQL Server
- C#

## Setup Instructions

1. Clone the repository to your local machine.
2. Make sure you have a local SQL Server instance set up and running.
3. Update the `appsettings.json` file with your SQL Server connection string.
4. Run the project using the `dotnet run` command.
5. Open your web browser and navigate to `https://localhost:5001/swagger` to access the Swagger UI for interacting with the API.

## API Endpoints

- **POST** `/api/transactions` - Create a new transaction.
- **GET** `/api/transactions` - Get a list of all transactions.
- **GET** `/api/transactions/{transactionId}` - Get details of a specific transaction by ID.
- **PUT** `/api/transactions/{transactionId}` - Update details of a specific transaction.
- **DELETE** `/api/transactions/{transactionId}` - Delete a transaction.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

Happy coding!
