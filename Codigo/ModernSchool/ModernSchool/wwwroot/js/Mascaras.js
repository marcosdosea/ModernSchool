$(document).ready(function () {
    // Inicializa com a formatação desejada
    $('#decimalInput').autoNumeric({
        aSep: ',',
        aDec: '.',
        mDec: '2',
        vMin: '0.00'
    });

    // Formata o campo enquanto o usuário digita
    $('#decimalInput').on('keyup', function () {
        $(this).autoNumeric('update');
    });
});
