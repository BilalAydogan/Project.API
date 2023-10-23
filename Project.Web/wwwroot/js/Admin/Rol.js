var limit = 10;
function GetRol(limit) {
    Get("Rol/AllRol/"+limit, (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>Role Name</th><th>Edit</th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].name}</td>`;
            html += `<td><i class="bi bi-trash text-danger" onclick='DeleteRol(${arr[i].id})'></i><i class="bi bi-pencil-square" onclick='RolModify(${arr[i].id},"${arr[i].name}")'></i></td>`;
            html += `</tr>`
        }
        html += `</table>`;
        $("#divRoller").html(html);
        if (arr.length == limit) {
            var a = `<button class="btn btn-info" onclick='LimitArtir(${limit})'>Limit Artır</button>`;
        } else {
            a = `<div style="color:black;
                            position:absolute;
                            width:200px;
                            bottom:0px;
                            right:25%;
                            left:50%;
                            margin-left:-150px;">No More Result...</div>`;
            
        }
        $("#demo").html(a);
    });
}


let selectedRolId = 0;

function NewRol() {
    selectedRolId = 0;
    $("#inputRolAd").val("");
    $("#rolModal").modal("show");
}
function SaveRol() {
    var rol = {
        Id: selectedRolId,
        Name: $("#inputRolAd").val()
    };
    Post("Rol/Save", rol, (data) => {
        GetRol();
        $("#rolModal").modal("hide");
        alert("Successfully");
    });
}


function DeleteRol(id) {
    Delete(`Rol/Delete?id=${id}`, (data) => {
        GetRol();
    });
    alert("Successfully");
}

function RolModify(id, name) {
    selectedRolId = id;
    $("#inputRolAd").val(name);
    $("#rolModal").modal("show");
}
function LimitArtir(limit) {
    limit += 10;
    GetRol(limit);
}
$(document).ready(function () {
    GetRol(limit);
});