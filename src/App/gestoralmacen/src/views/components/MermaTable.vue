<template>
  <div class="card mb-4">

    <div class="card-header pb-0">
      <h6>Mermas de productos</h6>
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
                Fecha de Salida
              </th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="merma in this.mermas" :key="merma['ID_Movimiento']">
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
                    <h6 class="mb-0 text-sm">{{ merma.producto_Name }}</h6>
                  </div>
                </div>
              </td>
              <td>
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ merma.cliente_Name }}</span>
                  </div>
                </div>
              </td>
              <td>
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ merma.autorization }}</span>
                  </div>
                </div>
              </td>
              <td class="align-middle">
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ merma.cantidad }}</span>
                  </div>
                </div>
              </td>
              <td class="align-middle">
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ merma.precio_Unidad }}</span>
                  </div>
                </div>
              </td>
              <td class="align-middle">
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ merma.precio_Unidad * merma.cantidad }}</span>
                  </div>
                </div>
              </td>
              <td class="align-middle">
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ formatDate(merma.fecha) }}</span>
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
  name: "salida-table",
  components: {
    SoftAlert
},
  data() {
    return {
      showModal: false,
      mermas: [],
      error_msg: ''
    };
  },
  mounted() {
    this.getSalidas();
  },
  methods: {
    formatDate(fecha) {
      let date = new Date(fecha);
      let opciones = { year: 'numeric', month: 'long', day: 'numeric'};

      return date.toLocaleDateString('es-ES', opciones);
    },

    async getMermas() {
      axios.get(`${API_URL}/merma`)
        .then(res => {
          this.mermas = res.data.value['mermas'];
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
