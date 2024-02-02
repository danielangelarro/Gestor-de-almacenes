import { createRouter, createWebHistory } from "vue-router";
import { isAuthenticated, logout } from "@/store/auth"
import Dashboard from "@/views/Dashboard.vue";
import Inventory from "@/views/Inventario.vue";
import Rack from "@/views/Rack.vue";
import RackWait from "@/views/RackWait.vue";
import Entrada from "@/views/Entrada.vue";
import Salida from "@/views/Salida.vue";
import Merma from "@/views/Merma.vue";
import Tables from "@/views/Tables.vue";
import Cliente from "@/views/Client.vue";
import Proveedor from "@/views/Proveedor.vue";
import Billing from "@/views/Billing.vue";
import VirtualReality from "@/views/VirtualReality.vue";
import Profile from "@/views/Profile.vue";
import Rtl from "@/views/Rtl.vue";
import SignIn from "@/views/SignIn.vue";
import SignUp from "@/views/SignUp.vue";
import CasilleroTable from "@/views/components/CasilleroTable.vue" ;

const routes = [
  {
    path: "/",
    name: "/",
    redirect: "/dashboard",
  },
  {
    path: "/logout",
    name: "Logout",
    beforeEnter: (to, from, next) => {
      logout();
      next('/sign-in');
    },
    meta: { requiresAuth: true }
  },
  {
    path: "/dashboard",
    name: "Dashboard",
    component: Dashboard,
    meta: { requiresAuth: true }
  },
  {
    path: "/inventory",
    name: "Inventario",
    component: Inventory,
    meta: { requiresAuth: true }
  },
  {
    path: "/rack",
    name: "Rack",
    component: Rack,
    meta: { requiresAuth: true }
  },
  {
    path: "/rack-wait",
    name: "RackWait",
    component: RackWait,
    meta: { requiresAuth: true }
  },
  {
    path: "/entry",
    name: "Entrada",
    component: Entrada,
    meta: { requiresAuth: true }
  },
  {
    path: "/exit",
    name: "Salida",
    component: Salida,
    meta: { requiresAuth: true }
  },
  {
    path: "/merma",
    name: "Merma",
    component: Merma,
    meta: { requiresAuth: true }
  },
  {
    path: '/casilleros/:id_rack/:pasillo/:rows/:columns',
    name: 'Casillero',
    component: CasilleroTable,
    props: true,
    meta: { requiresAuth: true }
  },
  {
    path: "/cliente",
    name: "Cliente",
    component: Cliente,
    meta: { requiresAuth: true }
  },
  {
    path: "/proveedor",
    name: "Proveedor",
    component: Proveedor,
    meta: { requiresAuth: true }
  },
  {
    path: "/tables",
    name: "Tables",
    component: Tables,
    meta: { requiresAuth: true }
  },
  {
    path: "/billing",
    name: "Billing",
    component: Billing,
    meta: { requiresAuth: true }
  },
  {
    path: "/virtual-reality",
    name: "Virtual Reality",
    component: VirtualReality,
    meta: { requiresAuth: true }
  },
  {
    path: "/profile",
    name: "Profile",
    component: Profile,
    meta: { requiresAuth: true }
  },
  {
    path: "/rtl-page",
    name: "Rtl",
    component: Rtl,
    meta: { requiresAuth: true }
  },
  {
    path: "/sign-in",
    name: "Sign In",
    component: SignIn,
    meta: { guest: true }
  },
  {
    path: "/sign-up",
    name: "Sign Up",
    component: SignUp,
    meta: { guest: true }
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
  linkActiveClass: "active",
});

router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresAuth)) {
    // esta ruta requiere autenticación, comprobar si el usuario está autenticado
    // si no, redirigir a la página de inicio de sesión.
    if (!isAuthenticated()) {
      next({
        path: '/sign-in',
        query: { redirect: to.fullPath }
      })
    } else {
      next()
    }
  } else if (to.matched.some(record => record.meta.guest)) {
    // esta ruta solo está disponible para usuarios no autenticados
    // si el usuario está autenticado, redirigir a la página de inicio
    if (isAuthenticated()) {
      next({
        path: '/dashboard',
        query: { redirect: to.fullPath }
      })
    } else {
      next()
    }
  } else {
    next() // asegurarse de que siempre se llame a next()
  }
})

export default router;
