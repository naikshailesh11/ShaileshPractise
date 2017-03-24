function Customer(utility) {
    this.CustomerName = "Shiv";
    this.CustomerCode = "1001";
    this.CustomerAmount = 100;
    this.SalesDateTime = utility.getDate();
    this.CalculateDiscount = function () {
        alert("10");
    }
}
function CustomerGold(utility) {
    var dt = new Date();
    this.CustomerName = "Shiv";
    this.CustomerCode = "1001";
    this.CustomerAmount = 100;
    this.SalesDateTime = utility.getDate();
    this.CalculateDiscount = function () {
        alert("20");
    }
}
function Factory() {

    return {
        CreateCustomer: function (type, utility) {
            if (type == 1) {
                return new Customer(utility);
            }
            else {
                return new CustomerGold(utility);
            }
        }
    }
}