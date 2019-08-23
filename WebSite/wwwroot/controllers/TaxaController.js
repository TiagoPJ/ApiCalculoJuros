app.controller('TaxaController', ['$scope', '$location', '$rootScope', 'TaxaService', function ($scope, $location, $rootScope, TaxaService) {
    $scope.valorTaxa;

    $scope.getTaxa = function () {
        TaxaService.getTaxa()
            .then(function (response) {
                if (response.data.isOk) {
                    $scope.valorTaxa = response.data.retorno.juros;
                } else {
                    alert(response.data.mensagem + ': ' + response.data.erros[0]);
                }
            },
            function (err) {
                    alert('Ocorreu algum problema ao retornar o valor da taxa.');
            });
    };

    $scope.go = function (path) {
        $location.path(path);
    };
}]);