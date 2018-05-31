assetApp.controller("GenderControllerAdd", function ($scope, GenderService) {
    
   
    
   
    
    $scope.IsGenderExists = function () {
       
        GenderService.IsGenderExists($scope.Gender.GenderName).then(function (response) {
           
            $scope.IsDuplicate= response.data;
        }).catch(function () { alert('Error in getting records'); });
    }
  
    // Adding New student record  
    $scope.AddGender = function (Gender) {
        GenderService.AddNewGender(Gender).then(function (msg) {
           
        }).catch( function () {
            alert('Error in adding record');
        });
    }
   
   

    
});