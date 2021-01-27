app.controller('myController', function ($scope, myService, $log) {
    GetStockFC();
    $scope.newStock = {};
    $scope.clickedStock = {};
    $scope.message = "";

    function GetStockFC() {
        $scope.stocks = [];
        myService.getstock().then(function (result) {
            $scope.stocks = result.data;

        }, function (result) {
            alert(result);
        });
    };

    $scope.SaveStock = function (stock) {

        myService.addstock(stock).then(function (result) {
            $scope.newStock = {};

            $scope.message = "Saved Successfully";

        }, function (result) {
            alert("not saved");
        })
    };

    $scope.Selectedstock = function (stock) {
        $scope.clickedStock = stock;
    };

    $scope.UpdateStock = function () {
        myService.updatestock($scope.clickedStock).then(function (result) {
            GetStockFC();
            $scope.message = "Updated Successfully";
        }, function (result) {
            $scope.message = "Updated failed";
        })
    };

    $scope.DeleteStock = function () {

        myService.deletestock($scope.clickedStock.id).then(function (result) {
            GetStockFC();
            $scope.message = "Deleted Successfully";
        }, function (result) {
            $scope.message = "Error Occured";
        })
    };

    $scope.ClearMessage = function () {
        $scope.message = "";
    };
})