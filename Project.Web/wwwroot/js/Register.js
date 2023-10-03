
function GetRol() {
    
    Get("Rol/AllRol", (data) => {
        $('#selectRolId').empty();
        var arr = data;
        $.each(arr, function (i, item) {
            $('#selectRolId').append($('<option>', {
                value: item.id,
                text: item.name,
                data_tokens: item.ad

            }));
        });
    });
}
function GetDepartment() {
    Get("Deparment/AllDepartment", (data) => {
        $('#selectDepartmentId').empty();
        var arr = data;
        $.each(arr, function (i, item) {
            $('#selectDepartmentId').append($('<option>', {
                value: item.id,
                text: item.name,
                data_tokens: item.ad

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
        Photo: null,
        RolId: $("#selectRolId").find(":selected").val(),
        DepartmentId: $("#selectDepartmentlId").find(":selected").val(),
        
    };
    Post("User/CreateUser", user, (data) => {
    });
}
$(document).ready(function () {
    GetRol();
    GetDepartment();
});