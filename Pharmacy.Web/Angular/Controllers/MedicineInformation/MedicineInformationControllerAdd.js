assetApp.controller("MedicineInformationControllerAdd", function ($scope, MedicineInformationService,UnitTypeService) {
    
   
    $scope.UnitTypes = {};



    UnitTypeService.getAllUnitTypes().then(function (UnitType) {
        $scope.UnitTypes = UnitType.data;
    }).catch(function () {
        alert('Error in getting records');
    });
   
    
    $scope.IsMedicineInformationExists = function () {
       
        MedicineInformationService.IsMedicineInformationExists($scope.MedicineInformation.MedicineName).then(function (response) {
           
            $scope.IsDuplicate= response.data;
        }).catch(function () { alert('Error in getting records'); });
    }
  
    // Adding New student record  
    $scope.AddMedicineInformation = function (MedicineInformation) {
        MedicineInformationService.AddNewMedicineInformation(MedicineInformation).then(function (msg) {
            alert("Successfully Added")
        }).catch( function () {
            alert('Error in adding record');
        });
    }
   
   

    
});