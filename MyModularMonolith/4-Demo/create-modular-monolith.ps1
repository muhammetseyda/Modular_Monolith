$solution = "ModularMonolithDemo"

dotnet new sln -n $solution
mkdir $solution
cd $solution
mkdir src
cd src

# Host WebAPI
dotnet new webapi -n Host
# Catalog Module
dotnet new classlib -n Modules.Catalog
# Order Module
dotnet new classlib -n Modules.Order

cd ..

dotnet sln add src/Host
dotnet sln add src/Modules.Catalog
dotnet sln add src/Modules.Order

# Project References
dotnet add src/Host reference src/Modules.Catalog
dotnet add src/Host reference src/Modules.Order

# EF Core & MediatR
dotnet add src/Host package Microsoft.EntityFrameworkCore.SqlServer
dotnet add src/Host package Microsoft.EntityFrameworkCore.Tools
dotnet add src/Host package MediatR
dotnet add src/Host package MediatR.Extensions.Microsoft.DependencyInjection