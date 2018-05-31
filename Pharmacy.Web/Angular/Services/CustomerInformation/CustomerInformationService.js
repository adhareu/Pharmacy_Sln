assetApp.service("CustomerInformationService", ['$http', '$rootScope', function ($http, $rootScope) {
   
    this.headers = $rootScope.headersWithLog;
    this.noLogHeaders = $rootScope.headersWithoutLog;
    //get All CustomerInformation  
    this.getAllCustomerInformations = function () {
        return $http({
            method: 'GET',
            url: api + "CustomerInformation/GetAllCustomerInformation",
          
            headers: this.noLogHeaders
        });
      
    };
    this.getCustomerInformation = function (Id) {
        return $http({
            method: 'GET',
            url: api + 'CustomerInformation/GetCustomerInformation',
            params: {
                Id: Encrypt.encrypt(Id)
            },
            headers: this.noLogHeaders
        });
    };
    // Adding Record  
    this.AddNewCustomerInformation = function (tbl_CustomerInformation) {
        return $http({
            method: "post",
            url: api + "CustomerInformation/AddCustomerInformation",
            data: JSON.stringify(tbl_CustomerInformation),
            headers: this.noLogHeaders,
            dataType: "json"
        });
    }
    // Updating record  
    this.UpdateCustomerInformation = function (tbl_CustomerInformation) {
        return $http({
            method: "PUT",
            url: api + "CustomerInformation/UpdateCustomerInformation",
            data: JSON.stringify(tbl_CustomerInformation),
            headers: this.noLogHeaders,
            dataType: "json"
        });
    }
    // Deleting records  
    this.deleteCustomerInformation = function (Id) {
        return $http({
            method: "PUT",
            url: api + "CustomerInformation/DeleteCustomerInformation",
            params: {
                Id: Encrypt.encrypt(Id)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });
       
    }
    this.IsCustomerInformationExists = function (name) {
       
        return $http({
            method: "GET",
            url: api + "CustomerInformation/IsCustomerInformationExists",
            params: {
                Name: Encrypt.encrypt(name)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });
       
    };
    this.IsCustomerInformationExistsWithID = function (id, name) {

        return $http({
            method: "GET",
            url: api + "CustomerInformation/IsCustomerInformationExistsWithID",
            params: {
                id: Encrypt.encrypt(id),
                Name: Encrypt.encrypt(name)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });

    };
}]);