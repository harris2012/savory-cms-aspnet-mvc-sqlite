//新建数据库
function MetaRepositoryTypeUpdateController($scope, $state, $stateParams, SavoryCmsService) {

    $scope.id = $stateParams.id;

    function meta_repository_type_editable_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
    }

    function meta_repository_type_update_callback(response) {
        if (response.status != 1) {
            return;
        }

        $state.go('app.meta-repository-type-item', { id: $scope.id });
    }

    $scope.confirmUpdate = function () {

        $scope.waiting = true;
        $scope.message = null;

        var request = {};
        request.item = $scope.item;

        SavoryCmsService.meta_repository_type_update(request).then(meta_repository_type_update_callback)
    }

    {
        var request = {};
        request.id = $scope.id;

        SavoryCmsService.meta_repository_type_editable(request).then(meta_repository_type_editable_callback);
    }
}
