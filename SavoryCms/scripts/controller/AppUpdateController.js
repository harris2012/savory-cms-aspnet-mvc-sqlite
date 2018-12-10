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
            for (var i = 0; i < $scope.item.appTypeId.length; i++) {
                if ($scope.item.appTypeId[i].selected) {
                    $scope.item.app_type_id_value = $scope.item.appTypeId[i].appTypeId;
                    break;
                }
            }
        }
    }

    function app_update_callback(response) {
        if (response.status != 1) {
            swal(response.message);
            return;
        }

        $state.go('app.app-item', { id: $scope.id });
    }

    $scope.confirmUpdate = function () {

        $scope.waiting = true;
        $scope.message = null;

        var request = {};
        request.id = $scope.item.id;
        request.appId = $scope.item.appId;
        request.appEname = $scope.item.appEname;
        request.appName = $scope.item.appName;
        request.appTypeId = $scope.item.app_type_id_value;
        request.dataStatus = $scope.item.dataStatus;
        request.description = $scope.item.description;

        SavoryCmsService.app_update(request).then(app_update_callback)
    }

    {
        var request = {};
        request.id = $scope.id;

        SavoryCmsService.app_editable(request).then(app_editable_callback);
    }
}
