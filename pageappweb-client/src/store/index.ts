import { createStore } from 'vuex'
import Vue from 'vue';


export default createStore({
  state: {
    student: {},
    accessToken: {}
  },
  getters: {
    student: state => {
      return state.student;
    },
    accessToken: state => {
      return state.accessToken;
    }
  },
  mutations: {
    changeStudent(state, student) {
      state.student = student;
    },
    changeAccessToken(state, accessToken) {
      console.log("kad do ovog dodje");

      state.accessToken = accessToken;
    }
  },
  actions: {
  },
  modules: {
  }
})
