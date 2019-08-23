app.controller('CaculaJurosController', ['$scope', '$location', 'CalculoJurosService', function ($scope, $location, CalculoJurosService) {
    $scope.valorCalculado;
    $scope.urlProjeto;
    $scope.urlIframeProjeto;
    $scope.IsVisible = false;
    $scope.form = {
        valorInicial: null,
        valorJuros: null,
        meses: null
    };

    $scope.calcularValorFinal = function (taxa) {
        $scope.form.valorJuros = taxa;
        if ($scope.form.valorInicial && $scope.form.valorInicial > 0) {
            if ($scope.form.meses && $scope.form.meses > 0) {
                CalculoJurosService.getCalculo($scope.form)
                    .then(function (response) {
                        if (response.data.isOk) {
                            $scope.valorCalculado = response.data.retorno.valor;
                            $scope.IsVisible = $scope.IsVisible = true;
                            alert(response.data.mensagem);
                        } else {
                            alert(response.data.mensagem + ': ' + response.data.erros[0]);
                        }
                    },
                        function (err) {
                            alert('Ocorreu algum problema ao calcular os juros.');
                        });
            }
            else
                alert('Os meses deve ser maior que ZERO.');
        }
        else
            alert('Valor inicial deve ser maior que ZERO.');
    };

    $scope.retornaInformacoesProjeto = function () {
        CalculoJurosService.getInformacoesProjeto()
            .then(function (response) {
                if (response.data.isOk) {
                    $scope.urlProjeto = response.data.retorno.urlProjeto;
                    $scope.urlIframeProjeto = response.data.retorno.urlIframeProjeto;
                } else {
                    alert(response.data.mensagem + ': ' + response.data.erros[0]);
                }
            },
                function (err) {
                    alert('Ocorreu algum problema ao retornar as informações do projeto.');
                });
    }
}]);