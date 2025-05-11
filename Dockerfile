FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["src/Ims.API/Ims.API.csproj", "Ims.API/"]
COPY ["src/Ims.Application/Ims.Application.csproj", "Ims.Application/"]
COPY ["src/Ims.Domain/Ims.Domain.csproj", "Ims.Domain/"]
COPY ["src/Ims.Infra/Ims.Infra.csproj", "Ims.Infra/"]
RUN dotnet restore "Ims.API/Ims.API.csproj"

COPY ["src/Ims.API", "Ims.API/"]
WORKDIR /src/Ims.API
RUN dotnet build "Ims.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ims.API.dll"]
