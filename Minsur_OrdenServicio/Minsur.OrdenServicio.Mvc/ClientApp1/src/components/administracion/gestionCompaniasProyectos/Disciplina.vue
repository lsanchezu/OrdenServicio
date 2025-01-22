<template>
  <div>
    <div class="col-lg-12">
      <div class="ibox float-e-margins">
        <div class="ibox-title">
          <h5>Lista de disciplinas</h5>
        </div>
        <div class="ibox-content m-b-sm border-bottom">
          <div class="row">
            <div class="col-lg-6">
              <div class="form-group">
                <label class="control-label" for="descripcion">Descripción</label>
                <input
                  type="text"
                  name="descripcion"
                  v-model="busquedaDescripcion"
                  class="form-control"
                />
              </div>
            </div>
            <div class="col-lg-6">
              <div class="form-group">
                <label class="control-label" style="display:block;" for>&nbsp;</label>
                <button
                  class="btn btn-primary"
                  type="button"
                  title="Nueva Disciplina"
                  style="float:right;"
                  @click="abrirNuevaDisciplinaPopUp()"
                >
                  <i class="fa fa-plus-square"></i>
                  &nbsp; Nueva disciplina
                </button>
              </div>
            </div>
          </div>
          <div class="row">
            <el-table
              :data="listaDisciplinas.filter(disciplina => !busquedaDescripcion || disciplina.descripcion.toLowerCase().includes(busquedaDescripcion.toLowerCase()))"
              row-key="idDisciplina"
              v-loading="isLoadingDisciplinas"
              :header-row-style="tableHeaderColor"
            >
              <el-table-column prop="idDisciplina" label="Código">
                <template slot-scope="scope">
                  <span>{{scope.row.idDisciplina | CodigoTresDigitosCeroIzquierda}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="descripcion" label="Descripción"></el-table-column>
              <el-table-column prop="estado" label="Estado"></el-table-column>
              <el-table-column prop="editar" label="Editar">
                <template slot-scope="scope">
                  <el-button
                    size="mini"
                    type="primary"
                    @click="editarNuevaDisciplinaPopUp(scope.$index, scope.row)"
                  >Editar</el-button>
                </template>
              </el-table-column>
            </el-table>
          </div>
        </div>
      </div>
    </div>
    <el-dialog :visible.sync="nuevaDisciplinaPopUpVisible" :show-close="false">
      <mantenimiento-disciplina
        v-bind:mantenimiento="mantenimiento"
        @cerrarPopUp="cerrarNuevaDisciplinaPopUp"
        @guardar="registrarDisciplina"
      />
    </el-dialog>
    <el-dialog :visible.sync="editarDisciplinaPopUpVisible" :show-close="false">
      <mantenimiento-disciplina
        v-bind:mantenimiento="mantenimiento"
        @cerrarPopUp="cerrarEditarDisciplinaPopUp"
        @guardar="actualizarDisciplina"
      />
    </el-dialog>
  </div>
</template>
<script>
import AdministracionService from "@/services/administracion.service";
import SwalAlert from "@/common/swal.alert";
import { ESTADOS_GENERALES } from "@/constants/maestro.constants";
import MantenimientoDisciplina from "@/components/administracion/gestionCompaniasProyectos/mantenimientos/MantenimientoDisciplina";
import "@/common/filters";
import sharedFunctions from "@/common/functions";

export default {
  name: "disciplina",
  components: {
    MantenimientoDisciplina
  },
  data() {
    return {
      busquedaDescripcion: "",
      listaDisciplinas: [],
      listaEstados: [],
      isLoadingDisciplinas: false,
      nuevaDisciplinaPopUpVisible: false,
      editarDisciplinaPopUpVisible: false,
      mantenimiento: {}
    };
  },
  created() {
    this.tableHeaderColor = sharedFunctions.tableHeaderColorBlack;
  },
  mounted() {
    this.obtenerDisciplinas();
    this.obtenerEstados();
  },
  methods: {
    obtenerDisciplinas() {
      this.isLoadingDisciplinas = true;
      AdministracionService.obtenerDisciplinas()
        .then(response => (this.listaDisciplinas = response.data.listaDisciplinas))
        .finally(() => (this.isLoadingDisciplinas = false));
    },
    obtenerEstados() {
      this.listaEstados = ESTADOS_GENERALES.LISTADO;
    },
    abrirNuevaDisciplinaPopUp() {
      this.mantenimiento = {
        disciplina: {
          idDisciplina: 0,
          descripcion: "",
          idEstado: 1
        },
        titulo: "Nueva disciplina",
        listaEstados: this.listaEstados
      };
      this.nuevaDisciplinaPopUpVisible = true;
    },
    editarNuevaDisciplinaPopUp(index, row) {
      this.mantenimiento = {
        disciplina: {
          idDisciplina: row.idDisciplina,
          descripcion: row.descripcion,
          idEstado: row.idEstado
        },
        titulo: "Editar disciplina",
        listaEstados: this.listaEstados
      };
      this.editarDisciplinaPopUpVisible = true;
    },
    registrarDisciplina(disciplina) {
      AdministracionService.registrarDisciplina(disciplina).then(response => {
        if (response.data.flagError) {
          SwalAlert.error(response.data.mensaje);
          return;
        }
        SwalAlert.successAction(
          response.data.mensaje,
          this.cerrarNuevaDisciplinaPopUp
        );
        this.busquedaDescripcion = "";
        this.obtenerDisciplinas();
      });
    },
    actualizarDisciplina(disciplina) {
      AdministracionService.editarDisciplina(disciplina).then(response => {
        if (response.data.flagError) {
          SwalAlert.error(response.data.mensaje);
          return;
        }
        SwalAlert.successAction(
          response.data.mensaje,
          this.cerrarEditarDisciplinaPopUp
        );
        this.obtenerDisciplinas();
      });
    },
    cerrarNuevaDisciplinaPopUp() {
      this.nuevaDisciplinaPopUpVisible = false;
    },
    cerrarEditarDisciplinaPopUp() {
      this.editarDisciplinaPopUpVisible = false;
    }
  }
};
</script>

