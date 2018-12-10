function MetaRepositoryTypeCreateController($scope, $state, $stateParams, SavoryCmsService) {

    function meta_repository_type_empty_callback(response) {

        if (response.status != 1) {
            swal(response.message);
            return;
        }

        $scope.item = response.item;
    }

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
        request.id = $scope.item.id;
        request.repositoryTypeId = $scope.item.repositoryTypeId;
        request.repositoryTypeName = $scope.item.repositoryTypeName;

        SavoryCmsService.meta_repository_type_create(request).then(meta_repository_type_create_callback)
    }

    {
        SavoryCmsService.meta_repository_type_empty({}).then(meta_repository_type_empty_callback);
    }
}
