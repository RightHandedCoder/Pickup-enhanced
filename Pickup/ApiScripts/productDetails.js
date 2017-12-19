$(document).ready(function () {

    function GetId() {
        var result = window.location.pathname.split('/Home/Details/');

        return result[1];
    }
    var id = GetId();
    $.ajax({
        url: 'http://localhost:52683/api/Home/' + id,
        method: 'GET',
        success: function (product){
            var row = "<tr><td><image alt='Photo'></image></td></tr>";
            row += "<tr><td>" + product.ProductName + "</td></td>";
            row += "<tr><td>" + product.Price + "</td></td>";

            $('#product').append(row);
        }
    })

})