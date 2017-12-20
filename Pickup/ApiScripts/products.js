$(document).ready(function () {
    console.log("Ready");
    $.ajax({
        url: 'http://localhost:52683/api/Home/',
        method: 'GET',
        success: function (productList) {
            productList.forEach(function (product) {
                var row = "<tr>";
                row += "<td><a href='Home/Details/" + product.Id + "'><image alt='Photo'></td></a>";
                row += "<td>";
                row += "<table align = 'center'>";
                row += "<tr>";
                row += "<td>Product:</td>";
                row += "<td>" + product.ProductName + "</td>";
                row += "</tr>";
                row += "<tr>";
                row += "<td>Price:</td>";
                row += "<td>" + product.Price + "</td>";
                row += "<td rowspan='2'><a href='Home/Details/" + product.Id + "'>Add To Cart</a></td>";
                row += "</tr>";
                row += "</table>";
                row += "</table>";
                row += "</td>";
                row += "</tr>";

                $('#productArea').append(row);
            });
        },

          complete: function (xhr) {

              if (!xhr.status==200) {
                  $('#noti').append("Loading Error");
              }
        }
    })
})