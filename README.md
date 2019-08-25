# Aplicativo para Calculo de Juros Compostos

Projeto final possuí 3 API's `ASP.NET Core (Sdk .NET Core 2.2)`, conforme descrição abaixo:

### Api TaxaJuros

Esta API tem como objetivo retornar um valor padrão de "0,01" referente à taxa de juros.
	
### Api CalculaJuros

Esta API tem como objetivo calcular e retornar um valor X de acordo com 3 parâmetros.  <br />
(Valor Incial, Valor Taxa (ApiTaxaJuros) e a quantidade de Meses). Também retorna as informações do projeto no GitHub.

### WebSite

SPA simples em Angular na versão 1.6 aonde é possível informar os valores e ver o retorno do cáculo  <br />
após consumir as API's citadas acima, bem como receber os dados do projeto no GitHub.

## Como rodar

### DOCKER (For Windows)

######  Construindo as imagens

Acesse a pasta raíz do projeto `./ApiCalculoJuros` no terminal e construa cada imagem (WebSite, API TaxaJuros e API CalculaJuros):

```
docker build -t website-calculajuros-image -f website/Dockerfile .
```
```
docker build -t apitaxajuros-image -f taxajuros/api/Dockerfile .
```
```
docker build -t apicalculajuros-image -f calculajuros/api/Dockerfile .
```

###### Rodando os containers

Ainda na pasta raíz do projeto `./ApiCalculoJuros`, execute um de cada vez:

```
docker run -it -d -v "$(pwd)\website".ToLower() -p 5000:80 --rm --name website-calculajuros-container website-calculajuros-image
```
```
docker run -it -d -v "$(pwd)\taxajuros\api".ToLower() -p 5001:80 --rm --name apitaxajuros-container apitaxajuros-image
```
```
docker run -it -d -v "$(pwd)\calculajuros\api".ToLower() -p 5002:80 --rm --name apicalculajuros-container apicalculajuros-image
```
### DotNet Run (Caso tenha problema com o Docker)

Basta abrir um terminal para cada projeto listado abaixo e executar os comandos: `dotnet restore` e após `dotnet run` para rodar aplicação.

###### `./ApiCalcuoJuros/WebSite`
###### `./ApiCalcuoJuros/CalculaJuros/Api`
###### `./ApiCalcuoJuros/TaxaJuros/Api`

### IISExpress (Caso ainda tenha problemas)

Basta abrir as solutions dos projetos no VS2017 e executar as mesmas.

## Api's em execução

Após estes processos agora basta acessar o endereço local `http://localhost:5000` que a SPA estará rodando,  <br />
posteriormente acessando as portas 5001 e 5002 é possivel ver o Swagger das aplicações restantes.

Swagger API TaxaJuros

```
http://localhost:5001/swagger/index.html
```

Swagger API CalculaJuros

```
http://localhost:5002/swagger/index.html
```

## Testes da Aplicação API TaxaJuros e API CalculaJuros

##### ApiTaxaJurosMSTest / ApiCalculaJurosMSTest

Os testes unitários das API's foram desenvolvidos com o framework <b>MSTest</b>.

##### APICalculaJurosXUnitTest / ApiTaxaJurosXUniTest

Os testes de integração das API's foram desenvolvidos com o framework <b>xUnit</b>,  <br />
e <b>FluentAssertions</b> os mesmos validam a requisição HTTP feita para as API's. 
