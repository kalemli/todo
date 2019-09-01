import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    { path: '/', name: 'home', component: Home },
    { path: '/about', name: 'about', component: () => import('./views/About.vue') },
    { path: '/categories', name: 'categories', component: () => import('./views/todo/Categories.vue') },
    { path: '/daily', name: 'daily', component: () => import('./views/todo/Daily.vue') },
    { path: '/monthly', name: 'monthly', component: () => import('./views/todo/Monthly.vue') },
    { path: '/byCategories/:id', name: 'byCategories', props: true, component: () => import('./views/todo/ByCategories.vue') },
  ]
})
