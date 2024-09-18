var app = angular.module('TareaApp', ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: '/wwwroot/index.html',
            controller: 'TareasController'
        })
        .when('/CrearLista', {
            templateUrl: '/wwwroot/views/tarea-form.html',
            controller: 'TareasController'
        })
        .when('/EditarTarea/:id', {
            templateUrl: '/wwwroot/views/tarea-edit.html',
            controller: 'TareasController'
        })
        .when('/verLista', {
            templateUrl: '/wwwroot/views/tareas.html',
            controller: 'TareasController'
        })
        .otherwise({
            redirectTo: '/'
        });
}]);
