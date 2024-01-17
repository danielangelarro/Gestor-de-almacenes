<template>
    <div class="card h-100 col-5 m-auto mb-4">
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
                            :value="peso_Maximo"
                            @input="event => peso_Maximo = event.target.value"
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

            <soft-button @click="editCasilleros">Guardar</soft-button>
            <span>&nbsp;&nbsp;</span>
            <soft-button color="danger" @click="$emit('casillero-cancel-edit')">Cancelar</soft-button>
        </div>
    </div>
</template>

<script>
import SoftInput from "@/components/SoftInput.vue";
import SoftButton from "@/components/SoftButton.vue";
import SoftAlert from "@/components/SoftAlert.vue";
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    name: "edit-casillero-card",
    props: {
        casilleros_params: {
            type: Array,
            required: true
        },
        id_casilleros: {
            type: Array
        }
    },
    components: {
        SoftAlert,
        SoftButton,
        SoftInput
    },
    data() {
        return {
        peso_Maximo: 0,
        alto: 0,
        ancho: 0,
        largo: 0,
        unidad_Dimensiones: "",
            error_msg: ''
        };
    },
    methods: {
        async editCasilleros() {
            this.casilleros_params.forEach(element => {

                axios.put(`${API_URL}/casillero`, {
                    iD_Casillero: element.iD_Casillero,
                    area: this.ancho * this.alto,
                    peso_Maximo: this.peso_Maximo,
                    alto: this.alto,
                    ancho: this.ancho,
                    largo: this.largo,
                    unidad_Dimensiones: this.unidad_Dimensiones
                })
                    .then(res => {
                        res;
                        this.peso_Maximo = 0;
                        this.alto = 0;
                        this.ancho = 0;
                        this.largo = 0;
                        this.unidad_Dimensiones = "";
                        
                        this.$emit('casillero-edited');
                    })
                    .catch(error => {
                        if (error.response && error.response.data) {
                            this.error_msg = error.response.data.title;
                        } else {
                            this.error_msg = error.message;
                        }
                    });
            });
        },
    }
};
</script>