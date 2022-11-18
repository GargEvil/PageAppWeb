import ListStudents from '@/components/student/ListStudents.vue'
import CreateStudent from '@/components/student/CreateStudent.vue'
import StudentDetails from '@/components/student/StudentDetails.vue'
import UpdateStudent from '@/components/student/UpdateStudent.vue'
import ListCourses from '@/components/course/ListCourses.vue'
import CourseDetails from '@/components/course/CourseDetails.vue'
import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'



const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'home',
    component: ListStudents
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this {route}
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  {
    path: '/courses',
    name: 'ListCourses',
    component: ListCourses
  },
  {
    path: '/CreateStudent',
    name: 'CreateStudent',
    component: CreateStudent
  },
  {
    path: '/StudentDetails/:studentId',
    name: 'StudentDetails',
    component: StudentDetails
  },
  {
    path: '/UpdateStudent/:studentId',
    name: 'UpdateStudent',
    component: UpdateStudent
  },
  {
    path: '/CourseDetails/:courseId',
    name: 'CourseDetails',
    component: CourseDetails
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
