$(document).ready(function () {
    $('#movies').DataTable();

    $("#movies").on("click", ".js-delete", function () {
        var button = $(this);
        var apiUrl = '@System.Web.Configuration.WebConfigurationManager.AppSettings["MoviesAPI"]/api/Movies/' + button.attr("data-movie-id");
        bootbox.confirm("Are you sure you want to delete this Movie?", function (result) {
            if (result) {
                $.ajax({
                    url: apiUrl,
                    method: "DELETE",
                    success: function () {
                        button.parents("tr").remove();
                    }
                });
            }
        });
    });
});