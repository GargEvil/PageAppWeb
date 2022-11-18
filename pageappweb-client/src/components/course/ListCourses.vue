<template>
    <div class="header">
        <h1>Courses</h1>
    </div>
    <div class="tableContainer">
        <button>
            <router-link to="/CreateCourse">Add</router-link>
        </button>


    </div>
</template>

<script>
export default {
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
