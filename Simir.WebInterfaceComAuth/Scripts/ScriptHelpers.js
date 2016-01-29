

$('input', '.umahora').keyup(function () {
    var edit = this;
    if (event.keyCode < 48 || event.keyCode > 57) {
        event.returnValue = false;
    }

    if (edit.value.length == 2) {
        if (edit.value >= 24) {
            edit.value = "23:";
        }
        else {
            edit.value += ":";
        }
    }
    else if (edit.value.length == 4) {
        var str = edit.value.charAt(3);
        if (str > 5) {
            edit.value = edit.value.substring(0, (edit.value.length - 1));
            edit.value += "5";
        }
    }
});


function addErros(name, data) {
    var str = "<ul>";
    if (typeof data === 'string') {
        //alert('é string: ' + data);
        data = [{ ErrorMessage: data }];
    }
    for (var i = 0; i < data.length; i++) {
        if (data[i].ErrorMessage != null) {
            str += "<li>" + data[i].ErrorMessage + "</li>";
        } else {
            str += "<li> Erro não identificado </li>";
        }
    }
    str += "</ul>";

    $("span[data-valmsg-for='" + name + "']").html(str);
}



function buscaCnpj(ele, razaosocialID) {
    var cnpj = $(ele).parent().parent().find("input.form-control").val();
    var id = $(ele).parent().parent().find("input.form-control").attr('name');
    //addErros(id, [{ ErrorMessage: "asdasdasd" }, { ErrorMessage: "asdasdasiqiwjeijqd" }])
    // $("span[data-valmsg-for='" + id + "']").text("erro interno, tente novamente mais tarde");
    razaosocialID = "." + razaosocialID;

    var url = "http://localhost:64548/Cadastros/Empresa/GetEmpresaByCnpj?cnpj=" + cnpj;
    console.log(url);
    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'json',
        cache: false,
        async: false,
        success: function (data) {
            console.log(data);
            if (data.Success) {
                $("span[data-valmsg-for='" + id + "']").html(' ');
                data = data.Dado;
                $('input[type="text"]', razaosocialID).val(data.RazaoSocial);
                $('input[type="text"]', razaosocialID).prop("disabled", true);
                $(razaosocialID).show();

            } else {
                var erros = data.ErrorMessage;
                addErros(id, erros);

                console.log(erros);

                for (var i = 0; i < erros.length; i++) {

                    if (erros[i].ErrorMessage == "CNPJ não encontrado. Preencha os campos manualmente.") {
                        $('input', razaosocialID).prop("disabled", false);
                        $(razaosocialID).show();
                        break;
                    } else {
                        $(razaosocialID).hide();
                    }
                }
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            addErros(id, [{ ErrorMessage: "erro interno, tente novamente mais tarde." }]);
        }
    });
}


$refresh = [];

function refreshDDL(element, urlFunc, pai) {

    var hiddenFor = $(element).next();

    var valorAtual = hiddenFor.val();

    if (pai != "nulo") {

        var Cadeia = pai.split(' ');

        for (i = 0; i < Cadeia.length; i++) {

            var id = $("select." + Cadeia[i]).next().val();
            if (typeof (id) === "undefined") {
                id = $("#" + Cadeia[i]).val();
            }
            if (i == 0) {
                urlFunc = urlFunc + '?id=' + id;
            }
            else {
                urlFunc = urlFunc + '&id' + i + '=' + id;
            }
        }
    }



    '5&Parametro01=3&idRegiaoAdministrativa=5'

    if (valorAtual == -10) {
        $refresh[urlFunc] = 4;
    }
    if (valorAtual == -1) {
        $refresh[urlFunc] = 9;
    }
    if (typeof ($refresh[urlFunc]) === "undefined") {

        $refresh[urlFunc] = 1;

    }

    if ($refresh[urlFunc] != 7) {
        $refresh[urlFunc] = 2;
        $.ajax({
            type: 'GET',
            url: urlFunc,//'/Cadastros/Localidade/GetMunicipiosByUf/' + valor,
            dataType: 'json',
            cache: false,
            async: false,
            success: function (data) {
                $refresh[urlFunc] = 7;
                var items = ' ';
                console.log(data);
                $.each(data, function (i, retorno) {
                    if (valorAtual == retorno[0]) {
                        items += "<option value='" + retorno[0] + "' title='" + retorno[2] + "' selected>" + retorno[1] + "</option>";
                    } else {
                        items += "<option value='" + retorno[0] + "' title='" + retorno[2] + "' >" + retorno[1] + "</option>";
                    }
                });
                element.innerHTML = items;
                changeDDL(element, $(element).attr("simir-ddl-filho"))
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $refresh[urlFunc] = 3;
                alert("Erro detectado: " + thrownError);
            }
        });
    }
    return;
}

function changeDDL(element, dependentes) {
    //changeGeneric(this,'div.residuo','input.subcapituloid','/Cadastros/ResiduoSolido/GetDetalheBySubcapitulo/','select.ddlDetalhe')


    //var hiddenFor = $(element).parent().find("input.hiddenFor");
    //$hiddenFor = $(element).next();


    var valorAtual = $(element).val();
    var descracaoAtual = $(element).find(":selected").text();



    $(element).next().next().val(descracaoAtual);
    if ($(element).next().val() == valorAtual) {
        return;
    }
    $(element).next().val(valorAtual);
    //hiddenFor.val(valorAtual);



    if (dependentes == "nulo") {
        //alert("dependente é nulo");
        return;
    }

    var selPedente = $("select." + dependentes)
    $(selPedente).html("<option value='-10'> Selecione uma opção... </option>");

    changeDDL(selPedente, $(selPedente).attr("simir-ddl-filho"));

    //$selPedente.parent().find("input.hiddenFor").val('-1');

    //alert($selPedente.html());
    //valor.innerHTML = items;
    //alert(dependentes);

    return;
}
function zeraDDL(element) {



}


function inicia() {
    var ddls = $("select.simir-ddl");

    $.each(ddls, function (key, value) {
        //console.log(value);
        //console.log($(value).attr("simir-ddl-url"));
        $(value).hover(function () { refreshDDL(value, $(value).attr("simir-ddl-url"), $(value).attr("simir-ddl-pai")) });
        $(value).change(function () { changeDDL(value, $(value).attr("simir-ddl-filho")) });
    });

    var bCnpj = $("button.buscaCnpj");

    $.each(bCnpj, function (key, value) {
        //console.log(value);
        //console.log($(value).attr("simir-ddl-url"));
        $(value).click(function () { buscaCnpj(value, $(value).attr("simir-razaosocial")) });
    });
    //onchange="changeDDL(this, 'LocalidadeBairroValor'); return;"
    //$("select.simir-ddl").click(refreshDDL(this, '/Cadastros/Endereco/GetMunicipiosByUf/', 'LocalidadeUfValor'))


    $('#main-menu').metisMenu();
}




$('.tooltip2').jBox('Tooltip', { pointer: 'center:-100' });

$('.umadata input').datepicker({
    format: "dd/mm/yyyy",
    language: "pt-BR",
    orientation: "top auto",
    autoclose: true
});


$('.ummes input').datepicker({
    format: "mm/yyyy",
    minViewMode: 1,
    language: "pt-BR",
    orientation: "top auto",
    autoclose: true
});

new jBox('Confirm', {

    confirmButton: 'Confirmo!',
    cancelButton: 'Cancelar'
});


/*
$.desabilitaValidacao = function () {
    $("[data-val='true']").attr('data-val', 'false');

    //Reset validation message
    $('.field-validation-error')
    .removeClass('field-validation-error')
    .addClass('field-validation-valid');

    //Reset input, select and textarea style
    $('.input-validation-error')
    .removeClass('input-validation-error')
    .addClass('valid');

    //Reset validation summary
    $(".validation-summary-errors")
    .removeClass("validation-summary-errors")
    .addClass("validation-summary-valid");

    //To reenable lazy validation (no validation until you submit the form)
    $('form').removeData('unobtrusiveValidation');
    $('form').removeData('validator');
    $.validator.unobtrusive.parse($('form'));
}*/



$(window).load(inicia());

