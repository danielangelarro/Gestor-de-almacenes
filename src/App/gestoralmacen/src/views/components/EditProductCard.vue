<template>
    <div class="card h-100 col-5 m-auto mb-4">
        <div class="p-3 card-body">
            <div class="list-group">
                <div class="row mb-2 border-0">
                    <div class="col">
                        <soft-input
                            :value="params.iD_Producto"
                            id="uuid"
                            type="text"
                            name="uuid"
                            textAlign="center"
                            isReadonly="true"
                        ></soft-input>
                    </div>
                </div>

                <div class="row mb-2 border-0">
                    <div class="col">
                        <h6 class="mb-0 text-sm">Nombre</h6>
                        <soft-input
                            :value="params.nombre"
                            @input="event => params.nombre = event.target.value"
                            id="nombre"
                            type="text"
                            placeholder="Nombre"
                            name="nombre"
                            rows="3"
                        ></soft-input>
                    </div>
                </div>

                <div class="row mb-2 border-0">
                    <div class="col">
                        <h6 class="mb-0 text-sm">Descripci&oacute;n</h6>
                        <soft-textarea
                            :value="params.descripcion"
                            @input="event => params.descripcion = event.target.value"
                            rows="3"
                            id="descripcion"
                            type="text"
                            placeholder="Descripci&oacute;n"
                            name="descripcion"
                        ></soft-textarea>
                    </div>
                </div>
                
                <div class="row mb-2 border-0">
                    <div class="col">
                        <h6 class="mb-0 text-sm">Tipo</h6>
                        <soft-input
                            :value="params.tipo"
                            @input="event => params.tipo = event.target.value"
                            id="tipo"
                            type="text"
                            name="Tipo"
                        ></soft-input>
                    </div>
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm">Precio de Compra</h6>
                        <soft-input
                            :value="params.precio_Entrada"
                            @input="event => params.precio_Entrada = event.target.value"
                            id="precio_Entrada"
                            type="number"
                            name="precio_Entrada"
                        ></soft-input>
                    </div>
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm">Precio de Venta</h6>
                        <soft-input
                            :value="params.precio_Salida"
                            @input="event => params.precio_Salida = event.target.value"
                            id="precio_Salida"
                            type="number"
                            name="precio_Salida"
                        ></soft-input>
                    </div>
                </div>
                <div class="row mb-2 border-0">
                    <div class="col">
                        <h6 class="mb-0 text-sm">Alto</h6>
                        <soft-input
                            :value="params.alto"
                            @input="event => params.alto = event.target.value"
                            id="alto"
                            type="number"
                            placeholder="Alto"
                            name="alto"
                        ></soft-input>
                    </div>    
                
                    <div class="col">
                        <h6 class="mb-0 text-sm">Largo</h6>
                        <soft-input
                            :value="params.largo"
                            @input="event => params.largo = event.target.value"
                            id="largo"
                            type="number"
                            placeholder="Largo"
                            name="largo"
                        ></soft-input>
                    </div>  
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm">Ancho</h6>
                        <soft-input
                            :value="params.ancho"
                            @input="event => params.ancho = event.target.value"
                            id="ancho"
                            type="number"
                            placeholder="ancho"
                            name="ancho"
                        ></soft-input>
                    </div>

                    <div class="col">
                        <h6 class="mb-0 text-sm">Peso</h6>
                        <soft-input
                            :value="params.peso"
                            @input="event => params.peso = event.target.value"
                            id="peso"
                            type="number"
                            placeholder="peso"
                            name="peso"
                            rows="3"
                        ></soft-input>
                    </div>
                
                </div>
                <div class="row mb-2 border-0">
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm">Unidad Dimensiones</h6>
                        <select v-model="params.unidad_Dimensiones">
                            <option disabled value="">Seleccione una unidad de medida</option>
                            <option>cm</option>
                            <option>m</option>
                            <option>ft</option>
                        </select>
                    </div>
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm">En Almac&eacute;n</h6>
                        <soft-switch
                            :checked="params.enAlmacen"
                            @change="event => params.enAlmacen = event.target.checked"
                            id="unidad_Dimensiones"
                            name="unidad_Dimensiones"
                            label-class="mb-0 text-body ms-3 text-truncate w-80"
                            class="ps-0 ms-auto"
                        ></soft-switch>
                    </div>    
                </div>
            </div>
            
            <soft-alert v-if="error_msg != ''" class="font-weight-light" color="danger" dismissible>
                <span class="text-sm">{{ error_msg }}</span>
            </soft-alert>

            <soft-button @click="editProducts">Guardar</soft-button>
            <span>&nbsp;&nbsp;</span>
            <soft-button color="danger" @click="$emit('product-cancel-edit')">Cancelar</soft-button>
        </div>
    </div>
</template>

<script>
import SoftButton from "@/components/SoftButton.vue";
import SoftInput from "@/components/SoftInput.vue";
import SoftTextarea from "@/components/SoftTextarea.vue";
import SoftAlert from "@/components/SoftAlert.vue";
import SoftSwitch from "@/components/SoftSwitch.vue";
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    name: "edit-product-card",
    props: {
        show: {
            type: Boolean,
            default: false
        },
        product_params: {
            type: Object,
            required: true
        }
    },
    components: {
        SoftAlert,
        SoftButton,
        SoftInput,
        SoftTextarea,
        SoftSwitch
    },
    data() {
        return {
            params: this.product_params,
            error_msg: ''
        };
    },
    methods: {
        async editProducts() {
            axios.put(`${API_URL}/product`, this.params)
                .then(res => {
                    res;
                    this.params.nombre = "";
                    this.params.descripcion = "";
                    this.params.tipo = "";
                    this.params.alto = 0;
                    this.params.ancho = 0;
                    this.params.largo = 0;
                    this.params.unidad_Dimensiones = "";
                    this.params.peso = 0;
                    this.params.precio_Entrada = 0;
                    this.params.precio_Salida = 0;
                    this.params.enAlmacen = false;
                    
                    this.$emit('product-edited');
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