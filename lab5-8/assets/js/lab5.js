$('#get').click(function() {
    $.ajax({
        url: '/api/numbers/get_random'
    }).success(function(data) {
        $('#number').text(data);
    });
});

$('#submit').click(function() {
    var number = $('#number').text();
    number = '17';
    $.ajax({
        url: '/api/numbers/check_number',
        type: 'post',
        data: number
    }).success(function(res) {
        if (res === 'true')
            alert("Prime");
        else alert("Not prime");
    });
})