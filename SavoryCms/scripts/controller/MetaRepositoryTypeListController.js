function MetaRepositoryTypeListController($scope, $state, $stateParams, SavoryCmsService) {

    function meta_repository_type_items_callback(response) {

        $scope.items_loaded = true;

        if (response.status !== 1) {
            $scope.items_message = response.message;
            return;
        }

        $scope.items = response.items;
    }

    function meta_repository_type_count_callback(response) {

        $scope.count_loaded = true;
        if (response.status !== 1) {
            $scope.count_message = response.message;
            return;
        }

        $scope.totalCount = response.totalCount;
    }

    //分页
    $scope.pageChanged = function () {

        $scope.items_loaded = false;
        $scope.items_message = null;

        var request = {};

        request.pageIndex = $scope.currentPage;

        SavoryCmsService.meta_repository_type_items(request).then(meta_repository_type_items_callback);
    };

    {
        $scope.maxSize = 10;
        $scope.currentPage = 1;
        $scope.pageSize = 20;

        SavoryCmsService.meta_repository_type_count({}).then(meta_repository_type_count_callback);
        SavoryCmsService.meta_repository_type_items({pageIndex: $scope.currentPage}).then(meta_repository_type_items_callback);
    }

}
