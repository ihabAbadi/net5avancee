const connection = new signalR.HubConnectionBuilder().withUrl('/firstHub').build()
connection.start().then(res => {
    console.log(res)
}).catch(err => {
    console.log(err)
})
connection.on("ReceiveMessage", (message, u) => {
    $("#result").append(`<div class='row'> from ${u}: ${message}</div>`)
})

$("#send").on('click', function (e) {
    connection.invoke("SendMessage", $("input[name='message']").val(), $("input[name='user']").val()).catch(err => {
        console.log(err)
    })
})