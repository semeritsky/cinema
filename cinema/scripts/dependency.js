; (function (ng) {
    'use strict';

    var dependencyList = [
                   'place'
    ];

    var dependencyService = function () {
        var service = this;      

        service.get = function () {
            return dependencyList;
        };
    };


    ng.module('dependency', [])
      .service('dependencyService', dependencyService);


})(window.angular);