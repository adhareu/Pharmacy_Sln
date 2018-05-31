assetApp.controller("CustomerInformationControllerEdit", function ($scope, $location, CustomerInformationService,GenderService) {

    $scope.CustomerInformation = {};
    $scope.Genders = {};

   
    

    var Id = $location.search()["id"];
    CustomerInformationService.getCustomerInformation(Id).then(function (response) {

        $scope.CustomerInformation = response.data;
    }).catch(function () { alert('Error in getting records'); });


   



    GenderService.getAllGenders().then(function (Gender) {
        $scope.Genders = Gender.data;
    }).catch(function () {
        alert('Error in getting records');
    });

    $scope.IsCustomerInformationExistsWithID = function () {

        CustomerInformationService.IsCustomerInformationExistsWithID(Id, $scope.CustomerInformation.CustomerName).then(function (response) {

            $scope.IsDuplicate = response.data;
        }).catch(function () { alert('Error in getting records'); });
    }
    // Updateing Records  
    $scope.UpdateCustomerInformation = function (tbl_CustomerInformation) {
        if (tbl_CustomerInformation.Photo == null)
        {
            var studentPic = getBase64Image();
            tbl_CustomerInformation.Photo = studentPic;
        }
       
        var RetValData = CustomerInformationService.UpdateCustomerInformation(tbl_CustomerInformation);
        RetValData.then(function (msg) {
            if (msg == true)
                alert('Updated Successfully');


        }).catch(function () {
            alert('Error in getting records');
        });
    }


});