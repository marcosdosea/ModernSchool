﻿function openModal(idAluno, idTurma) {
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


function exibirMensagemNoModal(mensagem) {
    var msg = $('#mensagemModal').text(mensagem).addClass('fs-6');
}



function showConfirmationModal(formId, view, idModal, nome) {
    var modal = document.getElementById(idModal);
    var modalForm = modal.querySelector('form');
    var artigo;
    if (view == 'Turma') {
        artigo = 'a';
    } else {
        artigo = 'o';
    }
    view = removerAcentos(view);
    modalForm.action = '/' + view + '/Delete/' + formId; // Define a ação do formulário com a rota correta
    var modalBody = modal.querySelector('.modal-body');
    var modalH5 = modal.querySelector('h5');
    modalH5.innerHTML = 'Confirmar Exclusão do ' + view;
    modalBody.innerHTML = 'Deseja <b>Excluir</b> '+ artigo + ' ' + view + ' <b>' + nome + '</b>?'; // Conteúdo do modal

    // Exibe o modal
    var modal = new bootstrap.Modal(modal);
    modal.show();
}

function showModalGradeHorario(idGrade, idTurma, nome, componente) {
    var modal = document.getElementById('gradeHorarioProf');
    var modalForm = modal.querySelector('form');
    modalForm.action = '/GradeHorario/Delete/' + idGrade + '?idTurma=' + idTurma // Define a ação do formulário com a rota correta
    var modalBody = modal.querySelector('.modal-body');
    modalBody.innerHTML = 'Deseja <b>Excluir</b> a Grade Horário de <b>' + nome + '</b> do compoente <b>' + componente + ' </b>?'; // Conteúdo do modal

    // Exibe o modal
    var modal = new bootstrap.Modal(modal);
    modal.show();
}

function showModalCancelarAluno(idAluno, idTurma, nomeTurma) {
    var modal = document.getElementById('alunoTurma');
    var modalForm = modal.querySelector('form');
    modalForm.action = '/Pessoa/Delete/' + idAluno + '?idTurma=' + idTurma; // Define a ação do formulário com a rota correta
    var modalBody = modal.querySelector('.modal-body');
    modalBody.innerHTML = 'Deseja <b>Desvincular</b> o Aluno(a) da Turma: <b>' + nomeTurma + '</b>?'; // Conteúdo do modal
    // Exibe o modal
    var modal = new bootstrap.Modal(modal);
    modal.show();
}
function removerAcentos(texto) {
    return texto.normalize("NFD").replace(/[\u0300-\u036f]/g, "");
}

function showConfirmationModalDiario(idObjeto, idDiario, idTabela, uniTematica) {
    var modal = document.getElementById(idTabela);
    var modalForm = modal.querySelector('form');
    modalForm.action = '/Professor/DeleteDiarioClasse/?IdDiario=' + idDiario + '&IdObjeto=' + idObjeto;
    var modalBody = modal.querySelector('.modal-body');
    var modalH5 = modal.querySelector('h5');
    modalH5.innerHTML = 'Excluir Diário de Classe'
    modalBody.innerHTML = 'Deseja <b>Excluir</b> o Diário de Classe da unidade Temática: <b>' + uniTematica + '</b>?'; // Conteúdo do modal

    // Exibe o modal
    var modal = new bootstrap.Modal(modal);
    modal.show();
}

function showConfirmationModalAvaliacao(idavaliacao, idTabela, componente, data, idTurma, idComponente) {
    var modal = document.getElementById(idTabela);
    var modalForm = modal.querySelector('form');
    modalForm.action = '/Avaliacao/Delete/' + idavaliacao + '?idTurma=' + idTurma + '&idComponente=' + idComponente;
    var modalBody = modal.querySelector('.modal-body');
    modalBody.innerHTML = 'Deseja <b>Excluir</b> a Avaliação de <b>' + componente + '</b> marcada para a Data: <b>' + formatarData(data) + '</b> com Horário de entrega: <b>' + data.substring(11, 16) + '</b>?';

    // Exibe o modal
    var modal = new bootstrap.Modal(modal);
    modal.show();
}
function formatarData(data) {
    var dia = data.substring(0, 2);
    var mes = data.substring(3, 5);
    var ano = data.substring(6, 10);

    return dia + '/' + mes + '/' + ano;
}
