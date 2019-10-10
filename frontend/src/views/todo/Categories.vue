<template>
  <div class="card shadow mb-4">
    <div class="card-header py-3">
      <h6 class="m-0 font-weight-bold text-primary">Categories</h6>
    </div>
    <div class="card-body">
      <div class="table-responsive">
        <div class="row mx-3">
            <div class="pt-5">
                <span class="h4 p-2" v-text="current.id"></span>
            </div>
            <div class="form-group col-md-4">
                <label for="categoryName">Name:</label>
                <input type="text" v-model="current.name" class="form-control form-control-sm" id="categoryName" placeholder="Category name">
            </div>
            <div class="form-group col-md-4">
                <label for="categoryGroup">Group:</label>
                <select v-model="current.parentId" class="form-control form-control-sm" id="categoryGroup">
                    <option></option>
                    <option v-for="category in topCategories" 
                            v-bind:key="category.id"
                            :value="category.id"
                    >{{ category.name }}</option>
                </select>
            </div>
            <div class="col-md-2 mt-4">
                <a href="#" @click="save" class="btn btn-success btn-circle btn-sm mx-1">
                    <i class="fas fa-plus"></i>
                </a>
                <a href="#" @click="cancel" class="btn btn-danger btn-circle btn-sm mx-1">
                    <i class="fas fa-times"></i>
                </a>
            </div>
        </div>
        <table class="table table-bordered table-hover table-sm mx-3">
            <thead class="thead-light">
                <tr>
                    <th scope="col" style="width: 60px">#</th>
                    <th scope="col">Name</th>
                    <th scope="col" style="width: 100px"> </th>
                </tr>
            </thead>
            <tr v-for="category in subCategories(current.parentId)" v-bind:key="category.id">
                <td>{{ category.id }}</td>
                <td>
                    <a href="#" @click="current = Object.assign({}, category)">{{ category.name }}</a>
                </td>
                <td>
                    <a href="#" @click="deleteCategory(category.id)">Delete</a>
                </td>
            </tr>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState, mapActions, mapGetters } from 'vuex'

export default {
    name: 'Categories',
    data() {
        return {
            current: { parentId: null }
        }
    },
    computed: {
        ...mapState([ 'categories' ]),
        ...mapGetters([ 'topCategories', 'subCategories' ])
    },
    methods: {
        ...mapActions(['loadCategories', 'saveCategory', 'deleteCategory' ]),
        cancel() {
            this.current = { parentId: null }
        },
        save() {
            this.saveCategory(this.current)
            this.cancel();
        }
    }
}
</script>