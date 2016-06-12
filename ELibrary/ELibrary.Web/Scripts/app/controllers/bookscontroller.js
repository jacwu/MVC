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

        $scope.borrowBook = function (book) {
            var bookBorrowUrl;

            for (var i = 0; i < book.links.length; i++) {
                if (book.links[i].rel === "borrowbook") {
                    bookBorrowUrl = book.links[i].href;
                    break;
                }
            }

            if (typeof (bookBorrowUrl) !== "undefined") {
                communicationFactory.borrowBook(bookBorrowUrl).then(function () {
                    $scope.ready = true;
                    $scope.hasError = false;

                    var idx = $scope.books.indexOf(book);

                    if (idx > -1)
                        $scope.books.splice(idx, 1);

                }, function () {
                    $scope.hasError = true;
                    $scope.ready = true;
                    $scope.errorMessage = "Failed to borrow book!";
                }
                );
            }

        };


    }]);


}());