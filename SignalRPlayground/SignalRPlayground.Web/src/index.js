"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var signalR = require("@microsoft/signalr");
require("./css/main.css");
var divMessages = document.querySelector("#divMessages");
var tbMessage = document.querySelector("#tbMessage");
var btnSend = document.querySelector("#btnSend");
var btnUpdate = document.querySelector("#btnUpdate");
var username = new Date().getTime();
var user = {
    firstName: "",
    lastName: "",
    userId: username + ''
};
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .build();
connection.on("messageReceived", function (username, message) {
    var m = document.createElement("div");
    var fullname = user.firstName + " " + user.lastName;
    m.innerHTML = "<div class=\"message-author\">".concat((fullname.trim() || user.userId), "</div><div>").concat(message, "</div>");
    divMessages.appendChild(m);
    divMessages.scrollTop = divMessages.scrollHeight;
});
connection.start().catch(function (err) { return document.write(err); });
tbMessage.addEventListener("keyup", function (e) {
    if (e.key === "Enter") {
        send();
    }
});
btnSend.addEventListener("click", send);
btnUpdate.addEventListener("click", update);
function send() {
    connection.send("newMessage", username, tbMessage.value)
        .then(function () { return (tbMessage.value = ""); });
}
function update() {
    var headers = new Headers();
    headers.set('Content-Type', 'application/json');
    headers.set('Accept', '*/*');
    var firstNameField = document.querySelector("#firstName");
    var lastNameField = document.querySelector("#lastName");
    var userUpdate = {
        firstName: firstNameField.value,
        lastName: lastNameField.value,
        userId: username,
    };
    var request = new Request('/api/User', {
        method: 'PUT',
        headers: headers,
        body: JSON.stringify(user)
    });
    return fetch(request)
        .then(function (res) {
        user.firstName = userUpdate.firstName;
        user.lastName = userUpdate.lastName;
    });
}
