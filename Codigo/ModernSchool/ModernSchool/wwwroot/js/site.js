// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#cpf').on('change', function () {
        var cpf = $(this).val();
        var idTurma = $('#idTurma').val();
        $.ajax({
            url: 'BuscarAlunoPorCPF',
            type: 'POST',
            data: {
                cpf: cpf,
                idTurma: idTurma
            },
            success: function (aluno) {
                if (aluno) {
                    $('#nome').val(aluno.nome = capitalizarPrimeirasLetras(aluno.nome)).addClass('text-secondary !importants').prop('readonly', true);
                    $('#dataNascimento').val(aluno.dataNascimento.substring(0, 10)).addClass('text-secondary !importants').prop('readonly', true);
                    $('#cep').val(aluno.cep).addClass('text-secondary !importants').prop('readonly', true);
                    $('#rua').val(aluno.rua).addClass('text-secondary !importants').prop('readonly', true);
                    $('#bairro').val(aluno.bairro).addClass('text-secondary !importants').prop('readonly', true);
                    $('#numero').val(aluno.numero).addClass('text-secondary !importants').prop('readonly', true);
                    $('#email').val(aluno.email).addClass('text-secondary !importants').prop('readonly', true);
                    $('#idAluno').val(aluno.id).prop('readonly', true);
                    $('#telefone1').val(aluno.telefone1).addClass('text-secondary !importants').prop('readonly', true);
                    $('#telefone2').val(aluno.telefone2).addClass('text-secondary !importants').prop('readonly', true);
                    $('#estado').val(aluno.uf).addClass('text-secondary !importants').prop('readonly', true);
                    $('#cidade').val(aluno.cidade).addClass('text-secondary !importants').prop('readonly', true);
                    $('#complemento').val(aluno.complemento).addClass('text-secondary !importants').prop('readonly', true);
                } else {
                    $('#nome').val('').removeClass('text-secondary').prop('readonly', false);
                    $('#dataNascimento').val('').removeClass('text-secondary').prop('readonly', false);
                    $('#cep').val('').removeClass('text-secondary').prop('readonly', false);
                    $('#rua').val('').removeClass('text-secondary').prop('readonly', false);
                    $('#bairro').val('').removeClass('text-secondary').prop('readonly', false);
                    $('#numero').val('').removeClass('text-secondary').prop('readonly', false);
                    $('#email').val('').removeClass('text-secondary').prop('readonly', false);
                    $('#idAluno').val('').removeClass('text-secondary').prop('readonly', false);
                    $('#telefone1').val(aluno.telefone1).removeClass('text-secondary').prop('readonly', false);
                    $('#telefone2').val(aluno.telefone2).removeClass('text-secondary').prop('readonly', false);
                    $('#estado').val(aluno.uf).removeClass('text-secondary').prop('readonly', false);
                    $('#cidade').val(aluno.cidade).removeClass('text-secondary').prop('readonly', false);
                    $('#complemento').val(aluno.complemento).removeClass('text-secondary').prop('readonly', false);
                }
            },
        });
    });
    function capitalizarPrimeirasLetras(texto) {
        return texto.toLowerCase().replace(/(?:^|\s)\S/g, function (a) { return a.toUpperCase(); });
    }
});
$(document).ready(function () {
    $('thead th').addClass('border-top');
});

function obterNomeDia(abreviacao) {
    switch (abreviacao) {
        case 'DOM':
            return 'Domingo';
        case 'SEG':
            return 'Segunda-Feira';
        case 'TER':
            return 'Terça-Feira';
        case 'QUA':
            return 'Quarta-Feira';
        case 'QUI':
            return 'Quinta-Feira';
        case 'SEX':
            return 'Sexta-Feira';
        case 'SAB':
            return 'Sábado';
        default:
            return abreviacao;
    }
}
function formatarHora(hora) {
    var horas = hora.substring(0, 2);
    var minutos = hora.substring(2);

    return horas + ":" + minutos;
}
$(document).ready(function () {
    $('#toggleSenha').on('click', function () {
        var senhaInput = $('#senhaInput');
        var tipo = senhaInput.attr('type') === 'password' ? 'text' : 'password';
        senhaInput.attr('type', tipo);
    });
});
