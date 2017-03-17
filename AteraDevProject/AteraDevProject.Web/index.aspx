<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AteraDevProject.Web.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Atera Developer Project</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body ng-app="ateraApp">
    <div class="container" ng-controller="devicesController">
        <div class="row">
            <div class="col-sm-12">
                <div class="page-header text-center">
                    <h1>Atera Developer Project <small>By Elad Mizrahi</small></h1>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <h4 class="col-sm-12">Please choose what you want to view:</h4>
            </div>
            <div class="form-group">
                <div class="col-sm-3">
                    <input class="form-control" type="text" ng-model="ownerName" placeholder="Owner Name" />
                </div>
                <div class="col-sm-3">
                    <button class="btn btn-default btn-block" ng-disabled="getByNameButtonDisabled" ng-click="getDevicesByOwnerName(ownerName)">Get Devices By Owner Name</button>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-3">
                    <input class="form-control" type="text" ng-model="ownerCountry" placeholder="Owner Country" />
                </div>
                <div class="col-sm-3">
                    <button class="btn btn-default btn-block" ng-disabled="getByCountryButtonDisabled" ng-click="getDevicesByOwnerCountry(ownerCountry)">Get Devices By Owner Country</button>
                </div>
                <div class="col-sm-3 col-sm-offset-3">
                    <button class="btn btn-default btn-block" ng-disabled="getAllButtonDisabled" ng-click="getAllDevices()">Get All Devices</button>
                </div>
            </div>
        </div>

        <div class="row">
            <table class="table table-bordered">
                <tr>
                    <th class="col-sm-1 text-center">Device Id</th>
                    <th class="col-sm-2 text-center">Name</th>
                    <th class="col-sm-2 text-center">Date Created</th>
                    <th class="col-sm-2 text-center">Owner Name</th>
                    <th class="col-sm-2 text-center">Owner Country</th>
                </tr>
                <tr ng-repeat="device in devices">
                    <td>{{device.DeviceId}}</td>
                    <td>{{device.Name}}</td>
                    <td>{{device.Created | date : "dd.MM.yyyy HH:mm:ss"}}</td>
                    <td>{{device.Owners.FullName}}</td>
                    <td>{{device.Owners.Country}}</td>
                </tr>
                <tr ng-if="!dataExist">
                    <td colspan="5">No Results</td>
                </tr>
            </table>
        </div>
    </div>

    <!--lib-->
    <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/ui-bootstrap.min.js"></script>

    <!--app-->
    <script src="Scripts/app/app.js?ver=1.00"></script>
    <script src="Scripts/app/factories.js?ver=1.00"></script>
    <script src="Scripts/app/controllers.js?ver=1.00"></script>
</body>
</html>
