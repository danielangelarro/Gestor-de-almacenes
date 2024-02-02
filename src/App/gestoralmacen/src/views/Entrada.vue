<template>
<div class="py-4 container-fluid">

    <create-entrada-card 
        :func_auth="func_auth" 
        @rack-added="getRacks">
    </create-entrada-card>

    <soft-button-vue 
        color="info"
        class="mb-4"
        @click="downloadReport"
    >Descargar Reporte</soft-button-vue>

    <div class="row">
        <div class="col-12">
            <entrada-table
                ref="entradaTable"
                @rack-selected="showRackDetail($event)"
            />
        </div>
    </div>
</div>
</template>

<script>
import EntradaTable from './components/EntradaTable.vue';
import CreateEntradaCard from './components/CreateEntradaCard.vue';
import SoftButtonVue from '@/components/SoftButton.vue';
import { API_URL } from '@/config'; 
import axios from 'axios';

export default {
    name: "entrada",
    components: {
        SoftButtonVue,
        EntradaTable,
        CreateEntradaCard,
    },
    data() {
        return {
            params: null,
            suggestions: []
        };
    },
    methods: {
        getRacks() {
            this.$refs.entradaTable.getEntradas();
        },

        downloadReport() {
            axios({
                url: `${API_URL}/entradaandsalida/entrada/report`,
                method: 'GET',
                responseType: 'blob',
            })
            .then((response) => {
                const url = window.URL.createObjectURL(new Blob([response.data]));
                const link = document.createElement('a');
                link.href = url;
                link.setAttribute('download', 'ReporteEntradaProductos.pdf'); // Asegúrate de que el PDF se descargue en lugar de abrirse en una nueva pestaña
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            });
        }
    },
};
</script>
  