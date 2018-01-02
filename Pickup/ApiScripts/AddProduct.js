$(document).ready(function () {
    $('#btnAdd').click(function () {

        $.ajax({
            url: 'http://localhost:52683/api/Home/',
            method: 'POST',
            dataType: 'json',
            data: $('#productForm').serialize(),
            complete: function (xhr) {

                if (xhr.status == 201) {

                    window.alert("Product Added");
                    window.location.href = "http://localhost:52662/Home";
                }

                else 
                {
                    window.alert(xhr.statusText);
                }
            }
        })
    })
})