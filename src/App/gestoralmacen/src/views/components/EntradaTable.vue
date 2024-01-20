<template>
  <div class="card mb-4">

    <div class="card-header pb-0">
      <h6>Entradas de productos</h6>
    </div>
    <soft-alert v-if="error_msg != ''" class="font-weight-light" color="danger" dismissible>
        <span class="text-sm">{{ error_msg }}</span>
    </soft-alert>
    <div class="card-body px-0 pt-0 pb-2">
      <div class="table-responsive p-0">
        <table class="table align-items-center justify-content-center mb-0">
          <thead>
            <tr>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Producto
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Proveedor
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Autorizaci&oacute;n
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Cantidad
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Precio Unitario
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Precio Total
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Fecha de Entrada
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Fecha de Caducidad
              </th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="entrada in this.entradas" :key="entrada['iD_Entrada']">
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
                    <h6 class="mb-0 text-sm">{{ entrada.producto_Name }}</h6>
                  </div>
                </div>
              </td>
              <td>
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ entrada.proveedor_Name }}</span>
                  </div>
                </div>
              </td>
              <td>
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ entrada.autorization }}</span>
                  </div>
                </div>
              </td>
              <td class="align-middle">
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ entrada.cantidad }}</span>
                  </div>
                </div>
              </td>
              <td class="align-middle">
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ entrada.precio_Unidad }}</span>
                  </div>
                </div>
              </td>
              <td class="align-middle">
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ entrada.precio_Unidad * entrada.cantidad }}</span>
                  </div>
                </div>
              </td>
              <td class="align-middle">
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ formatDate(entrada.fecha) }}</span>
                  </div>
                </div>
              </td>
              <td class="align-middle">
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ formatDate(entrada.fecha_Caducidad) }}</span>
                  </div>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import SoftAlert from '@/components/SoftAlert.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
  name: "entrada-table",
  components: {
    SoftAlert
},
  data() {
    return {
      showModal: false,
      entradas: [],
      error_msg: ''
    };
  },
  mounted() {
    this.getEntradas();
  },
  methods: {
    formatDate(fecha) {
      let date = new Date(fecha);
      let opciones = { year: 'numeric', month: 'long', day: 'numeric'};

      return date.toLocaleDateString('es-ES', opciones);
    },

    async getEntradas() {
      axios.get(`${API_URL}/entradaandsalida/entrada`)
        .then(res => {
          this.entradas = res.data.value['entradas'];
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
