import axios from 'axios'
import store from './store'

const client = axios.create({
    baseURL: 'https://localhost:7024/api/course/',
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