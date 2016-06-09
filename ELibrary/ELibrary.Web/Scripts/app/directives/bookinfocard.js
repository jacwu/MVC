(function () {
    "use strict";

    angular.module("elibrary.web").directive("bookInfoCard", function () {
        return {
            scope: {
                book: "=",
                initialCollapsed: "@collapsed"
            },
            templateUrl: "Scripts/app/directives/bookinfocard.html",
            controller: function ($scope) {
                $scope.collapsed = ($scope.initialCollapsed === "true");


                $scope.collapse = function () {
                    $scope.collapsed = !$scope.collapsed;
                };

                $scope.removeTag = function (tag) {
                    var idx = $scope.book.tags.indexOf(tag);

                    if (idx > -1)
                        $scope.book.tags.splice(idx, 1);
                };
            }
        };
    });
}());