
function GetRol() {
    
    Get("Rol/AllRol", (data) => {
        $('#selectRolId').empty();
        var arr = data;
        $.each(arr, function (i, item) {
            $('#selectRolId').append($('<option>', {
                value: item.id,
                text: item.name
            }));
        });
    });
}
//function GetUsers() {

//    Get("User/AllUsers", (data) => {
//        var arr = data;
//        var mail;
//        $.each(arr, function (i, item) {
//            mail = item.email;
//        });
//    });
//}
function GetDepartment() {
    Get("Department/AllDepartment", (data) => {
        $('#selectDepartmentId').empty();
        var arr = data;
        $.each(arr, function (i, item) {
            $('#selectDepartmentId').append($('<option>', {
                value: item.id,
                text: item.name
            }));
        });
    });
}
function GetHolding() {
    Get("Holding/AllHolding", (data) => {
        $("#selectHoldingId").empty();
        var arr = data;
        $.each(arr, function (i, item) {
            $('#selectHoldingId').append($('<option>', {
                value: item.id,
                text: item.name
            }));
        });
    });
}
function Register() {
    var user = {
        Id: 0,
        Name: $("#inputName").val(),
        Surname: $("#inputSurname").val(),
        Email: $("#inputEmail").val(),
        Password: $("#inputPassword").val(),
        RolId: $("#selectRolId").find(":selected").val(),
        DepartmentId: $("#selectDepartmentId").find(":selected").val(),
        HoldingId: $("#selectHoldingId").find(":selected").val()
    };
    Post("User/CreateUser", user, (data) => {
        console.log(user);
        window.location.href = '/Account/Login/';
        alert("You Can Login with your account.");
    });
}
$(document).ready(function () {
    GetRol();
    GetDepartment();
    GetHolding();
});