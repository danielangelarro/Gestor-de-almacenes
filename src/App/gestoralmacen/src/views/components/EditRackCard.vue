<template>
    <div class="card h-100 col-5 m-auto mb-4">
        <div class="p-3 card-body">
            <div class="list-group">
                <div class="row mb-2 border-0">
                    <div class="col">
                        <h6 class="mb-0 text-sm">Pasillo</h6>
                        <soft-input
                            :value="params.pasillo"
                            @input="event => params.pasillo = event.target.value"
                            id="pasillo"
                            type="text"
                            placeholder="Pasillo"
                            name="pasillo"
                            rows="3"
                            isReadonly="true"
                        ></soft-input>
                    </div>
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm">Cantidad Filas</h6>
                        <soft-input
                            :value="params.filas"
                            @input="event => params.filas = event.target.value"
                            id="filas"
                            type="number"
                            placeholder="Cantidad de Filas"
                            name="filas"
                            rows="3"
                            isReadonly="true"
                        ></soft-input>
                    </div>
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm">Cantidad Columnas</h6>
                        <soft-input
                            :value="params.columnas"
                            @input="event => params.columnas = event.target.value"
                            id="columnas"
                            type="number"
                            placeholder="Cantidad de Columnas"
                            name="columnas"
                            rows="3"
                            isReadonly="true"
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
                            :value="params.peso_Maximo"
                            @input="event => params.peso_Maximo = event.target.value"
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
                        <select class="input" v-model="params.unidad_Dimensiones">
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

            <soft-button @click="editRacks">Guardar</soft-button>
            <span>&nbsp;&nbsp;</span>
            <soft-button color="danger" @click="$emit('rack-cancel-edit')">Cancelar</soft-button>
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
    name: "edit-rack-card",
    props: {
        show: {
            type: Boolean,
            default: false
        },
        rack_params: {
            type: Object,
            required: true
        }
    },
    components: {
        SoftAlert,
        SoftButton,
        SoftInput
    },
    data() {
        return {
            params: this.rack_params,
            error_msg: ''
        };
    },
    methods: {
        async editRacks() {
            axios.put(`${API_URL}/rack`, this.params)
                .then(res => {
                    res;
                    this.params.pasillo = "";
                    this.params.casilleros = "";
                    this.params.peso_Maximo = 0;
                    this.params.alto = 0;
                    this.params.ancho = 0;
                    this.params.largo = 0;
                    this.params.unidad_Dimensiones = "";
                    
                    this.$emit('rack-edited');
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