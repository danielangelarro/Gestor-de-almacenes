<template>
<div class="py-4 container-fluid">

    <edit-product-card
        v-if="this.show_edit"
        :product_params="params"
        @product-edited="getProducts"
        @product-cancel-edit="this.show_edit = false;"
    ></edit-product-card>

    <create-product-card 
        v-else
        :func_auth="func_auth" 
        @product-added="getProducts">
    </create-product-card>

    <div class="row">
        <div class="col-12">
            <inventory-table
                ref="inventoryTable"
                @product-selected="showProductDetail($event)"
                @emit-product-edit="handleEditProduct"
            />
        </div>
    </div>
</div>
</template>

<script>
import InventoryTable from './components/InventoryTable.vue';
import CreateProductCard from './components/CreateProductCard.vue';
import EditProductCard from './components/EditProductCard.vue';

export default {
    name: "inventory",
    components: {
        InventoryTable,
        CreateProductCard,
        EditProductCard
    },
    data() {
        return {
            show_edit: false,
            params: null
        };
    },
    methods: {
        getProducts() {
            this.show_edit = false;
            this.$refs.inventoryTable.getProducts();
        },
        handleEditProduct(product) {
            this.show_edit = true;
            this.params = product;
        }
    },
};
</script>
  