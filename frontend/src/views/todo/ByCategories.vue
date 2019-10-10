<template>
  <div class="card shadow mb-4">
    <div class="card-header py-1">
      <div class="row">
        <h6 class="m-0 font-weight-bold text-primary col-md-8 py-2">
            by Categories: <u class="text-uppercase">{{ getCategory(id).name }}</u>
        </h6>
        <select v-model="current.categoryId" class="form-control form-control-sm col-md-4 my-1">
            <option value="">All categories</option>
            <option v-for="category in subCategories(id)" 
                    v-bind:key="category.id"
                    :value="category.id"
            >{{ category.name }}</option>
        </select>
      </div>
    </div>
    <div class="card-body">
        <div class="row">
            <div class="form-group col-md-2">
                <a-date-picker v-model="current.taskDate" format="DD.MM.YYYY" placeholder="Task date" />
            </div>
            <div class="form-group col-md-2">
                <a-time-picker v-model="current.startTime" format="HH:mm" placeholder="Start time" />
            </div>
            <div class="form-group col-md-2">
                <a-time-picker v-model="current.endTime" format="HH:mm" placeholder="End time" />
            </div>
            <div class="form-group col-md-2">
                <a-time-picker v-model="current.delayTime" format="HH:mm" placeholder="Delay time" />
            </div>
            <div class="col-md-1">
                <a-button type="primary" @click="save">
                    {{ current.id == undefined ? 'Add' : 'Save'}}
                </a-button>
            </div>
            <div class="col-md-1">
                <a-button type="danger" @click="cancel">Cancel</a-button>
            </div>
        </div>        
        <a-table :columns="columns" :dataSource="tasks" :rowKey="task => task.id" size="small">
            <template slot="category" slot-scope="category">
              <a href="#" @click="current = task">{{category}}</a>
            </template>
        </a-table>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'
import api from '@/backend-api'

export default {
    props: [ 'id' ],
    data() {
        return {
            current: { },
            columns: [{
                title: '#',
                dataIndex: 'id',
                key: 'id'
            }, {
                title: 'Category:',
                dataIndex: 'category',
                scopedSlots: { customRender: 'category' },
            }, {
                title: 'Task date:',
                dataIndex: 'taskDay'
            }, {
                title: 'Start time:',
                dataIndex: 'start'
            },{
                title: 'End time:',
                dataIndex: 'end'
            },{
                title: 'Delayed:',
                dataIndex: 'delay'
            },{
                title: 'Period:',
                dataIndex: 'period'
            }],
            tasks: []
        }
    },
    //components: { Tasks },
    computed: {
        ...mapGetters([ 'getCategory', 'subCategories' ])
    },
    methods: {
        ...mapActions([ 'saveTask' ]),
        save() {
            this.saveTask(this.current);
        },
        cancel() {
            this.current = { };
        },
        loadTasks() {
            api.loadTasks(this.current.categoryId || this.id)
                .then(result => this.tasks = result.data);
        }
    },
    created() {
        this.loadTasks();
    },
}
</script>