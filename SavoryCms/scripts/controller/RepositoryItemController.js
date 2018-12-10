function RepositoryItemController($scope, $state, $stateParams, SavoryCmsService) {

    $scope.id = $stateParams.id;

    function repository_item_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
    }

    {
        var request = {};
        request.id = $scope.id;

        SavoryCmsService.repository_item(request).then(repository_item_callback);
    }
}
