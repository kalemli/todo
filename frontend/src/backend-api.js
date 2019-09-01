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
    saveCategory(id, category) {
        return AXIOS.put(`/category/${id}`, category);
    },
    deleteCategory(id) {
        return AXIOS.delete(`/category/${id}`);
    },
}
