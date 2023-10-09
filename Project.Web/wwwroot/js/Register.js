function Register() {
    var user = {
        Id: 0,
        Name: $("#inputName").val(),
        Surname: $("#inputSurname").val(),
        Email: $("#inputEmail").val(),
        Password: $("#inputPassword").val(),
        RolId: $("#selectRolId").find(":selected").val(),
        SupervisorId: $("#selectUserId").find(":selected").val(),
    };
    Post("User/CreateUser", user, (data) => {
        window.location.href = '/Account/Login/';
        alert("You Can Login with your account.");
    });
    var userdepartment = {
        Id:0,
        UserId:user.Id,
        DepartmentId:$("#selectDepartmentId").find(":selected").val()
    };
    Post("User/CreateUserDepartment", userdepartment, (data) => {
    });
}
function GetRol() {
    Get("Rol/AllRol", (data) => {
        $("#selectRolId").empty();
        var arr = data;
        $.each(arr, function (i, item) {
            $('#selectRolId').append($('<option>', {
                value: item.id,
                text: item.name
            }));
        });
    });
}
function GetUser() {
    Get("User/AllUsers", (data) => {
        $("#selectUserId").empty();
        var arr = data;
        $.each(arr, function (i, item) {
            $('#selectUserId').append($('<option>', {
                value: item.id,
                text: item.name+" "+item.surname
            }));
        });
    });
}
$(document).ready(function () {
    GetRol();
    GetUser();
    Get("Department/AllCompany", (data) => {
        var companies = data;
        var comp = $("#selectCompanyId");
        $.each(companies, function (index, companies) {
            comp.append($("<option>").val(companies.id).text(companies.name));
        });
    });
    $("#selectCompanyId").change(function () {
        var compId = $(this).val();
        var depId = $("#selectDepartmentId");
        depId.empty();
        if (compId !== "") {
            Get(`Department/DepartmentByCompany/${compId}`, (data) => {
                var com = data;
                $.each(com, function (index, dep) {
                    depId.append($("<option>").val(dep.id).text(dep.name));
                });
            });
        }
    });
});