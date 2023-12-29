<template>
    <div class="card h-100 col-4 m-auto mb-4">
        <div class="p-3 card-body">
            <div class="list-group">
                <div class="row mb-2 border-0">
                    <div class="col">
                        <h6 class="mb-0 text-sm">Nombres</h6>
                        <soft-input
                            :value="this.params.nombres"
                            @input="event => this.params.nombres = event.target.value"
                            id="nombre"
                            type="text"
                            placeholder="Nombres"
                            name="nombre"
                        ></soft-input>
                    </div>    
                
                    <div class="col">
                        <h6 class="mb-0 text-sm">Apellidos</h6>
                        <soft-input
                            :value="this.params.apellidos"
                            @input="event => this.params.apellidos = event.target.value"
                            id="apellido"
                            type="text"
                            placeholder="apellidos"
                            name="apellido"
                        ></soft-input>
                    </div>    
                </div>
                <div class="row mb-2 border-0">
                    <div class="col">
                        <h6 class="mb-0 text-sm">DNI</h6>
                        <soft-input
                            :value="this.params.ci"
                            @input="event => this.params.ci = event.target.value"
                            id="dni"
                            type="text"
                            placeholder="DNI"
                            name="dni"
                        ></soft-input>
                    </div>    
                
                    <div class="col">
                        <h6 class="mb-0 text-sm">Correo</h6>
                        <soft-input
                            :value="this.params.correo"
                            @input="event => this.params.correo = event.target.value"
                            id="correo"
                            type="email"
                            placeholder="Correo"
                            name="correo"
                        ></soft-input>
                    </div>  
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm">Tel&eacute;fono</h6>
                        <soft-input
                            :value="this.params.telefono"
                            @input="event => this.params.telefono = event.target.value"
                            id="phone"
                            type="number"
                            placeholder="Tel&eacute;fono"
                            name="phone"
                        ></soft-input>
                    </div>    
                </div>

                <div class="row mb-2 border-0">
                    <div class="col">
                        <h6 class="mb-0 text-sm">Direcci&oacute;n</h6>
                        <soft-input
                            :value="this.params.direccion"
                            @input="event => this.params.direccion = event.target.value"
                            id="direction"
                            type="text"
                            placeholder="Direcci&oacute;n"
                            name="Direcci&oacute;n"
                        ></soft-input>
                    </div>    
                </div>
            </div>
            
            <soft-alert v-if="error_msg != ''" class="font-weight-light" color="danger" dismissible>
                <span class="text-sm">{{ error_msg }}</span>
            </soft-alert>

            <soft-button @click="editAuthors">Guardar</soft-button>
            <span>&nbsp;&nbsp;</span>
            <soft-button color="danger" @click="$emit('author-cancel-edit')">Cancelar</soft-button>
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
    name: "edit-authors-card",
    props: {
        func_auth: {
            type: String,
            required: true
        },
        auth_param: {
            type: Object,
            required: true
        }
    },
    components: {
        SoftAlert,
        SoftButton,
        SoftInput
    },
    mounted() {
        console.log(this.params);
    },
    data() {
        return {
            error_msg: '',
            params: this.auth_param
        };
    },
    methods: {
        async editAuthors() {
            axios.put(`${API_URL}/${this.func_auth}`, this.params)
                .then(res => {
                    res;
                    this.params.nombres = '';
                    this.params.apellidos = '';
                    this.params.ci = '';
                    this.params.correo = '';
                    this.params.telefono = '';
                    this.params.direccion = '';
                    
                    this.$emit('author-edited');
                })
                .catch(error => {
                    if (error.response && error.response.data) {
                        this.error_msg = error.response.data.title;
                    } else {
                        this.error_msg = error.message;
                    }
                });
        }
    }
};
</script>