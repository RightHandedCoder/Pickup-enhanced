$(document).ready(function () {

    function GetId() {
        var result = window.location.pathname.split('/Product/Edit/');

        return result[1];
    }
    var id = GetId();
    console.log(id);

    $('#btnDelete').click(function () {

        $.ajax({

            url: 'http://localhost:52683/api/Home/'+id,
            method: 'DELETE',
            complete: function (xhr)
            {
                alert(xhr.statusText);
            }
        })
    })
})