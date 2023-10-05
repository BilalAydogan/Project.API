function GetHolding() {
    Get("Holding/AllHolding", (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>Holding Name</th><th>Edit</th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].name}</td>`;
            html += `<td><i class="bi bi-trash text-danger" onclick='DeleteHolding(${arr[i].id})'></i><i class="bi bi-pencil-square" onclick='HoldingModify(${arr[i].id},"${arr[i].name}")'></i></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divHolding").html(html);
    });
}

let selectedHoldingId = 0;

function NewHolding() {
    selectedRolId = 0;
    $("#inputHoldingAd").val("");
    $("#holdingModal").modal("show");
}
function SaveHolding() {
    var holding = {
        Id: selectedHoldingId,
        Name: $("#inputHoldingAd").val()
    };
    Post("Holding/Save", holding, (data) => {
        GetHolding();
        $("#holdingModal").modal("hide");
        alert("Successfully");
        $("#inputHoldingAd").val("");
    });
}


function DeleteHolding(id) {
    Delete(`Holding/Delete?id=${id}`, (data) => {
        GetHolding();
    });
    alert("Successfully");
}

function HoldingModify(id, name) {
    selectedHoldingId = id;
    $("#inputHoldingAd").val(name);
    $("#holdingModal").modal("show");
}

$(document).ready(function () {
    GetHolding();
});