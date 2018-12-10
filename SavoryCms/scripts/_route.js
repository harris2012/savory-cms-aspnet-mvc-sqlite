var route = function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.when('', '/welcome').when('/', '/welcome');

    $stateProvider.state('app', {
        url: '/',
        views: {
            'header': { templateUrl: 'scripts/view/view_header.html?v=' + window.releaseNo, controller: HeaderController },
            'main-menu': { templateUrl: 'scripts/view/view_menu.html?v=' + window.releaseNo},
            'main-body': { template: '<div ui-view></div>' }
        }
    });

    $stateProvider.state('app.welcome', { url: 'welcome', templateUrl: 'scripts/view/view_welcome.html?v=' + window.releaseNo });

    $stateProvider.state('app.app-list', { url: 'app-list', templateUrl: 'scripts/view/view_app_list.html?v=' + window.releaseNo, controller: AppListController });
    $stateProvider.state('app.app-item', { url: 'app-item/:id', templateUrl: 'scripts/view/view_app_item.html?v=' + window.releaseNo, controller: AppItemController });
    $stateProvider.state('app.app-create', { url: 'app-create', templateUrl: 'scripts/view/view_app_create.html?v=' + window.releaseNo, controller: AppCreateController });
    $stateProvider.state('app.app-update', { url: 'app-update/:id', templateUrl: 'scripts/view/view_app_update.html?v=' + window.releaseNo, controller: AppUpdateController });

    $stateProvider.state('app.repository-list', { url: 'repository-list', templateUrl: 'scripts/view/view_repository_list.html?v=' + window.releaseNo, controller: RepositoryListController });
    $stateProvider.state('app.repository-item', { url: 'repository-item/:id', templateUrl: 'scripts/view/view_repository_item.html?v=' + window.releaseNo, controller: RepositoryItemController });
    $stateProvider.state('app.repository-create', { url: 'repository-create', templateUrl: 'scripts/view/view_repository_create.html?v=' + window.releaseNo, controller: RepositoryCreateController });
    $stateProvider.state('app.repository-update', { url: 'repository-update/:id', templateUrl: 'scripts/view/view_repository_update.html?v=' + window.releaseNo, controller: RepositoryUpdateController });

    $stateProvider.state('app.meta-app-type-list', { url: 'meta-app-type-list', templateUrl: 'scripts/view/view_meta_app_type_list.html?v=' + window.releaseNo, controller: MetaAppTypeListController });
    $stateProvider.state('app.meta-app-type-item', { url: 'meta-app-type-item/:id', templateUrl: 'scripts/view/view_meta_app_type_item.html?v=' + window.releaseNo, controller: MetaAppTypeItemController });
    $stateProvider.state('app.meta-app-type-create', { url: 'meta-app-type-create', templateUrl: 'scripts/view/view_meta_app_type_create.html?v=' + window.releaseNo, controller: MetaAppTypeCreateController });
    $stateProvider.state('app.meta-app-type-update', { url: 'meta-app-type-update/:id', templateUrl: 'scripts/view/view_meta_app_type_update.html?v=' + window.releaseNo, controller: MetaAppTypeUpdateController });

    $stateProvider.state('app.meta-repository-type-list', { url: 'meta-repository-type-list', templateUrl: 'scripts/view/view_meta_repository_type_list.html?v=' + window.releaseNo, controller: MetaRepositoryTypeListController });
    $stateProvider.state('app.meta-repository-type-item', { url: 'meta-repository-type-item/:id', templateUrl: 'scripts/view/view_meta_repository_type_item.html?v=' + window.releaseNo, controller: MetaRepositoryTypeItemController });
    $stateProvider.state('app.meta-repository-type-create', { url: 'meta-repository-type-create', templateUrl: 'scripts/view/view_meta_repository_type_create.html?v=' + window.releaseNo, controller: MetaRepositoryTypeCreateController });
    $stateProvider.state('app.meta-repository-type-update', { url: 'meta-repository-type-update/:id', templateUrl: 'scripts/view/view_meta_repository_type_update.html?v=' + window.releaseNo, controller: MetaRepositoryTypeUpdateController });

    $stateProvider.state('app.otherwise', {
        url: '*path',
        templateUrl: 'views/view_404.html?v=' + window.releaseNo
    });
}