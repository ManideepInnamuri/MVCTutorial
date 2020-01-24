$(".custom-file-input").on("change", function () {
    var fileName = $(this).val().split("\\").pop();
    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
});

// popovers initialization - on hover
$('[data-toggle="popover-hover"]').popover({
    html: true,
    trigger: 'hover',
    placement: 'bottom',
    content: function () { return '<img style="height:20%;width:10em;" src="' + $(this).data('img') + ' " />'; }
});

// popovers initialization - on click
$('[data-toggle="popover-click"]').popover({
    html: true,
    trigger: 'click',
    placement: 'bottom',
    content: function () { return '<img src="' + $(this).data('img') + '" />'; }
});