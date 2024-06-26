# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AlunosBase/AlunosBase/AlunosBase.csproj", "AlunosBase/"]
RUN dotnet restore "AlunosBase/AlunosBase.csproj"
COPY . .
WORKDIR /src/AlunosBase/AlunosBase
RUN dotnet build "AlunosBase.csproj" -c Release -o /app/build

# Estágio de publicação
FROM build AS publish
RUN dotnet publish "AlunosBase.csproj" -c Release -o /app/publish

# Estágio de execução
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlunosBase.dll"]
