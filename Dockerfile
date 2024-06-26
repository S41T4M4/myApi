FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AlunosBase/AlunosBase.csproj", "AlunosBase/"]
RUN dotnet restore "AlunosBase/AlunosBase.csproj"
COPY . .
WORKDIR "/src/AlunosBase"
RUN dotnet build "AlunosBase.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AlunosBase.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlunosBase.dll"]
