<template>
    <div class="py-4 container-fluid">
      <div class="row">
        <div class="col-12">
          <authors-table :authors="authorsList" :func_auth="func_auth" />
        </div>
      </div>
    </div>
  </template>
  
  <script>
  import AuthorsTable from "./components/AuthorsTable";
  import axios from 'axios';
  
  export default {
    name: "proveedor",
    components: {
      AuthorsTable,
    },
    mounted() {
        this.getProveedores();
    },
    data() {
        return {
            authorsList: [],
            func_auth: 'Proveedor'
        };
    },
    methods: {
        async getProveedores() {
            
            axios.get('https://localhost:5001/proveedor')
                .then(res => {
                    this.authorsList = res.data.value.proveedors;
                })
                .catch(error => {
                    if (error.response && error.response.data) {
                        this.error_msg = error.response.data.title;
                    } else {
                        this.error_msg = error.message;
                    }

                    console.log('error' + error);
                })
        }
    }
  };
  </script>
  