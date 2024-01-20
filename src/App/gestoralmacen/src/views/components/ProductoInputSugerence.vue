<template>
<div class="autocomplete">
    <input 
        v-model="input"
        @input="update" 
        @keyup.down="down" 
        @keyup.up="up"
        @keyup.enter="hit"
        @blur="reset" 
        class="input form-control"
        placeholder="Escribe para buscar..."
    />
    
    <div class="suggestions" v-if="open">
        <div 
            v-for="(suggestion, i) in filtered" 
            :key="i"
            @click="select(suggestion)" 
            class="suggestion" 
            :class="{ active: i === active }" 
        >
            {{ suggestion.nombre }}
        </div>
    </div>
</div>
</template>

<script>
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    name: 'producto-input-sugerence',
    props: {
        value_input: {
            type: String,
            default: ''
        },
        transaction: {
            type: String,
            default: ''
        }
    },
    data() {
        return {
            open: false,
            input: "",
            active: 0,
            value: this.value_input,
            suggestions: []
        };
    },
    mounted() {
        this.getProductos();
    },
    computed: {
        filtered() {
            let results = this.suggestions.filter(suggestion => {
                return suggestion.nombre.toLowerCase().indexOf(this.input.toLowerCase()) > -1;
            });

            if (results.length === 0) {
                return ["No se encontraron sugerencias"];
            }

            return results.slice(0, 5);
        }
    },
    methods: {
        update() {
            if (!this.open) {
                this.open = true;
                this.active = 0;
            }
        },
        down() {
            if (this.active < this.filtered.length - 1) {
                this.active++;
            }
        },
        up() {
            if (this.active > 0) {
                this.active--;
            }
        },
        hit() {
            this.select(this.filtered[this.active]);
        },
        select(suggestion) {
            this.input = suggestion.nombre;
            this.value = suggestion.iD_Producto;
            let price = 0;
            this.open = false;

            if (this.transaction === "entrada") {
                price = suggestion.precio_Entrada;
            } else if (this.transaction === "salida") {
                price = suggestion.precio_Salida;
            }

            this.$emit('input', {value: this.value, price: price});
        },
        reset() {
            this.active = 0;
            this.open = false;
        },

        async getProductos() {
            axios.get(`${API_URL}/product`)
                .then(res => {
                    this.suggestions = res.data.value['productos'];
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

<style scoped>
.autocomplete {
    position: relative;
}
.suggestions {
    position: absolute;
    background: white;
    width: 100%;
    z-index: 1;
}
.suggestion {
    padding: 10px;
    cursor: pointer;
}
.suggestion.active {
    background: #f5f5f5;
}
</style>
