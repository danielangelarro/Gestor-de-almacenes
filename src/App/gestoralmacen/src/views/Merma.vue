<template>
<div class="py-4 container-fluid">
    <div class="row">
        <div class="col-12">
            <merma-table/>
        </div>
    </div>
</div>
</template>

<script>
import MermaTable from './components/MermaTable.vue';

export default {
    name: "merma",
    components: {
        MermaTable,
    },
    data() {
        return {
            params: null,
            suggestions: []
        };
    },
};
</script>
  