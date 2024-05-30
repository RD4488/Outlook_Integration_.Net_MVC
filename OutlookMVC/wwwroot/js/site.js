// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Home/GetMails",
        success: function (data) {
            console.log(data.value);
            
            var table = document.getElementById('myTable');

            data.value.forEach(function (item) {
                var row = table.insertRow();

                var toRecipientsCell = row.insertCell(0);
                var fromCell = row.insertCell(1);
                var subjectCell = row.insertCell(2);
                var bodyPreviewCell = row.insertCell(3);
                var createdDateTimeCell = row.insertCell(4);

                var emailAddresses = item.toRecipients.map(function (recipient) {
                    return recipient.emailAddress.address;
                });
                toRecipientsCell.innerHTML = emailAddresses.join(', ');
                fromCell.innerHTML = item.from.emailAddress.address;
                subjectCell.innerHTML = item.subject;
                bodyPreviewCell.innerHTML = item.body.content;
                createdDateTimeCell.innerHTML = item.createdDateTime;
            });
        },
    });

    $.ajax({
        type: "GET",
        url: "/Home/GetInboxMails",
        success: function (data) {
            console.log(data);
            var table = document.getElementById('myTable1');

            data.value.forEach(function (item) {
                var row = table.insertRow();

                var toRecipientsCell = row.insertCell(0);
                var fromCell = row.insertCell(1);
                var subjectCell = row.insertCell(2);
                var bodyPreviewCell = row.insertCell(3);
                var createdDateTimeCell = row.insertCell(4);

                var emailAddresses = item.toRecipients.map(function (recipient) {
                    return recipient.emailAddress.address;
                });
                toRecipientsCell.innerHTML = emailAddresses.join(', ');
                fromCell.innerHTML = item.from.emailAddress.address;
                subjectCell.innerHTML = item.subject;
                bodyPreviewCell.innerHTML = item.body.content;
                createdDateTimeCell.innerHTML = item.createdDateTime;
            });
        },
    });
});