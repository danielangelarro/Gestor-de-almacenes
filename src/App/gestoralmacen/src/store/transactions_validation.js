export class Objeto {
    constructor(largo, alto, ancho, unidadMedida) {
        this.largo = largo;
        this.alto = alto;
        this.ancho = ancho;
        this.unidadMedida = unidadMedida;
    }

    volumenEnMetrosCubicos() {
        let factorConversion;
        switch (this.unidadMedida) {
            case 'cm':
                factorConversion = 0.01;
                break;
            case 'ft':
                factorConversion = 0.3048;
                break;
            case 'm':
            default:
                factorConversion = 1;
                break;
        }
        return this.largo * factorConversion * this.alto * factorConversion * this.ancho * factorConversion;
    }
}

export function cabeDentroConOrientacionYCantidad(product, listaB) {

    let cabeEnAlgunCasillero = false;
    let indexCasillero = [];

    for (let b of listaB) {
        if (b.pesoRestante() < product.peso) {
            continue;
        }

        let volumenB = b.volumenEnMetrosCubicos();
        let cabenTodos = true;

        // Verificar si el objeto A cabe en el casillero B
        for (let i = 0; i < product.quantity; i++) {

            if (cabeDentroConOrientacion(product, b) && volumenB >= product.volumenEnMetrosCubicos()) {
                volumenB -= product.volumenEnMetrosCubicos();
                indexCasillero.push(i);
            } else {
                cabenTodos = false;
                break; // No cabe en este casillero, intentar con el siguiente
            }
        }

        if (cabenTodos) {
            cabeEnAlgunCasillero = true;
            b.productos.push(product); // Actualizar el volumen restante del casillero
            break; // No es necesario buscar en más casilleros
        }
    }

    if (!cabeEnAlgunCasillero) {
        return {Ok: false, Changes: null};
    }

    return {Ok: true, Changes: indexCasillero};
}

function cabeDentroConOrientacion(a, b) {
    // Convertir las dimensiones a metros
    let dimensionesA = [a.largo, a.alto, a.ancho];
    let dimensionesB = [b.largo, b.alto, b.ancho];

    for (let i = 0; i < 3; i++) {
        dimensionesA[i] *= factorConversion(a.unidadMedida);
        dimensionesB[i] *= factorConversion(b.unidadMedida);
    }

    // Ordenar las dimensiones de menor a mayor
    dimensionesA.sort((a, b) => a - b);
    dimensionesB.sort((a, b) => a - b);

    // Verificar si cada dimensión de a cabe dentro de la dimensión correspondiente de b
    for (let i = 0; i < 3; i++) {
        if (dimensionesA[i] > dimensionesB[i]) {
            return false;
        }
    }

    return true;
}

function factorConversion(unidadMedida) {
    switch (unidadMedida) {
        case 'cm':
            return 0.01;
        case 'ft':
            return 0.3048;
        case 'm':
        default:
            return 1;
    }
}
