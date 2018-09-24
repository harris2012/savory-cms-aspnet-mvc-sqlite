//新建数据库
function RepositoryUpdateController($scope, $state, $stateParams, SavoryCmsService) {

    $scope.id = $stateParams.id;

    function repository_editable_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
        {
            for (var i = 0; i < $scope.item.repositoryTypeId.length; i++) {
                if ($scope.item.repositoryTypeId[i].selected) {
                    $scope.item.repository_type_id_value = $scope.item.repositoryTypeId[i].repositoryTypeId;
                    break;
                }
            }
        }
    }

    function repository_update_callback(response) {
        if (response.status != 1) {
            swal(response.message);
            return;
        }

        $state.go('app.repository-item', { id: $scope.id });
    }

    $scope.confirmUpdate = function () {

        $scope.waiting = true;
        $scope.message = null;

        var request = {};
        request.id = $scope.item.id;
        request.repositoryName = $scope.item.repositoryName;
        request.repositoryTypeId = $scope.item.repository_type_id_value;
        request.gitlabProjectFullname = $scope.item.gitlabProjectFullname;
        request.dataStatus = $scope.item.dataStatus;
        request.description = $scope.item.description;

        SavoryCmsService.repository_update(request).then(repository_update_callback)
    }

    {
        var request = {};
        request.id = $scope.id;

        SavoryCmsService.repository_editable(request).then(repository_editable_callback);
    }
}
