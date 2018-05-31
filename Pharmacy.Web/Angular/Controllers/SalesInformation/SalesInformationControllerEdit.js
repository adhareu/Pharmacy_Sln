assetApp.controller("SalesInformationControllerEdit", function ($scope, $location, SalesInformationService, MedicineInformationService, CustomerInformationService) {

    $scope.SalesInformation = {};
    $scope.MedicineInformations = {};
    $scope.CustomerInformations = {};
    //Get Student INformation By Id

    var Id = $location.search()["id"];
    SalesInformationService.getSalesInformation(Id).then(function (response) {

        $scope.SalesInformation = response.data;
    }).catch(function () { alert('Error in getting records'); });


    $scope.IsSalesInformationExists = function () {

        SalesInformationService.IsSalesInformationExistsWithID(Id, $scope.SalesInformation.SalesInformationName).then(function (response) {

            $scope.IsDuplicate = response.data;
        }).catch(function () { alert('Error in getting records'); });
    }

    MedicineInformationService.getAllMedicineInformations().then(function (MedicineInformation) {
        $scope.MedicineInformations = MedicineInformation.data;
    }).catch(function () {
        alert('Error in getting records');
    });

    CustomerInformationService.getAllCustomerInformations().then(function (CustomerInformation) {
        $scope.CustomerInformations = CustomerInformation.data;
    }).catch(function () {
        alert('Error in getting records');
    });
    // Updateing Records  
    $scope.UpdateSalesInformation = function (tbl_SalesInformation) {
      
        var RetValData = SalesInformationService.UpdateSalesInformation(tbl_SalesInformation);
        RetValData.then(function (msg) {
           
                alert('Updated Successfully');


        }).catch(function () {
            alert('Error in getting records');
        });
    }


});