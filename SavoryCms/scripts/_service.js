function SavoryCmsService($resource, $q) {

    var resource = $resource('api/search-support', {}, {

        app_items: { method: 'POST', url: 'api/app/items' },
        app_item: { method: 'POST', url: 'api/app/item' },
        app_count: { method: 'POST', url: 'api/app/count' },
        app_update: { method: 'POST', url: 'api/app/update' },
        app_enable: { method: 'POST', url: 'api/app/enable' },
        app_disable: { method: 'POST', url: 'api/app/disable' },
        app_create: { method: 'POST', url: 'api/app/create' },
        app_editable: { method: 'POST', url: 'api/app/editable' },

        repository_items: { method: 'POST', url: 'api/repository/items' },
        repository_item: { method: 'POST', url: 'api/repository/item' },
        repository_count: { method: 'POST', url: 'api/repository/count' },
        repository_update: { method: 'POST', url: 'api/repository/update' },
        repository_enable: { method: 'POST', url: 'api/repository/enable' },
        repository_disable: { method: 'POST', url: 'api/repository/disable' },
        repository_create: { method: 'POST', url: 'api/repository/create' },
        repository_editable: { method: 'POST', url: 'api/repository/editable' },

        meta_app_type_items: { method: 'POST', url: 'api/meta-app-type/items' },
        meta_app_type_item: { method: 'POST', url: 'api/meta-app-type/item' },
        meta_app_type_count: { method: 'POST', url: 'api/meta-app-type/count' },
        meta_app_type_update: { method: 'POST', url: 'api/meta-app-type/update' },
        meta_app_type_enable: { method: 'POST', url: 'api/meta-app-type/enable' },
        meta_app_type_disable: { method: 'POST', url: 'api/meta-app-type/disable' },
        meta_app_type_create: { method: 'POST', url: 'api/meta-app-type/create' },
        meta_app_type_editable: { method: 'POST', url: 'api/meta-app-type/editable' },

        meta_repository_type_items: { method: 'POST', url: 'api/meta-repository-type/items' },
        meta_repository_type_item: { method: 'POST', url: 'api/meta-repository-type/item' },
        meta_repository_type_count: { method: 'POST', url: 'api/meta-repository-type/count' },
        meta_repository_type_update: { method: 'POST', url: 'api/meta-repository-type/update' },
        meta_repository_type_enable: { method: 'POST', url: 'api/meta-repository-type/enable' },
        meta_repository_type_disable: { method: 'POST', url: 'api/meta-repository-type/disable' },
        meta_repository_type_create: { method: 'POST', url: 'api/meta-repository-type/create' },
        meta_repository_type_editable: { method: 'POST', url: 'api/meta-repository-type/editable' },

        user_profile: { method: 'POST', url: 'api/user/profile' }
    });

    return {

        app_items: function (request) { var d = $q.defer(); resource.app_items({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        app_item: function (request) { var d = $q.defer(); resource.app_item({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        app_update: function (request) { var d = $q.defer(); resource.app_update({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        app_count: function (request) { var d = $q.defer(); resource.app_count({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        app_enable: function (request) { var d = $q.defer(); resource.app_enable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        app_disable: function (request) { var d = $q.defer(); resource.app_disable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        app_create: function (request) { var d = $q.defer(); resource.app_create({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        app_editable: function (request) { var d = $q.defer(); resource.app_editable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },

        repository_items: function (request) { var d = $q.defer(); resource.repository_items({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        repository_item: function (request) { var d = $q.defer(); resource.repository_item({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        repository_update: function (request) { var d = $q.defer(); resource.repository_update({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        repository_count: function (request) { var d = $q.defer(); resource.repository_count({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        repository_enable: function (request) { var d = $q.defer(); resource.repository_enable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        repository_disable: function (request) { var d = $q.defer(); resource.repository_disable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        repository_create: function (request) { var d = $q.defer(); resource.repository_create({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        repository_editable: function (request) { var d = $q.defer(); resource.repository_editable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },

        meta_app_type_items: function (request) { var d = $q.defer(); resource.meta_app_type_items({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        meta_app_type_item: function (request) { var d = $q.defer(); resource.meta_app_type_item({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        meta_app_type_update: function (request) { var d = $q.defer(); resource.meta_app_type_update({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        meta_app_type_count: function (request) { var d = $q.defer(); resource.meta_app_type_count({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        meta_app_type_enable: function (request) { var d = $q.defer(); resource.meta_app_type_enable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        meta_app_type_disable: function (request) { var d = $q.defer(); resource.meta_app_type_disable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        meta_app_type_create: function (request) { var d = $q.defer(); resource.meta_app_type_create({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        meta_app_type_editable: function (request) { var d = $q.defer(); resource.meta_app_type_editable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },

        meta_repository_type_items: function (request) { var d = $q.defer(); resource.meta_repository_type_items({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        meta_repository_type_item: function (request) { var d = $q.defer(); resource.meta_repository_type_item({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        meta_repository_type_update: function (request) { var d = $q.defer(); resource.meta_repository_type_update({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        meta_repository_type_count: function (request) { var d = $q.defer(); resource.meta_repository_type_count({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        meta_repository_type_enable: function (request) { var d = $q.defer(); resource.meta_repository_type_enable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        meta_repository_type_disable: function (request) { var d = $q.defer(); resource.meta_repository_type_disable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        meta_repository_type_create: function (request) { var d = $q.defer(); resource.meta_repository_type_create({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        meta_repository_type_editable: function (request) { var d = $q.defer(); resource.meta_repository_type_editable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },

        user_profile: function () { var d = $q.defer(); resource.user_profile({}, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; }
    }
}
