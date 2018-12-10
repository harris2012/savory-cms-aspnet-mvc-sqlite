function AppItemController($scope, $state, $stateParams, SavoryCmsService) {

    $scope.id = $stateParams.id;

    function app_item_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
    }

    {
        var request = {};
        request.id = $scope.id;

        SavoryCmsService.app_item(request).then(app_item_callback);
    }
}
