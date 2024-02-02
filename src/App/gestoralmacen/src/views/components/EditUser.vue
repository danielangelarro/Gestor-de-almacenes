<template>
    <div class="card h-100">
        <div class="text-center card-header p-3 pb-0">
            <h6>Editar Usuario</h6>
        </div>
        <div class="p-3 card-body">
            <form role="form" @submit.prevent="editProfile">
                <div class="mb-3">
                    <soft-input :value="file" @input="event => file = event.target.value" id="file" type="file"
                        placeholder="Foto" aria-label="Foto" />
                </div>
                <div class="mb-3">
                    <soft-input :value="name" @input="event => name = event.target.value" id="name" type="text"
                        placeholder="Name" aria-label="Name" />
                </div>
                <div class="mb-3">
                    <soft-input :value="lastname" @input="event => lastname = event.target.value" id="lastname" type="text"
                        placeholder="Last Name" aria-label="LastName" />
                </div>
                <div class="mb-3">
                    <soft-input :value="email" @input="event => email = event.target.value" id="email" type="email"
                        placeholder="Email" aria-label="Email" />
                </div>
                <div class="mb-3">
                    <soft-input :value="password" @input="event => password = event.target.value" id="password"
                        type="password" placeholder="Password" aria-label="Password" />
                </div>
                
                <div class="mb-3">
                    <soft-input :value="rol" @input="event => rol = event.target.value" id="rol"
                        type="text" placeholder="Rol" aria-label="Rol" />
                </div>

                <soft-alert v-if="error_msg != ''" class="font-weight-light" color="danger" dismissible>
                    <span class="text-sm">{{ error_msg }}</span>
                </soft-alert>

                <div class="row">
                    <div class="col text-center">
                        <soft-button @click="cancel=true" color="danger" full-width variant="gradient" class="my-4 mb-2">Cancelar</soft-button>
                    </div>
                    
                    <div class="col text-center">
                        <soft-button color="success" full-width variant="gradient" class="my-4 mb-2">Guardar</soft-button>
                    </div>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
import SoftInput from "@/components/SoftInput.vue";
import SoftButton from "@/components/SoftButton.vue";
import { API_URL } from '@/config';

import { mapMutations } from "vuex";
import axios from 'axios';

export default {
  name: "edit-user",
  props: ['user'],
  components: {    
    SoftInput,
    SoftButton,
  },
  data() {
    return {
      file: null,
      name: this.user.firstName,
      lastname: this.user.lastName,
      email: this.user.email,
      password: '',
      rol: 'Almacenero',
      cancel: false,
      flexCheckDefault: false,
      error_msg: ''
    };
  },
  created() {
    this.toggleEveryDisplay();
    this.toggleHideConfig();
  },
  beforeUnmount() {
    this.toggleEveryDisplay();
    this.toggleHideConfig();
  },
  methods: {
    ...mapMutations(["toggleEveryDisplay", "toggleHideConfig"]),

    async editProfile() {
      
      if (this.cancel){
          this.$emit("edit-user-end");
      }

      let formData = new FormData();
      formData.append("file", this.file);

      try {
        const response = await axios.post(`${API_URL}/auth/edit-user`, {
          firstname: this.name,
          lastname: this.lastname,
          email: this.email,
          password: this.password,
          rol: this.rol,
          file: formData
        },{
          headers: {
            'Content-Type': 'multipart/form-data'
          }
        });

        if (response.status == 200) {
            this.$emit('edit-user-end');
        }
      } catch (error) {
        if (error.response && error.response.data) {
          this.error_msg = error.response.data.title;
        } else {
          this.error_msg = error.message;
        }
      }
    }
  },
};
</script>
