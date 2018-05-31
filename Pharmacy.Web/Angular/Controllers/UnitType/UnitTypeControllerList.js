
assetApp.controller("UnitTypeControllerList", function ($scope, UnitTypeService, DTOptionsBuilder) {
    
    $scope.UnitType = {};
    $scope.UnitTypes = [];
  

   
    
    //To Get All Records  
  
       
    UnitTypeService.getAllUnitTypes().then(function (UnitType) {
        $scope.UnitTypes = UnitType.data;
    }).catch(function () {
        alert('Error in getting records');
    });
    
    
   
    
   
    // Deleting record.  
    $scope.deleteUnitType = function (UnitType, index) {
        var retval = UnitTypeService.deleteUnitType(UnitType.StudentId).then(function (msg) {
            
        }).catch(function () {
            alert('Oops! something went wrong.');
        });
    }
   

    $scope.dtOptions = DTOptionsBuilder.newOptions()
                .withPaginationType('full_numbers')
                .withDisplayLength(2);
});
