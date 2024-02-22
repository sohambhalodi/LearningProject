"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.start().then(function () {
    console.log("connection start.")
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("ReceiveMessage", function (IsSender,IsGroup, user, senderId, message, date) {
    const queryString = window.location.search;
    const searchParams = new URLSearchParams(queryString);
    const urlId = searchParams.get('receiverId');

    if ($('#senderId').val() == user && IsSender == false && IsGroup==true)
        return;

    if (urlId === senderId) {
        const messageDate = new Date(date);
        const options = { hour: 'numeric', minute: 'numeric', hour12: true, weekday: 'long' };
        const dateString = messageDate.toLocaleString('en-US', options);

        const li = document.createElement("li");
        li.classList.add('clearfix');


        /* --- Message Div Heading --- */
        const divMessageHeading = document.createElement('div');
        if (IsSender)
            divMessageHeading.classList.add('message-data', 'text-right');
        else
            divMessageHeading.classList.add('message-data');

        const span = document.createElement('span');
        span.classList.add('message-data-time');
        span.textContent = dateString;
        divMessageHeading.appendChild(span);
        /* --- Over Message Div Heading --- */

        /* --- Message Body --- */
        const divMessageDataPerent = document.createElement('div');
        const divMessageData = document.createElement('div');

        divMessageDataPerent.classList.add('align-right');

        if (IsSender)
            divMessageData.classList.add('message', 'other-message')
        else
            divMessageData.classList.add('message', 'my-message')
        divMessageData.textContent = message;

        /* --- Over Message Body --- */

        if (IsSender) {
            divMessageDataPerent.appendChild(divMessageData);
            divMessageDataPerent.appendChild(divMessageHeading);
            li.appendChild(divMessageDataPerent);
        }
        else {
            li.appendChild(divMessageData);
            li.appendChild(divMessageHeading)
        }

        //li.appendChild(divMessageHeading);
        document.getElementById("messageList").appendChild(li);
        var objDiv = document.getElementById("chat-history");
        objDiv.scrollTop = objDiv.scrollHeight;
    }
});

connection.on("ReceiveMessageTest", function (message) {
    console.log(message);
});

const txtMessage = document.getElementById('txtMessage');
if (txtMessage) {
    document.getElementById("txtMessage").addEventListener("keypress", function (event) {
        if (event.code === "Enter") {
            let sender = document.getElementById("senderName").value;
            let receiver = document.getElementById("receiverId").value;
            let groupId = document.getElementById("groupId").value;
            let groupName = document.getElementById("groupName").value;
            let message = document.getElementById("txtMessage").value;
            $("#txtMessage").val("");
            if (groupId == 0) {
                connection.invoke("SendMessageToUser", receiver, message).catch(function (err) {
                    return console.error(err.toString());
                });
            }
            else {
                connection.invoke("SendMessageToGroup", groupId, groupName, message).catch(function (err) {
                    return console.error(err.toString());
                });
            }
            event.preventDefault();
        }
    });
}