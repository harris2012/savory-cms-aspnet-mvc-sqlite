function AppListController($scope, $state, $stateParams, SavoryCmsService) {

    function app_items_callback(response) {

        $scope.items_loaded = true;

        if (response.status !== 1) {
            $scope.items_message = response.message;
            return;
        }

        $scope.items = response.items;
    }

    function app_count_callback(response) {

        $scope.count_loaded = true;
        if (response.status !== 1) {
            $scope.count_message = response.message;
            return;
        }

        $scope.totalCount = response.totalCount;
    }

    $scope.pageChanged = function () {

        $scope.items_loaded = false;
        $scope.items_message = null;

        var request = {};

        request.pageIndex = $scope.currentPage;

        SavoryCmsService.app_items(request).then(app_items_callback);
    }

    {
        $scope.maxSize = 10;
        $scope.currentPage = 1;
        $scope.pageSize = 20;

        SavoryCmsService.app_count({}).then(app_count_callback);
        SavoryCmsService.app_items({pageIndex: $scope.currentPage}).then(app_items_callback);
    }

}
