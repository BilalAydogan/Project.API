function GetOffer() {
    var req = $("#inputCompanyId").val();
    Get("Request/OfferByCompId/" + req, (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th>Requester Name</th><th>Request Name</th><th>Description</th><th>Amount</th><th>Request Date</th><th>Status</th><th>ApproveDate</th></tr>`;
        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            
            html += `<tr>`;
            html += `<td>${arr[i].name} ${arr[i].surname}</td><td>${arr[i].reqName}</td><td>${arr[i].description}</td><td>${arr[i].amount}</td><td>${formatDate(arr[i].requestDate)}</td><td>${arr[i].status === null ? 'Waiting...' : arr[i].status ? 'Approved' : 'Refused'}</td><td>${arr[i].approveDate === null ? 'Waiting...' : formatDate(arr[i].approveDate)}</td>`;
            html += `<td>
                <div class="dropdown">
              <button class="btn btn-info dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                Operations
              </button>
              <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                <i class=" dropdown-item btn btn-success" onclick='OpenOffer(${arr[i].requestId})'>Give an Offer</i>
                <i class=" dropdown-item btn btn-success" onclick='ShowOffer(${arr[i].requestId})'>Show Offers</i>
              </ul>
            </div>
            </td>`;
            html += `</tr>`
            
        }
        html += `</table>`;
        $("#divOffer").html(html);
    });
}
function ShowOffer(id) {
    Get("Offer/OfferById/" + id, (data) => {
        var mod = `
        <div class="modal fade" id="showOfferModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="exampleModalLabel">Offers Details</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Offer Name</th>
                                    <th>Offer Description</th>
                                    <th>Offer Price</th>
                                    <th>Offer Status</th>
                                    <th>Edit</th>
                                    <!-- Add more columns as needed -->
                                </tr>
                            </thead>
                            <tbody id="offerTableBody">
                                <!-- Offer details will be appended here dynamically -->
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        `;

        $("#divMod").html(mod);

        var offerTableBody = $("#offerTableBody");
        offerTableBody.empty();

        data.forEach((offer) => {
            var row = `<tr>
                <td>${offer.userName}</td>
                <td>${offer.description}</td>
                <td>${offer.price} ₺</td>
                <td>${ offer.status === null ? 'Waiting...' : offer.status ? 'Approved' : 'Refused'}</td>
                <td>
                <button class="btn btn-success" onclick='AcceptOffer(
                    "${offer.id}",
                    "${offer.requestId}",
                    "${offer.userName}",
                    "${offer.price}",
                    "${offer.description}",
                    "${offer.offerDate}"
                )'>Accept</button>
                <button class="btn btn-danger" onclick='RefuseOffer(
                    "${offer.id}",
                    "${offer.requestId}",
                    "${offer.userName}",
                    "${offer.price}",
                    "${offer.description}",
                    "${offer.offerDate}"
                )'>Refuse</button>
                    </td>
            </tr>`;
            offerTableBody.append(row);
        });

        $("#showOfferModal").modal("show");
    });
}
function AcceptOffer(offerId, requestId, userName, price, description,offerdate) {
    var den = {
        Id: offerId,
        RequestId: requestId,
        UserName: userName,
        Price: price,
        Description: description,
        Status: 1,
        OfferDate: offerdate
    };
    Post("Offer/Save", den, (data) => {
        alert("Offer Approved Successfully");

    });

}
function RefuseOffer(offerId, requestId, userName, price, description, offerdate) {
    var den = {
        Id: offerId,
        RequestId: requestId,
        UserName: userName,
        Price: price,
        Description: description,
        Status: 0,
        OfferDate: offerdate
    };
    Post("Offer/Save", den, (data) => {
        alert("Offer Successfully Refused");

    });

}
function validate(evt) {
    var theEvent = evt || window.event;

    if (theEvent.type === 'paste') {
        key = event.clipboardData.getData('text/plain');
    } else {
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
    }
    var regex = /[0-9]|\./;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}
function OpenOffer(id) {
    $("#inputReqId").val(id);
    $("#makeOfferModal").modal("show");
}
function OpenModal(id) {
    $("#inputReqId").val(id);
    $("#showOfferModal").modal("show");
}
function MakeOffer(id) {
    var offer = {
        Id: 0,
        RequestId: $("#inputReqId").val(),
        UserName: $("#inputOfferName").val(),
        Description: $("#inputDescription").val(),
        Price: $("#inputPrice").val(),
        OfferDate: moment().format(),
        Status: null
    };
    Post("Offer/Save", offer, (data) => {
        $("#makeOfferModal").modal("hide");
        alert("Successfully Offered");
        $("#inputOfferName").val("");
        $("#inputDescription").val("");
        $("#inputPrice").val("");

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
    GetOffer();
});