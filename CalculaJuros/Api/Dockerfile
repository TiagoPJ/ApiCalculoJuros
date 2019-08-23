#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 5002

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["CalculaJuros/Api/Api.csproj", "Api/"]
COPY ["CalculaJuros/Aplicacao/Aplicacao.csproj", "Aplicacao/"]
COPY ["CalculaJuros/Dominio/Dominio.csproj", "Dominio/"]
COPY ["CalculaJuros/Servico/Servico.csproj", "Servico/"]
RUN dotnet restore "Api/Api.csproj"
COPY . .
WORKDIR "/src/CalculaJuros/Api"
RUN dotnet build "Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Api.dll"]