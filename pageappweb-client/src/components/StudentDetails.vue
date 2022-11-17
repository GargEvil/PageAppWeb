<template>
    <div class="header">
        <h1>Student Details</h1>
    </div>
    <div class="container">
        <div class="form-group">
            <div class="form-control">
                <label>Student name</label>
                <div>{{ student.name }} {{ student.surname }}</div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-control">
                <label>Index Number</label>
                <div>{{ student.indexNumber }}</div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-control">
                <label>Year</label>
                <div>{{ student.year }}</div>
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
import onActivated from 'vue'
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
    name: "StudentDetails"

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
