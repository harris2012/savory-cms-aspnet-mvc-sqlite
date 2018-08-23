function MetaRepositoryTypeItemController($scope, $state, $stateParams, SavoryCmsService) {

    $scope.id = $stateParams.id;

    function meta_repository_type_item_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
    }

    {
        var request = {};
        request.id = $scope.id;

        SavoryCmsService.meta_repository_type_item(request).then(meta_repository_type_item_callback);
    }
}
