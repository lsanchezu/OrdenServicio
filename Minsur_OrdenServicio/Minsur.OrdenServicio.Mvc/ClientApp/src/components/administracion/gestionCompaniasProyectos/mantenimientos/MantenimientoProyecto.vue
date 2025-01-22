<template>
  <div>
    <div class="ibox float-e-margins">
      <div class="ibox-title">
        <h5>{{mantenimiento.titulo}}</h5>
      </div>
      <div class="ibox-content m-b-sm">
        <div class="row">
          <div class="col-lg-8">
            <div class="form-group">
              <label class="control-label" for="descripcion">Descripción</label>
              <input
                type="text"
                name="descripcion"
                v-model="mantenimiento.proyecto.descripcion"
                class="form-control"
              />
            </div>
          </div>
          <div class="col-lg-4">
            <div class="form-group">
              <label class="control-label" for="estado">Estado</label>
              <select name="estado" class="form-control" v-model="mantenimiento.proyecto.idEstado">
                <option
                  v-for="item in mantenimiento.listaEstados"
                  v-bind:value="item.idEstado"
                  :key="item.idEstado"
                >{{item.estado}}</option>
              </select>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-lg-12">
            <label class="control-label" style="display:block;" for>&nbsp;</label>
            <div class="text-right">
              <button class="btn btn-primary" type="button" @click="guardar">
                <i class="fa fa-save">&nbsp; Guardar</i>
              </button>
              <button class="btn btn-primary" type="button" @click="cerrarPopUp">
                <i class="fa fa-reply">&nbsp; Cancelar</i>
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "mantenimiento-proyecto",
  props: {
    mantenimiento: Object
  },
  methods: {
    cerrarPopUp() {
      this.$emit("cerrarPopUp");
    },
    guardar() {
      this.$emit("guardar", this.mantenimiento.proyecto);
    }
  }
}
</script>