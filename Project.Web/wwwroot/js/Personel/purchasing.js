function GetPurchasing() {
    var req = $("#inputCompanyId").val();
    Get("Offer/PurchasingByCompId/" + req, (data) => {
        var html = `<table class="table table-hover">` +
            `<tr>
            <th>Requester Name</th>
            <th>Department</th>
            <th>Request Name</th>
            <th>Description</th>
            <th>Amount</th>
            <th>Request Date</th>
            <th>ApproveDate</th>
            <th>Supplier Name</th>
            <th>Supplier Description</th>
            <th>Price</th>
            <th>Offer Date</th>
            <th>Status</th>
            <th>Operations</th>
            </tr>`;
        var arr = data;

        for (var i = 0; i < arr.length; i++) {
                html += `<tr>`;
                html += `
            <td>${arr[i].userName} ${arr[i].userSurname}</td>
            <td>${arr[i].depName}</td>
            <td>${arr[i].requestName}</td>
            <td>${arr[i].requestDescription}</td>
            <td>${arr[i].amount}</td>
            <td>${formatDate(arr[i].requestDate)}</td>
            <td>${formatDate(arr[i].approveDate)}</td>
            <td>${arr[i].offerName}</td>
            <td>${arr[i].offerDescription}</td>
            <td>${arr[i].price} ₺</td>
            <td>${formatDate(arr[i].offerDate)}</td>`;

                if (arr[i].status == 1) {
                    html += `<td>waiting to approve</td>`;
                } else if (arr[i].status == 2) {
                    html += `<td>upon general approval</td>`;
                } else if (arr[i].status == 4) {
                    html += `<td>Approved ${arr[i].status}</td>`;
                } else if (arr[i].status == 6) {
                    html += `<td>Refused ${arr[i].status}</td>`;
                }
                html += `<td>
                <div class="dropdown">
              <button class="btn btn-info dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                Operations
              </button>
              <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                <i class=" dropdown-item btn btn-success"
                onclick='General(
                    "${arr[i].offerId}",
                    "${arr[i].requestId}",
                    "${arr[i].offerName}",
                    "${arr[i].price}",
                    "${arr[i].offerDescription}",
                    "${arr[i].offerDate}"
                )'>Show Invoice</i>
              </ul>
            </div>
            </td>`;
              
            html += `</tr>`
        }
        html += `</table>`;
        $("#divPurchasing").html(html);
    });
}
function General(offerId, requestId, userName, price, description, offerdate) {
    $("#invoiceModal").modal("show");
}
function formatDate(inputDate) {
    const dateObj = new Date(inputDate);
    const year = dateObj.getFullYear();
    const month = String(dateObj.getMonth() + 1).padStart(2, '0');
    const day = String(dateObj.getDate()).padStart(2, '0');
    const hours = String(dateObj.getHours()).padStart(2, '0');
    const minutes = String(dateObj.getMinutes()).padStart(2, '0');
    const seconds = String(dateObj.getSeconds()).padStart(2, '0');
    return `${year}/${month}/${day} ${hours}:${minutes}`;
}
$(document).ready(function () {
    GetPurchasing();
});