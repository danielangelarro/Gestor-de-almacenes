<template>
<div class="py-4 container-fluid">

    <create-salida-card 
        :func_auth="func_auth" 
        @salida-added="getSalidas">
    </create-salida-card>

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
import SalidaTable from './components/SalidaTable.vue';
import CreateSalidaCard from './components/CreateSalidaCard.vue';

export default {
    name: "salida",
    components: {
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
    },
};
</script>
  