<template>
  <div>
    <div class="col-lg-6">
      <div class="ibox float-e-margins">
        <div class="ibox-title">
          <h5>Lista de compañías</h5>
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
                  title="Nueva Compañía"
                  style="float:right;"
                  @click="abrirNuevaCompaniaPopUp()"
                >
                  <i class="fa fa-plus-square"></i>
                  &nbsp; Nueva compañía
                </button>
              </div>
            </div>
          </div>
          <div class="row">
            <el-table
              :data="listaCompanias.filter(compania => !busquedaDescripcion || compania.descripcion.toLowerCase().includes(busquedaDescripcion.toLowerCase()))"
              row-key="idCompania"
              v-loading="isLoadingCompanias"
              :header-row-style="tableHeaderColor"
              @row-click="seleccionarCompania"
            >
              <el-table-column prop="idCompania" label="Código">
                <template slot-scope="scope">
                  <span>{{scope.row.idCompania | CodigoTresDigitosCeroIzquierda}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="descripcion" label="Descripción"></el-table-column>
              <el-table-column prop="estado" label="Estado"></el-table-column>
              <el-table-column prop="editar" label="Editar">
                <template slot-scope="scope">
                  <el-button
                    size="mini"
                    type="primary"
                    @click="editarNuevaCompaniaPopUp(scope.$index, scope.row)"
                  >Editar</el-button>
                </template>
              </el-table-column>
            </el-table>
          </div>
        </div>
      </div>
    </div>
    <div class="col-lg-6">
      <detalle-proyecto-por-compania v-bind:compania="companiaSeleccionada" />
    </div>
    <el-dialog :visible.sync="nuevaCompaniaPopUpVisible" :show-close="false">
      <mantenimiento-compania
        v-bind:mantenimiento="mantenimiento"
        @cerrarPopUp="cerrarNuevaCompaniaPopUp"
        @guardar="registrarCompania"
      />
    </el-dialog>
    <el-dialog :visible.sync="editarCompaniaPopUpVisible" :show-close="false">
      <mantenimiento-compania
        v-bind:mantenimiento="mantenimiento"
        @cerrarPopUp="cerrarEditarCompaniaPopUp"
        @guardar="actualizarCompania"
      />
    </el-dialog>
  </div>
</template>
<script>
import sharedFunctions from "@/common/functions";
import AdministracionService from "@/services/administracion.service";
import SwalAlert from "@/common/swal.alert";
import { ESTADOS_GENERALES } from "@/constants/maestro.constants";
import MantenimientoCompania from "@/components/administracion/gestionCompaniasProyectos/mantenimientos/MantenimientoCompania";
import DetalleProyectoPorCompania from "@/components/administracion/gestionCompaniasProyectos/detalles/DetalleProyectoPorCompania";

export default {
  name: "compania",
  components: {
    MantenimientoCompania,
    DetalleProyectoPorCompania
  },
  data() {
    return {
      busquedaDescripcion: "",
      listaCompanias: [],
      listaEstados: [],
      isLoadingCompanias: false,
      nuevaCompaniaPopUpVisible: false,
      editarCompaniaPopUpVisible: false,
      mantenimiento: {},
      companiaSeleccionada: {}
    };
  },
  created() {
    this.tableHeaderColor = sharedFunctions.tableHeaderColorBlack;
  },
  mounted() {
    this.obtenerCompanias();
    this.obtenerEstados();
  },
  methods: {
    obtenerCompanias() {
      this.isLoadingCompanias = true;
      AdministracionService.obtenerCompanias()
        .then(response => (this.listaCompanias = response.data.listaCompanias))
        .finally(() => (this.isLoadingCompanias = false));
    },
    obtenerEstados() {
      this.listaEstados = ESTADOS_GENERALES.LISTADO;
    },
    abrirNuevaCompaniaPopUp() {
      this.mantenimiento = {
        compania: {
          idCompania: 0,
          descripcion: "",
          idEstado: 1
        },
        titulo: "Nueva compañía",
        listaEstados: this.listaEstados
      };
      this.nuevaCompaniaPopUpVisible = true;
    },
    editarNuevaCompaniaPopUp(index, row) {
      this.mantenimiento = {
        compania: {
          idCompania: row.idCompania,
          descripcion: row.descripcion,
          idEstado: row.idEstado
        },
        titulo: "Editar compañía",
        listaEstados: this.listaEstados
      };
      this.editarCompaniaPopUpVisible = true;
    },
    registrarCompania(compania) {
      AdministracionService.registrarCompania(compania).then(response => {
        if (response.data.flagError) {
          SwalAlert.error(response.data.mensaje);
          return;
        }
        SwalAlert.successAction(
          response.data.mensaje,
          this.cerrarNuevaCompaniaPopUp
        );
        this.busquedaDescripcion = "";
        this.obtenerCompanias();
      });
    },
    actualizarCompania(compania) {
      AdministracionService.editarCompania(compania).then(response => {
        if (response.data.flagError) {
          SwalAlert.error(response.data.mensaje);
          return;
        }
        SwalAlert.successAction(
          response.data.mensaje,
          this.cerrarEditarCompaniaPopUp
        );
        this.obtenerCompanias();
      });
    },
    cerrarNuevaCompaniaPopUp() {
      this.nuevaCompaniaPopUpVisible = false;
    },
    cerrarEditarCompaniaPopUp() {
      this.editarCompaniaPopUpVisible = false;
    },
    seleccionarCompania(row) {
      this.companiaSeleccionada = row;
    }
  }
};
</script>

<style>
.el-tabs__content {
  background: #f3f3f4;
}
.el-table__row {
  cursor: pointer;
}
</style>