$(document).ready(function() {

    $.sifr({
        path: 'Swf/',
        save: true
    });
    $('h1').sifr({ font: 'Title' });
    //$('.Nav').sifr({ font: 'Title' });


    $('.ttT').tipsy({ gravity: 's', fade: false });
    $('.ttB').tipsy({ gravity: 'n', fade: false });
    $('.ttL').tipsy({ gravity: 'e', fade: false });
    $('.ttR').tipsy({ gravity: 'w', fade: false });    
});