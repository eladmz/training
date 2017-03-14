var controllers = {
    devicesController: function ($scope, DeviceService) {

        $scope.getAllDevices = function () {

            DeviceService.getAllDevices()
                .then(function successCallback(response) {
                    $scope.devices = response.data;
                }, function errorCallback(response) {
                    console.log(response);
                });
        },

        $scope.getDevicesByOwnerName = function () {

            DeviceService.getDevicesByOwnerName($scope.ownerName)
                    .then(function successCallback(response) {
                        $scope.devices = response.data;
                    }, function errorCallback(response) {
                        console.log(response);
                    });
        }
    }
};

ateraApp.controller(controllers);