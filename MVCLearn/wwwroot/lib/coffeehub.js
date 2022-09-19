let connection = null;
setupConnection = () => {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:44331/api/coffeehub")
        .build();

    connection.on("ReceiveOrderUpdate", (update) => {
        const statusDiv = document.getElementById("status");
        statusDiv.innerHTML = update;
    });
    connection.on("Finished", function () {
        connection.stop();
    });
    connection.start()
        .catch(err => console.error(err.toString()))
            .then(result => { console.log("connection started");})
                .then(result => { connection.invoke("GetUpdate"); });

    
};
setupConnection();
