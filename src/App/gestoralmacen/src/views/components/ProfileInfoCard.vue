<template>
  <div class="card h-100">
    <div class="p-3 pb-0 card-header">
      <div class="row">
        <div class="col-md-8 d-flex align-items-center">
          <h6 class="mb-0">{{ title }}</h6>
        </div>
        <div class="col-md-4 text-end">
          <a :href="action.route" @click.prevent="$emit('edit-user')">
            <i
              class="text-sm fas fa-user-edit text-secondary"
              data-bs-toggle="tooltip"
              data-bs-placement="top"
              :title="action.tooltip"
            >Edit</i>
          </a>
        </div>
      </div>
    </div>
    <div class="p-3 card-body">
      <hr class="my-4 horizontal gray-light" />
      <ul class="list-group">
        <li class="pt-0 text-sm border-0 list-group-item ps-0">
          <strong class="text-dark">Nombres:</strong> &nbsp;
          {{ info.firstName }}
        </li>
        <li class="pt-0 text-sm border-0 list-group-item ps-0">
          <strong class="text-dark">Apellidos:</strong> &nbsp;
          {{ info.lastName }}
        </li>
        <li class="text-sm border-0 list-group-item ps-0">
          <strong class="text-dark">Correo:</strong> &nbsp; {{ info.email }}
        </li>
        <li class="text-sm border-0 list-group-item ps-0">
          <strong class="text-dark">Contrase&ntilde;a</strong> &nbsp; *****
        </li>
        <li class="text-sm border-0 list-group-item ps-0">
          <strong class="text-dark">Rol:</strong> &nbsp; {{ info.rol }}
        </li>
      </ul>
    </div>
  </div>
</template>

<script>

export default {
  name: "ProfileInfoCard",
  components: {
  },
  props: {
    title: {
      type: String,
      default: "",
    },
    info: {
      type: Object,
      fullName: String,
      mobile: String,
      email: String,
      location: String,
      default: () => {},
    },
    action: {
      type: Object,
      route: String,
      tooltip: String,
      default: () => ({
        route: "javascript:;",
      }),
    },
  }
};
</script>
