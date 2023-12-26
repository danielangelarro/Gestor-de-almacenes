<template>
    <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">
      <SidebarBrand />
      <NavItem v-for="item in items" :key="item.id" :item="item" />
    </ul>
  </template>
  
  <script>
  import SidebarBrand from './SidebarBrand.vue'
  import NavItem from './NavItem.vue'
  
  export default {
    name: 'Sidebar',
    components: {
      SidebarBrand,
      NavItem
    },
    data() {
      return {
        items: [
          // Your nav items data here
        ]
      }
    }
  }
  </script>
  
  <style scoped>
  /* CSS for Sidebar */
  </style>