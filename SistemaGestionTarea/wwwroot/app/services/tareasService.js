app.factory('TareasService', ['$http', function ($http) {
    var apiBase = '/api/Tareas/';

    return {
        // Obtener todas las lista
        getTareas: function () {
            return $http.get(apiBase + 'GetTaskList');
        },

        // Crear tarea
        createTarea: function (tarea) {
            return $http.post(apiBase + 'CreateTask', tarea);
        },

        // Actualizar tarea
        updateTarea: function (id, tarea) {
            return $http.put(apiBase + 'UpdateTask/' + id, tarea);
        },

        // Obtener tarea por Id
        getTareaById: function (id) {
            return $http.get(apiBase + 'GetTaskById/' + id);
        },

        // Eliminar tarea
        deleteTarea: function (id) {
            return $http.delete(apiBase + 'DeleteTask/' + id);
        }
    };
}]);
