var app = angular.module('app', []);

app.controller('MainController', function($scope, $http) {
    $scope.num = '123';
    $scope.getNum = function() {
        $http.get('/api/numbers/get_random')
            .success(function(data) {
                $scope.num = data;
            });
    };

    $scope.primes = [];

    $http.get('/api/numbers/primes_list').success(function(data) {
        for (item in data)
            $scope.primes.push(data[item]);
    });

    $scope.checkNum = function() {
        $http({
            url: '/api/numbers/check_number',
            method: "GET",
            params: { value: $scope.num }
        }).success(function(data) {
            if (data === true)
                alert('Prime');
            else alert('Not prime');
        });
    };

    $scope.getPrime = function() {
        $http.get('/api/numbers/get_prime')
            .success(function(data) {
                $scope.num = data;
            });
    };
});