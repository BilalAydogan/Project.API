﻿function GetRequest() {
    var req = $("#inputUserId").val();
    Get("Request/RequestById/" + req, (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th>Request Name</th><th>Description</th><th>Amount</th><th>Request Date</th><th>Status</th><th>ApproveDate</th></tr>`;
        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].name}</td><td>${arr[i].description}</td><td>${arr[i].amount}</td><td>${arr[i].requestDate}</td><td>${arr[i].status === null ? 'Waiting...' : arr[i].status ? 'Approved' : 'Refused'}</td><td>${arr[i].approveDate === null ? 'Waiting...' : arr[i].approveDate}</td>`;
            html += `<td><i class="bi bi-trash text-danger" onclick='DeleteRequest(${arr[i].id})'></i><i class="bi bi-pencil-square" onclick='RequestModify(${arr[i].id},"${arr[i].name}",${req})'></i></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divRequest").html(html);
    });
}
function GetSupervisor() {
    var req = $("#inputUserId").val();
    Get("Request/UserById/" + req, (data) => {
        
        var arr = data;
        for (var i = 0; i < arr.length; i++) {
            $("#inputSupervisorId").val(arr[i].supervisorId);
            $("#inputDate").val(moment().format());
        }
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
        UserId: $("#inputUserId").val(),
        ApproveId: $("#inputSupervisorId").val(),
        RequestDate: moment().format(),
        Status: null,
        ApproveDate: null
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
    GetSupervisor();
    GetRequest();    
});