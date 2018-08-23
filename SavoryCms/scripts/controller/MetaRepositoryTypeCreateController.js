function MetaRepositoryTypeCreateController($scope, $state, $stateParams, SavoryCmsService) {

    $scope.item = {};

    function meta_repository_type_create_callback(response) {

        $scope.waiting = false;

        if (response.status != 1) {
            $scope.message = response.message;
            return;
        }

        $state.go('app.meta-repository-type-list');
    }

    $scope.confirmCreate = function () {

        $scope.waiting = true;
        $scope.message = null;

        var request = {};
        request.item = $scope.item;

        SavoryCmsService.meta_repository_type_create(request).then(meta_repository_type_create_callback)
    }

}
