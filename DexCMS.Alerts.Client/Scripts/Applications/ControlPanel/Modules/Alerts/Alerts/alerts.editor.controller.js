define([
   'controlpanel-app'
], function (app) {
    app.controller('alertsEditorCtrl', [
        '$scope',
        'Alerts',
        '$stateParams',
        '$state',
        function ($scope, Alerts, $stateParams, $state) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Alert";

            $scope.currentItem = { displayOrder: 0};

            if (id != null) {
                Alerts.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.alertID) {
                    Alerts.updateItem(item.alertID, item).then(function (response) {
                        $state.go('alerts');
                    });
                } else {
                    Alerts.createItem(item).then(function (response) {
                        $state.go('alerts');
                    });
                }
            }
        }
    ]);
});