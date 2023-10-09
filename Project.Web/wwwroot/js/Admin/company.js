function GetCompany() {
    Get("Company/AllCompany", (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>Company Name</th><th>Edit</th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].name}</td>`;
            html += `<td><i class="bi bi-trash text-danger" onclick='DeleteCompany(${arr[i].id})'></i><i class="bi bi-pencil-square" onclick='CompanyModify(${arr[i].id},"${arr[i].name}")'></i></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divCompany").html(html);
    });
}

let selectedCompanyId = 0;

function NewCompany() {
    selectedRolId = 0;
    $("#inputCompanyAd").val("");
    $("#companyModal").modal("show");
}
function SaveCompany() {
    var company = {
        Id: selectedCompanyId,
        Name: $("#inputCompanyAd").val()
    };
    Post("Company/Save", company, (data) => {
        GetCompany();
        $("#companyModal").modal("hide");
        alert("Successfully");
        location.reload();
    });
}


function DeleteCompany(id) {
    Delete(`Company/Delete?id=${id}`, (data) => {
        GetCompany();
    });
    alert("Successfully");
}

function CompanyModify(id, name) {
    selectedCompanyId = id;
    $("#inputCompanyAd").val(name);
    $("#companyModal").modal("show");
}

$(document).ready(function () {
    GetCompany();
});