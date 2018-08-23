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
            $scope.repositoryTypeIds = $scope.item.repositoryTypeId;
            var items = [];
            for (var i = 0; i < $scope.item.repositoryTypeId.length; i++) {
                if ($scope.item.repositoryTypeId[i].selected) {
                    $scope.item.repositoryTypeId_value = $scope.item.repositoryTypeId[i];
                    break;
                }
            }
        }
    }

    function repository_update_callback(response) {
        if (response.status != 1) {
            return;
        }

        $state.go('app.repository-item', { id: $scope.id });
    }

    $scope.confirmUpdate = function () {

        $scope.waiting = true;
        $scope.message = null;

        var request = {};
        request.item = $scope.item;
        {
            var items = [];
            for (var i = 0; i < $scope.repositoryTypeIds.length; i++) {
                if ($scope.repositoryTypeIds[i] == $scope.item.repositoryTypeId_value) {
                    items.push($scope.repositoryTypeIds[i]);
                    $scope.repositoryTypeIds[i].selected = true;
                    break;
                }
            }
            request.item.repositoryTypeId = items;
        }

        SavoryCmsService.repository_update(request).then(repository_update_callback)
    }

    {
        var request = {};
        request.id = $scope.id;

        SavoryCmsService.repository_editable(request).then(repository_editable_callback);
    }
}
