function GetRequest() {
    var req = $("#inputUserId").val();
    Get("Request/RequestById/" + req, (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>Request Name</th><th>Description</th><th>Amount</th><th>User Id</th><th>Edit</th></tr>`;
        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].name}</td><td>${arr[i].description}</td><td>${arr[i].amount}</td><td>${arr[i].userId}</td>`;
            html += `<td><i class="bi bi-trash text-danger" onclick='DeleteRequest(${arr[i].id})'></i><i class="bi bi-pencil-square" onclick='RequestModify(${arr[i].id},"${arr[i].name}",${req})'></i></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divRequest").html(html);
    });
}

let selectedRequestId = 0;

function NewRequest() {
    selectedRequestId = 0;
    $("#inputRequestAd").val("");
    $("#requestModal").modal("show");
}
function SaveRequest() {
    var request = {
        Id: selectedRequestId,
        Name: $("#inputRequestAd").val(),
        Description: $("#inputDescription").val(),
        Amount: $("#inputAmount").val(),
        UserId: $("#inputUserId").val()
    };
    Post("Request/Save", request, (data) => {
        GetRequest();
        $("#requestModal").modal("hide");
        alert("Successfully");
        $("#inputRequestAd").val("");
        $("#inputDescription").val("");
        $("#inputAmount").val("");

    });
}


function DeleteRequest(id) {
    Delete(`Request/Delete?id=${id}`, (data) => {
        GetRequest();
    });
    alert("Successfully");
}

function RequestModify(id, name,req) {
    selectedRolId = id;
    $("#inputRequestAd").val(name);
    $("#inputDescription").val(req);

    $("#requestModal").modal("show");
}

$(document).ready(function () {
    GetRequest();
});