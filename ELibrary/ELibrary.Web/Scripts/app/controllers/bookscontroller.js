(function () {
    "use strict";

    angular.module("elibrary.web").controller("BooksController", ["$scope", "tagValue", "communicationFactory", function ($scope, tagValue, communicationFactory) {

        $scope.ready = false;
        $scope.hasError = false;

        var booksUrl;
        $scope.tag = tagValue;

        for (var i = 0; i < tagValue.links.length; i++) {
            if (tagValue.links[i].rel === "self") {
                booksUrl = tagValue.links[i].href;
                break;
            }
        }

        if (typeof (booksUrl) !== "undefined") {
            communicationFactory.getBooksByTag(booksUrl).then(function (books) {
                $scope.books = books;
                $scope.ready = true;
                $scope.hasError = false;

            }, function () {
                $scope.hasError = true;
                $scope.ready = true;
                $scope.errorMessage = "Failed to retrieve books list!";
            }
            );
        }
        else {
            $scope.hasError = true;
            $scope.ready = true;
            $scope.errorMessage = "Failed to get books URL to API!";

        }


    }]);


}());