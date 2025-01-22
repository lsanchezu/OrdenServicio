import {ID_TOKEN_KEY} from '../constants/api.contants';

export default {
  obtenerToken () {
    return window.localStorage.getItem(ID_TOKEN_KEY)
  },

  guardarToken (token) {
    window.localStorage.setItem(ID_TOKEN_KEY, token)
  },

  eliminarToken () {
    window.localStorage.removeItem(ID_TOKEN_KEY)
  }
}