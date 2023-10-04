function GetUser() {
    Get("User/AllUs", (data) => {
        var html = `<table class="table table-hover table-responsive">` +
            `<tr>
            <th>Name</th>
            <th>Surname</th>
            <th>Email</th>
            <th>Company</th>
            <th>Department</th>
            <th>Rol</th>
            <th>Edit</th>
            </tr>`;
        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `
            <td>${arr[i].name}</td>
            <td>${arr[i].surname}</td>
            <td>${arr[i].email}</td>
            <td>${arr[i].compName}</td>
            <td>${arr[i].depName}</td>
            <td>${arr[i].rolName}</td>
            `;
            html += `<td><i class="btn btn-danger" onclick='DeleteUser(${arr[i].id})'>Delete</i>
            </td>`;
            html += `</tr>`
        }
        html += `</table>`;
        $("#divUsers").html(html);
    });
}
function DeleteUser(id) {
    Delete(`Department/Delete?id=${id}`, (data) => {
        GetUser();
    });
    alert("Successfully");
}
$(document).ready(function () { GetUser();});