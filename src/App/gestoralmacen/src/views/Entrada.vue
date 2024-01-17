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

    <div class="row">
        <div class="col-12">
            <rack-table
                ref="rackTable"
                @rack-selected="showRackDetail($event)"
            />
        </div>
    </div>
</div>
</template>

<script>
import RackTable from './components/RackTable.vue';
import CreateRackCard from './components/CreateRackCard.vue';
import EditRackCard from './components/EditRackCard.vue';

export default {
    name: "entrada",
    components: {
        RackTable,
        CreateRackCard,
        EditRackCard
    },
    data() {
        return {
            params: null
        };
    },
    methods: {
        getRacks() {
            this.$refs.rackTable.getRacks();
        },
    },
};
</script>
  