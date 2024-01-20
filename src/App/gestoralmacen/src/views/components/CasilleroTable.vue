<template>
  <div class="mt-4 p-4 row">

    <Teleport to="body">
      <casillero-view-info 
        :id="casilla.id" 
        :show="showModal" 
        @close="showModal = false" 
        @selected-items="closeModal"
      >
        <template #header>
          <h3>Casillero {{ casilla.index }} del Rack <b>{{ pasillo }}</b></h3>
        </template>
      </casillero-view-info>
    </Teleport>

    <edit-casillero-card
        v-show="show_edit"
        :casilleros_params="selectedItems"
        :id_casilleros="id_casilleros"
        @casillero-edited="getCasilleros"
        @casillero-cancel-edit="show_edit = false;"
    ></edit-casillero-card>
    
    <reservar-casillero-card
        v-show="show_reservar"
        :casilleros_params="selectedItems"
        :id_casilleros="id_casilleros"
        :change_selection="change_selection"
        @casillero-edited="getCasilleros"
        @casillero-cancel-edit="show_reservar = false;"
        @emit-product-reserve="resetPage"
    ></reservar-casillero-card>

    <div class="col-12">
      <div class="mb-4">
        <div class="p-3 pb-0 text-center">
          <soft-badge color="danger" variant="gradient" size="sm">Rack: {{ id }}</soft-badge>
        </div>
        <soft-alert v-if="error_msg != ''" class="font-weight-light" color="danger" dismissible>
          <span class="text-sm">{{ error_msg }}</span>
        </soft-alert>
      </div>
    </div>

    <div class="d-flex justify-content-end">
      <button 
        class="btn col-1"
        :class="btnSelectBackgroundColor"
        @click="btnSelectedPress()"
      >Seleccionar</button>
      
      <button 
        v-show="selectedPress && !show_edit"
        class="btn col-1 mx-3 btn-success"
        @click="show_edit = true"
      >Editar</button>
      
      <button 
        v-show="selectedPress && !show_reservar"
        class="btn col-1 mx-3 btn-success"
        @click="show_reservar = true"
      >Reservar</button>
    </div>

    <div class="card-body pt-0 pb-2">
      <div :style="gridStyle" class="">
        <div 
          v-for="item in casilleros.sort((a, b) => a.index - b.index)" 
          :key="item.index" 
          class="grid-item"
          id="show-modal"
          :class="{ 'selected': selectedItems.includes(item) }"
          @click="selectItem(item, item.index)"
          >
          {{ item.index }}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import SoftBadge from "@/components/SoftBadge.vue";
import CasilleroViewInfo from "./CasilleroViewInfo.vue";
import EditCasilleroCard from "./EditCasilleroCard.vue";
import ReservarCasilleroCard from "./ReservarCasilleroCard.vue";
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    name: 'casillero-table',
    props: ['id_rack', 'pasillo', 'rows', 'columns'],
    components: {
        SoftBadge,
        CasilleroViewInfo,
        EditCasilleroCard,
        ReservarCasilleroCard
    },
    data() {
      return {
        casilla: {
          id: 0,
          index: 0
        },
        adminMode: true,
        showModal: false,
        showInfo: false,
        show_edit: false,
        show_reservar: false,
        selectedPress: false,
        change_selection: false,
        selectedItems: [],
        casilleros: [],
        id_casilleros: []
      };
    },
    mounted() {
      this.getCasilleros();
    },
    computed: {
      btnSelectBackgroundColor() {
        return this.selectedPress ? 'btn-danger' : 'btn-success';
      },
      items() {
        return Array.from({length: this.rows * this.columns}, (_, i) => i + 1)
      },
      gridStyle() {
        return {
          display: 'grid',
          gridTemplateColumns: `repeat(${this.columns}, 50px)`,
          gridGap: '10px',
          justifyContent: 'center'
        }
      }
    },
    methods: {
        resetPage() {
          this.getCasilleros();
        },

        selectItem(item, index_casilla) {

          if (!this.selectedPress) {
            this.casilla = { 
              id: item.iD_Casillero,
              index: index_casilla + 1
            };
            this.showModal = true;
            
            return;
          }

          const index = this.selectedItems.indexOf(item);
          if (index >= 0) {
            this.selectedItems.splice(index, 1);
            this.id_casilleros.splice(index, 1);
          } else {
            this.selectedItems.push(item);
            this.id_casilleros.push(index_casilla);
          }

          this.change_selection = !this.change_selection;
        },

        btnSelectedPress() {
          this.selectedPress = !this.selectedPress;

          if (!this.selectedPress) {
            this.show_edit = false;
            this.show_reservar = false;
            this.selectedItems = [];
            this.id_casilleros = [];
          }
        },

        async getCasilleros() {
            axios.get(`${API_URL}/casillero/rack/${this.id_rack}`)
                .then(res => {
                    this.casilleros = res.data.value['casilleros'];
                  })
                  .catch(error => {
                    if (error.response && error.response.data) {
                      this.error_msg = error.response.data.title;
                    } else {
                      this.error_msg = error.message;
                    }
                });
        },
    },
};
</script>

<style>
.grid-item {
  border: 2px solid; /* Borde de las casillas */
  padding: 10px; /* Espacio interior de las casillas */
  border-radius: 10px;
  width: 50px;
  height: 50px;
}

.grid-item.selected {
  background-color: #82d616;
}
</style>
