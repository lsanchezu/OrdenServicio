<template>
  <div>
    <div class="row">
      <div class="ibox-title">
        <h5>Lista de gobernanzas</h5>
      </div>
      <div class="ibox-content m-b-sm border-bottom">
        <div class="row" v-loading="isLoading">
          <div class="col-lg-3">
            <div class="form-group">
              <label class="control-label" for="compania">Compañía</label>
              <select
                name="compania"
                class="form-control"
                v-model="idCompaniaSeleccionada"
                @change="obtenerProyectosActivos"
              >
                <option
                  v-for="item in listaCompanias"
                  :value="item.idCompania"
                  :key="item.idCompania"
                  >{{ item.descripcion }}</option
                >
              </select>
            </div>
          </div>
          <div class="col-lg-3">
            <div class="form-group">
              <label class="control-label" for="proyecto">Proyecto</label>
              <select
                name="compania"
                class="form-control"
                v-model="idProyectoSeleccionado"
                @change="obtenerConfiguracionGobernanzaPorProyecto"
              >
                <option
                  v-for="item in listaProyectos"
                  :value="item.idProyecto"
                  :key="item.idProyecto"
                  >{{ item.descripcion }}</option
                >
              </select>
            </div>
          </div>
        </div>
        <div class="row" v-loading="isConfiguracionGobernanzaLoading">
          <div class="table-responsive m-t">
            <table class="table table-striped custom-table">
              <thead>
                <tr>
                  <th></th>
                  <th class="text-center">Gobernanza</th>
                </tr>
              </thead>
              <tbody>
                <tr
                  v-for="(item, index) in listaConfiguracionGobernanza"
                  :key="index"
                >
                  <td class="text-center">
                    <input
                      type="checkbox"
                      v-model="item.idEstado"
                      :disabled="item.gobernanzaDto.idGobernanza === 0"
                    />
                  </td>
                  <td>{{ item.gobernanzaDto.descripcion }}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-lg-12">
          <button
            class="btn btn-primary"
            type="button"
            style="float:right;"
            @click="guardar"
            :disabled="idProyectoSeleccionado === 0"
          >
            <i class="fa fa-save"></i> Guardar
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import AdministracionService from "@/services/administracion.service";
import SwalAlert from "@/common/swal.alert";
import { ESTADOS_GENERALES } from "@/constants/maestro.constants";

export default {
  name: "gobernanza",
  data() {
    return {
      idCompaniaSeleccionada: 0,
      idProyectoSeleccionado: 0,
      listaCompanias: [],
      listaProyectos: [],
      listaConfiguracionGobernanza: [],
      isLoading: false,
      isConfiguracionGobernanzaLoading: false
    };
  },
  mounted() {
    this.obtenerCompaniasActivas();
    this.listaProyectos.unshift({
      idProyecto: 0,
      idEstado: ESTADOS_GENERALES.ACTIVO,
      descripcion: ":: SELECCIONE ::"
    });
  },
  methods: {
    obtenerCompaniasActivas() {
      this.isLoading = true;
      AdministracionService.obtenerCompanias()
        .then(
          response =>
            (this.listaCompanias = response.data.listaCompanias.filter(
              compania => compania.idEstado === ESTADOS_GENERALES.ACTIVO
            ))
        )
        .then(() =>
          this.listaCompanias.unshift({
            idCompania: 0,
            idEstado: ESTADOS_GENERALES.ACTIVO,
            descripcion: ":: SELECCIONE ::"
          })
        )
        .then(
          () =>
            (this.idCompaniaSeleccionada = this.listaCompanias[0].idCompania)
        )
        .finally(() => (this.isLoading = false));
    },
    obtenerProyectosActivos() {
      this.listaProyectos = null;
      this.listaConfiguracionGobernanza = [];
      this.isLoading = true;
      AdministracionService.obtenerProyectosPorCompania({
        idCompania: this.idCompaniaSeleccionada
      })
        .then(
          response =>
            (this.listaProyectos = response.data.listaProyectos.filter(
              proyecto => proyecto.idEstado === ESTADOS_GENERALES.ACTIVO
            ))
        )
        .then(() =>
          this.listaProyectos.unshift({
            idProyecto: 0,
            idEstado: ESTADOS_GENERALES.ACTIVO,
            descripcion: ":: SELECCIONE ::"
          })
        )
        .then(
          () =>
            (this.idProyectoSeleccionado = this.listaProyectos[0].idProyecto)
        )
        .finally(() => (this.isLoading = false));
    },
    obtenerConfiguracionGobernanzaPorProyecto() {
      if (this.idProyectoSeleccionado === 0) {
        this.listaConfiguracionGobernanza = [];
        return;
      }
      this.isConfiguracionGobernanzaLoading = true;
      AdministracionService.obtenerConfiguracionGobernanzaPorProyecto({
        idProyecto: this.idProyectoSeleccionado
      })
        .then(response => {
          this.listaConfiguracionGobernanza =
            response.data.listaConfiguracionGobernanza;
          this.listaConfiguracionGobernanza.unshift(
            {
              idConfiguracionGobernanza: 0,
              idEstado: 1,
              flagApruebaSolicitud: false,
              gobernanzaDto: {
                idGobernanza: 0,
                descripcion: "Encargado de Control de Proyectos",
                flagApruebaSolicitud: false,
                orden: 0
              }
            },
            {
              idConfiguracionGobernanza: 0,
              idEstado: 1,
              flagApruebaSolicitud: false,
              gobernanzaDto: {
                idGobernanza: 0,
                descripcion: "Encargado de Procura y Contrato",
                flagApruebaSolicitud: false,
                orden: 0
              }
            }
          );
        })
        .finally(() => (this.isConfiguracionGobernanzaLoading = false));
    },
    guardar() {
      this.$store.commit(`solicitudServicio/SET_LOADING`, true);
      let gobernanzaRequest = {
        listaConfiguracionGobernanzaDto: this.listaConfiguracionGobernanza.filter(x => x.gobernanzaDto.idGobernanza),
        idProyecto: this.idProyectoSeleccionado
      };
      gobernanzaRequest.listaConfiguracionGobernanzaDto.map(item => {
        item.idEstado = item.idEstado ? 1 : 0;
      });
      AdministracionService.guardarConfiguracionGobernanzaPorProyecto(
        gobernanzaRequest
      ).then(response => {
        this.$store.commit(`solicitudServicio/SET_LOADING`, false);
        if (response.data.flagError) {
          SwalAlert.error(response.data.mensaje);
          return;
        }
        SwalAlert.success(response.data.mensaje);
        this.obtenerConfiguracionGobernanzaPorProyecto();
      });
    }
  }
};
</script>