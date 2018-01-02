$(document).ready(function () {

    function GetId() {
        var result = window.location.pathname.split('/Product/Edit/');

        return result[1];
    }
    var id = GetId();
    console.log(id);

    var product = { Id: parseInt(document.getElementById("Id").value), ProductName: document.getElementById("ProductName").value, Price: parseInt(document.getElementById("Price").value), SellerId: 2, CatagoryId: parseInt(document.getElementById("CatagoryId").value) }

    var json = JSON.stringify(product);

    $('#btnSave').click(function () {
        console.log('clicked');
        $.ajax({
            url: 'http://localhost:52683/api/Home/' + id,
            method: 'PUT',
            contentType: 'application/json; charset=utf-8',
            data: json,
            complete: function (xhr)
            {
                window.alert(xhr.statusText);
                console.log(product);
            }
        })
    })
    
})