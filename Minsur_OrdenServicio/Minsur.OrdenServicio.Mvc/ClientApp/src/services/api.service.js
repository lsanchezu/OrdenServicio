import axios from 'axios'
import toastr from 'toastr'
import JwtService from './jwt.service'
import SwalAlert from '@/common/swal.alert'

const ApiService = {
    init() {
        axios.defaults.baseURL = "/"
        axios.interceptors.request.use(function(config) {
            const token = JwtService.obtenerToken();
            if (token !== null) {
                config.headers.Authorization = `Bearer ${token}`;
            }

            return config;
        }, function(err) {
            return Promise.reject(err);
        });
    },
    query(url, params) {
        return axios
            .get(url, params)
            .catch((error) => {
                throw new Error(`[RWV] ApiService ${error}`)
            })
    },
    get(url, queryString = '') {
        return this.request('GET', `${url}`, queryString);
    },
    post(url, data, multipart = false) {
        return this.request('POST', `${url}`, data, multipart);
    },
    update(url, slug, params) {
        return axios.put(`${url}/${slug}`, params)
    },
    put(url, params) {
        return axios
            .put(`${url}`, params)
    },
    
    delete(url) {
        return axios
            .delete(url)
            .catch((error) => {
                throw new Error(`[RWV] ApiService ${error}`)
            })
    },
    request(method, url, data, multipart) {
        let body = data;
        let headers = {
            'Authorization': `Bearer ${JwtService.obtenerToken()}`,
            'Accept': 'application/json'
        };

        if (multipart) {
            headers['Content-Type'] = 'multipart/form-data';
            body = data;
        } else if ((typeof data === 'object')) {
            headers['Content-Type'] = 'application/json';
            body = JSON.stringify(data);
        } else {
            headers['Content-Type'] = 'application/x-www-form-urlencoded';
        }

        return axios({
                url: url,
                method: method,
                data: body,
                headers: headers
            }).then((response) => {
                response = {
                    is_error: false,
                    data: response.data
                };
                return response;

            })
            .catch((error) => {
                if (error.response.status === 401) {
                    JwtService.eliminarToken();
                    window.location.replace(`/`);
                } else {
                    SwalAlert.error("Ocurrió un error al realizar la operación");
                }
            });
    }
}

export default ApiService