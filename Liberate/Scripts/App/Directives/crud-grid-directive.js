﻿app.directive('crudGrid', function () {
    return {
        restrict: 'A',
        replace: false,
        scope: true,
        templateUrl: '/Scripts/App/Directives/Templates/crud-grid-directive-template.html',
        controller: ['$scope', '$element', '$attrs', 'crudGridDataFactory', 'notificationFactory',
            function ($scope, $element, $attrs, crudGridDataFactory, notificationFactory) {
                $scope.objects = [];
                $scope.addMode = false;
                $scope.order = 'Title';
                $scope.currentPage = 0;
                $scope.pageSize = 20;
                $scope.numberOfPages = function () {
                    return Math.ceil($scope.items.length / $scope.pageSize);
                }
                $scope.decending = true;

                $scope.setOrder = function (column) {
                    $scope.decending = !$scope.decending;
                    $scope.order = column;
                };

                $scope.toggleAddMode = function () {
                    $scope.addMode = !$scope.addMode;
                };

                $scope.toggleEditMode = function (object) {
                    object.editMode = !object.editMode;
                };

                var successCallback = function (e, cb) {
                    notificationFactory.success();
                    $scope.getData(cb);
                };

                var successPostCallback = function (e) {
                    successCallback(e, function () {
                        $scope.toggleAddMode();
                        $scope.object = {};
                    });
                };

                var errorCallback = function (e) {
                    notificationFactory.error(e.object.Message);
                };

                $scope.addObject = function () {
                    crudGridDataFactory($attrs.tableName).save($scope.object, successPostCallback, errorCallback);
                };

                $scope.deleteObject = function (object) {
                    crudGridDataFactory($attrs.tableName).delete({ id: object.Id }, successCallback, errorCallback);
                };

                $scope.updateObject = function (object) {
                    crudGridDataFactory($attrs.tableName).update({ id: object.Id }, object, successCallback, errorCallback);
                };

                $scope.getData = function (cb) {
                    crudGridDataFactory($attrs.tableName).query(function (data) {
                        $scope.objects = data;
                        if (cb) cb();
                    });
                };

                $scope.getData();   
            }]
    }
});
app.filter('startFrom', function () {
    return function (input, start, pageSize) {
        start = +start; //parse to int
        pageSize = +pageSize;
        while (start > input.length) {
            start -= pageSize;
        }
        if (start < 0) {
            start = 0;
        }
        return input.slice(start);
    };
});   