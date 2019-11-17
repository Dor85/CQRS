FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY Src/Api/Company.Project.Api.csproj Src/Api/
COPY Src/Common/Company.Project.Common.csproj Src/Common/
COPY Src/Infrastructure/Company.Project.Insfrastructure.csproj Src/Infrastructure/
COPY Src/Application/Company.Project.Application.csproj Src/Application/
COPY Src/Domain/Company.Project.Domain.csproj Src/Domain/
COPY Src/Persistence/Company.Project.Persistence.csproj Src/Persistence/
RUN dotnet restore "Src/Api/Company.Project.Api.csproj"
COPY . .
WORKDIR "/src/Src/Api"
RUN dotnet build "Company.Project.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Company.Project.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Company.Project.Api.dll"]
