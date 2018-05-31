assetApp.controller("GenderControllerEdit", function ($scope, $location, GenderService) {

    $scope.Gender = {};
    //Get Student INformation By Id

    var Id = $location.search()["id"];
    GenderService.getGender(Id).then(function (response) {

        $scope.Gender = response.data;
    }).catch(function () { alert('Error in getting records'); });


    $scope.IsGenderExists = function () {

        GenderService.IsGenderExists(Id, $scope.Gender.GenderName).then(function (response) {

            $scope.IsDuplicate = response.data;
        }).catch(function () { alert('Error in getting records'); });
    }
    // Updateing Records  
    $scope.UpdateGender = function (tbl_Gender) {
       
        var RetValData = GenderService.UpdateGender(tbl_Gender);
        RetValData.then(function (msg) {
            if (msg == true)
                alert('Updated Successfully');


        }).catch(function () {
            alert('Error in getting records');
        });
    }


});