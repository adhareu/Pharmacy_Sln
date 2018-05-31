assetApp.controller("UnitTypeControllerEdit", function ($scope, $location, UnitTypeService) {

    $scope.UnitType = {};
    //Get Student INformation By Id

    var Id = $location.search()["id"];
    UnitTypeService.getUnitType(Id).then(function (response) {

        $scope.UnitType = response.data;
    }).catch(function () { alert('Error in getting records'); });


    $scope.IsUnitTypeExistsWithID = function () {

        UnitTypeService.IsUnitTypeExistsWithID(Id, $scope.UnitType.UnitTypeName).then(function (response) {

            $scope.IsDuplicate = response.data;
        }).catch(function () { alert('Error in getting records'); });
    }
    // Updateing Records  
    $scope.UpdateUnitType = function (tbl_UnitType) {
       
        var RetValData = UnitTypeService.UpdateUnitType(tbl_UnitType);
        RetValData.then(function (msg) {
         
                alert('Updated Successfully');


        }).catch(function () {
            alert('Error in getting records');
        });
    }


});