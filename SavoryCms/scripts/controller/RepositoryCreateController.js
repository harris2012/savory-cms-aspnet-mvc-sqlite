function RepositoryCreateController($scope, $state, $stateParams, SavoryCmsService) {

    function repository_empty_callback(response) {

        if (response.status != 1) {
            swal(response.message);
            return;
        }

        $scope.item = response.item;
        {
            if($scope.item.repositoryTypeId.length > 0)
            {
                $scope.item.repository_type_id_value = $scope.item.repositoryTypeId[0].repositoryTypeId;
            }
        }
    }

    function repository_create_callback(response) {

        $scope.waiting = false;

        if (response.status != 1) {
            $scope.message = response.message;
            return;
        }

        $state.go('app.repository-list');
    }

    $scope.confirmCreate = function () {

        $scope.waiting = true;
        $scope.message = null;

        var request = {};
        request.id = $scope.item.id;
        request.repositoryName = $scope.item.repositoryName;
        request.repositoryTypeId = $scope.item.repository_type_id_value;
        request.gitlabProjectFullname = $scope.item.gitlabProjectFullname;
        request.dataStatus = $scope.item.dataStatus;
        request.description = $scope.item.description;

        SavoryCmsService.repository_create(request).then(repository_create_callback)
    }

    {
        SavoryCmsService.repository_empty({}).then(repository_empty_callback);
    }
}
