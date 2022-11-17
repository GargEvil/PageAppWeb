<template>
    <div class="header">
        <h1>Create Student</h1>
    </div>
    <form @submit="onSubmit" class="add-form">
        <label for="name">First name:</label><br>
        <input v-model="student.name" type="text" placeholder="Enter your first name" /><br>
        <label for="surname">Last name:</label><br>
        <input v-model="student.surname" type="text" placeholder="Enter your last name" /><br>
        <label for="indexNumber">Index Number:</label><br>
        <input v-model="student.indexNumber" type="text" placeholder="Enter your index number" /><br>
        <label for="year">Year</label><br>
        <input v-model="student.year" type="number" placeholder="Enter year" /><br>
        <label for="studentStatus">Student status:</label><br>
        <select v-model="student.studentStatus">
            <option disabled value="">Please select one</option>
            <option value=1>Redovan</option>
            <option value=2>Vanredan</option>
        </select>
        <input class="submit" type="submit" value="Submit">
    </form>
</template>


<script>

import api from '@/StudentsApiService';

export default {
    data() {
        return {
            student: {
                name: "",
                surname: "",
                indexNumber: "",
                year: "",
                selected: ""
            }
        }

    },
    name: "CreateStudent",
    props: {
    },
    methods: {
        onSubmit(e) {
            e.preventDefault()
            const NewInformation = {
                name: this.student.name,
                surname: this.student.surname,
                indexNumber: this.student.indexNumber,
                year: this.student.year,
                studentStatus: {
                    statusName: this.student.selected,
                    studentStatusId: this.student.studentStatus
                },
                studentStatusId: this.student.studentStatus
            }
            api.create(NewInformation).then(this.$router.push('/'));
        }
    },

};
</script>


<style>

</style>