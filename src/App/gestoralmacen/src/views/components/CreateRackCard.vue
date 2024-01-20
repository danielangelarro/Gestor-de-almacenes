<template>
    <div v-if="show_conditional" class="card h-100 col-5 m-auto mb-4">
        <div class="p-3 card-body">
            <div class="list-group">
                <div class="row mb-2 border-0">
                    <div class="col">
                        <h6 class="mb-0 text-sm">Pasillo</h6>
                        <soft-input
                            :value="pasillo"
                            @input="event => pasillo = event.target.value"
                            id="pasillo"
                            type="text"
                            placeholder="Pasillo"
                            name="pasillo"
                            rows="3"
                        ></soft-input>
                    </div>
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm">Cantidad de Filas</h6>
                        <soft-input
                            :value="filas"
                            @input="event => filas = event.target.value"
                            id="filas"
                            type="number"
                            placeholder="Cantidad de Filas"
                            name="filas"
                            rows="3"
                        ></soft-input>
                    </div>
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm">Cantidad de Columnas</h6>
                        <soft-input
                            :value="columnas"
                            @input="event => columnas = event.target.value"
                            id="columnas"
                            type="number"
                            placeholder="Cantidad de Columnas"
                            name="columnas"
                            rows="3"
                        ></soft-input>
                    </div>
                </div>

                <div class="row mb-2 border-0">
                    <h1 class="mb-4 text-sm text-center">PROPIEDADES DE LOS CASILLEROS</h1>
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
                        <select class="input" v-model="unidad_Dimensiones">
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

            <soft-button @click="addRacks">Guardar</soft-button>
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
import SoftAlert from "@/components/SoftAlert.vue";
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    name: "create-rack-card",
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
    },
    data() {
        return {
            pasillo: "",
            filas: "",
            columnas: "",
            peso: 0,
            alto: 0,
            ancho: 0,
            largo: 0,
            unidad_Dimensiones: "",
            show_conditional: this.show,
            error_msg: ''
        };
    },
    methods: {
        async addRacks() {
            axios.post(`${API_URL}/rack`, {
                pasillo: this.pasillo,
                filas: this.filas,
                columnas: this.columnas,
                peso_Maximo: this.peso,
                alto: this.alto,
                ancho: this.ancho,
                largo: this.largo,
                unidad_Dimensiones: this.unidad_Dimensiones
            })
                .then(res => {
                    res;
                    this.pasillo = "";
                    this.filas = "";
                    this.columnas = "";
                    this.peso = 0;
                    this.alto = 0;
                    this.ancho = 0;
                    this.largo = 0;
                    this.unidad_Dimensiones = "";
                    this.show_conditional = false;
                    
                    this.$emit('rack-added');
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