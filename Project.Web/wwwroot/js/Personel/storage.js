function GetStorage() {
    var req = $("#inputCompanyId").val();
    Get("Storage/StorageByCompId/" + req, (data) => {
        var html = `<table class="table table-hover">` +
            `<tr>
            <th>Item Name</th>
            <th>Description</th>
            <th>Amount</th>
            <th>Entry Date</th>
            <th>Operations</th>
            </tr>`;
        var arr = data;
        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `
            <td>${arr[i].name}</td>
            <td>${arr[i].description}</td>
            <td>${arr[i].amount}</td>
            <td>${formatDate(arr[i].entryDate)}</td>`;
            if (arr[i].amount > 0) {
                html += `<td><i onclick='UseStock("${arr[i].storageId}","${arr[i].companyId}","${arr[i].name}","${arr[i].description}","${arr[i].amount}","${arr[i].entryDate}")' class="dropdown-item btn btn-success">Use from Storage</i> </td>`;
            } else {
                html += `<td>Don't Have More Stock </td>`;
            }
            html +=`
            </ul>
            </div>
            </td>`
            html += `</tr>`;
        }
        html += `</table>`;
        $("#divStorage").html(html);
    });
}
function UseStock(storageId, companyId, name, description, amount, entryDate) {
    $("#inputStorageId").val(storageId);
    $("#inputCompId").val(companyId);
    $("#inputItemName").val(name);
    $("#inputDescription").val(description);
    $("#inputAmount").val(amount);
    $("#inputEntryDate").val(entryDate);
    $("#StorageModal").modal("show");
}
function UseStorage() {
    var storage = {
        Id: $("#inputStorageId").val(),
        Name: $("#inputItemName").val(),
        CompanyId: $("#inputCompId").val(),
        Description: $("#inputDescription").val(),
        Amount: $("#inputAmount").val(),
        EntryDate: $("#inputEntryDate").val()
    };
    Post("Storage/Save", storage, (data) => {
        alert("Store used Successfully");
        GetStorage();
        $("#StorageModal").modal("hide");
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
    GetStorage();
});