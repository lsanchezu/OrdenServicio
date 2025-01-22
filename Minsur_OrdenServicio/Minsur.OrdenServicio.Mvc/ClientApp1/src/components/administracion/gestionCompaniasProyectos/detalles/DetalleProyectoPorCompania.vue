<template>
  <div>
    <div class="ibox float-e-margins">
      <div class="ibox-title">
        <h5>Detalle de proyectos por compañías</h5>
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
                title="Nuevo Proyecto"
                style="float:right;"
                :disabled="!nuevoProyectoEnabled"
                @click="abrirNuevoProyectoPopUp()"
              >
                <i class="fa fa-plus-square"></i>
                &nbsp; Nuevo proyecto
              </button>
            </div>
          </div>
        </div>
        <div class="row">
          <el-table
            :data="listaProyectos.filter(proyecto => !busquedaDescripcion || proyecto.descripcion.toLowerCase().includes(busquedaDescripcion.toLowerCase()))"
            row-key="idProyecto"
            v-loading="isLoadingProyectos"
            :header-row-style="tableHeaderColor"
          >
            <el-table-column prop="idProyecto" label="Código">
              <template slot-scope="scope">
                <span>{{scope.row.idProyecto | CodigoTresDigitosCeroIzquierda}}</span>
              </template>
            </el-table-column>
            <el-table-column prop="descripcion" label="Descripción"></el-table-column>
            <el-table-column prop="estado" label="Estado"></el-table-column>
            <el-table-column prop="editar" label="Editar">
              <template slot-scope="scope">
                <el-button
                  size="mini"
                  type="primary"
                  @click="editarNuevoProyectoPopUp(scope.$index, scope.row)"
                >Editar</el-button>
              </template>
            </el-table-column>
          </el-table>
        </div>
      </div>
    </div>
    <el-dialog :visible.sync="nuevoProyectoPopUpVisible" :show-close="false">
      <mantenimiento-proyecto
        v-bind:mantenimiento="mantenimiento"
        @cerrarPopUp="cerrarNuevoProyectoPopUp"
        @guardar="registrarProyecto"
      />
    </el-dialog>
    <el-dialog :visible.sync="editarProyectoPopUpVisible" :show-close="false">
      <mantenimiento-proyecto
        v-bind:mantenimiento="mantenimiento"
        @cerrarPopUp="cerrarEditarProyectoPopUp"
        @guardar="actualizarProyecto"
      />
    </el-dialog>
  </div>
</template>
<script>
import sharedFunctions from "@/common/functions";
import AdministracionService from "@/services/administracion.service";
import SwalAlert from "@/common/swal.alert";
import { ESTADOS_GENERALES } from "@/constants/maestro.constants";
import MantenimientoProyecto from "@/components/administracion/gestionCompaniasProyectos/mantenimientos/MantenimientoProyecto";

export default {
  name: "detalle-proyecto-por-compania",
  components: {
    MantenimientoProyecto
  },
  props: {
    compania: Object
  },
  data() {
    return {
      busquedaDescripcion: "",
      listaProyectos: [],
      listaEstados: [],
      isLoadingProyectos: false,
      nuevoProyectoPopUpVisible: false,
      editarProyectoPopUpVisible: false,
      nuevoProyectoEnabled: false,
      mantenimiento: {}
    };
  },
  created() {
    this.tableHeaderColor = sharedFunctions.tableHeaderColorBlack;
  },
  mounted() {
    this.$watch(
      "compania",
      compania => {
        this.obtenerProyectos();
      },
      { inmediate: true }
    );
    this.obtenerEstados();
  },
  methods: {
    obtenerProyectos() {
      this.isLoadingProyectos = true;
      AdministracionService.obtenerProyectosPorCompania({
        idCompania: this.compania.idCompania
      })
        .then(response => (this.listaProyectos = response.data.listaProyectos))
        .finally(() => {
          this.isLoadingProyectos = false;
          this.nuevoProyectoEnabled = true;
        });
    },
    obtenerEstados() {
      this.listaEstados = ESTADOS_GENERALES.LISTADO;
    },
    abrirNuevoProyectoPopUp() {
      this.mantenimiento = {
        proyecto: {
          idProyecto: 0,
          descripcion: "",
          idEstado: 1,
          idCompania: this.compania.idCompania
        },
        titulo: "Nuevo proyecto",
        listaEstados: this.listaEstados
      };
      this.nuevoProyectoPopUpVisible = true;
    },
    editarNuevoProyectoPopUp(index, row) {
      this.mantenimiento = {
        proyecto: {
          idProyecto: row.idProyecto,
          descripcion: row.descripcion,
          idEstado: row.idEstado,
          idCompania: row.idCompania
        },
        titulo: "Editar proyecto",
        listaEstados: this.listaEstados
      };
      this.editarProyectoPopUpVisible = true;
    },
    registrarProyecto(proyecto) {
      AdministracionService.registrarProyecto(proyecto).then(response => {
        if (response.data.flagError) {
          SwalAlert.error(response.data.mensaje);
          return;
        }
        SwalAlert.successAction(
          response.data.mensaje,
          this.cerrarNuevoProyectoPopUp
        );
        this.busquedaDescripcion = "";
        this.obtenerProyectos();
      });
    },
    actualizarProyecto(proyecto) {
      AdministracionService.editarProyecto(proyecto).then(response => {
        if (response.data.flagError) {
          SwalAlert.error(response.data.mensaje);
          return;
        }
        SwalAlert.successAction(
          response.data.mensaje,
          this.cerrarEditarProyectoPopUp
        );
        this.obtenerProyectos();
      });
    },
    cerrarNuevoProyectoPopUp() {
      this.nuevoProyectoPopUpVisible = false;
    },
    cerrarEditarProyectoPopUp() {
      this.editarProyectoPopUpVisible = false;
    }
  }
};
</script>