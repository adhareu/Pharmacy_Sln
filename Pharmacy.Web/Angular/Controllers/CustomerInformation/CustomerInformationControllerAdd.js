assetApp.controller("CustomerInformationControllerAdd", function ($scope, CustomerInformationService,GenderService) {
    
    $scope.Genders = {};
   
    GenderService.getAllGenders().then(function (Gender) {
        $scope.Genders = Gender.data;
    }).catch(function () {
        alert('Error in getting records');
    });
    
    $scope.IsCustomerInformationExists = function () {
       
        CustomerInformationService.IsCustomerInformationExists($scope.CustomerInformation.CustomerName).then(function (response) {
           
            $scope.IsDuplicate= response.data;
        }).catch(function () { alert('Error in getting records'); });
    }
  
    // Adding New student record  
    $scope.AddCustomerInformation = function (CustomerInformation) {
        var studentPic = getBase64Image();
        CustomerInformation.Photo = studentPic;
        CustomerInformationService.AddNewCustomerInformation(CustomerInformation).then(function (msg) {
           
        }).catch( function () {
            alert('Error in adding record');
        });
    }
   
   

    
});