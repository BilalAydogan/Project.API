function GetDepartment() {
    Get("Department/DepartmentCompany", (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>Department Name</th><th>Company Name</th><th>Edit</th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].name}</td><td>${arr[i].companyName}</td>`;
            html += `<td><i class="bi bi-trash text-danger" onclick='DeleteDepartment(${arr[i].id})'></i><i class="bi bi-pencil-square" onclick='DepartmentModify(${arr[i].id},"${arr[i].name}")'></i></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divDepartments").html(html);
    });
}
function GetCompany() {
    Get("Company/AllCompany", (data) => {
        $("#selectCompanyId").empty();
        var arr = data;
        $.each(arr, function (i, item) {
            $('#selectCompanyId').append($('<option>', {
                value: item.id,
                text: item.name
            }));
        });
    });
}

let selectedDepartmentId = 0;

function NewDepartment() {
    selectedRolId = 0;
    $("#inputDepartmentAd").val("");
    $("#departmentModal").modal("show");
}
function SaveDepartment() {
    var department = {
        Id: selectedDepartmentId,
        Name: $("#inputDepartmentAd").val(),
        CompanyId: $("#selectCompanyId").find(":selected").val()
    };
    Post("Department/Save", department, (data) => {
        GetDepartment();
        $("#departmentModal").modal("hide");
        alert("Successfully");
    });
}


function DeleteDepartment(id) {
    Delete(`Department/Delete?id=${id}`, (data) => {
        GetDepartment();
    });
    alert("Successfully");
}

function DepartmentModify(id, name) {
    selectedDepartmentId = id;
    $("#inputDepartmentAd").val(name);
    $("#departmentModal").modal("show");
}

$(document).ready(function () {
    GetDepartment();
    GetCompany();
});