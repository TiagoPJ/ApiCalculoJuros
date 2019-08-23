angular.module('SoftplanApp')
    .service('CalculoJurosService', ['$http', function ($http) {

        var urlBase = 'http://localhost:5002';

        this.getCalculo = function (objeto) {
            return $http.post(urlBase + "/Calculo/CalculaJurosCompostos", JSON.stringify(objeto));
        };

        this.getInformacoesProjeto = function () {
            return $http.get(urlBase + "/InformacoesProjeto/ObterInformacoesProjeto");
        };
    }]);
