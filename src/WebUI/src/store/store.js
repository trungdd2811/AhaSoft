import Vue from 'vue'
import Vuex from 'vuex'
import header_block from './modules/header-block'
import page_home from './modules/page-home'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    header_block,
    page_home
  }
})
