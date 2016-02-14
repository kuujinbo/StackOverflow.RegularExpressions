var app = angular.module('plunker', []);
app.controller('MainCtrl', function ($scope) { });

app.directive('inputRestrictor', [function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            // changed here
            var pattern = /^(?:|(?:[0-9]+(?:\.[0-9]{0,4})?))$/g;
            var view_value;

            function fromUser(text) {
                var return_value;
                if (text.match(pattern) === null) {
                    return_value = view_value;
                    // changed here
                    ngModelCtrl.$setViewValue(view_value || '');
                    ngModelCtrl.$render();
                }
                else {
                    return_value = text;
                    view_value = return_value;
                }

                return return_value;
            }
            ngModelCtrl.$parsers.push(fromUser);
        }
    };
}]);