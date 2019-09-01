<template>
    <div>
        By Categories {{id}}
        <Tasks></Tasks>
    </div>
</template>

<script>
import Tasks from '../../components/Tasks'

export default {
    props: [ 'id' ],
    components: { Tasks }
}
</script>