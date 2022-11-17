import ListStudents from '@/components/ListStudents.vue'
import CreateStudent from '@/components/CreateStudent.vue'
import StudentDetails from '@/components/StudentDetails.vue'

import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import UpdateStudent from '@/components/UpdateStudent.vue'

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
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
