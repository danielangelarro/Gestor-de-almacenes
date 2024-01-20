<template>
    <div v-if="show_conditional" class="card h-100 col-5 m-auto mb-4">
        <div class="p-3 card-body">
            <div class="list-group">
                <div class="row mb-2 border-0">
                    <div class="col">
                        <h6 class="mb-0 text-sm">Nombre</h6>
                        <soft-input
                            :value="nombre"
                            @input="event => nombre = event.target.value"
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
                            :value="descripcion"
                            @input="event => descripcion = event.target.value"
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
                            :value="tipo"
                            @input="event => tipo = event.target.value"
                            id="tipo"
                            type="text"
                            name="Tipo"
                        ></soft-input>
                    </div>
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm">Precio de Compra</h6>
                        <soft-input
                            :value="precio_entrada"
                            @input="event => precio_entrada = event.target.value"
                            id="precio_entrada"
                            type="number"
                            name="precio_entrada"
                        ></soft-input>
                    </div>
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm">Precio de Venta</h6>
                        <soft-input
                            :value="precio_salida"
                            @input="event => precio_salida = event.target.value"
                            id="precio_salida"
                            type="number"
                            name="precio_salida"
                        ></soft-input>
                    </div>
                </div>
                <div class="row mb-2 border-0">
                    <div class="col">
                        <h6 class="mb-0 text-sm">Alto</h6>
                        <soft-input
                            :value="alto"
                            @input="event => alto = event.target.value"
                            id="alto"
                            type="number"
                            placeholder="Alto"
                            name="alto"
                        ></soft-input>
                    </div>
                
                    <div class="col">
                        <h6 class="mb-0 text-sm">Largo</h6>
                        <soft-input
                            :value="largo"
                            @input="event => largo = event.target.value"
                            id="largo"
                            type="number"
                            placeholder="Largo"
                            name="largo"
                        ></soft-input>
                    </div>  
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm">Ancho</h6>
                        <soft-input
                            :value="ancho"
                            @input="event => ancho = event.target.value"
                            id="ancho"
                            type="number"
                            placeholder="ancho"
                            name="ancho"
                        ></soft-input>
                    </div>

                    <div class="col">
                        <h6 class="mb-0 text-sm">Peso</h6>
                        <soft-input
                            :value="peso"
                            @input="event => peso = event.target.value"
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
                        <select v-model="unidad_Dimensiones">
                            <option disabled value="">Seleccione una unidad de medida</option>
                            <option>cm</option>
                            <option>m</option>
                            <option>ft</option>
                        </select>
                    </div>    
                </div>
            </div>
            
            <soft-alert v-if="error_msg != ''" class="font-weight-light" color="danger" dismissible>
                <span class="text-sm">{{ error_msg }}</span>
            </soft-alert>

            <soft-button @click="addProducts">Guardar</soft-button>
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
import SoftTextarea from "@/components/SoftTextarea.vue";
import SoftAlert from "@/components/SoftAlert.vue";
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    name: "create-product-card",
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
        SoftTextarea
    },
    data() {
        return {
            nombre: "",
            descripcion: "",
            tipo: "",
            alto: 0,
            ancho: 0,
            largo: 0,
            unidad_Dimensiones: "",
            peso: 0,
            precio_entrada: 0,
            precio_salida: 0,
            enAlmacen: true,
            show_conditional: this.show,
            error_msg: ''
        };
    },
    methods: {
        async addProducts() {
            axios.post(`${API_URL}/product`, {
                nombre: this.nombre,
                descripcion: this.descripcion,
                tipo: this.tipo,
                alto: this.alto,
                ancho: this.ancho,
                largo: this.largo,
                unidad_Dimensiones: this.unidad_Dimensiones,
                peso: this.peso,
                precio_Entrada: this.precio_entrada,
                precio_Salida: this.precio_salida,
                enAlmacen: this.enAlmacen
            })
                .then(res => {
                    res;
                    this.nombre = "";
                    this.descripcion = "";
                    this.tipo = "";
                    this.alto = 0;
                    this.ancho = 0;
                    this.largo = 0;
                    this.unidad_Dimensiones = "";
                    this.peso = 0;
                    this.precio_entrada = 0;
                    this.precio_salida = 0;
                    this.show_conditional = false;
                    
                    this.$emit('product-added');
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