function GetDepartment() {
    Get("Department/AllDepartment", (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>Department Name</th><th>Edit</th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].name}</td>`;
            html += `<td><i class="bi bi-trash text-danger" onclick='DeleteDepartment(${arr[i].id})'></i><i class="bi bi-pencil-square" onclick='DepartmentModify(${arr[i].id},"${arr[i].name}")'></i></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divDepartments").html(html);
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
        Name: $("#inputDepartmentAd").val()
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
});