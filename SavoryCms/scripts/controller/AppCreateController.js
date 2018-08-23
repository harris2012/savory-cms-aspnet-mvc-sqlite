function AppCreateController($scope, $state, $stateParams, SavoryCmsService) {

    $scope.item = {};

    function app_create_callback(response) {

        $scope.waiting = false;

        if (response.status != 1) {
            $scope.message = response.message;
            return;
        }

        $state.go('app.app-list');
    }

    function meta_app_type_items_for_app_type_id_callback(response) {

        if (response.status == 1) {
            $scope.appTypeIds = response.items;
        }
    }

    $scope.confirmCreate = function () {

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

        SavoryCmsService.app_create(request).then(app_create_callback)
    }

    {
        var request = {};
        request.pageIndex = 1;

        SavoryCmsService.meta_app_type_items(request).then(meta_app_type_items_for_app_type_id_callback)
    }
}
