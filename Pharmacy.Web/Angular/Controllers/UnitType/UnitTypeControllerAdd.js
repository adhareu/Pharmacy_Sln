assetApp.controller("UnitTypeControllerAdd", function ($scope, UnitTypeService) {
    
   
    
   
    
    $scope.IsUnitTypeExists = function () {
       
        UnitTypeService.IsUnitTypeExists($scope.UnitType.UnitTypeName).then(function (response) {
           
            $scope.IsDuplicate= response.data;
        }).catch(function () { alert('Error in getting records'); });
    }
  
    // Adding New student record  
    $scope.AddUnitType = function (UnitType) {
        UnitTypeService.AddNewUnitType(UnitType).then(function (msg) {
           alert("Successfully Added")
        }).catch( function () {
            alert('Error in adding record');
        });
    }
   
   

    
});