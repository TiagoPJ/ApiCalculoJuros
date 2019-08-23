#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 5001

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["TaxaJuros/Api/Api.csproj", "Api/"]
COPY ["TaxaJuros/Aplicacao/Aplicacao.csproj", "Aplicacao/"]
COPY ["TaxaJuros/Dominio/Dominio.csproj", "Dominio/"]
COPY ["TaxaJuros/Servico/Servico.csproj", "Servico/"]
RUN dotnet restore "Api/Api.csproj"
COPY . .
WORKDIR "/src/TaxaJuros/Api"
RUN dotnet build "Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Api.dll"]