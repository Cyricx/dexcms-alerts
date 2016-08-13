define([
   'controlpanel-app'
], function (app) {
    app.controller('alertsListCtrl', [
        '$scope',
        'Alerts',
        '$window',
        '$filter',
        'dexCMSControlPanelSettings',
        function ($scope, Alerts, $window, $filter, dexcmsSettings) {
            $scope.title = "View Alerts";

            var _getDateValue = function (value, item) {
                return $filter('date')(value, "MM/dd/yyyy h:mm a");
            };

            $scope.table = {
                columns: [
                    { property: 'alertID', title: 'ID' },
                    { property: 'alertText', title: 'Alert' },
                    { property: 'startDate', title: 'Start', dataFunction: _getDateValue },
                    { property: 'endDate', title: 'End', dataFunction: _getDateValue },
                    { property: 'displayOrder', title: 'Order' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/alerts/alerts/_alerts.list.buttons.html'
                    },
                ],
                defaultSort: 'alertID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            Alerts.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Alerts'
            };

            Alerts.getList().then(function (data) {
                $scope.table.promiseData = data;
            });

        }
    ]);
});