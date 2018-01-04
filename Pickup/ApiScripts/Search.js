$(document).ready(function () {

    $('#btnSearch').click(function () {

        $.ajax({
            url: 'http://localhost:52662/api/Home/Search',
            method: 'GET',
            data: $('#searchForm').serialize(),
            success: function (obj) {
                console.log(obj.Id);
            }
        })
    })

})