<template>
    <div class="header">
        <h1>Update Student</h1>
    </div>
    <div class="container">
        <form @submit="onSubmit" class="add-form">
            <div class="row">
                <div class="col-25">
                    <label for="name">First name:</label><br>
                </div>
                <div class="col-75">
                    <input v-model="student.name" type="text" placeholder="Enter your first name" /><br>
                </div>
            </div>
            <div class="row">
                <div class="col-25">
                    <label for="surname">Last name:</label><br>
                </div>
                <div class="col-75">
                    <input v-model="student.surname" type="text" placeholder="Enter your last name" /><br>
                </div>
            </div>
            <div class="row">
                <div class="col-25">
                    <label for="indexNumber">Index Number:</label><br>
                </div>
                <div class="col-75">
                    <input v-model="student.indexNumber" type="text" placeholder="Enter your index number" /><br>
                </div>
            </div>
            <div class="row">
                <div class="col-25">
                    <label for="year">Year</label><br>
                </div>
                <div class="col-75">
                    <input v-model="student.year" type="number" placeholder="Enter year" /><br>
                </div>
            </div>
            <div class="row">
                <div class="col-25">
                    <label for="studentStatus">Student status:</label><br>
                </div>
                <div class="col-75">
                    <input v-model="student.statusName" type="text" disabled /><br>
                    <select v-model="student.studentStatus" style="margin-top:5px;">
                        <option disabled value="">Please select one</option>
                        <option value=1>Redovan</option>
                        <option value=2>Vanredan</option>
                    </select>
                </div>
            </div>
            <div class="row">
                <input class="submit" type="submit" value="Submit">
                <button>
                    <router-link to="/" style="color:white; text-decoration:none;">Back to List</router-link>
                </button>
            </div>
        </form>
    </div>
</template>

<script>
import api from '@/StudentsApiService';

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
    name: "UpdateStudent",
    methods: {
        onSubmit(e) {

            e.preventDefault()
            const newInformation = {
                studentId: this.student.studentId,
                name: this.student.name,
                surname: this.student.surname,
                indexNumber: this.student.indexNumber,
                year: this.student.year,
                studentStatus: {
                    statusName: this.student.statusName,
                    studentStatusId: this.student.studentStatusId
                },
                studentStatusId: this.student.studentStatusId
            }
            if (newInformation.studentStatus.statusName == undefined) {
                newInformation.studentStatus.statusName = ""
            }
            api.update(newInformation.studentId, newInformation).then(this.$router.push('/'));
        }
    },

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

.col-75 {
    float: left;
    width: 75%;
    margin-top: 6px;
}
</style>
