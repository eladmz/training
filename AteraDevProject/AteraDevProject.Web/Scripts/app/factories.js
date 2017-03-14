var factories = {
    DeviceService: function ($http) {
        var urlBase = 'http://localhost:55178/api';
        
        this.getAllDevices = function () {
            return $http.get(urlBase + '/Devices/GetAllDevices');
        };

        this.getDevicesByOwnerName = function (ownerName) {
            $http.defaults.headers.post["Content-Type"] = "application/x-www-form-urlencoded";

            return $http.post(urlBase + '/Devices/GetDevicesByOwnerName', "=" + ownerName);
        };

        return this;
    }
};

ateraApp.factory(factories);