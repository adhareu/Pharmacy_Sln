assetApp.service("SalesInformationService", ['$http', '$rootScope', function ($http, $rootScope) {
   
    this.headers = $rootScope.headersWithLog;
    this.noLogHeaders = $rootScope.headersWithoutLog;
    //get All SalesInformation  
    this.getAllSalesInformations = function () {
        return $http({
            method: 'GET',
            url: api + "SalesInformation/GetAllSalesInformation",
          
            headers: this.noLogHeaders
        });
      
    };
    this.GetSalesInformationLastData = function () {
        return $http({
            method: 'GET',
            url: api + "SalesInformation/GetSalesInformationLastData",

            headers: this.noLogHeaders
        });

    };
    this.getSalesInformation = function (Id) {
        return $http({
            method: 'GET',
            url: api + 'SalesInformation/GetSalesInformation',
            params: {
                Id: Encrypt.encrypt(Id)
            },
            headers: this.noLogHeaders
        });
    };
    // Adding Record  
    this.AddNewSalesInformation = function (tbl_SalesInformation) {
        return $http({
            method: "post",
            url: api + "SalesInformation/AddSalesInformation",
            data: JSON.stringify(tbl_SalesInformation),
            headers: this.noLogHeaders,
            dataType: "json"
        });
    }
    // Updating record  
    this.UpdateSalesInformation = function (tbl_SalesInformation) {
        return $http({
            method: "PUT",
            url: api + "SalesInformation/UpdateSalesInformation",
            data: JSON.stringify(tbl_SalesInformation),
            headers: this.noLogHeaders,
            dataType: "json"
        });
    }
    // Deleting records  
    this.deleteSalesInformation = function (Id) {
        return $http({
            method: "PUT",
            url: api + "SalesInformation/DeleteSalesInformation",
            params: {
                Id: Encrypt.encrypt(Id)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });
       
    }
    this.IsSalesInformationExists = function (name) {
       
        return $http({
            method: "GET",
            url: api + "SalesInformation/IsSalesInformationExists",
            params: {
                Name: Encrypt.encrypt(name)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });
       
    };
    this.IsSalesInformationExistsWithID = function (id,name) {

        return $http({
            method: "GET",
            url: api + "SalesInformation/IsSalesInformationExists",
            params: {
                id: Encrypt.encrypt(id),
                Name: Encrypt.encrypt(name)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });

    };
}]);