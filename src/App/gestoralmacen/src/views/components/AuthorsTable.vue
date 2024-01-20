<template>
  <div class="card mb-4">
    <soft-alert v-show="showConfirm" color="dark" class="font-weight-light m-4">
      <p>Está seguro de querer borrar este autor?</p>
      <soft-button @click="deleteAuthors(authorToDelete); showConfirm = false;">Confirmar</soft-button>
      <span>&nbsp;</span>
      <soft-button color="danger" @click="showConfirm = false;">Cancelar</soft-button>
    </soft-alert>

    <soft-alert v-show="error_msg != ''" class="font-weight-light m-4" color="danger" dismissible>
        <span class="text-sm">{{ error_msg }}</span>
    </soft-alert>

    <div class="card-header pb-0">
      <h6>{{ name_table }}</h6>
    </div>
    <div class="card-body px-0 pt-0 pb-2">
      <div class="table-responsive p-0">
        <table class="table align-items-center mb-0">
          <thead>
            <tr>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Nombres y Apellidos
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                DNI
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2"
              >
                Tel&eacute;fono
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Estado
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Direcci&oacute;n
              </th>
              <th class="text-secondary opacity-7"></th>
            </tr>
          </thead>
          <tbody v-if="this.authors.length > 0">
            <tr v-for="auth in authors" :key="auth[key_table]">
              <td>
                <div class="d-flex px-2 py-1">
                  <div>
                    <soft-avatar
                      :img="img1"
                      size="sm"
                      border-radius="lg"
                      class="me-3"
                      alt="user1"
                    />
                  </div>
                  <div class="d-flex flex-column justify-content-center">
                    <h6 class="mb-0 text-sm">{{ auth.nombres }} {{ auth.apellidos }}</h6>
                    <p class="text-xs text-secondary mb-0">
                      {{ auth.correo }}
                    </p>
                  </div>
                </div>
              </td>
              <td class="align-middle text-center">
                <span class="text-secondary text-xs font-weight-bold">
                  {{ auth.ci }}
                </span>
              </td>
              <td>
                <span class="text-secondary text-xs font-weight-bold">
                  {{ auth.telefono }}
                </span>
              </td>
              <td class="align-middle text-center text-sm">
                <soft-badge color="success" variant="gradient" size="sm"
                  >Activado</soft-badge
                >
              </td>
              <td class="align-middle text-center">
                <span class="text-secondary text-xs font-weight-bold">
                  {{ auth.direccion }}
                </span>
              </td>
              <td class="align-middle">
                <a
                  @click="$emit('emit-author-edit', auth)"
                  href="#"
                  class="text-dark font-weight-bold text-xs"
                  data-toggle="tooltip"
                  data-original-title="Editar autor"
                  >
                  <i class="fa fa-pencil-alt">&nbsp;&nbsp;Editar</i>
                </a>
                <span>&nbsp;&nbsp;</span>
                <a
                  @click="confirmDelete(auth[key_table])"
                  href="#"
                  class="text-danger font-weight-bold text-xs"
                  data-toggle="tooltip"
                  data-original-title="Delete user"
                  >
                  <i class="fa fa-trash-o">&nbsp;&nbsp;Borrar</i>
                </a>
              </td>
            </tr>
          </tbody>
          <tbody v-else>
              <tr>
                  <td colspan="6">Loading...</td>
              </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import SoftAvatar from "@/components/SoftAvatar.vue";
import SoftBadge from "@/components/SoftBadge.vue";
import SoftAlert from "@/components/SoftAlert.vue";
import SoftButton from "@/components/SoftButton.vue";
import { API_URL } from '@/config';
import axios from 'axios';
import img1 from "../../assets/img/team-2.jpg";

export default {
  name: "authors-table",
  props: {
    func_auth: String, 
    name_table: String, 
    var_name: String,
    key_table: String
  },
  components: {
    SoftAvatar,
    SoftBadge,
    SoftAlert,
    SoftButton
  },
  mounted() {
    this.getAuthors();
  },
  data() {
    return {
      img1,
      showConfirm: false,
      authorToDelete: null,
      authors: [],
      link: `${API_URL}/${this.func_auth}`,
      error_msg: ''
    };
  },
  methods: {
    async getAuthors() {
      axios.get(this.link)
        .then(res => {
          this.authors = res.data.value[this.var_name];
        })
        .catch(error => {
          if (error.response && error.response.data) {
            this.error_msg = error.response.data.title;
          } else {
            this.error_msg = error.message;
          }
        });
    },

    async confirmDelete(id) {
      this.authorToDelete = id;
      this.showConfirm = true;
    },

    async deleteAuthors() {
      axios.delete(`${this.link}/${this.authorToDelete}`)
        .then(res => {
          res;
          this.getAuthors();
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
