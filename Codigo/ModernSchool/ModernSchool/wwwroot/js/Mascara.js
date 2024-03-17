$(document).ready(function () {
    $("#cpf").inputmask("999.999.999-99"); //static mask
    $("#cep").inputmask("99999-999");
    $('#nome').on('input', function () {
        var texto = $(this).val();
        var textoCapitalizado = capitalizarPrimeirasLetras(texto);
        $(this).val(textoCapitalizado);
    });
    function limparCampo(idCampo) {
        $(idCampo).inputmask('remove');
        $(idCampo).val("");
    }
});
function capitalizarPrimeirasLetras(texto) {
    return texto.toLowerCase().replace(/(?:^|\s)\S/g, function (a) { return a.toUpperCase(); });
}