<template>
<div class="py-4 container-fluid">

    <create-salida-card 
        :func_auth="func_auth" 
        @salida-added="getSalidas">
    </create-salida-card>

    <soft-button-vue 
        color="info"
        class="mb-4"
        @click="downloadReport"
    >Descargar Reporte</soft-button-vue>

    <div class="row">
        <div class="col-12">
            <salida-table
                ref="salidaTable"
                @rack-selected="showRackDetail($event)"
            />
        </div>
    </div>
</div>
</template>

<script>
import SoftButtonVue from  '@/components/SoftButton.vue';
import SalidaTable from './components/SalidaTable.vue';
import CreateSalidaCard from './components/CreateSalidaCard.vue';
import { API_URL } from '@/config'; 
import axios from 'axios';

export default {
    name: "salida",
    components: {
        SoftButtonVue,
        SalidaTable,
        CreateSalidaCard,
    },
    data() {
        return {
            params: null,
            suggestions: []
        };
    },
    methods: {
        getSalidas() {
            this.$refs.salidaTable.getSalidas();
        },

        downloadReport() {
            axios({
                url: `${API_URL}/entradaandsalida/salida/report`,
                method: 'GET',
                responseType: 'blob',
            })
            .then((response) => {
                const url = window.URL.createObjectURL(new Blob([response.data]));
                const link = document.createElement('a');
                link.href = url;
                link.setAttribute('download', 'ReporteSalidaProductos.pdf'); // Asegúrate de que el PDF se descargue en lugar de abrirse en una nueva pestaña
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            });
        }
    },
};
</script>
  