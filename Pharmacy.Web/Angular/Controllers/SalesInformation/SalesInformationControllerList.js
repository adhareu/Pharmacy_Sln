
assetApp.controller("SalesInformationControllerList", function ($scope, SalesInformationService, DTOptionsBuilder) {
    
    $scope.SalesInformation = {};
    $scope.SalesInformations = [];
  

   
    
    //To Get All Records  
  
       
    SalesInformationService.getAllSalesInformations().then(function (SalesInformation) {
        $scope.SalesInformations = SalesInformation.data;
    }).catch(function () {
        alert('Error in getting records');
    });
    
    
   
    
   
    // Deleting record.  
    $scope.deleteSalesInformation = function (SalesInformation, index) {
        var retval = SalesInformationService.deleteSalesInformation(SalesInformation.StudentId).then(function (msg) {
            
        }).catch(function () {
            alert('Oops! something went wrong.');
        });
    }
   

    $scope.dtOptions = DTOptionsBuilder.newOptions()
                .withPaginationType('full_numbers')
                .withDisplayLength(2);

    
});
