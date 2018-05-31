assetApp.controller("MedicineInformationControllerEdit", function ($scope, $location, MedicineInformationService,UnitTypeService) {

    $scope.MedicineInformation = {};
    $scope.UnitTypes = {};
    

    var Id = $location.search()["id"];
    MedicineInformationService.getMedicineInformation(Id).then(function (response) {

        $scope.MedicineInformation = response.data;
    }).catch(function () { alert('Error in getting records'); });


   



    UnitTypeService.getAllUnitTypes().then(function (UnitType) {
        $scope.UnitTypes = UnitType.data;
    }).catch(function () {
        alert('Error in getting records');
    });

    $scope.IsMedicineInformationExistsWithID = function () {

        MedicineInformationService.IsMedicineInformationExistsWithID(Id, $scope.MedicineInformation.MedicineName).then(function (response) {

            $scope.IsDuplicate = response.data;
        }).catch(function () { alert('Error in getting records'); });
    }
    // Updateing Records  
    $scope.UpdateMedicineInformation = function (tbl_MedicineInformation) {
       
        var RetValData = MedicineInformationService.UpdateMedicineInformation(tbl_MedicineInformation);
        RetValData.then(function (msg) {
           
                alert('Updated Successfully');


        }).catch(function () {
            alert('Error in getting records');
        });
    }


});