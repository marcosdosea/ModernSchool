function openModal(idAluno, idTurma) {
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
}


$(document).ready(function () {
    $('.open-modal-comunicado').click(function () {
        var mensagem = $(this).data('mensagem'); // Obtém a mensagem do atributo data-mensagem do botão

        // Insere a mensagem no corpo do modal
        $('#mensagemModal').text(mensagem).addClass('fs-6');
    });
});

function showConfirmationModal(formId, view, idModal, nome) {
    var modal = document.getElementById(idModal);
    var modalForm = modal.querySelector('form');
    modalForm.action = '/' + view + '/Delete/' + formId; // Define a ação do formulário com a rota correta
    var modalBody = modal.querySelector('.modal-body');
    var modalH5 = modal.querySelector('h5');
    modalH5.innerHTML = 'Confirmar Exclusão do ' + view;
    modalBody.innerHTML = 'Deseja <b>Excluir</b> o ' + view + ' <b>' + nome + '</b>?'; // Conteúdo do modal

    // Exibe o modal
    var modal = new bootstrap.Modal(modal);
    modal.show();
}

function showModalCancelarAluno(idAluno, idTurma) {
    var modal = document.getElementById('alunoTurma');
    var modalForm = modal.querySelector('form');
    modalForm.action = '/Pessoa/Delete/' + idAluno + '?idTurma=' + idTurma; // Define a ação do formulário com a rota correta
    var modalBody = modal.querySelector('.modal-body');
    modalBody.innerHTML = 'Deseja <b>Cancelar</b> o Aluno(a) <b> </b>?'; // Conteúdo do modal
    // Exibe o modal
    var modal = new bootstrap.Modal(modal);
    modal.show();
}