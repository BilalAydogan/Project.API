function GetUser() {
    Get("User/AllUs", (data) => {
        var html = `<table class="table table-hover table-responsive">` +
            `<tr>
            <th>Name</th>
            <th>Surname</th>
            <th>Email</th>
            <th>Company</th>
            <th>Department</th>
            <th>Rol</th>
            <th>Edit</th>
            </tr>`;
        var arr = data;
        console.log(data);

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `
            <td>${arr[i].name}</td>
            <td>${arr[i].surname}</td>
            <td>${arr[i].email}</td>
            <td>${arr[i].compName}</td>
            <td>${arr[i].depName}</td>
            <td>${arr[i].rolName}</td>
            `;
            html += `<td>
            <div class="dropdown">
              <button class="btn btn-info dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                Operations
              </button>
              <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                <i class=" dropdown-item btn btn-success" onclick='NewDepartment(${arr[i].userId})'>Add Department</i>
                            <i class="btn btn-danger dropdown-item" onclick='DeleteUserDepartment(${arr[i].userDepId})'>Remove Department</i>
                            <li><hr class="dropdown-divider"></li>
                            <i class="btn btn-info dropdown-item" onclick='NewRol(${arr[i].userId})'>Add Role</i>
                            <i class="btn btn-danger dropdown-item" onclick='DeleteRol(${arr[i].userId})'>Delete Role</i>
              </ul>
            </div>
            
            </td>`;
            html += `</tr>`
        }
        html += `</table>`;
        $("#divUsers").html(html);
    });
}
let selectedDepId = 0;
function NewDepartment(userId) {
    selectedDepId = 0;
    $("#inputUserId").val(userId);
    $("#depModal").modal("show");
}
function AddDepartment() {
    var dep = {
        Id: selectedDepId,
        UserId: $("#inputUserId").val(),
        DepartmentId: $("#selectDepartmentId").find(":selected").val()
    };
    Post("User/CreateUserDepartment", dep, (data) => {
        $("#depModal").modal("hide");
        GetUser();
        alert("Successfully");
    });
}
let selectedRolId = 0;
function NewRol(userId) {
    selectedRolId = 0;
    $("#inputUserRolId").val(userId);
    $("#rolModal").modal("show");
}
function AddRol() {
    var dep = {
        Id: selectedRolId,
        UserId: $("#inputUserRolId").val(),
        RolId: $("#selectRolId").find(":selected").val()
    };
    Post("User/CreateUserRol", dep, (data) => {
        $("#rolModal").modal("hide");
        GetUser();
        alert("Successfully");
    });
}
function DeleteUserRol(userRolId) {
    Delete(`User/DeleteUserRol?id=${userRolId}`, (data) => {
        GetUser();
    });
    alert("Successfully");
}
function DeleteUserDepartment(userDepId) {
    Delete(`User/DeleteUserDepartment?id=${userDepId}`, (data) => {
        GetUser();
    });
    alert("Successfully");
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
$(document).ready(function () {
    GetUser();
    GetRol();
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