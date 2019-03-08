$(function () {
    $("#tblZimmet").on("click", ".btnZimmetSil", function () {

        var btn = $(this);
        bootbox.confirm("Ürünü, Arızları ürünler listesine eklemek istediğinize emin misiniz?", function (result) {
            if (result) {
                var id = btn.data("id");
                $.ajax({
                    type: "GET",
                    url: "/Zimmet/Arizalandi/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                });
            }
        })
        
    });
});