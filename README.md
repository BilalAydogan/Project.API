DB-First Model

ef sqlserver -- ef design -- ef tools    (packages)


dotnet tool install --global dotnet-ef  (Check --> Version)

dotnet ef dbcontext scaffold "Data Source=DBCONNECTIONSTRING; Initial Catalog=DBNAME; Integrated Security=true; TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models --project "Model Dosya Yolu"

Updating 

dotnet ef dbcontext scaffold "Data Source=DBCONNECTIONSTRING; Initial Catalog=DBNAME; Integrated Security=true; TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models --project "File Direction" --force
