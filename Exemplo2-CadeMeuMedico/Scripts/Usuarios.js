$(document).ready(function () {
    $("#status").hide();
    $("#btnEntrar").click(function () {
        $.ajax({
            url: "/Usuarios/AutenticacaoDeUsuario",
            data: { Login: $("#usuario").val(), Senha: $("#password").val() },
            dataType: "json",
            type: "GET",
            async: true,
            beforeSend: function () {
                $("#status").html("<img src='/Content/Imagens/ajax-loader.gif' border='0' />&nbsp;Estamos autenticando o usuário. Só um instante...");
                $("#status").show();
            },
            success: function (dados) {
                if (dados.OK) {
                    $("#status").html(dados.Mensagem)
                    setTimeout(function () { window.location.href = "/Sistema/Index" }, 5000);
                    $("#status").show();
                }
                else {
                    $("#status").html(dados.Mensagem);
                    $("#status").show();
                }
            },
            error: function () {
                $("#status").html(dados.Mensagem);
                $("#status").show()
            }
        });
    });
});