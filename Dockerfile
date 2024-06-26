
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AlunosBase.csproj", "./"]
RUN dotnet restore "AlunosBase.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "AlunosBase.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "AlunosBase.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlunosBase.dll"]


