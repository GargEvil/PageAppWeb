<template>
    <div class="header">
        <h1>Course Details</h1>
    </div>
    <div class="tableContainer">
        <table>
            <tr>
                <th>Student Going To Course</th>
                <th>

                </th>
            </tr>
            <tr v-for="item in students">
                <!--v-for="item in courses" :key="courseId"-->
                <td>{{ item.name }} {{ item.surname }}</td>
                <!--{{ item.courseName }}-->
                <td class="test">
                    <!-- <router-link to='/CourseDetails/{{item.courseId}}' @click="changeState(item.courseId)"><img
                            src="../../assets/search.png" alt="details" title="Details" />
                    </router-link> -->
                </td>
            </tr>

        </table>
    </div>
</template>

<script>
import api from '@/StudentsApiService'

export default {
    data() {
        return {
            course: {},
            students: []
        }
    },
    mounted() {
        setTimeout(() => {
            this.getStudentsForCourse();
        }, 500);
    },
    created() {
        this.course = this.$store.getters.course;
        api.getAccessToken();
    },
    methods: {
        getStudentsForCourse() {
            api.getStudentsByCourseId(this.course.courseId)
                .then(response => {
                    this.students = response;
                });
        }
    },
    name: "CourseDetails"

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
