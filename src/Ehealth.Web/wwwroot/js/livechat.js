let connection = new signalR.HubConnectionBuilder().withUrl("/livechat").build();

connection.on("NewMessage",
    function (message) {

        let chatInfo = `<div><strong style= "color: blue">${message.userId}=></strong>   ${message.text}</div>`;
        let line = `<hr />`;

        $("#messagesList").append(chatInfo);
        $("#messagesList").append(line);
    });

connection.on("NewMessageFromAdmin",
    function (message) {

        let chatInfo = `<div class="text-right">${message.text}   <strong style= "color: blue"><=${message.userId}</strong></div>`;
        let line = `<hr />`;

        $("#messagesList").append(chatInfo);
        $("#messagesList").append(line);
    });


$("#sendButton").click(function () {

    let message = $("#messageInput").val();

    if (message.length > 0) {
        connection.invoke("SendMessage", message);
    }
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});