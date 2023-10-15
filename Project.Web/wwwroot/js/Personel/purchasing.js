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
                    html += `<td>Approved </td>`;
                } else if (arr[i].status == 6) {
                    html += `<td>Refused </td>`;
                }
                else if (arr[i].status == 5) {
                    html += `<td>Stocked </td>`;
                }
                html += `<td>
                <div class="dropdown">
              <button class="btn btn-info dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                Operations
              </button>
              <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">`;
            if (arr[i].status == 4) {
                html += `
                <i class=" dropdown-item btn btn-success"
                onclick='General(
                    "${arr[i].requestId}",
                    "${arr[i].userName}",
                    "${arr[i].userSurname}",
                    "${arr[i].depName}",
                    "${arr[i].requestName}",
                    "${arr[i].requestDescription}",
                    "${arr[i].requestDate}",
                    "${arr[i].approveDate}",
                    "${arr[i].offerId}",
                    "${arr[i].offerName}",
                    "${arr[i].amount}",
                    "${arr[i].price}",
                    "${arr[i].offerDescription}",
                    "${arr[i].offerDate}"
                )'>Show Invoice</i>`;
            } 
                else {
                html += `<i class=" dropdown-item btn btn-success">Else</i>`;
                }
            html += `<i class=" dropdown-item btn btn-success"
            onclick='SendStock(
                "${arr[i].companyId}",
                "${arr[i].requestName}",
                "${arr[i].amount}",
                "${arr[i].requestDescription}",
                "${arr[i].offerId}",
                "${arr[i].requestId}",
                "${arr[i].userName}",
                "${arr[i].price}",
                "${arr[i].offerdescription}",
                "${arr[i].offerDate}"
            )'>Send to Stock</i>`;
            html +=`
              </ul>
            </div>
            </td>`
            html += `</tr>`;
        }
        html += `</table>`;
        $("#divPurchasing").html(html);
    });
}
function General(
    requestId, userName, userSurname, depName, requestName, requestDescription, requestDate, approveDate,
    offerId, offerName, amount, price, offerDescription, offerDate) {
    $("#RequestId").text(requestId);
    $("#RequesterName").text(userName + " " + userSurname);
    $("#RequesterDep").text(depName);
    $("#RequestName").text(requestName);
    $("#RequestDescription").text(requestDescription);
    $("#amount").text(amount);
    $("#offerId").text(offerId);
    $("#offerName").text(offerName);
    $("#price").text(price + " ₺");
    $("#offerDescription").text(offerDescription);
    $("#offerDate").text(formatDate(offerDate));
    $("#requestDate").text(formatDate(requestDate));
    $("#approveDate").text(formatDate(approveDate));
    $("#summaryName").text(requestName);
    $("#summaryDescription").text(requestDescription);
    $("#invoiceModal").modal("show");
}
function SendStock(companyId, requestName, amount, description, offerId, requestId, userName, price, offerdescription,offerDate) {
    var storage = {
        Id: 0,
        CompanyId: companyId,
        Name: requestName,
        Amount: amount,
        Description: description,
        EntryDate: moment().format()
    };
    Post("Storage/Save", storage, (data) => {
        alert("Stored Successfully");
        GetPurchasing();

    });
    var general = {
        Id: offerId,
        RequestId: requestId,
        UserName: userName,
        Price: price,
        Description: offerdescription,
        Status: 5,
        OfferDate: offerDate
    };
    Post("Offer/Save", general, (data) => {
        alert("Status Change to Stored Successfully");
        Manager();

    });
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