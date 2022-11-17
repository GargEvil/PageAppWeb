<template>
    <div class="header">
        <h1>Update Student</h1>
    </div>
    <div class="container">
        <div class="form-group">
            <div class="form-control">
                <label>Student name</label>
                <input type="text" v-model="student.name">
            </div>
        </div>
        <div class="form-group">
            <div class="form-control">
                <label>Index Number</label>
                <input type="text" v-model="student.indexNumber">
            </div>
        </div>
        <div class="form-group">
            <div class="form-control">
                <label>Year</label>
                <input type="text" v-model="student.year">
            </div>
        </div>
        <div class="form-group">
            <div class="form-control">
                <label>Student Status</label>
                <div>{{ student.studentStatus }}</div>
            </div>
        </div>
    </div>
</template>

<script>

export default {
    data() {
        return {
            student: {}
        }
    },
    mounted() {
        setTimeout(() => {
            this.student = this.$store.getters.student;
        }, 500);
    },
    name: "UpdateStudent"

};
</script>

<style>
.header {
    padding: 5px;
    text-align: center;
    background: #1abc9c;
    color: white;
    font-size: 30px;
}
</style>
