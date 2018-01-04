$(document).ready(function () {
    console.log("Ready");
    $.ajax({
        url: 'http://localhost:52683/api/Home/',
        method: 'GET',
        success: function (productList) {
            productList.forEach(function (product) {
                var row = '';
                row += '<div class="row">';
                row += '<div class="col-sm-6 col-md-4">';
                row += '<div class="thumbnail">';
                row += '<h4 class="text-center"><span class="label label-info">' + product.CatagoryName + '</span></h4>';
                row += '<a href="http://localhost:52662/Product/Details/' + product.Id + '"><img src="abcd" alt="Photo" class="img-responsive"></a>';
                row += '<div class="caption">';
                row += '<div class="row">';
                row += '<div class="col-md-6 col-xs-6">';
                row += '<h3>' + product.ProductName + '</h3>';
                row += '</div>';
                row += '<div class="col-md-6 col-xs-6 price">';
                row += '<h3><label>BDT ' + product.Price + '</label ></h3 >';
                row += '</div>';
                row += '<div class="row">';
                row += '<div class="col-md-6">';
                row += '<a href="http://localhost:52662/ShoppingCart/AddToCart/' + product.Id + '" class="btn btn-success btn-product"><span class="glyphicon glyphicon-shopping-cart"></span> Buy</a>';
                row += '</div>';
                row += '<div class="col-md-6">';
                row += '</div>';
                row += '</div>';
                row += '<p> </p>';
                row += '</div>';
                row += '</div>';
                row += '</div>';

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

                          
                            
                                
                                    
                