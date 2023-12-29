<template>
  <div class="py-4 container-fluid">
    <create-authors-card 
      :func_auth="func_auth" 
      @author-added="getAuthors">
    </create-authors-card>

    <edit-authors-card
      v-if="this.show_edit"
      :func_auth="func_auth"
      :auth_param="params"
      @author-edited="getAuthors"
      @author-cancel-edit="this.show_edit = false;"
    >
    </edit-authors-card>

    <div class="row">
      <div class="col-12">
        <authors-table 
          ref="authorsTable"
          :func_auth="func_auth" 
          :name_table="name_table" 
          :var_name="var_name"
          :key_table="key"
          @emit-author-edit="handleEditAuthor"
        />
      </div>
    </div>
  </div>
</template>
  
<script>
  import AuthorsTable from "./components/AuthorsTable";
  import CreateAuthorsCard from "./components/CreateAuthorsCard.vue";
  import EditAuthorsCard from "./components/EditAuthorsCard.vue";
  
  export default {
    name: "proveedor",
    components: {
      AuthorsTable,
      CreateAuthorsCard,
      EditAuthorsCard
    },
    data() {
      return {
        func_auth: 'proveedor',
        var_name: 'proveedors',
        name_table: 'Lista de Proveedores',
        key: 'iD_Proveedor',
        show_edit: false,
        params: null
      };
    },
    methods: {
      getAuthors() {
      this.show_edit = false;
      this.$refs.authorsTable.getAuthors();
    },

    handleEditAuthor(auth) {
      this.show_edit = true;
      this.params = auth;
    }
    },
  };
</script>
  