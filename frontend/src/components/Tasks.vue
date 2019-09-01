<template>
  <div class="card shadow mb-4">
    <div class="card-header py-3">
      <h6 class="m-0 font-weight-bold text-primary">DataTables Example</h6>
    </div>
    <div class="card-body">
      <div class="table-responsive">
        <v-data-table dense
          :headers="headers"
          :items="tasks"
          :items-per-page="5"
          class="elevation-1"
        ></v-data-table>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Tasks',
  data() {
    return {
      headers: [
        { text: 'Name', value: 'name' },
        { text: 'Position', value: 'position' },
        { text: 'Office', value: 'office' },
        { text: 'Age', value: 'age' },
        { text: 'Start date', value: 'startDate' },
        { text: 'Salary', value: 'salary' }
      ],
      tasks: [
        {
          name: 'Donna Snider',
          position: 'Customer Support',
          office: 'New York',
          age: 27,
          startDate: '2011/01/25',
          salary: '$112,000'
        },
        {
          name: 'Michael Bruce',
          position: 'Javascript Developer',
          office: 'Singapore',
          age: 29,
          startDate: '2011/06/27',
          salary: '$183,000'
        },
        {
          name: 'Shad Decker',
          position: 'Regional Director',
          office: 'Edinburgh',
          age: 51,
          startDate: '2008/11/13',
          salary: '$183,000'
        },
        {
          name: 'Jonas Alexander',
          position: 'Developer',
          office: 'San Francisco',
          age: 30,
          startDate: '2010/07/14',
          salary: '$86,500'
        },
        {
          name: 'Lael Greer',
          position: 'Systems Administrator',
          office: 'London',
          age: 21,
          startDate: '2009/02/27',
          salary: '$103,500'
        }
      ]
    }
  }
}
</script>