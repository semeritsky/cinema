; (function (ng) {

    'use strict';
   
    var dependencyService = ng.injector(['dependency']).get('dependencyService');
    ng.module('app', dependencyService.get())

})(window.angular);