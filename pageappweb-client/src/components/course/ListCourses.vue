<template>
    <div class="header">
        <h1>Courses</h1>
    </div>
    <div class="tableContainer">
        <button>
            <router-link to="/CreateCourse">Add</router-link>
        </button>

        <table>
            <tr>
                <th>Course Name</th>
                <th>

                </th>
            </tr>
            <tr v-for="item in courses" :key="courseId">
                <td>{{ item.courseName }}</td>
                <td class="test">
                    <router-link to='/CourseDetails/{{item.courseId}}' @click="changeState(item.courseId)"><img
                            src="../../assets/search.png" alt="details" title="Details" />
                    </router-link>
                </td>
            </tr>

        </table>
    </div>
</template>

<script>
import api from '@/CourseApiService'
export default {
    data() {
        return {
            courses: []
        }
    },
    mounted() {
        setTimeout(() => {
            this.getCourses();
        }, 500);
    },
    created() {
        api.getAccessToken();
    },
    methods: {
        getCourses() {
            api.getAll()
                .then(response => {
                    this.courses = response;
                });
        },
        changeState(courseId) {
            let course = this.courses.filter(e => e.courseId == courseId)
            this.$store.commit("changeCourse", course[0])
        }
    },
    name: "ListCourses"

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
