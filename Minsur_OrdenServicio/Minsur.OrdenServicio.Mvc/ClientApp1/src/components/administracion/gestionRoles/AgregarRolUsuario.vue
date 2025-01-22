<template>
  <div>
    <div class="ibox float-e-margins">
      <div class="ibox-title">
        <h5>Agregar Usuario</h5>
      </div>
    </div>
    <div class="ibox-content m-b-sm">
      <div class="row">
        <div class="form-group">
          <label class="control-label" for="descripcion">Correo</label>
          <input
            type="text"
            name="descripcion"
            v-model="usuario.correo"
            class="form-control"
          />
        </div>
      </div>
      <div class="row">
        <label class="control-label" style="display:block;" for>&nbsp;</label>
        <div class="text-right">
          <button class="btn btn-primary" type="button" @click="agregar">
            <i class="fa fa-save">&nbsp; Agregar Usuario</i>
          </button>
          <button class="btn btn-primary" type="button" @click="cerrarPopUp">
            <i class="fa fa-reply">&nbsp; Cancelar</i>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "agregar-rol-usuario",
  props: {
    usuario: Object
  },
  methods: {
    agregar() {
      if (isBlank(this.usuario.correo)) {
        swal(
          "Mensaje",
          "Debe ingresar el correo del usuario",
          "warning"
        );
        return;
      }
      this.$emit("agregar");
    },
    cerrarPopUp() {
      this.$emit("cerrarPopUp");
    }
  }
};
</script>