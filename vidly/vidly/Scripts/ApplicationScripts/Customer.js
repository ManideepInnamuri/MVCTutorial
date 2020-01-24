$(document).ready(function () {
    $('#customers').DataTable();

    //$('["popover"]').popover();



    $("#customers").on("click", ".js-delete", function () {
        var button = $(this);
        var apiUrl = '@System.Web.Configuration.WebConfigurationManager.AppSettings["MoviesAPI"]/api/customers/' + button.attr("data-customer-id");
        bootbox.confirm("Are you sure you want to delete this Customer?", function (result) {
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