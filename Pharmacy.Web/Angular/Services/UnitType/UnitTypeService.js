assetApp.service("UnitTypeService", ['$http', '$rootScope', function ($http, $rootScope) {
   
    this.headers = $rootScope.headersWithLog;
    this.noLogHeaders = $rootScope.headersWithoutLog;
    //get All UnitType  
    this.getAllUnitTypes = function () {
        return $http({
            method: 'GET',
            url: api + "UnitType/GetAllUnitType",
          
            headers: this.noLogHeaders
        });
      
    };
    this.getUnitType = function (Id) {
        return $http({
            method: 'GET',
            url: api + 'UnitType/GetUnitType',
            params: {
                Id: Encrypt.encrypt(Id)
            },
            headers: this.noLogHeaders
        });
    };
    // Adding Record  
    this.AddNewUnitType = function (tbl_UnitType) {
        return $http({
            method: "post",
            url: api + "UnitType/AddUnitType",
            data: JSON.stringify(tbl_UnitType),
            headers: this.noLogHeaders,
            dataType: "json"
        });
    }
    // Updating record  
    this.UpdateUnitType = function (tbl_UnitType) {
        return $http({
            method: "PUT",
            url: api + "UnitType/UpdateUnitType",
            data: JSON.stringify(tbl_UnitType),
            headers: this.noLogHeaders,
            dataType: "json"
        });
    }
    // Deleting records  
    this.deleteUnitType = function (Id) {
        return $http({
            method: "PUT",
            url: api + "UnitType/DeleteUnitType",
            params: {
                Id: Encrypt.encrypt(Id)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });
       
    }
    this.IsUnitTypeExists = function (name) {
       
        return $http({
            method: "GET",
            url: api + "UnitType/IsUnitTypeExists",
            params: {
                Name: Encrypt.encrypt(name)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });
       
    };
    this.IsUnitTypeExistsWithID = function (id, name) {

        return $http({
            method: "GET",
            url: api + "UnitType/IsUnitTypeExistsWithID",
            params: {
                id: Encrypt.encrypt(id),
                Name: Encrypt.encrypt(name)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });

    };
}]);