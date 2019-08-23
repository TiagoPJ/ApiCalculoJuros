angular.module('SoftplanApp')
    .service('TaxaService', ['$http', function ($http) {

        var urlBase = 'http://localhost:5001/ObterTaxaJuros';
        this.getTaxa = function () {
            return $http.get(urlBase);
        };
    }]);
