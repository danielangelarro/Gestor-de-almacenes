<template>
    <li class="nav-item" :class="{ active: item.active }">
      <a class="nav-link" :href="item.href">
        <i :class="`fas fa-fw ${item.icon}`"></i>
        <span>{{ item.name }}</span>
      </a>
    </li>
  </template>
  
  <script>
  export default {
    name: 'NavItem',
    props: {
      item: {
        type: Object,
        required: true
      }
    }
  }
  </script>
  
  <style scoped>
  /* CSS for NavItem */
  </style>