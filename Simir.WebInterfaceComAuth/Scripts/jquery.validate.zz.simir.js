

function validarCNPJ(cnpj) {

    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj == '') return false;

    if (cnpj.length != 14)
        return false;

    // LINHA 10 - Elimina CNPJs invalidos conhecidos
    if (cnpj == "00000000000000" ||
        cnpj == "11111111111111" ||
        cnpj == "22222222222222" ||
        cnpj == "33333333333333" ||
        cnpj == "44444444444444" ||
        cnpj == "55555555555555" ||
        cnpj == "66666666666666" ||
        cnpj == "77777777777777" ||
        cnpj == "88888888888888" ||
        cnpj == "99999999999999")
        return false; // LINHA 21

    // Valida DVs LINHA 23 -
    tamanho = cnpj.length - 2
    numeros = cnpj.substring(0, tamanho);
    digitos = cnpj.substring(tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(0))
        return false;

    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(1))
        return false; // LINHA 49

    return true; // LINHA 51

}

$.validator.addMethod("customvalidationcnpj", function (value, element, param) {

    return validarCNPJ(value); //chama um método validaCPF implementado em javascript
});

jQuery.validator.unobtrusive.adapters.addBool('customvalidationcnpj');

$.validator.unobtrusive.adapters.add('dynamicrange', ['minvalueproperty', 'maxvalueproperty'],
        function (options) {
            options.rules['dynamicrange'] = options.params;
            if (options.message != null) {
                $.validator.messages.dynamicrange = options.message;
            }
        }
    );

$.validator.addMethod('dynamicrange', function (value, element, params) {
    var minValue = parseInt($('input[name="' + params.minvalueproperty + '"]').val(), 10);
    var maxValue = parseInt($('input[name="' + params.maxvalueproperty + '"]').val(), 10);
    var currentValue = parseInt(value, 10);
    if (isNaN(minValue) || isNaN(maxValue) || isNaN(currentValue) || minValue >= currentValue || currentValue >= maxValue) {
        var message = $(element).attr('data-val-dynamicrange');
        $.validator.messages.dynamicrange = $.format(message, minValue, maxValue);
        return false;
    }
    return true;
}, '');



$.validator.unobtrusive.adapters.add('maximo', ['maxvalueproperty', 'restovalueproperty'],
        function (options) {
            options.rules['maximo'] = options.params;
            if (options.message != null) {
                $.validator.messages.maximo = options.message;
            }
        }
    );

$.validator.addMethod('maximo', function (value, element, params) {
    var restoValue = parseInt($('input[name="' + params.restovalueproperty + '"]').val(), 10);
    var maxValue = parseInt($('input[name="' + params.maxvalueproperty + '"]').val(), 10);
    var currentValue = parseInt(value, 10);
    if (isNaN(restoValue)) {
        restoValue = 0;
    }

    if (isNaN(maxValue) || isNaN(currentValue) || restoValue + currentValue > maxValue) {
        
        var message = $(element).attr('data-val-maximo');
        $.validator.messages.maximo = $.format(message, restoValue, maxValue);
        return false;
    }
    return true;
}, '');