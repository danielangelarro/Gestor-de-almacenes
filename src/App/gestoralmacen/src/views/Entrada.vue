<template>
<div class="py-4 container-fluid">

    <create-entrada-card 
        :func_auth="func_auth" 
        @rack-added="getRacks">
    </create-entrada-card>

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

export default {
    name: "entrada",
    components: {
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
    },
};
</script>
  