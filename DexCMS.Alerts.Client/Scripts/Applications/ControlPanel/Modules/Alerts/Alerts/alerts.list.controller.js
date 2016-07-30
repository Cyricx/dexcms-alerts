define([
   'controlpanel-app'
], function (app) {
    app.controller('alertsListCtrl', [
        '$scope',
        'Alerts',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        '$filter',
        function ($scope, Alerts, DTOptionsBuilder, DTColumnBuilder, $compile, $window, $filter) {
            $scope.title = "View Alerts";

            $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                return Alerts.getList();
            }).withBootstrap().withOption('createdRow', createdRow);

            $scope.dtColumns = [
                DTColumnBuilder.newColumn('alertID').withTitle('ID'),
                DTColumnBuilder.newColumn('alertText').withTitle('Alert'),
                DTColumnBuilder.newColumn('startDate').withTitle('Start').renderWith(dateHtml),
                DTColumnBuilder.newColumn('endDate').withTitle('End').renderWith(dateHtml),
                DTColumnBuilder.newColumn('displayOrder').withTitle('Order'),
                DTColumnBuilder.newColumn(null).withTitle('').notSortable().renderWith(actionsHtml)
            ];

            function dateHtml(data, type, full, meta) {
                if (data != null) {
                    return $filter('date')(data, "MM/dd/yyyy h:mm a");
                } else {
                    return null;
                }
            }

            function createdRow(row, data, dataIndex) {
                // Recompiling so we can bind Angular directive to the DT
                $compile(angular.element(row).contents())($scope);
            }

            function actionsHtml(data, type, full, meta) {
                var buttons = '<a class="btn btn-warning" ui-sref="alerts/:id({id: +' + data.alertID + '})">' +
                   '   <i class="fa fa-edit"></i>' +
                   '</a>';
                    buttons += ' <button class="btn btn-danger" ng-click="delete(' + data.alertID + ')">' +
                   '   <i class="fa fa-trash-o"></i>' +
                   '</button>';
                return buttons;
            }

            $scope.delete = function (id) {
                if (confirm('Are you sure?')) {
                    Alerts.deleteItem(id).then(function (response) {
                        $window.location.reload();
                    });
                }
            };
        }
    ]);
});