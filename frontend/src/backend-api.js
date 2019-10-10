import axios from 'axios'

const AXIOS = axios.create({
  baseURL: `http://localhost:5050/api/`,
  timeout: 60000
});

export default {
    loadCategories() {
        return AXIOS.get(`/categories`);
    },
    addCategory(category) {
        return AXIOS.post('/category', category);
    },
    saveCategory(category) {
        return AXIOS.put(`/category/${category.id}`, category);
    },
    deleteCategory(id) {
        return AXIOS.delete(`/category/${id}`);
    },

    loadTasks(categoryId) {
        return AXIOS.get(`/tasks/${categoryId}`);
    },
    addTask(task) {
        return AXIOS.post('/task', task);
    },
    saveTask(task) {
        return AXIOS.put(`/task/${task.id}`, task);
    },
    deleteTask(id) {
        return AXIOS.delete(`/task/${id}`);
    },
}
