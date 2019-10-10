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
      if (category.id)
        api.saveCategory(category).then(() => context.dispatch('loadCategories'))
      else
        api.addCategory(category).then(() => context.dispatch('loadCategories'))
    },
    deleteCategory(context, id) {
      api.deleteCategory(id).then(() => context.dispatch('loadCategories'))      
    },

    saveTask(context, task) {
      if (task.id)
        api.saveTask(task).then(() => { })
      else
        api.addTask(task).then(() => { })
    },
    deleteTask(context, id) {
      api.deleteTask(id).then(() => { })
    }    
  },
  getters: {
    topCategories: state => {
      return state.categories.filter(category => category.parent == null)
    },
    subCategories: (state) => (parentId) => {
      parentId = parentId == '' ? null : parentId;
      return state.categories.filter(category => category.parentId == parentId)
    },
    getCategory: (state) => (id) => {
      var list = state.categories.filter(category => category.id == id);
      return list.length > 0 ? list[0] : { };
    }
  }
})
