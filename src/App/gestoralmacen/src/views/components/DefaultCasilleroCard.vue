<template>
    <div 
        v-for="(item, index) in items" 
        :key="index" 
        class="grid-item"
        :class="{ 'selected': selected }"
        @click="$emit('selected-item', index)"
    >
        
    </div>
</template>

<script>

export default {
    name: 'default-casillero-card',
    props: ['item', 'index', 'selected'],
    methods: {
        getColor() {
            if (this.percentage <= 20) {
                return 'danger';
            }

            else if (this.percentage <= 60) {
                return 'warning';
            }

            return 'success';
        }
    },
};
</script>
  
<style scoped>
    .card {
        margin: 10px;
    }
</style>
  