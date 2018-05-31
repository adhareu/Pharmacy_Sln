
assetApp.controller("CustomerInformationControllerList", function ($scope, CustomerInformationService, DTOptionsBuilder) {
    
    $scope.CustomerInformation = {};
    $scope.CustomerInformations = [];
  

   
    
    //To Get All Records  
  
       
    CustomerInformationService.getAllCustomerInformations().then(function (CustomerInformation) {
        $scope.CustomerInformations = CustomerInformation.data;
    }).catch(function () {
        alert('Error in getting records');
    });
    
    
   
    
   
    // Deleting record.  
    $scope.deleteCustomerInformation = function (CustomerInformation, index) {
        var retval = CustomerInformationService.deleteCustomerInformation(CustomerInformation.StudentId).then(function (msg) {
            
        }).catch(function () {
            alert('Oops! something went wrong.');
        });
    }
   

    $scope.dtOptions = DTOptionsBuilder.newOptions()
                .withPaginationType('full_numbers')
                .withDisplayLength(2);
});
