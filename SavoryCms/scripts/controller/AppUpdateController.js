//新建数据库
function AppUpdateController($scope, $state, $stateParams, SavoryCmsService) {

    $scope.id = $stateParams.id;

    function app_editable_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
        {
            $scope.appTypeIds = $scope.item.appTypeId;
            var items = [];
            for (var i = 0; i < $scope.item.appTypeId.length; i++) {
                if ($scope.item.appTypeId[i].selected) {
                    $scope.item.appTypeId_value = $scope.item.appTypeId[i];
                    break;
                }
            }
        }
    }

    function app_update_callback(response) {
        if (response.status != 1) {
            return;
        }

        $state.go('app.app-item', { id: $scope.id });
    }

    $scope.confirmUpdate = function () {

        $scope.waiting = true;
        $scope.message = null;

        var request = {};
        request.item = $scope.item;
        {
            var items = [];
            for (var i = 0; i < $scope.appTypeIds.length; i++) {
                if ($scope.appTypeIds[i] == $scope.item.appTypeId_value) {
                    items.push($scope.appTypeIds[i]);
                    $scope.appTypeIds[i].selected = true;
                    break;
                }
            }
            request.item.appTypeId = items;
        }

        SavoryCmsService.app_update(request).then(app_update_callback)
    }

    {
        var request = {};
        request.id = $scope.id;

        SavoryCmsService.app_editable(request).then(app_editable_callback);
    }
}
