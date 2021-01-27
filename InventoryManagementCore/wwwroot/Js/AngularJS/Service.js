app.service("myService", function ($http, $log) {

    this.getstock = function () {
        var response = $http.get('Stock/GetAllStock');
        return response;
    };

    this.updatestock = function (stock) {
        // $log.info(product)
        var response = $http({
            method: 'post',
            url: 'Stock/UpdateStock/',
            data: JSON.stringify(stock)

        });
        return response;
    };
    this.addstock = function (stock) {

        var response = $http({
            method: 'post',
            url: 'Stock/AddStock',
            data: stock

        }).success(function (response) {
            alert(response);
        })
            .error(function (error) {
                alert(error);
            });;
        return response;
    };
    this.deletestock = function (id) {
        var response = $http({
            method: 'post',
            url: 'Stock/DeleteStock',
            params: { Id: JSON.stringify(id) }
        });
        return response;
    };

});