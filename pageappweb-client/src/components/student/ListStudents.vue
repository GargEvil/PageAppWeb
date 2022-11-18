<template>
    <div class="header">
        <h1>Students</h1>
        <p class="row">
            <router-link to="/courses" style="color:white;">Courses</router-link>
        </p>
    </div>
    <div class="tableContainer">
        <button>
            <router-link to="/CreateStudent" style="color:white; text-decoration:none;">Add</router-link>
        </button>

        <table>
            <tr>
                <th>Student Name</th>
                <th>Index Number</th>
                <th>Year</th>
                <th>

                </th>
            </tr>
            <tr v-for="item in students" :key="studentId">
                <td>{{ item.name }} {{ item.surname }}</td>
                <td>{{ item.indexNumber }}</td>
                <td>{{ item.year }}</td>
                <td class="test">
                    <img src="../../assets/delete.png" alt="delete" title="Delete student"
                        @click="deleteStudent(item.studentId)" />
                    <router-link to='/UpdateStudent/{{item.studentId}}' @click="changeState(item.studentId)"><img
                            src="../../assets/edit.png" alt="edit" title="Edit student info" />
                    </router-link>
                    <router-link to='/StudentDetails/{{item.studentId}}' @click="changeState(item.studentId)"><img
                            src="../../assets/search.png" alt="details" title="Details" />
                    </router-link>
                </td>
            </tr>

        </table>
    </div>
</template>

<script>
import api from '@/StudentsApiService';

export default {
    data() {
        return {
            students: []
        }
    },
    mounted() {
        setTimeout(() => {
            this.getStudents();
        }, 500);

    },
    created() {
        api.getAccessToken();
    },
    methods: {
        getStudents() {
            api.getAll()
                .then(response => {
                    this.students = response;
                });
        },
        changeState(studentId) {
            let student = this.students.filter(e => e.studentId == studentId)
            student[0].statusName = student[0].studentStatus.statusName
            this.$store.commit("changeStudent", student[0])
        },
        deleteStudent(studentId) {
            api.delete(studentId).then(
                this.students = this.students.filter(e => e.studentId != studentId));
        }
    },
    name: "ListStudents"

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

.tableContainer {
    width: 90%;
    align-items: center;
    justify-content: center;
    margin: auto;
    margin-top: 5%;
}

button {
    background: #1abc9c;
    border: none;
    width: 150px;
    color: white;
    height: 30px;
    margin-top: 1%;
    margin-left: auto;
    display: flex;
    align-items: center;
    justify-content: center;
}

table {
    font-family: arial, sans-serif;
    border-collapse: collapse;
    width: 100%;
    margin-top: 2%;
}

td,
th {
    border: 1px solid #dddddd;
    text-align: left;
    padding: 8px;
}

tr:nth-child(even) {
    background-color: #dddddd;
}

img {
    width: 20px;
    height: 20px;
    padding: 5px;
}

.test {
    display: flex;
    align-items: center;
    justify-content: center;
}
</style>
