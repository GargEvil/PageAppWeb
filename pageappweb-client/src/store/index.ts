import { createStore } from 'vuex'
import Vue from 'vue';


export default createStore({
  state: {
    student: {},
    accessToken: {},
    course: {}
  },
  getters: {
    student: state => {
      return state.student;
    },
    accessToken: state => {
      return state.accessToken;
    },
    course: state => {
      return state.course;
    }
  },
  mutations: {
    changeStudent(state, student) {
      state.student = student;
    },
    changeAccessToken(state, accessToken) {
      state.accessToken = accessToken;
    },
    changeCourse(state, course) {
      state.course = course;
    }
  },
  actions: {
  },
  modules: {
  }
})
