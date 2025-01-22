<template>
  <div>
    <div class="ibox float-e-margins">
      <div class="ibox-title">
        <h5>Lista de Disciplinas</h5>
      </div>
    </div>
    <div class="ibox-content m-b-sm">
      <div class="row">
        <div class="table-responsive m-t table-height">
          <table class="table table-striped">
            <thead>
              <tr>
                <th class="text-center">Disciplina</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="(item, index) in configuracion.listaRolDisciplinaDto"
                :key="index"
              >
                <td>{{ item.descripcion }}</td>
                <td class="text-center">
                  <input type="checkbox" v-model="item.idEstado" />
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "disciplinas-usuario",
  props: {
    configuracion: Object
  },
  methods: {
    cerrarPopUp() {
      this.$emit("cerrarPopUp");
    }
  }
};
</script>
<style scoped>
@media only screen and (min-width: 768px) {
  .table-height {
    height: 50vh;
  }
}
</style>