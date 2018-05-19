; (function (ng) {
    'use strict';

    var PlaceCtrl = function ($scope, $window, $http) {
        var ctrl = this,
            Data = [];
      
        ctrl.Init = () => {
            $http.post('/Home/Init').then(function (data) {                
                if (data.data.Success) {                    
                    ctrl.Data = data.data.Message;
                }
            });
        }

        ctrl.TakePlace = (RowNumber, Place) => {        
            Place.Busy = !Place.Busy;
            $http.post('/Home/TakePlace', { RowNumber: RowNumber, PlaceNumber: Place.PlaceNumber }).then(function (data) {
                if (data.data.Success) {
                    
                }
            });
        }
        ctrl.Init();
    };

    ng.module('place')
      .controller('PlaceCtrl', PlaceCtrl);
    

})(window.angular);