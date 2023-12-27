<template>
  <div class="py-4 container-fluid">
    <div class="row">
      <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
        <mini-statistics-card
          :title="{ text: 'Ganancia Semanal', value: '$53k' }"
          detail="<span class='text-success text-sm font-weight-bolder'>+55%</span> que la última semana"
          :icon="{
            name: 'ni ni-money-coins',
            color: 'text-white',
            background: iconBackground,
          }"
        />
      </div>
      <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
        <mini-statistics-card
          :title="{ text: 'Ganancia Mensual', value: '$2,300' }"
          detail="<span class='text-success text-sm font-weight-bolder'>+3%</span> que el último mes"
          :icon="{
            name: 'ni ni-money-coins',
            color: 'text-white',
            background: iconBackground,
          }"
        />
      </div>
      <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
        <mini-statistics-card
          :title="{ text: 'Entradas', value: '462' }"
          detail="<span class='text-danger text-sm font-weight-bolder'>-2%</span> que el último mes"
          :icon="{
            name: 'ni ni-cart',
            color: 'text-white',
            background: iconBackground,
          }"
        />
      </div>
      <div class="col-xl-3 col-sm-6 mb-xl-0">
        <mini-statistics-card
          :title="{ text: 'Salidas', value: '1,430' }"
          detail="<span class='text-success text-sm font-weight-bolder'>+5%</span> que el último mes"
          :icon="{
            name: 'ni ni-cart',
            color: 'text-white',
            background: iconBackground,
          }"
        />
      </div>
    </div>
    <div class="mt-4 row">
      <div class="mb-4 col-lg-5 mb-lg-0">
        <div class="card z-index-2">
          <div class="p-3 card-body">
            <reports-bar-chart
              id="chart-bar"
              title="Total de ventas"
              :color=iconBackground
              :chart="{
                labels: [
                  'Enero',
                  'Febrero',
                  'Marzo',
                  'Abril',
                  'Mayo',
                  'Junio',
                  'Julio',
                  'Agosto',
                  'Septiembre',
                  'Octubre',
                  'Noviembre',
                  'Diciembre',
                ],
                datasets: {
                  label: 'Ventas',
                  data: [450, 200, 100, 220, 500, 100, 400, 230, 500, 450, 200, 100],
                },
              }"
              :items="[
                {
                  icon: {
                    color: 'primary',
                    component: faUsers,
                  },
                  label: 'Proveedores',
                  progress: { content: '37K', percentage: 60 },
                },
                {
                  icon: { color: 'info', component: faHandPointer },
                  label: 'Clientes',
                  progress: { content: '2m', percentage: 90 },
                },
                {
                  icon: { color: 'warning', component: faCreditCard },
                  label: 'Ventas',
                  progress: { content: '435$', percentage: 30 },
                },
                {
                  icon: { color: 'danger', component: faScrewdriverWrench },
                  label: 'Productos',
                  progress: { content: '43', percentage: 50 },
                },
              ]"
            />
          </div>
        </div>
      </div>
      <div class="col-lg-7">
        <!-- line chart -->
        <div class="card z-index-2">
          <gradient-line-chart
            id="chart-line"
            title="Gradient Line Chart"
            description="<i class='fa fa-arrow-up text-success'></i>
      <span class='font-weight-bold'>4% more</span> in 2021"
            :chart="{
              labels: [
                'Apr',
                'May',
                'Jun',
                'Jul',
                'Aug',
                'Sep',
                'Oct',
                'Nov',
                'Dec',
              ],
              datasets: [
                {
                  label: 'Mobile Apps',
                  data: [50, 40, 300, 220, 500, 250, 400, 230, 500],
                },
                {
                  label: 'Websites',
                  data: [30, 90, 40, 140, 290, 290, 340, 230, 400],
                },
              ],
            }"
          />
        </div>
      </div>
    </div>
    <div class="row my-4">
      <div class="col-lg-8 col-md-6 mb-md-0 mb-4">
        <projects-card />
      </div>
      <div class="col-lg-4 col-md-6">
        <timeline-list
          class="h-100"
          title="Orders overview"
          description="<i class='fa fa-arrow-up text-success' aria-hidden='true'></i>
        <span class='font-weight-bold'>24%</span> this month"
        >
          <timeline-item
            color="success"
            icon="bell-55"
            title="$2400 Design changes"
            date-time="22 DEC 7:20 PM"
          />
          <TimelineItem
            color="danger"
            icon="html5"
            title="New order #1832412"
            date-time="21 DEC 11 PM"
          />
          <TimelineItem
            color="info"
            icon="cart"
            title="Server payments for April"
            date-time="21 DEC 9:34 PM"
          />
          <TimelineItem
            color="warning"
            icon="credit-card"
            title="New card added for order #4395133"
            date-time="20 DEC 2:20 AM"
          />
          <TimelineItem
            color="primary"
            icon="key-25"
            title="Unlock packages for development"
            date-time="18 DEC 4:54 AM"
          />
          <TimelineItem
            color="info"
            icon="check-bold"
            title="Notifications unread"
            date-time="15 DEC"
          />
        </timeline-list>
      </div>
    </div>
  </div>
</template>
<script>
import MiniStatisticsCard from "@/examples/Cards/MiniStatisticsCard.vue";
import ReportsBarChart from "@/examples/Charts/ReportsBarChart.vue";
import GradientLineChart from "@/examples/Charts/GradientLineChart.vue";
import TimelineList from "./components/TimelineList.vue";
import TimelineItem from "./components/TimelineItem.vue";
import ProjectsCard from "./components/ProjectsCard.vue";
import US from "../assets/img/icons/flags/US.png";
import DE from "../assets/img/icons/flags/DE.png";
import GB from "../assets/img/icons/flags/GB.png";
import BR from "../assets/img/icons/flags/BR.png";
import {
  faHandPointer,
  faUsers,
  faCreditCard,
  faScrewdriverWrench,
} from "@fortawesome/free-solid-svg-icons";
export default {
  name: "dashboard-default",
  data() {
    return {
      iconBackground: "info",
      faCreditCard,
      faScrewdriverWrench,
      faUsers,
      faHandPointer,
      sales: {
        us: {
          country: "United States",
          sales: 2500,
          value: "$230,900",
          bounce: "29.9%",
          flag: US,
        },
        germany: {
          country: "Germany",
          sales: "3.900",
          value: "$440,000",
          bounce: "40.22%",
          flag: DE,
        },
        britain: {
          country: "Great Britain",
          sales: "1.400",
          value: "$190,700",
          bounce: "23.44%",
          flag: GB,
        },
        brasil: {
          country: "Brasil",
          sales: "562",
          value: "$143,960",
          bounce: "32.14%",
          flag: BR,
        },
      },
    };
  },
  components: {
    MiniStatisticsCard,
    ReportsBarChart,
    GradientLineChart,
    ProjectsCard,
    TimelineList,
    TimelineItem,
  },
};
</script>
