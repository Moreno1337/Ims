FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY src/Ims.API/Ims.API.csproj src/Ims.API/
COPY src/Ims.Application/Ims.Application.csproj src/Ims.Application/
COPY src/Ims.Domain/Ims.Domain.csproj src/Ims.Domain/
COPY src/Ims.Infra/Ims.Infra.csproj src/Ims.Infra/
RUN dotnet restore "src/Ims.API/Ims.API.csproj"

COPY src/ src/
WORKDIR /src/src/Ims.API
RUN dotnet build "Ims.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ims.API.dll"]
