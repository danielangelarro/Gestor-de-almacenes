   FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
   WORKDIR /app

   # Copia csproj y restaura las dependencias
   COPY *.csproj ./
   RUN dotnet restore

   # Copia todo el código fuente y compila la aplicación
   COPY . ./
   RUN dotnet publish -c Release -o out

   FROM mcr.microsoft.com/dotnet/aspnet:7.0
   WORKDIR /app
   COPY --from=build-env /app/out .
   ENTRYPOINT ["dotnet", "your-app.dll"]