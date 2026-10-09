// Install EF Core
//dotnet add package Microsoft.EntityFrameworkCore --version 8.0.19
//If you're using SQL Server, also install:
//dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.19

//For EF Core migrations:
//dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.19
// opene microsoft sql and do someting  from 16:00;
using Microsoft.EntityFrameworkCore;
namespace FinanceApp.Data
{
    
    public class FinanceAppContext: DbContext  // importing dbcontext class
    {
        
        public FinanceAppContext(DbCOntextOption<FinanceAppContext> options):base(options)







        DbSet<Expense> Expenses {get; set;}
    }
}