function Utility() {
    this.ApplicationName = "The Angular Customer project";
    this.ApplicationVersion = "0.1";
    this.getDate = function () {
        var dt = new Date();
        return dt.toDateString();
    }
    this.IsEmpty = function (value) {
        if (value.length == 0) {
            return true;
        }
        else {
            return false;
        }
    }
}