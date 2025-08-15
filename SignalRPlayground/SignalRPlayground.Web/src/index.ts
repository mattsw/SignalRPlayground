import * as signalR from "@microsoft/signalr";
import "./css/main.css";

const divMessages: HTMLDivElement = document.querySelector("#divMessages");
const tbMessage: HTMLInputElement = document.querySelector("#tbMessage");
const btnSend: HTMLButtonElement = document.querySelector("#btnSend");
const btnUpdate: HTMLButtonElement = document.querySelector("#btnUpdate");
const username = new Date().getTime();

let user = {
  firstName: "",
  lastName: "",
  userId: username + ''
}

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .build();

connection.on("messageReceived", (username: string, message: string) => {
  const m = document.createElement("div");

  let fullname = user.firstName + " " + user.lastName;
  m.innerHTML = `<div class="message-author">${(fullname.trim() || user.userId)}</div><div>${message}</div>`;

  divMessages.appendChild(m);
  divMessages.scrollTop = divMessages.scrollHeight;
});

connection.start().catch((err) => document.write(err));

tbMessage.addEventListener("keyup", (e: KeyboardEvent) => {
  if (e.key === "Enter") {
    send();
  }
});

btnSend.addEventListener("click", send);
btnUpdate.addEventListener("click", update);

function send() {
  connection.send("newMessage", username, tbMessage.value)
    .then(() => (tbMessage.value = ""));
}

function update(){
  const headers: Headers = new Headers();
  headers.set('Content-Type', 'application/json');
  headers.set('Accept', '*/*');
  
  let firstNameField:HTMLInputElement = document.querySelector("#firstName");
  let lastNameField:HTMLInputElement = document.querySelector("#lastName");
  
  let userUpdate = {
    firstName: firstNameField.value,
    lastName: lastNameField.value,
    userId: username,
  }

  const request: RequestInfo = new Request('/api/User', {    
    method: 'PUT',
    headers: headers,    
    body: JSON.stringify(user)
  });

  
  return fetch(request)
      .then(res => {
        user.firstName = userUpdate.firstName;
        user.lastName = userUpdate.lastName;
      });
}