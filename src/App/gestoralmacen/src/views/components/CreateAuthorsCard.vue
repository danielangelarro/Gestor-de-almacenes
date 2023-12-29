<template>
    <div v-if="show_conditional" class="card h-100 col-5 m-auto mb-4">
        <div class="p-3 card-body">
            <div class="list-group">
                <div class="row mb-2 border-0">
                    <div class="col">
                        <h6 class="mb-0 text-sm">Nombres</h6>
                        <soft-input
                            :value="nombres"
                            @input="event => nombres = event.target.value"
                            id="nombre"
                            type="text"
                            placeholder="Nombres"
                            name="nombre"
                        ></soft-input>
                    </div>    
                
                    <div class="col">
                        <h6 class="mb-0 text-sm">Apellidos</h6>
                        <soft-input
                            :value="apellidos"
                            @input="event => apellidos = event.target.value"
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
                            :value="dni"
                            @input="event => dni = event.target.value"
                            id="dni"
                            type="text"
                            placeholder="DNI"
                            name="dni"
                        ></soft-input>
                    </div>    
                
                    <div class="col">
                        <h6 class="mb-0 text-sm">Correo</h6>
                        <soft-input
                            :value="correo"
                            @input="event => correo = event.target.value"
                            id="correo"
                            type="email"
                            placeholder="Correo"
                            name="correo"
                        ></soft-input>
                    </div>  
                    
                    <div class="col">
                        <h6 class="mb-0 text-sm">Tel&eacute;fono</h6>
                        <soft-input
                            :value="telefono"
                            @input="event => telefono = event.target.value"
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
                            :value="direction"
                            @input="event => direction = event.target.value"
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

            <soft-button @click="addAuthors">Guardar</soft-button>
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
    name: "create-authors-card",
    props: {
        func_auth: {
            type: String,
            required: true
        },
        show: {
            type: Boolean,
            default: false
        }
    },
    components: {
        SoftAlert,
        SoftButton,
        SoftInput
    },
    data() {
        return {
            nombres: '',
            apellidos: '',
            dni: '',
            correo: '',
            telefono: '',
            direction: '',
            show_conditional: this.show,
            error_msg: ''
        };
    },
    methods: {
        async addAuthors() {
            axios.post(`${API_URL}/${this.func_auth}`, {
                nombres: this.nombres,
                apellidos: this.apellidos,
                ci: this.dni,
                telefono: this.telefono,
                correo: this.correo,
                direccion: this.direction
            })
                .then(res => {
                    res;
                    this.nombres = '';
                    this.apellidos = '';
                    this.dni = '';
                    this.correo = '';
                    this.telefono = '';
                    this.direction = '';
                    this.show_conditional = false;
                    
                    this.$emit('author-added');
                })
                .catch(error => {
                    if (error.response && error.response.data) {
                        this.error_msg = error.response.data.title;
                    } else {
                        this.error_msg = error.message;
                    }
                    console.log(error)
                });
        },
    }
};
</script>