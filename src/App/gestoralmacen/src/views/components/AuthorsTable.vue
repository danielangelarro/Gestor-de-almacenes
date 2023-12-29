<template>
  <div class="card mb-4">
    <div class="card-header pb-0">
      <h6>Authors table</h6>
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
          <tbody>
            <tr v-for="auth in authors" :key="auth.id">
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
                  href="javascript:;"
                  class="text-secondary font-weight-bold text-xs"
                  data-toggle="tooltip"
                  data-original-title="Edit user"
                  >Edit</a
                >
              </td>
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
import img1 from "../../assets/img/team-2.jpg";

export default {
  name: "authors-table",
  props: ['authors', 'func_auth'],
  data() {
    return {
      img1
    };
  },
  mounted() {
    console.log(this.authors);
    console.log(this.func_auth);
  },
  components: {
    SoftAvatar,
    SoftBadge,
  },
};
</script>
