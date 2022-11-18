<template>
    <div class="header">
        <h1>Create Course</h1>
    </div>
    <div class="container">
        <form @submit="onSubmit" class="add-form">
            <div class="row">
                <div class="col-25">
                    <label for="name">Name:</label><br>
                </div>
                <div class="col-75">
                    <input v-model="courseName" type="text" placeholder="Enter course name" /><br>
                </div>
            </div>
            <div>
                <table>
                    <tr>
                        <th>Pick a student</th>
                        <th>

                        </th>
                    </tr>
                    <tr v-for="item in students">
                        <td>{{ item.name }} {{ item.surname }}</td>
                        <td class="test">
                            <button type="button" @click="addStudent(item)"><img src="../../assets/plus.png" alt="plus"
                                    title="plus" />
                            </button>
                        </td>
                    </tr>

                </table>
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
import apiCourse from '@/CourseApiService';
import api from "@/StudentsApiService";

export default {
    data() {
        return {
            courseName: '',
            students: [],
            selectedStudents: []
        }

    },
    mounted() {
        setTimeout(() => {
            this.getStudents();
        }, 500);
    },
    name: "CreateCourse",

    props: {
    },
    methods: {
        getStudents() {
            api.getAll().then((response) => {
                this.students = response;
            });
        },
        addStudent(student) {
            this.selectedStudents.push(student);
            this.students = this.students.filter(e => e.studentId != student.studentId);
            console.log("seleceted", this.selectedStudents);
        },
        onSubmit(e) {
            e.preventDefault()
            console.log(this.courseName);
            const newCourse = {
                courseName: this.courseName,
                students: this.selectedStudents
            }
            console.log("new", newCourse);
            apiCourse.create(newCourse).then(this.$router.push('/'));
        }
    },

};
</script>

<style>
input[type=text],
input[type=number],
select,
textarea {
    width: 100%;
    padding: 12px;
    border: 1px solid #ccc;
    border-radius: 4px;
    resize: vertical;
    width: 85%;

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