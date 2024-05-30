$('#loginForm').submit(function (e) {
    e.preventDefault();

    let Email = {
        "message": {
            "subject": document.getElementById('subject').value,
            "body": {
                "contentType": "Text",
                "content": document.getElementById('content').value,
            },
            "toRecipients": [
                {
                    "emailAddress": {
                        "address": document.getElementById('email').value,
                    }
                }
            ]
        }
    };
        $.ajax({
            type: "POST",
            url: "/Home/SendMail",
            data: {
                sendEmail: Email
            },
            success: function (data) {
                alert(data);
            },
            error: function () {
                alert('error');
            }
        });
});