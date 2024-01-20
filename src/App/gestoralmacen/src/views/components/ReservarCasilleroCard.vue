<template>
    <div class="card h-100 col-10 m-auto mb-4">
        <div class="p-3 card-body">
            <div class="list-group">
                <div class="row mb-2 border-0">
                    <div class="col">
                        <soft-input
                            :value="id_casilleros"
                            id="uuids"
                            type="text"
                            placeholder="&Iacute;ndices de casillas"
                            name="uuids"
                            textAlign="center"
                            isReadonly="true"
                        ></soft-input>
                    </div>   
                </div>
                <div class="row mb-2 border-0">
                    <div class="col">
                        <h6 class="mb-0 text-sm text-center">Dimensiones</h6>

                        <div class="align-items-center justify-content-center">
                            <div class="d-flex">
                                <span class="me-2 text-xs font-weight-bold">{{ dimension_porcentage }}%</span>
                                <span class="me-2 text-xs font-weight-bold mx-auto"></span>
                                <span class="me-2 text-xs font-weight-bold"> {{ dimension_ocupado }} / {{ dimension_total }} m<sup>3</sup></span>
                            </div>
                            <soft-progress
                                color="info"
                                variant="gradient"
                                :percentage="dimension_porcentage"
                            />
                        </div>
                    </div>    
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm text-center">Peso</h6>
                        
                        <div class="align-items-center justify-content-center">
                            <div class="d-flex">
                                <span class="me-2 text-xs font-weight-bold">{{ peso_porcentage }}%</span>
                                <span class="me-2 text-xs font-weight-bold mx-auto"></span>
                                <span class="me-2 text-xs font-weight-bold">{{ peso_ocupado }} / {{ peso_total }}</span>
                            </div>
                            <soft-progress
                                color="info"
                                variant="gradient"
                                :percentage="peso_porcentage"
                            />
                        </div>
                    </div>  
                
                </div>
                <div class="row mb-2 border-0">
                    <inventory-casillero-table
                        table_title="Productos en Espera"
                        state_wait="true"
                        :products="productos_wait"

                        @add-product="addProducto"
                        @remove-product="removeProducto"
                    >
                    </inventory-casillero-table>
                </div>
            </div>
            
            <soft-alert v-if="error_msg != ''" class="font-weight-light" color="danger" dismissible>
                <span class="text-sm">{{ error_msg }}</span>
            </soft-alert>

            <div class="text-center">
                <soft-button @click.prevent="reservarProductos">Guardar</soft-button>
                <span>&nbsp;&nbsp;</span>
                <soft-button color="danger" @click="$emit('casillero-cancel-edit')">Cancelar</soft-button>
            </div>
        </div>
    </div>
</template>

<script>
import SoftInput from "@/components/SoftInput.vue";
import SoftButton from "@/components/SoftButton.vue";
import SoftAlert from "@/components/SoftAlert.vue";
import SoftProgress from "@/components/SoftProgress.vue";
import InventoryCasilleroTable from "./InventoryCasilleroTable.vue";
import { cabeDentroConOrientacionYCantidad } from "@/store/transactions_validation";
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    name: "reservar-casillero-card",
    props: {
        casilleros_params: {
            type: Array,
            required: true
        },
        id_casilleros: {
            type: Array
        },
        change_selection: {
            type: Boolean,
            default: false
        }
    },
    components: {
        SoftAlert,
        SoftButton,
        SoftProgress,
        SoftInput,
        InventoryCasilleroTable
    },
    data() {
        return {
            dimension_restante: 0,
            peso_restante: 0,
            error_msg: '',
            
            productos_wait: [],
            casilleros: []
        };
    },
    mounted() {
        this.getWaitCasillero();
        this.casilleros = this.casilleros_params.map(casilla => this.insertCasillero(casilla));
    },
    computed: {
        dimension_total() {
            let volumen = 0;

            this.casilleros.forEach(casillero => {
                volumen += casillero.volumenEnMetrosCubicos();
            });

            return volumen;
        },

        dimension_ocupado() {
            let volumen = 0;

            this.casilleros.forEach(casillero => {
                volumen += casillero.volumenOcupadoEnMetrosCubicos();
            });

            return volumen;
        },

        dimension_porcentage() {
            if (this.dimension_total <= 0) {
                return 0;
            }

            return (this.dimension_ocupado * 100) / this.dimension_total;
        },
        
        peso_total() {
            let peso = 0;

            this.casilleros.forEach(c => {
                peso += c.peso_Maximo;
            });

            return peso;
        },

        peso_ocupado() {
            let peso = 0;

            this.casilleros.forEach(c => {
                peso += c.pesoOcupadoTotal();
            });

            return peso;
        },

        peso_porcentage() {
            if (this.peso_total <= 0) {
                return 0;
            }

            return (this.peso_ocupado * 100) / this.peso_total;
        },
    },
    watch: {
        change_selection: async function () {

            // Crear un mapa con los IDs de los nuevos casilleros para un acceso rápido
            const newCasillerosMap = new Map(this.casilleros_params.map(casillero => [casillero.id, casillero]));

            // Elimina los productos que contiene las casillas que se van a borrar
            this.casilleros.forEach(casillero => {
                if (!newCasillerosMap.has(casillero.iD_Casillero)) {
                    
                    for (let i = 0; i < casillero.productos.length; i++) {
                        let product = casillero.productos[i];
                        
                        this.removeProducto(product, product.quantity);
                    }
                }
            });

            // Filtrar los casilleros existentes para eliminar los que ya no están en casilleros_params
            this.casilleros = this.casilleros.filter(casillero => newCasillerosMap.has(casillero.iD_Casillero));

            // Agregar o actualizar casilleros de casilleros_params
            this.casilleros_params.forEach(casilleroParam => {
                const existingCasillero = this.casilleros.find(casillero => casillero.iD_Casillero === casilleroParam.iD_Casillero);

                if (!existingCasillero) {
                    // Agregar el nuevo casillero a la lista de casilleros
                    this.casilleros.push(this.insertCasillero(casilleroParam));
                }
            });
        }
    },
    methods: {
        addProducto(product, quantity)
        {
            let product_copy = product;
            product_copy.quantity = quantity;

            let result = cabeDentroConOrientacionYCantidad(product_copy, this.casilleros);

            if (!result.Ok) {
                this.error_msg = "El producto no cabe en las casillas señaladas";
                return;
            }

            result.Changes.forEach(index => {
                this.casilleros[index].productos.push(product);
            });
        },
        
        removeProducto(product, quantity)
        {
            let product_copy = product;
            product_copy.quantity = quantity;

            this.casilleros.forEach(casillero => {
                let index = -1;

                casillero.productos.forEach((p, i) => {
                    if (product['iD_Ubicacion'] == p['iD_Ubicacion']) {
                        index = i;
                    }

                    if (i != -1) {
                        casillero.productos.splice(index, 1);
                    }
                });
            });
        },

        insertCasillero(casilla) {
            return {
                ...casilla,
                productos: [],

                volumenEnMetrosCubicos() {
                    let factorConversion;
                    switch (this.unidad_Medida) {
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
                },

                volumenRestante() {
                    return this.volumenEnMetrosCubicos() - this.volumenOcupado();
                },

                volumenOcupadoEnMetrosCubicos() {
                    let volumenOcupado = 0;

                    
                    this.productos.forEach(product => {
                        volumenOcupado += product.volumenEnMetrosCubicos() * product.quantity;
                    });

                    return volumenOcupado;
                },

                pesoOcupadoTotal() {
                    let peso_total = 0;
                    
                    this.productos.forEach(product => {
                        peso_total += product.peso * product.quantity;
                    });

                    return peso_total;
                },

                pesoRestante() {
                    return this.peso - this.pesoOcupadoTotal();
                }

            };
        },

        async getWaitCasillero() {
            axios.get(`${API_URL}/product/wait`)
                .then(res => {
                    this.productos_wait = res.data.value['ubicaciones'].map(product => ({
                        ...product,
                        selected: false,
                        quantity: 0,

                        volumenEnMetrosCubicos() {
                            let factorConversion;
                            switch (this.unidad_Dimensions) {
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
                    }));
                })
                .catch(error => {
                    if (error.response && error.response.data) {
                        this.error_msg = error.response.data.title;
                    } else {
                        this.error_msg = error.message;
                    }
                });
        },
        
        async reservarProductos() {
            this.casilleros.forEach(casillero => {

                for (const p of casillero.productos) {

                    axios.post(`${API_URL}/product/transaction/move`,{
                        Ubicacion: p.iD_Ubicacion,
                        ID_Casillero_New: casillero.iD_Casillero,
                        Cantidad: p.quantity
                    })
                    .then(res => {
                        res;
                        this.$emit('emit-product-reserve');
                    })
                    .catch(error => {
                        if (error.response && error.response.data) {
                            this.error_msg = error.response.data.title;
                        } else {
                            this.error_msg = error.message;
                        }
                    });
                }
            });

            this.getWaitCasillero();
        },
    }
};
</script>