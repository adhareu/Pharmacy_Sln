assetApp.controller("SalesInformationControllerAdd", function ($scope, SalesInformationService,MedicineInformationService,CustomerInformationService) {
    
    $scope.InvoiceNo = ""
    $scope.SalesInformationLastData = {}
    $scope.MedicineInformations = {};
    $scope.CustomerInformations = {};
    $scope.items = []
    $scope.tax = 0;
    $scope.discount = 0;
    $scope.SalesInformation = { SalesID: 0, SalesName: "", InvoiceNo: "", CustomerID: 0, TotalPriceExcludingAll: 0, DiscountAmount: 0, DiscountRate: 0, TaxPercentage: 0, TotalTax: 0, TotalPriceIncludingAll: 0, SubTotal: 0, Status: 0, CreatedOn: null, CreatedBy:1 }
    $scope.getMedicineInformationById = function (item) {
        MedicineInformationService.getMedicineInformation(item.MedicineID).then(function (response) {
           
            var idx = $scope.items.indexOf(item)
           
            $scope.items[idx].cost = response.data.Price;
    }).catch(function () { alert('Error in getting records'); });
    }

    $scope.CalculateTotalCost = function (item) {
       

            var idx = $scope.items.indexOf(item)

            $scope.items[idx].TotalCost =  $scope.items[idx].TotalUnit* $scope.items[idx].cost;
       
    }
    $scope.getInvoiceNo = function () {
     
        SalesInformationService.GetSalesInformationLastData().then(function (response) {
           
            $scope.SalesInformationLastData = response.data;
          
           var todaysDate = new Date();
           var formatedDate = formatDate(todaysDate);
            var format = "INV-" + formatDate(todaysDate);
            if ($scope.SalesInformationLastData == null)
            {
                $scope.SalesInformation.InvoiceNo = format + "-00001";
            }
            else
            {
                debugger
                var inv = $scope.SalesInformationLastData.InvoiceNo;
                var counter = inv.substring(format.length + 1, inv.length);
                var dateformate = inv.substring(4, inv.length-6);
                if (formatedDate == dateformate)
                {
                    var count = parseInt(counter) + 1;
                    $scope.SalesInformation.InvoiceNo = format + '-' + pad(count, 5);
                }
                else
                {
                    $scope.SalesInformation.InvoiceNo = format + "-00001";
                }
              
            }

        }).catch(function () { alert('Error in getting records'); });
    }
    $scope.getInvoiceNo();

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
    $scope.IsSalesInformationExists = function () {
       
        SalesInformationService.IsSalesInformationExists($scope.SalesInformation.SalesName).then(function (response) {
           
            $scope.IsDuplicate= response.data;
        }).catch(function () { alert('Error in getting records'); });
    }
  
    // Adding New student record  
    $scope.AddSalesInformation = function (SalesInformation, items) {
        debugger
        SalesInformation.CreatedOn = getClientSideDateTime();
        SalesInformation.CreatedBy = 1;
        SalesInformation.SalesInformationDetails = items
        SalesInformationService.AddNewSalesInformation(SalesInformation).then(function (msg) {
            alert("Successfully Added")
            $scope.getInvoiceNo();
            $scope.items = []
        }).catch( function () {
            alert('Error in adding record');
        });
    }
   
    // Adds an item to the invoice's items
    $scope.addItem = function () {
        $scope.items.push({ TotalUnit: 0, cost: 0, MedicineID: 0, TotalCost:0,Status:1 });
    };
    // Remotes an item from the invoice
    $scope.removeItem = function (item) {
        $scope.items.splice($scope.items.indexOf(item), 1);
    };

    // Calculates the sub total of the invoice
    $scope.invoiceSubTotal = function () {
        var total = 0.00;
        angular.forEach($scope.items, function (item, key) {
            total += (item.TotalUnit * item.cost);
        });
        $scope.SalesInformation.SubTotal = total;
        $scope.SalesInformation.TotalPriceExcludingAll = total;
        return total;
    };

    // Calculates the tax of the invoice
    $scope.calculateTax = function () {
        $scope.SalesInformation.TotalTax = (($scope.SalesInformation.TaxPercentage * $scope.invoiceSubTotal()) / 100);
        return (($scope.SalesInformation.TaxPercentage * $scope.invoiceSubTotal()) / 100);
    };
    // Calculates the tax of the invoice
    $scope.calculateDiscount = function () {
        $scope.SalesInformation.DiscountAmount = (($scope.SalesInformation.DiscountRate * $scope.invoiceSubTotal()) / 100);
        return (($scope.SalesInformation.DiscountRate * $scope.invoiceSubTotal()) / 100);
    };
    // Calculates the grand total of the invoice
    $scope.calculateGrandTotal = function () {
        $scope.SalesInformation.TotalPriceIncludingAll = $scope.calculateTax() + $scope.invoiceSubTotal() - $scope.calculateDiscount()
        return $scope.calculateTax() + $scope.invoiceSubTotal() - $scope.calculateDiscount();
    };

    
});