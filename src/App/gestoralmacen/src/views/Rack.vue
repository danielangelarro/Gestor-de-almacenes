<template>
<div class="py-4 container-fluid">

    <edit-rack-card
        v-if="this.show_edit"
        :rack_params="params"
        @rack-edited="getRacks"
        @rack-cancel-edit="this.show_edit = false;"
    ></edit-rack-card>

    <create-rack-card 
        v-else
        :func_auth="func_auth" 
        @rack-added="getRacks">
    </create-rack-card>

    <soft-button-vue 
        color="info"
        class="mb-4"
        @click="downloadReport"
    >Descargar Reporte</soft-button-vue>

    <div class="row">
        <div class="col-12">
            <rack-table
                ref="rackTable"
                @rack-selected="showRackDetail($event)"
                @emit-rack-edit="handleEditRack"
            />
        </div>
    </div>
</div>
</template>

<script>
import RackTable from './components/RackTable.vue';
import CreateRackCard from './components/CreateRackCard.vue';
import EditRackCard from './components/EditRackCard.vue';
import SoftButtonVue from '@/components/SoftButton.vue';
import { API_URL } from '@/config'; 
import axios from 'axios';

export default {
    name: "rack",
    components: {
        RackTable,
        CreateRackCard,
        EditRackCard,
        SoftButtonVue
    },
    data() {
        return {
            show_edit: false,
            params: null
        };
    },
    methods: {
        getRacks() {
            this.show_edit = false;
            this.$refs.rackTable.getRacks();
        },
        handleEditRack(rack) {
            this.show_edit = true;
            this.params = rack;
        },

        downloadReport() {
            axios({
                url: `${API_URL}/rack/report`,
                method: 'GET',
                responseType: 'blob',
            })
            .then((response) => {
                const url = window.URL.createObjectURL(new Blob([response.data]));
                const link = document.createElement('a');
                link.href = url;
                link.setAttribute('download', 'ReporteUbicacionProductos.pdf'); // Asegúrate de que el PDF se descargue en lugar de abrirse en una nueva pestaña
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            });
        }
    },
};
</script>
  