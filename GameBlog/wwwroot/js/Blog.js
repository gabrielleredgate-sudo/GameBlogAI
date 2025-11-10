$(document).ready(function () {


    $("#showModalButton").click(function () {
        $("#myModal").modal("show");
    });

    $("#submitBlogBtn").click(function (e) {
        e.preventDefault();

        var title = $("#newTitle").val();
          var post = $("#newBlogBody").val();
     


        $.ajax({
            url: 'NewBlogSubmit/' + title + '/' + post,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: {title: title, post: post},
            success: function (response) {
                if (response.success) {
                    window.location.reload(true);
                } else {
                    $("#newTitle").text(response.message).css("color", "red");
                }
            },
            error: function (xhr, status, error) {
                $("#newTitle").text("Error: " + error).css("color", "red");
            }
        });
    });
});