<template>
  <div class="card mb-4">
    <soft-alert v-show="showConfirm" color="dark" class="font-weight-light m-4">
      <p>Está seguro de querer borrar este producto?</p>
      <soft-button @click="deleteProduct(); showConfirm = false;">Confirmar</soft-button>
      <span>&nbsp;</span>
      <soft-button color="danger" @click="showConfirm = false;">Cancelar</soft-button>
    </soft-alert>

    <div class="card-header pb-0">
      <h6>Productos</h6>
    </div>
    <div class="card-body px-0 pt-0 pb-2">
      <div class="table-responsive p-0">
        <table class="table align-items-center justify-content-center mb-0">
          <thead>
            <tr>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Nombre
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2"
              >
                Tipo
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2"
              >
                Dimensiones
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder text-center opacity-7 ps-2"
              >
                Peso
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder text-center opacity-7 ps-2"
              >
                En Almac&eacute;n
              </th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="product in this.products" :key="product['iD_Producto']">
              <td>
                <div class="d-flex px-2">
                  <div>
                    <img
                      src="../../assets/img/small-logos/logo-invision.svg"
                      class="avatar avatar-sm rounded-circle me-2"
                      alt="spotify"
                    />
                  </div>
                  <div class="my-auto">
                    <h6 class="mb-0 text-sm">{{ product.nombre }}</h6>
                  </div>
                </div>
              </td>
              <td>
                <p class="text-sm font-weight-bold mb-0">{{ product.tipo }}</p>
              </td>
              <td>
                <span class="text-xs font-weight-bold">
                  {{ product.alto }} x {{ product.ancho }} x {{ product.largo }} {{ product.unidad_Dimensiones }}<sup>3</sup>
                </span>
              </td>
              <td class="align-middle text-center">
                <span class="text-xs font-weight-bold">{{ product.peso }}</span>
              </td>
              <td class="align-middle text-center">
                <soft-badge :color="[product.enAlmacen ? 'success' : 'danger']" variant="gradient" size="sm"
                  >Existencia</soft-badge
                >
              </td>
              <td class="align-middle">
                <span>&nbsp;&nbsp;</span>
                <a
                  @click="$emit('emit-product-edit', product)"
                  href="#"
                  class="text-dark font-weight-bold text-xs"
                  data-toggle="tooltip"
                  data-original-title="Editar producto"
                  >
                  <i class="fa fa-pencil-alt">&nbsp;&nbsp;Editar</i>
                </a>
                <span>&nbsp;&nbsp;</span>
                <a
                  @click="confirmDelete(product.iD_Producto)"
                  href="#"
                  class="text-danger font-weight-bold text-xs"
                  data-toggle="tooltip"
                  data-original-title="Delete product"
                  >
                  <i class="fa fa-trash-o">&nbsp;&nbsp;Borrar</i>
                </a>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import SoftBadge from '@/components/SoftBadge.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
  name: "inventory-table",
  components: {
    SoftBadge
  },
  data() {
    return {
      showConfirm: false,
      productToDelete: null,
      products: [],
      error_msg: ''
    };
  },
  mounted() {
    this.getProducts();
  },
  methods: {
    async getProducts() {
      axios.get(`${API_URL}/product`)
        .then(res => {
          this.products = res.data.value['productos'];
        })
        .catch(error => {
          if (error.response && error.response.data) {
            this.error_msg = error.response.data.title;
          } else {
            this.error_msg = error.message;
          }
        });
    },

    showDetail(id) {
      console.log('emit: ' + id);
      this.$emit('product-selected', id);
    },

    async confirmDelete(id) {
      this.productToDelete = id;
      this.showConfirm = true;
    },

    async deleteProduct() {
      axios.delete(`${this.link}/${this.productToDelete}`)
        .then(res => {
          res;
          this.getProducts();
        })
        .catch(error => {
          if (error.response && error.response.data) {
            this.error_msg = error.response.data.title;
          } else {
            this.error_msg = error.message;
          }
        });
    }
  }
};
</script>
