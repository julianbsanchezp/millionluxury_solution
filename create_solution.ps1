Write-Host "Scaffolding MillionLuxury solution using dotnet CLI..."
dotnet new sln -n Million.Luxury
dotnet new classlib -n Million.Luxury.Domain -o src/Million.Luxury.Domain
dotnet new classlib -n Million.Luxury.Application -o src/Million.Luxury.Application
dotnet new classlib -n Million.Luxury.Infrastructure -o src/Million.Luxury.Infrastructure
dotnet new webapi -n Million.Luxury.Api -o src/Million.Luxury.Api
dotnet new nunit -n Million.Luxury.Tests -o src/Million.Luxury.Tests

dotnet sln add src/Million.Luxury.Domain/src/Million.Luxury.Domain.csproj
dotnet sln add src/Million.Luxury.Application/src/Million.Luxury.Application.csproj
dotnet sln add src/Million.Luxury.Infrastructure/src/Million.Luxury.Infrastructure.csproj
dotnet sln add src/Million.Luxury.Api/src/Million.Luxury.Api.csproj
dotnet sln add src/Million.Luxury.Tests/src/Million.Luxury.Tests.csproj

dotnet add src/Million.Luxury.Application/src/Million.Luxury.Application.csproj reference src/Million.Luxury.Domain/src/Million.Luxury.Domain.csproj
dotnet add src/Million.Luxury.Infrastructure/src/Million.Luxury.Infrastructure.csproj reference src/Million.Luxury.Application/src/Million.Luxury.Application.csproj
dotnet add src/Million.Luxury.Api/src/Million.Luxury.Api.csproj reference src/Million.Luxury.Application/src/Million.Luxury.Application.csproj
dotnet add src/Million.Luxury.Tests/src/Million.Luxury.Tests.csproj reference src/Million.Luxury.Domain/src/Million.Luxury.Domain.csproj

Copy-Item -Path template_files/* -Destination src/ -Recurse -Force -ErrorAction SilentlyContinue
Write-Host "Done."
