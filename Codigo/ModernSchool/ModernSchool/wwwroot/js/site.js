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
                    $('#nome').val(aluno.nome = capitalizarPrimeirasLetras(aluno.nome));
                    $('#dataNascimento').val(aluno.dataNascimento.substring(0, 10));
                    $('#cep').val(aluno.cep);
                    $('#rua').val(aluno.rua);
                    $('#bairro').val(aluno.bairro);
                    $('#numero').val(aluno.numero);
                    $('#email').val(aluno.email);
                    $('#idAluno').val(aluno.id);
                } else {
                    // Limpar os campos do formulário
                    $('#nome').val('');
                    $('#dataNascimento').val('');
                    $('#cep').val('');
                    $('#rua').val('');
                    $('#bairro').val('');
                    $('#numero').val('');
                    $('#email').val('');
                    $('#idAluno').val('');
                }
            },
        });
    });
    function capitalizarPrimeirasLetras(texto) {
        return texto.toLowerCase().replace(/(?:^|\s)\S/g, function (a) { return a.toUpperCase(); });
    }
});
