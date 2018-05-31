var api = "http://localhost:7764/api/";

var assetApp = angular.module("assetApp", ['ngMessages', 'datatables']);


assetApp.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
}]);

var p;
var canvas = document.createElement("canvas");
var img1 = document.createElement("img");

function getBase64Image() {
   
    var imageData;
    var fileByteArray = [];
    //p = document.getElementById("file").value;
   debugger
    var fileList = document.getElementById("file").files;
    var fileReader = new FileReader();
    if (fileReader && fileList && fileList.length) {
        fileReader.readAsArrayBuffer(fileList[0]);
       
             imageData = fileReader.result;
             array = new Uint8Array(imageData);
             for (var i = 0; i < array.length; i++) {
                 fileByteArray.push(array[i]);
             }
    }
   
    return fileByteArray;
    //img1.setAttribute('src', p);
    //canvas.width = img1.width;
    //canvas.height = img1.height;
    //var ctx = canvas.getContext("2d");
    //ctx.drawImage(img1, 0, 0);
    //var dataURL = canvas.toDataURL("image/png");
    
    //return dataURL;
}


function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [year, month, day].join('');
}

function getClientSideDateTime() {
    debugger
    //Get the current date
    var localTime = new Date();

    //Access each of the components for formatting purposes
    var year = localTime.getFullYear();
    var month = localTime.getMonth() + 1;
    var date = localTime.getDate();
    var hours = localTime.getHours();
    var minutes = localTime.getMinutes();
    var seconds = localTime.getSeconds();

    //Set your hidden element to your preferred value (d/M/yyyy hh:mm:ss)
    var formatted = year + "-" + month + "-" + date + " " + hours + ":" + minutes + ":" + seconds;
    return formatted;
}

function pad(number, length) {

    var str = '' + number;
    while (str.length < length) {
        str = '0' + str;
    }

    return str;

}
