function RepositoryCreateController($scope, $state, $stateParams, SavoryCmsService) {

    $scope.item = {};

    function repository_create_callback(response) {

        $scope.waiting = false;

        if (response.status != 1) {
            $scope.message = response.message;
            return;
        }

        $state.go('app.repository-list');
    }

    function meta_repository_type_items_for_repository_type_id_callback(response) {

        if (response.status == 1) {
            $scope.repositoryTypeIds = response.items;
        }
    }

    $scope.confirmCreate = function () {

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

        SavoryCmsService.repository_create(request).then(repository_create_callback)
    }

    {
        var request = {};
        request.pageIndex = 1;

        SavoryCmsService.meta_repository_type_items(request).then(meta_repository_type_items_for_repository_type_id_callback)
    }
}
