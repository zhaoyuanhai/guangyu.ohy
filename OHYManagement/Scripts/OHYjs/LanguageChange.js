$("#language").change(function () {
    var lan = $("#language").val();
    window.location = "index?language=" + lan;
});