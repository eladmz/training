var controllers = {
    devicesController: function ($scope, DeviceService) {

        $scope.dataExist = false;
        $scope.getAllButtonDisabled = false;
        $scope.getByNameButtonDisabled = false;

        $scope.getAllDevices = function () {
            $scope.getAllButtonDisabled = true;

            DeviceService.getAllDevices()
                .then(function (response) {
                    $scope.devices = response.data;
                })
                .catch(function (response) {
                    console.error('Get All Devices Error: ', response.status, response.data);
                })
                .finally(function () {
                    $scope.getAllButtonDisabled = false;
                    $scope.dataExist = $scope.devices == null || $scope.devices.length == 0 ? false : true;
                });
        },

        $scope.getDevicesByOwnerName = function (ownerName) {
            $scope.getByNameButtonDisabled = true;

            DeviceService.getDevicesByOwnerName(ownerName)
                .then(function (response) {
                    $scope.devices = response.data;
                })
                .catch(function (response) {
                    console.error('Get Devices By Owner Name Error: ', response.status, response.data);
                })
                .finally(function () {
                    $scope.getByNameButtonDisabled = false;
                    $scope.dataExist = $scope.devices == null || $scope.devices.length == 0 ? false : true;
                });
        }
    }
};

ateraApp.controller(controllers);