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
                    <input v-model="course.name" type="text" placeholder="Enter course name" /><br>
                </div>
            </div>
            <div class="col-75">
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
            course: {
                name: "",
                students: []
            }
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
                this.course.students = response;
            });
        },
        onSubmit(e) {
            e.preventDefault()
            console.log(this.course);
            const NewInformation = {
                name: this.student.name,
                students: [{
                    statusName: this.student.selected,
                    studentStatusId: this.student.studentStatus
                }],
            }
            api.create(NewInformation).then(this.$router.push('/'));
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