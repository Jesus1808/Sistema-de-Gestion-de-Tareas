app.controller('TareasController', ['$scope', '$routeParams', '$window', 'TareasService', function($scope, $routeParams, $window, TareasService) {
    $scope.tareas = [];
    $scope.nuevaTarea = {};
    $scope.tareaActualizada = {};
    $scope.alert = null;

    // Obtener el id de la tarea desde la URL (para edición)
    var tareaId = $routeParams.id;

    if (tareaId) {
        TareasService.getTareaById(tareaId).then(function(response) {
            $scope.tareaActualizada = response.data;
        }, function(error) {
            console.error('Ha sucesido un error al obtener la tarea:', error);
        });
    }

    // Obtener todas las tareas
    $scope.cargarTareas = function() {
        TareasService.getTareas().then(function(response) {
            $scope.tareas = response.data;
        }, function(error) {
            console.error('Ha sucesido un error al obtener las tareas:', error);
        });
    };

    // Crear nueva tarea
    $scope.crearTarea = function() {
        if ($scope.tareaForm.$valid) {
            TareasService.createTarea($scope.nuevaTarea).then(function(response) {
                $scope.tareas.push(response.data);
                $scope.nuevaTarea = {};
                showAlert('success', 'ha sido creada correctamente la tarea.');
            }, function(error) {
                console.error('Ha sucesido un error al crear la tarea:', error);
            });
        } else {
            showAlert('warning', 'Verifique los campos obligatorios.');
        }

    };

    // Actualizar tarea
    $scope.actualizarTarea = function(id) {
        TareasService.updateTarea(id, $scope.tareaActualizada).then(function(response) {
            $scope.cargarTareas();
            showAlert('success', 'ha sido actualizada correctamente la tarea.');
        }, function(error) {
            console.error('Ha sucesido un error al actualizar la tarea:', error);
        });
    };

    // Eliminar tarea
    $scope.eliminarTarea = function(id) {
        TareasService.deleteTarea(id).then(function(response) {
            showAlert('success', 'ha sido eliminada correctamente la tarea.');
            $scope.cargarTareas();
        }, function(error) {
            console.error('Ha sucesido un error al eliminar la tarea:', error);
        });
    };

    // Inicializar cargando las tareas
    $scope.cargarTareas();


    function showAlert(type, message) {
        $scope.alert = { type: type, message: message };
        setTimeout(function() {
            $scope.alert = null;
            $scope.$apply();
        }, 3000);
    }
}]);