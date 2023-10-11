function GetApprove() {
    var req = $("#inputUserId").val();
    Get("Request/RequestApproveId/" + req, (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th>Request Name</th><th>Description</th><th>Amount</th><th>Request Date</th><th>Status</th><th>ApproveDate</th><th>Edit</th></tr>`;
        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `
            <td>${arr[i].name}</td>
            <td>${arr[i].description}</td>
            <td>${arr[i].amount}</td>
            <td>${arr[i].requestDate}</td>
            <td>${ arr[i].status === null ? 'Waiting...' : arr[i].status ? 'Approved' : 'Refused' }</td>
            <td>${arr[i].approveDate}</td>
            `;
            html += `<td>
            <i class="bi bi-check2-circle text-success fs-3 px-2"
            onclick='Approve(${arr[i].id},"${arr[i].name}",${arr[i].userId},${arr[i].approveId},"${arr[i].description}",${arr[i].amount},"${arr[i].requestDate}")'></i>
            <i class="bi bi-x-circle-fill text-danger fs-4" onclick='Refuse(
                ${arr[i].id},
                "${arr[i].name}",
                ${arr[i].userId},
                ${arr[i].approveId},
                "${arr[i].description}",
                ${arr[i].amount},
                "${arr[i].requestDate}"
            )'></i>
            </td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divApprove").html(html);
    });
}
let selectedApproveId = 0;
function Approve(id, name, userId, ApproveId, description, amount, requestDate) {
        var app = {
            Id: id,
            UserId: userId,
            ApproveId: ApproveId,
            Name: name,
            Description: description,
            Amount: amount,
            RequestDate: requestDate,
            Status: 1,
            ApproveDate: moment().format()
        };
        Post("Request/Save", app, (data) => {
            GetApprove();
            alert("Approved");
        });
}
function Refuse(id, name, userId, ApproveId, description, amount, requestDate) {
    var app = {
        Id: id,
        Name: name,
        UserId: userId,
        ApproveId: ApproveId,
        Description: description,
        Amount: amount,
        RequestDate: requestDate,
        Status: 0,
        ApproveDate: moment().format()
    };
    Post("Request/Save", app, (data) => {
        GetApprove();
        alert("Refused");
    });
}
$(document).ready(function () {
    GetApprove();
});