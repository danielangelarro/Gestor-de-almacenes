<template>
  <div class="card mb-4">
    <soft-alert v-show="showConfirm" color="dark" class="font-weight-light m-4">
      <p>Está seguro de querer borrar este rack?</p>
      <soft-button @click="deleteRack(); showConfirm = false;">Confirmar</soft-button>
      <span>&nbsp;</span>
      <soft-button color="danger" @click="showConfirm = false;">Cancelar</soft-button>
    </soft-alert>

    <div class="card-header pb-0">
      <h6>Racks</h6>
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
                Pasillo
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Cantidad de Filas
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Cantidad de Columnas
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Dimensi&oacute;n de los Casilleros
              </th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="rack in this.racks" :key="rack['iD_Rack']">
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
                    <h6 class="mb-0 text-sm">{{ rack.pasillo }}</h6>
                  </div>
                </div>
              </td>
              <td>
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ rack.filas }}</span>
                  </div>
                </div>
              </td>
              <td class="align-middle">
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ rack.columnas }}</span>
                  </div>
                </div>
              </td>
              <td class="align-middle">
                <div class="d-flex px-2">
                  <div class="my-auto">
                    <span class="mb-0 text-sm">{{ rack.alto }} x {{ rack.ancho }} x {{ rack.largo }} {{ rack.unidad_Dimensiones }}<sup>3</sup></span>
                  </div>
                </div>
              </td>
              <td class="align-middle">
                <router-link 
                  :to="{ name: 'Casillero', params: { id_rack: rack.iD_Rack, pasillo: rack.pasillo, rows: rack.filas, columns: rack.columnas }}"
                  class="text-dark font-weight-bold text-xs"
                >
                  <i class="fa fa-eye">&nbsp;&nbsp;Ver Casilleros</i>
                </router-link>
                <span>&nbsp;|&nbsp;</span>
                <a
                  @click="$emit('emit-rack-edit', rack)"
                  href="#"
                  class="text-dark font-weight-bold text-xs"
                  data-toggle="tooltip"
                  data-original-title="Editar rack"
                  >
                  <i class="fa fa-pencil-alt">&nbsp;&nbsp;Editar</i>
                </a>
                <span>&nbsp;|&nbsp;</span>
                <a
                  @click="confirmDelete(rack.iD_Rack)"
                  href="#"
                  class="text-danger font-weight-bold text-xs"
                  data-toggle="tooltip"
                  data-original-title="Delete rack"
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
import SoftAlert from '@/components/SoftAlert.vue';
import SoftButton from '@/components/SoftButton.vue';
import { API_URL } from '@/config';
import axios from 'axios';
import { RouterLink } from 'vue-router';

export default {
  name: "rack-table",
  components: {
    SoftAlert,
    SoftButton,
    RouterLink
},
  data() {
    return {
      showModal: false,
      showConfirm: false,
      rackToDelete: null,
      racks: [],
      error_msg: ''
    };
  },
  mounted() {
    this.getRacks();
  },
  methods: {
    async getRacks() {
      axios.get(`${API_URL}/rack`)
        .then(res => {
          this.racks = res.data.value['racks'];
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
      this.$emit('rack-selected', id);
    },

    async confirmDelete(id) {
      this.rackToDelete = id;
      this.showConfirm = true;
    },

    async deleteRack() {
      axios.delete(`${API_URL}/rack/${this.rackToDelete}`)
        .then(res => {
          res;
          this.getRacks();
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
