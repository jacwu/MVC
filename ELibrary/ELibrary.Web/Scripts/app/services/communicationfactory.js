﻿(function () {
    "use strict";

    angular.module("elibrary.web").factory("communicationFactory", ["$http", function ($http) {
        return {
            getBooksByTag: function (booksUrl) {
                
                return $http.get(booksUrl)
                        .then(function (r) {
                            return r.data.books;
                        });
            },

            getTagsByBook: function (tagsUrl) {
                return $http.get(tagsUrl)
                    .then(function (r) {
                        return r.data;
                    });
            },

            borrowBook: function (bookBorrowUrl) {
                return $http.post(bookBorrowUrl);
            },

            getOpenOrders: function (openOrdersUrl) {
                return $http.get(openOrdersUrl)
                        .then(function (r) {
                            return r.data;
                        });
            },

            returnBook: function(bookReturnUrl) {
                return $http.put(bookReturnUrl);
            }

        };
    }]);


}());