import Vue from "vue"

Vue.filter("CodigoTresDigitosCeroIzquierda", value => ("0000" + value).slice(-4))
