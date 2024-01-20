<template>
<div class="py-4 container-fluid">
    <div class="row">
        <div class="col-12">
            <inventory-casillero-table
                table_title="Productos en Espera"
                state_wait="true"
                only_view="true"
                :products="productos_wait"
            />
        </div>
    </div>
</div>
</template>

<script>
import InventoryCasilleroTable from "./components/./InventoryCasilleroTable.vue";
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    name: "rack-wait",
    components: {
        InventoryCasilleroTable
    },
    data() {
        return {
            productos_wait: []
        };
    },
    mounted() {
        this.getWaitCasillero();
    },
    methods: {
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
        }
    },
};
</script>
  