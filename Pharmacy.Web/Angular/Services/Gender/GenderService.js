assetApp.service("GenderService", ['$http', '$rootScope', function ($http, $rootScope) {
   
    this.headers = $rootScope.headersWithLog;
    this.noLogHeaders = $rootScope.headersWithoutLog;
    //get All Gender  
    this.getAllGenders = function () {
        return $http({
            method: 'GET',
            url: api + "Gender/GetAllGender",
          
            headers: this.noLogHeaders
        });
      
    };
    this.getGender = function (Id) {
        return $http({
            method: 'GET',
            url: api + 'Gender/GetGender',
            params: {
                Id: Encrypt.encrypt(Id)
            },
            headers: this.noLogHeaders
        });
    };
    // Adding Record  
    this.AddNewGender = function (tbl_Gender) {
        return $http({
            method: "post",
            url: api + "Gender/AddGender",
            data: JSON.stringify(tbl_Gender),
            headers: this.noLogHeaders,
            dataType: "json"
        });
    }
    // Updating record  
    this.UpdateGender = function (tbl_Gender) {
        return $http({
            method: "PUT",
            url: api + "Gender/UpdateGender",
            data: JSON.stringify(tbl_Gender),
            headers: this.noLogHeaders,
            dataType: "json"
        });
    }
    // Deleting records  
    this.deleteGender = function (Id) {
        return $http({
            method: "PUT",
            url: api + "Gender/DeleteGender",
            params: {
                Id: Encrypt.encrypt(Id)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });
       
    }
    this.IsGenderExists = function (name) {
       
        return $http({
            method: "GET",
            url: api + "Gender/IsGenderExists",
            params: {
                Name: Encrypt.encrypt(name)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });
       
    };
    this.IsGenderExists = function (id,name) {

        return $http({
            method: "GET",
            url: api + "Gender/IsGenderExists",
            params: {
                id: Encrypt.encrypt(id),
                Name: Encrypt.encrypt(name)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });

    };
}]);