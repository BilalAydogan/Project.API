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
            html += `<td><i class="btn btn-danger" onclick='DeleteUser(${arr[i].id})'>Delete</i>
            <i class="btn btn-info" onclick='NewDepartment(${arr[i].id})'>Add Department</i>
            </td>`;
            html += `</tr>`
        }
        html += `</table>`;
        $("#divUsers").html(html);
    });
}
let selectedRolId = 0;
function NewDepartment(id) {
    selectedRolId = 0;
    $("#inputUserId").val(id);
    $("#depModal").modal("show");
}
function AddDepartment() {
    var dep = {
        Id: selectedRolId,
        UserId: $("#inputUserId").val(),
        DepartmentId: $("#selectDepartmentId").find(":selected").val()
    };
    Post("User/CreateUserDepartment", dep, (data) => {
        $("#depModal").modal("hide");
        GetUser();
        alert("Successfully");
    });
}
function DeleteUser(id) {
    Delete(`Department/Delete?id=${id}`, (data) => {
        GetUser();
    });
    alert("Successfully");
}
$(document).ready(function () {
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