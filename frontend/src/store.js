import Vue from 'vue'
import Vuex from 'vuex'
import api from '@/backend-api'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    categories: []
  },
  mutations: {

  },
  actions: {
    loadCategories(context) {
      api.loadCategories().then(response => { 
        context.state.categories = response.data
      })
    },
    saveCategory(context, category) {
      console.log(category)
      if (category.id)
        api.saveCategory(id, category).then(response => context.dispatch('loadCategories'))
      else
        api.addCategory(category).then(response => context.dispatch('loadCategories'))
    },
    deleteCategory(context, id) {
      api.deleteCategory(id).then(response => context.dispatch('loadCategories'))      
    }
  },
  getters: {
    topCategories: state => {
      return state.categories.filter(category => category.parent == null)
    },
    subCategories: (state) => (parentId) => {
      return state.categories.filter(category => category.parentId == parentId)
    }
  }
})
