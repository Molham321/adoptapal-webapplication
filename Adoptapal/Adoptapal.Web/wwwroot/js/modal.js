
$("#modalBtn").click(function () {
    $("#testModal").modal("show");
})

$('[data-dismiss="modal"]').each(function () {
    $(this).click(function () {
        $("#testModal").modal("hide");
    });
})

$("#saveButton").click(function () {
    alert("Saved");
    $("#testModal").modal("hide");
});