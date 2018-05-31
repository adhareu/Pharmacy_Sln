
assetApp.controller("MedicineInformationControllerList", function ($scope, MedicineInformationService, DTOptionsBuilder) {
    
    $scope.MedicineInformation = {};
    $scope.MedicineInformations = [];
  

   
    
    //To Get All Records  
  
       
    MedicineInformationService.getAllMedicineInformations().then(function (MedicineInformation) {
      

        $scope.MedicineInformations = MedicineInformation.data;
    }).catch(function () {
        alert('Error in getting records');
    });
    
    
   
    
   
    // Deleting record.  
    $scope.deleteMedicineInformation = function (MedicineInformation, index) {
        var retval = MedicineInformationService.deleteMedicineInformation(MedicineInformation.StudentId).then(function (msg) {
            
        }).catch(function () {
            alert('Oops! something went wrong.');
        });
    }
   

    $scope.dtOptions = DTOptionsBuilder.newOptions()
                .withPaginationType('full_numbers')
                .withDisplayLength(2);
});
