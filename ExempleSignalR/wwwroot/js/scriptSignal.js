const connection = new signalR.HubConnectionBuilder().withUrl('/firstHub').build()
connection.start().then(res => {
    console.log(res)
}).catch(err => {
    console.log(err)
})
connection.on("ReceiveMessage", (message) => {
    $("#result").append("<div class='row'>"+message+"</div>")
})

$("#send").on('click', function (e) {
    connection.invoke("SendMessage", $("input[name='message']").val()).catch(err => {
        console.log(err)
    })
})