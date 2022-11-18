import Vue from 'vue'
import axios from 'axios'
import store from './store'

const client = axios.create({
    baseURL: 'https://localhost:7024/api/student/',
    json: true
});

let accessToken;
const tokenConfig = {
    grant_type: 'client_credentials',
    scope: 'pageApp.write',
    client_id: 'pageAppWeb',
    client_secret: 'pageApp'
}
export default {
    execute(method, resource, data) {
        if (accessToken == undefined) {
            accessToken = store.getters.accessToken;
        }
        console.log(data);

        return client({
            method,
            url: method + resource,
            data,
            headers: {
                Authorization: `Bearer ${accessToken}`
            }
        }).then(req => {
            return req.data
        })
    },
    getAll() {
        return this.execute('get', '/')
    },
    create(data) {
        return this.execute('post', '/', data)
    },
    update(id, data) {
        return this.execute('put', `/${id}`, data)
    },
    delete(id) {
        return this.execute('delete', `/${id}`)
    },
    getAccessToken() {
        axios.post("https://localhost:7138/connect/token",
            tokenConfig,
            { headers: { "Content-Type": "application/x-www-form-urlencoded" } })
            .then((value) => {
                accessToken = value.data.access_token;
                store.commit("changeAccessToken", accessToken);
            });
    }
}