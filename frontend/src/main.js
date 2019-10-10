import Vue from 'vue'
import 'bootstrap'
import './assets/app.scss'
import './assets/sb-admin-2.scss'
import App from './App.vue'
import router from './router'
import store from './store'
//import vuetify from '@/plugins/vuetify'
import '@/plugins/antd'

Vue.config.productionTip = false

new Vue({
  router,
  store,
  //vuetify,
  render: h => h(App)
}).$mount('#app')
