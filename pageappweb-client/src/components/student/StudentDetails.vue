<template>
    <div class="header">
        <h1>Student Details</h1>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-25">
                <label for="name">First name:</label><br>
            </div>
            <div class="col-75">
                <div>{{ student.name }} </div>
            </div>
        </div>
        <div class="row">
            <div class="col-25">
                <label for="surname">Last name:</label><br>
            </div>
            <div class="col-75">
                <div>{{ student.surname }}</div>
            </div>
        </div>
        <div class="row">
            <div class="col-25">
                <label for="indexNumber">Index Number:</label><br>
            </div>
            <div class="col-75">
                <div>{{ student.indexNumber }}</div>
            </div>
        </div>
        <div class="row">
            <div class="col-25">
                <label for="year">Year</label><br>
            </div>
            <div class="col-75">
                <div>{{ student.year }}</div>
            </div>
        </div>
        <div class="row">
            <div class="col-25">
                <label for="studentStatus">Student status:</label><br>
            </div>
            <div class="col-75">
                <div>{{ student.statusName }}</div>
            </div>
            <button>
                <router-link to="/" style="color:white; text-decoration:none;">Back to List</router-link>
            </button>
        </div>

    </div>

</template>

<script>
import onActivated from 'vue'
export default {
    data() {
        return {
            student: {},
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

button {
    height: 41px;
    color: white;
}

label {
    padding: 12px 12px 12px 0;
    display: inline-block;
}

input[type=submit],
button {
    background-color: #04AA6D;
    color: white;
    padding: 12px 20px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    float: right;
    margin: 5px;
}

input[type=submit]:hover {
    background-color: #45a049;

}

.container {
    border-radius: 5px;
    background-color: #f2f2f2;
    padding: 20px;
}

.col-25 {
    float: left;
    width: 25%;
    margin-top: 6px;
}

.col-75 {
    float: left;
    width: 75%;
    margin-top: 6px;
}

.row {
    margin-top: 1%;
}

.row:after {
    content: "";
    display: table;
    clear: both;
}
</style>
