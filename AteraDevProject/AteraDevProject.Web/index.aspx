<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AteraDevProject.Web.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Atera Developer Project</title>
    
</head>
<body ng-app="ateraApp">
    <div ng-controller="devicesController">
        <button ng-click="getAllDevices()">Get All Devices</button>
        <input type="text" ng-model="ownerName" placeholder="Owner Name" />
        <button ng-click="getDevicesByOwnerName()">Get Devices By Owner Name</button>
        <table class="table">
            <tr>
                <th>Device Id</th>
                <th>Name</th>
                <th>Created</th>
            </tr>
            <tr ng-repeat="device in devices">
                <td>{{device.DeviceId}}</td>
                <td>{{device.Name}}</td>
                <td>{{device.Created | date : "dd.MM.yyyy HH:mm:ss"}}</td>
            </tr>
        </table>
    </div>

    <!--lib-->
    <script src="Scripts/angular.min.js"></script>

    <!--app-->
    <script src="Scripts/app/app.js"></script>
    <script src="Scripts/app/factories.js"></script>
    <script src="Scripts/app/controllers.js"></script>
</body>
</html>
