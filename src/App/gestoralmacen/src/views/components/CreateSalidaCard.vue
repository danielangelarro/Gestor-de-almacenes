<template>
    <div v-if="show_conditional" class="card h-100 col-5 m-auto mb-4">
        <div class="p-3 card-body">
            <div class="list-group">
                <div class="row mb-2 border-0">
                    <div class="col">
                        <h6 class="mb-0 text-sm">Producto</h6>
                        
                        <producto-input-sugerence
                            transaction="salida"
                            @input="productInput"
                        ></producto-input-sugerence>
                    </div>

                    <div class="col">
                        <h6 class="mb-0 text-sm">Precio Unidad</h6>
                        
                        <input
                            type="number"
                            class="form-control"
                            v-model="precio_Salida"
                        >
                    </div>
                </div>
                
                <div class="row mb-2 border-0">
                    <h6 class="mb-0 text-sm">Cliente</h6>
                    
                    <cliente-input-sugerence
                        @input="iD_Usuario = $event"
                    ></cliente-input-sugerence>
                </div>
                
                <div class="row mb-2 border-0">
                    <div class="col">
                        <h6 class="mb-0 text-sm">Cantidad</h6>
                        
                        <soft-input
                            type="number"
                            @input="cantidad = $event.target.value"
                        ></soft-input>
                    </div>
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm">Fecha de Salida</h6>

                        <soft-input
                            type="date"
                            @input="fecha = $event.target.value"
                        ></soft-input>
                    </div>
                    
                </div>

            </div>
            
            <soft-alert v-if="error_msg != ''" class="font-weight-light" color="danger" dismissible>
                <span class="text-sm">{{ error_msg }}</span>
            </soft-alert>

            <soft-button @click="addSalida">Guardar</soft-button>
            <span>&nbsp;&nbsp;</span>
            <soft-button color="danger" @click="show_conditional=false;">Cancelar</soft-button>
        </div>
    </div>
    <div v-else class="row mb-4">
        <div class="col-12">
          <soft-button @click="show_conditional=true">Agregar</soft-button>
        </div>
    </div>
</template>

<script>
import SoftButton from "@/components/SoftButton.vue";
import SoftInput from "@/components/SoftInput.vue";
import ProductoInputSugerence from "./ProductoInputSugerence.vue";
import ClienteInputSugerence from "./ClienteInputSugerence.vue";
import SoftAlert from "@/components/SoftAlert.vue";
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    name: "create-entrada-card",
    props: {
        show: {
            type: Boolean,
            default: false
        }
    },
    components: {
        SoftAlert,
        SoftButton,
        SoftInput,
        ProductoInputSugerence,
        ClienteInputSugerence
    },
    data() {
        return {
            iD_Producto: "",
            iD_Usuario: "",
            cantidad: 0,
            precio_Salida: 0,
            fecha: "",
            token: localStorage.getItem('user-token'),
            show_conditional: this.show,
            error_msg: ''
        };
    },
    methods: {

        productInput(value) {
            this.iD_Producto = value.value;
            this.precio_Salida = value.price;
        },

        async addSalida() {
            
            axios.post(`${API_URL}/entradaandsalida/salida/add`, {
                iD_Producto: this.iD_Producto,
                iD_Usuario: this.iD_Usuario,
                cantidad: this.cantidad,
                fecha: this.fecha,
                token: this.token,
            })
                .then(res => {
                    res;
                    this.iD_Producto = "";
                    this.iD_Usuario = "";
                    this.cantidad = 0;
                    this.fecha = "";
                    this.token = localStorage.getItem('user-token');
                    this.show_conditional = false;
                    
                    this.$emit('salida-added');
                })
                .catch(error => {
                    if (error.response && error.response.data) {
                        this.error_msg = error.response.data.title;
                    } else {
                        this.error_msg = error.message;
                    }
                });
        },
    }
};
</script>