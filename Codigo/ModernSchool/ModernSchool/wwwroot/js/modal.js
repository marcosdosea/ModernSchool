$(document).ready(function () {
    $('.open-modal').click(function () {
        var idAluno = $(this).attr('data-Id'); // Obter o ID do aluno do atributo data-asp-route-Id
        var idTurma = $(this).attr('data-idTurma'); // Obter o ID da turma do atributo data-asp-route-idTurma

        // Faz uma requisição AJAX para buscar as informações do aluno
        $.ajax({
            url: 'Details/' + idAluno + '?idTurma=' + idTurma,
            type: 'GET',
            success: function (data) {
                // Insira as informações do aluno no corpo do modal
                $('#infoAluno').html($(data));
            },
            error: function () {
                console.log('Erro ao carregar informações do aluno.');
            }
        });
    });
});

$(document).ready(function () {
    $('.open-modal-comunicado').click(function () {
        var mensagem = $(this).data('mensagem'); // Obtém a mensagem do atributo data-mensagem do botão

        // Insere a mensagem no corpo do modal
        $('#mensagemModal').text(mensagem).addClass('fs-6');
    });
});