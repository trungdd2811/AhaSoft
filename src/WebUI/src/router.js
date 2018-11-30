import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

function loadPage (page) {
    return () => import(/* webpackChunkName: "view-[request]" */ `./pages/${page}/${page}.vue`)
}

export default new Router({
    // mode: 'history', // https://router.vuejs.org/guide/essentials/history-mode.html
    // eslint-disable-next-line no-undef
    base: process.env.BASE_URL,
    routes: [
        {
            path: '/',
            name: 'home',
            component: loadPage('home') // pages/home.vue
        },
        {
            path: '/sales',
            name: 'sales',
            component: loadPage('sales')
        }
    ]
})
