var app = angular.module('app', []);

app.controller('MainController', function($scope, $http) {
    $scope.num;
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

    // lab 6
    $scope.a;
    $scope.b;
    $scope.c;
    $scope.add = function(a, b) {
        $http.get('/api/numbers/add', { params: { a: a, b: b } })
            .success(function(data) {
                $scope.c = data;
            });
    };

    $scope.sub = function(a, b) {
        $http.get('/api/numbers/substract', { params: { a: a, b: b } })
            .success(function(data) {
                $scope.c = data;
            });
    };

    $scope.mul = function(a, b) {
        $http.get('/api/numbers/multiply', { params: { a: a, b: b } })
            .success(function(data) {
                $scope.c = data;
            });
    };

    $scope.div = function (a, b) {
        if (b === '0')
            $scope.c = 'divide by zero';
        $http.get('/api/numbers/divide', { params: { a: a, b: b } })
            .success(function(data) {
                $scope.c = data;
            });
    };
});