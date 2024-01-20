<template>
  <div class="card mb-4">
    <soft-alert v-show="showConfirm" color="dark" class="font-weight-light m-4">
      <p>Está seguro de querer borrar este producto?</p>
      <soft-button @click="deleteProduct(); showConfirm = false;">Confirmar</soft-button>
      <span>&nbsp;</span>
      <soft-button color="danger" @click="showConfirm = false;">Cancelar</soft-button>
    </soft-alert>

    <div class="card-header pb-0">
      <h6 v-if="table_title != ''">{{ table_title }}</h6>
      <h6 v-else>Productos en la Casilla</h6>
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
                Nombre
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2"
              >
                Tipo
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2"
              >
                Dimensiones
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder text-center opacity-7 ps-2"
              >
                Peso
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder text-center opacity-7 ps-2"
              >
                Cantidad
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder text-center opacity-7 ps-2"
              >
                Fecha de Entrada
              </th>
              <th
                class="text-uppercase text-secondary text-xxs font-weight-bolder text-center opacity-7 ps-2"
              >
                Fecha de Caducidad
              </th>
              <th v-show="!only_view"></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="product in this.products" :key="product['iD_Ubicacion']">
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
                    <h6 class="mb-0 text-sm">{{ product.nombre }}</h6>
                  </div>
                </div>
              </td>
              <td>
                <p class="text-sm font-weight-bold mb-0">{{ product.tipo }}</p>
              </td>
              <td>
                <span class="text-xs font-weight-bold">
                  {{ product.alto }} x {{ product.ancho }} x {{ product.largo }} {{ product.unidad_Dimensions }}<sup>3</sup>
                </span>
              </td>
              <td class="align-middle text-center">
                <span class="text-xs font-weight-bold">{{ product.peso }}</span>
              </td>
              <td class="align-middle text-center">
                <span class="text-xs font-weight-bold">{{ product.cantidad }}</span>
              </td>
              <td class="align-middle text-center">
                <span class="text-xs font-weight-bold">{{ formatDate(product.fecha_Llegada) }}</span>
              </td>
              <td class="align-middle text-center">
                <span class="text-xs font-weight-bold">{{ formatDate(product.fecha_Caducidad) }}</span>
              </td>
              <td v-show="!only_view" class="align-middle">
                <div v-if="state_wait">
                  
                  <soft-switch
                    :id="product['iD_Ubicacion']"
                    :name="product['iD_Ubicacion']"

                    @change="handleSwitchChange(product)"

                    label-class="mb-0 text-body ms-3 text-truncate w-80"
                    class="ps-0 ms-auto"
                  >Reservar</soft-switch>

                  <input v-model="product.quantity" type="number" @change="handleSwitchChange(product)">
                </div>

                <a
                  v-else-if="!product.confirmar_Guardado"
                  @click="$emit('emit-product-confirm', product['iD_Ubicacion'])"
                  href="#"
                  class="text-dark font-weight-bold text-xs"
                  data-toggle="tooltip"
                  data-original-title="Editar producto"
                  >
                  <i class="fa fa-floppy-o">&nbsp;|&nbsp;&nbsp;&nbsp;Confirmar</i>
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
import SoftSwitch from '@/components/SoftSwitch.vue';

export default {
  name: "inventory-casillero-table",
  components: {
    SoftAlert,
    SoftButton,
    SoftSwitch
  },
  props: {
    only_view: {
      type: Boolean,
      default: false
    },
    table_title: {
      type: String,
      default: ''
    },
    state_wait: {
      type: Boolean,
      default: false
    },
    ubicacion_old_id: {
      type: String,
      default: ""
    },
    products: {
      type: Array,
      default: () => {}
    }
  },
  data() {
    return {
      showConfirm: false,
      productToDelete: null,
      error_msg: ''
    };
  },
  methods: {
    showDetail(id) {
      this.$emit('product-selected', id);
    },

    formatDate(fecha) {
      let date = new Date(fecha);
      let opciones = { year: 'numeric', month: 'long', day: 'numeric'};

      return date.toLocaleDateString('es-ES', opciones);
    },

    async confirmDelete(id) {
      this.productToDelete = id;
      this.showConfirm = true;
    },

    handleSwitchChange(product) {
        let quantity = product.quantity;
        product.selected = !product.selected;

        if (product.selected) {
            if (quantity <= 0) {
              product.quantity = 0;
              this.error_msg = "La cantidad del producto debe ser mayor que 0 para ser seleccionado.";
            }

            else if (quantity > product.cantidad) {
              product.quantity = 0;
              this.error_msg = "Ha superado el límite de la cantidad de ése producto."
            }

            else {
              this.error_msg = '';
              this.$emit('add-product', product, quantity);
            }

        } else {  
          product.quantity = 0;
          this.$emit('remove-product', product, quantity);
        }
    },

  }
};
</script>
