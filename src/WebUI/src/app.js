// Vue Package
import Vue from 'vue'
import router from './router'
import i18n from './translate/translate.js'
import store from './store/store.js'
import BootstrapVue from 'bootstrap-vue'
import app from './app.vue'


// Vue Config
Vue.config.productionTip = false
Vue.use(BootstrapVue)


// Global CSS
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import './template/template.css'
import './template/_variables.scss'
import './template/_bootstrap-custom.scss'
import './template/_custom.scss'


// Vue Instanse
new Vue({
  el: '#app',
  router,
  i18n,
  store,
  render: h => h(app)
})