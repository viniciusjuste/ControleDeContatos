$(document).ready(function () {
    $('.close-alert').click(function () {
        $('.alert').hide('hide');
    });

    getDataTable('#table-contatos');
    getDataTable('#table-usuarios');

    $('.btn-total-contatos').click(function () {
        var usuarioId = $(this).attr('usuario-Id');

        $.ajax({
            type:'GET',
            url: '/Usuario/ListarContatosPorUsuarioId/' + usuarioId,
            success: function (result) {
                $('#listaContatoUsuario').html(result);
                $('#modalContatosUsuario').modal('show'); // Abre o modal
                getDataTable('#table-contatos-usuario');
            }
        });

        console.log(usuarioId); // Verifica se o ID do usuário está sendo capturado corretamente

    });
   
        // Adiciona um evento de clique ao botão de fechar
        $('.close').click(function () {
            fecharModal(); // Chama a função para fechar o modal
        });

  
});
function getDataTable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "language": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}
function fecharModal() {
        $('#modalContatosUsuario').modal('hide');
    }