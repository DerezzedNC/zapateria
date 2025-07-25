# Usa una imagen oficial de .NET para compilar y publicar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia archivos del proyecto y restaura dependencias
COPY *.csproj .
RUN dotnet restore

# Copia el resto del código y compílalo
COPY . .
RUN dotnet publish -c Release -o out

# Usa una imagen de runtime ligera para producción
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expone el puerto de la aplicación (asegúrate que coincida con el de tu app)
EXPOSE 80

# Ejecuta la app
ENTRYPOINT ["dotnet", "ZapateriaAPI.dll"]
