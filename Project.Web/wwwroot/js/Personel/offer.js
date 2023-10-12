function GetOffer() {
    var req = $("#inputCompanyId").val();
    Get("Request/OfferByCompId/" + req, (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th>Request Name</th><th>Description</th><th>Amount</th><th>Request Date</th><th>Status</th><th>ApproveDate</th></tr>`;
        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].name}</td><td>${arr[i].description}</td><td>${arr[i].amount}</td><td>${arr[i].requestDate}</td><td>${arr[i].status === null ? 'Waiting...' : arr[i].status ? 'Approved' : 'Refused'}</td><td>${arr[i].approveDate === null ? 'Waiting...' : arr[i].approveDate}</td>`;
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
function validate(evt) {
    var theEvent = evt || window.event;

    // Handle paste
    if (theEvent.type === 'paste') {
        key = event.clipboardData.getData('text/plain');
    } else {
        // Handle key press
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
        $("#requestModal").modal("hide");
        alert("Successfully Offered");
        $("#inputOfferName").val("");
        $("#inputDescription").val("");
        $("#inputPrice").val("");

    });
}
$(document).ready(function () {
    GetOffer();
});