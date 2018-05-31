assetApp.service("MedicineInformationService", ['$http', '$rootScope', function ($http, $rootScope) {
   
    this.headers = $rootScope.headersWithLog;
    this.noLogHeaders = $rootScope.headersWithoutLog;
    //get All MedicineInformation  
    this.getAllMedicineInformations = function () {
        return $http({
            method: 'GET',
            url: api + "MedicineInformation/GetAllMedicineInformation",
          
            headers: this.noLogHeaders
        });
      
    };
    this.getMedicineInformation = function (Id) {
        return $http({
            method: 'GET',
            url: api + 'MedicineInformation/GetMedicineInformation',
            params: {
                Id: Encrypt.encrypt(Id)
            },
            headers: this.noLogHeaders
        });
    };
    // Adding Record  
    this.AddNewMedicineInformation = function (tbl_MedicineInformation) {
        return $http({
            method: "post",
            url: api + "MedicineInformation/AddMedicineInformation",
            data: JSON.stringify(tbl_MedicineInformation),
            headers: this.noLogHeaders,
            dataType: "json"
        });
    }
    // Updating record  
    this.UpdateMedicineInformation = function (tbl_MedicineInformation) {
        return $http({
            method: "PUT",
            url: api + "MedicineInformation/UpdateMedicineInformation",
            data: JSON.stringify(tbl_MedicineInformation),
            headers: this.noLogHeaders,
            dataType: "json"
        });
    }
    // Deleting records  
    this.deleteMedicineInformation = function (Id) {
        return $http({
            method: "PUT",
            url: api + "MedicineInformation/DeleteMedicineInformation",
            params: {
                Id: Encrypt.encrypt(Id)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });
       
    }
    this.IsMedicineInformationExists = function (name) {
       
        return $http({
            method: "GET",
            url: api + "MedicineInformation/IsMedicineInformationExists",
            params: {
                Name: Encrypt.encrypt(name)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });
       
    };
    this.IsMedicineInformationExistsWithID = function (id, name) {

        return $http({
            method: "GET",
            url: api + "MedicineInformation/IsMedicineInformationExistsWithID",
            params: {
                id: Encrypt.encrypt(id),
                Name: Encrypt.encrypt(name)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });

    };
}]);