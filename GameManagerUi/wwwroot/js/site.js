const navBar = $("body")

navBar.on("click", function (e) {
    console.log(e)
    $(e.target).append($(document.createElement("div")).html("hi"))
})
