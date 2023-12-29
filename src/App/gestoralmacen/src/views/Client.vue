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
    name: "cliente",
    components: {
      AuthorsTable,
    },
    mounted() {
        this.getClientes();
    },
    data() {
        return {
            authorsList: [],
            func_auth: 'Cliente'
        };
    },
    methods: {
        async getClientes() {
            
            axios.get('https://localhost:5001/cliente')
                .then(res => {
                    this.authorsList = res.data.value.clientes;
                })
                .catch(error => {
                    if (error.response && error.response.data) {
                        this.error_msg = error.response.data.title;
                    } else {
                        this.error_msg = error.message;
                    }

                    console.log('error...');
                    console.log(error);
                })
        }
    }
  };
  </script>
  