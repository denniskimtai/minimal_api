using MySql_Minimal_Api_Project.Contexts;
using MySql_Minimal_Api_Project.Models;

namespace MySql_Minimal_Api_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //add the dbcontext service
            builder.Services.AddDbContext<DataContext>
                (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //Get all transactions
            app.MapGet("/api/Transactions",
                async (DataContext context) => await context.TransactionItems.ToListAsync());

            //Get Todo Items by id
            app.MapGet("/api/Transactions/{id}", async (DataContext context, int id) =>
                await context.TransactionItems.FindAsync(id) is TransactionModel transactionItem ? 
                Results.Ok(transactionItem) : Results.NotFound("Transaction not found ./"));

            //Create Todo Items 
            app.MapPost("/api/Transactions", async (DataContext context, TransactionModel transaction) =>
            {
                context.TransactionItems.Add(transaction);
                await context.SaveChangesAsync();
                return Results.Created($"/api/Transactions/{transaction.Id}", transaction);
            });

            //Updating Todo Items
            app.MapPut("/api/Transactions/{id}", async (DataContext context, TransactionModel transaction, int id) =>
            {
                var transactionItemFromDb = await context.TransactionItems.FindAsync(id);

                if (transactionItemFromDb != null)
                {
                    transactionItemFromDb.Amount = transaction.Amount;
                    transactionItemFromDb.Balance = transaction.Balance;
                    transactionItemFromDb.RecipientId = transaction.RecipientId;
                    transactionItemFromDb.InitiatorId = transaction.InitiatorId;
                    transactionItemFromDb.TransactionCode = transaction.TransactionCode;

                    await context.SaveChangesAsync();
                    return Results.Ok(transaction);
                }
                return Results.NotFound("Transaction not found");
            });


            //Deleting Todo Items
            app.MapDelete("/api/Transactions/{id}", async (DataContext context, int id) =>
            {
                var transactionItemFromDb = await context.TransactionItems.FindAsync(id);

                if (transactionItemFromDb != null)
                {
                    context.Remove(transactionItemFromDb);
                    await context.SaveChangesAsync();
                    return Results.Ok("Transaction deleted");
                }
                return Results.NotFound("Transaction not found");
            });

            app.UseAuthorization();
            app.Run();

        }
    }
}