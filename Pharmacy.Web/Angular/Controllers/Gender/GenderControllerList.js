
assetApp.controller("GenderControllerList", function ($scope, GenderService, DTOptionsBuilder) {
    
    $scope.Gender = {};
    $scope.Genders = [];
  

   
    
    //To Get All Records  
  
       
    GenderService.getAllGenders().then(function (Gender) {
        $scope.Genders = Gender.data;
    }).catch(function () {
        alert('Error in getting records');
    });
    
    
   
    
   
    // Deleting record.  
    $scope.deleteGender = function (Gender, index) {
        var retval = GenderService.deleteGender(Gender.StudentId).then(function (msg) {
            
        }).catch(function () {
            alert('Oops! something went wrong.');
        });
    }
   

    $scope.dtOptions = DTOptionsBuilder.newOptions()
                .withPaginationType('full_numbers')
                .withDisplayLength(2);
});
