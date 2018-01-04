$(document).ready(function () {

    function GetId() {
        var result = window.location.pathname.split('/Product/EditProduct/');

        return result[1];
    }
    var id = GetId();
    console.log(id);

   

    $('#btnSave').click(function () {

        var product = { ProductName: document.getElementById("ProductName").value, Price: parseInt(document.getElementById("Price").value), SellerId: 2, CatagoryId: parseInt(document.getElementById("CatagoryId").value) }

        var json = JSON.stringify(product);

        $.ajax({
            url: 'http://localhost:52683/api/Home/' + id,
            method: 'PUT',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: json,
            async: true,
            processData: false,
            cache: false,
            complete: function (xhr)
            {
                window.alert(xhr.statusText);
                console.log(json);
                window.location.href = 'http://localhost:526832/';
            }
        })
    })
    
})