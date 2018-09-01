function AppCreateController($scope, $state, $stateParams, SavoryCmsService) {

    function app_empty_callback(response) {

        if (response.status != 1) {
            console.log(response.message);
            return;
        }

        $scope.item = response.item;
        {
            if($scope.item.appTypeId.length > 0)
            {
                $scope.item.app_type_id_value = $scope.item.appTypeId[0].appTypeId;
            }
        }
    }

    function app_create_callback(response) {

        $scope.waiting = false;

        if (response.status != 1) {
            $scope.message = response.message;
            return;
        }

        $state.go('app.app-list');
    }

    $scope.confirmCreate = function () {

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

        SavoryCmsService.app_create(request).then(app_create_callback)
    }

    {
        SavoryCmsService.app_empty({}).then(app_empty_callback);
    }
}
